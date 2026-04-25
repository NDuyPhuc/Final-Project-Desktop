using System.Windows.Forms.DataVisualization.Charting;

namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmAdminReports
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tblAdminReportRoot;
    private Panel pnlAdminReportHeader;
    private TableLayoutPanel tblAdminReportHeaderLayout;
    private Panel pnlAdminReportTitleBlock;
    private Label lblAdminReportTitle;
    private FlowLayoutPanel flpAdminReportMeta;
    private Label lblAdminReportSession;
    private Label lblAdminReportStatus;
    private FlowLayoutPanel flpAdminReportHeaderActions;
    private Button btnPrintReport;
    private Button btnRefreshData;
    private Panel pnlAdminReportFilterCard;
    private TableLayoutPanel tblAdminReportFilter;
    private Label lblReportType;
    private Label lblReportFromDate;
    private Label lblReportToDate;
    private ComboBox cboReportType;
    private DateTimePicker dtpReportFromDate;
    private DateTimePicker dtpReportToDate;
    private Button btnViewReport;
    private Button btnExportReportCsv;
    private TableLayoutPanel tblReportKpi;
    private Panel pnlReportRevenue;
    private Panel pnlReportRevenueAccent;
    private Label lblReportRevenueTitle;
    private Label lblReportRevenueValue;
    private Label lblReportRevenueTrend;
    private Label lblReportRevenueIcon;
    private Panel pnlReportEnrollment;
    private Panel pnlReportEnrollmentAccent;
    private Label lblReportEnrollmentTitle;
    private Label lblReportEnrollmentValue;
    private Label lblReportEnrollmentTrend;
    private Label lblReportEnrollmentIcon;
    private Panel pnlReportClassCount;
    private Panel pnlReportClassCountAccent;
    private Label lblReportClassCountTitle;
    private Label lblReportClassCountValue;
    private Label lblReportClassCountTrend;
    private Label lblReportClassCountIcon;
    private Panel pnlReportRetention;
    private Panel pnlReportRetentionAccent;
    private Label lblReportRetentionTitle;
    private Label lblReportRetentionValue;
    private Label lblReportRetentionTrend;
    private Label lblReportRetentionIcon;
    private TableLayoutPanel tblReportMiddle;
    private Panel pnlReportChartCard;
    private Panel pnlReportChartHeader;
    private Label lblReportChartTitle;
    private FlowLayoutPanel flpChartLegend;
    private Panel pnlChartLegendRevenue;
    private Label lblChartLegendRevenue;
    private Panel pnlChartLegendTarget;
    private Label lblChartLegendTarget;
    private Chart chtAdminRevenue;
    private TableLayoutPanel tblReportSideColumn;
    private Panel pnlReportHighlightCard;
    private Label lblReportHighlightIcon;
    private Label lblReportHighlightTitle;
    private Label lblReportHighlightBody;
    private Panel pnlReportHighlightTrack;
    private Panel pnlReportHighlightFill;
    private Panel pnlReportDistributionCard;
    private Label lblReportDistributionTitle;
    private TableLayoutPanel tblReportDistribution;
    private Label lblDistributionCourse1Name;
    private Label lblDistributionCourse1Value;
    private Label lblDistributionCourse2Name;
    private Label lblDistributionCourse2Value;
    private Label lblDistributionCourse3Name;
    private Label lblDistributionCourse3Value;
    private Panel pnlReportDetailCard;
    private Panel pnlReportDetailHeader;
    private Label lblReportDetailTitle;
    private Label lblReportDetailPaging;
    private FlowLayoutPanel flpReportDetailNavigation;
    private Button btnReportPrevPage;
    private Button btnReportNextPage;
    private DataGridView dgvAdminReportDetail;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        ChartArea chartArea1 = new ChartArea();
        Legend legend1 = new Legend();
        tblAdminReportRoot = new TableLayoutPanel();
        pnlAdminReportHeader = new Panel();
        tblAdminReportHeaderLayout = new TableLayoutPanel();
        pnlAdminReportTitleBlock = new Panel();
        flpAdminReportMeta = new FlowLayoutPanel();
        lblAdminReportSession = new Label();
        lblAdminReportStatus = new Label();
        lblAdminReportTitle = new Label();
        flpAdminReportHeaderActions = new FlowLayoutPanel();
        btnPrintReport = new Button();
        btnRefreshData = new Button();
        btnExportReportCsv = new Button();
        pnlAdminReportFilterCard = new Panel();
        tblAdminReportFilter = new TableLayoutPanel();
        lblReportType = new Label();
        lblReportFromDate = new Label();
        lblReportToDate = new Label();
        cboReportType = new ComboBox();
        dtpReportFromDate = new DateTimePicker();
        dtpReportToDate = new DateTimePicker();
        btnViewReport = new Button();
        tblReportKpi = new TableLayoutPanel();
        pnlReportRevenue = new Panel();
        lblReportRevenueIcon = new Label();
        lblReportRevenueTrend = new Label();
        lblReportRevenueValue = new Label();
        lblReportRevenueTitle = new Label();
        pnlReportRevenueAccent = new Panel();
        pnlReportEnrollment = new Panel();
        lblReportEnrollmentIcon = new Label();
        lblReportEnrollmentTrend = new Label();
        lblReportEnrollmentValue = new Label();
        lblReportEnrollmentTitle = new Label();
        pnlReportEnrollmentAccent = new Panel();
        pnlReportClassCount = new Panel();
        lblReportClassCountIcon = new Label();
        lblReportClassCountTrend = new Label();
        lblReportClassCountValue = new Label();
        lblReportClassCountTitle = new Label();
        pnlReportClassCountAccent = new Panel();
        pnlReportRetention = new Panel();
        lblReportRetentionIcon = new Label();
        lblReportRetentionTrend = new Label();
        lblReportRetentionValue = new Label();
        lblReportRetentionTitle = new Label();
        pnlReportRetentionAccent = new Panel();
        tblReportMiddle = new TableLayoutPanel();
        pnlReportChartCard = new Panel();
        chtAdminRevenue = new Chart();
        pnlReportChartHeader = new Panel();
        flpChartLegend = new FlowLayoutPanel();
        pnlChartLegendRevenue = new Panel();
        lblChartLegendRevenue = new Label();
        pnlChartLegendTarget = new Panel();
        lblChartLegendTarget = new Label();
        lblReportChartTitle = new Label();
        tblReportSideColumn = new TableLayoutPanel();
        pnlReportHighlightCard = new Panel();
        pnlReportHighlightTrack = new Panel();
        pnlReportHighlightFill = new Panel();
        lblReportHighlightBody = new Label();
        lblReportHighlightTitle = new Label();
        lblReportHighlightIcon = new Label();
        pnlReportDistributionCard = new Panel();
        tblReportDistribution = new TableLayoutPanel();
        lblDistributionCourse1Name = new Label();
        lblDistributionCourse1Value = new Label();
        lblDistributionCourse2Name = new Label();
        lblDistributionCourse2Value = new Label();
        lblDistributionCourse3Name = new Label();
        lblDistributionCourse3Value = new Label();
        lblReportDistributionTitle = new Label();
        pnlReportDetailCard = new Panel();
        dgvAdminReportDetail = new DataGridView();
        pnlReportDetailHeader = new Panel();
        flpReportDetailNavigation = new FlowLayoutPanel();
        btnReportPrevPage = new Button();
        btnReportNextPage = new Button();
        lblReportDetailPaging = new Label();
        lblReportDetailTitle = new Label();
        tblAdminReportRoot.SuspendLayout();
        pnlAdminReportHeader.SuspendLayout();
        tblAdminReportHeaderLayout.SuspendLayout();
        pnlAdminReportTitleBlock.SuspendLayout();
        flpAdminReportMeta.SuspendLayout();
        flpAdminReportHeaderActions.SuspendLayout();
        pnlAdminReportFilterCard.SuspendLayout();
        tblAdminReportFilter.SuspendLayout();
        tblReportKpi.SuspendLayout();
        pnlReportRevenue.SuspendLayout();
        pnlReportEnrollment.SuspendLayout();
        pnlReportClassCount.SuspendLayout();
        pnlReportRetention.SuspendLayout();
        tblReportMiddle.SuspendLayout();
        pnlReportChartCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)chtAdminRevenue).BeginInit();
        pnlReportChartHeader.SuspendLayout();
        flpChartLegend.SuspendLayout();
        tblReportSideColumn.SuspendLayout();
        pnlReportHighlightCard.SuspendLayout();
        pnlReportHighlightTrack.SuspendLayout();
        pnlReportDistributionCard.SuspendLayout();
        tblReportDistribution.SuspendLayout();
        pnlReportDetailCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvAdminReportDetail).BeginInit();
        pnlReportDetailHeader.SuspendLayout();
        flpReportDetailNavigation.SuspendLayout();
        SuspendLayout();
        // 
        // tblAdminReportRoot
        // 
        tblAdminReportRoot.AutoScroll = true;
        tblAdminReportRoot.ColumnCount = 1;
        tblAdminReportRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblAdminReportRoot.Controls.Add(pnlAdminReportHeader, 0, 0);
        tblAdminReportRoot.Controls.Add(pnlAdminReportFilterCard, 0, 1);
        tblAdminReportRoot.Controls.Add(tblReportKpi, 0, 2);
        tblAdminReportRoot.Controls.Add(tblReportMiddle, 0, 3);
        tblAdminReportRoot.Controls.Add(pnlReportDetailCard, 0, 4);
        tblAdminReportRoot.Dock = DockStyle.Fill;
        tblAdminReportRoot.Location = new Point(18, 18);
        tblAdminReportRoot.Margin = new Padding(0);
        tblAdminReportRoot.Name = "tblAdminReportRoot";
        tblAdminReportRoot.RowCount = 5;
        tblAdminReportRoot.RowStyles.Add(new RowStyle());
        tblAdminReportRoot.RowStyles.Add(new RowStyle());
        tblAdminReportRoot.RowStyles.Add(new RowStyle());
        tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 350F));
        tblAdminReportRoot.Size = new Size(1224, 804);
        tblAdminReportRoot.TabIndex = 0;
        // 
        // pnlAdminReportHeader
        // 
        pnlAdminReportHeader.Controls.Add(tblAdminReportHeaderLayout);
        pnlAdminReportHeader.Dock = DockStyle.Fill;
        pnlAdminReportHeader.Location = new Point(0, 0);
        pnlAdminReportHeader.Margin = new Padding(0, 0, 0, 18);
        pnlAdminReportHeader.Name = "pnlAdminReportHeader";
        pnlAdminReportHeader.Size = new Size(1224, 74);
        pnlAdminReportHeader.TabIndex = 0;
        // 
        // tblAdminReportHeaderLayout
        // 
        tblAdminReportHeaderLayout.ColumnCount = 2;
        tblAdminReportHeaderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblAdminReportHeaderLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 432F));
        tblAdminReportHeaderLayout.Controls.Add(pnlAdminReportTitleBlock, 0, 0);
        tblAdminReportHeaderLayout.Controls.Add(flpAdminReportHeaderActions, 1, 0);
        tblAdminReportHeaderLayout.Dock = DockStyle.Fill;
        tblAdminReportHeaderLayout.Location = new Point(0, 0);
        tblAdminReportHeaderLayout.Margin = new Padding(0);
        tblAdminReportHeaderLayout.Name = "tblAdminReportHeaderLayout";
        tblAdminReportHeaderLayout.RowCount = 1;
        tblAdminReportHeaderLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblAdminReportHeaderLayout.Size = new Size(1224, 74);
        tblAdminReportHeaderLayout.TabIndex = 0;
        // 
        // pnlAdminReportTitleBlock
        // 
        pnlAdminReportTitleBlock.Controls.Add(flpAdminReportMeta);
        pnlAdminReportTitleBlock.Controls.Add(lblAdminReportTitle);
        pnlAdminReportTitleBlock.Dock = DockStyle.Fill;
        pnlAdminReportTitleBlock.Location = new Point(0, 0);
        pnlAdminReportTitleBlock.Margin = new Padding(0);
        pnlAdminReportTitleBlock.Name = "pnlAdminReportTitleBlock";
        pnlAdminReportTitleBlock.Size = new Size(792, 74);
        pnlAdminReportTitleBlock.TabIndex = 0;
        // 
        // flpAdminReportMeta
        // 
        flpAdminReportMeta.AutoSize = true;
        flpAdminReportMeta.Controls.Add(lblAdminReportSession);
        flpAdminReportMeta.Controls.Add(lblAdminReportStatus);
        flpAdminReportMeta.Location = new Point(2, 54);
        flpAdminReportMeta.Margin = new Padding(0);
        flpAdminReportMeta.Name = "flpAdminReportMeta";
        flpAdminReportMeta.Size = new Size(569, 30);
        flpAdminReportMeta.TabIndex = 1;
        flpAdminReportMeta.WrapContents = false;
        // 
        // lblAdminReportSession
        // 
        lblAdminReportSession.AutoSize = true;
        lblAdminReportSession.Font = new Font("Segoe UI", 10.5F);
        lblAdminReportSession.ForeColor = Color.FromArgb(49, 58, 71);
        lblAdminReportSession.Location = new Point(0, 0);
        lblAdminReportSession.Margin = new Padding(0, 0, 20, 0);
        lblAdminReportSession.Name = "lblAdminReportSession";
        lblAdminReportSession.Size = new Size(243, 30);
        lblAdminReportSession.TabIndex = 0;
        lblAdminReportSession.Text = "PHIÊN: 24/05/2024 14:30";
        // 
        // lblAdminReportStatus
        // 
        lblAdminReportStatus.AutoSize = true;
        lblAdminReportStatus.Font = new Font("Segoe UI", 10.5F);
        lblAdminReportStatus.ForeColor = Color.FromArgb(49, 58, 71);
        lblAdminReportStatus.Location = new Point(263, 0);
        lblAdminReportStatus.Margin = new Padding(0);
        lblAdminReportStatus.Name = "lblAdminReportStatus";
        lblAdminReportStatus.Size = new Size(306, 30);
        lblAdminReportStatus.TabIndex = 1;
        lblAdminReportStatus.Text = "TRẠNG THÁI: ADMINISTRATOR";
        // 
        // lblAdminReportTitle
        // 
        lblAdminReportTitle.AutoSize = true;
        lblAdminReportTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
        lblAdminReportTitle.ForeColor = Color.FromArgb(7, 30, 39);
        lblAdminReportTitle.Location = new Point(0, 0);
        lblAdminReportTitle.Margin = new Padding(0);
        lblAdminReportTitle.Name = "lblAdminReportTitle";
        lblAdminReportTitle.Size = new Size(578, 74);
        lblAdminReportTitle.TabIndex = 0;
        lblAdminReportTitle.Text = "BÁO CÁO THỐNG KÊ";
        // 
        // flpAdminReportHeaderActions
        // 
        flpAdminReportHeaderActions.Controls.Add(btnPrintReport);
        flpAdminReportHeaderActions.Controls.Add(btnRefreshData);
        flpAdminReportHeaderActions.Controls.Add(btnExportReportCsv);
        flpAdminReportHeaderActions.Dock = DockStyle.Fill;
        flpAdminReportHeaderActions.FlowDirection = FlowDirection.RightToLeft;
        flpAdminReportHeaderActions.Location = new Point(792, 0);
        flpAdminReportHeaderActions.Margin = new Padding(0);
        flpAdminReportHeaderActions.Name = "flpAdminReportHeaderActions";
        flpAdminReportHeaderActions.Padding = new Padding(0, 20, 0, 0);
        flpAdminReportHeaderActions.Size = new Size(432, 74);
        flpAdminReportHeaderActions.TabIndex = 1;
        flpAdminReportHeaderActions.WrapContents = false;
        // 
        // btnPrintReport
        // 
        btnPrintReport.FlatStyle = FlatStyle.Flat;
        btnPrintReport.Location = new Point(252, 20);
        btnPrintReport.Margin = new Padding(12, 0, 0, 0);
        btnPrintReport.Name = "btnPrintReport";
        btnPrintReport.Size = new Size(180, 52);
        btnPrintReport.TabIndex = 0;
        btnPrintReport.Text = "IN BÁO CÁO";
        btnPrintReport.UseVisualStyleBackColor = true;
        // 
        // btnRefreshData
        // 
        btnRefreshData.FlatStyle = FlatStyle.Flat;
        btnRefreshData.Location = new Point(60, 20);
        btnRefreshData.Margin = new Padding(12, 0, 0, 0);
        btnRefreshData.Name = "btnRefreshData";
        btnRefreshData.Size = new Size(180, 52);
        btnRefreshData.TabIndex = 1;
        btnRefreshData.Text = "CẬP NHẬT DỮ LIỆU";
        btnRefreshData.UseVisualStyleBackColor = true;
        // 
        // btnExportReportCsv
        // 
        btnExportReportCsv.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnExportReportCsv.FlatStyle = FlatStyle.Flat;
        btnExportReportCsv.Location = new Point(-142, 24);
        btnExportReportCsv.Margin = new Padding(0);
        btnExportReportCsv.Name = "btnExportReportCsv";
        btnExportReportCsv.Size = new Size(190, 48);
        btnExportReportCsv.TabIndex = 7;
        btnExportReportCsv.Text = "XUẤT FILE (.CSV)";
        btnExportReportCsv.UseVisualStyleBackColor = true;
        // 
        // pnlAdminReportFilterCard
        // 
        pnlAdminReportFilterCard.Controls.Add(tblAdminReportFilter);
        pnlAdminReportFilterCard.Dock = DockStyle.Fill;
        pnlAdminReportFilterCard.Location = new Point(0, 92);
        pnlAdminReportFilterCard.Margin = new Padding(0, 0, 0, 18);
        pnlAdminReportFilterCard.Name = "pnlAdminReportFilterCard";
        pnlAdminReportFilterCard.Padding = new Padding(20, 18, 20, 20);
        pnlAdminReportFilterCard.Size = new Size(1224, 110);
        pnlAdminReportFilterCard.TabIndex = 1;
        // 
        // tblAdminReportFilter
        // 
        tblAdminReportFilter.ColumnCount = 5;
        tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
        tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210F));
        tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210F));
        tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
        tblAdminReportFilter.Controls.Add(lblReportType, 0, 0);
        tblAdminReportFilter.Controls.Add(lblReportFromDate, 1, 0);
        tblAdminReportFilter.Controls.Add(lblReportToDate, 2, 0);
        tblAdminReportFilter.Controls.Add(cboReportType, 0, 1);
        tblAdminReportFilter.Controls.Add(dtpReportFromDate, 1, 1);
        tblAdminReportFilter.Controls.Add(dtpReportToDate, 2, 1);
        tblAdminReportFilter.Controls.Add(btnViewReport, 3, 1);
        tblAdminReportFilter.Dock = DockStyle.Fill;
        tblAdminReportFilter.Location = new Point(20, 18);
        tblAdminReportFilter.Margin = new Padding(0);
        tblAdminReportFilter.Name = "tblAdminReportFilter";
        tblAdminReportFilter.RowCount = 2;
        tblAdminReportFilter.RowStyles.Add(new RowStyle());
        tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblAdminReportFilter.Size = new Size(1184, 72);
        tblAdminReportFilter.TabIndex = 0;
        // 
        // lblReportType
        // 
        lblReportType.AutoSize = true;
        lblReportType.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblReportType.Location = new Point(0, 0);
        lblReportType.Margin = new Padding(0, 0, 0, 10);
        lblReportType.Name = "lblReportType";
        lblReportType.Size = new Size(143, 25);
        lblReportType.TabIndex = 0;
        lblReportType.Text = "LOẠI BÁO CÁO";
        // 
        // lblReportFromDate
        // 
        lblReportFromDate.AutoSize = true;
        lblReportFromDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblReportFromDate.Location = new Point(300, 0);
        lblReportFromDate.Margin = new Padding(0, 0, 0, 10);
        lblReportFromDate.Name = "lblReportFromDate";
        lblReportFromDate.Size = new Size(96, 25);
        lblReportFromDate.TabIndex = 1;
        lblReportFromDate.Text = "TỪ NGÀY";
        // 
        // lblReportToDate
        // 
        lblReportToDate.AutoSize = true;
        lblReportToDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblReportToDate.Location = new Point(510, 0);
        lblReportToDate.Margin = new Padding(0, 0, 0, 10);
        lblReportToDate.Name = "lblReportToDate";
        lblReportToDate.Size = new Size(109, 25);
        lblReportToDate.TabIndex = 2;
        lblReportToDate.Text = "ĐẾN NGÀY";
        // 
        // cboReportType
        // 
        cboReportType.Dock = DockStyle.Fill;
        cboReportType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboReportType.FormattingEnabled = true;
        cboReportType.Location = new Point(0, 35);
        cboReportType.Margin = new Padding(0, 0, 22, 0);
        cboReportType.Name = "cboReportType";
        cboReportType.Size = new Size(278, 36);
        cboReportType.TabIndex = 3;
        // 
        // dtpReportFromDate
        // 
        dtpReportFromDate.CalendarMonthBackground = Color.White;
        dtpReportFromDate.CustomFormat = "MM/dd/yyyy";
        dtpReportFromDate.Dock = DockStyle.Fill;
        dtpReportFromDate.Format = DateTimePickerFormat.Custom;
        dtpReportFromDate.Location = new Point(300, 35);
        dtpReportFromDate.Margin = new Padding(0, 0, 22, 0);
        dtpReportFromDate.Name = "dtpReportFromDate";
        dtpReportFromDate.Size = new Size(188, 34);
        dtpReportFromDate.TabIndex = 4;
        // 
        // dtpReportToDate
        // 
        dtpReportToDate.CalendarMonthBackground = Color.White;
        dtpReportToDate.CustomFormat = "MM/dd/yyyy";
        dtpReportToDate.Dock = DockStyle.Fill;
        dtpReportToDate.Format = DateTimePickerFormat.Custom;
        dtpReportToDate.Location = new Point(510, 35);
        dtpReportToDate.Margin = new Padding(0, 0, 22, 0);
        dtpReportToDate.Name = "dtpReportToDate";
        dtpReportToDate.Size = new Size(188, 34);
        dtpReportToDate.TabIndex = 5;
        // 
        // btnViewReport
        // 
        btnViewReport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnViewReport.FlatStyle = FlatStyle.Flat;
        btnViewReport.Location = new Point(804, 35);
        btnViewReport.Margin = new Padding(0);
        btnViewReport.Name = "btnViewReport";
        btnViewReport.Size = new Size(180, 37);
        btnViewReport.TabIndex = 6;
        btnViewReport.Text = "XEM BÁO CÁO";
        btnViewReport.UseVisualStyleBackColor = true;
        // 
        // tblReportKpi
        // 
        tblReportKpi.ColumnCount = 4;
        tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblReportKpi.Controls.Add(pnlReportRevenue, 0, 0);
        tblReportKpi.Controls.Add(pnlReportEnrollment, 1, 0);
        tblReportKpi.Controls.Add(pnlReportClassCount, 2, 0);
        tblReportKpi.Controls.Add(pnlReportRetention, 3, 0);
        tblReportKpi.Dock = DockStyle.Fill;
        tblReportKpi.Location = new Point(0, 220);
        tblReportKpi.Margin = new Padding(0, 0, 0, 18);
        tblReportKpi.Name = "tblReportKpi";
        tblReportKpi.RowCount = 1;
        tblReportKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblReportKpi.Size = new Size(1224, 112);
        tblReportKpi.TabIndex = 2;
        // 
        // pnlReportRevenue
        // 
        pnlReportRevenue.Controls.Add(lblReportRevenueIcon);
        pnlReportRevenue.Controls.Add(lblReportRevenueTrend);
        pnlReportRevenue.Controls.Add(lblReportRevenueValue);
        pnlReportRevenue.Controls.Add(lblReportRevenueTitle);
        pnlReportRevenue.Controls.Add(pnlReportRevenueAccent);
        pnlReportRevenue.Dock = DockStyle.Fill;
        pnlReportRevenue.Location = new Point(0, 0);
        pnlReportRevenue.Margin = new Padding(0, 0, 18, 0);
        pnlReportRevenue.Name = "pnlReportRevenue";
        pnlReportRevenue.Padding = new Padding(20, 18, 20, 18);
        pnlReportRevenue.Size = new Size(288, 112);
        pnlReportRevenue.TabIndex = 0;
        // 
        // lblReportRevenueIcon
        // 
        lblReportRevenueIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblReportRevenueIcon.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblReportRevenueIcon.Location = new Point(233, 18);
        lblReportRevenueIcon.Name = "lblReportRevenueIcon";
        lblReportRevenueIcon.Size = new Size(34, 34);
        lblReportRevenueIcon.TabIndex = 4;
        lblReportRevenueIcon.Text = "$";
        lblReportRevenueIcon.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblReportRevenueTrend
        // 
        lblReportRevenueTrend.AutoSize = true;
        lblReportRevenueTrend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblReportRevenueTrend.Location = new Point(30, 92);
        lblReportRevenueTrend.Name = "lblReportRevenueTrend";
        lblReportRevenueTrend.Size = new Size(85, 28);
        lblReportRevenueTrend.TabIndex = 3;
        lblReportRevenueTrend.Text = "↑ 12.4%";
        // 
        // lblReportRevenueValue
        // 
        lblReportRevenueValue.AutoSize = true;
        lblReportRevenueValue.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
        lblReportRevenueValue.Location = new Point(28, 48);
        lblReportRevenueValue.Name = "lblReportRevenueValue";
        lblReportRevenueValue.Size = new Size(263, 62);
        lblReportRevenueValue.TabIndex = 2;
        lblReportRevenueValue.Text = "1.420.500K";
        // 
        // lblReportRevenueTitle
        // 
        lblReportRevenueTitle.AutoSize = true;
        lblReportRevenueTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblReportRevenueTitle.Location = new Point(28, 18);
        lblReportRevenueTitle.Name = "lblReportRevenueTitle";
        lblReportRevenueTitle.Size = new Size(197, 28);
        lblReportRevenueTitle.TabIndex = 1;
        lblReportRevenueTitle.Text = "TỔNG DOANH THU";
        // 
        // pnlReportRevenueAccent
        // 
        pnlReportRevenueAccent.AutoScroll = true;
        pnlReportRevenueAccent.Dock = DockStyle.Left;
        pnlReportRevenueAccent.Location = new Point(20, 18);
        pnlReportRevenueAccent.Name = "pnlReportRevenueAccent";
        pnlReportRevenueAccent.Size = new Size(4, 76);
        pnlReportRevenueAccent.TabIndex = 0;
        // 
        // pnlReportEnrollment
        // 
        pnlReportEnrollment.Controls.Add(lblReportEnrollmentIcon);
        pnlReportEnrollment.Controls.Add(lblReportEnrollmentTrend);
        pnlReportEnrollment.Controls.Add(lblReportEnrollmentValue);
        pnlReportEnrollment.Controls.Add(lblReportEnrollmentTitle);
        pnlReportEnrollment.Controls.Add(pnlReportEnrollmentAccent);
        pnlReportEnrollment.Dock = DockStyle.Fill;
        pnlReportEnrollment.Location = new Point(306, 0);
        pnlReportEnrollment.Margin = new Padding(0, 0, 18, 0);
        pnlReportEnrollment.Name = "pnlReportEnrollment";
        pnlReportEnrollment.Padding = new Padding(20, 18, 20, 18);
        pnlReportEnrollment.Size = new Size(288, 112);
        pnlReportEnrollment.TabIndex = 1;
        // 
        // lblReportEnrollmentIcon
        // 
        lblReportEnrollmentIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblReportEnrollmentIcon.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblReportEnrollmentIcon.Location = new Point(206, 18);
        lblReportEnrollmentIcon.Name = "lblReportEnrollmentIcon";
        lblReportEnrollmentIcon.Size = new Size(34, 34);
        lblReportEnrollmentIcon.TabIndex = 4;
        lblReportEnrollmentIcon.Text = "+";
        lblReportEnrollmentIcon.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblReportEnrollmentTrend
        // 
        lblReportEnrollmentTrend.AutoSize = true;
        lblReportEnrollmentTrend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblReportEnrollmentTrend.Location = new Point(30, 92);
        lblReportEnrollmentTrend.Name = "lblReportEnrollmentTrend";
        lblReportEnrollmentTrend.Size = new Size(73, 28);
        lblReportEnrollmentTrend.TabIndex = 3;
        lblReportEnrollmentTrend.Text = "↑ 5.2%";
        // 
        // lblReportEnrollmentValue
        // 
        lblReportEnrollmentValue.AutoSize = true;
        lblReportEnrollmentValue.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
        lblReportEnrollmentValue.Location = new Point(28, 48);
        lblReportEnrollmentValue.Name = "lblReportEnrollmentValue";
        lblReportEnrollmentValue.Size = new Size(105, 62);
        lblReportEnrollmentValue.TabIndex = 2;
        lblReportEnrollmentValue.Text = "842";
        // 
        // lblReportEnrollmentTitle
        // 
        lblReportEnrollmentTitle.AutoSize = true;
        lblReportEnrollmentTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblReportEnrollmentTitle.Location = new Point(28, 18);
        lblReportEnrollmentTitle.Name = "lblReportEnrollmentTitle";
        lblReportEnrollmentTitle.Size = new Size(153, 28);
        lblReportEnrollmentTitle.TabIndex = 1;
        lblReportEnrollmentTitle.Text = "HỌC VIÊN MỚI";
        // 
        // pnlReportEnrollmentAccent
        // 
        pnlReportEnrollmentAccent.AutoScroll = true;
        pnlReportEnrollmentAccent.Dock = DockStyle.Left;
        pnlReportEnrollmentAccent.Location = new Point(20, 18);
        pnlReportEnrollmentAccent.Name = "pnlReportEnrollmentAccent";
        pnlReportEnrollmentAccent.Size = new Size(4, 76);
        pnlReportEnrollmentAccent.TabIndex = 0;
        // 
        // pnlReportClassCount
        // 
        pnlReportClassCount.Controls.Add(lblReportClassCountIcon);
        pnlReportClassCount.Controls.Add(lblReportClassCountTrend);
        pnlReportClassCount.Controls.Add(lblReportClassCountValue);
        pnlReportClassCount.Controls.Add(lblReportClassCountTitle);
        pnlReportClassCount.Controls.Add(pnlReportClassCountAccent);
        pnlReportClassCount.Dock = DockStyle.Fill;
        pnlReportClassCount.Location = new Point(612, 0);
        pnlReportClassCount.Margin = new Padding(0, 0, 18, 0);
        pnlReportClassCount.Name = "pnlReportClassCount";
        pnlReportClassCount.Padding = new Padding(20, 18, 20, 18);
        pnlReportClassCount.Size = new Size(288, 112);
        pnlReportClassCount.TabIndex = 2;
        // 
        // lblReportClassCountIcon
        // 
        lblReportClassCountIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblReportClassCountIcon.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblReportClassCountIcon.Location = new Point(206, 18);
        lblReportClassCountIcon.Name = "lblReportClassCountIcon";
        lblReportClassCountIcon.Size = new Size(34, 34);
        lblReportClassCountIcon.TabIndex = 4;
        lblReportClassCountIcon.Text = "C";
        lblReportClassCountIcon.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblReportClassCountTrend
        // 
        lblReportClassCountTrend.AutoSize = true;
        lblReportClassCountTrend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblReportClassCountTrend.Location = new Point(30, 92);
        lblReportClassCountTrend.Name = "lblReportClassCountTrend";
        lblReportClassCountTrend.Size = new Size(58, 28);
        lblReportClassCountTrend.TabIndex = 3;
        lblReportClassCountTrend.Text = "0.0%";
        // 
        // lblReportClassCountValue
        // 
        lblReportClassCountValue.AutoSize = true;
        lblReportClassCountValue.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
        lblReportClassCountValue.Location = new Point(28, 48);
        lblReportClassCountValue.Name = "lblReportClassCountValue";
        lblReportClassCountValue.Size = new Size(105, 62);
        lblReportClassCountValue.TabIndex = 2;
        lblReportClassCountValue.Text = "156";
        // 
        // lblReportClassCountTitle
        // 
        lblReportClassCountTitle.AutoSize = true;
        lblReportClassCountTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblReportClassCountTitle.Location = new Point(28, 18);
        lblReportClassCountTitle.Name = "lblReportClassCountTitle";
        lblReportClassCountTitle.Size = new Size(188, 28);
        lblReportClassCountTitle.TabIndex = 1;
        lblReportClassCountTitle.Text = "SỐ LỚP ĐANG MỞ";
        // 
        // pnlReportClassCountAccent
        // 
        pnlReportClassCountAccent.AutoScroll = true;
        pnlReportClassCountAccent.Dock = DockStyle.Left;
        pnlReportClassCountAccent.Location = new Point(20, 18);
        pnlReportClassCountAccent.Name = "pnlReportClassCountAccent";
        pnlReportClassCountAccent.Size = new Size(4, 76);
        pnlReportClassCountAccent.TabIndex = 0;
        // 
        // pnlReportRetention
        // 
        pnlReportRetention.Controls.Add(lblReportRetentionIcon);
        pnlReportRetention.Controls.Add(lblReportRetentionTrend);
        pnlReportRetention.Controls.Add(lblReportRetentionValue);
        pnlReportRetention.Controls.Add(lblReportRetentionTitle);
        pnlReportRetention.Controls.Add(pnlReportRetentionAccent);
        pnlReportRetention.Dock = DockStyle.Fill;
        pnlReportRetention.Location = new Point(918, 0);
        pnlReportRetention.Margin = new Padding(0);
        pnlReportRetention.Name = "pnlReportRetention";
        pnlReportRetention.Padding = new Padding(20, 18, 20, 18);
        pnlReportRetention.Size = new Size(306, 112);
        pnlReportRetention.TabIndex = 3;
        // 
        // lblReportRetentionIcon
        // 
        lblReportRetentionIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblReportRetentionIcon.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblReportRetentionIcon.Location = new Point(224, 18);
        lblReportRetentionIcon.Name = "lblReportRetentionIcon";
        lblReportRetentionIcon.Size = new Size(34, 34);
        lblReportRetentionIcon.TabIndex = 4;
        lblReportRetentionIcon.Text = "%";
        lblReportRetentionIcon.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblReportRetentionTrend
        // 
        lblReportRetentionTrend.AutoSize = true;
        lblReportRetentionTrend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblReportRetentionTrend.Location = new Point(30, 92);
        lblReportRetentionTrend.Name = "lblReportRetentionTrend";
        lblReportRetentionTrend.Size = new Size(73, 28);
        lblReportRetentionTrend.TabIndex = 3;
        lblReportRetentionTrend.Text = "↑ 1.8%";
        // 
        // lblReportRetentionValue
        // 
        lblReportRetentionValue.AutoSize = true;
        lblReportRetentionValue.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
        lblReportRetentionValue.Location = new Point(28, 48);
        lblReportRetentionValue.Name = "lblReportRetentionValue";
        lblReportRetentionValue.Size = new Size(157, 62);
        lblReportRetentionValue.TabIndex = 2;
        lblReportRetentionValue.Text = "94.2%";
        // 
        // lblReportRetentionTitle
        // 
        lblReportRetentionTitle.AutoSize = true;
        lblReportRetentionTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblReportRetentionTitle.Location = new Point(28, 18);
        lblReportRetentionTitle.Name = "lblReportRetentionTitle";
        lblReportRetentionTitle.Size = new Size(147, 28);
        lblReportRetentionTitle.TabIndex = 1;
        lblReportRetentionTitle.Text = "TỶ LỆ DUY TRÌ";
        // 
        // pnlReportRetentionAccent
        // 
        pnlReportRetentionAccent.AutoScroll = true;
        pnlReportRetentionAccent.Dock = DockStyle.Left;
        pnlReportRetentionAccent.Location = new Point(20, 18);
        pnlReportRetentionAccent.Name = "pnlReportRetentionAccent";
        pnlReportRetentionAccent.Size = new Size(4, 76);
        pnlReportRetentionAccent.TabIndex = 0;
        // 
        // tblReportMiddle
        // 
        tblReportMiddle.ColumnCount = 2;
        tblReportMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.5F));
        tblReportMiddle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.5F));
        tblReportMiddle.Controls.Add(pnlReportChartCard, 0, 0);
        tblReportMiddle.Controls.Add(tblReportSideColumn, 1, 0);
        tblReportMiddle.Dock = DockStyle.Fill;
        tblReportMiddle.Location = new Point(0, 350);
        tblReportMiddle.Margin = new Padding(0, 0, 0, 18);
        tblReportMiddle.Name = "tblReportMiddle";
        tblReportMiddle.RowCount = 1;
        tblReportMiddle.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblReportMiddle.Size = new Size(1224, 86);
        tblReportMiddle.TabIndex = 3;
        // 
        // pnlReportChartCard
        // 
        pnlReportChartCard.AutoScroll = true;
        pnlReportChartCard.Controls.Add(chtAdminRevenue);
        pnlReportChartCard.Controls.Add(pnlReportChartHeader);
        pnlReportChartCard.Dock = DockStyle.Fill;
        pnlReportChartCard.Location = new Point(0, 0);
        pnlReportChartCard.Margin = new Padding(0, 0, 24, 0);
        pnlReportChartCard.Name = "pnlReportChartCard";
        pnlReportChartCard.Padding = new Padding(24, 20, 24, 20);
        pnlReportChartCard.Size = new Size(802, 86);
        pnlReportChartCard.TabIndex = 0;
        // 
        // chtAdminRevenue
        // 
        chartArea1.Name = "DefaultArea";
        chtAdminRevenue.ChartAreas.Add(chartArea1);
        chtAdminRevenue.Dock = DockStyle.Fill;
        legend1.Name = "DefaultLegend";
        chtAdminRevenue.Legends.Add(legend1);
        chtAdminRevenue.Location = new Point(24, 74);
        chtAdminRevenue.Name = "chtAdminRevenue";
        chtAdminRevenue.Size = new Size(754, 0);
        chtAdminRevenue.TabIndex = 1;
        // 
        // pnlReportChartHeader
        // 
        pnlReportChartHeader.Controls.Add(flpChartLegend);
        pnlReportChartHeader.Controls.Add(lblReportChartTitle);
        pnlReportChartHeader.Dock = DockStyle.Top;
        pnlReportChartHeader.Location = new Point(24, 20);
        pnlReportChartHeader.Name = "pnlReportChartHeader";
        pnlReportChartHeader.Size = new Size(754, 54);
        pnlReportChartHeader.TabIndex = 0;
        // 
        // flpChartLegend
        // 
        flpChartLegend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        flpChartLegend.AutoSize = true;
        flpChartLegend.Controls.Add(pnlChartLegendRevenue);
        flpChartLegend.Controls.Add(lblChartLegendRevenue);
        flpChartLegend.Controls.Add(pnlChartLegendTarget);
        flpChartLegend.Controls.Add(lblChartLegendTarget);
        flpChartLegend.Location = new Point(452, 12);
        flpChartLegend.Margin = new Padding(0);
        flpChartLegend.Name = "flpChartLegend";
        flpChartLegend.Size = new Size(302, 28);
        flpChartLegend.TabIndex = 1;
        flpChartLegend.WrapContents = false;
        // 
        // pnlChartLegendRevenue
        // 
        pnlChartLegendRevenue.AutoScroll = true;
        pnlChartLegendRevenue.Location = new Point(0, 6);
        pnlChartLegendRevenue.Margin = new Padding(0, 6, 8, 0);
        pnlChartLegendRevenue.Name = "pnlChartLegendRevenue";
        pnlChartLegendRevenue.Size = new Size(14, 14);
        pnlChartLegendRevenue.TabIndex = 0;
        // 
        // lblChartLegendRevenue
        // 
        lblChartLegendRevenue.AutoSize = true;
        lblChartLegendRevenue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblChartLegendRevenue.Location = new Point(22, 0);
        lblChartLegendRevenue.Margin = new Padding(0, 0, 18, 0);
        lblChartLegendRevenue.Name = "lblChartLegendRevenue";
        lblChartLegendRevenue.Size = new Size(134, 28);
        lblChartLegendRevenue.TabIndex = 1;
        lblChartLegendRevenue.Text = "DOANH THU";
        // 
        // pnlChartLegendTarget
        // 
        pnlChartLegendTarget.AutoScroll = true;
        pnlChartLegendTarget.Location = new Point(174, 6);
        pnlChartLegendTarget.Margin = new Padding(0, 6, 8, 0);
        pnlChartLegendTarget.Name = "pnlChartLegendTarget";
        pnlChartLegendTarget.Size = new Size(14, 14);
        pnlChartLegendTarget.TabIndex = 2;
        // 
        // lblChartLegendTarget
        // 
        lblChartLegendTarget.AutoSize = true;
        lblChartLegendTarget.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblChartLegendTarget.Location = new Point(196, 0);
        lblChartLegendTarget.Margin = new Padding(0);
        lblChartLegendTarget.Name = "lblChartLegendTarget";
        lblChartLegendTarget.Size = new Size(106, 28);
        lblChartLegendTarget.TabIndex = 3;
        lblChartLegendTarget.Text = "MỤC TIÊU";
        // 
        // lblReportChartTitle
        // 
        lblReportChartTitle.AutoSize = true;
        lblReportChartTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblReportChartTitle.Location = new Point(0, 6);
        lblReportChartTitle.Margin = new Padding(0);
        lblReportChartTitle.Name = "lblReportChartTitle";
        lblReportChartTitle.Size = new Size(631, 45);
        lblReportChartTitle.TabIndex = 0;
        lblReportChartTitle.Text = "XU HƯỚNG DOANH THU HÀNG THÁNG";
        // 
        // tblReportSideColumn
        // 
        tblReportSideColumn.ColumnCount = 1;
        tblReportSideColumn.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblReportSideColumn.Controls.Add(pnlReportHighlightCard, 0, 0);
        tblReportSideColumn.Controls.Add(pnlReportDistributionCard, 0, 1);
        tblReportSideColumn.Dock = DockStyle.Fill;
        tblReportSideColumn.Location = new Point(826, 0);
        tblReportSideColumn.Margin = new Padding(0);
        tblReportSideColumn.Name = "tblReportSideColumn";
        tblReportSideColumn.RowCount = 2;
        tblReportSideColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 63F));
        tblReportSideColumn.RowStyles.Add(new RowStyle(SizeType.Percent, 37F));
        tblReportSideColumn.Size = new Size(398, 86);
        tblReportSideColumn.TabIndex = 1;
        // 
        // pnlReportHighlightCard
        // 
        pnlReportHighlightCard.AutoScroll = true;
        pnlReportHighlightCard.Controls.Add(pnlReportHighlightTrack);
        pnlReportHighlightCard.Controls.Add(lblReportHighlightBody);
        pnlReportHighlightCard.Controls.Add(lblReportHighlightTitle);
        pnlReportHighlightCard.Controls.Add(lblReportHighlightIcon);
        pnlReportHighlightCard.Dock = DockStyle.Fill;
        pnlReportHighlightCard.Location = new Point(0, 0);
        pnlReportHighlightCard.Margin = new Padding(0, 0, 0, 22);
        pnlReportHighlightCard.Name = "pnlReportHighlightCard";
        pnlReportHighlightCard.Padding = new Padding(28, 24, 28, 26);
        pnlReportHighlightCard.Size = new Size(398, 32);
        pnlReportHighlightCard.TabIndex = 0;
        // 
        // pnlReportHighlightTrack
        // 
        pnlReportHighlightTrack.AutoScroll = true;
        pnlReportHighlightTrack.Controls.Add(pnlReportHighlightFill);
        pnlReportHighlightTrack.Location = new Point(30, 171);
        pnlReportHighlightTrack.Name = "pnlReportHighlightTrack";
        pnlReportHighlightTrack.Size = new Size(338, 8);
        pnlReportHighlightTrack.TabIndex = 3;
        // 
        // pnlReportHighlightFill
        // 
        pnlReportHighlightFill.AutoScroll = true;
        pnlReportHighlightFill.Dock = DockStyle.Left;
        pnlReportHighlightFill.Location = new Point(0, 0);
        pnlReportHighlightFill.Name = "pnlReportHighlightFill";
        pnlReportHighlightFill.Size = new Size(236, 8);
        pnlReportHighlightFill.TabIndex = 0;
        // 
        // lblReportHighlightBody
        // 
        lblReportHighlightBody.AutoSize = true;
        lblReportHighlightBody.Font = new Font("Segoe UI", 12F);
        lblReportHighlightBody.Location = new Point(30, 98);
        lblReportHighlightBody.MaximumSize = new Size(320, 0);
        lblReportHighlightBody.Name = "lblReportHighlightBody";
        lblReportHighlightBody.Size = new Size(308, 96);
        lblReportHighlightBody.TabIndex = 2;
        lblReportHighlightBody.Text = "Chiến dịch tuyển sinh mùa hè đạt hiệu quả cao nhất trong 3 năm qua.";
        // 
        // lblReportHighlightTitle
        // 
        lblReportHighlightTitle.AutoSize = true;
        lblReportHighlightTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblReportHighlightTitle.Location = new Point(28, 54);
        lblReportHighlightTitle.MaximumSize = new Size(320, 0);
        lblReportHighlightTitle.Name = "lblReportHighlightTitle";
        lblReportHighlightTitle.Size = new Size(287, 96);
        lblReportHighlightTitle.TabIndex = 1;
        lblReportHighlightTitle.Text = "Phát triển vượt mức 15%";
        // 
        // lblReportHighlightIcon
        // 
        lblReportHighlightIcon.AutoSize = true;
        lblReportHighlightIcon.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
        lblReportHighlightIcon.Location = new Point(28, 6);
        lblReportHighlightIcon.Name = "lblReportHighlightIcon";
        lblReportHighlightIcon.Size = new Size(54, 70);
        lblReportHighlightIcon.TabIndex = 0;
        lblReportHighlightIcon.Text = "*";
        // 
        // pnlReportDistributionCard
        // 
        pnlReportDistributionCard.AutoScroll = true;
        pnlReportDistributionCard.Controls.Add(tblReportDistribution);
        pnlReportDistributionCard.Controls.Add(lblReportDistributionTitle);
        pnlReportDistributionCard.Dock = DockStyle.Fill;
        pnlReportDistributionCard.Location = new Point(0, 54);
        pnlReportDistributionCard.Margin = new Padding(0);
        pnlReportDistributionCard.Name = "pnlReportDistributionCard";
        pnlReportDistributionCard.Padding = new Padding(28, 24, 28, 24);
        pnlReportDistributionCard.Size = new Size(398, 32);
        pnlReportDistributionCard.TabIndex = 1;
        // 
        // tblReportDistribution
        // 
        tblReportDistribution.ColumnCount = 2;
        tblReportDistribution.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblReportDistribution.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
        tblReportDistribution.Controls.Add(lblDistributionCourse1Name, 0, 0);
        tblReportDistribution.Controls.Add(lblDistributionCourse1Value, 1, 0);
        tblReportDistribution.Controls.Add(lblDistributionCourse2Name, 0, 1);
        tblReportDistribution.Controls.Add(lblDistributionCourse2Value, 1, 1);
        tblReportDistribution.Controls.Add(lblDistributionCourse3Name, 0, 2);
        tblReportDistribution.Controls.Add(lblDistributionCourse3Value, 1, 2);
        tblReportDistribution.Dock = DockStyle.Bottom;
        tblReportDistribution.Location = new Point(28, 30);
        tblReportDistribution.Name = "tblReportDistribution";
        tblReportDistribution.RowCount = 3;
        tblReportDistribution.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
        tblReportDistribution.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
        tblReportDistribution.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
        tblReportDistribution.Size = new Size(316, 66);
        tblReportDistribution.TabIndex = 1;
        // 
        // lblDistributionCourse1Name
        // 
        lblDistributionCourse1Name.AutoSize = true;
        lblDistributionCourse1Name.Dock = DockStyle.Fill;
        lblDistributionCourse1Name.Font = new Font("Segoe UI", 11F);
        lblDistributionCourse1Name.Location = new Point(0, 0);
        lblDistributionCourse1Name.Margin = new Padding(0);
        lblDistributionCourse1Name.Name = "lblDistributionCourse1Name";
        lblDistributionCourse1Name.Size = new Size(246, 22);
        lblDistributionCourse1Name.TabIndex = 0;
        lblDistributionCourse1Name.Text = "IELTS Foundation";
        lblDistributionCourse1Name.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblDistributionCourse1Value
        // 
        lblDistributionCourse1Value.AutoSize = true;
        lblDistributionCourse1Value.Dock = DockStyle.Fill;
        lblDistributionCourse1Value.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblDistributionCourse1Value.Location = new Point(246, 0);
        lblDistributionCourse1Value.Margin = new Padding(0);
        lblDistributionCourse1Value.Name = "lblDistributionCourse1Value";
        lblDistributionCourse1Value.Size = new Size(70, 22);
        lblDistributionCourse1Value.TabIndex = 1;
        lblDistributionCourse1Value.Text = "42%";
        lblDistributionCourse1Value.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblDistributionCourse2Name
        // 
        lblDistributionCourse2Name.AutoSize = true;
        lblDistributionCourse2Name.Dock = DockStyle.Fill;
        lblDistributionCourse2Name.Font = new Font("Segoe UI", 11F);
        lblDistributionCourse2Name.Location = new Point(0, 22);
        lblDistributionCourse2Name.Margin = new Padding(0);
        lblDistributionCourse2Name.Name = "lblDistributionCourse2Name";
        lblDistributionCourse2Name.Size = new Size(246, 22);
        lblDistributionCourse2Name.TabIndex = 2;
        lblDistributionCourse2Name.Text = "Business English";
        lblDistributionCourse2Name.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblDistributionCourse2Value
        // 
        lblDistributionCourse2Value.AutoSize = true;
        lblDistributionCourse2Value.Dock = DockStyle.Fill;
        lblDistributionCourse2Value.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblDistributionCourse2Value.Location = new Point(246, 22);
        lblDistributionCourse2Value.Margin = new Padding(0);
        lblDistributionCourse2Value.Name = "lblDistributionCourse2Value";
        lblDistributionCourse2Value.Size = new Size(70, 22);
        lblDistributionCourse2Value.TabIndex = 3;
        lblDistributionCourse2Value.Text = "28%";
        lblDistributionCourse2Value.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblDistributionCourse3Name
        // 
        lblDistributionCourse3Name.AutoSize = true;
        lblDistributionCourse3Name.Dock = DockStyle.Fill;
        lblDistributionCourse3Name.Font = new Font("Segoe UI", 11F);
        lblDistributionCourse3Name.Location = new Point(0, 44);
        lblDistributionCourse3Name.Margin = new Padding(0);
        lblDistributionCourse3Name.Name = "lblDistributionCourse3Name";
        lblDistributionCourse3Name.Size = new Size(246, 22);
        lblDistributionCourse3Name.TabIndex = 4;
        lblDistributionCourse3Name.Text = "Kid's Phonics";
        lblDistributionCourse3Name.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblDistributionCourse3Value
        // 
        lblDistributionCourse3Value.AutoSize = true;
        lblDistributionCourse3Value.Dock = DockStyle.Fill;
        lblDistributionCourse3Value.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblDistributionCourse3Value.Location = new Point(246, 44);
        lblDistributionCourse3Value.Margin = new Padding(0);
        lblDistributionCourse3Value.Name = "lblDistributionCourse3Value";
        lblDistributionCourse3Value.Size = new Size(70, 22);
        lblDistributionCourse3Value.TabIndex = 5;
        lblDistributionCourse3Value.Text = "30%";
        lblDistributionCourse3Value.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblReportDistributionTitle
        // 
        lblReportDistributionTitle.AutoSize = true;
        lblReportDistributionTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblReportDistributionTitle.Location = new Point(28, 24);
        lblReportDistributionTitle.Name = "lblReportDistributionTitle";
        lblReportDistributionTitle.Size = new Size(236, 30);
        lblReportDistributionTitle.TabIndex = 0;
        lblReportDistributionTitle.Text = "PHÂN BỔ KHÓA HỌC";
        // 
        // pnlReportDetailCard
        // 
        pnlReportDetailCard.AutoScroll = true;
        pnlReportDetailCard.Controls.Add(dgvAdminReportDetail);
        pnlReportDetailCard.Controls.Add(pnlReportDetailHeader);
        pnlReportDetailCard.Dock = DockStyle.Fill;
        pnlReportDetailCard.Location = new Point(0, 454);
        pnlReportDetailCard.Margin = new Padding(0);
        pnlReportDetailCard.Name = "pnlReportDetailCard";
        pnlReportDetailCard.Size = new Size(1224, 350);
        pnlReportDetailCard.TabIndex = 4;
        // 
        // dgvAdminReportDetail
        // 
        dgvAdminReportDetail.AllowUserToAddRows = false;
        dgvAdminReportDetail.AllowUserToDeleteRows = false;
        dgvAdminReportDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvAdminReportDetail.BackgroundColor = Color.White;
        dgvAdminReportDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvAdminReportDetail.Dock = DockStyle.Fill;
        dgvAdminReportDetail.Location = new Point(0, 66);
        dgvAdminReportDetail.MultiSelect = false;
        dgvAdminReportDetail.Name = "dgvAdminReportDetail";
        dgvAdminReportDetail.ReadOnly = true;
        dgvAdminReportDetail.RowHeadersVisible = false;
        dgvAdminReportDetail.RowHeadersWidth = 62;
        dgvAdminReportDetail.RowTemplate.Height = 36;
        dgvAdminReportDetail.ScrollBars = ScrollBars.Vertical;
        dgvAdminReportDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAdminReportDetail.Size = new Size(1224, 284);
        dgvAdminReportDetail.TabIndex = 1;
        // 
        // pnlReportDetailHeader
        // 
        pnlReportDetailHeader.Controls.Add(flpReportDetailNavigation);
        pnlReportDetailHeader.Controls.Add(lblReportDetailPaging);
        pnlReportDetailHeader.Controls.Add(lblReportDetailTitle);
        pnlReportDetailHeader.Dock = DockStyle.Top;
        pnlReportDetailHeader.Location = new Point(0, 0);
        pnlReportDetailHeader.Name = "pnlReportDetailHeader";
        pnlReportDetailHeader.Padding = new Padding(24, 18, 24, 18);
        pnlReportDetailHeader.Size = new Size(1224, 66);
        pnlReportDetailHeader.TabIndex = 0;
        // 
        // flpReportDetailNavigation
        // 
        flpReportDetailNavigation.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        flpReportDetailNavigation.Controls.Add(btnReportPrevPage);
        flpReportDetailNavigation.Controls.Add(btnReportNextPage);
        flpReportDetailNavigation.Location = new Point(1138, 15);
        flpReportDetailNavigation.Margin = new Padding(0);
        flpReportDetailNavigation.Name = "flpReportDetailNavigation";
        flpReportDetailNavigation.Size = new Size(62, 36);
        flpReportDetailNavigation.TabIndex = 2;
        flpReportDetailNavigation.WrapContents = false;
        // 
        // btnReportPrevPage
        // 
        btnReportPrevPage.FlatStyle = FlatStyle.Flat;
        btnReportPrevPage.Location = new Point(0, 0);
        btnReportPrevPage.Margin = new Padding(0);
        btnReportPrevPage.Name = "btnReportPrevPage";
        btnReportPrevPage.Size = new Size(30, 36);
        btnReportPrevPage.TabIndex = 0;
        btnReportPrevPage.Text = "<";
        btnReportPrevPage.UseVisualStyleBackColor = true;
        // 
        // btnReportNextPage
        // 
        btnReportNextPage.FlatStyle = FlatStyle.Flat;
        btnReportNextPage.Location = new Point(32, 0);
        btnReportNextPage.Margin = new Padding(2, 0, 0, 0);
        btnReportNextPage.Name = "btnReportNextPage";
        btnReportNextPage.Size = new Size(30, 36);
        btnReportNextPage.TabIndex = 1;
        btnReportNextPage.Text = ">";
        btnReportNextPage.UseVisualStyleBackColor = true;
        // 
        // lblReportDetailPaging
        // 
        lblReportDetailPaging.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblReportDetailPaging.AutoSize = true;
        lblReportDetailPaging.Font = new Font("Segoe UI", 10F);
        lblReportDetailPaging.Location = new Point(986, 24);
        lblReportDetailPaging.Name = "lblReportDetailPaging";
        lblReportDetailPaging.Size = new Size(228, 28);
        lblReportDetailPaging.TabIndex = 1;
        lblReportDetailPaging.Text = "Hiển thị 10 / 125 kết quả";
        // 
        // lblReportDetailTitle
        // 
        lblReportDetailTitle.AutoSize = true;
        lblReportDetailTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblReportDetailTitle.Location = new Point(24, 20);
        lblReportDetailTitle.Name = "lblReportDetailTitle";
        lblReportDetailTitle.Size = new Size(467, 41);
        lblReportDetailTitle.TabIndex = 0;
        lblReportDetailTitle.Text = "CHI TIẾT PHÁT SINH TRONG KỲ";
        // 
        // FrmAdminReports
        // 
        AutoScaleDimensions = new SizeF(144F, 144F);
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoScroll = true;
        BackColor = Color.FromArgb(239, 247, 255);
        ClientSize = new Size(1260, 840);
        Controls.Add(tblAdminReportRoot);
        Font = new Font("Segoe UI", 10F);
        MinimumSize = new Size(1180, 760);
        Name = "FrmAdminReports";
        Padding = new Padding(18);
        Text = "Báo cáo thống kê";
        tblAdminReportRoot.ResumeLayout(false);
        pnlAdminReportHeader.ResumeLayout(false);
        tblAdminReportHeaderLayout.ResumeLayout(false);
        pnlAdminReportTitleBlock.ResumeLayout(false);
        pnlAdminReportTitleBlock.PerformLayout();
        flpAdminReportMeta.ResumeLayout(false);
        flpAdminReportMeta.PerformLayout();
        flpAdminReportHeaderActions.ResumeLayout(false);
        pnlAdminReportFilterCard.ResumeLayout(false);
        tblAdminReportFilter.ResumeLayout(false);
        tblAdminReportFilter.PerformLayout();
        tblReportKpi.ResumeLayout(false);
        pnlReportRevenue.ResumeLayout(false);
        pnlReportRevenue.PerformLayout();
        pnlReportEnrollment.ResumeLayout(false);
        pnlReportEnrollment.PerformLayout();
        pnlReportClassCount.ResumeLayout(false);
        pnlReportClassCount.PerformLayout();
        pnlReportRetention.ResumeLayout(false);
        pnlReportRetention.PerformLayout();
        tblReportMiddle.ResumeLayout(false);
        pnlReportChartCard.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)chtAdminRevenue).EndInit();
        pnlReportChartHeader.ResumeLayout(false);
        pnlReportChartHeader.PerformLayout();
        flpChartLegend.ResumeLayout(false);
        flpChartLegend.PerformLayout();
        tblReportSideColumn.ResumeLayout(false);
        pnlReportHighlightCard.ResumeLayout(false);
        pnlReportHighlightCard.PerformLayout();
        pnlReportHighlightTrack.ResumeLayout(false);
        pnlReportDistributionCard.ResumeLayout(false);
        pnlReportDistributionCard.PerformLayout();
        tblReportDistribution.ResumeLayout(false);
        tblReportDistribution.PerformLayout();
        pnlReportDetailCard.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvAdminReportDetail).EndInit();
        pnlReportDetailHeader.ResumeLayout(false);
        pnlReportDetailHeader.PerformLayout();
        flpReportDetailNavigation.ResumeLayout(false);
        ResumeLayout(false);
    }
}

