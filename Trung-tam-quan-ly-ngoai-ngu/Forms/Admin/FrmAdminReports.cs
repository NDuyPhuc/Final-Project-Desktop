using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using TrungTamNgoaiNgu.Application.Contracts;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Application.Models;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAdminReports : Form
{
    private static readonly CultureInfo ReportCulture = CultureInfo.GetCultureInfo("vi-VN");

    private readonly ILanguageCenterDataService _dataService;
    private ReportScenario? _currentScenario;

    public FrmAdminReports() : this(AppRuntime.DataService)
    {
    }

    public FrmAdminReports(ILanguageCenterDataService dataService)
    {
        _dataService = dataService;

        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Bao cao thong ke");
        ApplyLocalizedText();
        ConfigureVisualStyle();
        ConfigureChartSurface();
        BindReportEvents();
        LoadDefaultReport();
    }

    private void ApplyLocalizedText()
    {
        Text = "Bao cao thong ke";
        lblAdminReportTitle.Text = "BAO CAO THONG KE";
        lblAdminReportSession.Text = $"PHIEN: {DateTime.Now:dd/MM/yyyy HH:mm}";
        lblAdminReportStatus.Text = "TRANG THAI: ADMIN";

        btnPrintReport.Text = "IN BAO CAO";
        btnRefreshData.Text = "CAP NHAT DU LIEU";
        btnViewReport.Text = "XEM BAO CAO";
        btnExportReportCsv.Text = "XUAT FILE CSV";

        lblReportType.Text = "LOAI BAO CAO";
        lblReportFromDate.Text = "TU NGAY";
        lblReportToDate.Text = "DEN NGAY";

        lblReportChartTitle.Text = "XU HUONG THEO THANG";
        lblChartLegendRevenue.Text = "THUC TE";
        lblChartLegendTarget.Text = "MUC TIEU";

        lblReportDetailTitle.Text = "CHI TIET PHAT SINH";
        lblReportDetailPaging.Text = "Hien thi 0 / 0 ket qua";
        btnReportPrevPage.Text = "<";
        btnReportNextPage.Text = ">";

        lblReportDistributionTitle.Text = "PHAN BO THEO KHOA";
        lblReportHighlightTitle.Text = "Tong quan";
        lblReportHighlightBody.Text = "Bao cao tong hop theo du lieu tu database.";

        lblReportRevenueIcon.Text = "VND";
        lblReportEnrollmentIcon.Text = "HV";
        lblReportClassCountIcon.Text = "LOP";
        lblReportRetentionIcon.Text = "NO";
        lblReportHighlightIcon.Text = "i";

        cboReportType.Items.Clear();
        cboReportType.Items.AddRange(["Doanh thu tong hop", "Tuyen sinh", "Cong no"]);
        cboReportType.SelectedIndex = 0;
    }

    private void ConfigureVisualStyle()
    {
        BackColor = Color.FromArgb(239, 247, 255);
        Padding = new Padding(18);
        AutoScroll = true;
        MinimumSize = new Size(1080, 720);

        StyleSurfaceCard(pnlAdminReportFilterCard, Color.FromArgb(223, 243, 255));
        StyleSurfaceCard(pnlReportChartCard, Color.White);
        StyleSurfaceCard(pnlReportDistributionCard, Color.FromArgb(217, 237, 252));
        StyleSurfaceCard(pnlReportDetailCard, Color.FromArgb(222, 242, 255));
        StyleSurfaceCard(pnlReportHighlightCard, Color.FromArgb(127, 229, 227));

        StyleHeaderButton(btnPrintReport, Color.FromArgb(214, 237, 249), Color.FromArgb(10, 36, 66));
        StyleHeaderButton(btnRefreshData, Color.FromArgb(9, 72, 137), Color.White);
        StyleHeaderButton(btnViewReport, Color.FromArgb(112, 227, 223), Color.FromArgb(11, 91, 98));
        StyleHeaderButton(btnExportReportCsv, Color.White, Color.FromArgb(9, 60, 123), Color.FromArgb(182, 204, 228));
        StyleMiniNavButton(btnReportPrevPage);
        StyleMiniNavButton(btnReportNextPage);

        StyleKpiCard(pnlReportRevenue, pnlReportRevenueAccent, Color.FromArgb(10, 73, 146));
        StyleKpiCard(pnlReportEnrollment, pnlReportEnrollmentAccent, Color.FromArgb(22, 126, 120));
        StyleKpiCard(pnlReportClassCount, pnlReportClassCountAccent, Color.FromArgb(115, 126, 141));
        StyleKpiCard(pnlReportRetention, pnlReportRetentionAccent, Color.FromArgb(115, 49, 4));

        pnlReportHighlightTrack.BackColor = Color.FromArgb(154, 238, 236);
        pnlReportHighlightFill.BackColor = Color.FromArgb(16, 117, 121);
        pnlChartLegendRevenue.BackColor = Color.FromArgb(20, 83, 144);
        pnlChartLegendTarget.BackColor = Color.FromArgb(22, 126, 120);

        lblAdminReportTitle.ForeColor = Color.FromArgb(7, 30, 39);
        lblAdminReportSession.ForeColor = Color.FromArgb(50, 61, 76);
        lblAdminReportStatus.ForeColor = Color.FromArgb(22, 90, 88);
        lblReportHighlightTitle.ForeColor = Color.FromArgb(7, 87, 96);
        lblReportHighlightBody.ForeColor = Color.FromArgb(24, 93, 99);

        StyleCombo(cboReportType);
        StyleDatePicker(dtpReportFromDate);
        StyleDatePicker(dtpReportToDate);

        dgvAdminReportDetail.BorderStyle = BorderStyle.None;
        dgvAdminReportDetail.AutoGenerateColumns = true;
        dgvAdminReportDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvAdminReportDetail.RowTemplate.Height = 40;
        dgvAdminReportDetail.ColumnHeadersHeight = 42;
        AppTheme.StyleGrid(dgvAdminReportDetail);
    }

    private void ConfigureChartSurface()
    {
        var area = chtAdminRevenue.ChartAreas["DefaultArea"];
        area.BackColor = Color.White;
        area.AxisX.MajorGrid.Enabled = false;
        area.AxisY.MajorGrid.LineColor = Color.FromArgb(225, 230, 239);
        area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Solid;
        area.AxisX.LineColor = Color.FromArgb(225, 230, 239);
        area.AxisY.LineColor = Color.FromArgb(225, 230, 239);
        area.AxisX.LabelStyle.ForeColor = Color.FromArgb(80, 91, 110);
        area.AxisY.LabelStyle.ForeColor = Color.FromArgb(80, 91, 110);
        area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        area.AxisX.MajorTickMark.Enabled = false;
        area.AxisY.MajorTickMark.Enabled = false;
        area.AxisX.Interval = 1;
        area.AxisY.IsStartedFromZero = true;

        var legend = chtAdminRevenue.Legends["DefaultLegend"];
        legend.Enabled = false;
    }

    private void BindReportEvents()
    {
        btnViewReport.Click += (_, _) => ApplyReportView();
        btnRefreshData.Click += (_, _) => RefreshReportData();
        btnExportReportCsv.Click += (_, _) => ExportCurrentReportCsv();
        btnPrintReport.Click += (_, _) => ShowFeatureHint("In bao cao");
        cboReportType.SelectedIndexChanged += (_, _) => ApplyReportView();
        btnReportPrevPage.Click += (_, _) => ShowFeatureHint("Dieu huong trang");
        btnReportNextPage.Click += (_, _) => ShowFeatureHint("Dieu huong trang");
    }

    private void LoadDefaultReport()
    {
        var today = DateTime.Today;
        dtpReportFromDate.Value = new DateTime(today.Year, 1, 1);
        dtpReportToDate.Value = today;
        ApplyReportView();
    }

    private void ApplyReportView()
    {
        if (dtpReportFromDate.Value.Date > dtpReportToDate.Value.Date)
        {
            MessageBox.Show(this, "Ngay bat dau phai nho hon hoac bang ngay ket thuc.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            _currentScenario = BuildScenario(GetSelectedReportType(), dtpReportFromDate.Value.Date, dtpReportToDate.Value.Date);
            BindScenarioToUi(_currentScenario);
            lblAdminReportSession.Text = $"PHIEN: {DateTime.Now:dd/MM/yyyy HH:mm}";
            lblAdminReportStatus.Text = $"TRANG THAI: ADMIN / {GetReadableReportType()}";
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmAdminReports));
            MessageBox.Show(this, "Khong tai duoc du lieu bao cao. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BindScenarioToUi(ReportScenario scenario)
    {
        lblReportRevenueTitle.Text = scenario.RevenueTitle;
        lblReportRevenueValue.Text = scenario.RevenueValue;
        lblReportRevenueTrend.Text = scenario.RevenueTrend;

        lblReportEnrollmentTitle.Text = scenario.EnrollmentTitle;
        lblReportEnrollmentValue.Text = scenario.EnrollmentValue;
        lblReportEnrollmentTrend.Text = scenario.EnrollmentTrend;

        lblReportClassCountTitle.Text = scenario.ClassTitle;
        lblReportClassCountValue.Text = scenario.ClassValue;
        lblReportClassCountTrend.Text = scenario.ClassTrend;

        lblReportRetentionTitle.Text = scenario.RetentionTitle;
        lblReportRetentionValue.Text = scenario.RetentionValue;
        lblReportRetentionTrend.Text = scenario.RetentionTrend;

        lblReportChartTitle.Text = scenario.ChartTitle;
        lblReportDetailTitle.Text = scenario.DetailTitle;
        lblReportHighlightTitle.Text = scenario.HighlightTitle;
        lblReportHighlightBody.Text = scenario.HighlightBody;
        lblReportDetailPaging.Text = scenario.DetailPaging;

        lblDistributionCourse1Name.Text = scenario.Distributions[0].Name;
        lblDistributionCourse1Value.Text = scenario.Distributions[0].Value;
        lblDistributionCourse2Name.Text = scenario.Distributions[1].Name;
        lblDistributionCourse2Value.Text = scenario.Distributions[1].Value;
        lblDistributionCourse3Name.Text = scenario.Distributions[2].Name;
        lblDistributionCourse3Value.Text = scenario.Distributions[2].Value;

        dgvAdminReportDetail.DataSource = scenario.DetailTable;
        FormatReportGrid();
        BindSeries(scenario.ChartPoints, scenario.TargetPoints);
        UpdateHighlightProgressWidth(scenario.HighlightProgress);
    }

    private ReportScenario BuildScenario(string reportType, DateTime fromDate, DateTime toDate)
    {
        var stats = _dataService.GetAdminDashboardStats();
        var detailTable = _dataService.GetReportDetail(reportType, fromDate, toDate);
        var chartPoints = BuildChartPoints(reportType, fromDate, toDate, detailTable);
        var targetPoints = BuildTargetPoints(chartPoints, reportType);
        var distributions = BuildDistributions(reportType, fromDate, toDate, detailTable);
        var detailCount = detailTable.Rows.Count;

        return reportType switch
        {
            "Tuyen sinh" => new ReportScenario
            {
                RevenueTitle = "Tong ho so ghi danh",
                RevenueValue = detailCount.ToString("N0", ReportCulture),
                RevenueTrend = BuildTrendText(chartPoints),
                EnrollmentTitle = "Hoc vien moi trong ky",
                EnrollmentValue = CountDistinctValues(detailTable, "Hoc vien").ToString("N0", ReportCulture),
                EnrollmentTrend = $"Thang nay: {stats.NewStudentsThisMonth:N0}",
                ClassTitle = "So lop dang mo",
                ClassValue = stats.TotalActiveClasses.ToString("N0", ReportCulture),
                ClassTrend = $"Tong hoc vien: {stats.TotalStudents:N0}",
                RetentionTitle = "Tong hoc vien trung tam",
                RetentionValue = stats.TotalStudents.ToString("N0", ReportCulture),
                RetentionTrend = $"Tong GV: {stats.TotalTeachers:N0}",
                ChartTitle = "XU HUONG GHI DANH THEO THANG",
                DetailTitle = "CHI TIET GHI DANH TRONG KY",
                HighlightTitle = "Tuyen sinh dang tang",
                HighlightBody = $"Co {detailCount:N0} ho so trong khoang {fromDate:dd/MM/yyyy} - {toDate:dd/MM/yyyy}.",
                HighlightProgress = BuildProgressValue(detailCount, Math.Max(1, stats.TotalStudents)),
                DetailPaging = BuildPagingText(detailCount),
                Distributions = distributions,
                ChartPoints = chartPoints,
                TargetPoints = targetPoints,
                DetailTable = detailTable
            },
            "Cong no" => new ReportScenario
            {
                RevenueTitle = "Tong cong no",
                RevenueValue = FormatCompactMoney(stats.TotalDebt),
                RevenueTrend = BuildTrendText(chartPoints),
                EnrollmentTitle = "So bien lai",
                EnrollmentValue = stats.TotalReceipts.ToString("N0", ReportCulture),
                EnrollmentTrend = $"Doanh thu: {FormatCompactMoney(stats.TotalRevenue)}",
                ClassTitle = "Lop dang mo",
                ClassValue = stats.TotalActiveClasses.ToString("N0", ReportCulture),
                ClassTrend = $"Tong staff: {stats.TotalStaff:N0}",
                RetentionTitle = "Hoc vien con no",
                RetentionValue = detailTable.Rows.Count.ToString("N0", ReportCulture),
                RetentionTrend = "Theo doi cong no chua thanh toan",
                ChartTitle = "XU HUONG CONG NO THEO THANG",
                DetailTitle = "CHI TIET CONG NO TRONG KY",
                HighlightTitle = "Cong no can theo doi",
                HighlightBody = $"Tong cong no hien tai la {FormatMoney(stats.TotalDebt)}.",
                HighlightProgress = BuildProgressValue(stats.TotalDebt, Math.Max(1M, stats.TotalRevenue + stats.TotalDebt)),
                DetailPaging = BuildPagingText(detailTable.Rows.Count),
                Distributions = distributions,
                ChartPoints = chartPoints,
                TargetPoints = targetPoints,
                DetailTable = detailTable
            },
            _ => new ReportScenario
            {
                RevenueTitle = "Tong doanh thu da thu",
                RevenueValue = FormatCompactMoney(stats.TotalRevenue),
                RevenueTrend = BuildTrendText(chartPoints),
                EnrollmentTitle = "Hoc vien moi",
                EnrollmentValue = stats.NewStudentsThisMonth.ToString("N0", ReportCulture),
                EnrollmentTrend = $"Tong hoc vien: {stats.TotalStudents:N0}",
                ClassTitle = "So lop dang mo",
                ClassValue = stats.TotalActiveClasses.ToString("N0", ReportCulture),
                ClassTrend = $"Tong GV: {stats.TotalTeachers:N0}",
                RetentionTitle = "Tong cong no",
                RetentionValue = FormatCompactMoney(stats.TotalDebt),
                RetentionTrend = $"Tong bien lai: {stats.TotalReceipts:N0}",
                ChartTitle = "XU HUONG DOANH THU THEO THANG",
                DetailTitle = "CHI TIET THU HOC PHI TRONG KY",
                HighlightTitle = "Doanh thu da ghi nhan",
                HighlightBody = $"Da thu {FormatMoney(stats.TotalRevenue)} va con no {FormatMoney(stats.TotalDebt)}.",
                HighlightProgress = BuildProgressValue(stats.TotalRevenue, Math.Max(1M, stats.TotalRevenue + stats.TotalDebt)),
                DetailPaging = BuildPagingText(detailTable.Rows.Count),
                Distributions = distributions,
                ChartPoints = chartPoints,
                TargetPoints = targetPoints,
                DetailTable = detailTable
            }
        };
    }

    private IReadOnlyList<ReportPoint> BuildChartPoints(string reportType, DateTime fromDate, DateTime toDate, DataTable detailTable)
    {
        IReadOnlyList<ReportPoint> points = reportType switch
        {
            "Tuyen sinh" => _dataService.GetMonthlyEnrollmentCounts(fromDate, toDate),
            "Cong no" => BuildMonthlySeriesFromTable(detailTable, "Ngay doi soat", "Con no"),
            _ => _dataService.GetMonthlyRevenue(fromDate, toDate)
        };

        return EnsureSeriesHasPoints(points, fromDate, toDate);
    }

    private IReadOnlyList<ReportPoint> BuildTargetPoints(IReadOnlyList<ReportPoint> sourcePoints, string reportType)
    {
        var multiplier = reportType == "Cong no" ? 0.85M : 0.90M;

        return sourcePoints
            .Select(point => new ReportPoint
            {
                Label = point.Label,
                Value = Math.Round(point.Value * multiplier, 0)
            })
            .ToList();
    }

    private (string Name, string Value)[] BuildDistributions(string reportType, DateTime fromDate, DateTime toDate, DataTable detailTable)
    {
        IEnumerable<IGrouping<string, DataRow>> groupedRows = reportType switch
        {
            "Tuyen sinh" => detailTable.AsEnumerable()
                .Where(row => !string.IsNullOrWhiteSpace(row.Field<string>("Khoa hoc")))
                .GroupBy(row => row.Field<string>("Khoa hoc") ?? string.Empty),
            "Cong no" => _dataService.GetDebtList(null, null, fromDate, toDate)
                .AsEnumerable()
                .Where(row => !string.IsNullOrWhiteSpace(row.Field<string>("Khoa hoc")))
                .GroupBy(row => row.Field<string>("Khoa hoc") ?? string.Empty),
            _ => _dataService.GetClassList()
                .AsEnumerable()
                .Where(row => !string.IsNullOrWhiteSpace(row.Field<string>("Khoa hoc")))
                .GroupBy(row => row.Field<string>("Khoa hoc") ?? string.Empty)
        };

        var summary = groupedRows
            .Select(group => new
            {
                Name = group.Key,
                Count = group.Count()
            })
            .Where(item => !string.IsNullOrWhiteSpace(item.Name))
            .OrderByDescending(item => item.Count)
            .ToList();

        var total = Math.Max(1, summary.Sum(item => item.Count));
        var result = summary
            .Take(3)
            .Select(item => (item.Name, $"{Math.Round(item.Count * 100M / total, 1):0.#}%"))
            .ToList();

        while (result.Count < 3)
        {
            result.Add(("-", "0%"));
        }

        return [result[0], result[1], result[2]];
    }

    private IReadOnlyList<ReportPoint> BuildMonthlySeriesFromTable(DataTable sourceTable, string dateColumn, string valueColumn)
    {
        return sourceTable.AsEnumerable()
            .Select(row => new
            {
                Date = TryParseDate(row[dateColumn]?.ToString()),
                Value = TryParseMoney(row[valueColumn]?.ToString())
            })
            .Where(item => item.Date.HasValue)
            .GroupBy(item => new { item.Date!.Value.Year, item.Date.Value.Month })
            .OrderBy(group => group.Key.Year)
            .ThenBy(group => group.Key.Month)
            .Select(group => new ReportPoint
            {
                Label = $"{group.Key.Month:00}/{group.Key.Year}",
                Value = group.Sum(item => item.Value)
            })
            .ToList();
    }

    private IReadOnlyList<ReportPoint> EnsureSeriesHasPoints(IReadOnlyList<ReportPoint> points, DateTime fromDate, DateTime toDate)
    {
        if (points.Count > 0)
        {
            return points;
        }

        var firstMonth = new DateTime(fromDate.Year, fromDate.Month, 1);
        var lastMonth = new DateTime(toDate.Year, toDate.Month, 1);
        var monthCount = Math.Max(1, ((lastMonth.Year - firstMonth.Year) * 12) + lastMonth.Month - firstMonth.Month + 1);

        return Enumerable.Range(0, monthCount)
            .Select(offset => firstMonth.AddMonths(offset))
            .Select(date => new ReportPoint
            {
                Label = $"{date.Month:00}/{date.Year}",
                Value = 0
            })
            .ToList();
    }

    private void BindSeries(IReadOnlyList<ReportPoint> actualPoints, IReadOnlyList<ReportPoint> targetPoints)
    {
        chtAdminRevenue.Series.Clear();

        var actualSeries = new Series("Thuc te")
        {
            ChartType = SeriesChartType.Column,
            Color = Color.FromArgb(20, 83, 144),
            BorderWidth = 0,
            IsValueShownAsLabel = false,
            IsXValueIndexed = true
        };
        actualSeries["PointWidth"] = "0.58";

        foreach (var point in actualPoints)
        {
            actualSeries.Points.AddXY(point.Label, (double)point.Value);
        }

        var targetSeries = new Series("Muc tieu")
        {
            ChartType = SeriesChartType.Line,
            Color = Color.FromArgb(22, 126, 120),
            BorderWidth = 3,
            MarkerStyle = MarkerStyle.Circle,
            MarkerSize = 7,
            IsXValueIndexed = true
        };

        foreach (var point in targetPoints)
        {
            targetSeries.Points.AddXY(point.Label, (double)point.Value);
        }

        chtAdminRevenue.Series.Add(actualSeries);
        chtAdminRevenue.Series.Add(targetSeries);
    }

    private void FormatReportGrid()
    {
        foreach (DataGridViewColumn column in dgvAdminReportDetail.Columns)
        {
            var header = column.HeaderText.ToLowerInvariant();
            var isMoneyColumn = header.Contains("thu") || header.Contains("phi") || header.Contains("tien") || header.Contains("no");
            column.DefaultCellStyle.Alignment = isMoneyColumn
                ? DataGridViewContentAlignment.MiddleRight
                : DataGridViewContentAlignment.MiddleCenter;
        }
    }

    private void UpdateHighlightProgressWidth(double progress)
    {
        var width = Math.Max(24, (int)(pnlReportHighlightTrack.ClientSize.Width * Math.Clamp(progress, 0.08, 1.0)));
        pnlReportHighlightFill.Width = width;
    }

    private void RefreshReportData()
    {
        ApplyReportView();
        MessageBox.Show(this, "Da cap nhat lai du lieu bao cao tu database.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ExportCurrentReportCsv()
    {
        if (_currentScenario is null)
        {
            return;
        }

        try
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = $"bao-cao-{GetSelectedReportType().ToLowerInvariant().Replace(' ', '-')}-{DateTime.Now:yyyyMMdd-HHmmss}.csv",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var csv = BuildCsv(_currentScenario.DetailTable);
            File.WriteAllText(dialog.FileName, csv, new UTF8Encoding(true));
            MessageBox.Show(this, "Da xuat file CSV thanh cong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmAdminReports));
            MessageBox.Show(this, "Khong xuat duoc file CSV. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ShowFeatureHint(string actionName)
    {
        MessageBox.Show(
            this,
            $"{actionName} dang duoc giu o muc co ban de de demo. Du lieu hien tai da lay tu SQL Server/EF.",
            "Thong bao",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private string GetSelectedReportType()
    {
        return cboReportType.SelectedIndex switch
        {
            1 => "Tuyen sinh",
            2 => "Cong no",
            _ => "Doanh thu tong hop"
        };
    }

    private string GetReadableReportType()
    {
        return cboReportType.SelectedItem?.ToString() ?? "Bao cao";
    }

    private static int CountDistinctValues(DataTable table, string columnName)
    {
        if (!table.Columns.Contains(columnName))
        {
            return 0;
        }

        return table.AsEnumerable()
            .Select(row => row[columnName]?.ToString())
            .Where(value => !string.IsNullOrWhiteSpace(value))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Count();
    }

    private static string BuildPagingText(int totalRows)
    {
        return $"Hien thi {Math.Min(10, totalRows)} / {totalRows} ket qua";
    }

    private static string BuildTrendText(IReadOnlyList<ReportPoint> points)
    {
        if (points.Count < 2)
        {
            return "Khong doi";
        }

        var previous = points[^2].Value;
        var current = points[^1].Value;
        if (previous == 0)
        {
            return current == 0 ? "Khong doi" : "Tang moi";
        }

        var change = Math.Round((current - previous) * 100M / previous, 1);
        return change switch
        {
            > 0 => $"Tang {change:0.#}%",
            < 0 => $"Giam {Math.Abs(change):0.#}%",
            _ => "Khong doi"
        };
    }

    private static double BuildProgressValue(decimal value, decimal total)
    {
        if (total <= 0)
        {
            return 0.08;
        }

        return Math.Clamp((double)(value / total), 0.08, 1.0);
    }

    private static string FormatCompactMoney(decimal amount)
    {
        if (amount >= 1_000_000_000M)
        {
            return $"{amount / 1_000_000_000M:0.##} ty";
        }

        if (amount >= 1_000_000M)
        {
            return $"{amount / 1_000_000M:0.##} tr";
        }

        if (amount >= 1_000M)
        {
            return $"{amount / 1_000M:0.##} nghin";
        }

        return amount.ToString("N0", ReportCulture);
    }

    private static string FormatMoney(decimal amount)
    {
        return amount.ToString("N0", ReportCulture) + " VND";
    }

    private static DateTime? TryParseDate(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return DateTime.TryParseExact(value, "dd/MM/yyyy", ReportCulture, DateTimeStyles.None, out var parsedDate)
            ? parsedDate
            : null;
    }

    private static decimal TryParseMoney(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return 0;
        }

        var sanitized = value
            .Replace("VND", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace(".", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace(",", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Trim();

        return decimal.TryParse(sanitized, NumberStyles.Number, CultureInfo.InvariantCulture, out var parsedValue)
            ? parsedValue
            : 0;
    }

    private static string BuildCsv(DataTable table)
    {
        var builder = new StringBuilder();
        var headers = table.Columns.Cast<DataColumn>().Select(column => EscapeCsv(column.ColumnName));
        builder.AppendLine(string.Join(",", headers));

        foreach (DataRow row in table.Rows)
        {
            var cells = row.ItemArray.Select(cell => EscapeCsv(cell?.ToString() ?? string.Empty));
            builder.AppendLine(string.Join(",", cells));
        }

        return builder.ToString();
    }

    private static string EscapeCsv(string value)
    {
        var escaped = value.Replace("\"", "\"\"");
        return $"\"{escaped}\"";
    }

    private static void StyleSurfaceCard(Panel panel, Color backColor)
    {
        panel.BackColor = backColor;
        panel.BorderStyle = BorderStyle.FixedSingle;
    }

    private static void StyleHeaderButton(Button button, Color backColor, Color foreColor, Color? borderColor = null)
    {
        button.BackColor = backColor;
        button.ForeColor = foreColor;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 1;
        button.FlatAppearance.BorderColor = borderColor ?? backColor;
        button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        button.Cursor = Cursors.Hand;
    }

    private static void StyleMiniNavButton(Button button)
    {
        button.BackColor = Color.FromArgb(234, 244, 252);
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 1;
        button.FlatAppearance.BorderColor = Color.FromArgb(198, 216, 233);
        button.ForeColor = Color.FromArgb(49, 58, 71);
        button.Cursor = Cursors.Hand;
    }

    private static void StyleCombo(ComboBox comboBox)
    {
        comboBox.FlatStyle = FlatStyle.Flat;
        comboBox.BackColor = Color.White;
        comboBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
    }

    private static void StyleDatePicker(DateTimePicker picker)
    {
        picker.CalendarMonthBackground = Color.White;
        picker.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
    }

    private static void StyleKpiCard(Panel panel, Panel accent, Color accentColor)
    {
        panel.BackColor = Color.White;
        panel.BorderStyle = BorderStyle.FixedSingle;
        accent.BackColor = accentColor;
    }

    private sealed class ReportScenario
    {
        public required string RevenueTitle { get; init; }
        public required string RevenueValue { get; init; }
        public required string RevenueTrend { get; init; }
        public required string EnrollmentTitle { get; init; }
        public required string EnrollmentValue { get; init; }
        public required string EnrollmentTrend { get; init; }
        public required string ClassTitle { get; init; }
        public required string ClassValue { get; init; }
        public required string ClassTrend { get; init; }
        public required string RetentionTitle { get; init; }
        public required string RetentionValue { get; init; }
        public required string RetentionTrend { get; init; }
        public required string ChartTitle { get; init; }
        public required string DetailTitle { get; init; }
        public required string HighlightTitle { get; init; }
        public required string HighlightBody { get; init; }
        public required double HighlightProgress { get; init; }
        public required string DetailPaging { get; init; }
        public required (string Name, string Value)[] Distributions { get; init; }
        public required IReadOnlyList<ReportPoint> ChartPoints { get; init; }
        public required IReadOnlyList<ReportPoint> TargetPoints { get; init; }
        public required DataTable DetailTable { get; init; }
    }
}
