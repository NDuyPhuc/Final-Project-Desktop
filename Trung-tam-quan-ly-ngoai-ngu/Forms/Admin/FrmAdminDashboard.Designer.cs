namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmAdminDashboard
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlSidebarAdmin;
    private Panel pnlSidebarBrand;
    private Label lblSidebarBrandTitle;
    private Label lblSidebarBrandSubtitle;
    private FlowLayoutPanel flpSidebarMenu;
    private Button btnMenuAdminDashboard;
    private Button btnMenuSystemMonitor;
    private Button btnMenuAccountManagement;
    private Button btnMenuAdminReports;
    private Panel pnlSidebarFooter;
    private Button btnLogoutAdmin;
    private Panel pnlTopbarAdmin;
    private Label lblAdminHeaderTitle;
    private Label lblAdminHeaderSubtitle;
    private Panel pnlAdminUserCard;
    private Label lblAdminUserCardRole;
    private Label lblAdminUserCardName;
    private Panel pnlContentHostAdmin;
    private Panel pnlDashboardHome;
    private TableLayoutPanel tblAdminDashboardRoot;
    private Panel pnlAdminHeroCard;
    private Label lblDashboardTitle;
    private Label lblDashboardSubtitle;
    private TableLayoutPanel tblAdminKpi;
    private Panel pnlKpiAccounts;
    private Panel pnlKpiClasses;
    private Panel pnlKpiRevenue;
    private Panel pnlKpiDebt;
    private Label lblKpiAccountsTitle;
    private Label lblKpiAccountsValue;
    private Label lblKpiAccountsNote;
    private Label lblKpiClassesTitle;
    private Label lblKpiClassesValue;
    private Label lblKpiClassesNote;
    private Label lblKpiRevenueTitle;
    private Label lblKpiRevenueValue;
    private Label lblKpiRevenueNote;
    private Label lblKpiDebtTitle;
    private Label lblKpiDebtValue;
    private Label lblKpiDebtNote;
    private SplitContainer splAdminDashboardBottom;
    private Panel pnlAdminWarningsCard;
    private Label lblAdminWarningsTitle;
    private Label lblAdminWarningsHint;
    private DataGridView dgvDashboardWarnings;
    private Panel pnlAdminQuickViewCard;
    private Label lblAdminQuickViewTitle;
    private Label lblAdminQuickViewHint;
    private DataGridView dgvDashboardSnapshot;

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
        pnlSidebarAdmin = new Panel();
        pnlSidebarFooter = new Panel();
        btnLogoutAdmin = new Button();
        flpSidebarMenu = new FlowLayoutPanel();
        btnMenuAdminDashboard = new Button();
        btnMenuSystemMonitor = new Button();
        btnMenuAccountManagement = new Button();
        btnMenuAdminReports = new Button();
        pnlSidebarBrand = new Panel();
        lblSidebarBrandSubtitle = new Label();
        lblSidebarBrandTitle = new Label();
        pnlTopbarAdmin = new Panel();
        pnlAdminUserCard = new Panel();
        lblAdminUserCardRole = new Label();
        lblAdminUserCardName = new Label();
        lblAdminHeaderSubtitle = new Label();
        lblAdminHeaderTitle = new Label();
        pnlContentHostAdmin = new Panel();
        pnlDashboardHome = new Panel();
        tblAdminDashboardRoot = new TableLayoutPanel();
        pnlAdminHeroCard = new Panel();
        lblDashboardSubtitle = new Label();
        lblDashboardTitle = new Label();
        tblAdminKpi = new TableLayoutPanel();
        pnlKpiAccounts = new Panel();
        lblKpiAccountsNote = new Label();
        lblKpiAccountsValue = new Label();
        lblKpiAccountsTitle = new Label();
        pnlKpiClasses = new Panel();
        lblKpiClassesNote = new Label();
        lblKpiClassesValue = new Label();
        lblKpiClassesTitle = new Label();
        pnlKpiRevenue = new Panel();
        lblKpiRevenueNote = new Label();
        lblKpiRevenueValue = new Label();
        lblKpiRevenueTitle = new Label();
        pnlKpiDebt = new Panel();
        lblKpiDebtNote = new Label();
        lblKpiDebtValue = new Label();
        lblKpiDebtTitle = new Label();
        splAdminDashboardBottom = new SplitContainer();
        pnlAdminWarningsCard = new Panel();
        dgvDashboardWarnings = new DataGridView();
        lblAdminWarningsHint = new Label();
        lblAdminWarningsTitle = new Label();
        pnlAdminQuickViewCard = new Panel();
        dgvDashboardSnapshot = new DataGridView();
        lblAdminQuickViewHint = new Label();
        lblAdminQuickViewTitle = new Label();
        pnlSidebarAdmin.SuspendLayout();
        pnlSidebarFooter.SuspendLayout();
        flpSidebarMenu.SuspendLayout();
        pnlSidebarBrand.SuspendLayout();
        pnlTopbarAdmin.SuspendLayout();
        pnlAdminUserCard.SuspendLayout();
        pnlContentHostAdmin.SuspendLayout();
        pnlDashboardHome.SuspendLayout();
        tblAdminDashboardRoot.SuspendLayout();
        pnlAdminHeroCard.SuspendLayout();
        tblAdminKpi.SuspendLayout();
        pnlKpiAccounts.SuspendLayout();
        pnlKpiClasses.SuspendLayout();
        pnlKpiRevenue.SuspendLayout();
        pnlKpiDebt.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splAdminDashboardBottom).BeginInit();
        splAdminDashboardBottom.Panel1.SuspendLayout();
        splAdminDashboardBottom.Panel2.SuspendLayout();
        splAdminDashboardBottom.SuspendLayout();
        pnlAdminWarningsCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDashboardWarnings).BeginInit();
        pnlAdminQuickViewCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDashboardSnapshot).BeginInit();
        SuspendLayout();
        // 
        // pnlSidebarAdmin
        // 
        pnlSidebarAdmin.AutoScroll = true;
        pnlSidebarAdmin.BackColor = Color.FromArgb(230, 246, 255);
        pnlSidebarAdmin.Controls.Add(pnlSidebarFooter);
        pnlSidebarAdmin.Controls.Add(flpSidebarMenu);
        pnlSidebarAdmin.Controls.Add(pnlSidebarBrand);
        pnlSidebarAdmin.Dock = DockStyle.Left;
        pnlSidebarAdmin.Location = new Point(0, 0);
        pnlSidebarAdmin.Name = "pnlSidebarAdmin";
        pnlSidebarAdmin.Padding = new Padding(18, 18, 18, 16);
        pnlSidebarAdmin.Size = new Size(248, 761);
        pnlSidebarAdmin.TabIndex = 0;
        // 
        // pnlSidebarFooter
        // 
        pnlSidebarFooter.Controls.Add(btnLogoutAdmin);
        pnlSidebarFooter.Dock = DockStyle.Bottom;
        pnlSidebarFooter.Location = new Point(18, 691);
        pnlSidebarFooter.Name = "pnlSidebarFooter";
        pnlSidebarFooter.Size = new Size(212, 54);
        pnlSidebarFooter.TabIndex = 2;
        // 
        // btnLogoutAdmin
        // 
        btnLogoutAdmin.Dock = DockStyle.Fill;
        btnLogoutAdmin.Location = new Point(0, 0);
        btnLogoutAdmin.Name = "btnLogoutAdmin";
        btnLogoutAdmin.Size = new Size(212, 54);
        btnLogoutAdmin.TabIndex = 0;
        btnLogoutAdmin.Text = "Đăng xuất";
        btnLogoutAdmin.UseVisualStyleBackColor = true;
        // 
        // flpSidebarMenu
        // 
        flpSidebarMenu.Controls.Add(btnMenuAdminDashboard);
        flpSidebarMenu.Controls.Add(btnMenuSystemMonitor);
        flpSidebarMenu.Controls.Add(btnMenuAccountManagement);
        flpSidebarMenu.Controls.Add(btnMenuAdminReports);
        flpSidebarMenu.Dock = DockStyle.Top;
        flpSidebarMenu.FlowDirection = FlowDirection.TopDown;
        flpSidebarMenu.Location = new Point(18, 98);
        flpSidebarMenu.Name = "flpSidebarMenu";
        flpSidebarMenu.Size = new Size(212, 234);
        flpSidebarMenu.TabIndex = 1;
        flpSidebarMenu.WrapContents = false;
        // 
        // btnMenuAdminDashboard
        // 
        btnMenuAdminDashboard.Location = new Point(3, 3);
        btnMenuAdminDashboard.Name = "btnMenuAdminDashboard";
        btnMenuAdminDashboard.Size = new Size(206, 46);
        btnMenuAdminDashboard.TabIndex = 0;
        btnMenuAdminDashboard.Text = "Dashboard";
        btnMenuAdminDashboard.UseVisualStyleBackColor = true;
        // 
        // btnMenuSystemMonitor
        // 
        btnMenuSystemMonitor.Location = new Point(3, 55);
        btnMenuSystemMonitor.Name = "btnMenuSystemMonitor";
        btnMenuSystemMonitor.Size = new Size(206, 46);
        btnMenuSystemMonitor.TabIndex = 1;
        btnMenuSystemMonitor.Text = "Giám sát hệ thống";
        btnMenuSystemMonitor.UseVisualStyleBackColor = true;
        // 
        // btnMenuAccountManagement
        // 
        btnMenuAccountManagement.Location = new Point(3, 107);
        btnMenuAccountManagement.Name = "btnMenuAccountManagement";
        btnMenuAccountManagement.Size = new Size(206, 46);
        btnMenuAccountManagement.TabIndex = 2;
        btnMenuAccountManagement.Text = "Tài khoản && phân quyền";
        btnMenuAccountManagement.UseVisualStyleBackColor = true;
        // 
        // btnMenuAdminReports
        // 
        btnMenuAdminReports.Location = new Point(3, 159);
        btnMenuAdminReports.Name = "btnMenuAdminReports";
        btnMenuAdminReports.Size = new Size(206, 46);
        btnMenuAdminReports.TabIndex = 3;
        btnMenuAdminReports.Text = "Báo cáo thống kê";
        btnMenuAdminReports.UseVisualStyleBackColor = true;
        // 
        // pnlSidebarBrand
        // 
        pnlSidebarBrand.Controls.Add(lblSidebarBrandSubtitle);
        pnlSidebarBrand.Controls.Add(lblSidebarBrandTitle);
        pnlSidebarBrand.Dock = DockStyle.Top;
        pnlSidebarBrand.Location = new Point(18, 18);
        pnlSidebarBrand.Name = "pnlSidebarBrand";
        pnlSidebarBrand.Size = new Size(212, 80);
        pnlSidebarBrand.TabIndex = 0;
        // 
        // lblSidebarBrandSubtitle
        // 
        lblSidebarBrandSubtitle.AutoSize = true;
        lblSidebarBrandSubtitle.ForeColor = Color.FromArgb(0, 110, 110);
        lblSidebarBrandSubtitle.Location = new Point(0, 30);
        lblSidebarBrandSubtitle.Name = "lblSidebarBrandSubtitle";
        lblSidebarBrandSubtitle.Size = new Size(167, 28);
        lblSidebarBrandSubtitle.TabIndex = 1;
        lblSidebarBrandSubtitle.Text = "Quản trị hệ thống";
        // 
        // lblSidebarBrandTitle
        // 
        lblSidebarBrandTitle.AutoSize = true;
        lblSidebarBrandTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblSidebarBrandTitle.ForeColor = Color.FromArgb(0, 66, 118);
        lblSidebarBrandTitle.Location = new Point(0, 0);
        lblSidebarBrandTitle.Name = "lblSidebarBrandTitle";
        lblSidebarBrandTitle.Size = new Size(116, 38);
        lblSidebarBrandTitle.TabIndex = 0;
        lblSidebarBrandTitle.Text = "ADMIN";
        // 
        // pnlTopbarAdmin
        // 
        pnlTopbarAdmin.BackColor = Color.White;
        pnlTopbarAdmin.Controls.Add(pnlAdminUserCard);
        pnlTopbarAdmin.Controls.Add(lblAdminHeaderSubtitle);
        pnlTopbarAdmin.Controls.Add(lblAdminHeaderTitle);
        pnlTopbarAdmin.Dock = DockStyle.Top;
        pnlTopbarAdmin.Location = new Point(248, 0);
        pnlTopbarAdmin.Name = "pnlTopbarAdmin";
        pnlTopbarAdmin.Padding = new Padding(28, 18, 28, 18);
        pnlTopbarAdmin.Size = new Size(1124, 98);
        pnlTopbarAdmin.TabIndex = 1;
        // 
        // pnlAdminUserCard
        // 
        pnlAdminUserCard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        pnlAdminUserCard.BackColor = Color.FromArgb(240, 246, 252);
        pnlAdminUserCard.Controls.Add(lblAdminUserCardRole);
        pnlAdminUserCard.Controls.Add(lblAdminUserCardName);
        pnlAdminUserCard.Location = new Point(868, 18);
        pnlAdminUserCard.Name = "pnlAdminUserCard";
        pnlAdminUserCard.Padding = new Padding(16, 12, 16, 12);
        pnlAdminUserCard.Size = new Size(228, 60);
        pnlAdminUserCard.TabIndex = 2;
        // 
        // lblAdminUserCardRole
        // 
        lblAdminUserCardRole.AutoSize = true;
        lblAdminUserCardRole.ForeColor = Color.FromArgb(102, 112, 133);
        lblAdminUserCardRole.Location = new Point(16, 32);
        lblAdminUserCardRole.Name = "lblAdminUserCardRole";
        lblAdminUserCardRole.Size = new Size(70, 28);
        lblAdminUserCardRole.TabIndex = 1;
        lblAdminUserCardRole.Text = "Admin";
        // 
        // lblAdminUserCardName
        // 
        lblAdminUserCardName.AutoSize = true;
        lblAdminUserCardName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblAdminUserCardName.ForeColor = Color.FromArgb(42, 51, 64);
        lblAdminUserCardName.Location = new Point(16, 10);
        lblAdminUserCardName.Name = "lblAdminUserCardName";
        lblAdminUserCardName.Size = new Size(148, 28);
        lblAdminUserCardName.TabIndex = 0;
        lblAdminUserCardName.Text = "System Admin";
        // 
        // lblAdminHeaderSubtitle
        // 
        lblAdminHeaderSubtitle.AutoSize = true;
        lblAdminHeaderSubtitle.ForeColor = Color.FromArgb(102, 112, 133);
        lblAdminHeaderSubtitle.Location = new Point(30, 52);
        lblAdminHeaderSubtitle.Name = "lblAdminHeaderSubtitle";
        lblAdminHeaderSubtitle.Size = new Size(572, 28);
        lblAdminHeaderSubtitle.TabIndex = 1;
        lblAdminHeaderSubtitle.Text = "Chỉ hiển thị dữ liệu quản trị tổng hợp, không thao tác nghiệp vụ.";
        // 
        // lblAdminHeaderTitle
        // 
        lblAdminHeaderTitle.AutoSize = true;
        lblAdminHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblAdminHeaderTitle.ForeColor = Color.FromArgb(7, 30, 39);
        lblAdminHeaderTitle.Location = new Point(28, 16);
        lblAdminHeaderTitle.Name = "lblAdminHeaderTitle";
        lblAdminHeaderTitle.Size = new Size(293, 45);
        lblAdminHeaderTitle.TabIndex = 0;
        lblAdminHeaderTitle.Text = "Dashboard Admin";
        // 
        // pnlContentHostAdmin
        // 
        pnlContentHostAdmin.AutoScroll = true;
        pnlContentHostAdmin.Controls.Add(pnlDashboardHome);
        pnlContentHostAdmin.Dock = DockStyle.Fill;
        pnlContentHostAdmin.Location = new Point(248, 98);
        pnlContentHostAdmin.Name = "pnlContentHostAdmin";
        pnlContentHostAdmin.Padding = new Padding(20, 0, 20, 20);
        pnlContentHostAdmin.Size = new Size(1124, 663);
        pnlContentHostAdmin.TabIndex = 2;
        // 
        // pnlDashboardHome
        // 
        pnlDashboardHome.Controls.Add(tblAdminDashboardRoot);
        pnlDashboardHome.Dock = DockStyle.Fill;
        pnlDashboardHome.Location = new Point(20, 0);
        pnlDashboardHome.Name = "pnlDashboardHome";
        pnlDashboardHome.Size = new Size(1084, 643);
        pnlDashboardHome.TabIndex = 0;
        // 
        // tblAdminDashboardRoot
        // 
        tblAdminDashboardRoot.ColumnCount = 1;
        tblAdminDashboardRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblAdminDashboardRoot.Controls.Add(pnlAdminHeroCard, 0, 0);
        tblAdminDashboardRoot.Controls.Add(tblAdminKpi, 0, 1);
        tblAdminDashboardRoot.Controls.Add(splAdminDashboardBottom, 0, 2);
        tblAdminDashboardRoot.Dock = DockStyle.Fill;
        tblAdminDashboardRoot.Location = new Point(0, 0);
        tblAdminDashboardRoot.Name = "tblAdminDashboardRoot";
        tblAdminDashboardRoot.RowCount = 3;
        tblAdminDashboardRoot.RowStyles.Add(new RowStyle());
        tblAdminDashboardRoot.RowStyles.Add(new RowStyle());
        tblAdminDashboardRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblAdminDashboardRoot.Size = new Size(1084, 643);
        tblAdminDashboardRoot.TabIndex = 0;
        // 
        // pnlAdminHeroCard
        // 
        pnlAdminHeroCard.BackColor = Color.White;
        pnlAdminHeroCard.Controls.Add(lblDashboardSubtitle);
        pnlAdminHeroCard.Controls.Add(lblDashboardTitle);
        pnlAdminHeroCard.Dock = DockStyle.Fill;
        pnlAdminHeroCard.Location = new Point(0, 0);
        pnlAdminHeroCard.Margin = new Padding(0, 0, 0, 16);
        pnlAdminHeroCard.Name = "pnlAdminHeroCard";
        pnlAdminHeroCard.Padding = new Padding(24, 20, 24, 20);
        pnlAdminHeroCard.Size = new Size(1084, 108);
        pnlAdminHeroCard.TabIndex = 0;
        pnlAdminHeroCard.Paint += pnlAdminHeroCard_Paint;
        // 
        // lblDashboardSubtitle
        // 
        lblDashboardSubtitle.AutoSize = true;
        lblDashboardSubtitle.ForeColor = Color.FromArgb(102, 112, 133);
        lblDashboardSubtitle.Location = new Point(24, 58);
        lblDashboardSubtitle.Name = "lblDashboardSubtitle";
        lblDashboardSubtitle.Size = new Size(749, 28);
        lblDashboardSubtitle.TabIndex = 1;
        lblDashboardSubtitle.Text = "Theo dõi tài khoản, lớp đang mở, doanh thu đã thu và danh sách cảnh báo cần chú ý.";
        // 
        // lblDashboardTitle
        // 
        lblDashboardTitle.AutoSize = true;
        lblDashboardTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblDashboardTitle.ForeColor = Color.FromArgb(7, 30, 39);
        lblDashboardTitle.Location = new Point(20, 10);
        lblDashboardTitle.Name = "lblDashboardTitle";
        lblDashboardTitle.Size = new Size(389, 54);
        lblDashboardTitle.TabIndex = 0;
        lblDashboardTitle.Text = "Dashboard quản trị";
        // 
        // tblAdminKpi
        // 
        tblAdminKpi.ColumnCount = 4;
        tblAdminKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblAdminKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblAdminKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblAdminKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblAdminKpi.Controls.Add(pnlKpiAccounts, 0, 0);
        tblAdminKpi.Controls.Add(pnlKpiClasses, 1, 0);
        tblAdminKpi.Controls.Add(pnlKpiRevenue, 2, 0);
        tblAdminKpi.Controls.Add(pnlKpiDebt, 3, 0);
        tblAdminKpi.Dock = DockStyle.Fill;
        tblAdminKpi.Location = new Point(0, 124);
        tblAdminKpi.Margin = new Padding(0, 0, 0, 16);
        tblAdminKpi.Name = "tblAdminKpi";
        tblAdminKpi.RowCount = 1;
        tblAdminKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblAdminKpi.Size = new Size(1084, 128);
        tblAdminKpi.TabIndex = 1;
        // 
        // pnlKpiAccounts
        // 
        pnlKpiAccounts.BackColor = Color.White;
        pnlKpiAccounts.Controls.Add(lblKpiAccountsNote);
        pnlKpiAccounts.Controls.Add(lblKpiAccountsValue);
        pnlKpiAccounts.Controls.Add(lblKpiAccountsTitle);
        pnlKpiAccounts.Dock = DockStyle.Fill;
        pnlKpiAccounts.Location = new Point(0, 0);
        pnlKpiAccounts.Margin = new Padding(0, 0, 12, 0);
        pnlKpiAccounts.Name = "pnlKpiAccounts";
        pnlKpiAccounts.Padding = new Padding(18);
        pnlKpiAccounts.Size = new Size(259, 128);
        pnlKpiAccounts.TabIndex = 0;
        // 
        // lblKpiAccountsNote
        // 
        lblKpiAccountsNote.AutoSize = true;
        lblKpiAccountsNote.ForeColor = Color.FromArgb(102, 112, 133);
        lblKpiAccountsNote.Location = new Point(18, 88);
        lblKpiAccountsNote.Name = "lblKpiAccountsNote";
        lblKpiAccountsNote.Size = new Size(194, 28);
        lblKpiAccountsNote.TabIndex = 2;
        lblKpiAccountsNote.Text = "Toàn bộ tài khoản hệ";
        // 
        // lblKpiAccountsValue
        // 
        lblKpiAccountsValue.AutoSize = true;
        lblKpiAccountsValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblKpiAccountsValue.ForeColor = Color.FromArgb(0, 66, 118);
        lblKpiAccountsValue.Location = new Point(15, 32);
        lblKpiAccountsValue.Name = "lblKpiAccountsValue";
        lblKpiAccountsValue.Size = new Size(75, 60);
        lblKpiAccountsValue.TabIndex = 1;
        lblKpiAccountsValue.Text = "32";
        // 
        // lblKpiAccountsTitle
        // 
        lblKpiAccountsTitle.AutoSize = true;
        lblKpiAccountsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblKpiAccountsTitle.ForeColor = Color.FromArgb(42, 51, 64);
        lblKpiAccountsTitle.Location = new Point(18, 12);
        lblKpiAccountsTitle.Name = "lblKpiAccountsTitle";
        lblKpiAccountsTitle.Size = new Size(155, 28);
        lblKpiAccountsTitle.TabIndex = 0;
        lblKpiAccountsTitle.Text = "Tổng tài khoản";
        // 
        // pnlKpiClasses
        // 
        pnlKpiClasses.BackColor = Color.White;
        pnlKpiClasses.Controls.Add(lblKpiClassesNote);
        pnlKpiClasses.Controls.Add(lblKpiClassesValue);
        pnlKpiClasses.Controls.Add(lblKpiClassesTitle);
        pnlKpiClasses.Dock = DockStyle.Fill;
        pnlKpiClasses.Location = new Point(271, 0);
        pnlKpiClasses.Margin = new Padding(0, 0, 12, 0);
        pnlKpiClasses.Name = "pnlKpiClasses";
        pnlKpiClasses.Padding = new Padding(18);
        pnlKpiClasses.Size = new Size(259, 128);
        pnlKpiClasses.TabIndex = 1;
        // 
        // lblKpiClassesNote
        // 
        lblKpiClassesNote.AutoSize = true;
        lblKpiClassesNote.ForeColor = Color.FromArgb(102, 112, 133);
        lblKpiClassesNote.Location = new Point(18, 88);
        lblKpiClassesNote.Name = "lblKpiClassesNote";
        lblKpiClassesNote.Size = new Size(252, 28);
        lblKpiClassesNote.TabIndex = 2;
        lblKpiClassesNote.Text = "Lớp đang có lịch khai giảng";
        // 
        // lblKpiClassesValue
        // 
        lblKpiClassesValue.AutoSize = true;
        lblKpiClassesValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblKpiClassesValue.ForeColor = Color.FromArgb(0, 110, 110);
        lblKpiClassesValue.Location = new Point(15, 32);
        lblKpiClassesValue.Name = "lblKpiClassesValue";
        lblKpiClassesValue.Size = new Size(75, 60);
        lblKpiClassesValue.TabIndex = 1;
        lblKpiClassesValue.Text = "18";
        // 
        // lblKpiClassesTitle
        // 
        lblKpiClassesTitle.AutoSize = true;
        lblKpiClassesTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblKpiClassesTitle.ForeColor = Color.FromArgb(42, 51, 64);
        lblKpiClassesTitle.Location = new Point(18, 12);
        lblKpiClassesTitle.Name = "lblKpiClassesTitle";
        lblKpiClassesTitle.Size = new Size(138, 28);
        lblKpiClassesTitle.TabIndex = 0;
        lblKpiClassesTitle.Text = "Lớp đang mở";
        // 
        // pnlKpiRevenue
        // 
        pnlKpiRevenue.BackColor = Color.White;
        pnlKpiRevenue.Controls.Add(lblKpiRevenueNote);
        pnlKpiRevenue.Controls.Add(lblKpiRevenueValue);
        pnlKpiRevenue.Controls.Add(lblKpiRevenueTitle);
        pnlKpiRevenue.Dock = DockStyle.Fill;
        pnlKpiRevenue.Location = new Point(542, 0);
        pnlKpiRevenue.Margin = new Padding(0, 0, 12, 0);
        pnlKpiRevenue.Name = "pnlKpiRevenue";
        pnlKpiRevenue.Padding = new Padding(18);
        pnlKpiRevenue.Size = new Size(259, 128);
        pnlKpiRevenue.TabIndex = 2;
        // 
        // lblKpiRevenueNote
        // 
        lblKpiRevenueNote.AutoSize = true;
        lblKpiRevenueNote.ForeColor = Color.FromArgb(102, 112, 133);
        lblKpiRevenueNote.Location = new Point(18, 88);
        lblKpiRevenueNote.Name = "lblKpiRevenueNote";
        lblKpiRevenueNote.Size = new Size(212, 28);
        lblKpiRevenueNote.TabIndex = 2;
        lblKpiRevenueNote.Text = "Doanh thu đã xác nhận";
        // 
        // lblKpiRevenueValue
        // 
        lblKpiRevenueValue.AutoSize = true;
        lblKpiRevenueValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblKpiRevenueValue.ForeColor = Color.FromArgb(124, 45, 18);
        lblKpiRevenueValue.Location = new Point(15, 32);
        lblKpiRevenueValue.Name = "lblKpiRevenueValue";
        lblKpiRevenueValue.Size = new Size(184, 60);
        lblKpiRevenueValue.TabIndex = 1;
        lblKpiRevenueValue.Text = "286,5 tr";
        // 
        // lblKpiRevenueTitle
        // 
        lblKpiRevenueTitle.AutoSize = true;
        lblKpiRevenueTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblKpiRevenueTitle.ForeColor = Color.FromArgb(42, 51, 64);
        lblKpiRevenueTitle.Location = new Point(18, 12);
        lblKpiRevenueTitle.Name = "lblKpiRevenueTitle";
        lblKpiRevenueTitle.Size = new Size(180, 28);
        lblKpiRevenueTitle.TabIndex = 0;
        lblKpiRevenueTitle.Text = "Doanh thu đã thu";
        // 
        // pnlKpiDebt
        // 
        pnlKpiDebt.BackColor = Color.White;
        pnlKpiDebt.Controls.Add(lblKpiDebtNote);
        pnlKpiDebt.Controls.Add(lblKpiDebtValue);
        pnlKpiDebt.Controls.Add(lblKpiDebtTitle);
        pnlKpiDebt.Dock = DockStyle.Fill;
        pnlKpiDebt.Location = new Point(813, 0);
        pnlKpiDebt.Margin = new Padding(0);
        pnlKpiDebt.Name = "pnlKpiDebt";
        pnlKpiDebt.Padding = new Padding(18);
        pnlKpiDebt.Size = new Size(271, 128);
        pnlKpiDebt.TabIndex = 3;
        // 
        // lblKpiDebtNote
        // 
        lblKpiDebtNote.AutoSize = true;
        lblKpiDebtNote.ForeColor = Color.FromArgb(102, 112, 133);
        lblKpiDebtNote.Location = new Point(18, 88);
        lblKpiDebtNote.Name = "lblKpiDebtNote";
        lblKpiDebtNote.Size = new Size(267, 28);
        lblKpiDebtNote.TabIndex = 2;
        lblKpiDebtNote.Text = "Học viên còn nợ cần theo dõi";
        // 
        // lblKpiDebtValue
        // 
        lblKpiDebtValue.AutoSize = true;
        lblKpiDebtValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblKpiDebtValue.ForeColor = Color.FromArgb(224, 91, 97);
        lblKpiDebtValue.Location = new Point(15, 32);
        lblKpiDebtValue.Name = "lblKpiDebtValue";
        lblKpiDebtValue.Size = new Size(75, 60);
        lblKpiDebtValue.TabIndex = 1;
        lblKpiDebtValue.Text = "27";
        // 
        // lblKpiDebtTitle
        // 
        lblKpiDebtTitle.AutoSize = true;
        lblKpiDebtTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblKpiDebtTitle.ForeColor = Color.FromArgb(42, 51, 64);
        lblKpiDebtTitle.Location = new Point(18, 12);
        lblKpiDebtTitle.Name = "lblKpiDebtTitle";
        lblKpiDebtTitle.Size = new Size(166, 28);
        lblKpiDebtTitle.TabIndex = 0;
        lblKpiDebtTitle.Text = "Học viên còn nợ";
        // 
        // splAdminDashboardBottom
        // 
        splAdminDashboardBottom.Dock = DockStyle.Fill;
        splAdminDashboardBottom.Location = new Point(0, 268);
        splAdminDashboardBottom.Margin = new Padding(0);
        splAdminDashboardBottom.Name = "splAdminDashboardBottom";
        // 
        // splAdminDashboardBottom.Panel1
        // 
        splAdminDashboardBottom.Panel1.Controls.Add(pnlAdminWarningsCard);
        splAdminDashboardBottom.Panel1.Padding = new Padding(0, 0, 10, 0);
        // 
        // splAdminDashboardBottom.Panel2
        // 
        splAdminDashboardBottom.Panel2.Controls.Add(pnlAdminQuickViewCard);
        splAdminDashboardBottom.Panel2.Padding = new Padding(10, 0, 0, 0);
        splAdminDashboardBottom.Size = new Size(1084, 375);
        splAdminDashboardBottom.SplitterDistance = 522;
        splAdminDashboardBottom.TabIndex = 2;
        // 
        // pnlAdminWarningsCard
        // 
        pnlAdminWarningsCard.BackColor = Color.White;
        pnlAdminWarningsCard.Controls.Add(dgvDashboardWarnings);
        pnlAdminWarningsCard.Controls.Add(lblAdminWarningsHint);
        pnlAdminWarningsCard.Controls.Add(lblAdminWarningsTitle);
        pnlAdminWarningsCard.Dock = DockStyle.Fill;
        pnlAdminWarningsCard.Location = new Point(0, 0);
        pnlAdminWarningsCard.Name = "pnlAdminWarningsCard";
        pnlAdminWarningsCard.Padding = new Padding(18);
        pnlAdminWarningsCard.Size = new Size(512, 375);
        pnlAdminWarningsCard.TabIndex = 0;
        // 
        // dgvDashboardWarnings
        // 
        dgvDashboardWarnings.ColumnHeadersHeight = 29;
        dgvDashboardWarnings.Dock = DockStyle.Fill;
        dgvDashboardWarnings.Location = new Point(18, 76);
        dgvDashboardWarnings.Name = "dgvDashboardWarnings";
        dgvDashboardWarnings.RowHeadersWidth = 51;
        dgvDashboardWarnings.Size = new Size(476, 281);
        dgvDashboardWarnings.TabIndex = 2;
        // 
        // lblAdminWarningsHint
        // 
        lblAdminWarningsHint.Dock = DockStyle.Top;
        lblAdminWarningsHint.ForeColor = Color.FromArgb(102, 112, 133);
        lblAdminWarningsHint.Location = new Point(18, 48);
        lblAdminWarningsHint.Name = "lblAdminWarningsHint";
        lblAdminWarningsHint.Size = new Size(476, 28);
        lblAdminWarningsHint.TabIndex = 1;
        lblAdminWarningsHint.Text = "Danh sách read-only các cảnh báo cần Admin theo dõi.";
        // 
        // lblAdminWarningsTitle
        // 
        lblAdminWarningsTitle.AutoSize = true;
        lblAdminWarningsTitle.Dock = DockStyle.Top;
        lblAdminWarningsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblAdminWarningsTitle.ForeColor = Color.FromArgb(42, 51, 64);
        lblAdminWarningsTitle.Location = new Point(18, 18);
        lblAdminWarningsTitle.Name = "lblAdminWarningsTitle";
        lblAdminWarningsTitle.Size = new Size(198, 30);
        lblAdminWarningsTitle.TabIndex = 0;
        lblAdminWarningsTitle.Text = "Cảnh báo quản trị";
        // 
        // pnlAdminQuickViewCard
        // 
        pnlAdminQuickViewCard.BackColor = Color.White;
        pnlAdminQuickViewCard.Controls.Add(dgvDashboardSnapshot);
        pnlAdminQuickViewCard.Controls.Add(lblAdminQuickViewHint);
        pnlAdminQuickViewCard.Controls.Add(lblAdminQuickViewTitle);
        pnlAdminQuickViewCard.Dock = DockStyle.Fill;
        pnlAdminQuickViewCard.Location = new Point(10, 0);
        pnlAdminQuickViewCard.Name = "pnlAdminQuickViewCard";
        pnlAdminQuickViewCard.Padding = new Padding(18);
        pnlAdminQuickViewCard.Size = new Size(548, 375);
        pnlAdminQuickViewCard.TabIndex = 0;
        // 
        // dgvDashboardSnapshot
        // 
        dgvDashboardSnapshot.ColumnHeadersHeight = 29;
        dgvDashboardSnapshot.Dock = DockStyle.Fill;
        dgvDashboardSnapshot.Location = new Point(18, 76);
        dgvDashboardSnapshot.Name = "dgvDashboardSnapshot";
        dgvDashboardSnapshot.RowHeadersWidth = 51;
        dgvDashboardSnapshot.Size = new Size(512, 281);
        dgvDashboardSnapshot.TabIndex = 2;
        // 
        // lblAdminQuickViewHint
        // 
        lblAdminQuickViewHint.Dock = DockStyle.Top;
        lblAdminQuickViewHint.ForeColor = Color.FromArgb(102, 112, 133);
        lblAdminQuickViewHint.Location = new Point(18, 48);
        lblAdminQuickViewHint.Name = "lblAdminQuickViewHint";
        lblAdminQuickViewHint.Size = new Size(512, 28);
        lblAdminQuickViewHint.TabIndex = 1;
        lblAdminQuickViewHint.Text = "Số liệu nhanh để đánh giá tình hình trung tâm trước khi mở báo cáo chi tiết.";
        // 
        // lblAdminQuickViewTitle
        // 
        lblAdminQuickViewTitle.AutoSize = true;
        lblAdminQuickViewTitle.Dock = DockStyle.Top;
        lblAdminQuickViewTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblAdminQuickViewTitle.ForeColor = Color.FromArgb(42, 51, 64);
        lblAdminQuickViewTitle.Location = new Point(18, 18);
        lblAdminQuickViewTitle.Name = "lblAdminQuickViewTitle";
        lblAdminQuickViewTitle.Size = new Size(151, 30);
        lblAdminQuickViewTitle.TabIndex = 0;
        lblAdminQuickViewTitle.Text = "Số liệu nhanh";
        // 
        // FrmAdminDashboard
        // 
        AutoScaleDimensions = new SizeF(144F, 144F);
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoScroll = true;
        BackColor = Color.FromArgb(245, 247, 251);
        ClientSize = new Size(1372, 761);
        Controls.Add(pnlContentHostAdmin);
        Controls.Add(pnlTopbarAdmin);
        Controls.Add(pnlSidebarAdmin);
        Font = new Font("Segoe UI", 10F);
        MinimumSize = new Size(1180, 760);
        Name = "FrmAdminDashboard";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Dashboard Admin";
        pnlSidebarAdmin.ResumeLayout(false);
        pnlSidebarFooter.ResumeLayout(false);
        flpSidebarMenu.ResumeLayout(false);
        pnlSidebarBrand.ResumeLayout(false);
        pnlSidebarBrand.PerformLayout();
        pnlTopbarAdmin.ResumeLayout(false);
        pnlTopbarAdmin.PerformLayout();
        pnlAdminUserCard.ResumeLayout(false);
        pnlAdminUserCard.PerformLayout();
        pnlContentHostAdmin.ResumeLayout(false);
        pnlDashboardHome.ResumeLayout(false);
        tblAdminDashboardRoot.ResumeLayout(false);
        pnlAdminHeroCard.ResumeLayout(false);
        pnlAdminHeroCard.PerformLayout();
        tblAdminKpi.ResumeLayout(false);
        pnlKpiAccounts.ResumeLayout(false);
        pnlKpiAccounts.PerformLayout();
        pnlKpiClasses.ResumeLayout(false);
        pnlKpiClasses.PerformLayout();
        pnlKpiRevenue.ResumeLayout(false);
        pnlKpiRevenue.PerformLayout();
        pnlKpiDebt.ResumeLayout(false);
        pnlKpiDebt.PerformLayout();
        splAdminDashboardBottom.Panel1.ResumeLayout(false);
        splAdminDashboardBottom.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splAdminDashboardBottom).EndInit();
        splAdminDashboardBottom.ResumeLayout(false);
        pnlAdminWarningsCard.ResumeLayout(false);
        pnlAdminWarningsCard.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDashboardWarnings).EndInit();
        pnlAdminQuickViewCard.ResumeLayout(false);
        pnlAdminQuickViewCard.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDashboardSnapshot).EndInit();
        ResumeLayout(false);
    }
}

