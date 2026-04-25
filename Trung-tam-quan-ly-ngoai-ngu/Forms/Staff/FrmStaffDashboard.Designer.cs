namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmStaffDashboard
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlSidebarStaff;
    private Panel pnlSidebarBrandStaff;
    private Label lblSidebarBrandLine1;
    private Label lblSidebarBrandLine2;
    private Label lblSidebarBrandSubtitle;
    private FlowLayoutPanel flpSidebarMenuStaff;
    private Button btnMenuStaffDashboard;
    private Button btnMenuStudentManagement;
    private Button btnMenuTeacherManagement;
    private Button btnMenuCourseManagement;
    private Button btnMenuClassManagement;
    private Button btnMenuEnrollment;
    private Button btnMenuTuitionReceipt;
    private Button btnMenuDebtTracking;
    private Panel pnlSidebarFooterStaff;
    private Button btnLogoutStaff;
    private Panel pnlTopbarStaff;
    private TableLayoutPanel tblTopbarStaff;
    private Label lblTopbarTitleStaff;
    private FlowLayoutPanel flpTopbarActionsStaff;
    private Button btnTopbarNotifyStaff;
    private Button btnTopbarSettingsStaff;
    private Button btnTopbarHelpStaff;
    private Panel pnlTopbarProfileStaff;
    private Label lblCurrentUserStaff;
    private Label lblCurrentRoleStaff;
    private Panel pnlTopbarAvatarStaff;
    private Label lblTopbarAvatarStaff;
    private Panel pnlContentHostStaff;
    private Panel pnlDashboardHome;
    private TableLayoutPanel tblStaffDashboardRoot;
    private TableLayoutPanel tblStaffKpi;
    private Panel pnlNewStudentsToday;
    private Panel pnlNewStudentsAccent;
    private Label lblNewStudentsTodayTitle;
    private Label lblNewStudentsTodayValue;
    private Label lblNewStudentsTodayBadge;
    private Panel pnlAvailableClasses;
    private Panel pnlAvailableClassesAccent;
    private Label lblAvailableClassesTitle;
    private Label lblAvailableClassesValue;
    private Label lblAvailableClassesBadge;
    private Panel pnlTodayReceipts;
    private Panel pnlTodayReceiptsAccent;
    private Label lblTodayReceiptsTitle;
    private Label lblTodayReceiptsValue;
    private Label lblTodayReceiptsBadge;
    private Panel pnlDebtStudents;
    private Panel pnlDebtStudentsAccent;
    private Label lblDebtStudentsTitle;
    private Label lblDebtStudentsValue;
    private Label lblDebtStudentsBadge;
    private TableLayoutPanel tblStaffMain;
    private Panel pnlRecentReceiptCard;
    private Panel pnlRecentReceiptHeader;
    private Label lblRecentReceiptTitle;
    private LinkLabel lnkRecentReceiptAll;
    private DataGridView dgvRecentReceipts;
    private Panel pnlStaffActionCard;
    private Panel pnlStaffActionHeader;
    private Label lblStaffActionTitle;
    private FlowLayoutPanel flpStaffTaskList;
    private Panel pnlStaffActionFooter;
    private Button btnAddTaskStaff;
    private Panel pnlWeeklyProgressCard;
    private Panel pnlWeeklyProgressHeader;
    private Label lblWeeklyProgressTitle;
    private FlowLayoutPanel flpWeeklyLegend;
    private Panel pnlLegendDone;
    private Label lblLegendDone;
    private Panel pnlLegendRemaining;
    private Label lblLegendRemaining;
    private FlowLayoutPanel flpWeeklyProgressGrid;
    private Label lblWeeklyProgressSummary;

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
        pnlSidebarStaff = new Panel();
        flpSidebarMenuStaff = new FlowLayoutPanel();
        btnMenuStaffDashboard = new Button();
        btnMenuStudentManagement = new Button();
        btnMenuTeacherManagement = new Button();
        btnMenuCourseManagement = new Button();
        btnMenuClassManagement = new Button();
        btnMenuEnrollment = new Button();
        btnMenuTuitionReceipt = new Button();
        btnMenuDebtTracking = new Button();
        pnlSidebarFooterStaff = new Panel();
        btnLogoutStaff = new Button();
        pnlSidebarBrandStaff = new Panel();
        lblSidebarBrandSubtitle = new Label();
        lblSidebarBrandLine2 = new Label();
        lblSidebarBrandLine1 = new Label();
        pnlTopbarStaff = new Panel();
        tblTopbarStaff = new TableLayoutPanel();
        lblTopbarTitleStaff = new Label();
        flpTopbarActionsStaff = new FlowLayoutPanel();
        btnTopbarNotifyStaff = new Button();
        btnTopbarSettingsStaff = new Button();
        btnTopbarHelpStaff = new Button();
        pnlTopbarProfileStaff = new Panel();
        pnlTopbarAvatarStaff = new Panel();
        lblTopbarAvatarStaff = new Label();
        lblCurrentRoleStaff = new Label();
        lblCurrentUserStaff = new Label();
        pnlContentHostStaff = new Panel();
        pnlDashboardHome = new Panel();
        tblStaffDashboardRoot = new TableLayoutPanel();
        tblStaffKpi = new TableLayoutPanel();
        pnlNewStudentsToday = new Panel();
        lblNewStudentsTodayBadge = new Label();
        lblNewStudentsTodayValue = new Label();
        lblNewStudentsTodayTitle = new Label();
        pnlNewStudentsAccent = new Panel();
        pnlAvailableClasses = new Panel();
        lblAvailableClassesBadge = new Label();
        lblAvailableClassesValue = new Label();
        lblAvailableClassesTitle = new Label();
        pnlAvailableClassesAccent = new Panel();
        pnlTodayReceipts = new Panel();
        lblTodayReceiptsBadge = new Label();
        lblTodayReceiptsValue = new Label();
        lblTodayReceiptsTitle = new Label();
        pnlTodayReceiptsAccent = new Panel();
        pnlDebtStudents = new Panel();
        lblDebtStudentsBadge = new Label();
        lblDebtStudentsValue = new Label();
        lblDebtStudentsTitle = new Label();
        pnlDebtStudentsAccent = new Panel();
        tblStaffMain = new TableLayoutPanel();
        pnlRecentReceiptCard = new Panel();
        dgvRecentReceipts = new DataGridView();
        pnlRecentReceiptHeader = new Panel();
        lnkRecentReceiptAll = new LinkLabel();
        lblRecentReceiptTitle = new Label();
        pnlStaffActionCard = new Panel();
        flpStaffTaskList = new FlowLayoutPanel();
        pnlStaffActionFooter = new Panel();
        btnAddTaskStaff = new Button();
        pnlStaffActionHeader = new Panel();
        lblStaffActionTitle = new Label();
        pnlWeeklyProgressCard = new Panel();
        lblWeeklyProgressSummary = new Label();
        flpWeeklyProgressGrid = new FlowLayoutPanel();
        pnlWeeklyProgressHeader = new Panel();
        flpWeeklyLegend = new FlowLayoutPanel();
        pnlLegendDone = new Panel();
        lblLegendDone = new Label();
        pnlLegendRemaining = new Panel();
        lblLegendRemaining = new Label();
        lblWeeklyProgressTitle = new Label();
        pnlSidebarStaff.SuspendLayout();
        flpSidebarMenuStaff.SuspendLayout();
        pnlSidebarFooterStaff.SuspendLayout();
        pnlSidebarBrandStaff.SuspendLayout();
        pnlTopbarStaff.SuspendLayout();
        tblTopbarStaff.SuspendLayout();
        flpTopbarActionsStaff.SuspendLayout();
        pnlTopbarProfileStaff.SuspendLayout();
        pnlTopbarAvatarStaff.SuspendLayout();
        pnlContentHostStaff.SuspendLayout();
        pnlDashboardHome.SuspendLayout();
        tblStaffDashboardRoot.SuspendLayout();
        tblStaffKpi.SuspendLayout();
        pnlNewStudentsToday.SuspendLayout();
        pnlAvailableClasses.SuspendLayout();
        pnlTodayReceipts.SuspendLayout();
        pnlDebtStudents.SuspendLayout();
        tblStaffMain.SuspendLayout();
        pnlRecentReceiptCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvRecentReceipts).BeginInit();
        pnlRecentReceiptHeader.SuspendLayout();
        pnlStaffActionCard.SuspendLayout();
        pnlStaffActionFooter.SuspendLayout();
        pnlStaffActionHeader.SuspendLayout();
        pnlWeeklyProgressCard.SuspendLayout();
        pnlWeeklyProgressHeader.SuspendLayout();
        flpWeeklyLegend.SuspendLayout();
        SuspendLayout();
        // 
        // pnlSidebarStaff
        // 
        pnlSidebarStaff.BackColor = Color.FromArgb(226, 243, 255);
        pnlSidebarStaff.Controls.Add(flpSidebarMenuStaff);
        pnlSidebarStaff.Controls.Add(pnlSidebarFooterStaff);
        pnlSidebarStaff.Controls.Add(pnlSidebarBrandStaff);
        pnlSidebarStaff.Dock = DockStyle.Left;
        pnlSidebarStaff.Location = new Point(0, 0);
        pnlSidebarStaff.Name = "pnlSidebarStaff";
        pnlSidebarStaff.Padding = new Padding(0, 24, 0, 24);
        pnlSidebarStaff.Size = new Size(320, 900);
        pnlSidebarStaff.AutoScroll = false;
        pnlSidebarStaff.TabIndex = 0;
        // 
        // flpSidebarMenuStaff
        // 
        flpSidebarMenuStaff.Controls.Add(btnMenuStaffDashboard);
        flpSidebarMenuStaff.Controls.Add(btnMenuStudentManagement);
        flpSidebarMenuStaff.Controls.Add(btnMenuTeacherManagement);
        flpSidebarMenuStaff.Controls.Add(btnMenuCourseManagement);
        flpSidebarMenuStaff.Controls.Add(btnMenuClassManagement);
        flpSidebarMenuStaff.Controls.Add(btnMenuEnrollment);
        flpSidebarMenuStaff.Controls.Add(btnMenuTuitionReceipt);
        flpSidebarMenuStaff.Controls.Add(btnMenuDebtTracking);
        flpSidebarMenuStaff.Dock = DockStyle.Fill;
        flpSidebarMenuStaff.FlowDirection = FlowDirection.TopDown;
        flpSidebarMenuStaff.Location = new Point(0, 174);
        flpSidebarMenuStaff.Name = "flpSidebarMenuStaff";
        flpSidebarMenuStaff.Padding = new Padding(0, 12, 0, 0);
        flpSidebarMenuStaff.Size = new Size(320, 638);
        flpSidebarMenuStaff.AutoScroll = true;
        flpSidebarMenuStaff.TabIndex = 1;
        flpSidebarMenuStaff.WrapContents = false;
        // 
        // btnMenuStaffDashboard
        // 
        btnMenuStaffDashboard.Location = new Point(0, 15);
        btnMenuStaffDashboard.Margin = new Padding(0, 3, 0, 15);
        btnMenuStaffDashboard.Name = "btnMenuStaffDashboard";
        btnMenuStaffDashboard.Size = new Size(320, 58);
        btnMenuStaffDashboard.TabIndex = 0;
        btnMenuStaffDashboard.Text = "    DASHBOARD";
        btnMenuStaffDashboard.UseVisualStyleBackColor = true;
        // 
        // btnMenuStudentManagement
        // 
        btnMenuStudentManagement.Location = new Point(0, 91);
        btnMenuStudentManagement.Margin = new Padding(0, 3, 0, 12);
        btnMenuStudentManagement.Name = "btnMenuStudentManagement";
        btnMenuStudentManagement.Size = new Size(320, 52);
        btnMenuStudentManagement.TabIndex = 1;
        btnMenuStudentManagement.Text = "    HỌC VIÊN";
        btnMenuStudentManagement.UseVisualStyleBackColor = true;
        // 
        // btnMenuTeacherManagement
        // 
        btnMenuTeacherManagement.Location = new Point(0, 158);
        btnMenuTeacherManagement.Margin = new Padding(0, 3, 0, 12);
        btnMenuTeacherManagement.Name = "btnMenuTeacherManagement";
        btnMenuTeacherManagement.Size = new Size(320, 52);
        btnMenuTeacherManagement.TabIndex = 2;
        btnMenuTeacherManagement.Text = "    GIÁO VIÊN";
        btnMenuTeacherManagement.UseVisualStyleBackColor = true;
        // 
        // btnMenuCourseManagement
        // 
        btnMenuCourseManagement.Location = new Point(0, 225);
        btnMenuCourseManagement.Margin = new Padding(0, 3, 0, 12);
        btnMenuCourseManagement.Name = "btnMenuCourseManagement";
        btnMenuCourseManagement.Size = new Size(320, 52);
        btnMenuCourseManagement.TabIndex = 3;
        btnMenuCourseManagement.Text = "    KHÓA HỌC";
        btnMenuCourseManagement.UseVisualStyleBackColor = true;
        // 
        // btnMenuClassManagement
        // 
        btnMenuClassManagement.Location = new Point(0, 292);
        btnMenuClassManagement.Margin = new Padding(0, 3, 0, 12);
        btnMenuClassManagement.Name = "btnMenuClassManagement";
        btnMenuClassManagement.Size = new Size(320, 52);
        btnMenuClassManagement.TabIndex = 4;
        btnMenuClassManagement.Text = "    LỚP HỌC";
        btnMenuClassManagement.UseVisualStyleBackColor = true;
        // 
        // btnMenuEnrollment
        // 
        btnMenuEnrollment.Location = new Point(0, 359);
        btnMenuEnrollment.Margin = new Padding(0, 3, 0, 12);
        btnMenuEnrollment.Name = "btnMenuEnrollment";
        btnMenuEnrollment.Size = new Size(320, 52);
        btnMenuEnrollment.TabIndex = 5;
        btnMenuEnrollment.Text = "    GHI DANH";
        btnMenuEnrollment.UseVisualStyleBackColor = true;
        // 
        // btnMenuTuitionReceipt
        // 
        btnMenuTuitionReceipt.Location = new Point(0, 426);
        btnMenuTuitionReceipt.Margin = new Padding(0, 3, 0, 12);
        btnMenuTuitionReceipt.Name = "btnMenuTuitionReceipt";
        btnMenuTuitionReceipt.Size = new Size(320, 52);
        btnMenuTuitionReceipt.TabIndex = 6;
        btnMenuTuitionReceipt.Text = "    THU HỌC PHÍ";
        btnMenuTuitionReceipt.UseVisualStyleBackColor = true;
        // 
        // btnMenuDebtTracking
        // 
        btnMenuDebtTracking.Location = new Point(0, 493);
        btnMenuDebtTracking.Margin = new Padding(0, 3, 0, 12);
        btnMenuDebtTracking.Name = "btnMenuDebtTracking";
        btnMenuDebtTracking.Size = new Size(320, 52);
        btnMenuDebtTracking.TabIndex = 7;
        btnMenuDebtTracking.Text = "    CÔNG NỢ";
        btnMenuDebtTracking.UseVisualStyleBackColor = true;
        // 
        // pnlSidebarFooterStaff
        // 
        pnlSidebarFooterStaff.Controls.Add(btnLogoutStaff);
        pnlSidebarFooterStaff.Dock = DockStyle.Bottom;
        pnlSidebarFooterStaff.Location = new Point(0, 812);
        pnlSidebarFooterStaff.Name = "pnlSidebarFooterStaff";
        pnlSidebarFooterStaff.Padding = new Padding(28, 16, 28, 0);
        pnlSidebarFooterStaff.Size = new Size(320, 64);
        pnlSidebarFooterStaff.AutoScroll = false;
        pnlSidebarFooterStaff.TabIndex = 2;
        // 
        // btnLogoutStaff
        // 
        btnLogoutStaff.Dock = DockStyle.Left;
        btnLogoutStaff.Location = new Point(28, 16);
        btnLogoutStaff.Name = "btnLogoutStaff";
        btnLogoutStaff.Size = new Size(132, 48);
        btnLogoutStaff.TabIndex = 0;
        btnLogoutStaff.Text = "Đăng xuất";
        btnLogoutStaff.UseVisualStyleBackColor = true;
        // 
        // pnlSidebarBrandStaff
        // 
        pnlSidebarBrandStaff.Controls.Add(lblSidebarBrandSubtitle);
        pnlSidebarBrandStaff.Controls.Add(lblSidebarBrandLine2);
        pnlSidebarBrandStaff.Controls.Add(lblSidebarBrandLine1);
        pnlSidebarBrandStaff.Dock = DockStyle.Top;
        pnlSidebarBrandStaff.Location = new Point(0, 24);
        pnlSidebarBrandStaff.Name = "pnlSidebarBrandStaff";
        pnlSidebarBrandStaff.Padding = new Padding(30, 0, 24, 0);
        pnlSidebarBrandStaff.Size = new Size(320, 150);
        pnlSidebarBrandStaff.AutoScroll = false;
        pnlSidebarBrandStaff.TabIndex = 0;
        // 
        // lblSidebarBrandSubtitle
        // 
        lblSidebarBrandSubtitle.AutoSize = true;
        lblSidebarBrandSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        lblSidebarBrandSubtitle.ForeColor = Color.FromArgb(95, 109, 125);
        lblSidebarBrandSubtitle.Location = new Point(30, 104);
        lblSidebarBrandSubtitle.Name = "lblSidebarBrandSubtitle";
        lblSidebarBrandSubtitle.Size = new Size(180, 20);
        lblSidebarBrandSubtitle.TabIndex = 2;
        lblSidebarBrandSubtitle.Text = "OPERATIONAL CONTROL";
        // 
        // lblSidebarBrandLine2
        // 
        lblSidebarBrandLine2.AutoSize = true;
        lblSidebarBrandLine2.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
        lblSidebarBrandLine2.ForeColor = Color.FromArgb(9, 25, 38);
        lblSidebarBrandLine2.Location = new Point(30, 40);
        lblSidebarBrandLine2.Name = "lblSidebarBrandLine2";
        lblSidebarBrandLine2.Size = new Size(166, 46);
        lblSidebarBrandLine2.TabIndex = 1;
        lblSidebarBrandLine2.Text = "ARCHITECT";
        // 
        // lblSidebarBrandLine1
        // 
        lblSidebarBrandLine1.AutoSize = true;
        lblSidebarBrandLine1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
        lblSidebarBrandLine1.ForeColor = Color.FromArgb(9, 25, 38);
        lblSidebarBrandLine1.Location = new Point(30, 0);
        lblSidebarBrandLine1.Name = "lblSidebarBrandLine1";
        lblSidebarBrandLine1.Size = new Size(157, 46);
        lblSidebarBrandLine1.TabIndex = 0;
        lblSidebarBrandLine1.Text = "LINGUISTIC";
        // 
        // pnlTopbarStaff
        // 
        pnlTopbarStaff.BackColor = Color.FromArgb(237, 247, 255);
        pnlTopbarStaff.Controls.Add(tblTopbarStaff);
        pnlTopbarStaff.Dock = DockStyle.Top;
        pnlTopbarStaff.Location = new Point(320, 0);
        pnlTopbarStaff.Name = "pnlTopbarStaff";
        pnlTopbarStaff.Padding = new Padding(26, 20, 26, 20);
        pnlTopbarStaff.Size = new Size(1280, 120);
        pnlTopbarStaff.AutoScroll = false;
        pnlTopbarStaff.TabIndex = 1;
        // 
        // tblTopbarStaff
        // 
        tblTopbarStaff.ColumnCount = 3;
        tblTopbarStaff.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblTopbarStaff.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 188F));
        tblTopbarStaff.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
        tblTopbarStaff.Controls.Add(lblTopbarTitleStaff, 0, 0);
        tblTopbarStaff.Controls.Add(flpTopbarActionsStaff, 1, 0);
        tblTopbarStaff.Controls.Add(pnlTopbarProfileStaff, 2, 0);
        tblTopbarStaff.Dock = DockStyle.Fill;
        tblTopbarStaff.Location = new Point(26, 20);
        tblTopbarStaff.Name = "tblTopbarStaff";
        tblTopbarStaff.RowCount = 1;
        tblTopbarStaff.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblTopbarStaff.Size = new Size(1228, 80);
        tblTopbarStaff.AutoScroll = false;
        tblTopbarStaff.TabIndex = 0;
        // 
        // lblTopbarTitleStaff
        // 
        lblTopbarTitleStaff.Dock = DockStyle.Fill;
        lblTopbarTitleStaff.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
        lblTopbarTitleStaff.ForeColor = Color.FromArgb(10, 23, 36);
        lblTopbarTitleStaff.Location = new Point(0, 0);
        lblTopbarTitleStaff.Margin = new Padding(0);
        lblTopbarTitleStaff.Name = "lblTopbarTitleStaff";
        lblTopbarTitleStaff.Size = new Size(790, 80);
        lblTopbarTitleStaff.TabIndex = 0;
        lblTopbarTitleStaff.Text = "BẢNG ĐIỀU KHIỂN VẬN HÀNH";
        lblTopbarTitleStaff.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // flpTopbarActionsStaff
        // 
        flpTopbarActionsStaff.Controls.Add(btnTopbarNotifyStaff);
        flpTopbarActionsStaff.Controls.Add(btnTopbarSettingsStaff);
        flpTopbarActionsStaff.Controls.Add(btnTopbarHelpStaff);
        flpTopbarActionsStaff.Dock = DockStyle.Fill;
        flpTopbarActionsStaff.Location = new Point(790, 0);
        flpTopbarActionsStaff.Margin = new Padding(0);
        flpTopbarActionsStaff.Name = "flpTopbarActionsStaff";
        flpTopbarActionsStaff.Padding = new Padding(28, 14, 0, 0);
        flpTopbarActionsStaff.Size = new Size(188, 80);
        flpTopbarActionsStaff.AutoScroll = false;
        flpTopbarActionsStaff.TabIndex = 1;
        flpTopbarActionsStaff.WrapContents = false;
        // 
        // btnTopbarNotifyStaff
        // 
        btnTopbarNotifyStaff.Location = new Point(28, 14);
        btnTopbarNotifyStaff.Margin = new Padding(0, 0, 16, 0);
        btnTopbarNotifyStaff.Name = "btnTopbarNotifyStaff";
        btnTopbarNotifyStaff.Size = new Size(40, 40);
        btnTopbarNotifyStaff.TabIndex = 0;
        btnTopbarNotifyStaff.Text = "Thông báo";
        btnTopbarNotifyStaff.UseVisualStyleBackColor = true;
        // 
        // btnTopbarSettingsStaff
        // 
        btnTopbarSettingsStaff.Location = new Point(84, 14);
        btnTopbarSettingsStaff.Margin = new Padding(0, 0, 16, 0);
        btnTopbarSettingsStaff.Name = "btnTopbarSettingsStaff";
        btnTopbarSettingsStaff.Size = new Size(40, 40);
        btnTopbarSettingsStaff.TabIndex = 1;
        btnTopbarSettingsStaff.Text = "Cài đặt";
        btnTopbarSettingsStaff.UseVisualStyleBackColor = true;
        // 
        // btnTopbarHelpStaff
        // 
        btnTopbarHelpStaff.Location = new Point(140, 14);
        btnTopbarHelpStaff.Margin = new Padding(0);
        btnTopbarHelpStaff.Name = "btnTopbarHelpStaff";
        btnTopbarHelpStaff.Size = new Size(40, 40);
        btnTopbarHelpStaff.TabIndex = 2;
        btnTopbarHelpStaff.Text = "Hỗ trợ";
        btnTopbarHelpStaff.UseVisualStyleBackColor = true;
        // 
        // pnlTopbarProfileStaff
        // 
        pnlTopbarProfileStaff.Controls.Add(pnlTopbarAvatarStaff);
        pnlTopbarProfileStaff.Controls.Add(lblCurrentRoleStaff);
        pnlTopbarProfileStaff.Controls.Add(lblCurrentUserStaff);
        pnlTopbarProfileStaff.Dock = DockStyle.Fill;
        pnlTopbarProfileStaff.Location = new Point(978, 0);
        pnlTopbarProfileStaff.Margin = new Padding(0);
        pnlTopbarProfileStaff.Name = "pnlTopbarProfileStaff";
        pnlTopbarProfileStaff.Padding = new Padding(18, 10, 0, 10);
        pnlTopbarProfileStaff.Size = new Size(250, 80);
        pnlTopbarProfileStaff.AutoScroll = false;
        pnlTopbarProfileStaff.TabIndex = 2;
        // 
        // pnlTopbarAvatarStaff
        // 
        pnlTopbarAvatarStaff.Controls.Add(lblTopbarAvatarStaff);
        pnlTopbarAvatarStaff.Dock = DockStyle.Right;
        pnlTopbarAvatarStaff.Location = new Point(194, 10);
        pnlTopbarAvatarStaff.Name = "pnlTopbarAvatarStaff";
        pnlTopbarAvatarStaff.Size = new Size(56, 60);
        pnlTopbarAvatarStaff.AutoScroll = false;
        pnlTopbarAvatarStaff.TabIndex = 2;
        // 
        // lblTopbarAvatarStaff
        // 
        lblTopbarAvatarStaff.Dock = DockStyle.Fill;
        lblTopbarAvatarStaff.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblTopbarAvatarStaff.Location = new Point(0, 0);
        lblTopbarAvatarStaff.Name = "lblTopbarAvatarStaff";
        lblTopbarAvatarStaff.Size = new Size(56, 60);
        lblTopbarAvatarStaff.TabIndex = 0;
        lblTopbarAvatarStaff.Text = "AS";
        lblTopbarAvatarStaff.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblCurrentRoleStaff
        // 
        lblCurrentRoleStaff.AutoSize = true;
        lblCurrentRoleStaff.ForeColor = Color.FromArgb(101, 111, 124);
        lblCurrentRoleStaff.Location = new Point(18, 40);
        lblCurrentRoleStaff.Name = "lblCurrentRoleStaff";
        lblCurrentRoleStaff.Size = new Size(162, 20);
        lblCurrentRoleStaff.TabIndex = 1;
        lblCurrentRoleStaff.Text = "Linguistic Architect CMS";
        // 
        // lblCurrentUserStaff
        // 
        lblCurrentUserStaff.AutoSize = true;
        lblCurrentUserStaff.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblCurrentUserStaff.Location = new Point(18, 14);
        lblCurrentUserStaff.Name = "lblCurrentUserStaff";
        lblCurrentUserStaff.Size = new Size(101, 23);
        lblCurrentUserStaff.TabIndex = 0;
        lblCurrentUserStaff.Text = "Admin Staff";
        // 
        // pnlContentHostStaff
        // 
        pnlContentHostStaff.AutoScroll = true;
        pnlContentHostStaff.Controls.Add(pnlDashboardHome);
        pnlContentHostStaff.Dock = DockStyle.Fill;
        pnlContentHostStaff.Location = new Point(320, 120);
        pnlContentHostStaff.Name = "pnlContentHostStaff";
        pnlContentHostStaff.Padding = new Padding(28, 0, 28, 28);
        pnlContentHostStaff.Size = new Size(1280, 780);
        pnlContentHostStaff.TabIndex = 2;
        // 
        // pnlDashboardHome
        // 
        pnlDashboardHome.Controls.Add(tblStaffDashboardRoot);
        pnlDashboardHome.Dock = DockStyle.Top;
        pnlDashboardHome.Location = new Point(28, 0);
        pnlDashboardHome.Name = "pnlDashboardHome";
        pnlDashboardHome.Size = new Size(1224, 1180);
        pnlDashboardHome.AutoScroll = false;
        pnlDashboardHome.TabIndex = 0;
        // 
        // tblStaffDashboardRoot
        // 
        tblStaffDashboardRoot.ColumnCount = 1;
        tblStaffDashboardRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblStaffDashboardRoot.Controls.Add(tblStaffKpi, 0, 0);
        tblStaffDashboardRoot.Controls.Add(tblStaffMain, 0, 1);
        tblStaffDashboardRoot.Controls.Add(pnlWeeklyProgressCard, 0, 2);
        tblStaffDashboardRoot.Dock = DockStyle.Fill;
        tblStaffDashboardRoot.Location = new Point(0, 0);
        tblStaffDashboardRoot.Name = "tblStaffDashboardRoot";
        tblStaffDashboardRoot.RowCount = 3;
        tblStaffDashboardRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tblStaffDashboardRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tblStaffDashboardRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tblStaffDashboardRoot.Size = new Size(1224, 1180);
        tblStaffDashboardRoot.AutoScroll = false;
        tblStaffDashboardRoot.TabIndex = 0;
        // 
        // tblStaffKpi
        // 
        tblStaffKpi.ColumnCount = 4;
        tblStaffKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblStaffKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblStaffKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblStaffKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblStaffKpi.Controls.Add(pnlNewStudentsToday, 0, 0);
        tblStaffKpi.Controls.Add(pnlAvailableClasses, 1, 0);
        tblStaffKpi.Controls.Add(pnlTodayReceipts, 2, 0);
        tblStaffKpi.Controls.Add(pnlDebtStudents, 3, 0);
        tblStaffKpi.Dock = DockStyle.Fill;
        tblStaffKpi.Location = new Point(0, 0);
        tblStaffKpi.Margin = new Padding(0, 0, 0, 28);
        tblStaffKpi.Name = "tblStaffKpi";
        tblStaffKpi.RowCount = 1;
        tblStaffKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblStaffKpi.Size = new Size(1224, 132);
        tblStaffKpi.AutoScroll = false;
        tblStaffKpi.TabIndex = 0;
        // 
        // pnlNewStudentsToday
        // 
        pnlNewStudentsToday.Controls.Add(lblNewStudentsTodayBadge);
        pnlNewStudentsToday.Controls.Add(lblNewStudentsTodayValue);
        pnlNewStudentsToday.Controls.Add(lblNewStudentsTodayTitle);
        pnlNewStudentsToday.Controls.Add(pnlNewStudentsAccent);
        pnlNewStudentsToday.Dock = DockStyle.Fill;
        pnlNewStudentsToday.Location = new Point(0, 0);
        pnlNewStudentsToday.Margin = new Padding(0, 0, 16, 0);
        pnlNewStudentsToday.Name = "pnlNewStudentsToday";
        pnlNewStudentsToday.Padding = new Padding(28, 22, 22, 22);
        pnlNewStudentsToday.Size = new Size(290, 132);
        pnlNewStudentsToday.AutoScroll = false;
        pnlNewStudentsToday.TabIndex = 0;
        // 
        // pnlNewStudentsAccent
        // 
        pnlNewStudentsAccent.Dock = DockStyle.Left;
        pnlNewStudentsAccent.Location = new Point(28, 22);
        pnlNewStudentsAccent.Name = "pnlNewStudentsAccent";
        pnlNewStudentsAccent.Size = new Size(4, 88);
        pnlNewStudentsAccent.AutoScroll = false;
        pnlNewStudentsAccent.TabIndex = 0;
        // 
        // lblNewStudentsTodayTitle
        // 
        lblNewStudentsTodayTitle.AutoSize = true;
        lblNewStudentsTodayTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
        lblNewStudentsTodayTitle.Location = new Point(58, 24);
        lblNewStudentsTodayTitle.Name = "lblNewStudentsTodayTitle";
        lblNewStudentsTodayTitle.Size = new Size(128, 25);
        lblNewStudentsTodayTitle.TabIndex = 1;
        lblNewStudentsTodayTitle.Text = "HỌC VIÊN MỚI";
        // 
        // lblNewStudentsTodayValue
        // 
        lblNewStudentsTodayValue.AutoSize = true;
        lblNewStudentsTodayValue.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point);
        lblNewStudentsTodayValue.Location = new Point(54, 42);
        lblNewStudentsTodayValue.Name = "lblNewStudentsTodayValue";
        lblNewStudentsTodayValue.Size = new Size(75, 67);
        lblNewStudentsTodayValue.TabIndex = 2;
        lblNewStudentsTodayValue.Text = "124";
        // 
        // lblNewStudentsTodayBadge
        // 
        lblNewStudentsTodayBadge.AutoSize = true;
        lblNewStudentsTodayBadge.Location = new Point(176, 80);
        lblNewStudentsTodayBadge.Name = "lblNewStudentsTodayBadge";
        lblNewStudentsTodayBadge.Size = new Size(117, 20);
        lblNewStudentsTodayBadge.TabIndex = 3;
        lblNewStudentsTodayBadge.Text = "+12% THÁNG NÀY";
        // 
        // pnlAvailableClasses
        // 
        pnlAvailableClasses.Controls.Add(lblAvailableClassesBadge);
        pnlAvailableClasses.Controls.Add(lblAvailableClassesValue);
        pnlAvailableClasses.Controls.Add(lblAvailableClassesTitle);
        pnlAvailableClasses.Controls.Add(pnlAvailableClassesAccent);
        pnlAvailableClasses.Dock = DockStyle.Fill;
        pnlAvailableClasses.Location = new Point(306, 0);
        pnlAvailableClasses.Margin = new Padding(0, 0, 16, 0);
        pnlAvailableClasses.Name = "pnlAvailableClasses";
        pnlAvailableClasses.Padding = new Padding(28, 22, 22, 22);
        pnlAvailableClasses.Size = new Size(290, 132);
        pnlAvailableClasses.AutoScroll = false;
        pnlAvailableClasses.TabIndex = 1;
        // 
        // pnlAvailableClassesAccent
        // 
        pnlAvailableClassesAccent.Dock = DockStyle.Left;
        pnlAvailableClassesAccent.Location = new Point(28, 22);
        pnlAvailableClassesAccent.Name = "pnlAvailableClassesAccent";
        pnlAvailableClassesAccent.Size = new Size(4, 88);
        pnlAvailableClassesAccent.AutoScroll = false;
        pnlAvailableClassesAccent.TabIndex = 0;
        // 
        // lblAvailableClassesTitle
        // 
        lblAvailableClassesTitle.AutoSize = true;
        lblAvailableClassesTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
        lblAvailableClassesTitle.Location = new Point(58, 24);
        lblAvailableClassesTitle.Name = "lblAvailableClassesTitle";
        lblAvailableClassesTitle.Size = new Size(118, 25);
        lblAvailableClassesTitle.TabIndex = 1;
        lblAvailableClassesTitle.Text = "LỚP CÒN CHỖ";
        // 
        // lblAvailableClassesValue
        // 
        lblAvailableClassesValue.AutoSize = true;
        lblAvailableClassesValue.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point);
        lblAvailableClassesValue.Location = new Point(54, 42);
        lblAvailableClassesValue.Name = "lblAvailableClassesValue";
        lblAvailableClassesValue.Size = new Size(54, 67);
        lblAvailableClassesValue.TabIndex = 2;
        lblAvailableClassesValue.Text = "18";
        // 
        // lblAvailableClassesBadge
        // 
        lblAvailableClassesBadge.AutoSize = true;
        lblAvailableClassesBadge.Location = new Point(176, 80);
        lblAvailableClassesBadge.Name = "lblAvailableClassesBadge";
        lblAvailableClassesBadge.Size = new Size(101, 20);
        lblAvailableClassesBadge.TabIndex = 3;
        lblAvailableClassesBadge.Text = "42 TỔNG LỚP";
        // 
        // pnlTodayReceipts
        // 
        pnlTodayReceipts.Controls.Add(lblTodayReceiptsBadge);
        pnlTodayReceipts.Controls.Add(lblTodayReceiptsValue);
        pnlTodayReceipts.Controls.Add(lblTodayReceiptsTitle);
        pnlTodayReceipts.Controls.Add(pnlTodayReceiptsAccent);
        pnlTodayReceipts.Dock = DockStyle.Fill;
        pnlTodayReceipts.Location = new Point(612, 0);
        pnlTodayReceipts.Margin = new Padding(0, 0, 16, 0);
        pnlTodayReceipts.Name = "pnlTodayReceipts";
        pnlTodayReceipts.Padding = new Padding(28, 22, 22, 22);
        pnlTodayReceipts.Size = new Size(290, 132);
        pnlTodayReceipts.AutoScroll = false;
        pnlTodayReceipts.TabIndex = 2;
        // 
        // pnlTodayReceiptsAccent
        // 
        pnlTodayReceiptsAccent.Dock = DockStyle.Left;
        pnlTodayReceiptsAccent.Location = new Point(28, 22);
        pnlTodayReceiptsAccent.Name = "pnlTodayReceiptsAccent";
        pnlTodayReceiptsAccent.Size = new Size(4, 88);
        pnlTodayReceiptsAccent.AutoScroll = false;
        pnlTodayReceiptsAccent.TabIndex = 0;
        // 
        // lblTodayReceiptsTitle
        // 
        lblTodayReceiptsTitle.AutoSize = true;
        lblTodayReceiptsTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
        lblTodayReceiptsTitle.Location = new Point(58, 24);
        lblTodayReceiptsTitle.Name = "lblTodayReceiptsTitle";
        lblTodayReceiptsTitle.Size = new Size(176, 25);
        lblTodayReceiptsTitle.TabIndex = 1;
        lblTodayReceiptsTitle.Text = "PHIẾU THU HÔM NAY";
        // 
        // lblTodayReceiptsValue
        // 
        lblTodayReceiptsValue.AutoSize = true;
        lblTodayReceiptsValue.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point);
        lblTodayReceiptsValue.Location = new Point(54, 42);
        lblTodayReceiptsValue.Name = "lblTodayReceiptsValue";
        lblTodayReceiptsValue.Size = new Size(54, 67);
        lblTodayReceiptsValue.TabIndex = 2;
        lblTodayReceiptsValue.Text = "45";
        // 
        // lblTodayReceiptsBadge
        // 
        lblTodayReceiptsBadge.AutoSize = true;
        lblTodayReceiptsBadge.Location = new Point(176, 80);
        lblTodayReceiptsBadge.Name = "lblTodayReceiptsBadge";
        lblTodayReceiptsBadge.Size = new Size(78, 20);
        lblTodayReceiptsBadge.TabIndex = 3;
        lblTodayReceiptsBadge.Text = "78.2M VND";
        // 
        // pnlDebtStudents
        // 
        pnlDebtStudents.Controls.Add(lblDebtStudentsBadge);
        pnlDebtStudents.Controls.Add(lblDebtStudentsValue);
        pnlDebtStudents.Controls.Add(lblDebtStudentsTitle);
        pnlDebtStudents.Controls.Add(pnlDebtStudentsAccent);
        pnlDebtStudents.Dock = DockStyle.Fill;
        pnlDebtStudents.Location = new Point(918, 0);
        pnlDebtStudents.Margin = new Padding(0);
        pnlDebtStudents.Name = "pnlDebtStudents";
        pnlDebtStudents.Padding = new Padding(28, 22, 22, 22);
        pnlDebtStudents.Size = new Size(306, 132);
        pnlDebtStudents.AutoScroll = false;
        pnlDebtStudents.TabIndex = 3;
        // 
        // pnlDebtStudentsAccent
        // 
        pnlDebtStudentsAccent.Dock = DockStyle.Left;
        pnlDebtStudentsAccent.Location = new Point(28, 22);
        pnlDebtStudentsAccent.Name = "pnlDebtStudentsAccent";
        pnlDebtStudentsAccent.Size = new Size(4, 88);
        pnlDebtStudentsAccent.AutoScroll = false;
        pnlDebtStudentsAccent.TabIndex = 0;
        // 
        // lblDebtStudentsTitle
        // 
        lblDebtStudentsTitle.AutoSize = true;
        lblDebtStudentsTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
        lblDebtStudentsTitle.Location = new Point(58, 24);
        lblDebtStudentsTitle.Name = "lblDebtStudentsTitle";
        lblDebtStudentsTitle.Size = new Size(155, 25);
        lblDebtStudentsTitle.TabIndex = 1;
        lblDebtStudentsTitle.Text = "HỌC VIÊN NỢ PHÍ";
        // 
        // lblDebtStudentsValue
        // 
        lblDebtStudentsValue.AutoSize = true;
        lblDebtStudentsValue.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point);
        lblDebtStudentsValue.Location = new Point(54, 42);
        lblDebtStudentsValue.Name = "lblDebtStudentsValue";
        lblDebtStudentsValue.Size = new Size(54, 67);
        lblDebtStudentsValue.TabIndex = 2;
        lblDebtStudentsValue.Text = "12";
        // 
        // lblDebtStudentsBadge
        // 
        lblDebtStudentsBadge.AutoSize = true;
        lblDebtStudentsBadge.Location = new Point(206, 80);
        lblDebtStudentsBadge.Name = "lblDebtStudentsBadge";
        lblDebtStudentsBadge.Size = new Size(72, 20);
        lblDebtStudentsBadge.TabIndex = 3;
        lblDebtStudentsBadge.Text = "CẦN XỬ LÝ";
        // 
        // tblStaffMain
        // 
        tblStaffMain.ColumnCount = 2;
        tblStaffMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63F));
        tblStaffMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37F));
        tblStaffMain.Controls.Add(pnlRecentReceiptCard, 0, 0);
        tblStaffMain.Controls.Add(pnlStaffActionCard, 1, 0);
        tblStaffMain.Dock = DockStyle.Fill;
        tblStaffMain.Location = new Point(0, 142);
        tblStaffMain.Margin = new Padding(0, 0, 0, 28);
        tblStaffMain.Name = "tblStaffMain";
        tblStaffMain.RowCount = 1;
        tblStaffMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblStaffMain.Size = new Size(1224, 532);
        tblStaffMain.AutoScroll = true;
        tblStaffMain.TabIndex = 1;
        // 
        // pnlRecentReceiptCard
        // 
        pnlRecentReceiptCard.Controls.Add(dgvRecentReceipts);
        pnlRecentReceiptCard.Controls.Add(pnlRecentReceiptHeader);
        pnlRecentReceiptCard.Dock = DockStyle.Fill;
        pnlRecentReceiptCard.Location = new Point(0, 0);
        pnlRecentReceiptCard.Margin = new Padding(0, 0, 20, 0);
        pnlRecentReceiptCard.Name = "pnlRecentReceiptCard";
        pnlRecentReceiptCard.Padding = new Padding(0, 0, 0, 18);
        pnlRecentReceiptCard.Size = new Size(751, 532);
        pnlRecentReceiptCard.AutoScroll = true;
        pnlRecentReceiptCard.TabIndex = 0;
        // 
        // dgvRecentReceipts
        // 
        dgvRecentReceipts.Dock = DockStyle.Fill;
        dgvRecentReceipts.Location = new Point(0, 64);
        dgvRecentReceipts.Name = "dgvRecentReceipts";
        dgvRecentReceipts.RowHeadersWidth = 51;
        dgvRecentReceipts.Size = new Size(751, 450);
        dgvRecentReceipts.TabIndex = 1;
        // 
        // pnlRecentReceiptHeader
        // 
        pnlRecentReceiptHeader.Controls.Add(lnkRecentReceiptAll);
        pnlRecentReceiptHeader.Controls.Add(lblRecentReceiptTitle);
        pnlRecentReceiptHeader.Dock = DockStyle.Top;
        pnlRecentReceiptHeader.Location = new Point(0, 0);
        pnlRecentReceiptHeader.Name = "pnlRecentReceiptHeader";
        pnlRecentReceiptHeader.Padding = new Padding(28, 18, 28, 16);
        pnlRecentReceiptHeader.Size = new Size(751, 64);
        pnlRecentReceiptHeader.AutoScroll = true;
        pnlRecentReceiptHeader.TabIndex = 0;
        // 
        // lnkRecentReceiptAll
        // 
        lnkRecentReceiptAll.ActiveLinkColor = Color.FromArgb(10, 76, 143);
        lnkRecentReceiptAll.AutoSize = true;
        lnkRecentReceiptAll.Dock = DockStyle.Right;
        lnkRecentReceiptAll.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lnkRecentReceiptAll.LinkBehavior = LinkBehavior.NeverUnderline;
        lnkRecentReceiptAll.LinkColor = Color.FromArgb(10, 76, 143);
        lnkRecentReceiptAll.Location = new Point(638, 18);
        lnkRecentReceiptAll.Name = "lnkRecentReceiptAll";
        lnkRecentReceiptAll.Size = new Size(85, 23);
        lnkRecentReceiptAll.TabIndex = 1;
        lnkRecentReceiptAll.TabStop = true;
        lnkRecentReceiptAll.Text = "XEM TẤT CẢ";
        // 
        // lblRecentReceiptTitle
        // 
        lblRecentReceiptTitle.AutoSize = true;
        lblRecentReceiptTitle.Dock = DockStyle.Left;
        lblRecentReceiptTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
        lblRecentReceiptTitle.Location = new Point(28, 18);
        lblRecentReceiptTitle.Name = "lblRecentReceiptTitle";
        lblRecentReceiptTitle.Size = new Size(209, 37);
        lblRecentReceiptTitle.TabIndex = 0;
        lblRecentReceiptTitle.Text = "PHIẾU THU GẦN ĐÂY";
        // 
        // pnlStaffActionCard
        // 
        pnlStaffActionCard.Controls.Add(flpStaffTaskList);
        pnlStaffActionCard.Controls.Add(pnlStaffActionFooter);
        pnlStaffActionCard.Controls.Add(pnlStaffActionHeader);
        pnlStaffActionCard.Dock = DockStyle.Fill;
        pnlStaffActionCard.Location = new Point(771, 0);
        pnlStaffActionCard.Margin = new Padding(0);
        pnlStaffActionCard.Name = "pnlStaffActionCard";
        pnlStaffActionCard.Padding = new Padding(0);
        pnlStaffActionCard.Size = new Size(453, 532);
        pnlStaffActionCard.AutoScroll = true;
        pnlStaffActionCard.TabIndex = 1;
        // 
        // btnAddTaskStaff
        // 
        btnAddTaskStaff.Dock = DockStyle.Fill;
        btnAddTaskStaff.Location = new Point(24, 16);
        btnAddTaskStaff.Name = "btnAddTaskStaff";
        btnAddTaskStaff.Size = new Size(405, 44);
        btnAddTaskStaff.TabIndex = 0;
        btnAddTaskStaff.Text = "THÊM NHIỆM VỤ MỚI";
        btnAddTaskStaff.UseVisualStyleBackColor = true;
        // 
        // flpStaffTaskList
        // 
        flpStaffTaskList.AutoScroll = true;
        flpStaffTaskList.Dock = DockStyle.Fill;
        flpStaffTaskList.FlowDirection = FlowDirection.TopDown;
        flpStaffTaskList.Location = new Point(0, 64);
        flpStaffTaskList.Name = "flpStaffTaskList";
        flpStaffTaskList.Padding = new Padding(24, 18, 24, 24);
        flpStaffTaskList.Size = new Size(453, 390);
        flpStaffTaskList.TabIndex = 1;
        flpStaffTaskList.WrapContents = false;
        // 
        // pnlStaffActionFooter
        // 
        pnlStaffActionFooter.Controls.Add(btnAddTaskStaff);
        pnlStaffActionFooter.Dock = DockStyle.Bottom;
        pnlStaffActionFooter.Location = new Point(0, 454);
        pnlStaffActionFooter.Name = "pnlStaffActionFooter";
        pnlStaffActionFooter.Padding = new Padding(24, 16, 24, 18);
        pnlStaffActionFooter.Size = new Size(453, 78);
        pnlStaffActionFooter.AutoScroll = true;
        pnlStaffActionFooter.TabIndex = 2;
        // 
        // pnlStaffActionHeader
        // 
        pnlStaffActionHeader.Controls.Add(lblStaffActionTitle);
        pnlStaffActionHeader.Dock = DockStyle.Top;
        pnlStaffActionHeader.Location = new Point(0, 0);
        pnlStaffActionHeader.Name = "pnlStaffActionHeader";
        pnlStaffActionHeader.Padding = new Padding(28, 18, 28, 16);
        pnlStaffActionHeader.Size = new Size(453, 64);
        pnlStaffActionHeader.AutoScroll = true;
        pnlStaffActionHeader.TabIndex = 0;
        // 
        // lblStaffActionTitle
        // 
        lblStaffActionTitle.AutoSize = true;
        lblStaffActionTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
        lblStaffActionTitle.Location = new Point(28, 18);
        lblStaffActionTitle.Name = "lblStaffActionTitle";
        lblStaffActionTitle.Size = new Size(271, 37);
        lblStaffActionTitle.TabIndex = 0;
        lblStaffActionTitle.Text = "DANH SÁCH NHIỆM VỤ";
        // 
        // pnlWeeklyProgressCard
        // 
        pnlWeeklyProgressCard.Controls.Add(lblWeeklyProgressSummary);
        pnlWeeklyProgressCard.Controls.Add(flpWeeklyProgressGrid);
        pnlWeeklyProgressCard.Controls.Add(pnlWeeklyProgressHeader);
        pnlWeeklyProgressCard.Dock = DockStyle.Fill;
        pnlWeeklyProgressCard.Location = new Point(0, 702);
        pnlWeeklyProgressCard.Margin = new Padding(0);
        pnlWeeklyProgressCard.Name = "pnlWeeklyProgressCard";
        pnlWeeklyProgressCard.Padding = new Padding(28, 24, 28, 24);
        pnlWeeklyProgressCard.Size = new Size(1224, 478);
        pnlWeeklyProgressCard.AutoScroll = true;
        pnlWeeklyProgressCard.TabIndex = 2;
        // 
        // lblWeeklyProgressSummary
        // 
        lblWeeklyProgressSummary.AutoSize = true;
        lblWeeklyProgressSummary.Dock = DockStyle.Bottom;
        lblWeeklyProgressSummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblWeeklyProgressSummary.Location = new Point(28, 431);
        lblWeeklyProgressSummary.Name = "lblWeeklyProgressSummary";
        lblWeeklyProgressSummary.Padding = new Padding(8, 18, 0, 0);
        lblWeeklyProgressSummary.Size = new Size(430, 23);
        lblWeeklyProgressSummary.TabIndex = 2;
        lblWeeklyProgressSummary.Text = "HIỆU SUẤT VẬN HÀNH: 38/56 CÔNG VIỆC HOÀN THÀNH (68%)";
        // 
        // flpWeeklyProgressGrid
        // 
        flpWeeklyProgressGrid.Dock = DockStyle.Fill;
        flpWeeklyProgressGrid.Location = new Point(28, 86);
        flpWeeklyProgressGrid.Name = "flpWeeklyProgressGrid";
        flpWeeklyProgressGrid.Padding = new Padding(8, 16, 8, 12);
        flpWeeklyProgressGrid.Size = new Size(1168, 368);
        flpWeeklyProgressGrid.AutoScroll = true;
        flpWeeklyProgressGrid.TabIndex = 1;
        // 
        // pnlWeeklyProgressHeader
        // 
        pnlWeeklyProgressHeader.Controls.Add(flpWeeklyLegend);
        pnlWeeklyProgressHeader.Controls.Add(lblWeeklyProgressTitle);
        pnlWeeklyProgressHeader.Dock = DockStyle.Top;
        pnlWeeklyProgressHeader.Location = new Point(28, 24);
        pnlWeeklyProgressHeader.Name = "pnlWeeklyProgressHeader";
        pnlWeeklyProgressHeader.Size = new Size(1168, 62);
        pnlWeeklyProgressHeader.AutoScroll = true;
        pnlWeeklyProgressHeader.TabIndex = 0;
        // 
        // flpWeeklyLegend
        // 
        flpWeeklyLegend.Controls.Add(pnlLegendDone);
        flpWeeklyLegend.Controls.Add(lblLegendDone);
        flpWeeklyLegend.Controls.Add(pnlLegendRemaining);
        flpWeeklyLegend.Controls.Add(lblLegendRemaining);
        flpWeeklyLegend.Dock = DockStyle.Right;
        flpWeeklyLegend.Location = new Point(902, 0);
        flpWeeklyLegend.Name = "flpWeeklyLegend";
        flpWeeklyLegend.Padding = new Padding(0, 18, 0, 0);
        flpWeeklyLegend.Size = new Size(266, 62);
        flpWeeklyLegend.AutoScroll = true;
        flpWeeklyLegend.TabIndex = 1;
        flpWeeklyLegend.WrapContents = false;
        // 
        // pnlLegendDone
        // 
        pnlLegendDone.Location = new Point(0, 18);
        pnlLegendDone.Margin = new Padding(0, 18, 8, 0);
        pnlLegendDone.Name = "pnlLegendDone";
        pnlLegendDone.Size = new Size(14, 14);
        pnlLegendDone.AutoScroll = true;
        pnlLegendDone.TabIndex = 0;
        // 
        // lblLegendDone
        // 
        lblLegendDone.AutoSize = true;
        lblLegendDone.Location = new Point(22, 18);
        lblLegendDone.Margin = new Padding(0, 14, 18, 0);
        lblLegendDone.Name = "lblLegendDone";
        lblLegendDone.Size = new Size(65, 20);
        lblLegendDone.TabIndex = 1;
        lblLegendDone.Text = "ĐÃ XONG";
        // 
        // pnlLegendRemaining
        // 
        pnlLegendRemaining.Location = new Point(105, 18);
        pnlLegendRemaining.Margin = new Padding(0, 18, 8, 0);
        pnlLegendRemaining.Name = "pnlLegendRemaining";
        pnlLegendRemaining.Size = new Size(14, 14);
        pnlLegendRemaining.AutoScroll = true;
        pnlLegendRemaining.TabIndex = 2;
        // 
        // lblLegendRemaining
        // 
        lblLegendRemaining.AutoSize = true;
        lblLegendRemaining.Location = new Point(127, 18);
        lblLegendRemaining.Margin = new Padding(0, 14, 0, 0);
        lblLegendRemaining.Name = "lblLegendRemaining";
        lblLegendRemaining.Size = new Size(69, 20);
        lblLegendRemaining.TabIndex = 3;
        lblLegendRemaining.Text = "CÒN LẠI";
        // 
        // lblWeeklyProgressTitle
        // 
        lblWeeklyProgressTitle.AutoSize = true;
        lblWeeklyProgressTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
        lblWeeklyProgressTitle.Location = new Point(0, 10);
        lblWeeklyProgressTitle.Name = "lblWeeklyProgressTitle";
        lblWeeklyProgressTitle.Size = new Size(308, 37);
        lblWeeklyProgressTitle.TabIndex = 0;
        lblWeeklyProgressTitle.Text = "TIẾN ĐỘ VẬN HÀNH TUẦN";
        // 
        // FrmStaffDashboard
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(1600, 900);
        Font = new Font("Segoe UI", 10F);
        Controls.Add(pnlContentHostStaff);
        Controls.Add(pnlTopbarStaff);
        Controls.Add(pnlSidebarStaff);
        MinimumSize = new Size(1180, 760);
        Name = "FrmStaffDashboard";
        pnlSidebarStaff.ResumeLayout(false);
        flpSidebarMenuStaff.ResumeLayout(false);
        pnlSidebarFooterStaff.ResumeLayout(false);
        pnlSidebarBrandStaff.ResumeLayout(false);
        pnlSidebarBrandStaff.PerformLayout();
        pnlTopbarStaff.ResumeLayout(false);
        tblTopbarStaff.ResumeLayout(false);
        flpTopbarActionsStaff.ResumeLayout(false);
        pnlTopbarProfileStaff.ResumeLayout(false);
        pnlTopbarProfileStaff.PerformLayout();
        pnlTopbarAvatarStaff.ResumeLayout(false);
        pnlContentHostStaff.ResumeLayout(false);
        pnlDashboardHome.ResumeLayout(false);
        tblStaffDashboardRoot.ResumeLayout(false);
        tblStaffKpi.ResumeLayout(false);
        pnlNewStudentsToday.ResumeLayout(false);
        pnlNewStudentsToday.PerformLayout();
        pnlAvailableClasses.ResumeLayout(false);
        pnlAvailableClasses.PerformLayout();
        pnlTodayReceipts.ResumeLayout(false);
        pnlTodayReceipts.PerformLayout();
        pnlDebtStudents.ResumeLayout(false);
        pnlDebtStudents.PerformLayout();
        tblStaffMain.ResumeLayout(false);
        pnlRecentReceiptCard.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvRecentReceipts).EndInit();
        pnlRecentReceiptHeader.ResumeLayout(false);
        pnlRecentReceiptHeader.PerformLayout();
        pnlStaffActionCard.ResumeLayout(false);
        pnlStaffActionFooter.ResumeLayout(false);
        pnlStaffActionHeader.ResumeLayout(false);
        pnlStaffActionHeader.PerformLayout();
        pnlWeeklyProgressCard.ResumeLayout(false);
        pnlWeeklyProgressCard.PerformLayout();
        pnlWeeklyProgressHeader.ResumeLayout(false);
        pnlWeeklyProgressHeader.PerformLayout();
        flpWeeklyLegend.ResumeLayout(false);
        flpWeeklyLegend.PerformLayout();
        AutoScroll = true;
        ResumeLayout(false);
    }
}

