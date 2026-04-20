using System.Drawing.Printing;

namespace Trung_tam_quan_ly_ngoai_ngu;

public sealed class FrmStaffDashboard : ShellFormBase
{
    public FrmStaffDashboard(string currentUserName)
        : base(
            "Dashboard vận hành",
            "Staff",
            currentUserName,
            new ShellChromeNames(
                "pnlSidebarStaff",
                "pnlTopbarStaff",
                "pnlContentHostStaff",
                "lblCurrentRoleStaff",
                "lblCurrentUserStaff",
                "btnLogoutStaff"))
    {
    }

    protected override IReadOnlyList<MenuDefinition> GetMenuDefinitions() =>
    [
        new("dashboard", "Dashboard vận hành", "btnMenuStaffDashboard"),
        new("studentManagement", "Quản lý học viên", "btnMenuStudentManagement"),
        new("teacherManagement", "Quản lý giáo viên", "btnMenuTeacherManagement"),
        new("courseManagement", "Quản lý khóa học", "btnMenuCourseManagement"),
        new("classManagement", "Quản lý lớp học", "btnMenuClassManagement"),
        new("enrollment", "Ghi danh / xếp lớp", "btnMenuEnrollment"),
        new("tuitionReceipt", "Thu học phí", "btnMenuTuitionReceipt"),
        new("debtTracking", "Công nợ học viên", "btnMenuDebtTracking")
    ];

    protected override Control BuildDashboardHome()
    {
        var root = new Panel { Dock = DockStyle.Fill, BackColor = AppTheme.Background };
        var title = UiHelpers.CreateLabel("lblStaffDashboardTitle", "Dashboard vận hành", AppTheme.FontTitle, AppTheme.TextPrimary);
        root.Controls.Add(title);

        var kpiRow = new FlowLayoutPanel
        {
            Name = "pnlStaffKpiRow",
            AutoSize = true,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            Location = new Point(0, 56),
            BackColor = Color.Transparent
        };
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlNewStudentsToday", "lblNewStudentsTodayTitle", "lblNewStudentsTodayValue", "HV mới hôm nay", "12", AppTheme.Accent));
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlAvailableClasses", "lblAvailableClassesTitle", "lblAvailableClassesValue", "Lớp còn chỗ", "9", AppTheme.Success));
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlTodayReceipts", "lblTodayReceiptsTitle", "lblTodayReceiptsValue", "Biên nhận hôm nay", "18", AppTheme.Warning));
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlDebtStudents", "lblDebtStudentsTitle", "lblDebtStudentsValue", "HV còn nợ", "27", AppTheme.Danger));
        root.Controls.Add(kpiRow);

        var contentGrid = UiHelpers.CreateContentGrid("tblStaffDashboardContent", 40F, 60F);
        contentGrid.Location = new Point(0, 188);
        contentGrid.Size = new Size(1120, 430);

        var leftCard = UiHelpers.CreateGroupBox("grpStaffTasks", "Công việc ưu tiên");
        var taskStack = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            BackColor = Color.Transparent
        };
        taskStack.Controls.Add(UiHelpers.CreateLabel("lblStaffTask01", "1. Kiểm tra học viên mới để hoàn tất hồ sơ.", AppTheme.FontBody, AppTheme.TextMuted));
        taskStack.Controls.Add(UiHelpers.CreateLabel("lblStaffTask02", "2. Lọc lớp còn chỗ trước khi ghi danh cho học viên.", AppTheme.FontBody, AppTheme.TextMuted));
        taskStack.Controls.Add(UiHelpers.CreateLabel("lblStaffTask03", "3. Theo dõi biên nhận trong ngày và các khoản còn nợ.", AppTheme.FontBody, AppTheme.TextMuted));
        taskStack.Controls.Add(UiHelpers.CreateLabel("lblStaffTask04", "4. Cập nhật giáo viên, khóa học và lớp khai giảng tuần này.", AppTheme.FontBody, AppTheme.TextMuted));
        var quickButtons = UiHelpers.CreateButtonBar("pnlStaffQuickButtons");
        var btnOpenStudentManagement = UiHelpers.CreateButton("btnOpenStudentManagement", "Mở học viên");
        var btnOpenEnrollment = UiHelpers.CreateButton("btnOpenEnrollment", "Mở ghi danh", "secondary");
        var btnOpenTuitionReceipt = UiHelpers.CreateButton("btnOpenTuitionReceipt", "Mở thu học phí", "secondary");
        var btnOpenDebtTracking = UiHelpers.CreateButton("btnOpenDebtTracking", "Mở công nợ", "secondary");
        btnOpenStudentManagement.Click += (_, _) =>
        {
            HighlightMenu("studentManagement");
            UiHelpers.ShowChildForm(pnlContentHost, new FrmStudentManagement());
        };
        btnOpenEnrollment.Click += (_, _) =>
        {
            HighlightMenu("enrollment");
            UiHelpers.ShowChildForm(pnlContentHost, new FrmEnrollment());
        };
        btnOpenTuitionReceipt.Click += (_, _) =>
        {
            HighlightMenu("tuitionReceipt");
            UiHelpers.ShowChildForm(pnlContentHost, new FrmTuitionReceipt());
        };
        btnOpenDebtTracking.Click += (_, _) =>
        {
            HighlightMenu("debtTracking");
            UiHelpers.ShowChildForm(pnlContentHost, new FrmDebtTracking());
        };
        quickButtons.Controls.Add(btnOpenStudentManagement);
        quickButtons.Controls.Add(btnOpenEnrollment);
        quickButtons.Controls.Add(btnOpenTuitionReceipt);
        quickButtons.Controls.Add(btnOpenDebtTracking);
        taskStack.Controls.Add(quickButtons);
        leftCard.Controls.Add(taskStack);

