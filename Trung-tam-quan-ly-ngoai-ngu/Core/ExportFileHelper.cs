using System.Data;
using System.Globalization;
using ClosedXML.Excel;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using TrungTamNgoaiNgu.Application.Models;

namespace Trung_tam_quan_ly_ngoai_ngu;

internal static class ExportFileHelper
{
    private const string PdfFontFamilyName = "Arial";
    private const string RegularFace = "app-arial-regular";
    private const string BoldFace = "app-arial-bold";
    private const string ItalicFace = "app-arial-italic";
    private const string BoldItalicFace = "app-arial-bold-italic";

    private static readonly CultureInfo ReceiptCulture = CultureInfo.GetCultureInfo("vi-VN");
    private static readonly XPdfFontOptions PdfFontOptions = new(PdfFontEncoding.Unicode);
    private static readonly object FontResolverLock = new();
    private static bool _fontResolverConfigured;

    public static void ExportDataTableToExcel(DataTable table, string filePath, string sheetName)
    {
        EnsureTargetDirectory(filePath);

        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add(string.IsNullOrWhiteSpace(sheetName) ? "Sheet1" : sheetName);
        for (var c = 0; c < table.Columns.Count; c++)
        {
            worksheet.Cell(1, c + 1).Value = table.Columns[c].ColumnName;
            worksheet.Cell(1, c + 1).Style.Font.Bold = true;
        }

        for (var r = 0; r < table.Rows.Count; r++)
        {
            for (var c = 0; c < table.Columns.Count; c++)
            {
                worksheet.Cell(r + 2, c + 1).Value = table.Rows[r][c]?.ToString() ?? string.Empty;
            }
        }

        worksheet.Columns().AdjustToContents();
        workbook.SaveAs(filePath);
    }

    public static void ExportDataTableToPdf(DataTable table, string filePath, string title)
    {
        EnsureTargetDirectory(filePath);
        EnsurePdfFontResolver();

        using var document = new PdfDocument();
        document.Info.Title = title;
        var titleFont = CreateFont(14, XFontStyleEx.Bold);
        var bodyFont = CreateFont(9);
        var header = string.Join(" | ", table.Columns.Cast<DataColumn>().Select(x => ToDisplayHeader(x.ColumnName)));

        var page = AddA4Page(document);
        var gfx = XGraphics.FromPdfPage(page);

        try
        {
            var y = DrawTableHeader(gfx, page, title, header, titleFont, bodyFont);

            foreach (DataRow row in table.Rows)
            {
                var line = string.Join(" | ", row.ItemArray.Select(x => NormalizePdfText(x?.ToString())));
                if (y > page.Height - 30)
                {
                    gfx.Dispose();
                    page = AddA4Page(document);
                    gfx = XGraphics.FromPdfPage(page);
                    y = DrawTableHeader(gfx, page, title, header, titleFont, bodyFont);
                }

                gfx.DrawString(line, bodyFont, XBrushes.Black, new XRect(30, y, page.Width - 60, 20), XStringFormats.TopLeft);
                y += 16;
            }
        }
        finally
        {
            gfx.Dispose();
        }

        document.Save(filePath);
    }

