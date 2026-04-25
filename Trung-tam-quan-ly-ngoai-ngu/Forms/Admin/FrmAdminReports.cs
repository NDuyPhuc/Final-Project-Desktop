using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAdminReports : Form
{
    private ReportScenario? _currentScenario;

    public FrmAdminReports()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Báo cáo thống kê");
        ApplyLocalizedText();
        ConfigureVisualStyle();
        ConfigureChartSurface();
        ConfigureReportSurface();
        ConfigureResponsiveLayout();
        BindReportEvents();
        LoadDefaultReport();
    }

    private void ApplyLocalizedText()
    {
        Text = "Báo cáo thống kê";
        lblAdminReportTitle.Text = "BÁO CÁO THỐNG KÊ";
        lblAdminReportSession.Text = "PHIÊN: 24/05/2024 14:30";
        lblAdminReportStatus.Text = "TRẠNG THÁI: ADMINISTRATOR";

        btnPrintReport.Text = "IN BÁO CÁO";
        btnRefreshData.Text = "CẬP NHẬT DỮ LIỆU";
        btnViewReport.Text = "XEM BÁO CÁO";
        btnExportReportCsv.Text = "XUẤT FILE (.CSV)";

        lblReportType.Text = "LOẠI BÁO CÁO";
        lblReportFromDate.Text = "TỪ NGÀY";
        lblReportToDate.Text = "ĐẾN NGÀY";

        lblReportChartTitle.Text = "XU HƯỚNG DOANH THU HÀNG THÁNG";
        lblChartLegendRevenue.Text = "DOANH THU";
        lblChartLegendTarget.Text = "MỤC TIÊU";

        lblReportDetailTitle.Text = "CHI TIẾT PHÁT SINH TRONG KỲ";
        lblReportDetailPaging.Text = "Hiển thị 10 / 125 kết quả";
        btnReportPrevPage.Text = "<";
        btnReportNextPage.Text = ">";

        lblReportDistributionTitle.Text = "PHÂN BỔ KHÓA HỌC";
        cboReportType.Items.Clear();
        cboReportType.Items.AddRange(["Doanh thu tổng hợp", "Tuyển sinh", "Công nợ"]);
        cboReportType.SelectedIndex = 0;
    }

    private void ConfigureVisualStyle()
    {
        BackColor = Color.FromArgb(239, 247, 255);
        Padding = new Padding(18);
        AutoScroll = true;

        StyleSurfaceCard(pnlAdminReportFilterCard, Color.FromArgb(223, 243, 255));
        StyleSurfaceCard(pnlReportChartCard, Color.White);
        StyleSurfaceCard(pnlReportDistributionCard, Color.FromArgb(217, 237, 252));
        StyleSurfaceCard(pnlReportDetailCard, Color.FromArgb(222, 242, 255));

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

        pnlReportHighlightCard.BackColor = Color.FromArgb(127, 229, 227);
        pnlReportHighlightTrack.BackColor = Color.FromArgb(154, 238, 236);
        pnlReportHighlightFill.BackColor = Color.FromArgb(16, 117, 121);

        pnlChartLegendRevenue.BackColor = Color.FromArgb(20, 83, 144);
        pnlChartLegendTarget.BackColor = Color.FromArgb(22, 126, 120);

        lblReportRevenueIcon.ForeColor = Color.FromArgb(10, 73, 146);
        lblReportEnrollmentIcon.ForeColor = Color.FromArgb(22, 126, 120);
        lblReportClassCountIcon.ForeColor = Color.FromArgb(115, 126, 141);
        lblReportRetentionIcon.ForeColor = Color.FromArgb(115, 49, 4);

        lblAdminReportTitle.ForeColor = Color.FromArgb(7, 30, 39);
        lblAdminReportSession.ForeColor = Color.FromArgb(50, 61, 76);
        lblAdminReportStatus.ForeColor = Color.FromArgb(22, 90, 88);
        lblReportHighlightTitle.ForeColor = Color.FromArgb(7, 87, 96);
        lblReportHighlightBody.ForeColor = Color.FromArgb(24, 93, 99);
        lblReportHighlightIcon.ForeColor = Color.FromArgb(7, 87, 96);

        dgvAdminReportDetail.BorderStyle = BorderStyle.None;
        AppTheme.StyleGrid(dgvAdminReportDetail);

        StyleDatePicker(dtpReportFromDate);
        StyleDatePicker(dtpReportToDate);
        StyleCombo(cboReportType);
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
        area.AxisX.IsMarginVisible = true;
        area.AxisX.IsLabelAutoFit = false;
        area.AxisY.IsLabelAutoFit = false;
        area.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
        area.Position.Auto = true;
        area.InnerPlotPosition.Auto = true;

        var legend = chtAdminRevenue.Legends["DefaultLegend"];
        legend.Enabled = false;
    }

    private void ConfigureReportSurface()
    {
        dtpReportFromDate.Value = new DateTime(2024, 5, 1);
        dtpReportToDate.Value = new DateTime(2024, 5, 24);
        dgvAdminReportDetail.AutoGenerateColumns = true;
        dgvAdminReportDetail.ScrollBars = ScrollBars.Vertical;
        cboReportType.Dock = DockStyle.Fill;
        dtpReportFromDate.Dock = DockStyle.Fill;
        dtpReportToDate.Dock = DockStyle.Fill;
        btnViewReport.Dock = DockStyle.Fill;
        btnViewReport.AutoSize = false;
        btnExportReportCsv.AutoSize = false;
        btnViewReport.MinimumSize = new Size(0, 52);
        btnExportReportCsv.MinimumSize = new Size(220, 52);
        btnViewReport.TextAlign = ContentAlignment.MiddleCenter;
        btnExportReportCsv.TextAlign = ContentAlignment.MiddleCenter;
        btnViewReport.Padding = new Padding(12, 0, 12, 0);
        btnExportReportCsv.Padding = new Padding(8, 0, 8, 0);
        btnViewReport.UseCompatibleTextRendering = false;
        btnExportReportCsv.UseCompatibleTextRendering = false;
        btnExportReportCsv.Dock = DockStyle.None;
        btnExportReportCsv.Anchor = AnchorStyles.None;
        btnExportReportCsv.Margin = new Padding(12, 0, 0, 0);
        tblReportDistribution.Dock = DockStyle.None;
        tblReportDistribution.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        pnlReportRevenue.Resize += (_, _) => LayoutKpiCard(pnlReportRevenue, lblReportRevenueTitle, lblReportRevenueValue, lblReportRevenueTrend, lblReportRevenueIcon);
        pnlReportEnrollment.Resize += (_, _) => LayoutKpiCard(pnlReportEnrollment, lblReportEnrollmentTitle, lblReportEnrollmentValue, lblReportEnrollmentTrend, lblReportEnrollmentIcon);
        pnlReportClassCount.Resize += (_, _) => LayoutKpiCard(pnlReportClassCount, lblReportClassCountTitle, lblReportClassCountValue, lblReportClassCountTrend, lblReportClassCountIcon);
        pnlReportRetention.Resize += (_, _) => LayoutKpiCard(pnlReportRetention, lblReportRetentionTitle, lblReportRetentionValue, lblReportRetentionTrend, lblReportRetentionIcon);
        pnlReportChartHeader.Resize += (_, _) => LayoutChartHeader();
        pnlReportHighlightCard.Resize += (_, _) =>
        {
            UpdateHighlightProgressWidth();
            LayoutHighlightCard();
        };
        pnlReportDistributionCard.Resize += (_, _) => LayoutDistributionCard();
        pnlReportDetailHeader.Resize += (_, _) => LayoutDetailHeader();
        Resize += (_, _) => ApplyResponsiveBreakpoints();
    }

    private void ConfigureResponsiveLayout()
    {
        tblAdminReportRoot.Dock = DockStyle.Top;
        tblAdminReportRoot.AutoSize = true;
        tblAdminReportRoot.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        tblAdminReportRoot.MinimumSize = Size.Empty;
        MinimumSize = new Size(760, 560);

        pnlReportChartCard.MinimumSize = Size.Empty;
        pnlReportDetailCard.MinimumSize = Size.Empty;
        pnlReportHighlightCard.MinimumSize = Size.Empty;
        pnlReportDistributionCard.MinimumSize = Size.Empty;
        tblReportMiddle.MinimumSize = Size.Empty;

        lblReportDetailPaging.AutoSize = false;
        lblReportDetailPaging.Size = new Size(190, 24);
        lblReportDetailPaging.TextAlign = ContentAlignment.MiddleRight;
        lblReportDetailPaging.AutoEllipsis = true;

        dgvAdminReportDetail.RowTemplate.Height = 40;
        dgvAdminReportDetail.ColumnHeadersHeight = 42;
        ApplyResponsiveBreakpoints();
    }

    private void ApplyResponsiveBreakpoints()
    {
        var contentWidth = Math.Max(720, ClientSize.Width - Padding.Horizontal);
        var compact = contentWidth < 1160;
        var veryCompact = contentWidth < 980;

        SuspendLayout();
        tblAdminReportRoot.SuspendLayout();
        tblAdminReportHeaderLayout.SuspendLayout();
        tblAdminReportFilter.SuspendLayout();
        tblReportKpi.SuspendLayout();
        tblReportMiddle.SuspendLayout();
        tblReportSideColumn.SuspendLayout();

        ConfigureRootRows(compact, veryCompact);
        ConfigureHeaderLayout(compact);
        ConfigureFilterLayout(compact, veryCompact);
        ConfigureKpiLayout(compact);
        ConfigureMiddleLayout(compact);

        tblReportSideColumn.ResumeLayout(true);
        tblReportMiddle.ResumeLayout(true);
        tblReportKpi.ResumeLayout(true);
        tblAdminReportFilter.ResumeLayout(true);
        tblAdminReportHeaderLayout.ResumeLayout(true);
        tblAdminReportRoot.ResumeLayout(true);
        ResumeLayout(true);

        LayoutKpiCard(pnlReportRevenue, lblReportRevenueTitle, lblReportRevenueValue, lblReportRevenueTrend, lblReportRevenueIcon);
        LayoutKpiCard(pnlReportEnrollment, lblReportEnrollmentTitle, lblReportEnrollmentValue, lblReportEnrollmentTrend, lblReportEnrollmentIcon);
        LayoutKpiCard(pnlReportClassCount, lblReportClassCountTitle, lblReportClassCountValue, lblReportClassCountTrend, lblReportClassCountIcon);
        LayoutKpiCard(pnlReportRetention, lblReportRetentionTitle, lblReportRetentionValue, lblReportRetentionTrend, lblReportRetentionIcon);
        LayoutChartHeader();
        LayoutHighlightCard();
        LayoutDistributionCard();
        LayoutDetailHeader();
    }

    private void ConfigureRootRows(bool compact, bool veryCompact)
    {
        tblAdminReportRoot.RowStyles.Clear();
        tblAdminReportRoot.RowCount = 5;

        if (veryCompact)
        {
            tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 168F));
            tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 228F));
            tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 302F));
            tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 612F));
            tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 330F));
        }
        else if (compact)
        {
            tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 168F));
            tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 176F));
            tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 302F));
            tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 612F));
            tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 330F));
        }
        else
        {
            tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 128F));
            tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 406F));
            tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 300F));
        }
    }

    private void ConfigureHeaderLayout(bool compact)
    {
        tblAdminReportHeaderLayout.ColumnStyles.Clear();
        tblAdminReportHeaderLayout.RowStyles.Clear();

        if (compact)
        {
            tblAdminReportHeaderLayout.ColumnCount = 1;
            tblAdminReportHeaderLayout.RowCount = 2;
            tblAdminReportHeaderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblAdminReportHeaderLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            tblAdminReportHeaderLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));

            tblAdminReportHeaderLayout.SetColumn(pnlAdminReportTitleBlock, 0);
            tblAdminReportHeaderLayout.SetRow(pnlAdminReportTitleBlock, 0);
            tblAdminReportHeaderLayout.SetColumn(flpAdminReportHeaderActions, 0);
            tblAdminReportHeaderLayout.SetRow(flpAdminReportHeaderActions, 1);

            flpAdminReportHeaderActions.FlowDirection = FlowDirection.LeftToRight;
            flpAdminReportHeaderActions.Padding = new Padding(0, 6, 0, 0);
            flpAdminReportHeaderActions.AutoSize = false;
            flpAdminReportHeaderActions.WrapContents = false;
            btnPrintReport.Size = new Size(182, 48);
            btnRefreshData.Size = new Size(182, 48);
            btnExportReportCsv.Size = new Size(220, 48);
            btnExportReportCsv.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        }
        else
        {
            tblAdminReportHeaderLayout.ColumnCount = 2;
            tblAdminReportHeaderLayout.RowCount = 1;
            tblAdminReportHeaderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblAdminReportHeaderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 624F));
            tblAdminReportHeaderLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            tblAdminReportHeaderLayout.SetColumn(pnlAdminReportTitleBlock, 0);
            tblAdminReportHeaderLayout.SetRow(pnlAdminReportTitleBlock, 0);
            tblAdminReportHeaderLayout.SetColumn(flpAdminReportHeaderActions, 1);
            tblAdminReportHeaderLayout.SetRow(flpAdminReportHeaderActions, 0);

            flpAdminReportHeaderActions.FlowDirection = FlowDirection.RightToLeft;
            flpAdminReportHeaderActions.Padding = new Padding(0, 20, 0, 0);
            flpAdminReportHeaderActions.AutoSize = false;
            flpAdminReportHeaderActions.WrapContents = false;
            btnPrintReport.Size = new Size(180, 52);
            btnRefreshData.Size = new Size(180, 52);
            btnExportReportCsv.Size = new Size(220, 52);
            btnExportReportCsv.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }
    }

    private void ConfigureFilterLayout(bool compact, bool veryCompact)
    {
        tblAdminReportFilter.ColumnStyles.Clear();
        tblAdminReportFilter.RowStyles.Clear();
        btnViewReport.Font = new Font("Segoe UI", compact ? 10.5F : 10F, FontStyle.Bold);
        btnExportReportCsv.Font = new Font("Segoe UI", compact ? 10.5F : 10F, FontStyle.Bold);

        if (veryCompact)
        {
            tblAdminReportFilter.ColumnCount = 2;
            tblAdminReportFilter.RowCount = 4;
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));

            tblAdminReportFilter.SetColumn(lblReportType, 0);
            tblAdminReportFilter.SetRow(lblReportType, 0);
            tblAdminReportFilter.SetColumn(lblReportFromDate, 1);
            tblAdminReportFilter.SetRow(lblReportFromDate, 0);
            tblAdminReportFilter.SetColumn(lblReportToDate, 0);
            tblAdminReportFilter.SetRow(lblReportToDate, 2);
            tblAdminReportFilter.SetColumnSpan(lblReportToDate, 2);

            tblAdminReportFilter.SetColumn(cboReportType, 0);
            tblAdminReportFilter.SetRow(cboReportType, 1);
            tblAdminReportFilter.SetColumn(dtpReportFromDate, 1);
            tblAdminReportFilter.SetRow(dtpReportFromDate, 1);
            tblAdminReportFilter.SetColumn(dtpReportToDate, 0);
            tblAdminReportFilter.SetRow(dtpReportToDate, 3);
            tblAdminReportFilter.SetColumn(btnViewReport, 1);
            tblAdminReportFilter.SetRow(btnViewReport, 3);
        }
        else if (compact)
        {
            tblAdminReportFilter.ColumnCount = 4;
            tblAdminReportFilter.RowCount = 2;
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));

            tblAdminReportFilter.SetColumn(lblReportType, 0);
            tblAdminReportFilter.SetRow(lblReportType, 0);
            tblAdminReportFilter.SetColumn(lblReportFromDate, 1);
            tblAdminReportFilter.SetRow(lblReportFromDate, 0);
            tblAdminReportFilter.SetColumn(lblReportToDate, 2);
            tblAdminReportFilter.SetRow(lblReportToDate, 0);

            tblAdminReportFilter.SetColumn(cboReportType, 0);
            tblAdminReportFilter.SetRow(cboReportType, 1);
            tblAdminReportFilter.SetColumn(dtpReportFromDate, 1);
            tblAdminReportFilter.SetRow(dtpReportFromDate, 1);
            tblAdminReportFilter.SetColumn(dtpReportToDate, 2);
            tblAdminReportFilter.SetRow(dtpReportToDate, 1);
            tblAdminReportFilter.SetColumn(btnViewReport, 3);
            tblAdminReportFilter.SetRow(btnViewReport, 1);
        }
        else
        {
            tblAdminReportFilter.ColumnCount = 4;
            tblAdminReportFilter.RowCount = 2;
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));

            tblAdminReportFilter.SetColumn(lblReportType, 0);
            tblAdminReportFilter.SetRow(lblReportType, 0);
            tblAdminReportFilter.SetColumn(lblReportFromDate, 1);
            tblAdminReportFilter.SetRow(lblReportFromDate, 0);
            tblAdminReportFilter.SetColumn(lblReportToDate, 2);
            tblAdminReportFilter.SetRow(lblReportToDate, 0);

            tblAdminReportFilter.SetColumn(cboReportType, 0);
            tblAdminReportFilter.SetRow(cboReportType, 1);
            tblAdminReportFilter.SetColumn(dtpReportFromDate, 1);
            tblAdminReportFilter.SetRow(dtpReportFromDate, 1);
            tblAdminReportFilter.SetColumn(dtpReportToDate, 2);
            tblAdminReportFilter.SetRow(dtpReportToDate, 1);
            tblAdminReportFilter.SetColumn(btnViewReport, 3);
            tblAdminReportFilter.SetRow(btnViewReport, 1);
        }
    }

    private void ConfigureKpiLayout(bool compact)
    {
        tblReportKpi.ColumnStyles.Clear();
        tblReportKpi.RowStyles.Clear();

        if (compact)
        {
            tblReportKpi.ColumnCount = 2;
            tblReportKpi.RowCount = 2;
            tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblReportKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblReportKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            MoveKpiCard(pnlReportRevenue, 0, 0, new Padding(0, 0, 12, 12));
            MoveKpiCard(pnlReportEnrollment, 1, 0, new Padding(0, 0, 0, 12));
            MoveKpiCard(pnlReportClassCount, 0, 1, new Padding(0, 0, 12, 0));
            MoveKpiCard(pnlReportRetention, 1, 1, Padding.Empty);
        }
        else
        {
            tblReportKpi.ColumnCount = 4;
            tblReportKpi.RowCount = 1;
            tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblReportKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            MoveKpiCard(pnlReportRevenue, 0, 0, new Padding(0, 0, 18, 0));
            MoveKpiCard(pnlReportEnrollment, 1, 0, new Padding(0, 0, 18, 0));
            MoveKpiCard(pnlReportClassCount, 2, 0, new Padding(0, 0, 18, 0));
            MoveKpiCard(pnlReportRetention, 3, 0, Padding.Empty);
        }
    }

    private void ConfigureMiddleLayout(bool compact)
    {
        tblReportMiddle.ColumnStyles.Clear();
        tblReportMiddle.RowStyles.Clear();

        if (compact)
        {
            tblReportMiddle.ColumnCount = 1;
            tblReportMiddle.RowCount = 2;
            tblReportMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblReportMiddle.RowStyles.Add(new RowStyle(SizeType.Absolute, 360F));
            tblReportMiddle.RowStyles.Add(new RowStyle(SizeType.Absolute, 234F));

            tblReportMiddle.SetColumn(pnlReportChartCard, 0);
            tblReportMiddle.SetRow(pnlReportChartCard, 0);
            tblReportMiddle.SetColumn(tblReportSideColumn, 0);
            tblReportMiddle.SetRow(tblReportSideColumn, 1);
            pnlReportChartCard.Margin = new Padding(0, 0, 0, 18);
            tblReportSideColumn.Margin = Padding.Empty;

            tblReportSideColumn.ColumnCount = 2;
            tblReportSideColumn.RowCount = 1;
            tblReportSideColumn.ColumnStyles.Clear();
            tblReportSideColumn.RowStyles.Clear();
            tblReportSideColumn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
            tblReportSideColumn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 48F));
            tblReportSideColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            tblReportSideColumn.SetColumn(pnlReportHighlightCard, 0);
            tblReportSideColumn.SetRow(pnlReportHighlightCard, 0);
            tblReportSideColumn.SetColumn(pnlReportDistributionCard, 1);
            tblReportSideColumn.SetRow(pnlReportDistributionCard, 0);
            pnlReportHighlightCard.Margin = new Padding(0, 0, 18, 0);
            pnlReportDistributionCard.Margin = Padding.Empty;
        }
        else
        {
            tblReportMiddle.ColumnCount = 2;
            tblReportMiddle.RowCount = 1;
            tblReportMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.5F));
            tblReportMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.5F));
            tblReportMiddle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            tblReportMiddle.SetColumn(pnlReportChartCard, 0);
            tblReportMiddle.SetRow(pnlReportChartCard, 0);
            tblReportMiddle.SetColumn(tblReportSideColumn, 1);
            tblReportMiddle.SetRow(tblReportSideColumn, 0);
            pnlReportChartCard.Margin = new Padding(0, 0, 24, 0);
            tblReportSideColumn.Margin = Padding.Empty;

            tblReportSideColumn.ColumnCount = 1;
            tblReportSideColumn.RowCount = 2;
            tblReportSideColumn.ColumnStyles.Clear();
            tblReportSideColumn.RowStyles.Clear();
            tblReportSideColumn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblReportSideColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 58F));
            tblReportSideColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 42F));

            tblReportSideColumn.SetColumn(pnlReportHighlightCard, 0);
            tblReportSideColumn.SetRow(pnlReportHighlightCard, 0);
            tblReportSideColumn.SetColumn(pnlReportDistributionCard, 0);
            tblReportSideColumn.SetRow(pnlReportDistributionCard, 1);
            pnlReportHighlightCard.Margin = new Padding(0, 0, 0, 22);
            pnlReportDistributionCard.Margin = Padding.Empty;
        }
    }

    private static void MoveKpiCard(Panel card, int column, int row, Padding margin)
    {
        if (card.Parent is not TableLayoutPanel host)
        {
            return;
        }

        host.SetColumn(card, column);
        host.SetRow(card, row);
        card.Margin = margin;
    }

    private void BindReportEvents()
    {
        btnViewReport.Click += (_, _) => ApplyReportView();
        btnExportReportCsv.Click += (_, _) => ShowExportHint("Xuất CSV");
        btnPrintReport.Click += (_, _) => ShowExportHint("In báo cáo");
        btnRefreshData.Click += (_, _) => ShowExportHint("Cập nhật dữ liệu");
        cboReportType.SelectedIndexChanged += (_, _) => ApplyReportView();
        btnReportPrevPage.Click += (_, _) => ShowExportHint("Điều hướng trang");
        btnReportNextPage.Click += (_, _) => ShowExportHint("Điều hướng trang");
    }

    private void LoadDefaultReport()
    {
        ApplyReportView();
    }

    private void ApplyReportView()
    {
        _currentScenario = BuildScenario(cboReportType.SelectedItem?.ToString() ?? "Doanh thu tổng hợp");

        lblReportRevenueTitle.Text = _currentScenario.RevenueTitle;
        lblReportRevenueValue.Text = _currentScenario.RevenueValue;
        lblReportRevenueTrend.Text = _currentScenario.RevenueTrend;

        lblReportEnrollmentTitle.Text = _currentScenario.EnrollmentTitle;
        lblReportEnrollmentValue.Text = _currentScenario.EnrollmentValue;
        lblReportEnrollmentTrend.Text = _currentScenario.EnrollmentTrend;

        lblReportClassCountTitle.Text = _currentScenario.ClassTitle;
        lblReportClassCountValue.Text = _currentScenario.ClassValue;
        lblReportClassCountTrend.Text = _currentScenario.ClassTrend;

        lblReportRetentionTitle.Text = _currentScenario.RetentionTitle;
        lblReportRetentionValue.Text = _currentScenario.RetentionValue;
        lblReportRetentionTrend.Text = _currentScenario.RetentionTrend;

        lblReportChartTitle.Text = _currentScenario.ChartTitle;
        lblReportDetailTitle.Text = _currentScenario.DetailTitle;
        lblReportHighlightTitle.Text = _currentScenario.HighlightTitle;
        lblReportHighlightBody.Text = _currentScenario.HighlightBody;
        lblReportDetailPaging.Text = _currentScenario.DetailPaging;

        lblDistributionCourse1Name.Text = _currentScenario.Distributions[0].Name;
        lblDistributionCourse1Value.Text = _currentScenario.Distributions[0].Value;
        lblDistributionCourse2Name.Text = _currentScenario.Distributions[1].Name;
        lblDistributionCourse2Value.Text = _currentScenario.Distributions[1].Value;
        lblDistributionCourse3Name.Text = _currentScenario.Distributions[2].Name;
        lblDistributionCourse3Value.Text = _currentScenario.Distributions[2].Value;

        dgvAdminReportDetail.DataSource = _currentScenario.DetailTable;
        FormatReportGrid();
        BindSeries(_currentScenario.ChartPoints, _currentScenario.TargetPoints);
        UpdateHighlightProgressWidth();
        LayoutHighlightCard();
        LayoutDetailHeader();
    }

    private void BindSeries((string Label, double Value)[] revenuePoints, (string Label, double Value)[] targetPoints)
    {
        chtAdminRevenue.Series.Clear();

        var revenueSeries = new Series("Doanh thu")
        {
            ChartType = SeriesChartType.Column,
            Color = Color.FromArgb(20, 83, 144),
            BorderWidth = 0,
            IsValueShownAsLabel = false,
            IsXValueIndexed = true
        };
        revenueSeries["PointWidth"] = "0.58";

        foreach (var point in revenuePoints)
        {
            revenueSeries.Points.AddXY(point.Label, point.Value);
        }

        var targetSeries = new Series("Mục tiêu")
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
            targetSeries.Points.AddXY(point.Label, point.Value);
        }

        chtAdminRevenue.Series.Add(revenueSeries);
        chtAdminRevenue.Series.Add(targetSeries);
    }

    private void FormatReportGrid()
    {
        foreach (DataGridViewColumn column in dgvAdminReportDetail.Columns)
        {
            var header = column.HeaderText;
            if (header.Contains("TIỀN", StringComparison.OrdinalIgnoreCase)
                || header.Contains("THU", StringComparison.OrdinalIgnoreCase)
                || header.Contains("NỢ", StringComparison.OrdinalIgnoreCase))
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }

    private void UpdateHighlightProgressWidth()
    {
        if (_currentScenario is null)
        {
            return;
        }

        var width = Math.Max(24, (int)(pnlReportHighlightTrack.ClientSize.Width * _currentScenario.HighlightProgress));
        pnlReportHighlightFill.Width = width;
    }

    private static void LayoutKpiCard(Panel host, Label title, Label value, Label trend, Label icon)
    {
        var compact = host.ClientSize.Width < 260;
        var contentLeft = 30;
        var contentWidth = Math.Max(110, host.ClientSize.Width - 88);
        var blockHeight = compact ? 102 : 112;
        var contentTop = Math.Max(12, (host.ClientSize.Height - blockHeight) / 2);

        title.Font = new Font("Segoe UI", compact ? 9F : 10F, FontStyle.Bold);
        value.Font = new Font("Segoe UI", compact ? 18F : 23F, FontStyle.Bold);
        trend.Font = new Font("Segoe UI", compact ? 9F : 10F, FontStyle.Bold);
        icon.Font = new Font("Segoe UI", compact ? 15F : 18F, FontStyle.Bold);

        title.AutoSize = false;
        title.Location = new Point(contentLeft, contentTop);
        title.Size = new Size(contentWidth, compact ? 34 : 24);
        title.TextAlign = ContentAlignment.MiddleCenter;

        value.AutoSize = false;
        value.Location = new Point(contentLeft, contentTop + (compact ? 30 : 28));
        value.Size = new Size(contentWidth, compact ? 42 : 52);
        value.TextAlign = ContentAlignment.MiddleCenter;

        trend.AutoSize = false;
        trend.Location = new Point(contentLeft, contentTop + (compact ? 76 : 82));
        trend.Size = new Size(contentWidth, 22);
        trend.TextAlign = ContentAlignment.MiddleCenter;

        icon.Location = new Point(Math.Max(contentLeft, host.ClientSize.Width - 56), contentTop + 6);
        icon.Size = new Size(34, 34);
        icon.TextAlign = ContentAlignment.MiddleCenter;
    }

    private void LayoutChartHeader()
    {
        var availableWidth = pnlReportChartHeader.ClientSize.Width;
        var stackedLegend = availableWidth < 700;

        lblReportChartTitle.AutoSize = false;
        lblReportChartTitle.Location = new Point(0, 6);
        lblReportChartTitle.Size = new Size(Math.Max(220, availableWidth - 10), 30);
        lblReportChartTitle.TextAlign = ContentAlignment.MiddleLeft;

        flpChartLegend.AutoSize = true;

        if (stackedLegend)
        {
            pnlReportChartHeader.Height = 78;
            flpChartLegend.Location = new Point(0, 42);
        }
        else
        {
            pnlReportChartHeader.Height = 54;
            flpChartLegend.Location = new Point(Math.Max(0, availableWidth - flpChartLegend.Width), 12);
        }
    }

    private void LayoutHighlightCard()
    {
        var compact = pnlReportHighlightCard.ClientSize.Width < 280;
        lblReportHighlightTitle.Font = new Font("Segoe UI", compact ? 15F : 18F, FontStyle.Bold);
        lblReportHighlightBody.Font = new Font("Segoe UI", compact ? 10.5F : 12F, FontStyle.Regular);

        lblReportHighlightIcon.Location = new Point(24, 10);
        lblReportHighlightIcon.Size = new Size(42, 42);
        lblReportHighlightIcon.TextAlign = ContentAlignment.MiddleCenter;

        lblReportHighlightTitle.AutoSize = false;
        lblReportHighlightTitle.Location = new Point(24, 56);
        lblReportHighlightTitle.Size = new Size(Math.Max(160, pnlReportHighlightCard.ClientSize.Width - 48), compact ? 54 : 44);
        lblReportHighlightTitle.TextAlign = ContentAlignment.MiddleCenter;

        lblReportHighlightBody.AutoSize = false;
        lblReportHighlightBody.Location = new Point(28, compact ? 116 : 110);
        lblReportHighlightBody.Size = new Size(Math.Max(150, pnlReportHighlightCard.ClientSize.Width - 56), compact ? 62 : 50);
        lblReportHighlightBody.TextAlign = ContentAlignment.MiddleCenter;

        pnlReportHighlightTrack.Location = new Point(28, Math.Max(140, pnlReportHighlightCard.ClientSize.Height - 26));
        pnlReportHighlightTrack.Size = new Size(Math.Max(140, pnlReportHighlightCard.ClientSize.Width - 56), 8);
    }

    private void LayoutDistributionCard()
    {
        var compact = pnlReportDistributionCard.ClientSize.Width < 280;
        lblReportDistributionTitle.Font = new Font("Segoe UI", compact ? 10.5F : 11F, FontStyle.Bold);

        lblReportDistributionTitle.AutoSize = false;
        lblReportDistributionTitle.Location = new Point(28, 20);
        lblReportDistributionTitle.Size = new Size(Math.Max(150, pnlReportDistributionCard.ClientSize.Width - 56), 24);

        tblReportDistribution.Location = new Point(28, 54);
        tblReportDistribution.Size = new Size(Math.Max(160, pnlReportDistributionCard.ClientSize.Width - 56), Math.Max(92, pnlReportDistributionCard.ClientSize.Height - 78));

        foreach (RowStyle row in tblReportDistribution.RowStyles)
        {
            row.SizeType = SizeType.Percent;
            row.Height = 33.3333F;
        }

        var nameFont = new Font("Segoe UI", compact ? 10F : 11F, FontStyle.Regular);
        var valueFont = new Font("Segoe UI", compact ? 10F : 11F, FontStyle.Bold);

        lblDistributionCourse1Name.Font = nameFont;
        lblDistributionCourse2Name.Font = nameFont;
        lblDistributionCourse3Name.Font = nameFont;
        lblDistributionCourse1Value.Font = valueFont;
        lblDistributionCourse2Value.Font = valueFont;
        lblDistributionCourse3Value.Font = valueFont;
    }

    private void LayoutDetailHeader()
    {
        var navigationLeft = pnlReportDetailHeader.ClientSize.Width - flpReportDetailNavigation.Width - 18;
        var pagingLeft = navigationLeft - lblReportDetailPaging.Width - 12;

        flpReportDetailNavigation.Location = new Point(Math.Max(24, navigationLeft), 16);
        lblReportDetailPaging.Location = new Point(Math.Max(320, pagingLeft), 22);
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

    private static DataTable BuildRevenueDetailTable()
    {
        var table = CreateReportTable("NGÀY PHÁT SINH", "SỐ BIÊN NHẬN", "HỌC VIÊN", "LỚP", "KHOẢN THU", "SỐ TIỀN (VND)");
        table.Rows.Add("05/01/2024", "PT051", "Nguyễn Hải Đăng", "ENG-A1-01", "Thu học phí đợt 1", "1.500.000");
        table.Rows.Add("05/02/2024", "PT052", "Lê Khánh Vy", "ENG-KID-02", "Thu học phí đủ khóa", "2.100.000");
        table.Rows.Add("05/03/2024", "PT053", "Trần Ngọc Hân", "TIN-CB-03", "Thu học phí đợt 1", "800.000");
        table.Rows.Add("05/05/2024", "PT054", "Phan Đức Minh", "ENG-A1-01", "Thu học phí đủ khóa", "2.400.000");
        table.Rows.Add("05/06/2024", "PT055", "Vũ Gia Bảo", "ENG-KID-02", "Giữ chỗ khai giảng", "500.000");
        table.Rows.Add("05/08/2024", "PT056", "Nguyễn Linh Chi", "ENG-A1-01", "Thu học phí đợt 1", "1.200.000");
        table.Rows.Add("05/10/2024", "PT057", "Lâm Minh Quân", "TIN-CB-03", "Thu học phí đủ khóa", "1.800.000");
        table.Rows.Add("05/12/2024", "PT058", "Hoàng Gia Hân", "ENG-KID-02", "Thu học phí đợt 1", "1.050.000");
        table.Rows.Add("05/15/2024", "PT059", "Phạm Quốc An", "ENG-A1-01", "Thu học phí bổ sung", "900.000");
        table.Rows.Add("05/18/2024", "PT060", "Đỗ Thanh Mai", "TIN-CB-03", "Thu học phí đợt 1", "1.000.000");
        table.Rows.Add("05/21/2024", "PT061", "Nguyễn Khánh Linh", "ENG-A1-01", "Thu học phí đủ khóa", "2.400.000");
        table.Rows.Add("05/24/2024", "PT062", "Trần Bảo Ngọc", "ENG-KID-02", "Thu học phí bổ sung", "650.000");
        return table;
    }

    private static DataTable BuildEnrollmentDetailTable()
    {
        var table = CreateReportTable("NGÀY GHI DANH", "MÃ GHI DANH", "HỌC VIÊN", "KHÓA HỌC", "LỚP", "TRẠNG THÁI");
        table.Rows.Add("05/01/2024", "GD401", "Nguyễn Hải Đăng", "English Foundation", "ENG-A1-01", "Đã xếp lớp");
        table.Rows.Add("05/02/2024", "GD402", "Lê Khánh Vy", "English Kids Starter", "ENG-KID-02", "Đã xếp lớp");
        table.Rows.Add("05/03/2024", "GD403", "Trần Ngọc Hân", "Tin học cơ bản", "TIN-CB-03", "Đã xếp lớp");
        table.Rows.Add("05/04/2024", "GD404", "Phan Đức Minh", "English Foundation", "ENG-A1-01", "Chờ học phí");
        table.Rows.Add("05/06/2024", "GD405", "Vũ Gia Bảo", "English Kids Starter", "ENG-KID-02", "Tư vấn");
        table.Rows.Add("05/07/2024", "GD406", "Nguyễn Linh Chi", "English Foundation", "ENG-A1-01", "Đã xếp lớp");
        table.Rows.Add("05/09/2024", "GD407", "Lâm Minh Quân", "Tin học cơ bản", "TIN-CB-03", "Đã xếp lớp");
        table.Rows.Add("05/10/2024", "GD408", "Hoàng Gia Hân", "English Kids Starter", "ENG-KID-02", "Giữ chỗ");
        table.Rows.Add("05/13/2024", "GD409", "Phạm Quốc An", "English Foundation", "ENG-A1-01", "Đã xếp lớp");
        table.Rows.Add("05/16/2024", "GD410", "Đỗ Thanh Mai", "Tin học cơ bản", "TIN-CB-03", "Chờ khai giảng");
        table.Rows.Add("05/19/2024", "GD411", "Nguyễn Khánh Linh", "English Foundation", "ENG-A1-01", "Đã xếp lớp");
        table.Rows.Add("05/23/2024", "GD412", "Trần Bảo Ngọc", "English Kids Starter", "ENG-KID-02", "Đã xếp lớp");
        return table;
    }

    private static DataTable BuildDebtDetailTable()
    {
        var table = CreateReportTable("NGÀY ĐỐI SOÁT", "HỌC VIÊN", "LỚP", "PHẢI THU", "ĐÃ THU", "CÒN NỢ", "TRẠNG THÁI");
        table.Rows.Add("05/02/2024", "Nguyễn Hải Đăng", "ENG-A1-01", "2.400.000", "1.500.000", "900.000", "Còn nợ");
        table.Rows.Add("05/03/2024", "Trần Ngọc Hân", "TIN-CB-03", "1.800.000", "800.000", "1.000.000", "Còn nợ");
        table.Rows.Add("05/05/2024", "Vũ Gia Bảo", "ENG-KID-02", "2.100.000", "500.000", "1.600.000", "Chờ thu tiếp");
        table.Rows.Add("05/07/2024", "Hoàng Gia Hân", "ENG-KID-02", "2.100.000", "1.050.000", "1.050.000", "Còn nợ");
        table.Rows.Add("05/09/2024", "Đỗ Thanh Mai", "TIN-CB-03", "1.800.000", "1.000.000", "800.000", "Còn nợ");
        table.Rows.Add("05/10/2024", "Phạm Quốc An", "ENG-A1-01", "2.400.000", "900.000", "1.500.000", "Quá hạn 3 ngày");
        table.Rows.Add("05/12/2024", "Nguyễn Khánh Linh", "ENG-A1-01", "2.400.000", "1.200.000", "1.200.000", "Còn nợ");
        table.Rows.Add("05/14/2024", "Trần Bảo Ngọc", "ENG-KID-02", "2.100.000", "650.000", "1.450.000", "Quá hạn 5 ngày");
        table.Rows.Add("05/16/2024", "Lâm Minh Quân", "TIN-CB-03", "1.800.000", "1.200.000", "600.000", "Nhắc phí");
        table.Rows.Add("05/18/2024", "Nguyễn Linh Chi", "ENG-A1-01", "2.400.000", "1.200.000", "1.200.000", "Còn nợ");
        table.Rows.Add("05/20/2024", "Phan Đức Minh", "ENG-A1-01", "2.400.000", "2.000.000", "400.000", "Sắp đến hạn");
        table.Rows.Add("05/24/2024", "Lê Khánh Vy", "ENG-KID-02", "2.100.000", "1.800.000", "300.000", "Sắp đến hạn");
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

    private static ReportScenario BuildScenario(string reportType)
    {
        return reportType switch
        {
            "Tuyển sinh" => new ReportScenario
            {
                RevenueTitle = "TỔNG HỒ SƠ GHI DANH",
                RevenueValue = "842",
                RevenueTrend = "↑ 9.1%",
                EnrollmentTitle = "HỌC VIÊN MỚI",
                EnrollmentValue = "524",
                EnrollmentTrend = "↑ 6.3%",
                ClassTitle = "SỐ LỚP MỞ MỚI",
                ClassValue = "31",
                ClassTrend = "↑ 3.4%",
                RetentionTitle = "TỶ LỆ CHUYỂN ĐỔI",
                RetentionValue = "76.8%",
                RetentionTrend = "↑ 2.6%",
                ChartTitle = "XU HƯỚNG TUYỂN SINH HÀNG THÁNG",
                DetailTitle = "CHI TIẾT HỒ SƠ PHÁT SINH",
                HighlightTitle = "Chiến dịch hè tăng 18%",
                HighlightBody = "Tỷ lệ chốt hồ sơ từ nhóm khách hàng mới đạt mức cao nhất kể từ đầu năm.",
                HighlightProgress = 0.82,
                DetailPaging = "Hiển thị 10 / 96 kết quả",
                Distributions =
                [
                    ("English Foundation", "41%"),
                    ("English Kids Starter", "34%"),
                    ("Tin học cơ bản", "25%")
                ],
                ChartPoints =
                [
                    ("TH01", 148),
                    ("TH02", 182),
                    ("TH03", 164),
                    ("TH04", 214),
                    ("TH05", 246)
                ],
                TargetPoints =
                [
                    ("TH01", 140),
                    ("TH02", 168),
                    ("TH03", 170),
                    ("TH04", 198),
                    ("TH05", 220)
                ],
                DetailTable = BuildEnrollmentDetailTable()
            },
            "Công nợ" => new ReportScenario
            {
                RevenueTitle = "TỔNG CÔNG NỢ",
                RevenueValue = "98.120K",
                RevenueTrend = "↓ 4.7%",
                EnrollmentTitle = "HỒ SƠ QUÁ HẠN",
                EnrollmentValue = "37",
                EnrollmentTrend = "↓ 2.1%",
                ClassTitle = "LỚP CẦN ĐỐI SOÁT",
                ClassValue = "14",
                ClassTrend = "↑ 1.2%",
                RetentionTitle = "TỶ LỆ THU HỒI",
                RetentionValue = "88.6%",
                RetentionTrend = "↑ 3.9%",
                ChartTitle = "XU HƯỚNG CÔNG NỢ HÀNG THÁNG",
                DetailTitle = "CHI TIẾT CÔNG NỢ TRONG KỲ",
                HighlightTitle = "Công nợ giảm còn 4.7%",
                HighlightBody = "Nhóm lớp IELTS đã hoàn thành đợt đối soát sớm hơn kế hoạch 5 ngày.",
                HighlightProgress = 0.68,
                DetailPaging = "Hiển thị 10 / 58 kết quả",
                Distributions =
                [
                    ("English Foundation", "44%"),
                    ("English Kids Starter", "31%"),
                    ("Tin học cơ bản", "25%")
                ],
                ChartPoints =
                [
                    ("TH01", 124),
                    ("TH02", 118),
                    ("TH03", 102),
                    ("TH04", 95),
                    ("TH05", 88)
                ],
                TargetPoints =
                [
                    ("TH01", 120),
                    ("TH02", 112),
                    ("TH03", 108),
                    ("TH04", 96),
                    ("TH05", 90)
                ],
                DetailTable = BuildDebtDetailTable()
            },
            _ => new ReportScenario
            {
                RevenueTitle = "TỔNG DOANH THU",
                RevenueValue = "1.420.500K",
                RevenueTrend = "↑ 12.4%",
                EnrollmentTitle = "HỌC VIÊN MỚI",
                EnrollmentValue = "842",
                EnrollmentTrend = "↑ 5.2%",
                ClassTitle = "SỐ LỚP ĐANG MỞ",
                ClassValue = "156",
                ClassTrend = "0.0%",
                RetentionTitle = "TỶ LỆ DUY TRÌ",
                RetentionValue = "94.2%",
                RetentionTrend = "↑ 1.8%",
                ChartTitle = "XU HƯỚNG DOANH THU HÀNG THÁNG",
                DetailTitle = "CHI TIẾT PHÁT SINH TRONG KỲ",
                HighlightTitle = "Phát triển vượt mức 15%",
                HighlightBody = "Chiến dịch tuyển sinh mùa hè đạt hiệu quả cao nhất trong 3 năm qua.",
                HighlightProgress = 0.86,
                DetailPaging = "Hiển thị 10 / 125 kết quả",
                Distributions =
                [
                    ("English Foundation", "42%"),
                    ("English Kids Starter", "33%"),
                    ("Tin học cơ bản", "25%")
                ],
                ChartPoints =
                [
                    ("TH01", 420),
                    ("TH02", 515),
                    ("TH03", 338),
                    ("TH04", 614),
                    ("TH05", 702)
                ],
                TargetPoints =
                [
                    ("TH01", 405),
                    ("TH02", 480),
                    ("TH03", 360),
                    ("TH04", 560),
                    ("TH05", 650)
                ],
                DetailTable = BuildRevenueDetailTable()
            }
        };
    }

    private void ShowExportHint(string action)
    {
        using var dialog = new FrmStatusDialog(
            action,
            $"Chức năng {action.ToLower()} đang dùng dữ liệu mẫu. Backend có thể nối sang dữ liệu thật sau.");
        dialog.ShowDialog(this);
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
        public required (string Label, double Value)[] ChartPoints { get; init; }
        public required (string Label, double Value)[] TargetPoints { get; init; }
        public required DataTable DetailTable { get; init; }
    }
}