        var rightCard = UiHelpers.CreatePanel("pnlRecentReceiptsCard");
        AppTheme.StyleCard(rightCard);
        AppTheme.RoundPanelCorners(rightCard);
        var dgvRecentReceipts = UiHelpers.CreateGrid("dgvRecentReceipts", DemoDataFactory.GetRecentReceipts());
        rightCard.Controls.Add(dgvRecentReceipts);

        contentGrid.Controls.Add(leftCard, 0, 0);
        contentGrid.Controls.Add(rightCard, 1, 0);
        root.Controls.Add(contentGrid);
        return root;
    }

    protected override Form? CreateModuleForm(string key) => key switch
    {
        "studentManagement" => new FrmStudentManagement(),
        "teacherManagement" => new FrmTeacherManagement(),
        "courseManagement" => new FrmCourseManagement(),
        "classManagement" => new FrmClassManagement(),
        "enrollment" => new FrmEnrollment(),
        "tuitionReceipt" => new FrmTuitionReceipt(),
        "debtTracking" => new FrmDebtTracking(),
        _ => null
    };
}

public sealed class FrmStudentManagement : ModuleFormBase
{
    private readonly ErrorProvider errStudent;
    private readonly ToolTip ttStudentManagement;

    public FrmStudentManagement() : base("Quản lý học viên")
    {
        errStudent = new ErrorProvider { ContainerControl = this, BlinkStyle = ErrorBlinkStyle.NeverBlink };
        ttStudentManagement = new ToolTip();

        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 2,
            ColumnCount = 1,
            BackColor = Color.Transparent
        };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var filterCard = UiHelpers.CreatePanel("pnlStudentFilterCard");
        AppTheme.StyleCard(filterCard);
        AppTheme.RoundPanelCorners(filterCard);
        filterCard.Height = 92;
        filterCard.Padding = new Padding(16);
        var filterBar = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, BackColor = Color.Transparent };
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblStudentKeyword", "Từ khóa", UiHelpers.CreateTextBox("txtStudentKeyword", "Tên / số điện thoại / mã HV")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblStudentStatusFilter", "Trạng thái", UiHelpers.CreateComboBox("cboStudentStatusFilter", "Tất cả", "Đang học", "Bảo lưu", "Ngừng học")));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnSearchStudent", "Tìm"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnRefreshStudent", "Làm mới", "secondary"));
        filterCard.Controls.Add(filterBar);

        var contentGrid = UiHelpers.CreateContentGrid("tblStudentContent", 54F, 46F);
        var listCard = UiHelpers.CreatePanel("pnlStudentListCard");
        AppTheme.StyleCard(listCard);
        AppTheme.RoundPanelCorners(listCard);
        var dgvStudentList = UiHelpers.CreateGrid("dgvStudentList", DemoDataFactory.GetStudentList());
        listCard.Controls.Add(dgvStudentList);

        var rightLayout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1, BackColor = Color.Transparent };
        rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rightLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        var grpStudentInfo = UiHelpers.CreateGroupBox("grpStudentInfo", "Thông tin học viên");
        var fields = UiHelpers.CreateFieldGrid("tblStudentFields", 6, 2);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblStudentId", "Mã học viên", UiHelpers.CreateTextBox("txtStudentId")), 0, 0);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblStudentName", "Họ tên", UiHelpers.CreateTextBox("txtStudentName")), 1, 0);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblStudentDob", "Ngày sinh", UiHelpers.CreateDateTimePicker("dtpStudentDob")), 0, 1);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblStudentPhone", "Điện thoại", UiHelpers.CreateTextBox("txtStudentPhone")), 1, 1);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblStudentAddress", "Địa chỉ", UiHelpers.CreateTextBox("txtStudentAddress")), 0, 2);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblStudentEmail", "Email", UiHelpers.CreateTextBox("txtStudentEmail")), 1, 2);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblStudentParent", "Phụ huynh", UiHelpers.CreateTextBox("txtStudentParent")), 0, 3);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblStudentStatus", "Trạng thái", UiHelpers.CreateComboBox("cboStudentStatus", "Đang học", "Bảo lưu", "Ngừng học")), 1, 3);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblStudentNote", "Ghi chú", UiHelpers.CreateTextBox("txtStudentNote")), 0, 4);
        var avatarPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true, BackColor = Color.Transparent };
        var picStudentAvatar = UiHelpers.CreatePictureBox("picStudentAvatar");
        var btnChooseStudentAvatar = UiHelpers.CreateButton("btnChooseStudentAvatar", "Chọn ảnh", "secondary");
        var btnRemoveStudentAvatar = UiHelpers.CreateButton("btnRemoveStudentAvatar", "Xóa ảnh", "danger");
        avatarPanel.Controls.Add(picStudentAvatar);
        avatarPanel.Controls.Add(btnChooseStudentAvatar);
        avatarPanel.Controls.Add(btnRemoveStudentAvatar);
        fields.Controls.Add(avatarPanel, 1, 4);
        grpStudentInfo.Controls.Add(fields);

        var actionBar = UiHelpers.CreateButtonBar("pnlStudentActions");
        actionBar.Controls.Add(UiHelpers.CreateButton("btnCreateStudent", "Thêm mới"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnSaveStudent", "Lưu"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnUpdateStudent", "Cập nhật", "secondary"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnDeleteStudent", "Xóa mềm", "danger"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnResetStudent", "Làm mới", "secondary"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnOpenEnrollment", "Ghi danh", "secondary"));

        ttStudentManagement.SetToolTip(btnChooseStudentAvatar, "Chuẩn bị sẵn control để backend nối tính năng upload avatar.");

        rightLayout.Controls.Add(grpStudentInfo, 0, 0);
        rightLayout.Controls.Add(actionBar, 0, 1);

        contentGrid.Controls.Add(listCard, 0, 0);
        contentGrid.Controls.Add(rightLayout, 1, 0);

        root.Controls.Add(filterCard, 0, 0);
        root.Controls.Add(contentGrid, 0, 1);
        pnlModuleBody.Controls.Add(root);
    }
}

