namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmStaffDashboard
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlSidebarStaff;
    private Panel pnlTopbarStaff;
    private Panel pnlContentHostStaff;
    private Panel pnlDashboardHome;
    private Label lblCurrentRoleStaff;
    private Label lblCurrentUserStaff;
    private Button btnLogoutStaff;
    private Button btnMenuStaffDashboard;
    private Button btnMenuStudentManagement;
    private Button btnMenuTeacherManagement;
    private Button btnMenuCourseManagement;
    private Button btnMenuClassManagement;
    private Button btnMenuEnrollment;
    private Button btnMenuTuitionReceipt;
    private Button btnMenuDebtTracking;
    private Label lblStaffDashboardTitle;
    private Panel pnlNewStudentsToday;
    private Panel pnlAvailableClasses;
    private Panel pnlTodayReceipts;
    private Panel pnlDebtStudents;
    private Label lblNewStudentsTodayValue;
    private Label lblAvailableClassesValue;
    private Label lblTodayReceiptsValue;
    private Label lblDebtStudentsValue;
    private DataGridView dgvRecentReceipts;
    private FlowLayoutPanel flpSidebarMenuStaff;
    private Panel pnlSidebarBrandStaff;
    private Label lblSidebarBrandStaffTitle;
    private Label lblSidebarBrandStaffSubtitle;
    private TableLayoutPanel tblStaffDashboardRoot;
    private Panel pnlStaffHeroCard;
    private Label lblStaffDashboardSubtitle;
    private TableLayoutPanel tblStaffKpi;
    private SplitContainer splStaffDashboard;
    private Panel pnlRecentReceiptCard;
    private Label lblRecentReceiptTitle;
    private Label lblRecentReceiptHint;
    private Panel pnlStaffActionCard;
    private Label lblStaffActionTitle;
    private Label lblStaffActionHint;
    private ListBox lstStaffActionQueue;

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
        pnlSidebarBrandStaff = new Panel();
        lblSidebarBrandStaffSubtitle = new Label();
        lblSidebarBrandStaffTitle = new Label();
        pnlTopbarStaff = new Panel();
        btnLogoutStaff = new Button();
        lblCurrentUserStaff = new Label();
        lblCurrentRoleStaff = new Label();
        pnlContentHostStaff = new Panel();
        pnlDashboardHome = new Panel();
        tblStaffDashboardRoot = new TableLayoutPanel();
        pnlStaffHeroCard = new Panel();
        lblStaffDashboardSubtitle = new Label();
        lblStaffDashboardTitle = new Label();
        tblStaffKpi = new TableLayoutPanel();
        pnlNewStudentsToday = new Panel();
        lblNewStudentsTodayValue = new Label();
        pnlAvailableClasses = new Panel();
        lblAvailableClassesValue = new Label();
        pnlTodayReceipts = new Panel();
        lblTodayReceiptsValue = new Label();
        pnlDebtStudents = new Panel();
        lblDebtStudentsValue = new Label();
        splStaffDashboard = new SplitContainer();
        pnlRecentReceiptCard = new Panel();
        dgvRecentReceipts = new DataGridView();
        lblRecentReceiptHint = new Label();
        lblRecentReceiptTitle = new Label();
        pnlStaffActionCard = new Panel();
        lstStaffActionQueue = new ListBox();
        lblStaffActionHint = new Label();
        lblStaffActionTitle = new Label();
        pnlSidebarStaff.SuspendLayout();
        flpSidebarMenuStaff.SuspendLayout();
        pnlSidebarBrandStaff.SuspendLayout();
        pnlTopbarStaff.SuspendLayout();
        pnlContentHostStaff.SuspendLayout();
        pnlDashboardHome.SuspendLayout();
        tblStaffDashboardRoot.SuspendLayout();
        pnlStaffHeroCard.SuspendLayout();
        tblStaffKpi.SuspendLayout();
        pnlNewStudentsToday.SuspendLayout();
        pnlAvailableClasses.SuspendLayout();
        pnlTodayReceipts.SuspendLayout();
        pnlDebtStudents.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splStaffDashboard).BeginInit();
        splStaffDashboard.Panel1.SuspendLayout();
        splStaffDashboard.Panel2.SuspendLayout();
        splStaffDashboard.SuspendLayout();
        pnlRecentReceiptCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvRecentReceipts).BeginInit();
        pnlStaffActionCard.SuspendLayout();
        SuspendLayout();
        // 
        // pnlSidebarStaff
        // 
        pnlSidebarStaff.BackColor = Color.FromArgb(230, 246, 255);
        pnlSidebarStaff.Controls.Add(flpSidebarMenuStaff);
        pnlSidebarStaff.Controls.Add(pnlSidebarBrandStaff);
        pnlSidebarStaff.Dock = DockStyle.Left;
        pnlSidebarStaff.Location = new Point(0, 0);
        pnlSidebarStaff.Name = "pnlSidebarStaff";
        pnlSidebarStaff.Padding = new Padding(18);
        pnlSidebarStaff.Size = new Size(256, 761);
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
        flpSidebarMenuStaff.Dock = DockStyle.Top;
        flpSidebarMenuStaff.FlowDirection = FlowDirection.TopDown;
        flpSidebarMenuStaff.Location = new Point(18, 106);
        flpSidebarMenuStaff.Name = "flpSidebarMenuStaff";
        flpSidebarMenuStaff.Size = new Size(220, 430);
        flpSidebarMenuStaff.TabIndex = 1;
        flpSidebarMenuStaff.WrapContents = false;
        // 
        // btnMenuStaffDashboard
        // 
        btnMenuStaffDashboard.Location = new Point(3, 3);
        btnMenuStaffDashboard.Name = "btnMenuStaffDashboard";
        btnMenuStaffDashboard.Size = new Size(214, 46);
        btnMenuStaffDashboard.TabIndex = 0;
        btnMenuStaffDashboard.Text = "Dashboard vận hành";
        btnMenuStaffDashboard.UseVisualStyleBackColor = true;
        // 
        // btnMenuStudentManagement
        // 
        btnMenuStudentManagement.Location = new Point(3, 55);
        btnMenuStudentManagement.Name = "btnMenuStudentManagement";
        btnMenuStudentManagement.Size = new Size(214, 46);
        btnMenuStudentManagement.TabIndex = 1;
        btnMenuStudentManagement.Text = "Quản lý học viên";
        btnMenuStudentManagement.UseVisualStyleBackColor = true;
        // 
        // btnMenuTeacherManagement
        // 
        btnMenuTeacherManagement.Location = new Point(3, 107);
        btnMenuTeacherManagement.Name = "btnMenuTeacherManagement";
        btnMenuTeacherManagement.Size = new Size(214, 46);
        btnMenuTeacherManagement.TabIndex = 2;
        btnMenuTeacherManagement.Text = "Quản lý giáo viên";
        btnMenuTeacherManagement.UseVisualStyleBackColor = true;
        // 
        // btnMenuCourseManagement
        // 
        btnMenuCourseManagement.Location = new Point(3, 159);
        btnMenuCourseManagement.Name = "btnMenuCourseManagement";
        btnMenuCourseManagement.Size = new Size(214, 46);
        btnMenuCourseManagement.TabIndex = 3;
        btnMenuCourseManagement.Text = "Quản lý khóa học";
        btnMenuCourseManagement.UseVisualStyleBackColor = true;
        // 
        // btnMenuClassManagement
        // 
        btnMenuClassManagement.Location = new Point(3, 211);
        btnMenuClassManagement.Name = "btnMenuClassManagement";
        btnMenuClassManagement.Size = new Size(214, 46);
        btnMenuClassManagement.TabIndex = 4;
        btnMenuClassManagement.Text = "Quản lý lớp học";
        btnMenuClassManagement.UseVisualStyleBackColor = true;
        // 
        // btnMenuEnrollment
        // 
        btnMenuEnrollment.Location = new Point(3, 263);
        btnMenuEnrollment.Name = "btnMenuEnrollment";
        btnMenuEnrollment.Size = new Size(214, 46);
        btnMenuEnrollment.TabIndex = 5;
        btnMenuEnrollment.Text = "Ghi danh / xếp lớp";
        btnMenuEnrollment.UseVisualStyleBackColor = true;
        // 
        // btnMenuTuitionReceipt
        // 
        btnMenuTuitionReceipt.Location = new Point(3, 315);
        btnMenuTuitionReceipt.Name = "btnMenuTuitionReceipt";
        btnMenuTuitionReceipt.Size = new Size(214, 46);
        btnMenuTuitionReceipt.TabIndex = 6;
        btnMenuTuitionReceipt.Text = "Thu học phí";
        btnMenuTuitionReceipt.UseVisualStyleBackColor = true;
        // 
        // btnMenuDebtTracking
        // 
        btnMenuDebtTracking.Location = new Point(3, 367);
        btnMenuDebtTracking.Name = "btnMenuDebtTracking";
        btnMenuDebtTracking.Size = new Size(214, 46);
        btnMenuDebtTracking.TabIndex = 7;
        btnMenuDebtTracking.Text = "Công nợ học viên";
        btnMenuDebtTracking.UseVisualStyleBackColor = true;
        // 
        // pnlSidebarBrandStaff
        // 
        pnlSidebarBrandStaff.Controls.Add(lblSidebarBrandStaffSubtitle);
        pnlSidebarBrandStaff.Controls.Add(lblSidebarBrandStaffTitle);
        pnlSidebarBrandStaff.Dock = DockStyle.Top;
        pnlSidebarBrandStaff.Location = new Point(18, 18);
        pnlSidebarBrandStaff.Name = "pnlSidebarBrandStaff";
        pnlSidebarBrandStaff.Size = new Size(220, 88);
        pnlSidebarBrandStaff.TabIndex = 0;
        // 
        // lblSidebarBrandStaffSubtitle
        // 
        lblSidebarBrandStaffSubtitle.AutoSize = true;
        lblSidebarBrandStaffSubtitle.ForeColor = Color.FromArgb(0, 110, 110);
        lblSidebarBrandStaffSubtitle.Location = new Point(0, 34);
        lblSidebarBrandStaffSubtitle.Name = "lblSidebarBrandStaffSubtitle";
        lblSidebarBrandStaffSubtitle.Size = new Size(145, 20);
        lblSidebarBrandStaffSubtitle.TabIndex = 1;
        lblSidebarBrandStaffSubtitle.Text = "Nhóm nghiệp vụ trung tâm";
        // 
        // lblSidebarBrandStaffTitle
        // 
        lblSidebarBrandStaffTitle.AutoSize = true;
        lblSidebarBrandStaffTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblSidebarBrandStaffTitle.ForeColor = Color.FromArgb(0, 66, 118);
        lblSidebarBrandStaffTitle.Location = new Point(0, 0);
        lblSidebarBrandStaffTitle.Name = "lblSidebarBrandStaffTitle";
        lblSidebarBrandStaffTitle.Size = new Size(79, 32);
        lblSidebarBrandStaffTitle.TabIndex = 0;
        lblSidebarBrandStaffTitle.Text = "STAFF";
        // 
        // pnlTopbarStaff
        // 
        pnlTopbarStaff.BackColor = Color.White;
        pnlTopbarStaff.Controls.Add(btnLogoutStaff);
        pnlTopbarStaff.Controls.Add(lblCurrentUserStaff);
        pnlTopbarStaff.Controls.Add(lblCurrentRoleStaff);
        pnlTopbarStaff.Dock = DockStyle.Top;
        pnlTopbarStaff.Location = new Point(256, 0);
        pnlTopbarStaff.Name = "pnlTopbarStaff";
        pnlTopbarStaff.Padding = new Padding(24, 18, 24, 18);
        pnlTopbarStaff.Size = new Size(1116, 74);
        pnlTopbarStaff.TabIndex = 1;
        // 
        // btnLogoutStaff
        // 
        btnLogoutStaff.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLogoutStaff.Location = new Point(972, 18);
        btnLogoutStaff.Name = "btnLogoutStaff";
        btnLogoutStaff.Size = new Size(120, 36);
        btnLogoutStaff.TabIndex = 2;
        btnLogoutStaff.Text = "Đăng xuất";
        btnLogoutStaff.UseVisualStyleBackColor = true;
        // 
        // lblCurrentUserStaff
        // 
        lblCurrentUserStaff.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblCurrentUserStaff.AutoSize = true;
        lblCurrentUserStaff.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCurrentUserStaff.Location = new Point(822, 16);
        lblCurrentUserStaff.Name = "lblCurrentUserStaff";
        lblCurrentUserStaff.Size = new Size(81, 23);
        lblCurrentUserStaff.TabIndex = 1;
        lblCurrentUserStaff.Text = "staff.user";
        // 
        // lblCurrentRoleStaff
        // 
        lblCurrentRoleStaff.AutoSize = true;
        lblCurrentRoleStaff.ForeColor = Color.FromArgb(102, 112, 133);
        lblCurrentRoleStaff.Location = new Point(24, 24);
        lblCurrentRoleStaff.Name = "lblCurrentRoleStaff";
        lblCurrentRoleStaff.Size = new Size(167, 20);
        lblCurrentRoleStaff.TabIndex = 0;
        lblCurrentRoleStaff.Text = "Vai trò: Staff vận hành";
        // 
        // pnlContentHostStaff
        // 
        pnlContentHostStaff.Controls.Add(pnlDashboardHome);
        pnlContentHostStaff.Dock = DockStyle.Fill;
        pnlContentHostStaff.Location = new Point(256, 74);
        pnlContentHostStaff.Name = "pnlContentHostStaff";
        pnlContentHostStaff.Padding = new Padding(20, 0, 20, 20);
        pnlContentHostStaff.Size = new Size(1116, 687);
        pnlContentHostStaff.TabIndex = 2;
        // 
        // pnlDashboardHome
        // 
        pnlDashboardHome.Controls.Add(tblStaffDashboardRoot);
        pnlDashboardHome.Dock = DockStyle.Fill;
        pnlDashboardHome.Location = new Point(20, 0);
        pnlDashboardHome.Name = "pnlDashboardHome";
        pnlDashboardHome.Size = new Size(1076, 667);
        pnlDashboardHome.TabIndex = 0;
        // 
        // tblStaffDashboardRoot
        // 
        tblStaffDashboardRoot.ColumnCount = 1;
        tblStaffDashboardRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblStaffDashboardRoot.Controls.Add(pnlStaffHeroCard, 0, 0);
        tblStaffDashboardRoot.Controls.Add(tblStaffKpi, 0, 1);
        tblStaffDashboardRoot.Controls.Add(splStaffDashboard, 0, 2);
        tblStaffDashboardRoot.Dock = DockStyle.Fill;
        tblStaffDashboardRoot.Location = new Point(0, 0);
        tblStaffDashboardRoot.Name = "tblStaffDashboardRoot";
        tblStaffDashboardRoot.RowCount = 3;
        tblStaffDashboardRoot.RowStyles.Add(new RowStyle());
        tblStaffDashboardRoot.RowStyles.Add(new RowStyle());
        tblStaffDashboardRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblStaffDashboardRoot.Size = new Size(1076, 667);
        tblStaffDashboardRoot.TabIndex = 0;
        // 
        // pnlStaffHeroCard
        // 
        pnlStaffHeroCard.BackColor = Color.White;
        pnlStaffHeroCard.Controls.Add(lblStaffDashboardSubtitle);
        pnlStaffHeroCard.Controls.Add(lblStaffDashboardTitle);
        pnlStaffHeroCard.Dock = DockStyle.Fill;
        pnlStaffHeroCard.Location = new Point(0, 0);
        pnlStaffHeroCard.Margin = new Padding(0, 0, 0, 16);
        pnlStaffHeroCard.Name = "pnlStaffHeroCard";
        pnlStaffHeroCard.Padding = new Padding(24, 20, 24, 20);
        pnlStaffHeroCard.Size = new Size(1076, 104);
        pnlStaffHeroCard.TabIndex = 0;
        // 
        // lblStaffDashboardSubtitle
        // 
        lblStaffDashboardSubtitle.AutoSize = true;
        lblStaffDashboardSubtitle.ForeColor = Color.FromArgb(102, 112, 133);
        lblStaffDashboardSubtitle.Location = new Point(24, 58);
        lblStaffDashboardSubtitle.Name = "lblStaffDashboardSubtitle";
        lblStaffDashboardSubtitle.Size = new Size(484, 20);
        lblStaffDashboardSubtitle.TabIndex = 1;
        lblStaffDashboardSubtitle.Text = "Tập trung vào hồ sơ học viên, lớp học, ghi danh, học phí và công nợ hằng ngày.";
        // 
        // lblStaffDashboardTitle
        // 
        lblStaffDashboardTitle.AutoSize = true;
        lblStaffDashboardTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblStaffDashboardTitle.ForeColor = Color.FromArgb(7, 30, 39);
        lblStaffDashboardTitle.Location = new Point(20, 10);
        lblStaffDashboardTitle.Name = "lblStaffDashboardTitle";
        lblStaffDashboardTitle.Size = new Size(344, 46);
        lblStaffDashboardTitle.TabIndex = 0;
        lblStaffDashboardTitle.Text = "Dashboard vận hành";
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
        tblStaffKpi.Location = new Point(0, 120);
        tblStaffKpi.Margin = new Padding(0, 0, 0, 16);
        tblStaffKpi.Name = "tblStaffKpi";
        tblStaffKpi.RowCount = 1;
        tblStaffKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblStaffKpi.Size = new Size(1076, 118);
        tblStaffKpi.TabIndex = 1;
        // 
        // pnlNewStudentsToday
        // 
        pnlNewStudentsToday.BackColor = Color.White;
        pnlNewStudentsToday.Controls.Add(lblNewStudentsTodayValue);
        pnlNewStudentsToday.Dock = DockStyle.Fill;
        pnlNewStudentsToday.Location = new Point(0, 0);
        pnlNewStudentsToday.Margin = new Padding(0, 0, 12, 0);
        pnlNewStudentsToday.Name = "pnlNewStudentsToday";
        pnlNewStudentsToday.Padding = new Padding(18);
        pnlNewStudentsToday.Size = new Size(257, 118);
        pnlNewStudentsToday.TabIndex = 0;
        // 
        // lblNewStudentsTodayValue
        // 
        lblNewStudentsTodayValue.Dock = DockStyle.Fill;
        lblNewStudentsTodayValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblNewStudentsTodayValue.Location = new Point(18, 18);
        lblNewStudentsTodayValue.Name = "lblNewStudentsTodayValue";
        lblNewStudentsTodayValue.Size = new Size(221, 82);
        lblNewStudentsTodayValue.TabIndex = 0;
        lblNewStudentsTodayValue.Text = "12";
        lblNewStudentsTodayValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlAvailableClasses
        // 
        pnlAvailableClasses.BackColor = Color.White;
        pnlAvailableClasses.Controls.Add(lblAvailableClassesValue);
        pnlAvailableClasses.Dock = DockStyle.Fill;
        pnlAvailableClasses.Location = new Point(269, 0);
        pnlAvailableClasses.Margin = new Padding(0, 0, 12, 0);
        pnlAvailableClasses.Name = "pnlAvailableClasses";
        pnlAvailableClasses.Padding = new Padding(18);
        pnlAvailableClasses.Size = new Size(257, 118);
        pnlAvailableClasses.TabIndex = 1;
        // 
        // lblAvailableClassesValue
        // 
        lblAvailableClassesValue.Dock = DockStyle.Fill;
        lblAvailableClassesValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblAvailableClassesValue.Location = new Point(18, 18);
        lblAvailableClassesValue.Name = "lblAvailableClassesValue";
        lblAvailableClassesValue.Size = new Size(221, 82);
        lblAvailableClassesValue.TabIndex = 0;
        lblAvailableClassesValue.Text = "9";
        lblAvailableClassesValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlTodayReceipts
        // 
        pnlTodayReceipts.BackColor = Color.White;
        pnlTodayReceipts.Controls.Add(lblTodayReceiptsValue);
        pnlTodayReceipts.Dock = DockStyle.Fill;
        pnlTodayReceipts.Location = new Point(538, 0);
        pnlTodayReceipts.Margin = new Padding(0, 0, 12, 0);
        pnlTodayReceipts.Name = "pnlTodayReceipts";
        pnlTodayReceipts.Padding = new Padding(18);
        pnlTodayReceipts.Size = new Size(257, 118);
        pnlTodayReceipts.TabIndex = 2;
        // 
        // lblTodayReceiptsValue
        // 
        lblTodayReceiptsValue.Dock = DockStyle.Fill;
        lblTodayReceiptsValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTodayReceiptsValue.Location = new Point(18, 18);
        lblTodayReceiptsValue.Name = "lblTodayReceiptsValue";
        lblTodayReceiptsValue.Size = new Size(221, 82);
        lblTodayReceiptsValue.TabIndex = 0;
        lblTodayReceiptsValue.Text = "18";
        lblTodayReceiptsValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlDebtStudents
        // 
        pnlDebtStudents.BackColor = Color.White;
        pnlDebtStudents.Controls.Add(lblDebtStudentsValue);
        pnlDebtStudents.Dock = DockStyle.Fill;
        pnlDebtStudents.Location = new Point(807, 0);
        pnlDebtStudents.Margin = new Padding(0);
        pnlDebtStudents.Name = "pnlDebtStudents";
        pnlDebtStudents.Padding = new Padding(18);
        pnlDebtStudents.Size = new Size(269, 118);
        pnlDebtStudents.TabIndex = 3;
        // 
        // lblDebtStudentsValue
        // 
        lblDebtStudentsValue.Dock = DockStyle.Fill;
        lblDebtStudentsValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblDebtStudentsValue.Location = new Point(18, 18);
        lblDebtStudentsValue.Name = "lblDebtStudentsValue";
        lblDebtStudentsValue.Size = new Size(233, 82);
        lblDebtStudentsValue.TabIndex = 0;
        lblDebtStudentsValue.Text = "27";
        lblDebtStudentsValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // splStaffDashboard
        // 
        splStaffDashboard.Dock = DockStyle.Fill;
        splStaffDashboard.Location = new Point(0, 254);
        splStaffDashboard.Margin = new Padding(0);
        splStaffDashboard.Name = "splStaffDashboard";
        // 
        // splStaffDashboard.Panel1
        // 
        splStaffDashboard.Panel1.Controls.Add(pnlRecentReceiptCard);
        splStaffDashboard.Panel1.Padding = new Padding(0, 0, 10, 0);
        // 
        // splStaffDashboard.Panel2
        // 
        splStaffDashboard.Panel2.Controls.Add(pnlStaffActionCard);
        splStaffDashboard.Panel2.Padding = new Padding(10, 0, 0, 0);
        splStaffDashboard.Size = new Size(1076, 413);
        splStaffDashboard.SplitterDistance = 724;
        splStaffDashboard.TabIndex = 2;
        // 
        // pnlRecentReceiptCard
        // 
        pnlRecentReceiptCard.BackColor = Color.White;
        pnlRecentReceiptCard.Controls.Add(dgvRecentReceipts);
        pnlRecentReceiptCard.Controls.Add(lblRecentReceiptHint);
        pnlRecentReceiptCard.Controls.Add(lblRecentReceiptTitle);
        pnlRecentReceiptCard.Dock = DockStyle.Fill;
        pnlRecentReceiptCard.Location = new Point(0, 0);
        pnlRecentReceiptCard.Name = "pnlRecentReceiptCard";
        pnlRecentReceiptCard.Padding = new Padding(18);
        pnlRecentReceiptCard.Size = new Size(714, 413);
        pnlRecentReceiptCard.TabIndex = 0;
        // 
        // dgvRecentReceipts
        // 
        dgvRecentReceipts.Dock = DockStyle.Fill;
        dgvRecentReceipts.Location = new Point(18, 69);
        dgvRecentReceipts.Name = "dgvRecentReceipts";
        dgvRecentReceipts.RowHeadersWidth = 51;
        dgvRecentReceipts.Size = new Size(678, 326);
        dgvRecentReceipts.TabIndex = 2;
        // 
        // lblRecentReceiptHint
        // 
        lblRecentReceiptHint.Dock = DockStyle.Top;
        lblRecentReceiptHint.ForeColor = Color.FromArgb(102, 112, 133);
        lblRecentReceiptHint.Location = new Point(18, 41);
        lblRecentReceiptHint.Name = "lblRecentReceiptHint";
        lblRecentReceiptHint.Size = new Size(678, 28);
        lblRecentReceiptHint.TabIndex = 1;
        lblRecentReceiptHint.Text = "Biên nhận gần đây để Staff kiểm tra và tiếp tục xử lý học phí nếu cần.";
        // 
        // lblRecentReceiptTitle
        // 
        lblRecentReceiptTitle.Dock = DockStyle.Top;
        lblRecentReceiptTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblRecentReceiptTitle.Location = new Point(18, 18);
        lblRecentReceiptTitle.Name = "lblRecentReceiptTitle";
        lblRecentReceiptTitle.Size = new Size(678, 23);
        lblRecentReceiptTitle.TabIndex = 0;
        lblRecentReceiptTitle.Text = "Biên nhận gần đây";
        // 
        // pnlStaffActionCard
        // 
        pnlStaffActionCard.BackColor = Color.White;
        pnlStaffActionCard.Controls.Add(lstStaffActionQueue);
        pnlStaffActionCard.Controls.Add(lblStaffActionHint);
        pnlStaffActionCard.Controls.Add(lblStaffActionTitle);
        pnlStaffActionCard.Dock = DockStyle.Fill;
        pnlStaffActionCard.Location = new Point(10, 0);
        pnlStaffActionCard.Name = "pnlStaffActionCard";
        pnlStaffActionCard.Padding = new Padding(18);
        pnlStaffActionCard.Size = new Size(328, 413);
        pnlStaffActionCard.TabIndex = 0;
        // 
        // lstStaffActionQueue
        // 
        lstStaffActionQueue.BorderStyle = BorderStyle.None;
        lstStaffActionQueue.Dock = DockStyle.Fill;
        lstStaffActionQueue.FormattingEnabled = true;
        lstStaffActionQueue.ItemHeight = 20;
        lstStaffActionQueue.Items.AddRange(new object[] { "3 hồ sơ học viên mới cần hoàn thiện.", "2 lớp sắp đầy cần kiểm tra sĩ số.", "5 khoản công nợ quá hạn trên 7 ngày.", "4 ghi danh mới chờ chuyển sang thu học phí." });
        lstStaffActionQueue.Location = new Point(18, 69);
        lstStaffActionQueue.Name = "lstStaffActionQueue";
        lstStaffActionQueue.Size = new Size(292, 326);
        lstStaffActionQueue.TabIndex = 2;
        // 
        // lblStaffActionHint
        // 
        lblStaffActionHint.Dock = DockStyle.Top;
        lblStaffActionHint.ForeColor = Color.FromArgb(102, 112, 133);
        lblStaffActionHint.Location = new Point(18, 41);
        lblStaffActionHint.Name = "lblStaffActionHint";
        lblStaffActionHint.Size = new Size(292, 28);
        lblStaffActionHint.TabIndex = 1;
        lblStaffActionHint.Text = "Danh sách việc cần làm ưu tiên trong ngày.";
        // 
        // lblStaffActionTitle
        // 
        lblStaffActionTitle.Dock = DockStyle.Top;
        lblStaffActionTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblStaffActionTitle.Location = new Point(18, 18);
        lblStaffActionTitle.Name = "lblStaffActionTitle";
        lblStaffActionTitle.Size = new Size(292, 23);
        lblStaffActionTitle.TabIndex = 0;
        lblStaffActionTitle.Text = "Tác vụ cần xử lý";
        // 
        // FrmStaffDashboard
        // 
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(1372, 761);
        Controls.Add(pnlContentHostStaff);
        Controls.Add(pnlTopbarStaff);
        Controls.Add(pnlSidebarStaff);
        Name = "FrmStaffDashboard";
        pnlSidebarStaff.ResumeLayout(false);
        flpSidebarMenuStaff.ResumeLayout(false);
        pnlSidebarBrandStaff.ResumeLayout(false);
        pnlSidebarBrandStaff.PerformLayout();
        pnlTopbarStaff.ResumeLayout(false);
        pnlTopbarStaff.PerformLayout();
        pnlContentHostStaff.ResumeLayout(false);
        pnlDashboardHome.ResumeLayout(false);
        tblStaffDashboardRoot.ResumeLayout(false);
        pnlStaffHeroCard.ResumeLayout(false);
        pnlStaffHeroCard.PerformLayout();
        tblStaffKpi.ResumeLayout(false);
        pnlNewStudentsToday.ResumeLayout(false);
        pnlAvailableClasses.ResumeLayout(false);
        pnlTodayReceipts.ResumeLayout(false);
        pnlDebtStudents.ResumeLayout(false);
        splStaffDashboard.Panel1.ResumeLayout(false);
        splStaffDashboard.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splStaffDashboard).EndInit();
        splStaffDashboard.ResumeLayout(false);
        pnlRecentReceiptCard.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvRecentReceipts).EndInit();
        pnlStaffActionCard.ResumeLayout(false);
        ResumeLayout(false);
    }
}
