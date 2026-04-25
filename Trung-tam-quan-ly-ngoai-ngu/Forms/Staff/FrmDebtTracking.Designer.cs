namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmDebtTracking
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tblDebtRoot;
    private Panel pnlDebtFilterCard;
    private TableLayoutPanel tblDebtFilterShell;
    private Panel pnlDebtFilterAccent;
    private TableLayoutPanel tblDebtFilterLayout;
    private Label lblDebtCourseFilter;
    private ComboBox cboDebtCourseFilter;
    private Label lblDebtClassFilter;
    private ComboBox cboDebtClassFilter;
    private Label lblDebtFromDate;
    private DateTimePicker dtpDebtFromDate;
    private Label lblDebtToDate;
    private DateTimePicker dtpDebtToDate;
    private FlowLayoutPanel flpDebtFilterActions;
    private Button btnSearchDebt;
    private Button btnRefreshDebt;
    private TableLayoutPanel tblDebtKpi;
    private Panel pnlDebtTotalCount;
    private Label lblDebtTotalCountBadge;
    private Label lblDebtTotalCountTitle;
    private Label lblDebtTotalCountValue;
    private Panel pnlDebtTotalCountAccent;
    private Panel pnlDebtTotalAmount;
    private Label lblDebtTotalAmountBadge;
    private Label lblDebtTotalAmountTitle;
    private Label lblDebtTotalAmountValue;
    private Label lblDebtTotalAmountUnit;
    private Panel pnlDebtTotalAmountAccent;
    private Panel pnlDebtDueSoon;
    private Label lblDebtDueSoonBadge;
    private Label lblDebtDueSoonTitle;
    private Label lblDebtDueSoonValue;
    private Panel pnlDebtDueSoonAccent;
    private Panel pnlDebtSectionCard;
    private TableLayoutPanel tblDebtSectionLayout;
    private TableLayoutPanel tblDebtSectionHeader;
    private Label lblDebtSectionTitle;
    private Label lblDebtUpdatedAt;
    private FlowLayoutPanel flpDebtActions;
    private Button btnOpenTuitionFromDebt;
    private Button btnExportDebt;
    private Button btnExportPdfDebt;
    private Panel pnlDebtGridHost;
    private DataGridView dgvDebtTrackingList;
    private TableLayoutPanel tblDebtFooter;
    private Label lblDebtFooterSummary;
    private FlowLayoutPanel flpDebtPager;
    private Button btnDebtPagePrev;
    private Button btnDebtPage1;
    private Button btnDebtPage2;
    private Button btnDebtPage3;
    private Label lblDebtPageDots;
    private Button btnDebtPageNext;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        tblDebtRoot = new TableLayoutPanel();
        pnlDebtFilterCard = new Panel();
        tblDebtFilterShell = new TableLayoutPanel();
        pnlDebtFilterAccent = new Panel();
        tblDebtFilterLayout = new TableLayoutPanel();
        lblDebtCourseFilter = new Label();
        cboDebtCourseFilter = new ComboBox();
        lblDebtClassFilter = new Label();
        cboDebtClassFilter = new ComboBox();
        lblDebtFromDate = new Label();
        dtpDebtFromDate = new DateTimePicker();
        lblDebtToDate = new Label();
        dtpDebtToDate = new DateTimePicker();
        flpDebtFilterActions = new FlowLayoutPanel();
        btnSearchDebt = new Button();
        btnRefreshDebt = new Button();
        tblDebtKpi = new TableLayoutPanel();
        pnlDebtTotalCount = new Panel();
        lblDebtTotalCountBadge = new Label();
        lblDebtTotalCountValue = new Label();
        lblDebtTotalCountTitle = new Label();
        pnlDebtTotalCountAccent = new Panel();
        pnlDebtTotalAmount = new Panel();
        lblDebtTotalAmountBadge = new Label();
        lblDebtTotalAmountUnit = new Label();
        lblDebtTotalAmountValue = new Label();
        lblDebtTotalAmountTitle = new Label();
        pnlDebtTotalAmountAccent = new Panel();
        pnlDebtDueSoon = new Panel();
        lblDebtDueSoonBadge = new Label();
        lblDebtDueSoonValue = new Label();
        lblDebtDueSoonTitle = new Label();
        pnlDebtDueSoonAccent = new Panel();
        pnlDebtSectionCard = new Panel();
        tblDebtSectionLayout = new TableLayoutPanel();
        tblDebtSectionHeader = new TableLayoutPanel();
        lblDebtSectionTitle = new Label();
        lblDebtUpdatedAt = new Label();
        flpDebtActions = new FlowLayoutPanel();
        btnOpenTuitionFromDebt = new Button();
        btnExportDebt = new Button();
        btnExportPdfDebt = new Button();
        pnlDebtGridHost = new Panel();
        dgvDebtTrackingList = new DataGridView();
        tblDebtFooter = new TableLayoutPanel();
        lblDebtFooterSummary = new Label();
        flpDebtPager = new FlowLayoutPanel();
        btnDebtPagePrev = new Button();
        btnDebtPage1 = new Button();
        btnDebtPage2 = new Button();
        btnDebtPage3 = new Button();
        lblDebtPageDots = new Label();
        btnDebtPageNext = new Button();
        tblDebtRoot.SuspendLayout();
        pnlDebtFilterCard.SuspendLayout();
        tblDebtFilterShell.SuspendLayout();
        tblDebtFilterLayout.SuspendLayout();
        flpDebtFilterActions.SuspendLayout();
        tblDebtKpi.SuspendLayout();
        pnlDebtTotalCount.SuspendLayout();
        pnlDebtTotalAmount.SuspendLayout();
        pnlDebtDueSoon.SuspendLayout();
        pnlDebtSectionCard.SuspendLayout();
        tblDebtSectionLayout.SuspendLayout();
        tblDebtSectionHeader.SuspendLayout();
        flpDebtActions.SuspendLayout();
        pnlDebtGridHost.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDebtTrackingList).BeginInit();
        tblDebtFooter.SuspendLayout();
        flpDebtPager.SuspendLayout();
        SuspendLayout();
        // 
        // tblDebtRoot
        // 
        tblDebtRoot.ColumnCount = 1;
        tblDebtRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblDebtRoot.Controls.Add(pnlDebtFilterCard, 0, 0);
        tblDebtRoot.Controls.Add(tblDebtKpi, 0, 1);
        tblDebtRoot.Controls.Add(pnlDebtSectionCard, 0, 2);
        tblDebtRoot.Dock = DockStyle.Fill;
        tblDebtRoot.Location = new Point(20, 18);
        tblDebtRoot.Name = "tblDebtRoot";
        tblDebtRoot.RowCount = 3;
        tblDebtRoot.RowStyles.Add(new RowStyle());
        tblDebtRoot.RowStyles.Add(new RowStyle());
        tblDebtRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblDebtRoot.Size = new Size(1160, 684);
        tblDebtRoot.TabIndex = 0;
        // 
        // pnlDebtFilterCard
        // 
        pnlDebtFilterCard.BorderStyle = BorderStyle.FixedSingle;
        pnlDebtFilterCard.Controls.Add(tblDebtFilterShell);
        pnlDebtFilterCard.Dock = DockStyle.Fill;
        pnlDebtFilterCard.Location = new Point(3, 3);
        pnlDebtFilterCard.Name = "pnlDebtFilterCard";
        pnlDebtFilterCard.Padding = new Padding(20, 18, 20, 18);
        pnlDebtFilterCard.Size = new Size(1154, 130);
        pnlDebtFilterCard.TabIndex = 0;
        // 
        // tblDebtFilterShell
        // 
        tblDebtFilterShell.ColumnCount = 2;
        tblDebtFilterShell.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 6F));
        tblDebtFilterShell.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblDebtFilterShell.Controls.Add(pnlDebtFilterAccent, 0, 0);
        tblDebtFilterShell.Controls.Add(tblDebtFilterLayout, 1, 0);
        tblDebtFilterShell.Dock = DockStyle.Fill;
        tblDebtFilterShell.Location = new Point(20, 18);
        tblDebtFilterShell.Name = "tblDebtFilterShell";
        tblDebtFilterShell.RowCount = 1;
        tblDebtFilterShell.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblDebtFilterShell.Size = new Size(1112, 92);
        tblDebtFilterShell.TabIndex = 0;
        // 
        // pnlDebtFilterAccent
        // 
        pnlDebtFilterAccent.BackColor = Color.FromArgb(0, 96, 168);
        pnlDebtFilterAccent.Dock = DockStyle.Top;
        pnlDebtFilterAccent.Location = new Point(0, 8);
        pnlDebtFilterAccent.Margin = new Padding(0, 8, 18, 8);
        pnlDebtFilterAccent.Name = "pnlDebtFilterAccent";
        pnlDebtFilterAccent.Size = new Size(6, 76);
        pnlDebtFilterAccent.TabIndex = 0;
        // 
        // tblDebtFilterLayout
        // 
        tblDebtFilterLayout.ColumnCount = 5;
        tblDebtFilterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
        tblDebtFilterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
        tblDebtFilterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tblDebtFilterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        tblDebtFilterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
        tblDebtFilterLayout.Controls.Add(lblDebtCourseFilter, 0, 0);
        tblDebtFilterLayout.Controls.Add(cboDebtCourseFilter, 0, 1);
        tblDebtFilterLayout.Controls.Add(lblDebtClassFilter, 1, 0);
        tblDebtFilterLayout.Controls.Add(cboDebtClassFilter, 1, 1);
        tblDebtFilterLayout.Controls.Add(lblDebtFromDate, 2, 0);
        tblDebtFilterLayout.Controls.Add(dtpDebtFromDate, 2, 1);
        tblDebtFilterLayout.Controls.Add(lblDebtToDate, 3, 0);
        tblDebtFilterLayout.Controls.Add(dtpDebtToDate, 3, 1);
        tblDebtFilterLayout.Controls.Add(flpDebtFilterActions, 4, 0);
        tblDebtFilterLayout.Dock = DockStyle.Fill;
        tblDebtFilterLayout.Location = new Point(24, 0);
        tblDebtFilterLayout.Margin = new Padding(18, 0, 0, 0);
        tblDebtFilterLayout.Name = "tblDebtFilterLayout";
        tblDebtFilterLayout.RowCount = 2;
        tblDebtFilterLayout.RowStyles.Add(new RowStyle());
        tblDebtFilterLayout.RowStyles.Add(new RowStyle());
        tblDebtFilterLayout.Size = new Size(1088, 92);
        tblDebtFilterLayout.TabIndex = 1;
        // 
        // lblDebtCourseFilter
        // 
        lblDebtCourseFilter.Anchor = AnchorStyles.Left;
        lblDebtCourseFilter.AutoSize = true;
        lblDebtCourseFilter.Location = new Point(3, 8);
        lblDebtCourseFilter.Margin = new Padding(3, 8, 3, 10);
        lblDebtCourseFilter.Name = "lblDebtCourseFilter";
        lblDebtCourseFilter.Size = new Size(75, 20);
        lblDebtCourseFilter.TabIndex = 0;
        lblDebtCourseFilter.Text = "KhÃ³a há»c";
        // 
        // cboDebtCourseFilter
        // 
        cboDebtCourseFilter.Dock = DockStyle.Fill;
        cboDebtCourseFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cboDebtCourseFilter.FormattingEnabled = true;
        cboDebtCourseFilter.Location = new Point(3, 41);
        cboDebtCourseFilter.Name = "cboDebtCourseFilter";
        cboDebtCourseFilter.Size = new Size(255, 28);
        cboDebtCourseFilter.TabIndex = 1;
        // 
        // lblDebtClassFilter
        // 
        lblDebtClassFilter.Anchor = AnchorStyles.Left;
        lblDebtClassFilter.AutoSize = true;
        lblDebtClassFilter.Location = new Point(264, 8);
        lblDebtClassFilter.Margin = new Padding(3, 8, 3, 10);
        lblDebtClassFilter.Name = "lblDebtClassFilter";
        lblDebtClassFilter.Size = new Size(65, 20);
        lblDebtClassFilter.TabIndex = 2;
        lblDebtClassFilter.Text = "Lá»›p há»c";
        // 
        // cboDebtClassFilter
        // 
        cboDebtClassFilter.Dock = DockStyle.Fill;
        cboDebtClassFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cboDebtClassFilter.FormattingEnabled = true;
        cboDebtClassFilter.Location = new Point(264, 41);
        cboDebtClassFilter.Name = "cboDebtClassFilter";
        cboDebtClassFilter.Size = new Size(255, 28);
        cboDebtClassFilter.TabIndex = 3;
        // 
        // lblDebtFromDate
        // 
        lblDebtFromDate.Anchor = AnchorStyles.Left;
        lblDebtFromDate.AutoSize = true;
        lblDebtFromDate.Location = new Point(525, 8);
        lblDebtFromDate.Margin = new Padding(3, 8, 3, 10);
        lblDebtFromDate.Name = "lblDebtFromDate";
        lblDebtFromDate.Size = new Size(60, 20);
        lblDebtFromDate.TabIndex = 4;
        lblDebtFromDate.Text = "Tá»« ngÃ y";
        // 
        // dtpDebtFromDate
        // 
        dtpDebtFromDate.Dock = DockStyle.Fill;
        dtpDebtFromDate.Format = DateTimePickerFormat.Short;
        dtpDebtFromDate.Location = new Point(525, 41);
        dtpDebtFromDate.Name = "dtpDebtFromDate";
        dtpDebtFromDate.Size = new Size(211, 27);
        dtpDebtFromDate.TabIndex = 5;
        // 
        // lblDebtToDate
        // 
        lblDebtToDate.Anchor = AnchorStyles.Left;
        lblDebtToDate.AutoSize = true;
        lblDebtToDate.Location = new Point(742, 8);
        lblDebtToDate.Margin = new Padding(3, 8, 3, 10);
        lblDebtToDate.Name = "lblDebtToDate";
        lblDebtToDate.Size = new Size(69, 20);
        lblDebtToDate.TabIndex = 6;
        lblDebtToDate.Text = "Äáº¿n ngÃ y";
        // 
        // dtpDebtToDate
        // 
        dtpDebtToDate.Dock = DockStyle.Fill;
        dtpDebtToDate.Format = DateTimePickerFormat.Short;
        dtpDebtToDate.Location = new Point(742, 41);
        dtpDebtToDate.Name = "dtpDebtToDate";
        dtpDebtToDate.Size = new Size(211, 27);
        dtpDebtToDate.TabIndex = 7;
        // 
        // flpDebtFilterActions
        // 
        flpDebtFilterActions.AutoSize = true;
        flpDebtFilterActions.Controls.Add(btnSearchDebt);
        flpDebtFilterActions.Controls.Add(btnRefreshDebt);
        flpDebtFilterActions.Dock = DockStyle.Fill;
        flpDebtFilterActions.FlowDirection = FlowDirection.TopDown;
        flpDebtFilterActions.Location = new Point(959, 0);
        flpDebtFilterActions.Margin = new Padding(6, 0, 0, 0);
        flpDebtFilterActions.Name = "flpDebtFilterActions";
        tblDebtFilterLayout.SetRowSpan(flpDebtFilterActions, 2);
        flpDebtFilterActions.Size = new Size(129, 92);
        flpDebtFilterActions.TabIndex = 8;
        // 
        // btnSearchDebt
        // 
        btnSearchDebt.Location = new Point(3, 3);
        btnSearchDebt.Name = "btnSearchDebt";
        btnSearchDebt.Size = new Size(116, 38);
        btnSearchDebt.TabIndex = 0;
        btnSearchDebt.Text = "Lá»c dá»¯ liá»‡u";
        btnSearchDebt.UseVisualStyleBackColor = true;
        // 
        // btnRefreshDebt
        // 
        btnRefreshDebt.Location = new Point(3, 47);
        btnRefreshDebt.Name = "btnRefreshDebt";
        btnRefreshDebt.Size = new Size(116, 38);
        btnRefreshDebt.TabIndex = 1;
        btnRefreshDebt.Text = "LÃ m má»›i";
        btnRefreshDebt.UseVisualStyleBackColor = true;
        // 
        // tblDebtKpi
        // 
        tblDebtKpi.ColumnCount = 3;
        tblDebtKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tblDebtKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tblDebtKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tblDebtKpi.Controls.Add(pnlDebtTotalCount, 0, 0);
        tblDebtKpi.Controls.Add(pnlDebtTotalAmount, 1, 0);
        tblDebtKpi.Controls.Add(pnlDebtDueSoon, 2, 0);
        tblDebtKpi.Dock = DockStyle.Fill;
        tblDebtKpi.Location = new Point(3, 139);
        tblDebtKpi.Name = "tblDebtKpi";
        tblDebtKpi.RowCount = 1;
        tblDebtKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblDebtKpi.Size = new Size(1154, 130);
        tblDebtKpi.TabIndex = 1;
        // 
        // pnlDebtTotalCount
        // 
        pnlDebtTotalCount.BorderStyle = BorderStyle.FixedSingle;
        pnlDebtTotalCount.Controls.Add(lblDebtTotalCountBadge);
        pnlDebtTotalCount.Controls.Add(lblDebtTotalCountValue);
        pnlDebtTotalCount.Controls.Add(lblDebtTotalCountTitle);
        pnlDebtTotalCount.Controls.Add(pnlDebtTotalCountAccent);
        pnlDebtTotalCount.Dock = DockStyle.Fill;
        pnlDebtTotalCount.Location = new Point(0, 0);
        pnlDebtTotalCount.Margin = new Padding(0, 0, 16, 0);
        pnlDebtTotalCount.Name = "pnlDebtTotalCount";
        pnlDebtTotalCount.Padding = new Padding(22, 18, 22, 18);
        pnlDebtTotalCount.Size = new Size(368, 130);
        pnlDebtTotalCount.TabIndex = 0;
        // 
        // lblDebtTotalCountBadge
        // 
        lblDebtTotalCountBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblDebtTotalCountBadge.BackColor = Color.FromArgb(214, 246, 247);
        lblDebtTotalCountBadge.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        lblDebtTotalCountBadge.ForeColor = Color.FromArgb(0, 110, 110);
        lblDebtTotalCountBadge.Location = new Point(292, 26);
        lblDebtTotalCountBadge.Name = "lblDebtTotalCountBadge";
        lblDebtTotalCountBadge.Size = new Size(46, 46);
        lblDebtTotalCountBadge.TabIndex = 3;
        lblDebtTotalCountBadge.Text = "HV";
        lblDebtTotalCountBadge.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblDebtTotalCountValue
        // 
        lblDebtTotalCountValue.AutoSize = true;
        lblDebtTotalCountValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
        lblDebtTotalCountValue.Location = new Point(22, 46);
        lblDebtTotalCountValue.Name = "lblDebtTotalCountValue";
        lblDebtTotalCountValue.Size = new Size(68, 54);
        lblDebtTotalCountValue.TabIndex = 2;
        lblDebtTotalCountValue.Text = "12";
        // 
        // lblDebtTotalCountTitle
        // 
        lblDebtTotalCountTitle.AutoSize = true;
        lblDebtTotalCountTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblDebtTotalCountTitle.Location = new Point(22, 18);
        lblDebtTotalCountTitle.Name = "lblDebtTotalCountTitle";
        lblDebtTotalCountTitle.Size = new Size(124, 23);
        lblDebtTotalCountTitle.TabIndex = 1;
        lblDebtTotalCountTitle.Text = "Há»c viÃªn ná»£ phÃ­";
        // 
        // pnlDebtTotalCountAccent
        // 
        pnlDebtTotalCountAccent.BackColor = Color.FromArgb(0, 110, 110);
        pnlDebtTotalCountAccent.Dock = DockStyle.Bottom;
        pnlDebtTotalCountAccent.Location = new Point(22, 109);
        pnlDebtTotalCountAccent.Name = "pnlDebtTotalCountAccent";
        pnlDebtTotalCountAccent.Size = new Size(322, 1);
        pnlDebtTotalCountAccent.TabIndex = 0;
        // 
        // pnlDebtTotalAmount
        // 
        pnlDebtTotalAmount.BorderStyle = BorderStyle.FixedSingle;
        pnlDebtTotalAmount.Controls.Add(lblDebtTotalAmountBadge);
        pnlDebtTotalAmount.Controls.Add(lblDebtTotalAmountUnit);
        pnlDebtTotalAmount.Controls.Add(lblDebtTotalAmountValue);
        pnlDebtTotalAmount.Controls.Add(lblDebtTotalAmountTitle);
        pnlDebtTotalAmount.Controls.Add(pnlDebtTotalAmountAccent);
        pnlDebtTotalAmount.Dock = DockStyle.Fill;
        pnlDebtTotalAmount.Location = new Point(384, 0);
        pnlDebtTotalAmount.Margin = new Padding(0, 0, 16, 0);
        pnlDebtTotalAmount.Name = "pnlDebtTotalAmount";
        pnlDebtTotalAmount.Padding = new Padding(22, 18, 22, 18);
        pnlDebtTotalAmount.Size = new Size(368, 130);
        pnlDebtTotalAmount.TabIndex = 1;
        // 
        // lblDebtTotalAmountBadge
        // 
        lblDebtTotalAmountBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblDebtTotalAmountBadge.BackColor = Color.FromArgb(227, 238, 253);
        lblDebtTotalAmountBadge.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        lblDebtTotalAmountBadge.ForeColor = Color.FromArgb(0, 96, 168);
        lblDebtTotalAmountBadge.Location = new Point(292, 26);
        lblDebtTotalAmountBadge.Name = "lblDebtTotalAmountBadge";
        lblDebtTotalAmountBadge.Size = new Size(46, 46);
        lblDebtTotalAmountBadge.TabIndex = 4;
        lblDebtTotalAmountBadge.Text = "VND";
        lblDebtTotalAmountBadge.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblDebtTotalAmountUnit
        // 
        lblDebtTotalAmountUnit.AutoSize = true;
        lblDebtTotalAmountUnit.ForeColor = Color.FromArgb(102, 112, 133);
        lblDebtTotalAmountUnit.Location = new Point(22, 88);
        lblDebtTotalAmountUnit.Name = "lblDebtTotalAmountUnit";
        lblDebtTotalAmountUnit.Size = new Size(37, 20);
        lblDebtTotalAmountUnit.TabIndex = 3;
        lblDebtTotalAmountUnit.Text = "VND";
        // 
        // lblDebtTotalAmountValue
        // 
        lblDebtTotalAmountValue.AutoSize = true;
        lblDebtTotalAmountValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
        lblDebtTotalAmountValue.Location = new Point(22, 41);
        lblDebtTotalAmountValue.Name = "lblDebtTotalAmountValue";
        lblDebtTotalAmountValue.Size = new Size(202, 50);
        lblDebtTotalAmountValue.TabIndex = 2;
        lblDebtTotalAmountValue.Text = "1.250.000";
        // 
        // lblDebtTotalAmountTitle
        // 
        lblDebtTotalAmountTitle.AutoSize = true;
        lblDebtTotalAmountTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblDebtTotalAmountTitle.Location = new Point(22, 18);
        lblDebtTotalAmountTitle.Name = "lblDebtTotalAmountTitle";
        lblDebtTotalAmountTitle.Size = new Size(124, 23);
        lblDebtTotalAmountTitle.TabIndex = 1;
        lblDebtTotalAmountTitle.Text = "Tá»•ng ná»£ cÃ´ng bá»‘";
        // 
        // pnlDebtTotalAmountAccent
        // 
        pnlDebtTotalAmountAccent.BackColor = Color.FromArgb(0, 96, 168);
        pnlDebtTotalAmountAccent.Dock = DockStyle.Bottom;
        pnlDebtTotalAmountAccent.Location = new Point(22, 109);
        pnlDebtTotalAmountAccent.Name = "pnlDebtTotalAmountAccent";
        pnlDebtTotalAmountAccent.Size = new Size(322, 1);
        pnlDebtTotalAmountAccent.TabIndex = 0;
        // 
        // pnlDebtDueSoon
        // 
        pnlDebtDueSoon.BorderStyle = BorderStyle.FixedSingle;
        pnlDebtDueSoon.Controls.Add(lblDebtDueSoonBadge);
        pnlDebtDueSoon.Controls.Add(lblDebtDueSoonValue);
        pnlDebtDueSoon.Controls.Add(lblDebtDueSoonTitle);
        pnlDebtDueSoon.Controls.Add(pnlDebtDueSoonAccent);
        pnlDebtDueSoon.Dock = DockStyle.Fill;
        pnlDebtDueSoon.Location = new Point(768, 0);
        pnlDebtDueSoon.Margin = new Padding(0);
        pnlDebtDueSoon.Name = "pnlDebtDueSoon";
        pnlDebtDueSoon.Padding = new Padding(22, 18, 22, 18);
        pnlDebtDueSoon.Size = new Size(386, 130);
        pnlDebtDueSoon.TabIndex = 2;
        // 
        // lblDebtDueSoonBadge
        // 
        lblDebtDueSoonBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblDebtDueSoonBadge.BackColor = Color.FromArgb(255, 233, 233);
        lblDebtDueSoonBadge.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
        lblDebtDueSoonBadge.ForeColor = Color.FromArgb(224, 91, 97);
        lblDebtDueSoonBadge.Location = new Point(308, 26);
        lblDebtDueSoonBadge.Name = "lblDebtDueSoonBadge";
        lblDebtDueSoonBadge.Size = new Size(46, 46);
        lblDebtDueSoonBadge.TabIndex = 3;
        lblDebtDueSoonBadge.Text = "!";
        lblDebtDueSoonBadge.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblDebtDueSoonValue
        // 
        lblDebtDueSoonValue.AutoSize = true;
        lblDebtDueSoonValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
        lblDebtDueSoonValue.ForeColor = Color.FromArgb(224, 91, 97);
        lblDebtDueSoonValue.Location = new Point(22, 46);
        lblDebtDueSoonValue.Name = "lblDebtDueSoonValue";
        lblDebtDueSoonValue.Size = new Size(68, 54);
        lblDebtDueSoonValue.TabIndex = 2;
        lblDebtDueSoonValue.Text = "04";
        // 
        // lblDebtDueSoonTitle
        // 
        lblDebtDueSoonTitle.AutoSize = true;
        lblDebtDueSoonTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblDebtDueSoonTitle.Location = new Point(22, 18);
        lblDebtDueSoonTitle.Name = "lblDebtDueSoonTitle";
        lblDebtDueSoonTitle.Size = new Size(136, 23);
        lblDebtDueSoonTitle.TabIndex = 1;
        lblDebtDueSoonTitle.Text = "PhÃ¡t sinh Ä‘áº¿n háº¡n";
        // 
        // pnlDebtDueSoonAccent
        // 
        pnlDebtDueSoonAccent.BackColor = Color.FromArgb(224, 91, 97);
        pnlDebtDueSoonAccent.Dock = DockStyle.Bottom;
        pnlDebtDueSoonAccent.Location = new Point(22, 109);
        pnlDebtDueSoonAccent.Name = "pnlDebtDueSoonAccent";
        pnlDebtDueSoonAccent.Size = new Size(340, 1);
        pnlDebtDueSoonAccent.TabIndex = 0;
        // 
        // pnlDebtSectionCard
        // 
        pnlDebtSectionCard.BorderStyle = BorderStyle.FixedSingle;
        pnlDebtSectionCard.Controls.Add(tblDebtSectionLayout);
        pnlDebtSectionCard.Dock = DockStyle.Fill;
        pnlDebtSectionCard.Location = new Point(3, 285);
        pnlDebtSectionCard.Margin = new Padding(3, 16, 3, 3);
        pnlDebtSectionCard.Name = "pnlDebtSectionCard";
        pnlDebtSectionCard.Padding = new Padding(18, 14, 18, 12);
        pnlDebtSectionCard.Size = new Size(1154, 396);
        pnlDebtSectionCard.TabIndex = 2;
        // 
        // tblDebtSectionLayout
        // 
        tblDebtSectionLayout.ColumnCount = 1;
        tblDebtSectionLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblDebtSectionLayout.Controls.Add(tblDebtSectionHeader, 0, 0);
        tblDebtSectionLayout.Controls.Add(pnlDebtGridHost, 0, 1);
        tblDebtSectionLayout.Controls.Add(tblDebtFooter, 0, 2);
        tblDebtSectionLayout.Dock = DockStyle.Fill;
        tblDebtSectionLayout.Location = new Point(18, 14);
        tblDebtSectionLayout.Name = "tblDebtSectionLayout";
        tblDebtSectionLayout.RowCount = 3;
        tblDebtSectionLayout.RowStyles.Add(new RowStyle());
        tblDebtSectionLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblDebtSectionLayout.RowStyles.Add(new RowStyle());
        tblDebtSectionLayout.Size = new Size(1116, 368);
        tblDebtSectionLayout.TabIndex = 0;
        // 
        // tblDebtSectionHeader
        // 
        tblDebtSectionHeader.ColumnCount = 3;
        tblDebtSectionHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblDebtSectionHeader.ColumnStyles.Add(new ColumnStyle());
        tblDebtSectionHeader.ColumnStyles.Add(new ColumnStyle());
        tblDebtSectionHeader.Controls.Add(lblDebtSectionTitle, 0, 0);
        tblDebtSectionHeader.Controls.Add(lblDebtUpdatedAt, 1, 0);
        tblDebtSectionHeader.Controls.Add(flpDebtActions, 2, 0);
        tblDebtSectionHeader.Dock = DockStyle.Fill;
        tblDebtSectionHeader.Location = new Point(0, 0);
        tblDebtSectionHeader.Margin = new Padding(0, 0, 0, 12);
        tblDebtSectionHeader.Name = "tblDebtSectionHeader";
        tblDebtSectionHeader.RowCount = 1;
        tblDebtSectionHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblDebtSectionHeader.Size = new Size(1116, 48);
        tblDebtSectionHeader.TabIndex = 0;
        // 
        // lblDebtSectionTitle
        // 
        lblDebtSectionTitle.Anchor = AnchorStyles.Left;
        lblDebtSectionTitle.AutoSize = true;
        lblDebtSectionTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        lblDebtSectionTitle.ForeColor = Color.FromArgb(0, 96, 168);
        lblDebtSectionTitle.Location = new Point(3, 11);
        lblDebtSectionTitle.Name = "lblDebtSectionTitle";
        lblDebtSectionTitle.Size = new Size(189, 25);
        lblDebtSectionTitle.TabIndex = 0;
        lblDebtSectionTitle.Text = "Báº£ng kÃª chi tiáº¿t cÃ´ng ná»£";
        // 
        // lblDebtUpdatedAt
        // 
        lblDebtUpdatedAt.Anchor = AnchorStyles.Left;
        lblDebtUpdatedAt.AutoSize = true;
        lblDebtUpdatedAt.BackColor = Color.FromArgb(240, 244, 251);
        lblDebtUpdatedAt.ForeColor = Color.FromArgb(102, 112, 133);
        lblDebtUpdatedAt.Location = new Point(385, 14);
        lblDebtUpdatedAt.Margin = new Padding(12, 0, 12, 0);
        lblDebtUpdatedAt.Name = "lblDebtUpdatedAt";
        lblDebtUpdatedAt.Padding = new Padding(10, 4, 10, 4);
        lblDebtUpdatedAt.Size = new Size(173, 28);
        lblDebtUpdatedAt.TabIndex = 1;
        lblDebtUpdatedAt.Text = "Cáº­p nháº­t: 14:30 24/04/2026";
        // 
        // flpDebtActions
        // 
        flpDebtActions.AutoSize = true;
        flpDebtActions.Controls.Add(btnOpenTuitionFromDebt);
        flpDebtActions.Controls.Add(btnExportDebt);
        flpDebtActions.Controls.Add(btnExportPdfDebt);
        flpDebtActions.Dock = DockStyle.Fill;
        flpDebtActions.Location = new Point(573, 0);
        flpDebtActions.Margin = new Padding(3, 0, 0, 0);
        flpDebtActions.Name = "flpDebtActions";
        flpDebtActions.Size = new Size(543, 48);
        flpDebtActions.TabIndex = 2;
        flpDebtActions.WrapContents = false;
        // 
        // btnOpenTuitionFromDebt
        // 
        btnOpenTuitionFromDebt.Location = new Point(0, 0);
        btnOpenTuitionFromDebt.Margin = new Padding(0, 0, 10, 0);
        btnOpenTuitionFromDebt.Name = "btnOpenTuitionFromDebt";
        btnOpenTuitionFromDebt.Size = new Size(146, 38);
        btnOpenTuitionFromDebt.TabIndex = 0;
        btnOpenTuitionFromDebt.Text = "Má»Ÿ thu há»c phÃ­";
        btnOpenTuitionFromDebt.UseVisualStyleBackColor = true;
        // 
        // btnExportDebt
        // 
        btnExportDebt.Location = new Point(156, 0);
        btnExportDebt.Margin = new Padding(0, 0, 10, 0);
        btnExportDebt.Name = "btnExportDebt";
        btnExportDebt.Size = new Size(126, 38);
        btnExportDebt.TabIndex = 1;
        btnExportDebt.Text = "Xuáº¥t Excel";
        btnExportDebt.UseVisualStyleBackColor = true;
        // 
        // btnExportPdfDebt
        // 
        btnExportPdfDebt.Location = new Point(292, 0);
        btnExportPdfDebt.Margin = new Padding(0);
        btnExportPdfDebt.Name = "btnExportPdfDebt";
        btnExportPdfDebt.Size = new Size(120, 38);
        btnExportPdfDebt.TabIndex = 2;
        btnExportPdfDebt.Text = "Xuáº¥t PDF";
        btnExportPdfDebt.UseVisualStyleBackColor = true;
        // 
        // pnlDebtGridHost
        // 
        pnlDebtGridHost.Controls.Add(dgvDebtTrackingList);
        pnlDebtGridHost.Dock = DockStyle.Fill;
        pnlDebtGridHost.Location = new Point(0, 60);
        pnlDebtGridHost.Margin = new Padding(0);
        pnlDebtGridHost.Name = "pnlDebtGridHost";
        pnlDebtGridHost.Size = new Size(1116, 264);
        pnlDebtGridHost.TabIndex = 1;
        // 
        // dgvDebtTrackingList
        // 
        dgvDebtTrackingList.AllowUserToAddRows = false;
        dgvDebtTrackingList.AllowUserToDeleteRows = false;
        dgvDebtTrackingList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDebtTrackingList.BackgroundColor = Color.White;
        dgvDebtTrackingList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvDebtTrackingList.Dock = DockStyle.Fill;
        dgvDebtTrackingList.Location = new Point(0, 0);
        dgvDebtTrackingList.Name = "dgvDebtTrackingList";
        dgvDebtTrackingList.ReadOnly = true;
        dgvDebtTrackingList.RowHeadersVisible = false;
        dgvDebtTrackingList.RowHeadersWidth = 51;
        dgvDebtTrackingList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDebtTrackingList.Size = new Size(1116, 264);
        dgvDebtTrackingList.TabIndex = 0;
        // 
        // tblDebtFooter
        // 
        tblDebtFooter.ColumnCount = 2;
        tblDebtFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblDebtFooter.ColumnStyles.Add(new ColumnStyle());
        tblDebtFooter.Controls.Add(lblDebtFooterSummary, 0, 0);
        tblDebtFooter.Controls.Add(flpDebtPager, 1, 0);
        tblDebtFooter.Dock = DockStyle.Fill;
        tblDebtFooter.Location = new Point(0, 324);
        tblDebtFooter.Margin = new Padding(0, 0, 0, 0);
        tblDebtFooter.Name = "tblDebtFooter";
        tblDebtFooter.RowCount = 1;
        tblDebtFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblDebtFooter.Size = new Size(1116, 44);
        tblDebtFooter.TabIndex = 2;
        // 
        // lblDebtFooterSummary
        // 
        lblDebtFooterSummary.Anchor = AnchorStyles.Left;
        lblDebtFooterSummary.AutoSize = true;
        lblDebtFooterSummary.ForeColor = Color.FromArgb(102, 112, 133);
        lblDebtFooterSummary.Location = new Point(3, 12);
        lblDebtFooterSummary.Name = "lblDebtFooterSummary";
        lblDebtFooterSummary.Size = new Size(198, 20);
        lblDebtFooterSummary.TabIndex = 0;
        lblDebtFooterSummary.Text = "Hiá»ƒn thá»‹ 1-6 trÃªn tá»•ng sá»‘ 6 há»c viÃªn";
        // 
        // flpDebtPager
        // 
        flpDebtPager.AutoSize = true;
        flpDebtPager.Controls.Add(btnDebtPagePrev);
        flpDebtPager.Controls.Add(btnDebtPage1);
        flpDebtPager.Controls.Add(btnDebtPage2);
        flpDebtPager.Controls.Add(btnDebtPage3);
        flpDebtPager.Controls.Add(lblDebtPageDots);
        flpDebtPager.Controls.Add(btnDebtPageNext);
        flpDebtPager.Dock = DockStyle.Fill;
        flpDebtPager.Location = new Point(868, 0);
        flpDebtPager.Margin = new Padding(0);
        flpDebtPager.Name = "flpDebtPager";
        flpDebtPager.Size = new Size(248, 44);
        flpDebtPager.TabIndex = 1;
        flpDebtPager.WrapContents = false;
        // 
        // btnDebtPagePrev
        // 
        btnDebtPagePrev.Location = new Point(0, 4);
        btnDebtPagePrev.Margin = new Padding(0, 4, 8, 0);
        btnDebtPagePrev.Name = "btnDebtPagePrev";
        btnDebtPagePrev.Size = new Size(34, 32);
        btnDebtPagePrev.TabIndex = 0;
        btnDebtPagePrev.Text = "<";
        btnDebtPagePrev.UseVisualStyleBackColor = true;
        // 
        // btnDebtPage1
        // 
        btnDebtPage1.Location = new Point(42, 4);
        btnDebtPage1.Margin = new Padding(0, 4, 8, 0);
        btnDebtPage1.Name = "btnDebtPage1";
        btnDebtPage1.Size = new Size(34, 32);
        btnDebtPage1.TabIndex = 1;
        btnDebtPage1.Text = "1";
        btnDebtPage1.UseVisualStyleBackColor = true;
        // 
        // btnDebtPage2
        // 
        btnDebtPage2.Location = new Point(84, 4);
        btnDebtPage2.Margin = new Padding(0, 4, 8, 0);
        btnDebtPage2.Name = "btnDebtPage2";
        btnDebtPage2.Size = new Size(34, 32);
        btnDebtPage2.TabIndex = 2;
        btnDebtPage2.Text = "2";
        btnDebtPage2.UseVisualStyleBackColor = true;
        // 
        // btnDebtPage3
        // 
        btnDebtPage3.Location = new Point(126, 4);
        btnDebtPage3.Margin = new Padding(0, 4, 8, 0);
        btnDebtPage3.Name = "btnDebtPage3";
        btnDebtPage3.Size = new Size(34, 32);
        btnDebtPage3.TabIndex = 3;
        btnDebtPage3.Text = "3";
        btnDebtPage3.UseVisualStyleBackColor = true;
        // 
        // lblDebtPageDots
        // 
        lblDebtPageDots.AutoSize = true;
        lblDebtPageDots.ForeColor = Color.FromArgb(102, 112, 133);
        lblDebtPageDots.Location = new Point(168, 10);
        lblDebtPageDots.Margin = new Padding(0, 10, 8, 0);
        lblDebtPageDots.Name = "lblDebtPageDots";
        lblDebtPageDots.Size = new Size(20, 20);
        lblDebtPageDots.TabIndex = 4;
        lblDebtPageDots.Text = "...";
        // 
        // btnDebtPageNext
        // 
        btnDebtPageNext.Location = new Point(196, 4);
        btnDebtPageNext.Margin = new Padding(0, 4, 0, 0);
        btnDebtPageNext.Name = "btnDebtPageNext";
        btnDebtPageNext.Size = new Size(34, 32);
        btnDebtPageNext.TabIndex = 5;
        btnDebtPageNext.Text = ">";
        btnDebtPageNext.UseVisualStyleBackColor = true;
        // 
        // FrmDebtTracking
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(1200, 720);
        Controls.Add(tblDebtRoot);
        Name = "FrmDebtTracking";
        Padding = new Padding(20, 18, 20, 18);
        Text = "CÃ´ng ná»£ há»c viÃªn";
        tblDebtRoot.ResumeLayout(false);
        pnlDebtFilterCard.ResumeLayout(false);
        tblDebtFilterShell.ResumeLayout(false);
        tblDebtFilterLayout.ResumeLayout(false);
        tblDebtFilterLayout.PerformLayout();
        flpDebtFilterActions.ResumeLayout(false);
        tblDebtKpi.ResumeLayout(false);
        pnlDebtTotalCount.ResumeLayout(false);
        pnlDebtTotalCount.PerformLayout();
        pnlDebtTotalAmount.ResumeLayout(false);
        pnlDebtTotalAmount.PerformLayout();
        pnlDebtDueSoon.ResumeLayout(false);
        pnlDebtDueSoon.PerformLayout();
        pnlDebtSectionCard.ResumeLayout(false);
        tblDebtSectionLayout.ResumeLayout(false);
        tblDebtSectionHeader.ResumeLayout(false);
        tblDebtSectionHeader.PerformLayout();
        flpDebtActions.ResumeLayout(false);
        pnlDebtGridHost.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvDebtTrackingList).EndInit();
        tblDebtFooter.ResumeLayout(false);
        tblDebtFooter.PerformLayout();
        flpDebtPager.ResumeLayout(false);
        flpDebtPager.PerformLayout();
        ResumeLayout(false);
    }
}