public sealed class FrmTeacherManagement : ModuleFormBase
{
    private readonly ErrorProvider errTeacher;

    public FrmTeacherManagement() : base("Quản lý giáo viên")
    {
        errTeacher = new ErrorProvider { ContainerControl = this, BlinkStyle = ErrorBlinkStyle.NeverBlink };

        var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1, BackColor = Color.Transparent };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var filterCard = UiHelpers.CreatePanel("pnlTeacherFilterCard");
        AppTheme.StyleCard(filterCard);
        AppTheme.RoundPanelCorners(filterCard);
        filterCard.Height = 92;
        filterCard.Padding = new Padding(16);
        var filterBar = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, BackColor = Color.Transparent };
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblTeacherKeyword", "Từ khóa", UiHelpers.CreateTextBox("txtTeacherKeyword", "Tên / điện thoại / chuyên môn")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblTeacherStatusFilter", "Trạng thái", UiHelpers.CreateComboBox("cboTeacherStatusFilter", "Tất cả", "Đang dạy", "Tạm nghỉ")));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnSearchTeacher", "Tìm"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnRefreshTeacher", "Làm mới", "secondary"));
        filterCard.Controls.Add(filterBar);

        var contentGrid = UiHelpers.CreateContentGrid("tblTeacherContent", 54F, 46F);
        var listCard = UiHelpers.CreatePanel("pnlTeacherListCard");
        AppTheme.StyleCard(listCard);
        AppTheme.RoundPanelCorners(listCard);
        var dgvTeacherList = UiHelpers.CreateGrid("dgvTeacherList", DemoDataFactory.GetTeacherList());
        listCard.Controls.Add(dgvTeacherList);

        var grpTeacherInfo = UiHelpers.CreateGroupBox("grpTeacherInfo", "Thông tin giáo viên");
        var fields = UiHelpers.CreateFieldGrid("tblTeacherFields", 5, 2);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblTeacherId", "Mã giáo viên", UiHelpers.CreateTextBox("txtTeacherId")), 0, 0);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblTeacherName", "Họ tên", UiHelpers.CreateTextBox("txtTeacherName")), 1, 0);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblTeacherPhone", "Điện thoại", UiHelpers.CreateTextBox("txtTeacherPhone")), 0, 1);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblTeacherEmail", "Email", UiHelpers.CreateTextBox("txtTeacherEmail")), 1, 1);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblTeacherSpecialization", "Chuyên môn", UiHelpers.CreateTextBox("txtTeacherSpecialization")), 0, 2);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblTeacherAddress", "Địa chỉ", UiHelpers.CreateTextBox("txtTeacherAddress")), 1, 2);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblTeacherStatus", "Trạng thái", UiHelpers.CreateComboBox("cboTeacherStatus", "Đang dạy", "Tạm nghỉ")), 0, 3);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblTeacherNote", "Ghi chú", UiHelpers.CreateTextBox("txtTeacherNote")), 1, 3);
        grpTeacherInfo.Controls.Add(fields);

        var rightLayout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1, BackColor = Color.Transparent };
        rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rightLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        var actionBar = UiHelpers.CreateButtonBar("pnlTeacherActions");
        actionBar.Controls.Add(UiHelpers.CreateButton("btnCreateTeacher", "Thêm mới"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnSaveTeacher", "Lưu"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnUpdateTeacher", "Cập nhật", "secondary"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnDeleteTeacher", "Xóa mềm", "danger"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnResetTeacher", "Làm mới", "secondary"));
        rightLayout.Controls.Add(grpTeacherInfo, 0, 0);
        rightLayout.Controls.Add(actionBar, 0, 1);

        contentGrid.Controls.Add(listCard, 0, 0);
        contentGrid.Controls.Add(rightLayout, 1, 0);

        root.Controls.Add(filterCard, 0, 0);
        root.Controls.Add(contentGrid, 0, 1);
        pnlModuleBody.Controls.Add(root);
    }
}

