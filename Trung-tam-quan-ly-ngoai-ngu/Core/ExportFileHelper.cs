using System.Data;
using System.Globalization;
using ClosedXML.Excel;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using TrungTamNgoaiNgu.Application.Models;

namespace Trung_tam_quan_ly_ngoai_ngu;

internal static class ExportFileHelper
{
    private static readonly CultureInfo ReceiptCulture = CultureInfo.GetCultureInfo("vi-VN");

    public static void ExportDataTableToExcel(DataTable table, string filePath, string sheetName)
    {
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
        using var document = new PdfDocument();
        document.Info.Title = title;
        var titleFont = new XFont("Arial", 14, XFontStyleEx.Bold);
        var bodyFont = new XFont("Arial", 9);
        var header = string.Join(" | ", table.Columns.Cast<DataColumn>().Select(x => x.ColumnName));

        var page = AddA4Page(document);
        var gfx = XGraphics.FromPdfPage(page);

        try
        {
            var y = DrawTableHeader(gfx, page, title, header, titleFont, bodyFont);

            foreach (DataRow row in table.Rows)
            {
                var line = string.Join(" | ", row.ItemArray.Select(x => (x?.ToString() ?? string.Empty).Replace("\r", " ").Replace("\n", " ")));
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

        using var document = new PdfDocument();
        document.Info.Title = $"Biên lai {receipt.ReceiptId}";

        var page = AddA4Page(document);
        using var gfx = XGraphics.FromPdfPage(page);
        var titleFont = new XFont("Arial", 16, XFontStyleEx.Bold);
        var labelFont = new XFont("Arial", 10, XFontStyleEx.Bold);
        var bodyFont = new XFont("Arial", 10);
        var noteFont = new XFont("Arial", 9);
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
        gfx.DrawString(value, valueFont, XBrushes.Black, new XRect(170, y, page.Width - 210, 24), XStringFormats.TopLeft);
        return y + 22;
    }

    private static string FormatMoney(decimal amount)
    {
        return amount.ToString("N0", ReceiptCulture) + " VND";
    }
}
