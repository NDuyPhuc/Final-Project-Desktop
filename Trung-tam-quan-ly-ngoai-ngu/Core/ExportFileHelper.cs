using System.Data;
using ClosedXML.Excel;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Trung_tam_quan_ly_ngoai_ngu;

internal static class ExportFileHelper
{
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
        var page = document.AddPage();
        page.Width = XUnit.FromMillimeter(210);
        page.Height = XUnit.FromMillimeter(297);

        using var gfx = XGraphics.FromPdfPage(page);
        var titleFont = new XFont("Arial", 14, XFontStyleEx.Bold);
        var bodyFont = new XFont("Arial", 9);
        double y = 30;
        gfx.DrawString(title, titleFont, XBrushes.Black, new XRect(30, y, page.Width - 60, 20), XStringFormats.TopLeft);
        y += 28;
        var header = string.Join(" | ", table.Columns.Cast<DataColumn>().Select(x => x.ColumnName));
        gfx.DrawString(header, bodyFont, XBrushes.Black, new XRect(30, y, page.Width - 60, 20), XStringFormats.TopLeft);
        y += 20;

        foreach (DataRow row in table.Rows)
        {
            var line = string.Join(" | ", row.ItemArray.Select(x => (x?.ToString() ?? string.Empty).Replace("\r", " ").Replace("\n", " ")));
            if (y > page.Height - 30)
            {
                page = document.AddPage();
                page.Width = XUnit.FromMillimeter(210);
                page.Height = XUnit.FromMillimeter(297);
                gfx.Dispose();
                using var nextGfx = XGraphics.FromPdfPage(page);
                y = 30;
                nextGfx.DrawString(line, bodyFont, XBrushes.Black, new XRect(30, y, page.Width - 60, 20), XStringFormats.TopLeft);
                y += 16;
                continue;
            }

            gfx.DrawString(line, bodyFont, XBrushes.Black, new XRect(30, y, page.Width - 60, 20), XStringFormats.TopLeft);
            y += 16;
        }

        document.Save(filePath);
    }
}