public sealed class FrmCourseManagement : ModuleFormBase
{
    public FrmCourseManagement() : base("Quản lý khóa học")
    {
        var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1, BackColor = Color.Transparent };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var filterCard = UiHelpers.CreatePanel("pnlCourseFilterCard");
        AppTheme.StyleCard(filterCard);
        AppTheme.RoundPanelCorners(filterCard);
        filterCard.Height = 92;
        filterCard.Padding = new Padding(16);
        var filterBar = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, BackColor = Color.Transparent };
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblCourseKeyword", "Từ khóa", UiHelpers.CreateTextBox("txtCourseKeyword", "Mã / tên khóa học")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblCourseStatusFilter", "Trạng thái", UiHelpers.CreateComboBox("cboCourseStatusFilter", "Tất cả", "Còn mở", "Tạm dừng")));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnSearchCourse", "Tìm"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnRefreshCourse", "Làm mới", "secondary"));
        filterCard.Controls.Add(filterBar);

        var contentGrid = UiHelpers.CreateContentGrid("tblCourseContent", 54F, 46F);
        var listCard = UiHelpers.CreatePanel("pnlCourseListCard");
        AppTheme.StyleCard(listCard);
        AppTheme.RoundPanelCorners(listCard);
        var dgvCourseList = UiHelpers.CreateGrid("dgvCourseList", DemoDataFactory.GetCourseList());
        listCard.Controls.Add(dgvCourseList);

        var grpCourseInfo = UiHelpers.CreateGroupBox("grpCourseInfo", "Thông tin khóa học");
        var fields = UiHelpers.CreateFieldGrid("tblCourseFields", 5, 2);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblCourseId", "Mã khóa", UiHelpers.CreateTextBox("txtCourseId")), 0, 0);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblCourseName", "Tên khóa", UiHelpers.CreateTextBox("txtCourseName")), 1, 0);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblCourseLevel", "Level", UiHelpers.CreateTextBox("txtCourseLevel")), 0, 1);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblCourseSessions", "Số buổi", UiHelpers.CreateTextBox("txtCourseSessions")), 1, 1);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblCourseFee", "Học phí", UiHelpers.CreateTextBox("txtCourseFee")), 0, 2);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblCourseStatus", "Trạng thái", UiHelpers.CreateComboBox("cboCourseStatus", "Còn mở", "Tạm dừng")), 1, 2);
        fields.Controls.Add(UiHelpers.CreateLabeledField("lblCourseDescription", "Mô tả", UiHelpers.CreateTextBox("txtCourseDescription")), 0, 3);
        grpCourseInfo.Controls.Add(fields);

        var rightLayout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1, BackColor = Color.Transparent };
        rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rightLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        var actionBar = UiHelpers.CreateButtonBar("pnlCourseActions");
        actionBar.Controls.Add(UiHelpers.CreateButton("btnCreateCourse", "Thêm mới"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnSaveCourse", "Lưu"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnUpdateCourse", "Cập nhật", "secondary"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnDeleteCourse", "Xóa mềm", "danger"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnResetCourse", "Làm mới", "secondary"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnOpenClassManagement", "Mở lớp học", "secondary"));
        rightLayout.Controls.Add(grpCourseInfo, 0, 0);
        rightLayout.Controls.Add(actionBar, 0, 1);

        contentGrid.Controls.Add(listCard, 0, 0);
        contentGrid.Controls.Add(rightLayout, 1, 0);
        root.Controls.Add(filterCard, 0, 0);
        root.Controls.Add(contentGrid, 0, 1);
        pnlModuleBody.Controls.Add(root);
    }
}