    public static void ExportReceiptToPdf(ReceiptPrintInfo receipt, string filePath)
    {
        ArgumentNullException.ThrowIfNull(receipt);
        EnsureTargetDirectory(filePath);
        EnsurePdfFontResolver();

        using var document = new PdfDocument();
        document.Info.Title = $"Biên lai {receipt.ReceiptId}";

        var page = AddA4Page(document);
        using var gfx = XGraphics.FromPdfPage(page);
        var titleFont = CreateFont(16, XFontStyleEx.Bold);
        var labelFont = CreateFont(10, XFontStyleEx.Bold);
        var bodyFont = CreateFont(10);
        var noteFont = CreateFont(9);
        double y = 36;

        gfx.DrawString("BIÊN LAI THU HỌC PHÍ", titleFont, XBrushes.Black, new XRect(40, y, page.Width - 80, 24), XStringFormats.TopCenter);
        y += 32;
        gfx.DrawLine(XPens.Black, 40, y, page.Width - 40, y);
        y += 18;

        y = DrawReceiptLine(gfx, page, labelFont, bodyFont, y, "Số biên lai", receipt.ReceiptId);
        y = DrawReceiptLine(gfx, page, labelFont, bodyFont, y, "Học viên", $"{receipt.StudentName} ({receipt.StudentCode})");
        y = DrawReceiptLine(gfx, page, labelFont, bodyFont, y, "Lớp", receipt.ClassName);
        y = DrawReceiptLine(gfx, page, labelFont, bodyFont, y, "Khóa học", receipt.CourseName);
        y = DrawReceiptLine(gfx, page, labelFont, bodyFont, y, "Học phí", FormatMoney(receipt.TuitionFee));
        y = DrawReceiptLine(gfx, page, labelFont, bodyFont, y, "Thu kỳ này", FormatMoney(receipt.AmountPaid));
        y = DrawReceiptLine(gfx, page, labelFont, bodyFont, y, "Tổng đã thu", FormatMoney(receipt.TotalPaid));
        y = DrawReceiptLine(gfx, page, labelFont, bodyFont, y, "Còn lại", FormatMoney(receipt.OutstandingBalance));
        y = DrawReceiptLine(gfx, page, labelFont, bodyFont, y, "Ngày nộp", receipt.PayDate.ToString("dd/MM/yyyy", ReceiptCulture));
        y = DrawReceiptLine(gfx, page, labelFont, bodyFont, y, "Phương thức", receipt.PaymentMethod);
        y = DrawReceiptLine(gfx, page, labelFont, bodyFont, y, "Nhân viên thu", receipt.StaffName ?? "Staff");
        y = DrawReceiptLine(gfx, page, labelFont, noteFont, y, "Ghi chú", string.IsNullOrWhiteSpace(receipt.Note) ? "-" : receipt.Note);

        y += 20;
        gfx.DrawLine(XPens.Black, 40, y, page.Width - 40, y);
        y += 14;
        gfx.DrawString("Tài liệu được tạo từ hệ thống quản lý trung tâm.", noteFont, XBrushes.Black, new XRect(40, y, page.Width - 80, 16), XStringFormats.TopLeft);

        document.Save(filePath);
    }

    private static PdfPage AddA4Page(PdfDocument document)
    {
        var page = document.AddPage();
        page.Width = XUnit.FromMillimeter(210);
        page.Height = XUnit.FromMillimeter(297);
        return page;
    }

    private static double DrawTableHeader(XGraphics gfx, PdfPage page, string title, string header, XFont titleFont, XFont bodyFont)
    {
        double y = 30;
        gfx.DrawString(title, titleFont, XBrushes.Black, new XRect(30, y, page.Width - 60, 20), XStringFormats.TopLeft);
        y += 28;
        gfx.DrawString(header, bodyFont, XBrushes.Black, new XRect(30, y, page.Width - 60, 20), XStringFormats.TopLeft);
        return y + 20;
    }

    private static double DrawReceiptLine(XGraphics gfx, PdfPage page, XFont labelFont, XFont valueFont, double y, string label, string value)
    {
        gfx.DrawString($"{label}:", labelFont, XBrushes.Black, new XRect(40, y, 125, 16), XStringFormats.TopLeft);
        gfx.DrawString(NormalizePdfText(value), valueFont, XBrushes.Black, new XRect(170, y, page.Width - 210, 24), XStringFormats.TopLeft);
        return y + 22;
    }

    private static XFont CreateFont(double size, XFontStyleEx style = XFontStyleEx.Regular)
    {
        return new XFont(PdfFontFamilyName, size, style, PdfFontOptions);
    }

    private static string FormatMoney(decimal amount)
    {
        return amount.ToString("N0", ReceiptCulture) + " VND";
    }

