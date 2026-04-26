namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmSystemMonitor
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tblMonitorRoot;
    private Panel pnlMonitorHeader;
    private Label lblMonitorEyebrow;
    private Label lblMonitorTitle;
    private Label lblMonitorSubtitle;
    private Button btnMonitorToday;
    private Panel pnlSystemMonitorFilterCard;
    private TableLayoutPanel tblMonitorFilter;
    private Label lblMonitorPeriod;
    private ComboBox cboMonitorPeriod;
    private Label lblMonitorDepartment;
    private ComboBox cboMonitorDepartment;
    private Label lblMonitorViewType;
    private ComboBox cboMonitorViewType;
    private FlowLayoutPanel flpMonitorActions;
    private Button btnViewMonitor;
    private Button btnQuickExportMonitor;
    private TableLayoutPanel tblMonitorKpi;
    private Panel pnlMonitorStudentCount;
    private Panel pnlMonitorEnrollmentCount;
    private Panel pnlMonitorReceiptCount;
    private Panel pnlMonitorDebtTotal;
    private Label lblMonitorStudentCountTitle;
    private Label lblMonitorStudentCountValue;
    private Label lblMonitorStudentCountTag;
    private Label lblMonitorEnrollmentCountTitle;
    private Label lblMonitorEnrollmentCountValue;
    private Label lblMonitorEnrollmentCountTag;
    private Label lblMonitorReceiptCountTitle;
    private Label lblMonitorReceiptCountValue;
    private Label lblMonitorReceiptCountTag;
    private Label lblMonitorDebtTotalTitle;
    private Label lblMonitorDebtTotalValue;
    private Label lblMonitorDebtTotalTag;
    private SplitContainer splMonitorMain;
    private Panel pnlMonitorActivityCard;
    private Label lblMonitorActivityTitle;
    private DataGridView dgvMonitorActivity;
    private Panel pnlMonitorActivityFooter;
    private Label lblMonitorActivityFooter;
    private FlowLayoutPanel flpMonitorPagination;
    private Button btnMonitorPagePrev;
    private Button btnMonitorPageCurrent;
    private Button btnMonitorPageNext;
    private Panel pnlMonitorSourceColumn;
    private Label lblMonitorSourceTitle;
    private Panel pnlMonitorSourceCardStaff;
    private Label lblMonitorSourceStaffTitle;
    private Label lblMonitorSourceStaffRate1;
    private ProgressBar prgMonitorSourceStaff1;
    private Label lblMonitorSourceStaffRate2;
    private ProgressBar prgMonitorSourceStaff2;
    private Label lblMonitorSourceStaffLive;
    private Panel pnlMonitorSourceCardTeacher;
    private Label lblMonitorSourceTeacherTitle;
    private Label lblMonitorSourceTeacherRate1;
    private ProgressBar prgMonitorSourceTeacher1;
    private Label lblMonitorSourceTeacherRate2;
    private ProgressBar prgMonitorSourceTeacher2;
    private Label lblMonitorSourceTeacherLive;
    private Panel pnlMonitorHealthCard;
    private Label lblMonitorHealthTitle;
    private TableLayoutPanel tblMonitorHealthMatrix;
    private Label lblMonitorHealthFootnote;
    private Panel pnlHealth01;
    private Panel pnlHealth02;
    private Panel pnlHealth03;
    private Panel pnlHealth04;
    private Panel pnlHealth05;
    private Panel pnlHealth06;
    private Panel pnlHealth07;
    private Panel pnlHealth08;
    private Panel pnlHealth09;
    private Panel pnlHealth10;
    private Panel pnlHealth11;
    private Panel pnlHealth12;
    private Panel pnlHealth13;
    private Panel pnlHealth14;
    private Panel pnlHealth15;
    private Panel pnlHealth16;
    private Panel pnlHealth17;
    private Panel pnlHealth18;
    private Panel pnlHealth19;
    private Panel pnlHealth20;

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
        tblMonitorRoot = new TableLayoutPanel();
        pnlMonitorHeader = new Panel();
        btnMonitorToday = new Button();
        lblMonitorSubtitle = new Label();
        lblMonitorTitle = new Label();
        lblMonitorEyebrow = new Label();
        pnlSystemMonitorFilterCard = new Panel();
        tblMonitorFilter = new TableLayoutPanel();
        lblMonitorPeriod = new Label();
        cboMonitorPeriod = new ComboBox();
        lblMonitorDepartment = new Label();
        cboMonitorDepartment = new ComboBox();
        lblMonitorViewType = new Label();
        cboMonitorViewType = new ComboBox();
        flpMonitorActions = new FlowLayoutPanel();
        btnViewMonitor = new Button();
        btnQuickExportMonitor = new Button();
        tblMonitorKpi = new TableLayoutPanel();
        pnlMonitorStudentCount = new Panel();
        lblMonitorStudentCountTag = new Label();
        lblMonitorStudentCountValue = new Label();
        lblMonitorStudentCountTitle = new Label();
        pnlMonitorEnrollmentCount = new Panel();
        lblMonitorEnrollmentCountTag = new Label();
        lblMonitorEnrollmentCountValue = new Label();
        lblMonitorEnrollmentCountTitle = new Label();
        pnlMonitorReceiptCount = new Panel();
        lblMonitorReceiptCountTag = new Label();
        lblMonitorReceiptCountValue = new Label();
        lblMonitorReceiptCountTitle = new Label();
        pnlMonitorDebtTotal = new Panel();
        lblMonitorDebtTotalTag = new Label();
        lblMonitorDebtTotalValue = new Label();
        lblMonitorDebtTotalTitle = new Label();
        splMonitorMain = new SplitContainer();
        pnlMonitorActivityCard = new Panel();
        dgvMonitorActivity = new DataGridView();
        pnlMonitorActivityFooter = new Panel();
        flpMonitorPagination = new FlowLayoutPanel();
        btnMonitorPagePrev = new Button();
        btnMonitorPageCurrent = new Button();
        btnMonitorPageNext = new Button();
        lblMonitorActivityFooter = new Label();
        lblMonitorActivityTitle = new Label();
        pnlMonitorSourceColumn = new Panel();
        pnlMonitorHealthCard = new Panel();
        lblMonitorHealthFootnote = new Label();
        tblMonitorHealthMatrix = new TableLayoutPanel();
        pnlHealth01 = new Panel();
        pnlHealth02 = new Panel();
        pnlHealth03 = new Panel();
        pnlHealth04 = new Panel();
        pnlHealth05 = new Panel();
        pnlHealth06 = new Panel();
        pnlHealth07 = new Panel();
        pnlHealth08 = new Panel();
        pnlHealth09 = new Panel();
        pnlHealth10 = new Panel();
        pnlHealth11 = new Panel();
        pnlHealth12 = new Panel();
        pnlHealth13 = new Panel();
        pnlHealth14 = new Panel();
        pnlHealth15 = new Panel();
        pnlHealth16 = new Panel();
        pnlHealth17 = new Panel();
        pnlHealth18 = new Panel();
        pnlHealth19 = new Panel();
        pnlHealth20 = new Panel();
        lblMonitorHealthTitle = new Label();
        pnlMonitorSourceCardTeacher = new Panel();
        lblMonitorSourceTeacherLive = new Label();
        lblMonitorSourceTeacherRate2 = new Label();
        prgMonitorSourceTeacher2 = new ProgressBar();
        lblMonitorSourceTeacherRate1 = new Label();
        prgMonitorSourceTeacher1 = new ProgressBar();
        lblMonitorSourceTeacherTitle = new Label();
        pnlMonitorSourceCardStaff = new Panel();
        lblMonitorSourceStaffLive = new Label();
        lblMonitorSourceStaffRate2 = new Label();
        prgMonitorSourceStaff2 = new ProgressBar();
        lblMonitorSourceStaffRate1 = new Label();
        prgMonitorSourceStaff1 = new ProgressBar();
        lblMonitorSourceStaffTitle = new Label();
        lblMonitorSourceTitle = new Label();
        tblMonitorRoot.SuspendLayout();
        pnlMonitorHeader.SuspendLayout();
        pnlSystemMonitorFilterCard.SuspendLayout();
        tblMonitorFilter.SuspendLayout();
        flpMonitorActions.SuspendLayout();
        tblMonitorKpi.SuspendLayout();
        pnlMonitorStudentCount.SuspendLayout();
        pnlMonitorEnrollmentCount.SuspendLayout();
        pnlMonitorReceiptCount.SuspendLayout();
        pnlMonitorDebtTotal.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splMonitorMain).BeginInit();
        splMonitorMain.Panel1.SuspendLayout();
        splMonitorMain.Panel2.SuspendLayout();
        splMonitorMain.SuspendLayout();
        pnlMonitorActivityCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMonitorActivity).BeginInit();
        pnlMonitorActivityFooter.SuspendLayout();
        flpMonitorPagination.SuspendLayout();
        pnlMonitorSourceColumn.SuspendLayout();
        pnlMonitorHealthCard.SuspendLayout();
        tblMonitorHealthMatrix.SuspendLayout();
        pnlMonitorSourceCardTeacher.SuspendLayout();
        pnlMonitorSourceCardStaff.SuspendLayout();
        SuspendLayout();
        // 
        // tblMonitorRoot
        // 
        tblMonitorRoot.ColumnCount = 1;
        tblMonitorRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblMonitorRoot.Controls.Add(pnlMonitorHeader, 0, 0);
        tblMonitorRoot.Controls.Add(pnlSystemMonitorFilterCard, 0, 1);
        tblMonitorRoot.Controls.Add(tblMonitorKpi, 0, 2);
        tblMonitorRoot.Controls.Add(splMonitorMain, 0, 3);
        tblMonitorRoot.Dock = DockStyle.Fill;
        tblMonitorRoot.Location = new Point(16, 16);
        tblMonitorRoot.Name = "tblMonitorRoot";
        tblMonitorRoot.RowCount = 4;
        tblMonitorRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tblMonitorRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tblMonitorRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tblMonitorRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblMonitorRoot.Size = new Size(1088, 688);
        tblMonitorRoot.AutoScroll = true;
        tblMonitorRoot.TabIndex = 0;
        // 
        // pnlMonitorHeader
        // 
        pnlMonitorHeader.Controls.Add(btnMonitorToday);
        pnlMonitorHeader.Controls.Add(lblMonitorSubtitle);
        pnlMonitorHeader.Controls.Add(lblMonitorTitle);
        pnlMonitorHeader.Controls.Add(lblMonitorEyebrow);
        pnlMonitorHeader.Dock = DockStyle.Fill;
        pnlMonitorHeader.Location = new Point(0, 0);
        pnlMonitorHeader.Margin = new Padding(0, 0, 0, 14);
        pnlMonitorHeader.Name = "pnlMonitorHeader";
        pnlMonitorHeader.Padding = new Padding(4, 0, 4, 10);
        pnlMonitorHeader.Size = new Size(1088, 114);
        pnlMonitorHeader.AutoScroll = false;
        pnlMonitorHeader.TabIndex = 0;
        // 
        // btnMonitorToday
        // 
        btnMonitorToday.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnMonitorToday.FlatStyle = FlatStyle.Flat;
        btnMonitorToday.Location = new Point(930, 29);
        btnMonitorToday.Name = "btnMonitorToday";
        btnMonitorToday.Size = new Size(146, 42);
        btnMonitorToday.TabIndex = 3;
        btnMonitorToday.Text = "HÔM NAY";
        btnMonitorToday.UseVisualStyleBackColor = true;
        // 
        // lblMonitorSubtitle
        // 
        lblMonitorSubtitle.AutoSize = true;
        lblMonitorSubtitle.Location = new Point(8, 67);
        lblMonitorSubtitle.Name = "lblMonitorSubtitle";
        lblMonitorSubtitle.Size = new Size(540, 28);
        lblMonitorSubtitle.TabIndex = 2;
        lblMonitorSubtitle.Text = "Phiên làm việc hiện tại: 08:45:12 GMT+7 | Trạng thái: Ổn định";
        // 
        // lblMonitorTitle
        // 
        lblMonitorTitle.AutoSize = true;
        lblMonitorTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold | FontStyle.Italic);
        lblMonitorTitle.Location = new Point(4, 10);
        lblMonitorTitle.Name = "lblMonitorTitle";
        lblMonitorTitle.Size = new Size(515, 65);
        lblMonitorTitle.TabIndex = 1;
        lblMonitorTitle.Text = "GIÁM SÁT HỆ THỐNG";
        // 
        // lblMonitorEyebrow
        // 
        lblMonitorEyebrow.Dock = DockStyle.Bottom;
        lblMonitorEyebrow.Location = new Point(4, 91);
        lblMonitorEyebrow.Name = "lblMonitorEyebrow";
        lblMonitorEyebrow.Size = new Size(1080, 13);
        lblMonitorEyebrow.AutoSize = true;
        lblMonitorEyebrow.TabIndex = 0;
        // 
        // pnlSystemMonitorFilterCard
        // 
        pnlSystemMonitorFilterCard.Controls.Add(tblMonitorFilter);
        pnlSystemMonitorFilterCard.Dock = DockStyle.Fill;
        pnlSystemMonitorFilterCard.Location = new Point(0, 128);
        pnlSystemMonitorFilterCard.Margin = new Padding(0, 0, 0, 16);
        pnlSystemMonitorFilterCard.Name = "pnlSystemMonitorFilterCard";
        pnlSystemMonitorFilterCard.Padding = new Padding(18);
        pnlSystemMonitorFilterCard.Size = new Size(1088, 114);
        pnlSystemMonitorFilterCard.AutoScroll = false;
        pnlSystemMonitorFilterCard.TabIndex = 1;
        // 
        // tblMonitorFilter
        // 
        tblMonitorFilter.ColumnCount = 4;
        tblMonitorFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
        tblMonitorFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
        tblMonitorFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
        tblMonitorFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
        tblMonitorFilter.Controls.Add(lblMonitorPeriod, 0, 0);
        tblMonitorFilter.Controls.Add(cboMonitorPeriod, 0, 1);
        tblMonitorFilter.Controls.Add(lblMonitorDepartment, 1, 0);
        tblMonitorFilter.Controls.Add(cboMonitorDepartment, 1, 1);
        tblMonitorFilter.Controls.Add(lblMonitorViewType, 2, 0);
        tblMonitorFilter.Controls.Add(cboMonitorViewType, 2, 1);
        tblMonitorFilter.Controls.Add(flpMonitorActions, 3, 1);
        tblMonitorFilter.Dock = DockStyle.Fill;
        tblMonitorFilter.Location = new Point(18, 18);
        tblMonitorFilter.Name = "tblMonitorFilter";
        tblMonitorFilter.RowCount = 2;
        tblMonitorFilter.RowStyles.Add(new RowStyle());
        tblMonitorFilter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblMonitorFilter.Size = new Size(1052, 78);
        tblMonitorFilter.AutoScroll = false;
        tblMonitorFilter.TabIndex = 0;
        // 
        // lblMonitorPeriod
        // 
        lblMonitorPeriod.AutoSize = true;
        lblMonitorPeriod.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblMonitorPeriod.Location = new Point(3, 0);
        lblMonitorPeriod.Name = "lblMonitorPeriod";
        lblMonitorPeriod.Size = new Size(193, 25);
        lblMonitorPeriod.TabIndex = 0;
        lblMonitorPeriod.Text = "KHOẢNG THỜI GIAN";
        // 
        // cboMonitorPeriod
        // 
        cboMonitorPeriod.Dock = DockStyle.Fill;
        cboMonitorPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
        cboMonitorPeriod.FormattingEnabled = true;
        cboMonitorPeriod.Items.AddRange(new object[] { "24 giờ qua", "7 ngày qua", "30 ngày qua" });
        cboMonitorPeriod.Location = new Point(3, 28);
        cboMonitorPeriod.Name = "cboMonitorPeriod";
        cboMonitorPeriod.Size = new Size(288, 36);
        cboMonitorPeriod.TabIndex = 1;
        // 
        // lblMonitorDepartment
        // 
        lblMonitorDepartment.AutoSize = true;
        lblMonitorDepartment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblMonitorDepartment.Location = new Point(297, 0);
        lblMonitorDepartment.Name = "lblMonitorDepartment";
        lblMonitorDepartment.Size = new Size(178, 25);
        lblMonitorDepartment.TabIndex = 2;
        lblMonitorDepartment.Text = "BỘ PHẬN QUẢN LÝ";
        // 
        // cboMonitorDepartment
        // 
        cboMonitorDepartment.Dock = DockStyle.Fill;
        cboMonitorDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
        cboMonitorDepartment.FormattingEnabled = true;
        cboMonitorDepartment.Items.AddRange(new object[] { "Nhân viên & Giảng viên", "Nhân viên", "Giảng viên", "Toàn hệ thống" });
        cboMonitorDepartment.Location = new Point(297, 28);
        cboMonitorDepartment.Name = "cboMonitorDepartment";
        cboMonitorDepartment.Size = new Size(288, 36);
        cboMonitorDepartment.TabIndex = 3;
        // 
        // lblMonitorViewType
        // 
        lblMonitorViewType.AutoSize = true;
        lblMonitorViewType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblMonitorViewType.Location = new Point(591, 0);
        lblMonitorViewType.Name = "lblMonitorViewType";
        lblMonitorViewType.Size = new Size(170, 25);
        lblMonitorViewType.TabIndex = 4;
        lblMonitorViewType.Text = "LOẠI HOẠT ĐỘNG";
        // 
        // cboMonitorViewType
        // 
        cboMonitorViewType.Dock = DockStyle.Fill;
        cboMonitorViewType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboMonitorViewType.FormattingEnabled = true;
        cboMonitorViewType.Items.AddRange(new object[] { "Tất cả hoạt động", "Thanh toán", "Điểm danh", "Ghi danh", "Cấu hình" });
        cboMonitorViewType.Location = new Point(591, 28);
        cboMonitorViewType.Name = "cboMonitorViewType";
        cboMonitorViewType.Size = new Size(288, 36);
        cboMonitorViewType.TabIndex = 5;
        // 
        // flpMonitorActions
        // 
        flpMonitorActions.Controls.Add(btnViewMonitor);
        flpMonitorActions.Controls.Add(btnQuickExportMonitor);
        flpMonitorActions.Dock = DockStyle.Fill;
        flpMonitorActions.FlowDirection = FlowDirection.TopDown;
        flpMonitorActions.Location = new Point(885, 28);
        flpMonitorActions.Name = "flpMonitorActions";
        flpMonitorActions.Size = new Size(164, 47);
        flpMonitorActions.AutoScroll = false;
        flpMonitorActions.TabIndex = 6;
        flpMonitorActions.WrapContents = false;
        // 
        // btnViewMonitor
        // 
        btnViewMonitor.Location = new Point(3, 3);
        btnViewMonitor.Name = "btnViewMonitor";
        btnViewMonitor.Size = new Size(158, 46);
        btnViewMonitor.TabIndex = 0;
        btnViewMonitor.Text = "LÀM MỚI";
        btnViewMonitor.UseVisualStyleBackColor = true;
        // 
        // btnQuickExportMonitor
        // 
        btnQuickExportMonitor.Location = new Point(3, 55);
        btnQuickExportMonitor.Name = "btnQuickExportMonitor";
        btnQuickExportMonitor.Size = new Size(160, 46);
        btnQuickExportMonitor.TabIndex = 1;
        btnQuickExportMonitor.Text = "XUẤT NHANH";
        btnQuickExportMonitor.UseVisualStyleBackColor = true;
        btnQuickExportMonitor.Visible = false;
        // 
        // tblMonitorKpi
        // 
        tblMonitorKpi.ColumnCount = 4;
        tblMonitorKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblMonitorKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblMonitorKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblMonitorKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblMonitorKpi.Controls.Add(pnlMonitorStudentCount, 0, 0);
        tblMonitorKpi.Controls.Add(pnlMonitorEnrollmentCount, 1, 0);
        tblMonitorKpi.Controls.Add(pnlMonitorReceiptCount, 2, 0);
        tblMonitorKpi.Controls.Add(pnlMonitorDebtTotal, 3, 0);
        tblMonitorKpi.Dock = DockStyle.Fill;
        tblMonitorKpi.Location = new Point(0, 258);
        tblMonitorKpi.Margin = new Padding(0, 0, 0, 18);
        tblMonitorKpi.Name = "tblMonitorKpi";
        tblMonitorKpi.RowCount = 1;
        tblMonitorKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblMonitorKpi.Size = new Size(1088, 128);
        tblMonitorKpi.AutoScroll = false;
        tblMonitorKpi.TabIndex = 2;
        // 
        // pnlMonitorStudentCount
        // 
        pnlMonitorStudentCount.Controls.Add(lblMonitorStudentCountTag);
        pnlMonitorStudentCount.Controls.Add(lblMonitorStudentCountValue);
        pnlMonitorStudentCount.Controls.Add(lblMonitorStudentCountTitle);
        pnlMonitorStudentCount.Dock = DockStyle.Fill;
        pnlMonitorStudentCount.Location = new Point(0, 0);
        pnlMonitorStudentCount.Margin = new Padding(0, 0, 14, 0);
        pnlMonitorStudentCount.Name = "pnlMonitorStudentCount";
        pnlMonitorStudentCount.Padding = new Padding(20, 18, 20, 16);
        pnlMonitorStudentCount.Size = new Size(258, 128);
        pnlMonitorStudentCount.AutoScroll = false;
        pnlMonitorStudentCount.TabIndex = 0;
        // 
        // lblMonitorStudentCountTag
        // 
        lblMonitorStudentCountTag.AutoSize = true;
        lblMonitorStudentCountTag.Location = new Point(39, 92);
        lblMonitorStudentCountTag.Name = "lblMonitorStudentCountTag";
        lblMonitorStudentCountTag.Size = new Size(95, 28);
        lblMonitorStudentCountTag.TabIndex = 2;
        lblMonitorStudentCountTag.Text = "ỔN ĐỊNH";
        lblMonitorStudentCountTag.Click += lblMonitorStudentCountTag_Click;
        // 
        // lblMonitorStudentCountValue
        // 
        lblMonitorStudentCountValue.AutoSize = true;
        lblMonitorStudentCountValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblMonitorStudentCountValue.Location = new Point(39, 42);
        lblMonitorStudentCountValue.Name = "lblMonitorStudentCountValue";
        lblMonitorStudentCountValue.Size = new Size(150, 60);
        lblMonitorStudentCountValue.TabIndex = 1;
        lblMonitorStudentCountValue.Text = "99.9%";
        // 
        // lblMonitorStudentCountTitle
        // 
        lblMonitorStudentCountTitle.AutoSize = true;
        lblMonitorStudentCountTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblMonitorStudentCountTitle.Location = new Point(20, 16);
        lblMonitorStudentCountTitle.Name = "lblMonitorStudentCountTitle";
        lblMonitorStudentCountTitle.Size = new Size(245, 28);
        lblMonitorStudentCountTitle.TabIndex = 0;
        lblMonitorStudentCountTitle.Text = "THỜI GIAN HOẠT ĐỘNG";
        // 
        // pnlMonitorEnrollmentCount
        // 
        pnlMonitorEnrollmentCount.Controls.Add(lblMonitorEnrollmentCountTag);
        pnlMonitorEnrollmentCount.Controls.Add(lblMonitorEnrollmentCountValue);
        pnlMonitorEnrollmentCount.Controls.Add(lblMonitorEnrollmentCountTitle);
        pnlMonitorEnrollmentCount.Dock = DockStyle.Fill;
        pnlMonitorEnrollmentCount.Location = new Point(272, 0);
        pnlMonitorEnrollmentCount.Margin = new Padding(0, 0, 14, 0);
        pnlMonitorEnrollmentCount.Name = "pnlMonitorEnrollmentCount";
        pnlMonitorEnrollmentCount.Padding = new Padding(20, 18, 20, 16);
        pnlMonitorEnrollmentCount.Size = new Size(258, 128);
        pnlMonitorEnrollmentCount.AutoScroll = false;
        pnlMonitorEnrollmentCount.TabIndex = 1;
        // 
        // lblMonitorEnrollmentCountTag
        // 
        lblMonitorEnrollmentCountTag.AutoSize = true;
        lblMonitorEnrollmentCountTag.Location = new Point(43, 93);
        lblMonitorEnrollmentCountTag.Name = "lblMonitorEnrollmentCountTag";
        lblMonitorEnrollmentCountTag.Size = new Size(137, 28);
        lblMonitorEnrollmentCountTag.TabIndex = 2;
        lblMonitorEnrollmentCountTag.Text = "NGƯỜI DÙNG";
        lblMonitorEnrollmentCountTag.Click += lblMonitorEnrollmentCountTag_Click;
        // 
        // lblMonitorEnrollmentCountValue
        // 
        lblMonitorEnrollmentCountValue.AutoSize = true;
        lblMonitorEnrollmentCountValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblMonitorEnrollmentCountValue.Location = new Point(43, 43);
        lblMonitorEnrollmentCountValue.Name = "lblMonitorEnrollmentCountValue";
        lblMonitorEnrollmentCountValue.Size = new Size(100, 60);
        lblMonitorEnrollmentCountValue.TabIndex = 1;
        lblMonitorEnrollmentCountValue.Text = "142";
        // 
        // lblMonitorEnrollmentCountTitle
        // 
        lblMonitorEnrollmentCountTitle.AutoSize = true;
        lblMonitorEnrollmentCountTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblMonitorEnrollmentCountTitle.Location = new Point(20, 16);
        lblMonitorEnrollmentCountTitle.Name = "lblMonitorEnrollmentCountTitle";
        lblMonitorEnrollmentCountTitle.Size = new Size(200, 28);
        lblMonitorEnrollmentCountTitle.TabIndex = 0;
        lblMonitorEnrollmentCountTitle.Text = "PHIÊN HOẠT ĐỘNG";
        // 
        // pnlMonitorReceiptCount
        // 
        pnlMonitorReceiptCount.Controls.Add(lblMonitorReceiptCountTag);
        pnlMonitorReceiptCount.Controls.Add(lblMonitorReceiptCountValue);
        pnlMonitorReceiptCount.Controls.Add(lblMonitorReceiptCountTitle);
        pnlMonitorReceiptCount.Dock = DockStyle.Fill;
        pnlMonitorReceiptCount.Location = new Point(544, 0);
        pnlMonitorReceiptCount.Margin = new Padding(0, 0, 14, 0);
        pnlMonitorReceiptCount.Name = "pnlMonitorReceiptCount";
        pnlMonitorReceiptCount.Padding = new Padding(20, 18, 20, 16);
        pnlMonitorReceiptCount.Size = new Size(258, 128);
        pnlMonitorReceiptCount.AutoScroll = false;
        pnlMonitorReceiptCount.TabIndex = 2;
        // 
        // lblMonitorReceiptCountTag
        // 
        lblMonitorReceiptCountTag.AutoSize = true;
        lblMonitorReceiptCountTag.Location = new Point(49, 93);
        lblMonitorReceiptCountTag.Name = "lblMonitorReceiptCountTag";
        lblMonitorReceiptCountTag.Size = new Size(109, 28);
        lblMonitorReceiptCountTag.TabIndex = 2;
        lblMonitorReceiptCountTag.Text = "GIAO DỊCH";
        // 
        // lblMonitorReceiptCountValue
        // 
        lblMonitorReceiptCountValue.AutoSize = true;
        lblMonitorReceiptCountValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblMonitorReceiptCountValue.Location = new Point(49, 39);
        lblMonitorReceiptCountValue.Name = "lblMonitorReceiptCountValue";
        lblMonitorReceiptCountValue.Size = new Size(137, 60);
        lblMonitorReceiptCountValue.TabIndex = 1;
        lblMonitorReceiptCountValue.Text = "1,240";
        // 
        // lblMonitorReceiptCountTitle
        // 
        lblMonitorReceiptCountTitle.AutoSize = true;
        lblMonitorReceiptCountTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblMonitorReceiptCountTitle.Location = new Point(20, 16);
        lblMonitorReceiptCountTitle.Name = "lblMonitorReceiptCountTitle";
        lblMonitorReceiptCountTitle.Size = new Size(172, 28);
        lblMonitorReceiptCountTitle.TabIndex = 0;
        lblMonitorReceiptCountTitle.Text = "NV XỬ LÝ HỒ SƠ";
        // 
        // pnlMonitorDebtTotal
        // 
        pnlMonitorDebtTotal.Controls.Add(lblMonitorDebtTotalTag);
        pnlMonitorDebtTotal.Controls.Add(lblMonitorDebtTotalValue);
        pnlMonitorDebtTotal.Controls.Add(lblMonitorDebtTotalTitle);
        pnlMonitorDebtTotal.Dock = DockStyle.Fill;
        pnlMonitorDebtTotal.Location = new Point(816, 0);
        pnlMonitorDebtTotal.Margin = new Padding(0);
        pnlMonitorDebtTotal.Name = "pnlMonitorDebtTotal";
        pnlMonitorDebtTotal.Padding = new Padding(20, 18, 20, 16);
        pnlMonitorDebtTotal.Size = new Size(272, 128);
        pnlMonitorDebtTotal.AutoScroll = false;
        pnlMonitorDebtTotal.TabIndex = 3;
        // 
        // lblMonitorDebtTotalTag
        // 
        lblMonitorDebtTotalTag.AutoSize = true;
        lblMonitorDebtTotalTag.Location = new Point(56, 92);
        lblMonitorDebtTotalTag.Name = "lblMonitorDebtTotalTag";
        lblMonitorDebtTotalTag.Size = new Size(89, 28);
        lblMonitorDebtTotalTag.TabIndex = 2;
        lblMonitorDebtTotalTag.Text = "BẢN GHI";
        // 
        // lblMonitorDebtTotalValue
        // 
        lblMonitorDebtTotalValue.AutoSize = true;
        lblMonitorDebtTotalValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblMonitorDebtTotalValue.Location = new Point(56, 42);
        lblMonitorDebtTotalValue.Name = "lblMonitorDebtTotalValue";
        lblMonitorDebtTotalValue.Size = new Size(100, 60);
        lblMonitorDebtTotalValue.TabIndex = 1;
        lblMonitorDebtTotalValue.Text = "856";
        // 
        // lblMonitorDebtTotalTitle
        // 
        lblMonitorDebtTotalTitle.AutoSize = true;
        lblMonitorDebtTotalTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblMonitorDebtTotalTitle.Location = new Point(20, 16);
        lblMonitorDebtTotalTitle.Name = "lblMonitorDebtTotalTitle";
        lblMonitorDebtTotalTitle.Size = new Size(250, 28);
        lblMonitorDebtTotalTitle.TabIndex = 0;
        lblMonitorDebtTotalTitle.Text = "GV NHẬT KÝ GIẢNG DẠY";
        // 
        // splMonitorMain
        // 
        splMonitorMain.Dock = DockStyle.Fill;
        splMonitorMain.Location = new Point(0, 404);
        splMonitorMain.Margin = new Padding(0);
        splMonitorMain.Name = "splMonitorMain";
        // 
        // splMonitorMain.Panel1
        // 
        splMonitorMain.Panel1.Controls.Add(pnlMonitorActivityCard);
        splMonitorMain.Panel1.Padding = new Padding(0, 0, 16, 0);
        // 
        // splMonitorMain.Panel2
        // 
        splMonitorMain.Panel2.Controls.Add(pnlMonitorSourceColumn);
        splMonitorMain.Panel2.Padding = new Padding(16, 0, 0, 0);
        splMonitorMain.Size = new Size(1088, 284);
        splMonitorMain.SplitterDistance = 756;
        splMonitorMain.AutoScroll = false;
        splMonitorMain.TabIndex = 3;
        // 
        // pnlMonitorActivityCard
        // 
        pnlMonitorActivityCard.Controls.Add(dgvMonitorActivity);
        pnlMonitorActivityCard.Controls.Add(pnlMonitorActivityFooter);
        pnlMonitorActivityCard.Controls.Add(lblMonitorActivityTitle);
        pnlMonitorActivityCard.Dock = DockStyle.Fill;
        pnlMonitorActivityCard.Location = new Point(0, 0);
        pnlMonitorActivityCard.Name = "pnlMonitorActivityCard";
        pnlMonitorActivityCard.Padding = new Padding(16, 14, 16, 14);
        pnlMonitorActivityCard.Size = new Size(740, 284);
        pnlMonitorActivityCard.AutoScroll = false;
        pnlMonitorActivityCard.TabIndex = 0;
        // 
        // dgvMonitorActivity
        // 
        dgvMonitorActivity.ColumnHeadersHeight = 29;
        dgvMonitorActivity.Dock = DockStyle.Fill;
        dgvMonitorActivity.Location = new Point(16, 53);
        dgvMonitorActivity.Name = "dgvMonitorActivity";
        dgvMonitorActivity.RowHeadersWidth = 51;
        dgvMonitorActivity.Size = new Size(708, 163);
        dgvMonitorActivity.TabIndex = 2;
        // 
        // pnlMonitorActivityFooter
        // 
        pnlMonitorActivityFooter.Controls.Add(flpMonitorPagination);
        pnlMonitorActivityFooter.Controls.Add(lblMonitorActivityFooter);
        pnlMonitorActivityFooter.Dock = DockStyle.Bottom;
        pnlMonitorActivityFooter.Location = new Point(16, 216);
        pnlMonitorActivityFooter.Name = "pnlMonitorActivityFooter";
        pnlMonitorActivityFooter.Size = new Size(708, 54);
        pnlMonitorActivityFooter.AutoScroll = false;
        pnlMonitorActivityFooter.TabIndex = 1;
        // 
        // flpMonitorPagination
        // 
        flpMonitorPagination.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        flpMonitorPagination.Controls.Add(btnMonitorPagePrev);
        flpMonitorPagination.Controls.Add(btnMonitorPageCurrent);
        flpMonitorPagination.Controls.Add(btnMonitorPageNext);
        flpMonitorPagination.Location = new Point(548, 9);
        flpMonitorPagination.Name = "flpMonitorPagination";
        flpMonitorPagination.Size = new Size(160, 36);
        flpMonitorPagination.AutoScroll = false;
        flpMonitorPagination.TabIndex = 1;
        flpMonitorPagination.WrapContents = false;
        // 
        // btnMonitorPagePrev
        // 
        btnMonitorPagePrev.Location = new Point(3, 3);
        btnMonitorPagePrev.Name = "btnMonitorPagePrev";
        btnMonitorPagePrev.Size = new Size(44, 30);
        btnMonitorPagePrev.TabIndex = 0;
        btnMonitorPagePrev.Text = "<";
        btnMonitorPagePrev.UseVisualStyleBackColor = true;
        // 
        // btnMonitorPageCurrent
        // 
        btnMonitorPageCurrent.Location = new Point(53, 3);
        btnMonitorPageCurrent.Name = "btnMonitorPageCurrent";
        btnMonitorPageCurrent.Size = new Size(44, 30);
        btnMonitorPageCurrent.TabIndex = 1;
        btnMonitorPageCurrent.Text = "1";
        btnMonitorPageCurrent.UseVisualStyleBackColor = true;
        // 
        // btnMonitorPageNext
        // 
        btnMonitorPageNext.Location = new Point(103, 3);
        btnMonitorPageNext.Name = "btnMonitorPageNext";
        btnMonitorPageNext.Size = new Size(44, 30);
        btnMonitorPageNext.TabIndex = 2;
        btnMonitorPageNext.Text = ">";
        btnMonitorPageNext.UseVisualStyleBackColor = true;
        // 
        // lblMonitorActivityFooter
        // 
        lblMonitorActivityFooter.AutoSize = true;
        lblMonitorActivityFooter.Location = new Point(6, 16);
        lblMonitorActivityFooter.Name = "lblMonitorActivityFooter";
        lblMonitorActivityFooter.Size = new Size(293, 28);
        lblMonitorActivityFooter.TabIndex = 0;
        lblMonitorActivityFooter.Text = "HIỂN THỊ 5 TRÊN 4,208 BẢN GHI";
        // 
        // lblMonitorActivityTitle
        // 
        lblMonitorActivityTitle.Dock = DockStyle.Top;
        lblMonitorActivityTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic);
        lblMonitorActivityTitle.Location = new Point(16, 14);
        lblMonitorActivityTitle.Name = "lblMonitorActivityTitle";
        lblMonitorActivityTitle.Size = new Size(708, 39);
        lblMonitorActivityTitle.TabIndex = 0;
        lblMonitorActivityTitle.Text = "NHẬT KÝ HOẠT ĐỘNG CHI TIẾT";
        // 
        // pnlMonitorSourceColumn
        // 
        pnlMonitorSourceColumn.Controls.Add(pnlMonitorHealthCard);
        pnlMonitorSourceColumn.Controls.Add(pnlMonitorSourceCardTeacher);
        pnlMonitorSourceColumn.Controls.Add(pnlMonitorSourceCardStaff);
        pnlMonitorSourceColumn.Controls.Add(lblMonitorSourceTitle);
        pnlMonitorSourceColumn.Dock = DockStyle.Fill;
        pnlMonitorSourceColumn.Location = new Point(16, 0);
        pnlMonitorSourceColumn.Name = "pnlMonitorSourceColumn";
        pnlMonitorSourceColumn.Size = new Size(312, 284);
        pnlMonitorSourceColumn.AutoScroll = false;
        pnlMonitorSourceColumn.TabIndex = 0;
        // 
        // pnlMonitorHealthCard
        // 
        pnlMonitorHealthCard.Controls.Add(lblMonitorHealthFootnote);
        pnlMonitorHealthCard.Controls.Add(tblMonitorHealthMatrix);
        pnlMonitorHealthCard.Controls.Add(lblMonitorHealthTitle);
        pnlMonitorHealthCard.Dock = DockStyle.Top;
        pnlMonitorHealthCard.Location = new Point(0, 387);
        pnlMonitorHealthCard.Margin = new Padding(0);
        pnlMonitorHealthCard.Name = "pnlMonitorHealthCard";
        pnlMonitorHealthCard.Padding = new Padding(16, 14, 16, 16);
        pnlMonitorHealthCard.Size = new Size(312, 176);
        pnlMonitorHealthCard.AutoScroll = false;
        pnlMonitorHealthCard.TabIndex = 3;
        // 
        // lblMonitorHealthFootnote
        // 
        lblMonitorHealthFootnote.Dock = DockStyle.Bottom;
        lblMonitorHealthFootnote.Location = new Point(16, 140);
        lblMonitorHealthFootnote.Name = "lblMonitorHealthFootnote";
        lblMonitorHealthFootnote.Size = new Size(280, 20);
        lblMonitorHealthFootnote.TabIndex = 2;
        lblMonitorHealthFootnote.Text = "* Mỗi ô đại diện cho một cluster logic xử lý dữ liệu";
        // 
        // tblMonitorHealthMatrix
        // 
        tblMonitorHealthMatrix.ColumnCount = 10;
        tblMonitorHealthMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tblMonitorHealthMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tblMonitorHealthMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tblMonitorHealthMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tblMonitorHealthMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tblMonitorHealthMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tblMonitorHealthMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tblMonitorHealthMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tblMonitorHealthMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tblMonitorHealthMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
        tblMonitorHealthMatrix.Controls.Add(pnlHealth01, 0, 0);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth02, 1, 0);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth03, 2, 0);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth04, 3, 0);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth05, 4, 0);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth06, 5, 0);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth07, 6, 0);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth08, 7, 0);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth09, 8, 0);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth10, 9, 0);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth11, 0, 1);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth12, 1, 1);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth13, 2, 1);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth14, 3, 1);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth15, 4, 1);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth16, 5, 1);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth17, 6, 1);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth18, 7, 1);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth19, 8, 1);
        tblMonitorHealthMatrix.Controls.Add(pnlHealth20, 9, 1);
        tblMonitorHealthMatrix.Dock = DockStyle.Top;
        tblMonitorHealthMatrix.Location = new Point(16, 45);
        tblMonitorHealthMatrix.Name = "tblMonitorHealthMatrix";
        tblMonitorHealthMatrix.RowCount = 2;
        tblMonitorHealthMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tblMonitorHealthMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tblMonitorHealthMatrix.Size = new Size(280, 84);
        tblMonitorHealthMatrix.AutoScroll = true;
        tblMonitorHealthMatrix.TabIndex = 1;
        // 
        // pnlHealth01
        // 
        pnlHealth01.Dock = DockStyle.Fill;
        pnlHealth01.Location = new Point(3, 3);
        pnlHealth01.Name = "pnlHealth01";
        pnlHealth01.Size = new Size(22, 36);
        pnlHealth01.AutoScroll = true;
        pnlHealth01.TabIndex = 0;
        // 
        // pnlHealth02
        // 
        pnlHealth02.Dock = DockStyle.Fill;
        pnlHealth02.Location = new Point(31, 3);
        pnlHealth02.Name = "pnlHealth02";
        pnlHealth02.Size = new Size(22, 36);
        pnlHealth02.AutoScroll = true;
        pnlHealth02.TabIndex = 1;
        // 
        // pnlHealth03
        // 
        pnlHealth03.Dock = DockStyle.Fill;
        pnlHealth03.Location = new Point(59, 3);
        pnlHealth03.Name = "pnlHealth03";
        pnlHealth03.Size = new Size(22, 36);
        pnlHealth03.AutoScroll = true;
        pnlHealth03.TabIndex = 2;
        // 
        // pnlHealth04
        // 
        pnlHealth04.Dock = DockStyle.Fill;
        pnlHealth04.Location = new Point(87, 3);
        pnlHealth04.Name = "pnlHealth04";
        pnlHealth04.Size = new Size(22, 36);
        pnlHealth04.AutoScroll = true;
        pnlHealth04.TabIndex = 3;
        // 
        // pnlHealth05
        // 
        pnlHealth05.Dock = DockStyle.Fill;
        pnlHealth05.Location = new Point(115, 3);
        pnlHealth05.Name = "pnlHealth05";
        pnlHealth05.Size = new Size(22, 36);
        pnlHealth05.AutoScroll = true;
        pnlHealth05.TabIndex = 4;
        // 
        // pnlHealth06
        // 
        pnlHealth06.Dock = DockStyle.Fill;
        pnlHealth06.Location = new Point(143, 3);
        pnlHealth06.Name = "pnlHealth06";
        pnlHealth06.Size = new Size(22, 36);
        pnlHealth06.AutoScroll = true;
        pnlHealth06.TabIndex = 5;
        // 
        // pnlHealth07
        // 
        pnlHealth07.Dock = DockStyle.Fill;
        pnlHealth07.Location = new Point(171, 3);
        pnlHealth07.Name = "pnlHealth07";
        pnlHealth07.Size = new Size(22, 36);
        pnlHealth07.AutoScroll = true;
        pnlHealth07.TabIndex = 6;
        // 
        // pnlHealth08
        // 
        pnlHealth08.Dock = DockStyle.Fill;
        pnlHealth08.Location = new Point(199, 3);
        pnlHealth08.Name = "pnlHealth08";
        pnlHealth08.Size = new Size(22, 36);
        pnlHealth08.AutoScroll = true;
        pnlHealth08.TabIndex = 7;
        // 
        // pnlHealth09
        // 
        pnlHealth09.Dock = DockStyle.Fill;
        pnlHealth09.Location = new Point(227, 3);
        pnlHealth09.Name = "pnlHealth09";
        pnlHealth09.Size = new Size(22, 36);
        pnlHealth09.AutoScroll = true;
        pnlHealth09.TabIndex = 8;
        // 
        // pnlHealth10
        // 
        pnlHealth10.Dock = DockStyle.Fill;
        pnlHealth10.Location = new Point(255, 3);
        pnlHealth10.Name = "pnlHealth10";
        pnlHealth10.Size = new Size(22, 36);
        pnlHealth10.AutoScroll = true;
        pnlHealth10.TabIndex = 9;
        // 
        // pnlHealth11
        // 
        pnlHealth11.Dock = DockStyle.Fill;
        pnlHealth11.Location = new Point(3, 45);
        pnlHealth11.Name = "pnlHealth11";
        pnlHealth11.Size = new Size(22, 36);
        pnlHealth11.AutoScroll = true;
        pnlHealth11.TabIndex = 10;
        // 
        // pnlHealth12
        // 
        pnlHealth12.Dock = DockStyle.Fill;
        pnlHealth12.Location = new Point(31, 45);
        pnlHealth12.Name = "pnlHealth12";
        pnlHealth12.Size = new Size(22, 36);
        pnlHealth12.AutoScroll = true;
        pnlHealth12.TabIndex = 11;
        // 
        // pnlHealth13
        // 
        pnlHealth13.Dock = DockStyle.Fill;
        pnlHealth13.Location = new Point(59, 45);
        pnlHealth13.Name = "pnlHealth13";
        pnlHealth13.Size = new Size(22, 36);
        pnlHealth13.AutoScroll = true;
        pnlHealth13.TabIndex = 12;
        // 
        // pnlHealth14
        // 
        pnlHealth14.Dock = DockStyle.Fill;
        pnlHealth14.Location = new Point(87, 45);
        pnlHealth14.Name = "pnlHealth14";
        pnlHealth14.Size = new Size(22, 36);
        pnlHealth14.AutoScroll = true;
        pnlHealth14.TabIndex = 13;
        // 
        // pnlHealth15
        // 
        pnlHealth15.Dock = DockStyle.Fill;
        pnlHealth15.Location = new Point(115, 45);
        pnlHealth15.Name = "pnlHealth15";
        pnlHealth15.Size = new Size(22, 36);
        pnlHealth15.AutoScroll = true;
        pnlHealth15.TabIndex = 14;
        // 
        // pnlHealth16
        // 
        pnlHealth16.Dock = DockStyle.Fill;
        pnlHealth16.Location = new Point(143, 45);
        pnlHealth16.Name = "pnlHealth16";
        pnlHealth16.Size = new Size(22, 36);
        pnlHealth16.AutoScroll = true;
        pnlHealth16.TabIndex = 15;
        // 
        // pnlHealth17
        // 
        pnlHealth17.Dock = DockStyle.Fill;
        pnlHealth17.Location = new Point(171, 45);
        pnlHealth17.Name = "pnlHealth17";
        pnlHealth17.Size = new Size(22, 36);
        pnlHealth17.AutoScroll = true;
        pnlHealth17.TabIndex = 16;
        // 
        // pnlHealth18
        // 
        pnlHealth18.Dock = DockStyle.Fill;
        pnlHealth18.Location = new Point(199, 45);
        pnlHealth18.Name = "pnlHealth18";
        pnlHealth18.Size = new Size(22, 36);
        pnlHealth18.AutoScroll = true;
        pnlHealth18.TabIndex = 17;
        // 
        // pnlHealth19
        // 
        pnlHealth19.Dock = DockStyle.Fill;
        pnlHealth19.Location = new Point(227, 45);
        pnlHealth19.Name = "pnlHealth19";
        pnlHealth19.Size = new Size(22, 36);
        pnlHealth19.AutoScroll = true;
        pnlHealth19.TabIndex = 18;
        // 
        // pnlHealth20
        // 
        pnlHealth20.Dock = DockStyle.Fill;
        pnlHealth20.Location = new Point(255, 45);
        pnlHealth20.Name = "pnlHealth20";
        pnlHealth20.Size = new Size(22, 36);
        pnlHealth20.AutoScroll = true;
        pnlHealth20.TabIndex = 19;
        // 
        // lblMonitorHealthTitle
        // 
        lblMonitorHealthTitle.Dock = DockStyle.Top;
        lblMonitorHealthTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblMonitorHealthTitle.Location = new Point(16, 14);
        lblMonitorHealthTitle.Name = "lblMonitorHealthTitle";
        lblMonitorHealthTitle.Size = new Size(280, 31);
        lblMonitorHealthTitle.TabIndex = 0;
        lblMonitorHealthTitle.Text = "MA TRẬN SỨC KHỎE HỆ THỐNG";
        // 
        // pnlMonitorSourceCardTeacher
        // 
        pnlMonitorSourceCardTeacher.Controls.Add(lblMonitorSourceTeacherLive);
        pnlMonitorSourceCardTeacher.Controls.Add(lblMonitorSourceTeacherRate2);
        pnlMonitorSourceCardTeacher.Controls.Add(prgMonitorSourceTeacher2);
        pnlMonitorSourceCardTeacher.Controls.Add(lblMonitorSourceTeacherRate1);
        pnlMonitorSourceCardTeacher.Controls.Add(prgMonitorSourceTeacher1);
        pnlMonitorSourceCardTeacher.Controls.Add(lblMonitorSourceTeacherTitle);
        pnlMonitorSourceCardTeacher.Dock = DockStyle.Top;
        pnlMonitorSourceCardTeacher.Location = new Point(0, 201);
        pnlMonitorSourceCardTeacher.Margin = new Padding(0, 0, 0, 14);
        pnlMonitorSourceCardTeacher.Name = "pnlMonitorSourceCardTeacher";
        pnlMonitorSourceCardTeacher.Padding = new Padding(16, 14, 16, 16);
        pnlMonitorSourceCardTeacher.Size = new Size(312, 186);
        pnlMonitorSourceCardTeacher.AutoScroll = true;
        pnlMonitorSourceCardTeacher.TabIndex = 2;
        // 
        // lblMonitorSourceTeacherLive
        // 
        lblMonitorSourceTeacherLive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblMonitorSourceTeacherLive.AutoSize = true;
        lblMonitorSourceTeacherLive.Location = new Point(253, 18);
        lblMonitorSourceTeacherLive.Name = "lblMonitorSourceTeacherLive";
        lblMonitorSourceTeacherLive.Size = new Size(48, 28);
        lblMonitorSourceTeacherLive.TabIndex = 5;
        lblMonitorSourceTeacherLive.Text = "LIVE";
        // 
        // lblMonitorSourceTeacherRate2
        // 
        lblMonitorSourceTeacherRate2.AutoSize = true;
        lblMonitorSourceTeacherRate2.Location = new Point(16, 113);
        lblMonitorSourceTeacherRate2.Name = "lblMonitorSourceTeacherRate2";
        lblMonitorSourceTeacherRate2.Size = new Size(170, 28);
        lblMonitorSourceTeacherRate2.TabIndex = 4;
        lblMonitorSourceTeacherRate2.Text = "Hệ thống Điểm số";
        // 
        // prgMonitorSourceTeacher2
        // 
        prgMonitorSourceTeacher2.Location = new Point(16, 138);
        prgMonitorSourceTeacher2.Name = "prgMonitorSourceTeacher2";
        prgMonitorSourceTeacher2.Size = new Size(260, 12);
        prgMonitorSourceTeacher2.TabIndex = 3;
        // 
        // lblMonitorSourceTeacherRate1
        // 
        lblMonitorSourceTeacherRate1.AutoSize = true;
        lblMonitorSourceTeacherRate1.Location = new Point(16, 58);
        lblMonitorSourceTeacherRate1.Name = "lblMonitorSourceTeacherRate1";
        lblMonitorSourceTeacherRate1.Size = new Size(180, 28);
        lblMonitorSourceTeacherRate1.TabIndex = 2;
        lblMonitorSourceTeacherRate1.Text = "Nhật ký Điểm danh";
        // 
        // prgMonitorSourceTeacher1
        // 
        prgMonitorSourceTeacher1.Location = new Point(16, 83);
        prgMonitorSourceTeacher1.Name = "prgMonitorSourceTeacher1";
        prgMonitorSourceTeacher1.Size = new Size(260, 12);
        prgMonitorSourceTeacher1.TabIndex = 1;
        // 
        // lblMonitorSourceTeacherTitle
        // 
        lblMonitorSourceTeacherTitle.AutoSize = true;
        lblMonitorSourceTeacherTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblMonitorSourceTeacherTitle.Location = new Point(13, 31);
        lblMonitorSourceTeacherTitle.Name = "lblMonitorSourceTeacherTitle";
        lblMonitorSourceTeacherTitle.Size = new Size(230, 30);
        lblMonitorSourceTeacherTitle.TabIndex = 0;
        lblMonitorSourceTeacherTitle.Text = "LUỒNG: GIẢNG VIÊN";
        // 
        // pnlMonitorSourceCardStaff
        // 
        pnlMonitorSourceCardStaff.Controls.Add(lblMonitorSourceStaffLive);
        pnlMonitorSourceCardStaff.Controls.Add(lblMonitorSourceStaffRate2);
        pnlMonitorSourceCardStaff.Controls.Add(prgMonitorSourceStaff2);
        pnlMonitorSourceCardStaff.Controls.Add(lblMonitorSourceStaffRate1);
        pnlMonitorSourceCardStaff.Controls.Add(prgMonitorSourceStaff1);
        pnlMonitorSourceCardStaff.Controls.Add(lblMonitorSourceStaffTitle);
        pnlMonitorSourceCardStaff.Dock = DockStyle.Top;
        pnlMonitorSourceCardStaff.Location = new Point(0, 53);
        pnlMonitorSourceCardStaff.Margin = new Padding(0, 0, 0, 14);
        pnlMonitorSourceCardStaff.Name = "pnlMonitorSourceCardStaff";
        pnlMonitorSourceCardStaff.Padding = new Padding(16, 14, 16, 16);
        pnlMonitorSourceCardStaff.Size = new Size(312, 148);
        pnlMonitorSourceCardStaff.AutoScroll = true;
        pnlMonitorSourceCardStaff.TabIndex = 1;
        // 
        // lblMonitorSourceStaffLive
        // 
        lblMonitorSourceStaffLive.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblMonitorSourceStaffLive.AutoSize = true;
        lblMonitorSourceStaffLive.Location = new Point(251, 14);
        lblMonitorSourceStaffLive.Name = "lblMonitorSourceStaffLive";
        lblMonitorSourceStaffLive.Size = new Size(48, 28);
        lblMonitorSourceStaffLive.TabIndex = 5;
        lblMonitorSourceStaffLive.Text = "LIVE";
        // 
        // lblMonitorSourceStaffRate2
        // 
        lblMonitorSourceStaffRate2.AutoSize = true;
        lblMonitorSourceStaffRate2.Location = new Point(16, 88);
        lblMonitorSourceStaffRate2.Name = "lblMonitorSourceStaffRate2";
        lblMonitorSourceStaffRate2.Size = new Size(198, 28);
        lblMonitorSourceStaffRate2.TabIndex = 4;
        lblMonitorSourceStaffRate2.Text = "Giao dịch Thanh toán";
        // 
        // prgMonitorSourceStaff2
        // 
        prgMonitorSourceStaff2.Location = new Point(16, 113);
        prgMonitorSourceStaff2.Name = "prgMonitorSourceStaff2";
        prgMonitorSourceStaff2.Size = new Size(260, 12);
        prgMonitorSourceStaff2.TabIndex = 3;
        // 
        // lblMonitorSourceStaffRate1
        // 
        lblMonitorSourceStaffRate1.AutoSize = true;
        lblMonitorSourceStaffRate1.Location = new Point(16, 51);
        lblMonitorSourceStaffRate1.Name = "lblMonitorSourceStaffRate1";
        lblMonitorSourceStaffRate1.Size = new Size(147, 28);
        lblMonitorSourceStaffRate1.TabIndex = 2;
        lblMonitorSourceStaffRate1.Text = "Hồ sơ Ghi danh";
        // 
        // prgMonitorSourceStaff1
        // 
        prgMonitorSourceStaff1.Location = new Point(16, 76);
        prgMonitorSourceStaff1.Name = "prgMonitorSourceStaff1";
        prgMonitorSourceStaff1.Size = new Size(260, 12);
        prgMonitorSourceStaff1.TabIndex = 1;
        // 
        // lblMonitorSourceStaffTitle
        // 
        lblMonitorSourceStaffTitle.AutoSize = true;
        lblMonitorSourceStaffTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblMonitorSourceStaffTitle.Location = new Point(13, 26);
        lblMonitorSourceStaffTitle.Name = "lblMonitorSourceStaffTitle";
        lblMonitorSourceStaffTitle.Size = new Size(225, 30);
        lblMonitorSourceStaffTitle.TabIndex = 0;
        lblMonitorSourceStaffTitle.Text = "LUỒNG: NHÂN VIÊN";
        // 
        // lblMonitorSourceTitle
        // 
        lblMonitorSourceTitle.Dock = DockStyle.Top;
        lblMonitorSourceTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic);
        lblMonitorSourceTitle.Location = new Point(0, 0);
        lblMonitorSourceTitle.Name = "lblMonitorSourceTitle";
        lblMonitorSourceTitle.Size = new Size(312, 53);
        lblMonitorSourceTitle.TabIndex = 0;
        lblMonitorSourceTitle.Text = "NGUỒN DỮ LIỆU";
        // 
        // FrmSystemMonitor
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(241, 248, 255);
        ClientSize = new Size(1120, 720);
        Controls.Add(tblMonitorRoot);
        Font = new Font("Segoe UI", 10F);
        MinimumSize = new Size(980, 640);
        Name = "FrmSystemMonitor";
        Padding = new Padding(16);
        Text = "Giám sát hệ thống";
        tblMonitorRoot.ResumeLayout(false);
        pnlMonitorHeader.ResumeLayout(false);
        pnlMonitorHeader.PerformLayout();
        pnlSystemMonitorFilterCard.ResumeLayout(false);
        tblMonitorFilter.ResumeLayout(false);
        tblMonitorFilter.PerformLayout();
        flpMonitorActions.ResumeLayout(false);
        tblMonitorKpi.ResumeLayout(false);
        pnlMonitorStudentCount.ResumeLayout(false);
        pnlMonitorStudentCount.PerformLayout();
        pnlMonitorEnrollmentCount.ResumeLayout(false);
        pnlMonitorEnrollmentCount.PerformLayout();
        pnlMonitorReceiptCount.ResumeLayout(false);
        pnlMonitorReceiptCount.PerformLayout();
        pnlMonitorDebtTotal.ResumeLayout(false);
        pnlMonitorDebtTotal.PerformLayout();
        splMonitorMain.Panel1.ResumeLayout(false);
        splMonitorMain.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splMonitorMain).EndInit();
        splMonitorMain.ResumeLayout(false);
        pnlMonitorActivityCard.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvMonitorActivity).EndInit();
        pnlMonitorActivityFooter.ResumeLayout(false);
        pnlMonitorActivityFooter.PerformLayout();
        flpMonitorPagination.ResumeLayout(false);
        pnlMonitorSourceColumn.ResumeLayout(false);
        pnlMonitorHealthCard.ResumeLayout(false);
        tblMonitorHealthMatrix.ResumeLayout(false);
        pnlMonitorSourceCardTeacher.ResumeLayout(false);
        pnlMonitorSourceCardTeacher.PerformLayout();
        pnlMonitorSourceCardStaff.ResumeLayout(false);
        pnlMonitorSourceCardStaff.PerformLayout();
        AutoScroll = true;
        ResumeLayout(false);
    }
}