public sealed class FrmClassManagement : ModuleFormBase
{
    public FrmClassManagement() : base("Quản lý lớp học")
    {
        var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1, BackColor = Color.Transparent };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var filterCard = UiHelpers.CreatePanel("pnlClassFilterCard");
        AppTheme.StyleCard(filterCard);
        AppTheme.RoundPanelCorners(filterCard);
        filterCard.Height = 92;
        filterCard.Padding = new Padding(16);
        var filterBar = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, BackColor = Color.Transparent };
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblClassKeyword", "Từ khóa", UiHelpers.CreateTextBox("txtClassKeyword", "Mã / tên lớp")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblClassStatusFilter", "Trạng thái", UiHelpers.CreateComboBox("cboClassStatusFilter", "Tất cả", "Đang mở", "Đầy", "Đã đóng")));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnSearchClass", "Tìm"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnRefreshClass", "Làm mới", "secondary"));
        filterCard.Controls.Add(filterBar);

        var contentGrid = UiHelpers.CreateContentGrid("tblClassContent", 36F, 64F);
        var listCard = UiHelpers.CreatePanel("pnlClassListCard");
        AppTheme.StyleCard(listCard);
        AppTheme.RoundPanelCorners(listCard);
        var dgvClassList = UiHelpers.CreateGrid("dgvClassList", DemoDataFactory.GetClassList());
        listCard.Controls.Add(dgvClassList);

        var tabClassManagement = new TabControl
        {
            Name = "tabClassManagement",
            Dock = DockStyle.Fill
        };
        var tpClassInfo = new TabPage { Name = "tpClassInfo", Text = "Thông tin lớp", BackColor = AppTheme.Background };
        var tpClassStudents = new TabPage { Name = "tpClassStudents", Text = "Học viên trong lớp", BackColor = AppTheme.Background };
        var tpClassSessions = new TabPage { Name = "tpClassSessions", Text = "Buổi học / lịch học", BackColor = AppTheme.Background };

        var classInfoGroup = UiHelpers.CreateGroupBox("grpClassInfo", "Thông tin lớp");
        var classFields = UiHelpers.CreateFieldGrid("tblClassFields", 6, 2);
        classFields.Controls.Add(UiHelpers.CreateLabeledField("lblClassId", "Mã lớp", UiHelpers.CreateTextBox("txtClassId")), 0, 0);
        classFields.Controls.Add(UiHelpers.CreateLabeledField("lblClassName", "Tên lớp", UiHelpers.CreateTextBox("txtClassName")), 1, 0);
        classFields.Controls.Add(UiHelpers.CreateLabeledField("lblClassCourse", "Khóa học", UiHelpers.CreateComboBox("cboClassCourse", "English Foundation", "English Kids Starter", "Tin học cơ bản")), 0, 1);
        classFields.Controls.Add(UiHelpers.CreateLabeledField("lblClassTeacher", "Giáo viên", UiHelpers.CreateComboBox("cboClassTeacher", "Trần Minh An", "Phạm Thảo Vy", "Ngô Gia Hưng")), 1, 1);
        classFields.Controls.Add(UiHelpers.CreateLabeledField("lblClassSchedule", "Lịch học", UiHelpers.CreateTextBox("txtClassSchedule")), 0, 2);
        classFields.Controls.Add(UiHelpers.CreateLabeledField("lblClassRoom", "Phòng", UiHelpers.CreateTextBox("txtClassRoom")), 1, 2);
        classFields.Controls.Add(UiHelpers.CreateLabeledField("lblClassStartDate", "Ngày bắt đầu", UiHelpers.CreateDateTimePicker("dtpClassStartDate")), 0, 3);
        classFields.Controls.Add(UiHelpers.CreateLabeledField("lblClassEndDate", "Ngày kết thúc", UiHelpers.CreateDateTimePicker("dtpClassEndDate")), 1, 3);
        classFields.Controls.Add(UiHelpers.CreateLabeledField("lblClassCapacity", "Sĩ số tối đa", UiHelpers.CreateTextBox("txtClassCapacity")), 0, 4);
        classFields.Controls.Add(UiHelpers.CreateLabeledField("lblClassCurrentSize", "Sĩ số hiện tại", UiHelpers.CreateTextBox("txtClassCurrentSize")), 1, 4);
        classFields.Controls.Add(UiHelpers.CreateLabeledField("lblClassStatus", "Trạng thái", UiHelpers.CreateComboBox("cboClassStatus", "Đang mở", "Đầy", "Đã đóng")), 0, 5);
        classInfoGroup.Controls.Add(classFields);
        var classActionBar = UiHelpers.CreateButtonBar("pnlClassActions");
        classActionBar.Controls.Add(UiHelpers.CreateButton("btnCreateClass", "Thêm lớp"));
        classActionBar.Controls.Add(UiHelpers.CreateButton("btnSaveClass", "Lưu"));
        classActionBar.Controls.Add(UiHelpers.CreateButton("btnUpdateClass", "Cập nhật", "secondary"));
        classActionBar.Controls.Add(UiHelpers.CreateButton("btnGenerateSessions", "Sinh buổi học", "secondary"));
        classActionBar.Controls.Add(UiHelpers.CreateButton("btnOpenEnrollmentFromClass", "Mở ghi danh", "secondary"));
        classActionBar.Controls.Add(UiHelpers.CreateButton("btnOpenAttendanceFromClass", "Mở điểm danh", "secondary"));
        classActionBar.Controls.Add(UiHelpers.CreateButton("btnOpenScoreEntryFromClass", "Mở nhập điểm", "secondary"));
        var infoLayout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1 };
        infoLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        infoLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        infoLayout.Controls.Add(classInfoGroup, 0, 0);
        infoLayout.Controls.Add(classActionBar, 0, 1);
        tpClassInfo.Controls.Add(infoLayout);

        var dgvClassStudentList = UiHelpers.CreateGrid("dgvClassStudentList", DemoDataFactory.GetClassStudents());
        tpClassStudents.Controls.Add(dgvClassStudentList);
        var dgvClassSessionList = UiHelpers.CreateGrid("dgvClassSessionList", DemoDataFactory.GetSessions());
        tpClassSessions.Controls.Add(dgvClassSessionList);

        tabClassManagement.TabPages.Add(tpClassInfo);
        tabClassManagement.TabPages.Add(tpClassStudents);
        tabClassManagement.TabPages.Add(tpClassSessions);

        contentGrid.Controls.Add(listCard, 0, 0);
        contentGrid.Controls.Add(tabClassManagement, 1, 0);
        root.Controls.Add(filterCard, 0, 0);
        root.Controls.Add(contentGrid, 0, 1);
        pnlModuleBody.Controls.Add(root);
    }
}

