namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmAdminDashboard
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlSidebarAdmin;
    private Panel pnlSidebarBrand;
    private Panel pnlSidebarLogo;
    private Label lblSidebarLogoGlyph;
    private Label lblCurrentRoleAdmin;
    private Label lblCurrentUserAdmin;
    private FlowLayoutPanel flpSidebarMenu;
    private Button btnMenuAdminDashboard;
    private Button btnMenuSystemMonitor;
    private Button btnMenuAccountManagement;
    private Button btnMenuAdminReports;
    private Button btnMenuAdminFinance;
    private FlowLayoutPanel flpSidebarFooter;
    private Button btnSidebarDocuments;
    private Button btnSidebarSupport;
    private Panel pnlTopbarAdmin;
    private Label lblAppBrandAdmin;
    private FlowLayoutPanel flpTopNavAdmin;
    private Label lblTopNavDashboard;
    private Label lblTopNavAnalysis;
    private Label lblTopNavReports;
    private Button btnAddRoleAdmin;
    private Button btnNotifyAdmin;
    private Button btnSettingsAdmin;
    private Panel pnlAvatarAdmin;
    private Label lblAvatarAdmin;
    private Panel pnlContentHostAdmin;
    private Panel pnlDashboardHome;
    private Label lblDashboardTitle;
    private Label lblDashboardSubtitle;
    private TableLayoutPanel tblRoleCards;
    private Panel pnlRoleAdminCard;
    private Panel pnlRoleStaffCard;
    private Panel pnlRoleTeacherCard;
    private Label lblRoleAdminCaption;
    private Label lblRoleAdminTitle;
    private Label lblRoleAdminBody;
    private Label lblRoleAdminBadgePrimary;
    private Label lblRoleAdminBadgeSecondary;
    private Label lblRoleAdminIcon;
    private Label lblRoleStaffCaption;
    private Label lblRoleStaffTitle;
    private Label lblRoleStaffBody;
    private Label lblRoleStaffBadgePrimary;
    private Label lblRoleStaffBadgeSecondary;
    private Label lblRoleStaffIcon;
    private Label lblRoleTeacherCaption;
    private Label lblRoleTeacherTitle;
    private Label lblRoleTeacherBody;
    private Label lblRoleTeacherBadgePrimary;
    private Label lblRoleTeacherBadgeSecondary;
    private Label lblRoleTeacherIcon;
    private Panel pnlMatrixCard;
    private Panel pnlMatrixHeader;
    private Label lblMatrixTitle;
    private FlowLayoutPanel flpMatrixLegend;
    private Panel pnlLegendAllowed;
    private Label lblLegendAllowed;
    private Panel pnlLegendDenied;
    private Label lblLegendDenied;
    private DataGridView dgvDashboardWarnings;
    private Button btnExportAuditAdmin;

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
        flpSidebarFooter = new FlowLayoutPanel();
        btnSidebarDocuments = new Button();
        btnSidebarSupport = new Button();
        flpSidebarMenu = new FlowLayoutPanel();
        btnMenuAdminDashboard = new Button();
        btnMenuSystemMonitor = new Button();
        btnMenuAccountManagement = new Button();
        btnMenuAdminReports = new Button();
        btnMenuAdminFinance = new Button();
        pnlSidebarBrand = new Panel();
        lblCurrentUserAdmin = new Label();
        lblCurrentRoleAdmin = new Label();
        pnlSidebarLogo = new Panel();
        lblSidebarLogoGlyph = new Label();
        pnlTopbarAdmin = new Panel();
        pnlAvatarAdmin = new Panel();
        lblAvatarAdmin = new Label();
        btnSettingsAdmin = new Button();
        btnNotifyAdmin = new Button();
        btnAddRoleAdmin = new Button();
        flpTopNavAdmin = new FlowLayoutPanel();
        lblTopNavDashboard = new Label();
        lblTopNavAnalysis = new Label();
        lblTopNavReports = new Label();
        lblAppBrandAdmin = new Label();
        pnlContentHostAdmin = new Panel();
        pnlDashboardHome = new Panel();
        pnlMatrixCard = new Panel();
        btnExportAuditAdmin = new Button();
        dgvDashboardWarnings = new DataGridView();
        pnlMatrixHeader = new Panel();
        flpMatrixLegend = new FlowLayoutPanel();
        pnlLegendAllowed = new Panel();
        lblLegendAllowed = new Label();
        pnlLegendDenied = new Panel();
        lblLegendDenied = new Label();
        lblMatrixTitle = new Label();
        tblRoleCards = new TableLayoutPanel();
        pnlRoleAdminCard = new Panel();
        lblRoleAdminBadgeSecondary = new Label();
        lblRoleAdminBadgePrimary = new Label();
        lblRoleAdminBody = new Label();
        lblRoleAdminTitle = new Label();
        lblRoleAdminCaption = new Label();
        lblRoleAdminIcon = new Label();
        pnlRoleStaffCard = new Panel();
        lblRoleStaffBadgeSecondary = new Label();
        lblRoleStaffBadgePrimary = new Label();
        lblRoleStaffBody = new Label();
        lblRoleStaffTitle = new Label();
        lblRoleStaffCaption = new Label();
        lblRoleStaffIcon = new Label();
        pnlRoleTeacherCard = new Panel();
        lblRoleTeacherBadgeSecondary = new Label();
        lblRoleTeacherBadgePrimary = new Label();
        lblRoleTeacherBody = new Label();
        lblRoleTeacherTitle = new Label();
        lblRoleTeacherCaption = new Label();
        lblRoleTeacherIcon = new Label();
        lblDashboardSubtitle = new Label();
        lblDashboardTitle = new Label();
        pnlSidebarAdmin.SuspendLayout();
        flpSidebarFooter.SuspendLayout();
        flpSidebarMenu.SuspendLayout();
        pnlSidebarBrand.SuspendLayout();
        pnlSidebarLogo.SuspendLayout();
        pnlTopbarAdmin.SuspendLayout();
        pnlAvatarAdmin.SuspendLayout();
        flpTopNavAdmin.SuspendLayout();
        pnlContentHostAdmin.SuspendLayout();
        pnlDashboardHome.SuspendLayout();
        pnlMatrixCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvDashboardWarnings).BeginInit();
        pnlMatrixHeader.SuspendLayout();
        flpMatrixLegend.SuspendLayout();
        tblRoleCards.SuspendLayout();
        pnlRoleAdminCard.SuspendLayout();
        pnlRoleStaffCard.SuspendLayout();
        pnlRoleTeacherCard.SuspendLayout();
        SuspendLayout();
        // 
        // pnlSidebarAdmin
        // 
        pnlSidebarAdmin.BackColor = Color.FromArgb(230, 246, 255);
        pnlSidebarAdmin.Controls.Add(flpSidebarFooter);
        pnlSidebarAdmin.Controls.Add(flpSidebarMenu);
        pnlSidebarAdmin.Controls.Add(pnlSidebarBrand);
        pnlSidebarAdmin.Dock = DockStyle.Left;
        pnlSidebarAdmin.Location = new Point(0, 0);
        pnlSidebarAdmin.Name = "pnlSidebarAdmin";
        pnlSidebarAdmin.Size = new Size(220, 698);
        pnlSidebarAdmin.TabIndex = 0;
        // 
        // flpSidebarFooter
        // 
        flpSidebarFooter.Controls.Add(btnSidebarDocuments);
        flpSidebarFooter.Controls.Add(btnSidebarSupport);
        flpSidebarFooter.FlowDirection = FlowDirection.TopDown;
        flpSidebarFooter.Location = new Point(18, 535);
        flpSidebarFooter.Name = "flpSidebarFooter";
        flpSidebarFooter.Size = new Size(176, 76);
        flpSidebarFooter.TabIndex = 2;
        flpSidebarFooter.WrapContents = false;
        // 
        // btnSidebarDocuments
        // 
        btnSidebarDocuments.FlatAppearance.BorderSize = 0;
        btnSidebarDocuments.FlatStyle = FlatStyle.Flat;
        btnSidebarDocuments.Font = new Font("Segoe UI", 9F);
        btnSidebarDocuments.ForeColor = Color.FromArgb(55, 65, 81);
        btnSidebarDocuments.ImageAlign = ContentAlignment.MiddleLeft;
        btnSidebarDocuments.Location = new Point(3, 3);
        btnSidebarDocuments.Name = "btnSidebarDocuments";
        btnSidebarDocuments.Padding = new Padding(10, 0, 0, 0);
        btnSidebarDocuments.Size = new Size(170, 32);
        btnSidebarDocuments.TabIndex = 0;
        btnSidebarDocuments.Text = "Tài liệu";
        btnSidebarDocuments.TextAlign = ContentAlignment.MiddleLeft;
        btnSidebarDocuments.UseVisualStyleBackColor = true;
        // 
        // btnSidebarSupport
        // 
        btnSidebarSupport.FlatAppearance.BorderSize = 0;
        btnSidebarSupport.FlatStyle = FlatStyle.Flat;
        btnSidebarSupport.Font = new Font("Segoe UI", 9F);
        btnSidebarSupport.ForeColor = Color.FromArgb(55, 65, 81);
        btnSidebarSupport.Location = new Point(3, 41);
        btnSidebarSupport.Name = "btnSidebarSupport";
        btnSidebarSupport.Padding = new Padding(10, 0, 0, 0);
        btnSidebarSupport.Size = new Size(170, 32);
        btnSidebarSupport.TabIndex = 1;
        btnSidebarSupport.Text = "Hỗ trợ";
        btnSidebarSupport.TextAlign = ContentAlignment.MiddleLeft;
        btnSidebarSupport.UseVisualStyleBackColor = true;
        // 
        // flpSidebarMenu
        // 
        flpSidebarMenu.Controls.Add(btnMenuAdminDashboard);
        flpSidebarMenu.Controls.Add(btnMenuSystemMonitor);
        flpSidebarMenu.Controls.Add(btnMenuAccountManagement);
        flpSidebarMenu.Controls.Add(btnMenuAdminReports);
        flpSidebarMenu.Controls.Add(btnMenuAdminFinance);
        flpSidebarMenu.FlowDirection = FlowDirection.TopDown;
        flpSidebarMenu.Location = new Point(18, 132);
        flpSidebarMenu.Name = "flpSidebarMenu";
        flpSidebarMenu.Size = new Size(182, 226);
        flpSidebarMenu.TabIndex = 1;
        flpSidebarMenu.WrapContents = false;
        // 
        // btnMenuAdminDashboard
        // 
        btnMenuAdminDashboard.BackColor = Color.FromArgb(144, 239, 239);
        btnMenuAdminDashboard.FlatAppearance.BorderSize = 0;
        btnMenuAdminDashboard.FlatStyle = FlatStyle.Flat;
        btnMenuAdminDashboard.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnMenuAdminDashboard.ForeColor = Color.FromArgb(0, 110, 110);
        btnMenuAdminDashboard.Location = new Point(3, 3);
        btnMenuAdminDashboard.Name = "btnMenuAdminDashboard";
        btnMenuAdminDashboard.Padding = new Padding(16, 0, 0, 0);
        btnMenuAdminDashboard.Size = new Size(176, 44);
        btnMenuAdminDashboard.TabIndex = 0;
        btnMenuAdminDashboard.Text = "Quyền truy cập";
        btnMenuAdminDashboard.TextAlign = ContentAlignment.MiddleLeft;
        btnMenuAdminDashboard.UseVisualStyleBackColor = false;
        // 
        // btnMenuSystemMonitor
        // 
        btnMenuSystemMonitor.FlatAppearance.BorderSize = 0;
        btnMenuSystemMonitor.FlatStyle = FlatStyle.Flat;
        btnMenuSystemMonitor.Font = new Font("Segoe UI", 10F);
        btnMenuSystemMonitor.ForeColor = Color.FromArgb(55, 65, 81);
        btnMenuSystemMonitor.Location = new Point(3, 53);
        btnMenuSystemMonitor.Name = "btnMenuSystemMonitor";
        btnMenuSystemMonitor.Padding = new Padding(16, 0, 0, 0);
        btnMenuSystemMonitor.Size = new Size(176, 40);
        btnMenuSystemMonitor.TabIndex = 1;
        btnMenuSystemMonitor.Text = "Danh bạ nhân viên";
        btnMenuSystemMonitor.TextAlign = ContentAlignment.MiddleLeft;
        btnMenuSystemMonitor.UseVisualStyleBackColor = true;
        // 
        // btnMenuAccountManagement
        // 
        btnMenuAccountManagement.FlatAppearance.BorderSize = 0;
        btnMenuAccountManagement.FlatStyle = FlatStyle.Flat;
        btnMenuAccountManagement.Font = new Font("Segoe UI", 10F);
        btnMenuAccountManagement.ForeColor = Color.FromArgb(55, 65, 81);
        btnMenuAccountManagement.Location = new Point(3, 99);
        btnMenuAccountManagement.Name = "btnMenuAccountManagement";
        btnMenuAccountManagement.Padding = new Padding(16, 0, 0, 0);
        btnMenuAccountManagement.Size = new Size(176, 40);
        btnMenuAccountManagement.TabIndex = 2;
        btnMenuAccountManagement.Text = "Ma trận học sinh";
        btnMenuAccountManagement.TextAlign = ContentAlignment.MiddleLeft;
        btnMenuAccountManagement.UseVisualStyleBackColor = true;
        // 
        // btnMenuAdminReports
        // 
        btnMenuAdminReports.FlatAppearance.BorderSize = 0;
        btnMenuAdminReports.FlatStyle = FlatStyle.Flat;
        btnMenuAdminReports.Font = new Font("Segoe UI", 10F);
        btnMenuAdminReports.ForeColor = Color.FromArgb(55, 65, 81);
        btnMenuAdminReports.Location = new Point(3, 145);
        btnMenuAdminReports.Name = "btnMenuAdminReports";
        btnMenuAdminReports.Padding = new Padding(16, 0, 0, 0);
        btnMenuAdminReports.Size = new Size(176, 40);
        btnMenuAdminReports.TabIndex = 3;
        btnMenuAdminReports.Text = "Lịch học";
        btnMenuAdminReports.TextAlign = ContentAlignment.MiddleLeft;
        btnMenuAdminReports.UseVisualStyleBackColor = true;
        // 
        // btnMenuAdminFinance
        // 
        btnMenuAdminFinance.FlatAppearance.BorderSize = 0;
        btnMenuAdminFinance.FlatStyle = FlatStyle.Flat;
        btnMenuAdminFinance.Font = new Font("Segoe UI", 10F);
        btnMenuAdminFinance.ForeColor = Color.FromArgb(55, 65, 81);
        btnMenuAdminFinance.Location = new Point(3, 191);
        btnMenuAdminFinance.Name = "btnMenuAdminFinance";
        btnMenuAdminFinance.Padding = new Padding(16, 0, 0, 0);
        btnMenuAdminFinance.Size = new Size(176, 40);
        btnMenuAdminFinance.TabIndex = 4;
        btnMenuAdminFinance.Text = "Tài chính";
        btnMenuAdminFinance.TextAlign = ContentAlignment.MiddleLeft;
        btnMenuAdminFinance.UseVisualStyleBackColor = true;
        // 
        // pnlSidebarBrand
        // 
        pnlSidebarBrand.Controls.Add(lblCurrentUserAdmin);
        pnlSidebarBrand.Controls.Add(lblCurrentRoleAdmin);
        pnlSidebarBrand.Controls.Add(pnlSidebarLogo);
        pnlSidebarBrand.Location = new Point(18, 22);
        pnlSidebarBrand.Name = "pnlSidebarBrand";
        pnlSidebarBrand.Size = new Size(182, 84);
        pnlSidebarBrand.TabIndex = 0;
        // 
        // lblCurrentUserAdmin
        // 
        lblCurrentUserAdmin.AutoSize = true;
        lblCurrentUserAdmin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCurrentUserAdmin.ForeColor = Color.FromArgb(7, 30, 39);
        lblCurrentUserAdmin.Location = new Point(66, 18);
        lblCurrentUserAdmin.Name = "lblCurrentUserAdmin";
        lblCurrentUserAdmin.Size = new Size(127, 23);
        lblCurrentUserAdmin.TabIndex = 2;
        lblCurrentUserAdmin.Text = "System Admin";
        // 
        // lblCurrentRoleAdmin
        // 
        lblCurrentRoleAdmin.AutoSize = true;
        lblCurrentRoleAdmin.Font = new Font("Segoe UI", 9F);
        lblCurrentRoleAdmin.ForeColor = Color.FromArgb(66, 71, 80);
        lblCurrentRoleAdmin.Location = new Point(66, 46);
        lblCurrentRoleAdmin.Name = "lblCurrentRoleAdmin";
        lblCurrentRoleAdmin.Size = new Size(116, 20);
        lblCurrentRoleAdmin.TabIndex = 1;
        lblCurrentRoleAdmin.Text = "Precision Access";
        // 
        // pnlSidebarLogo
        // 
        pnlSidebarLogo.BackColor = Color.FromArgb(0, 66, 118);
        pnlSidebarLogo.Controls.Add(lblSidebarLogoGlyph);
        pnlSidebarLogo.Location = new Point(0, 12);
        pnlSidebarLogo.Name = "pnlSidebarLogo";
        pnlSidebarLogo.Size = new Size(50, 50);
        pnlSidebarLogo.TabIndex = 0;
        // 
        // lblSidebarLogoGlyph
        // 
        lblSidebarLogoGlyph.Dock = DockStyle.Fill;
        lblSidebarLogoGlyph.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblSidebarLogoGlyph.ForeColor = Color.White;
        lblSidebarLogoGlyph.Location = new Point(0, 0);
        lblSidebarLogoGlyph.Name = "lblSidebarLogoGlyph";
        lblSidebarLogoGlyph.Size = new Size(50, 50);
        lblSidebarLogoGlyph.TabIndex = 0;
        lblSidebarLogoGlyph.Text = "A";
        lblSidebarLogoGlyph.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlTopbarAdmin
        // 
        pnlTopbarAdmin.BackColor = Color.FromArgb(207, 232, 248);
        pnlTopbarAdmin.Controls.Add(pnlAvatarAdmin);
        pnlTopbarAdmin.Controls.Add(btnSettingsAdmin);
        pnlTopbarAdmin.Controls.Add(btnNotifyAdmin);
        pnlTopbarAdmin.Controls.Add(btnAddRoleAdmin);
        pnlTopbarAdmin.Controls.Add(flpTopNavAdmin);
        pnlTopbarAdmin.Controls.Add(lblAppBrandAdmin);
        pnlTopbarAdmin.Dock = DockStyle.Top;
        pnlTopbarAdmin.Location = new Point(220, 0);
        pnlTopbarAdmin.Name = "pnlTopbarAdmin";
        pnlTopbarAdmin.Size = new Size(802, 58);
        pnlTopbarAdmin.TabIndex = 1;
        // 
        // pnlAvatarAdmin
        // 
        pnlAvatarAdmin.BackColor = Color.White;
        pnlAvatarAdmin.BorderStyle = BorderStyle.FixedSingle;
        pnlAvatarAdmin.Controls.Add(lblAvatarAdmin);
        pnlAvatarAdmin.Location = new Point(701, 14);
        pnlAvatarAdmin.Name = "pnlAvatarAdmin";
        pnlAvatarAdmin.Size = new Size(36, 36);
        pnlAvatarAdmin.TabIndex = 5;
        // 
        // lblAvatarAdmin
        // 
        lblAvatarAdmin.Dock = DockStyle.Fill;
        lblAvatarAdmin.Font = new Font("Segoe UI", 12F);
        lblAvatarAdmin.Location = new Point(0, 0);
        lblAvatarAdmin.Name = "lblAvatarAdmin";
        lblAvatarAdmin.Size = new Size(34, 34);
        lblAvatarAdmin.TabIndex = 0;
        lblAvatarAdmin.Text = "👤";
        lblAvatarAdmin.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnSettingsAdmin
        // 
        btnSettingsAdmin.FlatAppearance.BorderSize = 0;
        btnSettingsAdmin.FlatStyle = FlatStyle.Flat;
        btnSettingsAdmin.Font = new Font("Segoe UI Symbol", 11F);
        btnSettingsAdmin.ForeColor = Color.FromArgb(0, 55, 103);
        btnSettingsAdmin.Location = new Point(665, 14);
        btnSettingsAdmin.Name = "btnSettingsAdmin";
        btnSettingsAdmin.Size = new Size(30, 30);
        btnSettingsAdmin.TabIndex = 4;
        btnSettingsAdmin.Text = "⚙";
        btnSettingsAdmin.UseVisualStyleBackColor = true;
        // 
        // btnNotifyAdmin
        // 
        btnNotifyAdmin.FlatAppearance.BorderSize = 0;
        btnNotifyAdmin.FlatStyle = FlatStyle.Flat;
        btnNotifyAdmin.Font = new Font("Segoe UI Symbol", 11F);
        btnNotifyAdmin.ForeColor = Color.FromArgb(0, 55, 103);
        btnNotifyAdmin.Location = new Point(629, 14);
        btnNotifyAdmin.Name = "btnNotifyAdmin";
        btnNotifyAdmin.Size = new Size(30, 30);
        btnNotifyAdmin.TabIndex = 3;
        btnNotifyAdmin.Text = "🔔";
        btnNotifyAdmin.UseVisualStyleBackColor = true;
        // 
        // btnAddRoleAdmin
        // 
        btnAddRoleAdmin.BackColor = Color.FromArgb(0, 66, 118);
        btnAddRoleAdmin.FlatAppearance.BorderSize = 0;
        btnAddRoleAdmin.FlatStyle = FlatStyle.Flat;
        btnAddRoleAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnAddRoleAdmin.ForeColor = Color.White;
        btnAddRoleAdmin.Location = new Point(501, 14);
        btnAddRoleAdmin.Name = "btnAddRoleAdmin";
        btnAddRoleAdmin.Size = new Size(110, 30);
        btnAddRoleAdmin.TabIndex = 2;
        btnAddRoleAdmin.Text = "THÊM VAI TRÒ";
        btnAddRoleAdmin.UseVisualStyleBackColor = false;
        // 
        // flpTopNavAdmin
        // 
        flpTopNavAdmin.Controls.Add(lblTopNavDashboard);
        flpTopNavAdmin.Controls.Add(lblTopNavAnalysis);
        flpTopNavAdmin.Controls.Add(lblTopNavReports);
        flpTopNavAdmin.Location = new Point(278, 16);
        flpTopNavAdmin.Name = "flpTopNavAdmin";
        flpTopNavAdmin.Size = new Size(205, 28);
        flpTopNavAdmin.TabIndex = 1;
        flpTopNavAdmin.WrapContents = false;
        // 
        // lblTopNavDashboard
        // 
        lblTopNavDashboard.AutoSize = true;
        lblTopNavDashboard.Font = new Font("Segoe UI", 9.5F);
        lblTopNavDashboard.ForeColor = Color.FromArgb(42, 51, 64);
        lblTopNavDashboard.Location = new Point(3, 0);
        lblTopNavDashboard.Margin = new Padding(3, 0, 18, 0);
        lblTopNavDashboard.Name = "lblTopNavDashboard";
        lblTopNavDashboard.Size = new Size(121, 21);
        lblTopNavDashboard.TabIndex = 0;
        lblTopNavDashboard.Text = "Bảng điều khiển";
        // 
        // lblTopNavAnalysis
        // 
        lblTopNavAnalysis.AutoSize = true;
        lblTopNavAnalysis.Font = new Font("Segoe UI", 9.5F);
        lblTopNavAnalysis.ForeColor = Color.FromArgb(42, 51, 64);
        lblTopNavAnalysis.Location = new Point(145, 0);
        lblTopNavAnalysis.Margin = new Padding(3, 0, 18, 0);
        lblTopNavAnalysis.Name = "lblTopNavAnalysis";
        lblTopNavAnalysis.Size = new Size(74, 21);
        lblTopNavAnalysis.TabIndex = 1;
        lblTopNavAnalysis.Text = "Phân tích";
        // 
        // lblTopNavReports
        // 
        lblTopNavReports.AutoSize = true;
        lblTopNavReports.Font = new Font("Segoe UI", 9.5F);
        lblTopNavReports.ForeColor = Color.FromArgb(42, 51, 64);
        lblTopNavReports.Location = new Point(240, 0);
        lblTopNavReports.Name = "lblTopNavReports";
        lblTopNavReports.Size = new Size(64, 21);
        lblTopNavReports.TabIndex = 2;
        lblTopNavReports.Text = "Báo cáo";
        // 
        // lblAppBrandAdmin
        // 
        lblAppBrandAdmin.AutoSize = true;
        lblAppBrandAdmin.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblAppBrandAdmin.ForeColor = Color.FromArgb(7, 30, 39);
        lblAppBrandAdmin.Location = new Point(18, 12);
        lblAppBrandAdmin.Name = "lblAppBrandAdmin";
        lblAppBrandAdmin.Size = new Size(320, 37);
        lblAppBrandAdmin.TabIndex = 0;
        lblAppBrandAdmin.Text = "LINGUISTIC ARCHITECT";
        // 
        // pnlContentHostAdmin
        // 
        pnlContentHostAdmin.BackColor = Color.FromArgb(244, 251, 255);
        pnlContentHostAdmin.Controls.Add(pnlDashboardHome);
        pnlContentHostAdmin.Dock = DockStyle.Fill;
        pnlContentHostAdmin.Location = new Point(220, 58);
        pnlContentHostAdmin.Name = "pnlContentHostAdmin";
        pnlContentHostAdmin.Padding = new Padding(16);
        pnlContentHostAdmin.Size = new Size(802, 640);
        pnlContentHostAdmin.TabIndex = 2;
        // 
        // pnlDashboardHome
        // 
        pnlDashboardHome.AutoScroll = true;
        pnlDashboardHome.BackColor = Color.FromArgb(244, 251, 255);
        pnlDashboardHome.Controls.Add(pnlMatrixCard);
        pnlDashboardHome.Controls.Add(tblRoleCards);
        pnlDashboardHome.Controls.Add(lblDashboardSubtitle);
        pnlDashboardHome.Controls.Add(lblDashboardTitle);
        pnlDashboardHome.Dock = DockStyle.Fill;
        pnlDashboardHome.Location = new Point(16, 16);
        pnlDashboardHome.Name = "pnlDashboardHome";
        pnlDashboardHome.Size = new Size(770, 608);
        pnlDashboardHome.TabIndex = 0;
        // 
        // pnlMatrixCard
        // 
        pnlMatrixCard.BackColor = Color.White;
        pnlMatrixCard.Controls.Add(btnExportAuditAdmin);
        pnlMatrixCard.Controls.Add(dgvDashboardWarnings);
        pnlMatrixCard.Controls.Add(pnlMatrixHeader);
        pnlMatrixCard.Location = new Point(16, 332);
        pnlMatrixCard.Name = "pnlMatrixCard";
        pnlMatrixCard.Size = new Size(680, 430);
        pnlMatrixCard.TabIndex = 3;
        // 
        // btnExportAuditAdmin
        // 
        btnExportAuditAdmin.FlatAppearance.BorderSize = 0;
        btnExportAuditAdmin.FlatStyle = FlatStyle.Flat;
        btnExportAuditAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnExportAuditAdmin.ForeColor = Color.FromArgb(0, 66, 118);
        btnExportAuditAdmin.Location = new Point(470, 385);
        btnExportAuditAdmin.Name = "btnExportAuditAdmin";
        btnExportAuditAdmin.Size = new Size(190, 30);
        btnExportAuditAdmin.TabIndex = 2;
        btnExportAuditAdmin.Text = "XUẤT NHẬT KÝ KIỂM TOÁN";
        btnExportAuditAdmin.UseVisualStyleBackColor = true;
        // 
        // dgvDashboardWarnings
        // 
        dgvDashboardWarnings.AllowUserToAddRows = false;
        dgvDashboardWarnings.AllowUserToDeleteRows = false;
        dgvDashboardWarnings.AllowUserToResizeColumns = false;
        dgvDashboardWarnings.AllowUserToResizeRows = false;
        dgvDashboardWarnings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDashboardWarnings.BackgroundColor = Color.White;
        dgvDashboardWarnings.BorderStyle = BorderStyle.None;
        dgvDashboardWarnings.ColumnHeadersHeight = 42;
        dgvDashboardWarnings.Location = new Point(0, 60);
        dgvDashboardWarnings.MultiSelect = false;
        dgvDashboardWarnings.Name = "dgvDashboardWarnings";
        dgvDashboardWarnings.ReadOnly = true;
        dgvDashboardWarnings.RowHeadersVisible = false;
        dgvDashboardWarnings.RowHeadersWidth = 51;
        dgvDashboardWarnings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDashboardWarnings.Size = new Size(680, 315);
        dgvDashboardWarnings.TabIndex = 1;
        // 
        // pnlMatrixHeader
        // 
        pnlMatrixHeader.BackColor = Color.FromArgb(205, 229, 245);
        pnlMatrixHeader.Controls.Add(flpMatrixLegend);
        pnlMatrixHeader.Controls.Add(lblMatrixTitle);
        pnlMatrixHeader.Dock = DockStyle.Top;
        pnlMatrixHeader.Location = new Point(0, 0);
        pnlMatrixHeader.Name = "pnlMatrixHeader";
        pnlMatrixHeader.Size = new Size(680, 52);
        pnlMatrixHeader.TabIndex = 0;
        // 
        // flpMatrixLegend
        // 
        flpMatrixLegend.Controls.Add(pnlLegendAllowed);
        flpMatrixLegend.Controls.Add(lblLegendAllowed);
        flpMatrixLegend.Controls.Add(pnlLegendDenied);
        flpMatrixLegend.Controls.Add(lblLegendDenied);
        flpMatrixLegend.Location = new Point(434, 15);
        flpMatrixLegend.Name = "flpMatrixLegend";
        flpMatrixLegend.Size = new Size(224, 24);
        flpMatrixLegend.TabIndex = 1;
        flpMatrixLegend.WrapContents = false;
        // 
        // pnlLegendAllowed
        // 
        pnlLegendAllowed.BackColor = Color.FromArgb(0, 110, 110);
        pnlLegendAllowed.Location = new Point(3, 6);
        pnlLegendAllowed.Margin = new Padding(3, 6, 4, 0);
        pnlLegendAllowed.Name = "pnlLegendAllowed";
        pnlLegendAllowed.Size = new Size(14, 14);
        pnlLegendAllowed.TabIndex = 0;
        // 
        // lblLegendAllowed
        // 
        lblLegendAllowed.AutoSize = true;
        lblLegendAllowed.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblLegendAllowed.ForeColor = Color.FromArgb(42, 51, 64);
        lblLegendAllowed.Location = new Point(24, 2);
        lblLegendAllowed.Margin = new Padding(3, 2, 0, 0);
        lblLegendAllowed.Name = "lblLegendAllowed";
        lblLegendAllowed.Size = new Size(106, 20);
        lblLegendAllowed.TabIndex = 1;
        lblLegendAllowed.Text = "TOÀN QUYỀN";
        // 
        // pnlLegendDenied
        // 
        pnlLegendDenied.BackColor = Color.FromArgb(235, 241, 247);
        pnlLegendDenied.Location = new Point(144, 6);
        pnlLegendDenied.Margin = new Padding(14, 6, 4, 0);
        pnlLegendDenied.Name = "pnlLegendDenied";
        pnlLegendDenied.Size = new Size(14, 14);
        pnlLegendDenied.TabIndex = 2;
        // 
        // lblLegendDenied
        // 
        lblLegendDenied.AutoSize = true;
        lblLegendDenied.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblLegendDenied.ForeColor = Color.FromArgb(42, 51, 64);
        lblLegendDenied.Location = new Point(165, 2);
        lblLegendDenied.Margin = new Padding(3, 2, 0, 0);
        lblLegendDenied.Name = "lblLegendDenied";
        lblLegendDenied.Size = new Size(140, 20);
        lblLegendDenied.TabIndex = 3;
        lblLegendDenied.Text = "KHÔNG TRUY CẬP";
        // 
        // lblMatrixTitle
        // 
        lblMatrixTitle.AutoSize = true;
        lblMatrixTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblMatrixTitle.ForeColor = Color.FromArgb(7, 30, 39);
        lblMatrixTitle.Location = new Point(20, 15);
        lblMatrixTitle.Name = "lblMatrixTitle";
        lblMatrixTitle.Size = new Size(297, 23);
        lblMatrixTitle.TabIndex = 0;
        lblMatrixTitle.Text = "MA TRẬN PHÂN QUYỀN HỆ THỐNG";
        // 
        // tblRoleCards
        // 
        tblRoleCards.ColumnCount = 3;
        tblRoleCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tblRoleCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tblRoleCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tblRoleCards.Controls.Add(pnlRoleAdminCard, 0, 0);
        tblRoleCards.Controls.Add(pnlRoleStaffCard, 1, 0);
        tblRoleCards.Controls.Add(pnlRoleTeacherCard, 2, 0);
        tblRoleCards.Location = new Point(16, 102);
        tblRoleCards.Name = "tblRoleCards";
        tblRoleCards.RowCount = 1;
        tblRoleCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblRoleCards.Size = new Size(680, 210);
        tblRoleCards.TabIndex = 2;
        // 
        // pnlRoleAdminCard
        // 
        pnlRoleAdminCard.BackColor = Color.White;
        pnlRoleAdminCard.BorderStyle = BorderStyle.FixedSingle;
        pnlRoleAdminCard.Controls.Add(lblRoleAdminBadgeSecondary);
        pnlRoleAdminCard.Controls.Add(lblRoleAdminBadgePrimary);
        pnlRoleAdminCard.Controls.Add(lblRoleAdminBody);
        pnlRoleAdminCard.Controls.Add(lblRoleAdminTitle);
        pnlRoleAdminCard.Controls.Add(lblRoleAdminCaption);
        pnlRoleAdminCard.Controls.Add(lblRoleAdminIcon);
        pnlRoleAdminCard.Dock = DockStyle.Fill;
        pnlRoleAdminCard.Location = new Point(3, 3);
        pnlRoleAdminCard.Name = "pnlRoleAdminCard";
        pnlRoleAdminCard.Padding = new Padding(16);
        pnlRoleAdminCard.Size = new Size(220, 204);
        pnlRoleAdminCard.TabIndex = 0;
        // 
        // lblRoleAdminBadgeSecondary
        // 
        lblRoleAdminBadgeSecondary.AutoSize = true;
        lblRoleAdminBadgeSecondary.BackColor = Color.FromArgb(225, 237, 246);
        lblRoleAdminBadgeSecondary.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblRoleAdminBadgeSecondary.ForeColor = Color.FromArgb(42, 51, 64);
        lblRoleAdminBadgeSecondary.Location = new Point(111, 166);
        lblRoleAdminBadgeSecondary.Name = "lblRoleAdminBadgeSecondary";
        lblRoleAdminBadgeSecondary.Padding = new Padding(8, 4, 8, 4);
        lblRoleAdminBadgeSecondary.Size = new Size(101, 27);
        lblRoleAdminBadgeSecondary.TabIndex = 5;
        lblRoleAdminBadgeSecondary.Text = "KIỂM TOÁN";
        // 
        // lblRoleAdminBadgePrimary
        // 
        lblRoleAdminBadgePrimary.AutoSize = true;
        lblRoleAdminBadgePrimary.BackColor = Color.FromArgb(144, 239, 239);
        lblRoleAdminBadgePrimary.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblRoleAdminBadgePrimary.ForeColor = Color.FromArgb(0, 110, 110);
        lblRoleAdminBadgePrimary.Location = new Point(16, 166);
        lblRoleAdminBadgePrimary.Name = "lblRoleAdminBadgePrimary";
        lblRoleAdminBadgePrimary.Padding = new Padding(8, 4, 8, 4);
        lblRoleAdminBadgePrimary.Size = new Size(107, 27);
        lblRoleAdminBadgePrimary.TabIndex = 4;
        lblRoleAdminBadgePrimary.Text = "QUYỀN GỐC";
        // 
        // lblRoleAdminBody
        // 
        lblRoleAdminBody.Font = new Font("Segoe UI", 9.5F);
        lblRoleAdminBody.ForeColor = Color.FromArgb(42, 51, 64);
        lblRoleAdminBody.Location = new Point(16, 84);
        lblRoleAdminBody.Name = "lblRoleAdminBody";
        lblRoleAdminBody.Size = new Size(172, 70);
        lblRoleAdminBody.TabIndex = 3;
        lblRoleAdminBody.Text = "Toàn quyền điều hành hệ thống, giám sát phân quyền và tính toàn vẹn dữ liệu.";
        // 
        // lblRoleAdminTitle
        // 
        lblRoleAdminTitle.AutoSize = true;
        lblRoleAdminTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblRoleAdminTitle.ForeColor = Color.FromArgb(0, 66, 118);
        lblRoleAdminTitle.Location = new Point(16, 50);
        lblRoleAdminTitle.Name = "lblRoleAdminTitle";
        lblRoleAdminTitle.Size = new Size(166, 25);
        lblRoleAdminTitle.TabIndex = 2;
        lblRoleAdminTitle.Text = "Quản lý & Giám sát";
        // 
        // lblRoleAdminCaption
        // 
        lblRoleAdminCaption.AutoSize = true;
        lblRoleAdminCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblRoleAdminCaption.ForeColor = Color.FromArgb(7, 30, 39);
        lblRoleAdminCaption.Location = new Point(16, 18);
        lblRoleAdminCaption.Name = "lblRoleAdminCaption";
        lblRoleAdminCaption.Size = new Size(121, 20);
        lblRoleAdminCaption.TabIndex = 1;
        lblRoleAdminCaption.Text = "QUẢN TRỊ VIÊN";
        // 
        // lblRoleAdminIcon
        // 
        lblRoleAdminIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblRoleAdminIcon.Font = new Font("Segoe UI Symbol", 42F);
        lblRoleAdminIcon.ForeColor = Color.FromArgb(225, 231, 238);
        lblRoleAdminIcon.Location = new Point(158, 16);
        lblRoleAdminIcon.Name = "lblRoleAdminIcon";
        lblRoleAdminIcon.Size = new Size(48, 66);
        lblRoleAdminIcon.TabIndex = 0;
        lblRoleAdminIcon.Text = "◔";
        lblRoleAdminIcon.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlRoleStaffCard
        // 
        pnlRoleStaffCard.BackColor = Color.White;
        pnlRoleStaffCard.BorderStyle = BorderStyle.FixedSingle;
        pnlRoleStaffCard.Controls.Add(lblRoleStaffBadgeSecondary);
        pnlRoleStaffCard.Controls.Add(lblRoleStaffBadgePrimary);
        pnlRoleStaffCard.Controls.Add(lblRoleStaffBody);
        pnlRoleStaffCard.Controls.Add(lblRoleStaffTitle);
        pnlRoleStaffCard.Controls.Add(lblRoleStaffCaption);
        pnlRoleStaffCard.Controls.Add(lblRoleStaffIcon);
        pnlRoleStaffCard.Dock = DockStyle.Fill;
        pnlRoleStaffCard.Location = new Point(229, 3);
        pnlRoleStaffCard.Name = "pnlRoleStaffCard";
        pnlRoleStaffCard.Padding = new Padding(16);
        pnlRoleStaffCard.Size = new Size(220, 204);
        pnlRoleStaffCard.TabIndex = 1;
        // 
        // lblRoleStaffBadgeSecondary
        // 
        lblRoleStaffBadgeSecondary.AutoSize = true;
        lblRoleStaffBadgeSecondary.BackColor = Color.FromArgb(225, 237, 246);
        lblRoleStaffBadgeSecondary.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblRoleStaffBadgeSecondary.ForeColor = Color.FromArgb(42, 51, 64);
        lblRoleStaffBadgeSecondary.Location = new Point(98, 166);
        lblRoleStaffBadgeSecondary.Name = "lblRoleStaffBadgeSecondary";
        lblRoleStaffBadgeSecondary.Padding = new Padding(8, 4, 8, 4);
        lblRoleStaffBadgeSecondary.Size = new Size(90, 27);
        lblRoleStaffBadgeSecondary.TabIndex = 5;
        lblRoleStaffBadgeSecondary.Text = "HẬU CẦN";
        // 
        // lblRoleStaffBadgePrimary
        // 
        lblRoleStaffBadgePrimary.AutoSize = true;
        lblRoleStaffBadgePrimary.BackColor = Color.FromArgb(225, 237, 246);
        lblRoleStaffBadgePrimary.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblRoleStaffBadgePrimary.ForeColor = Color.FromArgb(0, 110, 110);
        lblRoleStaffBadgePrimary.Location = new Point(16, 166);
        lblRoleStaffBadgePrimary.Name = "lblRoleStaffBadgePrimary";
        lblRoleStaffBadgePrimary.Padding = new Padding(8, 4, 8, 4);
        lblRoleStaffBadgePrimary.Size = new Size(102, 27);
        lblRoleStaffBadgePrimary.TabIndex = 4;
        lblRoleStaffBadgePrimary.Text = "VẬN HÀNH";
        // 
        // lblRoleStaffBody
        // 
        lblRoleStaffBody.Font = new Font("Segoe UI", 9.5F);
        lblRoleStaffBody.ForeColor = Color.FromArgb(42, 51, 64);
        lblRoleStaffBody.Location = new Point(16, 84);
        lblRoleStaffBody.Name = "lblRoleStaffBody";
        lblRoleStaffBody.Size = new Size(178, 70);
        lblRoleStaffBody.TabIndex = 3;
        lblRoleStaffBody.Text = "Ghi danh, thanh toán, hậu cần và điều phối lớp học cho toàn trung tâm.";
        // 
        // lblRoleStaffTitle
        // 
        lblRoleStaffTitle.AutoSize = true;
        lblRoleStaffTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblRoleStaffTitle.ForeColor = Color.FromArgb(0, 110, 110);
        lblRoleStaffTitle.Location = new Point(16, 50);
        lblRoleStaffTitle.Name = "lblRoleStaffTitle";
        lblRoleStaffTitle.Size = new Size(182, 25);
        lblRoleStaffTitle.TabIndex = 2;
        lblRoleStaffTitle.Text = "Quy trình vận hành";
        // 
        // lblRoleStaffCaption
        // 
        lblRoleStaffCaption.AutoSize = true;
        lblRoleStaffCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblRoleStaffCaption.ForeColor = Color.FromArgb(7, 30, 39);
        lblRoleStaffCaption.Location = new Point(16, 18);
        lblRoleStaffCaption.Name = "lblRoleStaffCaption";
        lblRoleStaffCaption.Size = new Size(94, 20);
        lblRoleStaffCaption.TabIndex = 1;
        lblRoleStaffCaption.Text = "NHÂN VIÊN";
        // 
        // lblRoleStaffIcon
        // 
        lblRoleStaffIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblRoleStaffIcon.Font = new Font("Segoe UI Symbol", 34F);
        lblRoleStaffIcon.ForeColor = Color.FromArgb(225, 231, 238);
        lblRoleStaffIcon.Location = new Point(164, 14);
        lblRoleStaffIcon.Name = "lblRoleStaffIcon";
        lblRoleStaffIcon.Size = new Size(42, 56);
        lblRoleStaffIcon.TabIndex = 0;
        lblRoleStaffIcon.Text = "⚙";
        lblRoleStaffIcon.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlRoleTeacherCard
        // 
        pnlRoleTeacherCard.BackColor = Color.White;
        pnlRoleTeacherCard.BorderStyle = BorderStyle.FixedSingle;
        pnlRoleTeacherCard.Controls.Add(lblRoleTeacherBadgeSecondary);
        pnlRoleTeacherCard.Controls.Add(lblRoleTeacherBadgePrimary);
        pnlRoleTeacherCard.Controls.Add(lblRoleTeacherBody);
        pnlRoleTeacherCard.Controls.Add(lblRoleTeacherTitle);
        pnlRoleTeacherCard.Controls.Add(lblRoleTeacherCaption);
        pnlRoleTeacherCard.Controls.Add(lblRoleTeacherIcon);
        pnlRoleTeacherCard.Dock = DockStyle.Fill;
        pnlRoleTeacherCard.Location = new Point(455, 3);
        pnlRoleTeacherCard.Name = "pnlRoleTeacherCard";
        pnlRoleTeacherCard.Padding = new Padding(16);
        pnlRoleTeacherCard.Size = new Size(222, 204);
        pnlRoleTeacherCard.TabIndex = 2;
        // 
        // lblRoleTeacherBadgeSecondary
        // 
        lblRoleTeacherBadgeSecondary.AutoSize = true;
        lblRoleTeacherBadgeSecondary.BackColor = Color.FromArgb(225, 237, 246);
        lblRoleTeacherBadgeSecondary.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblRoleTeacherBadgeSecondary.ForeColor = Color.FromArgb(42, 51, 64);
        lblRoleTeacherBadgeSecondary.Location = new Point(96, 166);
        lblRoleTeacherBadgeSecondary.Name = "lblRoleTeacherBadgeSecondary";
        lblRoleTeacherBadgeSecondary.Padding = new Padding(8, 4, 8, 4);
        lblRoleTeacherBadgeSecondary.Size = new Size(79, 27);
        lblRoleTeacherBadgeSecondary.TabIndex = 5;
        lblRoleTeacherBadgeSecondary.Text = "CỐ VẤN";
        // 
        // lblRoleTeacherBadgePrimary
        // 
        lblRoleTeacherBadgePrimary.AutoSize = true;
        lblRoleTeacherBadgePrimary.BackColor = Color.FromArgb(255, 236, 217);
        lblRoleTeacherBadgePrimary.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
        lblRoleTeacherBadgePrimary.ForeColor = Color.FromArgb(124, 45, 18);
        lblRoleTeacherBadgePrimary.Location = new Point(16, 166);
        lblRoleTeacherBadgePrimary.Name = "lblRoleTeacherBadgePrimary";
        lblRoleTeacherBadgePrimary.Padding = new Padding(8, 4, 8, 4);
        lblRoleTeacherBadgePrimary.Size = new Size(107, 27);
        lblRoleTeacherBadgePrimary.TabIndex = 4;
        lblRoleTeacherBadgePrimary.Text = "HỌC THUẬT";
        // 
        // lblRoleTeacherBody
        // 
        lblRoleTeacherBody.Font = new Font("Segoe UI", 9.5F);
        lblRoleTeacherBody.ForeColor = Color.FromArgb(42, 51, 64);
        lblRoleTeacherBody.Location = new Point(16, 84);
        lblRoleTeacherBody.Name = "lblRoleTeacherBody";
        lblRoleTeacherBody.Size = new Size(178, 70);
        lblRoleTeacherBody.TabIndex = 3;
        lblRoleTeacherBody.Text = "Giảng dạy, đánh giá, theo dõi tiến độ và lập kế hoạch học thuật cho học sinh.";
        // 
        // lblRoleTeacherTitle
        // 
        lblRoleTeacherTitle.AutoSize = true;
        lblRoleTeacherTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblRoleTeacherTitle.ForeColor = Color.FromArgb(124, 45, 18);
        lblRoleTeacherTitle.Location = new Point(16, 50);
        lblRoleTeacherTitle.Name = "lblRoleTeacherTitle";
        lblRoleTeacherTitle.Size = new Size(191, 25);
        lblRoleTeacherTitle.TabIndex = 2;
        lblRoleTeacherTitle.Text = "Giảng dạy & Đánh giá";
        // 
        // lblRoleTeacherCaption
        // 
        lblRoleTeacherCaption.AutoSize = true;
        lblRoleTeacherCaption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblRoleTeacherCaption.ForeColor = Color.FromArgb(7, 30, 39);
        lblRoleTeacherCaption.Location = new Point(16, 18);
        lblRoleTeacherCaption.Name = "lblRoleTeacherCaption";
        lblRoleTeacherCaption.Size = new Size(86, 20);
        lblRoleTeacherCaption.TabIndex = 1;
        lblRoleTeacherCaption.Text = "GIÁO VIÊN";
        // 
        // lblRoleTeacherIcon
        // 
        lblRoleTeacherIcon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblRoleTeacherIcon.Font = new Font("Segoe UI Symbol", 40F);
        lblRoleTeacherIcon.ForeColor = Color.FromArgb(230, 234, 239);
        lblRoleTeacherIcon.Location = new Point(161, 12);
        lblRoleTeacherIcon.Name = "lblRoleTeacherIcon";
        lblRoleTeacherIcon.Size = new Size(46, 60);
        lblRoleTeacherIcon.TabIndex = 0;
        lblRoleTeacherIcon.Text = "⌂";
        lblRoleTeacherIcon.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblDashboardSubtitle
        // 
        lblDashboardSubtitle.AutoSize = true;
        lblDashboardSubtitle.Font = new Font("Segoe UI", 11F);
        lblDashboardSubtitle.ForeColor = Color.FromArgb(42, 51, 64);
        lblDashboardSubtitle.Location = new Point(20, 62);
        lblDashboardSubtitle.Name = "lblDashboardSubtitle";
        lblDashboardSubtitle.Size = new Size(551, 25);
        lblDashboardSubtitle.TabIndex = 1;
        lblDashboardSubtitle.Text = "Cấu hình phân quyền hệ thống và phân cấp kiến trúc trung tâm.";
        // 
        // lblDashboardTitle
        // 
        lblDashboardTitle.AutoSize = true;
        lblDashboardTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblDashboardTitle.ForeColor = Color.FromArgb(7, 30, 39);
        lblDashboardTitle.Location = new Point(16, 12);
        lblDashboardTitle.Name = "lblDashboardTitle";
        lblDashboardTitle.Size = new Size(525, 46);
        lblDashboardTitle.TabIndex = 0;
        lblDashboardTitle.Text = "TỔNG QUAN QUYỀN TRUY CẬP";
        // 
        // FrmAdminDashboard
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(244, 251, 255);
        ClientSize = new Size(920, 580);
        Controls.Add(pnlContentHostAdmin);
        Controls.Add(pnlTopbarAdmin);
        Controls.Add(pnlSidebarAdmin);
        Font = new Font("Segoe UI", 9.5F);
        MinimumSize = new Size(920, 600);
        Name = "FrmAdminDashboard";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Dashboard quản trị";
        pnlSidebarAdmin.ResumeLayout(false);
        flpSidebarFooter.ResumeLayout(false);
        flpSidebarMenu.ResumeLayout(false);
        pnlSidebarBrand.ResumeLayout(false);
        pnlSidebarBrand.PerformLayout();
        pnlSidebarLogo.ResumeLayout(false);
        pnlTopbarAdmin.ResumeLayout(false);
        pnlTopbarAdmin.PerformLayout();
        pnlAvatarAdmin.ResumeLayout(false);
        flpTopNavAdmin.ResumeLayout(false);
        flpTopNavAdmin.PerformLayout();
        pnlContentHostAdmin.ResumeLayout(false);
        pnlDashboardHome.ResumeLayout(false);
        pnlDashboardHome.PerformLayout();
        pnlMatrixCard.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvDashboardWarnings).EndInit();
        pnlMatrixHeader.ResumeLayout(false);
        pnlMatrixHeader.PerformLayout();
        flpMatrixLegend.ResumeLayout(false);
        flpMatrixLegend.PerformLayout();
        tblRoleCards.ResumeLayout(false);
        pnlRoleAdminCard.ResumeLayout(false);
        pnlRoleAdminCard.PerformLayout();
        pnlRoleStaffCard.ResumeLayout(false);
        pnlRoleStaffCard.PerformLayout();
        pnlRoleTeacherCard.ResumeLayout(false);
        pnlRoleTeacherCard.PerformLayout();
        ResumeLayout(false);
    }
}