    private static string NormalizePdfText(string? value)
    {
        return (value ?? string.Empty).Replace("\r", " ").Replace("\n", " ");
    }

    private static string ToDisplayHeader(string columnName)
    {
        return columnName switch
        {
            "Ma lop" => "Mã lớp",
            "Ten lop" => "Tên lớp",
            "Khoa hoc" => "Khóa học",
            "Lich hoc" => "Lịch học",
            "Si so" => "Sĩ số",
            "Trang thai" => "Trạng thái",
            "Thao tac" => "Thao tác",
            "Ma hoc vien" => "Mã học viên",
            "Hoc vien" => "Học viên",
            "Ho ten" => "Họ tên",
            "Dien thoai" => "Điện thoại",
            "Ngay" => "Ngày",
            "Ngay hoc" => "Ngày học",
            "Ngay ghi danh" => "Ngày ghi danh",
            "Lop" => "Lớp",
            "Phai thu" => "Phải thu",
            "Da thu" => "Đã thu",
            "Con no" => "Còn nợ",
            "So tien" => "Số tiền",
            "Ngay nop" => "Ngày nộp",
            "Phuong thuc" => "Phương thức",
            "Ghi chu" => "Ghi chú",
            "Diem giua ky" => "Điểm giữa kỳ",
            "Diem cuoi ky" => "Điểm cuối kỳ",
            "Co mat" => "Có mặt",
            _ => columnName
        };
    }

    private static void EnsureTargetDirectory(string filePath)
    {
        var directory = Path.GetDirectoryName(Path.GetFullPath(filePath));
        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }

    private static void EnsurePdfFontResolver()
    {
        if (_fontResolverConfigured)
        {
            return;
        }

        lock (FontResolverLock)
        {
            if (_fontResolverConfigured)
            {
                return;
            }

            try
            {
                if (GlobalFontSettings.FontResolver is null)
                {
                    GlobalFontSettings.FontResolver = new WindowsFontResolver();
                }
            }
            catch (InvalidOperationException)
            {
                // PDFsharp locks font settings after first font use. Existing resolver can still serve fonts.
            }

            _fontResolverConfigured = true;
        }
    }

    private sealed class WindowsFontResolver : IFontResolver
    {
        private static readonly IReadOnlyDictionary<string, string> FontFiles = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            [RegularFace] = "arial.ttf",
            [BoldFace] = "arialbd.ttf",
            [ItalicFace] = "ariali.ttf",
            [BoldItalicFace] = "arialbi.ttf"
        };

        public FontResolverInfo? ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            var requestedFace = (isBold, isItalic) switch
            {
                (true, true) => BoldItalicFace,
                (true, false) => BoldFace,
                (false, true) => ItalicFace,
                _ => RegularFace
            };

            if (FontFileExists(requestedFace))
            {
                return new FontResolverInfo(requestedFace);
            }

            return new FontResolverInfo(RegularFace, isBold, isItalic);
        }

        public byte[]? GetFont(string faceName)
        {
            var fileName = FontFiles.TryGetValue(faceName, out var mappedFileName)
                ? mappedFileName
                : FontFiles[RegularFace];

            var path = FindFontFile(fileName) ?? FindFontFile(FontFiles[RegularFace]) ?? FindFontFile("segoeui.ttf");
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new InvalidOperationException("Khong tim thay font Arial hoac Segoe UI de xuat PDF.");
            }

            return File.ReadAllBytes(path);
        }

        private static bool FontFileExists(string faceName)
        {
            return FontFiles.TryGetValue(faceName, out var fileName) && FindFontFile(fileName) is not null;
        }

        private static string? FindFontFile(string fileName)
        {
            var windowsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            var candidates = new[]
            {
                Path.Combine(windowsDirectory, "Fonts", fileName),
                Path.Combine(AppContext.BaseDirectory, "Fonts", fileName),
                Path.Combine(AppContext.BaseDirectory, fileName)
            };

            return candidates.FirstOrDefault(File.Exists);
        }
    }
}