public sealed class FrmEnrollment : ModuleFormBase
{
    public FrmEnrollment() : base("Ghi danh / xếp lớp")
    {
        var contentGrid = UiHelpers.CreateContentGrid("tblEnrollmentContent", 32F, 32F, 36F);

        var grpEnrollmentStudentSelect = UiHelpers.CreateGroupBox("grpEnrollmentStudentSelect", "1. Chọn học viên");
        var studentLayout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1 };
        studentLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        studentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        var studentFilter = new FlowLayoutPanel { Dock = DockStyle.Top, WrapContents = false, BackColor = Color.Transparent };
        studentFilter.Controls.Add(UiHelpers.CreateLabeledField("lblEnrollmentStudentKeyword", "Từ khóa", UiHelpers.CreateTextBox("txtEnrollmentStudentKeyword", "Tên / SĐT / mã HV")));
        studentFilter.Controls.Add(UiHelpers.CreateButton("btnSearchEnrollmentStudent", "Tìm", "secondary"));
        studentLayout.Controls.Add(studentFilter, 0, 0);
        studentLayout.Controls.Add(UiHelpers.CreateGrid("dgvEnrollmentStudentList", DemoDataFactory.GetEnrollmentStudents()), 0, 1);
        grpEnrollmentStudentSelect.Controls.Add(studentLayout);

        var grpEnrollmentClassSelect = UiHelpers.CreateGroupBox("grpEnrollmentClassSelect", "2. Chọn khóa học / lớp");
        var classLayout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3, ColumnCount = 1 };
        classLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        classLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        classLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        classLayout.Controls.Add(UiHelpers.CreateLabeledField("lblEnrollmentCourse", "Khóa học", UiHelpers.CreateComboBox("cboEnrollmentCourse", "English Foundation", "English Kids Starter", "Tin học cơ bản")), 0, 0);
        classLayout.Controls.Add(UiHelpers.CreateLabeledField("lblEnrollmentClassStatus", "Lọc lớp", UiHelpers.CreateComboBox("cboEnrollmentClassStatus", "Còn chỗ", "Đang mở")), 0, 1);
        classLayout.Controls.Add(UiHelpers.CreateGrid("dgvEnrollmentClassList", DemoDataFactory.GetEnrollmentClasses()), 0, 2);
        grpEnrollmentClassSelect.Controls.Add(classLayout);

        var grpEnrollmentSummary = UiHelpers.CreateGroupBox("grpEnrollmentSummary", "3. Tóm tắt ghi danh");
        var summaryFields = UiHelpers.CreateFieldGrid("tblEnrollmentSummaryFields", 8, 1);
        summaryFields.Controls.Add(UiHelpers.CreateLabeledField("lblEnrollmentDate", "Ngày ghi danh", UiHelpers.CreateDateTimePicker("dtpEnrollmentDate")), 0, 0);
        summaryFields.Controls.Add(UiHelpers.CreateLabeledField("lblEnrollmentOriginalFee", "Học phí gốc", UiHelpers.CreateTextBox("txtEnrollmentOriginalFee")), 0, 1);
        summaryFields.Controls.Add(UiHelpers.CreateLabeledField("lblEnrollmentDiscount", "Giảm giá", UiHelpers.CreateTextBox("txtEnrollmentDiscount")), 0, 2);
        summaryFields.Controls.Add(UiHelpers.CreateLabeledField("lblEnrollmentFinalFee", "Học phí cuối", UiHelpers.CreateTextBox("txtEnrollmentFinalFee")), 0, 3);
        summaryFields.Controls.Add(UiHelpers.CreateLabeledField("lblEnrollmentStatus", "Trạng thái", UiHelpers.CreateComboBox("cboEnrollmentStatus", "Đang học", "Bảo lưu")), 0, 4);
        summaryFields.Controls.Add(UiHelpers.CreateLabeledField("lblEnrollmentNote", "Ghi chú", UiHelpers.CreateTextBox("txtEnrollmentNote")), 0, 5);
        var actionBar = UiHelpers.CreateButtonBar("pnlEnrollmentActions");
        actionBar.Controls.Add(UiHelpers.CreateButton("btnCreateEnrollment", "Tạo ghi danh"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnRefreshEnrollment", "Làm mới", "secondary"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnOpenTuitionReceipt", "Chuyển sang thu học phí", "secondary"));
        summaryFields.Controls.Add(actionBar, 0, 6);
        grpEnrollmentSummary.Controls.Add(summaryFields);

        contentGrid.Controls.Add(grpEnrollmentStudentSelect, 0, 0);
        contentGrid.Controls.Add(grpEnrollmentClassSelect, 1, 0);
        contentGrid.Controls.Add(grpEnrollmentSummary, 2, 0);
        pnlModuleBody.Controls.Add(contentGrid);
    }
}

