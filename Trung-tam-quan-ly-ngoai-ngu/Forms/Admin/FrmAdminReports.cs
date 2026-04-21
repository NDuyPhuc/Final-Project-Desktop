using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAdminReports : Form
{
    public FrmAdminReports()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Báo cáo thống kê");
        ConfigureReportSurface();
        BindReportEvents();
        LoadDefaultReport();
    }

    private void ConfigureReportSurface()
    {
        dgvAdminReportDetail.AutoGenerateColumns = true;
        AppTheme.StyleGrid(dgvAdminReportDetail);
        ConfigureChartSurface();
        cboReportType.SelectedIndex = 0;
        dtpReportFromDate.Value = new DateTime(2026, 1, 1);
        dtpReportToDate.Value = new DateTime(2026, 4, 30);
    }

    private void ConfigureChartSurface()
    {
        var area = chtAdminRevenue.ChartAreas["DefaultArea"];
        area.BackColor = Color.White;
        area.AxisX.MajorGrid.Enabled = false;
        area.AxisY.MajorGrid.LineColor = Color.FromArgb(225, 230, 239);
        area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
        area.AxisX.LineColor = Color.FromArgb(214, 220, 229);
        area.AxisY.LineColor = Color.FromArgb(214, 220, 229);
        area.AxisX.LabelStyle.ForeColor = Color.FromArgb(102, 112, 133);
        area.AxisY.LabelStyle.ForeColor = Color.FromArgb(102, 112, 133);
        area.AxisX.MajorTickMark.Enabled = false;
        area.AxisY.MajorTickMark.Enabled = false;
        var legend = chtAdminRevenue.Legends["DefaultLegend"];
        legend.Enabled = false;
    }

    private void BindReportEvents()
    {
        btnViewReport.Click += (_, _) => ApplyReportView();
        btnExportReportExcel.Click += (_, _) => ShowExportHint("Xuất Excel");
        btnExportReportPdf.Click += (_, _) => ShowExportHint("Xuất PDF");
        cboReportType.SelectedIndexChanged += (_, _) => ApplyReportView();
    }

    private void LoadDefaultReport()
    {
        ApplyReportView();
    }

    private void ApplyReportView()
    {
        var reportType = cboReportType.SelectedItem?.ToString() ?? "Doanh thu";

        switch (reportType)
        {
            case "Ghi danh":
                lblReportRevenueTitle.Text = "Tổng hồ sơ ghi danh";
                lblReportRevenueValue.Text = "152";
                lblReportRevenueNote.Text = "Bao gồm ghi danh mới và tái ghi danh";
                lblReportEnrollmentTitle.Text = "Đã xếp lớp";
                lblReportEnrollmentValue.Text = "126";
                lblReportEnrollmentNote.Text = "Đủ điều kiện vận hành lớp";
                lblReportClassCountTitle.Text = "Tỷ lệ hoàn tất";
                lblReportClassCountValue.Text = "82%";
                lblReportClassCountNote.Text = "Theo hồ sơ trong kỳ lọc";
                lblReportChartTitle.Text = "Biểu đồ ghi danh theo tháng";
                lblReportDetailTitle.Text = "Bảng tổng hợp ghi danh";
                dgvAdminReportDetail.DataSource = BuildEnrollmentReportTable();
                BindSeries(
                    "Ghi danh",
                    Color.FromArgb(0, 110, 110),
                    ("Th1", 32),
                    ("Th2", 39),
                    ("Th3", 41),
                    ("Th4", 28));
                break;

            case "Công nợ":
                lblReportRevenueTitle.Text = "Tổng công nợ";
                lblReportRevenueValue.Text = "54.300.000";
                lblReportRevenueNote.Text = "Theo học viên còn nghĩa vụ thanh toán";
                lblReportEnrollmentTitle.Text = "Học viên còn nợ";
                lblReportEnrollmentValue.Text = "17";
                lblReportEnrollmentNote.Text = "Cần nhắc phí và đối soát";
                lblReportClassCountTitle.Text = "Khoản quá hạn";
                lblReportClassCountValue.Text = "05";
                lblReportClassCountNote.Text = "Quá hạn trên 7 ngày";
                lblReportChartTitle.Text = "Biểu đồ công nợ theo tháng";
                lblReportDetailTitle.Text = "Bảng tổng hợp công nợ";
                dgvAdminReportDetail.DataSource = BuildDebtReportTable();
                BindSeries(
                    "Công nợ",
                    Color.FromArgb(224, 91, 97),
                    ("Th1", 8.5),
                    ("Th2", 10.0),
                    ("Th3", 12.3),
                    ("Th4", 15.1));
                break;

            default:
                lblReportRevenueTitle.Text = "Tổng doanh thu";
                lblReportRevenueValue.Text = "286.500.000";
                lblReportRevenueNote.Text = "Theo biên nhận đã xác nhận";
                lblReportEnrollmentTitle.Text = "Số ghi danh";
                lblReportEnrollmentValue.Text = "152";
                lblReportEnrollmentNote.Text = "Tổng hồ sơ trong kỳ lọc";
                lblReportClassCountTitle.Text = "Lớp đang mở";
                lblReportClassCountValue.Text = "18";
                lblReportClassCountNote.Text = "Theo lịch học đang hiệu lực";
                lblReportChartTitle.Text = "Biểu đồ doanh thu";
                lblReportDetailTitle.Text = "Bảng số liệu tổng hợp";
                dgvAdminReportDetail.DataSource = BuildRevenueReportTable();
                BindSeries(
                    "Doanh thu",
                    Color.FromArgb(0, 110, 110),
                    ("Th1", 52),
                    ("Th2", 68),
                    ("Th3", 74.5),
                    ("Th4", 92));
                break;
        }
    }

    private void BindSeries(string seriesName, Color color, params (string Label, double Value)[] points)
    {
        chtAdminRevenue.Series.Clear();
        var series = new Series(seriesName)
        {
            ChartType = SeriesChartType.Column,
            Color = color,
            BorderColor = color,
            BorderWidth = 1,
            IsValueShownAsLabel = false
        };

        foreach (var point in points)
        {
            series.Points.AddXY(point.Label, point.Value);
        }

        chtAdminRevenue.Series.Add(series);
    }

    private static DataTable BuildRevenueReportTable()
    {
        var table = CreateReportTable("Tháng", "Ghi danh", "Đã thu", "Còn nợ", "Ghi chú");
        table.Rows.Add("01/2026", "28", "52.000.000", "8.500.000", "Ổn định");
        table.Rows.Add("02/2026", "35", "68.000.000", "10.000.000", "Tăng");
        table.Rows.Add("03/2026", "42", "74.500.000", "12.300.000", "Tốt");
        table.Rows.Add("04/2026", "47", "92.000.000", "15.100.000", "Cao điểm");
        return table;
    }

    private static DataTable BuildEnrollmentReportTable()
    {
        var table = CreateReportTable("Tháng", "Hồ sơ mới", "Đã xếp lớp", "Chờ xử lý", "Ghi chú");
        table.Rows.Add("01/2026", "32", "26", "6", "Ổn định");
        table.Rows.Add("02/2026", "39", "31", "8", "Mở thêm lớp");
        table.Rows.Add("03/2026", "41", "35", "6", "Tỷ lệ chuyển đổi tốt");
        table.Rows.Add("04/2026", "28", "24", "4", "Theo mùa tuyển sinh");
        return table;
    }

    private static DataTable BuildDebtReportTable()
    {
        var table = CreateReportTable("Tháng", "Số hồ sơ nợ", "Tổng nợ", "Quá hạn", "Ghi chú");
        table.Rows.Add("01/2026", "11", "8.500.000", "2", "Kiểm soát tốt");
        table.Rows.Add("02/2026", "9", "10.000.000", "2", "Phát sinh lớp mới");
        table.Rows.Add("03/2026", "7", "12.300.000", "1", "Đã nhắc phí");
        table.Rows.Add("04/2026", "5", "15.100.000", "0", "Chuẩn bị đối soát");
        return table;
    }

    private static DataTable CreateReportTable(params string[] columns)
    {
        var table = new DataTable();
        foreach (var column in columns)
        {
            table.Columns.Add(column);
        }

        return table;
    }

    private void ShowExportHint(string action)
    {
        using var dialog = new FrmStatusDialog(
            action,
            $"Chức năng {action.ToLower()} đang dùng dữ liệu mẫu. Backend có thể nối sang file thật sau.");
        dialog.ShowDialog(this);
    }
}
