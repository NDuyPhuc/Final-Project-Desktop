namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmTeacherDashboard
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlSidebarTeacher;
    private Panel pnlTopbarTeacher;
    private Panel pnlContentHostTeacher;
    private Panel pnlDashboardHome;
    private Label lblCurrentRoleTeacher;
    private Label lblCurrentUserTeacher;
    private Button btnLogoutTeacher;
    private Button btnMenuTeacherDashboard;
    private Button btnMenuTeachingClasses;
    private Button btnMenuClassStudentList;
    private Button btnMenuAttendance;
    private Button btnMenuScoreEntry;
    private Label lblTeacherDashboardTitle;
    private Panel pnlTeachingClassesCount;
    private Panel pnlTeachingStudentCount;
    private Panel pnlTeachingTodaySessions;
    private Panel pnlTeachingPendingScores;
    private Label lblTeachingClassesCountValue;
    private Label lblTeachingStudentCountValue;
    private Label lblTeachingTodaySessionsValue;
    private Label lblTeachingPendingScoresValue;
    private DataGridView dgvTeacherClassOverview;
    private FlowLayoutPanel flpSidebarTeacherMenu;
    private Panel pnlSidebarTeacherBrand;
    private Label lblSidebarTeacherSubtitle;
    private Label lblSidebarTeacherTitle;
    private TableLayoutPanel tblTeacherDashboardRoot;
    private Panel pnlTeacherHeroCard;
    private Label lblTeacherDashboardSubtitle;
    private TableLayoutPanel tblTeacherKpi;
    private SplitContainer splTeacherDashboard;
    private Panel pnlTeacherClassCard;
    private Label lblTeacherClassCardTitle;
    private Label lblTeacherClassCardHint;
    private Panel pnlTeacherTaskCard;
    private ListBox lstTeacherTaskQueue;
    private Label lblTeacherTaskHint;
    private Label lblTeacherTaskTitle;

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
        pnlSidebarTeacher = new Panel();
        flpSidebarTeacherMenu = new FlowLayoutPanel();
        btnMenuTeacherDashboard = new Button();
        btnMenuTeachingClasses = new Button();
        btnMenuClassStudentList = new Button();
        btnMenuAttendance = new Button();
        btnMenuScoreEntry = new Button();
        pnlSidebarTeacherBrand = new Panel();
        lblSidebarTeacherSubtitle = new Label();
        lblSidebarTeacherTitle = new Label();
        pnlTopbarTeacher = new Panel();
        btnLogoutTeacher = new Button();
        lblCurrentUserTeacher = new Label();
        lblCurrentRoleTeacher = new Label();
        pnlContentHostTeacher = new Panel();
        pnlDashboardHome = new Panel();
        tblTeacherDashboardRoot = new TableLayoutPanel();
        pnlTeacherHeroCard = new Panel();
        lblTeacherDashboardSubtitle = new Label();
        lblTeacherDashboardTitle = new Label();
        tblTeacherKpi = new TableLayoutPanel();
        pnlTeachingClassesCount = new Panel();
        lblTeachingClassesCountValue = new Label();
        pnlTeachingStudentCount = new Panel();
        lblTeachingStudentCountValue = new Label();
        pnlTeachingTodaySessions = new Panel();
        lblTeachingTodaySessionsValue = new Label();
        pnlTeachingPendingScores = new Panel();
        lblTeachingPendingScoresValue = new Label();
        splTeacherDashboard = new SplitContainer();
        pnlTeacherClassCard = new Panel();
        dgvTeacherClassOverview = new DataGridView();
        lblTeacherClassCardHint = new Label();
        lblTeacherClassCardTitle = new Label();
        pnlTeacherTaskCard = new Panel();
        lstTeacherTaskQueue = new ListBox();
        lblTeacherTaskHint = new Label();
        lblTeacherTaskTitle = new Label();
        pnlSidebarTeacher.SuspendLayout();
        flpSidebarTeacherMenu.SuspendLayout();
        pnlSidebarTeacherBrand.SuspendLayout();
        pnlTopbarTeacher.SuspendLayout();
        pnlContentHostTeacher.SuspendLayout();
        pnlDashboardHome.SuspendLayout();
        tblTeacherDashboardRoot.SuspendLayout();
        pnlTeacherHeroCard.SuspendLayout();
        tblTeacherKpi.SuspendLayout();
        pnlTeachingClassesCount.SuspendLayout();
        pnlTeachingStudentCount.SuspendLayout();
        pnlTeachingTodaySessions.SuspendLayout();
        pnlTeachingPendingScores.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splTeacherDashboard).BeginInit();
        splTeacherDashboard.Panel1.SuspendLayout();
        splTeacherDashboard.Panel2.SuspendLayout();
        splTeacherDashboard.SuspendLayout();
        pnlTeacherClassCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvTeacherClassOverview).BeginInit();
        pnlTeacherTaskCard.SuspendLayout();
        SuspendLayout();
        // 
        // pnlSidebarTeacher
        // 
        pnlSidebarTeacher.BackColor = Color.FromArgb(230, 246, 255);
        pnlSidebarTeacher.Controls.Add(flpSidebarTeacherMenu);
        pnlSidebarTeacher.Controls.Add(pnlSidebarTeacherBrand);
        pnlSidebarTeacher.Dock = DockStyle.Left;
        pnlSidebarTeacher.Location = new Point(0, 0);
        pnlSidebarTeacher.Name = "pnlSidebarTeacher";
        pnlSidebarTeacher.Padding = new Padding(18);
        pnlSidebarTeacher.Size = new Size(256, 761);
        pnlSidebarTeacher.AutoScroll = false;
        pnlSidebarTeacher.TabIndex = 0;
        // 
        // flpSidebarTeacherMenu
        // 
        flpSidebarTeacherMenu.Controls.Add(btnMenuTeacherDashboard);
        flpSidebarTeacherMenu.Controls.Add(btnMenuTeachingClasses);
        flpSidebarTeacherMenu.Controls.Add(btnMenuClassStudentList);
        flpSidebarTeacherMenu.Controls.Add(btnMenuAttendance);
        flpSidebarTeacherMenu.Controls.Add(btnMenuScoreEntry);
        flpSidebarTeacherMenu.Dock = DockStyle.Top;
        flpSidebarTeacherMenu.FlowDirection = FlowDirection.TopDown;
        flpSidebarTeacherMenu.Location = new Point(18, 106);
        flpSidebarTeacherMenu.Name = "flpSidebarTeacherMenu";
        flpSidebarTeacherMenu.Size = new Size(220, 274);
        flpSidebarTeacherMenu.AutoScroll = true;
        flpSidebarTeacherMenu.TabIndex = 1;
        flpSidebarTeacherMenu.WrapContents = false;
        // 
        // btnMenuTeacherDashboard
        // 
        btnMenuTeacherDashboard.Location = new Point(3, 3);
        btnMenuTeacherDashboard.Name = "btnMenuTeacherDashboard";
        btnMenuTeacherDashboard.Size = new Size(214, 46);
        btnMenuTeacherDashboard.TabIndex = 0;
        btnMenuTeacherDashboard.Text = "Dashboard giảng dạy";
        btnMenuTeacherDashboard.UseVisualStyleBackColor = true;
        // 
        // btnMenuTeachingClasses
        // 
        btnMenuTeachingClasses.Location = new Point(3, 55);
        btnMenuTeachingClasses.Name = "btnMenuTeachingClasses";
        btnMenuTeachingClasses.Size = new Size(214, 46);
        btnMenuTeachingClasses.TabIndex = 1;
        btnMenuTeachingClasses.Text = "Lớp đang dạy";
        btnMenuTeachingClasses.UseVisualStyleBackColor = true;
        // 
        // btnMenuClassStudentList
        // 
        btnMenuClassStudentList.Location = new Point(3, 107);
        btnMenuClassStudentList.Name = "btnMenuClassStudentList";
        btnMenuClassStudentList.Size = new Size(214, 46);
        btnMenuClassStudentList.TabIndex = 2;
        btnMenuClassStudentList.Text = "DS học viên lớp";
        btnMenuClassStudentList.UseVisualStyleBackColor = true;
        // 
        // btnMenuAttendance
        // 
        btnMenuAttendance.Location = new Point(3, 159);
        btnMenuAttendance.Name = "btnMenuAttendance";
        btnMenuAttendance.Size = new Size(214, 46);
        btnMenuAttendance.TabIndex = 3;
        btnMenuAttendance.Text = "Điểm danh";
        btnMenuAttendance.UseVisualStyleBackColor = true;
        // 
        // btnMenuScoreEntry
        // 
        btnMenuScoreEntry.Location = new Point(3, 211);
        btnMenuScoreEntry.Name = "btnMenuScoreEntry";
        btnMenuScoreEntry.Size = new Size(214, 46);
        btnMenuScoreEntry.TabIndex = 4;
        btnMenuScoreEntry.Text = "Nhập điểm";
        btnMenuScoreEntry.UseVisualStyleBackColor = true;
        // 
        // pnlSidebarTeacherBrand
        // 
        pnlSidebarTeacherBrand.Controls.Add(lblSidebarTeacherSubtitle);
        pnlSidebarTeacherBrand.Controls.Add(lblSidebarTeacherTitle);
        pnlSidebarTeacherBrand.Dock = DockStyle.Top;
        pnlSidebarTeacherBrand.Location = new Point(18, 18);
        pnlSidebarTeacherBrand.Name = "pnlSidebarTeacherBrand";
        pnlSidebarTeacherBrand.Size = new Size(220, 88);
        pnlSidebarTeacherBrand.AutoScroll = false;
        pnlSidebarTeacherBrand.TabIndex = 0;
        // 
        // lblSidebarTeacherSubtitle
        // 
        lblSidebarTeacherSubtitle.AutoSize = true;
        lblSidebarTeacherSubtitle.ForeColor = Color.FromArgb(0, 110, 110);
        lblSidebarTeacherSubtitle.Location = new Point(0, 34);
        lblSidebarTeacherSubtitle.Name = "lblSidebarTeacherSubtitle";
        lblSidebarTeacherSubtitle.Size = new Size(144, 28);
        lblSidebarTeacherSubtitle.AutoSize = true;
        lblSidebarTeacherSubtitle.TabIndex = 1;
        lblSidebarTeacherSubtitle.Text = "Tập trung vào lớp được giao";
        // 
        // lblSidebarTeacherTitle
        // 
        lblSidebarTeacherTitle.AutoSize = true;
        lblSidebarTeacherTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblSidebarTeacherTitle.ForeColor = Color.FromArgb(0, 66, 118);
        lblSidebarTeacherTitle.Location = new Point(0, 0);
        lblSidebarTeacherTitle.Name = "lblSidebarTeacherTitle";
        lblSidebarTeacherTitle.Size = new Size(116, 32);
        lblSidebarTeacherTitle.TabIndex = 0;
        lblSidebarTeacherTitle.Text = "TEACHER";
        // 
        // pnlTopbarTeacher
        // 
        pnlTopbarTeacher.BackColor = Color.White;
        pnlTopbarTeacher.Controls.Add(btnLogoutTeacher);
        pnlTopbarTeacher.Controls.Add(lblCurrentUserTeacher);
        pnlTopbarTeacher.Controls.Add(lblCurrentRoleTeacher);
        pnlTopbarTeacher.Dock = DockStyle.Top;
        pnlTopbarTeacher.Location = new Point(256, 0);
        pnlTopbarTeacher.Name = "pnlTopbarTeacher";
        pnlTopbarTeacher.Padding = new Padding(24, 18, 24, 18);
        pnlTopbarTeacher.Size = new Size(1116, 74);
        pnlTopbarTeacher.AutoScroll = false;
        pnlTopbarTeacher.TabIndex = 1;
        // 
        // btnLogoutTeacher
        // 
        btnLogoutTeacher.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLogoutTeacher.Location = new Point(972, 18);
        btnLogoutTeacher.Name = "btnLogoutTeacher";
        btnLogoutTeacher.Size = new Size(120, 36);
        btnLogoutTeacher.TabIndex = 2;
        btnLogoutTeacher.Text = "Đăng xuất";
        btnLogoutTeacher.UseVisualStyleBackColor = true;
        // 
        // lblCurrentUserTeacher
        // 
        lblCurrentUserTeacher.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblCurrentUserTeacher.AutoSize = true;
        lblCurrentUserTeacher.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCurrentUserTeacher.Location = new Point(818, 16);
        lblCurrentUserTeacher.Name = "lblCurrentUserTeacher";
        lblCurrentUserTeacher.Size = new Size(100, 23);
        lblCurrentUserTeacher.TabIndex = 1;
        lblCurrentUserTeacher.Text = "teacher.user";
        // 
        // lblCurrentRoleTeacher
        // 
        lblCurrentRoleTeacher.AutoSize = true;
        lblCurrentRoleTeacher.ForeColor = Color.FromArgb(102, 112, 133);
        lblCurrentRoleTeacher.Location = new Point(24, 24);
        lblCurrentRoleTeacher.Name = "lblCurrentRoleTeacher";
        lblCurrentRoleTeacher.Size = new Size(193, 28);
        lblCurrentRoleTeacher.AutoSize = true;
        lblCurrentRoleTeacher.TabIndex = 0;
        lblCurrentRoleTeacher.Text = "Vai trò: Teacher giảng dạy";
        // 
        // pnlContentHostTeacher
        // 
        pnlContentHostTeacher.Controls.Add(pnlDashboardHome);
        pnlContentHostTeacher.Dock = DockStyle.Fill;
        pnlContentHostTeacher.Location = new Point(256, 74);
        pnlContentHostTeacher.Name = "pnlContentHostTeacher";
        pnlContentHostTeacher.Padding = new Padding(20, 0, 20, 20);
        pnlContentHostTeacher.Size = new Size(1116, 687);
        pnlContentHostTeacher.AutoScroll = false;
        pnlContentHostTeacher.TabIndex = 2;
        // 
        // pnlDashboardHome
        // 
        pnlDashboardHome.Controls.Add(tblTeacherDashboardRoot);
        pnlDashboardHome.Dock = DockStyle.Fill;
        pnlDashboardHome.Location = new Point(20, 0);
        pnlDashboardHome.Name = "pnlDashboardHome";
        pnlDashboardHome.Size = new Size(1076, 667);
        pnlDashboardHome.AutoScroll = false;
        pnlDashboardHome.TabIndex = 0;
        // 
        // tblTeacherDashboardRoot
        // 
        tblTeacherDashboardRoot.ColumnCount = 1;
        tblTeacherDashboardRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblTeacherDashboardRoot.Controls.Add(pnlTeacherHeroCard, 0, 0);
        tblTeacherDashboardRoot.Controls.Add(tblTeacherKpi, 0, 1);
        tblTeacherDashboardRoot.Controls.Add(splTeacherDashboard, 0, 2);
        tblTeacherDashboardRoot.Dock = DockStyle.Fill;
        tblTeacherDashboardRoot.Location = new Point(0, 0);
        tblTeacherDashboardRoot.Name = "tblTeacherDashboardRoot";
        tblTeacherDashboardRoot.RowCount = 3;
        tblTeacherDashboardRoot.RowStyles.Add(new RowStyle());
        tblTeacherDashboardRoot.RowStyles.Add(new RowStyle());
        tblTeacherDashboardRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblTeacherDashboardRoot.Size = new Size(1076, 667);
        tblTeacherDashboardRoot.AutoScroll = false;
        tblTeacherDashboardRoot.TabIndex = 0;
        // 
        // pnlTeacherHeroCard
        // 
        pnlTeacherHeroCard.BackColor = Color.White;
        pnlTeacherHeroCard.Controls.Add(lblTeacherDashboardSubtitle);
        pnlTeacherHeroCard.Controls.Add(lblTeacherDashboardTitle);
        pnlTeacherHeroCard.Dock = DockStyle.Fill;
        pnlTeacherHeroCard.Location = new Point(0, 0);
        pnlTeacherHeroCard.Margin = new Padding(0, 0, 0, 16);
        pnlTeacherHeroCard.Name = "pnlTeacherHeroCard";
        pnlTeacherHeroCard.Padding = new Padding(24, 20, 24, 20);
        pnlTeacherHeroCard.Size = new Size(1076, 104);
        pnlTeacherHeroCard.AutoScroll = false;
        pnlTeacherHeroCard.TabIndex = 0;
        // 
        // lblTeacherDashboardSubtitle
        // 
        lblTeacherDashboardSubtitle.AutoSize = true;
        lblTeacherDashboardSubtitle.ForeColor = Color.FromArgb(102, 112, 133);
        lblTeacherDashboardSubtitle.Location = new Point(24, 58);
        lblTeacherDashboardSubtitle.Name = "lblTeacherDashboardSubtitle";
        lblTeacherDashboardSubtitle.Size = new Size(425, 28);
        lblTeacherDashboardSubtitle.AutoSize = true;
        lblTeacherDashboardSubtitle.TabIndex = 1;
        lblTeacherDashboardSubtitle.Text = "Theo dõi lớp đang dạy, điểm danh và nhập điểm đúng phạm vi phân công.";
        // 
        // lblTeacherDashboardTitle
        // 
        lblTeacherDashboardTitle.AutoSize = true;
        lblTeacherDashboardTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTeacherDashboardTitle.ForeColor = Color.FromArgb(7, 30, 39);
        lblTeacherDashboardTitle.Location = new Point(20, 10);
        lblTeacherDashboardTitle.Name = "lblTeacherDashboardTitle";
        lblTeacherDashboardTitle.Size = new Size(342, 46);
        lblTeacherDashboardTitle.TabIndex = 0;
        lblTeacherDashboardTitle.Text = "Dashboard giảng dạy";
        // 
        // tblTeacherKpi
        // 
        tblTeacherKpi.ColumnCount = 4;
        tblTeacherKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblTeacherKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblTeacherKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblTeacherKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tblTeacherKpi.Controls.Add(pnlTeachingClassesCount, 0, 0);
        tblTeacherKpi.Controls.Add(pnlTeachingStudentCount, 1, 0);
        tblTeacherKpi.Controls.Add(pnlTeachingTodaySessions, 2, 0);
        tblTeacherKpi.Controls.Add(pnlTeachingPendingScores, 3, 0);
        tblTeacherKpi.Dock = DockStyle.Fill;
        tblTeacherKpi.Location = new Point(0, 120);
        tblTeacherKpi.Margin = new Padding(0, 0, 0, 16);
        tblTeacherKpi.Name = "tblTeacherKpi";
        tblTeacherKpi.RowCount = 1;
        tblTeacherKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblTeacherKpi.Size = new Size(1076, 118);
        tblTeacherKpi.AutoScroll = false;
        tblTeacherKpi.TabIndex = 1;
        // 
        // pnlTeachingClassesCount
        // 
        pnlTeachingClassesCount.BackColor = Color.White;
        pnlTeachingClassesCount.Controls.Add(lblTeachingClassesCountValue);
        pnlTeachingClassesCount.Dock = DockStyle.Fill;
        pnlTeachingClassesCount.Location = new Point(0, 0);
        pnlTeachingClassesCount.Margin = new Padding(0, 0, 12, 0);
        pnlTeachingClassesCount.Name = "pnlTeachingClassesCount";
        pnlTeachingClassesCount.Padding = new Padding(18);
        pnlTeachingClassesCount.Size = new Size(257, 118);
        pnlTeachingClassesCount.AutoScroll = false;
        pnlTeachingClassesCount.TabIndex = 0;
        // 
        // lblTeachingClassesCountValue
        // 
        lblTeachingClassesCountValue.Dock = DockStyle.Fill;
        lblTeachingClassesCountValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTeachingClassesCountValue.Location = new Point(18, 18);
        lblTeachingClassesCountValue.Name = "lblTeachingClassesCountValue";
        lblTeachingClassesCountValue.Size = new Size(221, 82);
        lblTeachingClassesCountValue.TabIndex = 0;
        lblTeachingClassesCountValue.Text = "4";
        lblTeachingClassesCountValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlTeachingStudentCount
        // 
        pnlTeachingStudentCount.BackColor = Color.White;
        pnlTeachingStudentCount.Controls.Add(lblTeachingStudentCountValue);
        pnlTeachingStudentCount.Dock = DockStyle.Fill;
        pnlTeachingStudentCount.Location = new Point(269, 0);
        pnlTeachingStudentCount.Margin = new Padding(0, 0, 12, 0);
        pnlTeachingStudentCount.Name = "pnlTeachingStudentCount";
        pnlTeachingStudentCount.Padding = new Padding(18);
        pnlTeachingStudentCount.Size = new Size(257, 118);
        pnlTeachingStudentCount.AutoScroll = false;
        pnlTeachingStudentCount.TabIndex = 1;
        // 
        // lblTeachingStudentCountValue
        // 
        lblTeachingStudentCountValue.Dock = DockStyle.Fill;
        lblTeachingStudentCountValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTeachingStudentCountValue.Location = new Point(18, 18);
        lblTeachingStudentCountValue.Name = "lblTeachingStudentCountValue";
        lblTeachingStudentCountValue.Size = new Size(221, 82);
        lblTeachingStudentCountValue.TabIndex = 0;
        lblTeachingStudentCountValue.Text = "52";
        lblTeachingStudentCountValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlTeachingTodaySessions
        // 
        pnlTeachingTodaySessions.BackColor = Color.White;
        pnlTeachingTodaySessions.Controls.Add(lblTeachingTodaySessionsValue);
        pnlTeachingTodaySessions.Dock = DockStyle.Fill;
        pnlTeachingTodaySessions.Location = new Point(538, 0);
        pnlTeachingTodaySessions.Margin = new Padding(0, 0, 12, 0);
        pnlTeachingTodaySessions.Name = "pnlTeachingTodaySessions";
        pnlTeachingTodaySessions.Padding = new Padding(18);
        pnlTeachingTodaySessions.Size = new Size(257, 118);
        pnlTeachingTodaySessions.AutoScroll = false;
        pnlTeachingTodaySessions.TabIndex = 2;
        // 
        // lblTeachingTodaySessionsValue
        // 
        lblTeachingTodaySessionsValue.Dock = DockStyle.Fill;
        lblTeachingTodaySessionsValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTeachingTodaySessionsValue.Location = new Point(18, 18);
        lblTeachingTodaySessionsValue.Name = "lblTeachingTodaySessionsValue";
        lblTeachingTodaySessionsValue.Size = new Size(221, 82);
        lblTeachingTodaySessionsValue.TabIndex = 0;
        lblTeachingTodaySessionsValue.Text = "3";
        lblTeachingTodaySessionsValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlTeachingPendingScores
        // 
        pnlTeachingPendingScores.BackColor = Color.White;
        pnlTeachingPendingScores.Controls.Add(lblTeachingPendingScoresValue);
        pnlTeachingPendingScores.Dock = DockStyle.Fill;
        pnlTeachingPendingScores.Location = new Point(807, 0);
        pnlTeachingPendingScores.Margin = new Padding(0);
        pnlTeachingPendingScores.Name = "pnlTeachingPendingScores";
        pnlTeachingPendingScores.Padding = new Padding(18);
        pnlTeachingPendingScores.Size = new Size(269, 118);
        pnlTeachingPendingScores.AutoScroll = false;
        pnlTeachingPendingScores.TabIndex = 3;
        // 
        // lblTeachingPendingScoresValue
        // 
        lblTeachingPendingScoresValue.Dock = DockStyle.Fill;
        lblTeachingPendingScoresValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTeachingPendingScoresValue.Location = new Point(18, 18);
        lblTeachingPendingScoresValue.Name = "lblTeachingPendingScoresValue";
        lblTeachingPendingScoresValue.Size = new Size(233, 82);
        lblTeachingPendingScoresValue.TabIndex = 0;
        lblTeachingPendingScoresValue.Text = "1";
        lblTeachingPendingScoresValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // splTeacherDashboard
        // 
        splTeacherDashboard.Dock = DockStyle.Fill;
        splTeacherDashboard.Location = new Point(0, 254);
        splTeacherDashboard.Margin = new Padding(0);
        splTeacherDashboard.Name = "splTeacherDashboard";
        // 
        // splTeacherDashboard.Panel1
        // 
        splTeacherDashboard.Panel1.Controls.Add(pnlTeacherClassCard);
        splTeacherDashboard.Panel1.Padding = new Padding(0, 0, 10, 0);
        // 
        // splTeacherDashboard.Panel2
        // 
        splTeacherDashboard.Panel2.Controls.Add(pnlTeacherTaskCard);
        splTeacherDashboard.Panel2.Padding = new Padding(10, 0, 0, 0);
        splTeacherDashboard.Size = new Size(1076, 413);
        splTeacherDashboard.SplitterDistance = 724;
        splTeacherDashboard.AutoScroll = false;
        splTeacherDashboard.TabIndex = 2;
        // 
        // pnlTeacherClassCard
        // 
        pnlTeacherClassCard.BackColor = Color.White;
        pnlTeacherClassCard.Controls.Add(dgvTeacherClassOverview);
        pnlTeacherClassCard.Controls.Add(lblTeacherClassCardHint);
        pnlTeacherClassCard.Controls.Add(lblTeacherClassCardTitle);
        pnlTeacherClassCard.Dock = DockStyle.Fill;
        pnlTeacherClassCard.Location = new Point(0, 0);
        pnlTeacherClassCard.Name = "pnlTeacherClassCard";
        pnlTeacherClassCard.Padding = new Padding(18);
        pnlTeacherClassCard.Size = new Size(714, 413);
        pnlTeacherClassCard.AutoScroll = false;
        pnlTeacherClassCard.TabIndex = 0;
        // 
        // dgvTeacherClassOverview
        // 
        dgvTeacherClassOverview.Dock = DockStyle.Fill;
        dgvTeacherClassOverview.Location = new Point(18, 69);
        dgvTeacherClassOverview.Name = "dgvTeacherClassOverview";
        dgvTeacherClassOverview.RowHeadersWidth = 51;
        dgvTeacherClassOverview.Size = new Size(678, 326);
        dgvTeacherClassOverview.TabIndex = 2;
        // 
        // lblTeacherClassCardHint
        // 
        lblTeacherClassCardHint.Dock = DockStyle.Top;
        lblTeacherClassCardHint.ForeColor = Color.FromArgb(102, 112, 133);
        lblTeacherClassCardHint.Location = new Point(18, 41);
        lblTeacherClassCardHint.Name = "lblTeacherClassCardHint";
        lblTeacherClassCardHint.Size = new Size(678, 28);
        lblTeacherClassCardHint.TabIndex = 1;
        lblTeacherClassCardHint.Text = "Chỉ hiển thị lớp giáo viên đang phụ trách theo đúng phân quyền.";
        // 
        // lblTeacherClassCardTitle
        // 
        lblTeacherClassCardTitle.Dock = DockStyle.Top;
        lblTeacherClassCardTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblTeacherClassCardTitle.Location = new Point(18, 18);
        lblTeacherClassCardTitle.Name = "lblTeacherClassCardTitle";
        lblTeacherClassCardTitle.Size = new Size(678, 23);
        lblTeacherClassCardTitle.TabIndex = 0;
        lblTeacherClassCardTitle.Text = "Lớp được phân công";
        // 
        // pnlTeacherTaskCard
        // 
        pnlTeacherTaskCard.BackColor = Color.White;
        pnlTeacherTaskCard.Controls.Add(lstTeacherTaskQueue);
        pnlTeacherTaskCard.Controls.Add(lblTeacherTaskHint);
        pnlTeacherTaskCard.Controls.Add(lblTeacherTaskTitle);
        pnlTeacherTaskCard.Dock = DockStyle.Fill;
        pnlTeacherTaskCard.Location = new Point(10, 0);
        pnlTeacherTaskCard.Name = "pnlTeacherTaskCard";
        pnlTeacherTaskCard.Padding = new Padding(18);
        pnlTeacherTaskCard.Size = new Size(328, 413);
        pnlTeacherTaskCard.AutoScroll = false;
        pnlTeacherTaskCard.TabIndex = 0;
        // 
        // lstTeacherTaskQueue
        // 
        lstTeacherTaskQueue.BorderStyle = BorderStyle.None;
        lstTeacherTaskQueue.Dock = DockStyle.Fill;
        lstTeacherTaskQueue.FormattingEnabled = true;
        lstTeacherTaskQueue.ItemHeight = 20;
        lstTeacherTaskQueue.Items.AddRange(new object[] { "3 buổi học hôm nay cần điểm danh.", "1 lớp còn thiếu điểm giữa kỳ.", "2 lớp cần rà lại danh sách học viên trước buổi học.", "Kiểm tra lại ghi chú vắng phép của buổi gần nhất." });
        lstTeacherTaskQueue.Location = new Point(18, 69);
        lstTeacherTaskQueue.Name = "lstTeacherTaskQueue";
        lstTeacherTaskQueue.Size = new Size(292, 326);
        lstTeacherTaskQueue.TabIndex = 2;
        // 
        // lblTeacherTaskHint
        // 
        lblTeacherTaskHint.Dock = DockStyle.Top;
        lblTeacherTaskHint.ForeColor = Color.FromArgb(102, 112, 133);
        lblTeacherTaskHint.Location = new Point(18, 41);
        lblTeacherTaskHint.Name = "lblTeacherTaskHint";
        lblTeacherTaskHint.Size = new Size(292, 28);
        lblTeacherTaskHint.TabIndex = 1;
        lblTeacherTaskHint.Text = "Những việc giảng dạy cần ưu tiên xử lý.";
        // 
        // lblTeacherTaskTitle
        // 
        lblTeacherTaskTitle.Dock = DockStyle.Top;
        lblTeacherTaskTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblTeacherTaskTitle.Location = new Point(18, 18);
        lblTeacherTaskTitle.Name = "lblTeacherTaskTitle";
        lblTeacherTaskTitle.Size = new Size(292, 23);
        lblTeacherTaskTitle.TabIndex = 0;
        lblTeacherTaskTitle.Text = "Việc cần làm";
        // 
        // FrmTeacherDashboard
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(1372, 761);
        Font = new Font("Segoe UI", 10F);
        Controls.Add(pnlContentHostTeacher);
        Controls.Add(pnlTopbarTeacher);
        Controls.Add(pnlSidebarTeacher);
        MinimumSize = new Size(1180, 760);
        Name = "FrmTeacherDashboard";
        pnlSidebarTeacher.ResumeLayout(false);
        flpSidebarTeacherMenu.ResumeLayout(false);
        pnlSidebarTeacherBrand.ResumeLayout(false);
        pnlSidebarTeacherBrand.PerformLayout();
        pnlTopbarTeacher.ResumeLayout(false);
        pnlTopbarTeacher.PerformLayout();
        pnlContentHostTeacher.ResumeLayout(false);
        pnlDashboardHome.ResumeLayout(false);
        tblTeacherDashboardRoot.ResumeLayout(false);
        pnlTeacherHeroCard.ResumeLayout(false);
        pnlTeacherHeroCard.PerformLayout();
        tblTeacherKpi.ResumeLayout(false);
        pnlTeachingClassesCount.ResumeLayout(false);
        pnlTeachingStudentCount.ResumeLayout(false);
        pnlTeachingTodaySessions.ResumeLayout(false);
        pnlTeachingPendingScores.ResumeLayout(false);
        splTeacherDashboard.Panel1.ResumeLayout(false);
        splTeacherDashboard.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splTeacherDashboard).EndInit();
        splTeacherDashboard.ResumeLayout(false);
        pnlTeacherClassCard.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvTeacherClassOverview).EndInit();
        pnlTeacherTaskCard.ResumeLayout(false);
        AutoScroll = true;
        ResumeLayout(false);
    }
}