public sealed class FrmTuitionReceipt : ModuleFormBase
{
    private readonly PrintPreviewDialog ppdTuitionReceiptPreview;
    private readonly PrintDocument prdTuitionReceipt;
    private readonly ToolTip ttTuitionReceipt;
    private readonly ErrorProvider errTuitionReceipt;

    public FrmTuitionReceipt() : base("Thu học phí / biên nhận")
    {
        ppdTuitionReceiptPreview = new PrintPreviewDialog { Name = "ppdTuitionReceiptPreview" };
        prdTuitionReceipt = new PrintDocument { DocumentName = "Biên nhận học phí" };
        prdTuitionReceipt.PrintPage += (_, e) =>
        {
            if (e.Graphics is null)
            {
                return;
            }

            using var font = new Font("Segoe UI", 14F, FontStyle.Bold);
            e.Graphics.DrawString("Biên nhận học phí - UI demo", font, Brushes.Black, 60, 60);
        };
        ppdTuitionReceiptPreview.Document = prdTuitionReceipt;
        ttTuitionReceipt = new ToolTip();
        errTuitionReceipt = new ErrorProvider { ContainerControl = this, BlinkStyle = ErrorBlinkStyle.NeverBlink };

        var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3, ColumnCount = 1, BackColor = Color.Transparent };
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 32F));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 38F));

        var grpEnrollmentInfo = UiHelpers.CreateGroupBox("grpEnrollmentInfo", "Thông tin ghi danh");
        var enrollmentFields = UiHelpers.CreateFieldGrid("tblTuitionEnrollmentFields", 4, 2);
        enrollmentFields.Controls.Add(UiHelpers.CreateLabeledField("lblReceiptStudent", "Học viên", UiHelpers.CreateTextBox("txtReceiptStudent")), 0, 0);
        enrollmentFields.Controls.Add(UiHelpers.CreateLabeledField("lblReceiptClass", "Lớp", UiHelpers.CreateTextBox("txtReceiptClass")), 1, 0);
        enrollmentFields.Controls.Add(UiHelpers.CreateLabeledField("lblReceiptCourse", "Khóa học", UiHelpers.CreateTextBox("txtReceiptCourse")), 0, 1);
        enrollmentFields.Controls.Add(UiHelpers.CreateLabeledField("lblReceiptFinalFee", "Học phí cuối", UiHelpers.CreateTextBox("txtReceiptFinalFee")), 1, 1);
        enrollmentFields.Controls.Add(UiHelpers.CreateLabeledField("lblReceiptPaid", "Đã thu", UiHelpers.CreateTextBox("txtReceiptPaid")), 0, 2);
        enrollmentFields.Controls.Add(UiHelpers.CreateLabeledField("lblReceiptDebt", "Còn nợ", UiHelpers.CreateTextBox("txtReceiptDebt")), 1, 2);
        grpEnrollmentInfo.Controls.Add(enrollmentFields);

        var grpPaymentInfo = UiHelpers.CreateGroupBox("grpPaymentInfo", "Khối thu tiền");
        var paymentFields = UiHelpers.CreateFieldGrid("tblPaymentFields", 4, 2);
        paymentFields.Controls.Add(UiHelpers.CreateLabeledField("lblReceiptNumber", "Số biên nhận", UiHelpers.CreateTextBox("txtReceiptNumber")), 0, 0);
        paymentFields.Controls.Add(UiHelpers.CreateLabeledField("lblReceiptPayDate", "Ngày nộp", UiHelpers.CreateDateTimePicker("dtpReceiptPayDate")), 1, 0);
        paymentFields.Controls.Add(UiHelpers.CreateLabeledField("lblReceiptAmount", "Số tiền nộp", UiHelpers.CreateTextBox("txtReceiptAmount")), 0, 1);
        paymentFields.Controls.Add(UiHelpers.CreateLabeledField("lblReceiptMethod", "Phương thức", UiHelpers.CreateComboBox("cboReceiptMethod", "Tiền mặt", "Chuyển khoản", "Ví điện tử")), 1, 1);
        paymentFields.Controls.Add(UiHelpers.CreateLabeledField("lblReceiptNote", "Ghi chú", UiHelpers.CreateTextBox("txtReceiptNote")), 0, 2);
        var actionBar = UiHelpers.CreateButtonBar("pnlTuitionReceiptActions");
        var btnCollectTuition = UiHelpers.CreateButton("btnCollectTuition", "Thu học phí");
        var btnSavePrintReceipt = UiHelpers.CreateButton("btnSavePrintReceipt", "Lưu & In biên nhận", "secondary");
        var btnViewReceipt = UiHelpers.CreateButton("btnViewReceipt", "Xem biên nhận", "secondary");
        var btnCancelReceipt = UiHelpers.CreateButton("btnCancelReceipt", "Hủy biên nhận", "danger");
        btnViewReceipt.Click += (_, _) => ppdTuitionReceiptPreview.ShowDialog(this);
        actionBar.Controls.Add(btnCollectTuition);
        actionBar.Controls.Add(btnSavePrintReceipt);
        actionBar.Controls.Add(btnViewReceipt);
        actionBar.Controls.Add(btnCancelReceipt);
        paymentFields.Controls.Add(actionBar, 0, 3);
        grpPaymentInfo.Controls.Add(paymentFields);

        var historyCard = UiHelpers.CreatePanel("pnlReceiptHistoryCard");
        AppTheme.StyleCard(historyCard);
        AppTheme.RoundPanelCorners(historyCard);
        var dgvReceiptHistory = UiHelpers.CreateGrid("dgvReceiptHistory", DemoDataFactory.GetReceiptHistory());
        historyCard.Controls.Add(dgvReceiptHistory);

        ttTuitionReceipt.SetToolTip(btnSavePrintReceipt, "Đã gắn sẵn PrintPreviewDialog và PrintDocument để backend nối logic in.");

        root.Controls.Add(grpEnrollmentInfo, 0, 0);
        root.Controls.Add(grpPaymentInfo, 0, 1);
        root.Controls.Add(historyCard, 0, 2);
        pnlModuleBody.Controls.Add(root);
    }
}

