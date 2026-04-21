using System.Windows.Forms.DataVisualization.Charting;

namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmAdminReports
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tblAdminReportRoot;
    private Panel pnlAdminReportHeader;
    private Label lblAdminReportTitle;
    private Label lblAdminReportSubtitle;
    private Panel pnlAdminReportFilterCard;
    private TableLayoutPanel tblAdminReportFilter;
    private Label lblReportType;
    private Label lblReportFromDate;
    private Label lblReportToDate;
    private ComboBox cboReportType;
    private DateTimePicker dtpReportFromDate;
    private DateTimePicker dtpReportToDate;
    private FlowLayoutPanel flpReportActions;
    private Button btnViewReport;
    private Button btnExportReportExcel;
    private Button btnExportReportPdf;
    private TableLayoutPanel tblReportKpi;
    private Panel pnlReportRevenue;
    private Label lblReportRevenueTitle;
    private Label lblReportRevenueValue;
    private Label lblReportRevenueNote;
    private Panel pnlReportEnrollment;
    private Label lblReportEnrollmentTitle;
    private Label lblReportEnrollmentValue;
    private Label lblReportEnrollmentNote;
    private Panel pnlReportClassCount;
    private Label lblReportClassCountTitle;
    private Label lblReportClassCountValue;
    private Label lblReportClassCountNote;
    private SplitContainer splAdminReportContent;
    private Panel pnlReportChartCard;
    private Label lblReportChartTitle;
    private Chart chtAdminRevenue;
    private Panel pnlReportDetailCard;
    private Label lblReportDetailTitle;
    private DataGridView dgvAdminReportDetail;
    private Panel pnlReportFooter;
    private Label lblReportFooterHint;

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
        components = new System.ComponentModel.Container();
        tblAdminReportRoot = new TableLayoutPanel();
        pnlAdminReportHeader = new Panel();
        lblAdminReportTitle = new Label();
        lblAdminReportSubtitle = new Label();
        pnlAdminReportFilterCard = new Panel();
        tblAdminReportFilter = new TableLayoutPanel();
        lblReportType = new Label();
        lblReportFromDate = new Label();
        lblReportToDate = new Label();
        cboReportType = new ComboBox();
        dtpReportFromDate = new DateTimePicker();
        dtpReportToDate = new DateTimePicker();
        flpReportActions = new FlowLayoutPanel();
        btnViewReport = new Button();
        btnExportReportExcel = new Button();
        btnExportReportPdf = new Button();
        tblReportKpi = new TableLayoutPanel();
        pnlReportRevenue = new Panel();
        lblReportRevenueTitle = new Label();
        lblReportRevenueValue = new Label();
        lblReportRevenueNote = new Label();
        pnlReportEnrollment = new Panel();
        lblReportEnrollmentTitle = new Label();
        lblReportEnrollmentValue = new Label();
        lblReportEnrollmentNote = new Label();
        pnlReportClassCount = new Panel();
        lblReportClassCountTitle = new Label();
        lblReportClassCountValue = new Label();
        lblReportClassCountNote = new Label();
        splAdminReportContent = new SplitContainer();
        pnlReportChartCard = new Panel();
        lblReportChartTitle = new Label();
        chtAdminRevenue = new Chart();
        pnlReportDetailCard = new Panel();
        lblReportDetailTitle = new Label();
        dgvAdminReportDetail = new DataGridView();
        pnlReportFooter = new Panel();
        lblReportFooterHint = new Label();
        ((System.ComponentModel.ISupportInitialize)splAdminReportContent).BeginInit();
        splAdminReportContent.Panel1.SuspendLayout();
        splAdminReportContent.Panel2.SuspendLayout();
        splAdminReportContent.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)chtAdminRevenue).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvAdminReportDetail).BeginInit();
        tblAdminReportRoot.SuspendLayout();
        pnlAdminReportHeader.SuspendLayout();
        pnlAdminReportFilterCard.SuspendLayout();
        tblAdminReportFilter.SuspendLayout();
        flpReportActions.SuspendLayout();
        tblReportKpi.SuspendLayout();
        pnlReportRevenue.SuspendLayout();
        pnlReportEnrollment.SuspendLayout();
        pnlReportClassCount.SuspendLayout();
        pnlReportChartCard.SuspendLayout();
        pnlReportDetailCard.SuspendLayout();
        pnlReportFooter.SuspendLayout();
        SuspendLayout();
        // 
        // tblAdminReportRoot
        // 
        tblAdminReportRoot.ColumnCount = 1;
        tblAdminReportRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblAdminReportRoot.Controls.Add(pnlAdminReportHeader, 0, 0);
        tblAdminReportRoot.Controls.Add(pnlAdminReportFilterCard, 0, 1);
        tblAdminReportRoot.Controls.Add(tblReportKpi, 0, 2);
        tblAdminReportRoot.Controls.Add(splAdminReportContent, 0, 3);
        tblAdminReportRoot.Controls.Add(pnlReportFooter, 0, 4);
        tblAdminReportRoot.Dock = DockStyle.Fill;
        tblAdminReportRoot.Location = new Point(20, 20);
        tblAdminReportRoot.Margin = new Padding(0);
        tblAdminReportRoot.Name = "tblAdminReportRoot";
        tblAdminReportRoot.RowCount = 5;
        tblAdminReportRoot.RowStyles.Add(new RowStyle());
        tblAdminReportRoot.RowStyles.Add(new RowStyle());
        tblAdminReportRoot.RowStyles.Add(new RowStyle());
        tblAdminReportRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblAdminReportRoot.RowStyles.Add(new RowStyle());
        tblAdminReportRoot.Size = new Size(1160, 710);
        tblAdminReportRoot.TabIndex = 0;
        // 
        // pnlAdminReportHeader
        // 
        pnlAdminReportHeader.BackColor = Color.White;
        pnlAdminReportHeader.BorderStyle = BorderStyle.FixedSingle;
        pnlAdminReportHeader.Controls.Add(lblAdminReportSubtitle);
        pnlAdminReportHeader.Controls.Add(lblAdminReportTitle);
        pnlAdminReportHeader.Dock = DockStyle.Fill;
        pnlAdminReportHeader.Margin = new Padding(0, 0, 0, 16);
        pnlAdminReportHeader.Name = "pnlAdminReportHeader";
        pnlAdminReportHeader.Padding = new Padding(24, 18, 24, 16);
        pnlAdminReportHeader.Size = new Size(1160, 84);
        pnlAdminReportHeader.TabIndex = 0;
        // 
        // lblAdminReportTitle
        // 
        lblAdminReportTitle.AutoSize = true;
        lblAdminReportTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
        lblAdminReportTitle.ForeColor = Color.FromArgb(7, 30, 39);
        lblAdminReportTitle.Location = new Point(22, 14);
        lblAdminReportTitle.Name = "lblAdminReportTitle";
        lblAdminReportTitle.Size = new Size(285, 37);
        lblAdminReportTitle.TabIndex = 0;
        lblAdminReportTitle.Text = "Báo cáo thống kê";
        // 
        // lblAdminReportSubtitle
        // 
        lblAdminReportSubtitle.AutoSize = true;
        lblAdminReportSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lblAdminReportSubtitle.ForeColor = Color.FromArgb(102, 112, 133);
        lblAdminReportSubtitle.Location = new Point(24, 52);
        lblAdminReportSubtitle.Name = "lblAdminReportSubtitle";
        lblAdminReportSubtitle.Size = new Size(468, 19);
        lblAdminReportSubtitle.TabIndex = 1;
        lblAdminReportSubtitle.Text = "Theo dõi doanh thu, ghi danh và công nợ theo kỳ để hỗ trợ quyết định quản trị.";
        // 
        // pnlAdminReportFilterCard
        // 
        pnlAdminReportFilterCard.BackColor = Color.White;
        pnlAdminReportFilterCard.BorderStyle = BorderStyle.FixedSingle;
        pnlAdminReportFilterCard.Controls.Add(tblAdminReportFilter);
        pnlAdminReportFilterCard.Dock = DockStyle.Fill;
        pnlAdminReportFilterCard.Margin = new Padding(0, 0, 0, 16);
        pnlAdminReportFilterCard.Name = "pnlAdminReportFilterCard";
        pnlAdminReportFilterCard.Padding = new Padding(20, 18, 20, 18);
        pnlAdminReportFilterCard.Size = new Size(1160, 92);
        pnlAdminReportFilterCard.TabIndex = 1;
        // 
        // tblAdminReportFilter
        // 
        tblAdminReportFilter.ColumnCount = 4;
        tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23F));
        tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21F));
        tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21F));
        tblAdminReportFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        tblAdminReportFilter.Controls.Add(lblReportType, 0, 0);
        tblAdminReportFilter.Controls.Add(lblReportFromDate, 1, 0);
        tblAdminReportFilter.Controls.Add(lblReportToDate, 2, 0);
        tblAdminReportFilter.Controls.Add(cboReportType, 0, 1);
        tblAdminReportFilter.Controls.Add(dtpReportFromDate, 1, 1);
        tblAdminReportFilter.Controls.Add(dtpReportToDate, 2, 1);
        tblAdminReportFilter.Controls.Add(flpReportActions, 3, 1);
        tblAdminReportFilter.Dock = DockStyle.Fill;
        tblAdminReportFilter.Location = new Point(20, 18);
        tblAdminReportFilter.Margin = new Padding(0);
        tblAdminReportFilter.Name = "tblAdminReportFilter";
        tblAdminReportFilter.RowCount = 2;
        tblAdminReportFilter.RowStyles.Add(new RowStyle());
        tblAdminReportFilter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblAdminReportFilter.Size = new Size(1118, 54);
        tblAdminReportFilter.TabIndex = 0;
        // 
        // lblReportType
        // 
        lblReportType.AutoSize = true;
        lblReportType.Dock = DockStyle.Fill;
        lblReportType.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        lblReportType.ForeColor = Color.FromArgb(42, 51, 64);
        lblReportType.Location = new Point(0, 0);
        lblReportType.Margin = new Padding(0, 0, 0, 8);
        lblReportType.Name = "lblReportType";
        lblReportType.Size = new Size(257, 25);
        lblReportType.TabIndex = 0;
        lblReportType.Text = "Loại báo cáo";
        // 
        // lblReportFromDate
        // 
        lblReportFromDate.AutoSize = true;
        lblReportFromDate.Dock = DockStyle.Fill;
        lblReportFromDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        lblReportFromDate.ForeColor = Color.FromArgb(42, 51, 64);
        lblReportFromDate.Location = new Point(257, 0);
        lblReportFromDate.Margin = new Padding(0, 0, 0, 8);
        lblReportFromDate.Name = "lblReportFromDate";
        lblReportFromDate.Size = new Size(234, 25);
        lblReportFromDate.TabIndex = 1;
        lblReportFromDate.Text = "Từ ngày";
        // 
        // lblReportToDate
        // 
        lblReportToDate.AutoSize = true;
        lblReportToDate.Dock = DockStyle.Fill;
        lblReportToDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        lblReportToDate.ForeColor = Color.FromArgb(42, 51, 64);
        lblReportToDate.Location = new Point(491, 0);
        lblReportToDate.Margin = new Padding(0, 0, 0, 8);
        lblReportToDate.Name = "lblReportToDate";
        lblReportToDate.Size = new Size(234, 25);
        lblReportToDate.TabIndex = 2;
        lblReportToDate.Text = "Đến ngày";
        // 
        // cboReportType
        // 
        cboReportType.Dock = DockStyle.Fill;
        cboReportType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboReportType.FormattingEnabled = true;
        cboReportType.Items.AddRange(new object[] { "Doanh thu", "Ghi danh", "Công nợ" });
        cboReportType.Margin = new Padding(0, 0, 12, 0);
        cboReportType.Name = "cboReportType";
        cboReportType.Size = new Size(245, 23);
        cboReportType.TabIndex = 3;
        // 
        // dtpReportFromDate
        // 
        dtpReportFromDate.Dock = DockStyle.Fill;
        dtpReportFromDate.Format = DateTimePickerFormat.Short;
        dtpReportFromDate.Margin = new Padding(0, 0, 12, 0);
        dtpReportFromDate.Name = "dtpReportFromDate";
        dtpReportFromDate.Size = new Size(222, 23);
        dtpReportFromDate.TabIndex = 4;
        // 
        // dtpReportToDate
        // 
        dtpReportToDate.Dock = DockStyle.Fill;
        dtpReportToDate.Format = DateTimePickerFormat.Short;
        dtpReportToDate.Margin = new Padding(0, 0, 12, 0);
        dtpReportToDate.Name = "dtpReportToDate";
        dtpReportToDate.Size = new Size(222, 23);
        dtpReportToDate.TabIndex = 5;
        // 
        // flpReportActions
        // 
        flpReportActions.Controls.Add(btnViewReport);
        flpReportActions.Controls.Add(btnExportReportExcel);
        flpReportActions.Controls.Add(btnExportReportPdf);
        flpReportActions.Dock = DockStyle.Fill;
        flpReportActions.FlowDirection = FlowDirection.LeftToRight;
        flpReportActions.Location = new Point(725, 25);
        flpReportActions.Margin = new Padding(0);
        flpReportActions.Name = "flpReportActions";
        flpReportActions.Size = new Size(393, 29);
        flpReportActions.TabIndex = 6;
        flpReportActions.WrapContents = false;
        // 
        // btnViewReport
        // 
        btnViewReport.BackColor = Color.FromArgb(0, 110, 110);
        btnViewReport.FlatStyle = FlatStyle.Flat;
        btnViewReport.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        btnViewReport.ForeColor = Color.White;
        btnViewReport.Location = new Point(0, 0);
        btnViewReport.Margin = new Padding(0, 0, 10, 0);
        btnViewReport.Name = "btnViewReport";
        btnViewReport.Size = new Size(110, 32);
        btnViewReport.TabIndex = 0;
        btnViewReport.Text = "Xem báo cáo";
        btnViewReport.UseVisualStyleBackColor = false;
        // 
        // btnExportReportExcel
        // 
        btnExportReportExcel.FlatStyle = FlatStyle.Flat;
        btnExportReportExcel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        btnExportReportExcel.ForeColor = Color.FromArgb(0, 110, 110);
        btnExportReportExcel.Location = new Point(120, 0);
        btnExportReportExcel.Margin = new Padding(0, 0, 10, 0);
        btnExportReportExcel.Name = "btnExportReportExcel";
        btnExportReportExcel.Size = new Size(110, 32);
        btnExportReportExcel.TabIndex = 1;
        btnExportReportExcel.Text = "Xuất Excel";
        btnExportReportExcel.UseVisualStyleBackColor = true;
        // 
        // btnExportReportPdf
        // 
        btnExportReportPdf.FlatStyle = FlatStyle.Flat;
        btnExportReportPdf.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        btnExportReportPdf.ForeColor = Color.FromArgb(0, 110, 110);
        btnExportReportPdf.Location = new Point(240, 0);
        btnExportReportPdf.Margin = new Padding(0);
        btnExportReportPdf.Name = "btnExportReportPdf";
        btnExportReportPdf.Size = new Size(110, 32);
        btnExportReportPdf.TabIndex = 2;
        btnExportReportPdf.Text = "Xuất PDF";
        btnExportReportPdf.UseVisualStyleBackColor = true;
        // 
        // tblReportKpi
        // 
        tblReportKpi.ColumnCount = 3;
        tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tblReportKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tblReportKpi.Controls.Add(pnlReportRevenue, 0, 0);
        tblReportKpi.Controls.Add(pnlReportEnrollment, 1, 0);
        tblReportKpi.Controls.Add(pnlReportClassCount, 2, 0);
        tblReportKpi.Dock = DockStyle.Fill;
        tblReportKpi.Location = new Point(0, 192);
        tblReportKpi.Margin = new Padding(0, 0, 0, 16);
        tblReportKpi.Name = "tblReportKpi";
        tblReportKpi.RowCount = 1;
        tblReportKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblReportKpi.Size = new Size(1160, 116);
        tblReportKpi.TabIndex = 2;
        // 
        // pnlReportRevenue
        // 
        pnlReportRevenue.BackColor = Color.White;
        pnlReportRevenue.BorderStyle = BorderStyle.FixedSingle;
        pnlReportRevenue.Controls.Add(lblReportRevenueNote);
        pnlReportRevenue.Controls.Add(lblReportRevenueValue);
        pnlReportRevenue.Controls.Add(lblReportRevenueTitle);
        pnlReportRevenue.Dock = DockStyle.Fill;
        pnlReportRevenue.Margin = new Padding(0, 0, 12, 0);
        pnlReportRevenue.Name = "pnlReportRevenue";
        pnlReportRevenue.Padding = new Padding(18, 16, 18, 16);
        pnlReportRevenue.Size = new Size(374, 116);
        pnlReportRevenue.TabIndex = 0;
        // 
        // lblReportRevenueTitle
        // 
        lblReportRevenueTitle.AutoSize = true;
        lblReportRevenueTitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lblReportRevenueTitle.ForeColor = Color.FromArgb(102, 112, 133);
        lblReportRevenueTitle.Location = new Point(18, 16);
        lblReportRevenueTitle.Name = "lblReportRevenueTitle";
        lblReportRevenueTitle.Size = new Size(108, 19);
        lblReportRevenueTitle.TabIndex = 0;
        lblReportRevenueTitle.Text = "Tổng doanh thu";
        // 
        // lblReportRevenueValue
        // 
        lblReportRevenueValue.AutoSize = true;
        lblReportRevenueValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
        lblReportRevenueValue.ForeColor = Color.FromArgb(42, 51, 64);
        lblReportRevenueValue.Location = new Point(18, 44);
        lblReportRevenueValue.Name = "lblReportRevenueValue";
        lblReportRevenueValue.Size = new Size(148, 37);
        lblReportRevenueValue.TabIndex = 1;
        lblReportRevenueValue.Text = "0";
        // 
        // lblReportRevenueNote
        // 
        lblReportRevenueNote.AutoSize = true;
        lblReportRevenueNote.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        lblReportRevenueNote.ForeColor = Color.FromArgb(0, 110, 110);
        lblReportRevenueNote.Location = new Point(20, 82);
        lblReportRevenueNote.Name = "lblReportRevenueNote";
        lblReportRevenueNote.Size = new Size(158, 15);
        lblReportRevenueNote.TabIndex = 2;
        lblReportRevenueNote.Text = "Theo biên nhận đã xác nhận";
        // 
        // pnlReportEnrollment
        // 
        pnlReportEnrollment.BackColor = Color.White;
        pnlReportEnrollment.BorderStyle = BorderStyle.FixedSingle;
        pnlReportEnrollment.Controls.Add(lblReportEnrollmentNote);
        pnlReportEnrollment.Controls.Add(lblReportEnrollmentValue);
        pnlReportEnrollment.Controls.Add(lblReportEnrollmentTitle);
        pnlReportEnrollment.Dock = DockStyle.Fill;
        pnlReportEnrollment.Margin = new Padding(0, 0, 12, 0);
        pnlReportEnrollment.Name = "pnlReportEnrollment";
        pnlReportEnrollment.Padding = new Padding(18, 16, 18, 16);
        pnlReportEnrollment.Size = new Size(374, 116);
        pnlReportEnrollment.TabIndex = 1;
        // 
        // lblReportEnrollmentTitle
        // 
        lblReportEnrollmentTitle.AutoSize = true;
        lblReportEnrollmentTitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lblReportEnrollmentTitle.ForeColor = Color.FromArgb(102, 112, 133);
        lblReportEnrollmentTitle.Location = new Point(18, 16);
        lblReportEnrollmentTitle.Name = "lblReportEnrollmentTitle";
        lblReportEnrollmentTitle.Size = new Size(82, 19);
        lblReportEnrollmentTitle.TabIndex = 0;
        lblReportEnrollmentTitle.Text = "Số ghi danh";
        // 
        // lblReportEnrollmentValue
        // 
        lblReportEnrollmentValue.AutoSize = true;
        lblReportEnrollmentValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
        lblReportEnrollmentValue.ForeColor = Color.FromArgb(42, 51, 64);
        lblReportEnrollmentValue.Location = new Point(18, 44);
        lblReportEnrollmentValue.Name = "lblReportEnrollmentValue";
        lblReportEnrollmentValue.Size = new Size(48, 37);
        lblReportEnrollmentValue.TabIndex = 1;
        lblReportEnrollmentValue.Text = "0";
        // 
        // lblReportEnrollmentNote
        // 
        lblReportEnrollmentNote.AutoSize = true;
        lblReportEnrollmentNote.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        lblReportEnrollmentNote.ForeColor = Color.FromArgb(0, 110, 110);
        lblReportEnrollmentNote.Location = new Point(20, 82);
        lblReportEnrollmentNote.Name = "lblReportEnrollmentNote";
        lblReportEnrollmentNote.Size = new Size(137, 15);
        lblReportEnrollmentNote.TabIndex = 2;
        lblReportEnrollmentNote.Text = "Tổng hồ sơ trong kỳ lọc";
        // 
        // pnlReportClassCount
        // 
        pnlReportClassCount.BackColor = Color.White;
        pnlReportClassCount.BorderStyle = BorderStyle.FixedSingle;
        pnlReportClassCount.Controls.Add(lblReportClassCountNote);
        pnlReportClassCount.Controls.Add(lblReportClassCountValue);
        pnlReportClassCount.Controls.Add(lblReportClassCountTitle);
        pnlReportClassCount.Dock = DockStyle.Fill;
        pnlReportClassCount.Margin = new Padding(0);
        pnlReportClassCount.Name = "pnlReportClassCount";
        pnlReportClassCount.Padding = new Padding(18, 16, 18, 16);
        pnlReportClassCount.Size = new Size(374, 116);
        pnlReportClassCount.TabIndex = 2;
        // 
        // lblReportClassCountTitle
        // 
        lblReportClassCountTitle.AutoSize = true;
        lblReportClassCountTitle.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lblReportClassCountTitle.ForeColor = Color.FromArgb(102, 112, 133);
        lblReportClassCountTitle.Location = new Point(18, 16);
        lblReportClassCountTitle.Name = "lblReportClassCountTitle";
        lblReportClassCountTitle.Size = new Size(85, 19);
        lblReportClassCountTitle.TabIndex = 0;
        lblReportClassCountTitle.Text = "Lớp đang mở";
        // 
        // lblReportClassCountValue
        // 
        lblReportClassCountValue.AutoSize = true;
        lblReportClassCountValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
        lblReportClassCountValue.ForeColor = Color.FromArgb(42, 51, 64);
        lblReportClassCountValue.Location = new Point(18, 44);
        lblReportClassCountValue.Name = "lblReportClassCountValue";
        lblReportClassCountValue.Size = new Size(48, 37);
        lblReportClassCountValue.TabIndex = 1;
        lblReportClassCountValue.Text = "0";
        // 
        // lblReportClassCountNote
        // 
        lblReportClassCountNote.AutoSize = true;
        lblReportClassCountNote.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        lblReportClassCountNote.ForeColor = Color.FromArgb(0, 110, 110);
        lblReportClassCountNote.Location = new Point(20, 82);
        lblReportClassCountNote.Name = "lblReportClassCountNote";
        lblReportClassCountNote.Size = new Size(145, 15);
        lblReportClassCountNote.TabIndex = 2;
        lblReportClassCountNote.Text = "Theo lịch học đang hiệu lực";
        // 
        // splAdminReportContent
        // 
        splAdminReportContent.Dock = DockStyle.Fill;
        splAdminReportContent.Location = new Point(0, 324);
        splAdminReportContent.Margin = new Padding(0, 0, 0, 16);
        splAdminReportContent.Name = "splAdminReportContent";
        // 
        // splAdminReportContent.Panel1
        // 
        splAdminReportContent.Panel1.Controls.Add(pnlReportChartCard);
        // 
        // splAdminReportContent.Panel2
        // 
        splAdminReportContent.Panel2.Controls.Add(pnlReportDetailCard);
        splAdminReportContent.Size = new Size(1160, 330);
        splAdminReportContent.SplitterDistance = 470;
        splAdminReportContent.SplitterWidth = 12;
        splAdminReportContent.TabIndex = 3;
        // 
        // pnlReportChartCard
        // 
        pnlReportChartCard.BackColor = Color.White;
        pnlReportChartCard.BorderStyle = BorderStyle.FixedSingle;
        pnlReportChartCard.Controls.Add(chtAdminRevenue);
        pnlReportChartCard.Controls.Add(lblReportChartTitle);
        pnlReportChartCard.Dock = DockStyle.Fill;
        pnlReportChartCard.Name = "pnlReportChartCard";
        pnlReportChartCard.Padding = new Padding(18, 16, 18, 18);
        pnlReportChartCard.TabIndex = 0;
        // 
        // lblReportChartTitle
        // 
        lblReportChartTitle.AutoSize = false;
        lblReportChartTitle.Dock = DockStyle.Top;
        lblReportChartTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
        lblReportChartTitle.ForeColor = Color.FromArgb(42, 51, 64);
        lblReportChartTitle.Location = new Point(18, 16);
        lblReportChartTitle.Name = "lblReportChartTitle";
        lblReportChartTitle.Size = new Size(432, 32);
        lblReportChartTitle.TabIndex = 0;
        lblReportChartTitle.Text = "Biểu đồ doanh thu";
        // 
        // chtAdminRevenue
        // 
        chtAdminRevenue.BackColor = Color.White;
        chtAdminRevenue.BorderlineColor = Color.FromArgb(225, 230, 239);
        chtAdminRevenue.BorderlineDashStyle = ChartDashStyle.Solid;
        chtAdminRevenue.BorderSkin.BorderColor = Color.FromArgb(225, 230, 239);
        chtAdminRevenue.ChartAreas.Add(new ChartArea("DefaultArea"));
        chtAdminRevenue.Dock = DockStyle.Fill;
        chtAdminRevenue.Legends.Add(new Legend("DefaultLegend"));
        chtAdminRevenue.Location = new Point(18, 48);
        chtAdminRevenue.Name = "chtAdminRevenue";
        chtAdminRevenue.Size = new Size(432, 262);
        chtAdminRevenue.TabIndex = 1;
        // 
        // pnlReportDetailCard
        // 
        pnlReportDetailCard.BackColor = Color.White;
        pnlReportDetailCard.BorderStyle = BorderStyle.FixedSingle;
        pnlReportDetailCard.Controls.Add(dgvAdminReportDetail);
        pnlReportDetailCard.Controls.Add(lblReportDetailTitle);
        pnlReportDetailCard.Dock = DockStyle.Fill;
        pnlReportDetailCard.Name = "pnlReportDetailCard";
        pnlReportDetailCard.Padding = new Padding(18, 16, 18, 18);
        pnlReportDetailCard.TabIndex = 0;
        // 
        // lblReportDetailTitle
        // 
        lblReportDetailTitle.AutoSize = false;
        lblReportDetailTitle.Dock = DockStyle.Top;
        lblReportDetailTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
        lblReportDetailTitle.ForeColor = Color.FromArgb(42, 51, 64);
        lblReportDetailTitle.Location = new Point(18, 16);
        lblReportDetailTitle.Name = "lblReportDetailTitle";
        lblReportDetailTitle.Size = new Size(640, 32);
        lblReportDetailTitle.TabIndex = 0;
        lblReportDetailTitle.Text = "Bảng số liệu tổng hợp";
        // 
        // dgvAdminReportDetail
        // 
        dgvAdminReportDetail.AllowUserToAddRows = false;
        dgvAdminReportDetail.AllowUserToDeleteRows = false;
        dgvAdminReportDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvAdminReportDetail.BackgroundColor = Color.White;
        dgvAdminReportDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvAdminReportDetail.Dock = DockStyle.Fill;
        dgvAdminReportDetail.Location = new Point(18, 48);
        dgvAdminReportDetail.MultiSelect = false;
        dgvAdminReportDetail.Name = "dgvAdminReportDetail";
        dgvAdminReportDetail.ReadOnly = true;
        dgvAdminReportDetail.RowHeadersVisible = false;
        dgvAdminReportDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAdminReportDetail.Size = new Size(640, 262);
        dgvAdminReportDetail.TabIndex = 1;
        // 
        // pnlReportFooter
        // 
        pnlReportFooter.BackColor = Color.White;
        pnlReportFooter.BorderStyle = BorderStyle.FixedSingle;
        pnlReportFooter.Controls.Add(lblReportFooterHint);
        pnlReportFooter.Dock = DockStyle.Fill;
        pnlReportFooter.Margin = new Padding(0);
        pnlReportFooter.Name = "pnlReportFooter";
        pnlReportFooter.Padding = new Padding(18, 10, 18, 10);
        pnlReportFooter.Size = new Size(1160, 40);
        pnlReportFooter.TabIndex = 4;
        // 
        // lblReportFooterHint
        // 
        lblReportFooterHint.AutoSize = true;
        lblReportFooterHint.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
        lblReportFooterHint.ForeColor = Color.FromArgb(102, 112, 133);
        lblReportFooterHint.Location = new Point(18, 11);
        lblReportFooterHint.Name = "lblReportFooterHint";
        lblReportFooterHint.Size = new Size(497, 15);
        lblReportFooterHint.TabIndex = 0;
        lblReportFooterHint.Text = "Báo cáo lấy dữ liệu mẫu từ luồng vận hành, thu học phí và lớp học để phục vụ demo UI.";
        // 
        // FrmAdminReports
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 251);
        ClientSize = new Size(1200, 750);
        Controls.Add(tblAdminReportRoot);
        MinimumSize = new Size(980, 620);
        Name = "FrmAdminReports";
        Padding = new Padding(20);
        Text = "Báo cáo thống kê";
        splAdminReportContent.Panel1.ResumeLayout(false);
        splAdminReportContent.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splAdminReportContent).EndInit();
        splAdminReportContent.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)chtAdminRevenue).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvAdminReportDetail).EndInit();
        tblAdminReportRoot.ResumeLayout(false);
        pnlAdminReportHeader.ResumeLayout(false);
        pnlAdminReportHeader.PerformLayout();
        pnlAdminReportFilterCard.ResumeLayout(false);
        tblAdminReportFilter.ResumeLayout(false);
        tblAdminReportFilter.PerformLayout();
        flpReportActions.ResumeLayout(false);
        tblReportKpi.ResumeLayout(false);
        pnlReportRevenue.ResumeLayout(false);
        pnlReportRevenue.PerformLayout();
        pnlReportEnrollment.ResumeLayout(false);
        pnlReportEnrollment.PerformLayout();
        pnlReportClassCount.ResumeLayout(false);
        pnlReportClassCount.PerformLayout();
        pnlReportChartCard.ResumeLayout(false);
        pnlReportChartCard.PerformLayout();
        pnlReportDetailCard.ResumeLayout(false);
        pnlReportDetailCard.PerformLayout();
        pnlReportFooter.ResumeLayout(false);
        pnlReportFooter.PerformLayout();
        ResumeLayout(false);
    }
}