public sealed class FrmDebtTracking : ModuleFormBase
{
    public FrmDebtTracking() : base("Công nợ học viên")
    {
        var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3, ColumnCount = 1, BackColor = Color.Transparent };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var filterCard = UiHelpers.CreatePanel("pnlDebtFilterCard");
        AppTheme.StyleCard(filterCard);
        AppTheme.RoundPanelCorners(filterCard);
        filterCard.Height = 98;
        filterCard.Padding = new Padding(16);
        var filterBar = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, BackColor = Color.Transparent };
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblDebtCourseFilter", "Khóa học", UiHelpers.CreateComboBox("cboDebtCourseFilter", "Tất cả", "English Foundation", "Tin học cơ bản")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblDebtClassFilter", "Lớp", UiHelpers.CreateComboBox("cboDebtClassFilter", "Tất cả", "ENG-A1-01", "TIN-CB-03")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblDebtFromDate", "Từ ngày", UiHelpers.CreateDateTimePicker("dtpDebtFromDate")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblDebtToDate", "Đến ngày", UiHelpers.CreateDateTimePicker("dtpDebtToDate")));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnSearchDebt", "Tìm"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnRefreshDebt", "Làm mới", "secondary"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnExportDebt", "Xuất Excel/PDF", "secondary"));
        filterCard.Controls.Add(filterBar);

        var summaryRow = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, WrapContents = false, AutoSize = true, BackColor = Color.Transparent };
        summaryRow.Controls.Add(UiHelpers.CreateMetricCard("pnlDebtTotalCount", "lblDebtTotalCountTitle", "lblDebtTotalCountValue", "Học viên còn nợ", "27", AppTheme.Danger));
        summaryRow.Controls.Add(UiHelpers.CreateMetricCard("pnlDebtTotalAmount", "lblDebtTotalAmountTitle", "lblDebtTotalAmountValue", "Tổng công nợ", "54.300.000", AppTheme.Warning));

        var listCard = UiHelpers.CreatePanel("pnlDebtListCard");
        AppTheme.StyleCard(listCard);
        AppTheme.RoundPanelCorners(listCard);
        var inner = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1, BackColor = Color.Transparent };
        inner.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        inner.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        var dgvDebtTrackingList = UiHelpers.CreateGrid("dgvDebtTrackingList", DemoDataFactory.GetDebtList());
        var actionBar = UiHelpers.CreateButtonBar("pnlDebtActions");
        actionBar.Controls.Add(UiHelpers.CreateButton("btnOpenTuitionFromDebt", "Thu tiền nhanh"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnViewReceiptHistory", "Xem lịch sử biên nhận", "secondary"));
        inner.Controls.Add(dgvDebtTrackingList, 0, 0);
        inner.Controls.Add(actionBar, 0, 1);
        listCard.Controls.Add(inner);

        root.Controls.Add(filterCard, 0, 0);
        root.Controls.Add(summaryRow, 0, 1);
        root.Controls.Add(listCard, 0, 2);
        pnlModuleBody.Controls.Add(root);
    }
}
