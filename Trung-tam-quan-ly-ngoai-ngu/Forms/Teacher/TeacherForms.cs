namespace Trung_tam_quan_ly_ngoai_ngu;

public sealed class FrmTeacherDashboard : ShellFormBase
{
    public FrmTeacherDashboard(string currentUserName)
        : base(
            "Dashboard giảng dạy",
            "Teacher",
            currentUserName,
            new ShellChromeNames(
                "pnlSidebarTeacher",
                "pnlTopbarTeacher",
                "pnlContentHostTeacher",
                "lblCurrentRoleTeacher",
                "lblCurrentUserTeacher",
                "btnLogoutTeacher"))
    {
    }

    protected override IReadOnlyList<MenuDefinition> GetMenuDefinitions() =>
    [
        new("dashboard", "Dashboard giảng dạy", "btnMenuTeacherDashboard"),
        new("teachingClasses", "Lớp đang dạy", "btnMenuTeachingClasses"),
        new("classStudentList", "DS học viên lớp", "btnMenuClassStudentList"),
        new("attendance", "Điểm danh", "btnMenuAttendance"),
        new("scoreEntry", "Nhập điểm", "btnMenuScoreEntry")
    ];

    protected override Control BuildDashboardHome()
    {
        var root = new Panel { Dock = DockStyle.Fill, BackColor = AppTheme.Background };
        var title = UiHelpers.CreateLabel("lblTeacherDashboardTitle", "Dashboard giảng dạy", AppTheme.FontTitle, AppTheme.TextPrimary);
        root.Controls.Add(title);

        var kpiRow = new FlowLayoutPanel
        {
            Name = "pnlTeacherKpiRow",
            AutoSize = true,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            Location = new Point(0, 56),
            BackColor = Color.Transparent
        };
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlTeachingClassesCount", "lblTeachingClassesCountTitle", "lblTeachingClassesCountValue", "Lớp phụ trách", "4", AppTheme.Accent));
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlTeachingStudentCount", "lblTeachingStudentCountTitle", "lblTeachingStudentCountValue", "Học viên", "52", AppTheme.Success));
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlTeachingTodaySessions", "lblTeachingTodaySessionsTitle", "lblTeachingTodaySessionsValue", "Ca dạy hôm nay", "3", AppTheme.Warning));
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlTeachingPendingScores", "lblTeachingPendingScoresTitle", "lblTeachingPendingScoresValue", "Lớp chưa nhập điểm", "1", AppTheme.Danger));
        root.Controls.Add(kpiRow);

        var contentGrid = UiHelpers.CreateContentGrid("tblTeacherDashboardContent", 50F, 50F);
        contentGrid.Location = new Point(0, 188);
        contentGrid.Size = new Size(1120, 430);

        var leftCard = UiHelpers.CreatePanel("pnlTeacherClassListCard");
        AppTheme.StyleCard(leftCard);
        AppTheme.RoundPanelCorners(leftCard);
        var dgvTeacherClassOverview = UiHelpers.CreateGrid("dgvTeacherClassOverview", DemoDataFactory.GetTeachingClasses());
        leftCard.Controls.Add(dgvTeacherClassOverview);

        var rightCard = UiHelpers.CreateGroupBox("grpTeacherTasks", "Các việc của giáo viên");
        var taskStack = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            BackColor = Color.Transparent
        };
        taskStack.Controls.Add(UiHelpers.CreateLabel("lblTeacherTask01", "1. Mở danh sách lớp đang dạy để kiểm tra lịch học gần nhất.", AppTheme.FontBody, AppTheme.TextMuted));
        taskStack.Controls.Add(UiHelpers.CreateLabel("lblTeacherTask02", "2. Điểm danh theo buổi học đang diễn ra hoặc sắp bắt đầu.", AppTheme.FontBody, AppTheme.TextMuted));
        taskStack.Controls.Add(UiHelpers.CreateLabel("lblTeacherTask03", "3. Rà soát danh sách học viên trước khi nhập điểm.", AppTheme.FontBody, AppTheme.TextMuted));
        taskStack.Controls.Add(UiHelpers.CreateLabel("lblTeacherTask04", "4. Hoàn tất nhập điểm giữa kỳ / cuối kỳ cho lớp còn thiếu.", AppTheme.FontBody, AppTheme.TextMuted));
        var quickButtons = UiHelpers.CreateButtonBar("pnlTeacherQuickButtons");
        var btnOpenTeachingClasses = UiHelpers.CreateButton("btnOpenTeachingClasses", "Mở lớp đang dạy");
        var btnOpenAttendance = UiHelpers.CreateButton("btnOpenAttendance", "Mở điểm danh", "secondary");
        var btnOpenScoreEntry = UiHelpers.CreateButton("btnOpenScoreEntry", "Mở nhập điểm", "secondary");
        btnOpenTeachingClasses.Click += (_, _) =>
        {
            HighlightMenu("teachingClasses");
            UiHelpers.ShowChildForm(pnlContentHost, new FrmTeachingClasses());
        };
        btnOpenAttendance.Click += (_, _) =>
        {
            HighlightMenu("attendance");
            UiHelpers.ShowChildForm(pnlContentHost, new FrmAttendance());
        };
        btnOpenScoreEntry.Click += (_, _) =>
        {
            HighlightMenu("scoreEntry");
            UiHelpers.ShowChildForm(pnlContentHost, new FrmScoreEntry());
        };
        quickButtons.Controls.Add(btnOpenTeachingClasses);
        quickButtons.Controls.Add(btnOpenAttendance);
        quickButtons.Controls.Add(btnOpenScoreEntry);
        taskStack.Controls.Add(quickButtons);
        rightCard.Controls.Add(taskStack);

        contentGrid.Controls.Add(leftCard, 0, 0);
        contentGrid.Controls.Add(rightCard, 1, 0);
        root.Controls.Add(contentGrid);
        return root;
    }

    protected override Form? CreateModuleForm(string key) => key switch
    {
        "teachingClasses" => new FrmTeachingClasses(),
        "classStudentList" => new FrmClassStudentList(),
        "attendance" => new FrmAttendance(),
        "scoreEntry" => new FrmScoreEntry(),
        _ => null
    };
}

public sealed class FrmTeachingClasses : ModuleFormBase
{
    public FrmTeachingClasses() : base("Lớp đang dạy")
    {
        var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1, BackColor = Color.Transparent };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var filterCard = UiHelpers.CreatePanel("pnlTeachingClassFilterCard");
        AppTheme.StyleCard(filterCard);
        AppTheme.RoundPanelCorners(filterCard);
        filterCard.Height = 92;
        filterCard.Padding = new Padding(16);
        var filterBar = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, BackColor = Color.Transparent };
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblTeachingClassKeyword", "Từ khóa", UiHelpers.CreateTextBox("txtTeachingClassKeyword", "Tên lớp / mã lớp")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblTeachingStatusFilter", "Trạng thái", UiHelpers.CreateComboBox("cboTeachingStatusFilter", "Đang dạy", "Sắp khai giảng", "Đã kết thúc")));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnSearchTeachingClass", "Tìm"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnRefreshTeachingClass", "Làm mới", "secondary"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnOpenClassStudentList", "Mở DS học viên", "secondary"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnOpenAttendance", "Mở điểm danh", "secondary"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnOpenScoreEntry", "Mở nhập điểm", "secondary"));
        filterCard.Controls.Add(filterBar);

        var listCard = UiHelpers.CreatePanel("pnlTeachingClassListCard");
        AppTheme.StyleCard(listCard);
        AppTheme.RoundPanelCorners(listCard);
        var dgvTeachingClassList = UiHelpers.CreateGrid("dgvTeachingClassList", DemoDataFactory.GetTeachingClasses());
        listCard.Controls.Add(dgvTeachingClassList);

        root.Controls.Add(filterCard, 0, 0);
        root.Controls.Add(listCard, 0, 1);
        pnlModuleBody.Controls.Add(root);
    }
}

public sealed class FrmClassStudentList : ModuleFormBase
{
    public FrmClassStudentList() : base("Danh sách học viên lớp")
    {
        var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 3, ColumnCount = 1, BackColor = Color.Transparent };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var filterCard = UiHelpers.CreatePanel("pnlClassStudentFilterCard");
        AppTheme.StyleCard(filterCard);
        AppTheme.RoundPanelCorners(filterCard);
        filterCard.Height = 92;
        filterCard.Padding = new Padding(16);
        var filterBar = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, BackColor = Color.Transparent };
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblClassStudentClass", "Lớp", UiHelpers.CreateComboBox("cboClassStudentClass", "ENG-A1-01", "ENG-IELTS-02")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblClassStudentKeyword", "Từ khóa", UiHelpers.CreateTextBox("txtClassStudentKeyword", "Tên học viên / mã HV")));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnSearchClassStudent", "Tìm"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnRefreshClassStudent", "Làm mới", "secondary"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnOpenAttendanceFromStudentList", "Mở điểm danh", "secondary"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnBackToTeachingClasses", "Quay lại lớp dạy", "secondary"));
        filterCard.Controls.Add(filterBar);

        var summaryRow = new FlowLayoutPanel { AutoSize = true, WrapContents = false, BackColor = Color.Transparent };
        summaryRow.Controls.Add(UiHelpers.CreateMetricCard("pnlClassStudentCount", "lblClassStudentCountTitle", "lblClassStudentCountValue", "Số học viên", "18", AppTheme.Accent));
        summaryRow.Controls.Add(UiHelpers.CreateMetricCard("pnlClassStudentSchedule", "lblClassStudentScheduleTitle", "lblClassStudentScheduleValue", "Lịch học", "2-4-6", AppTheme.Success));

        var listCard = UiHelpers.CreatePanel("pnlClassStudentListCard");
        AppTheme.StyleCard(listCard);
        AppTheme.RoundPanelCorners(listCard);
        var dgvClassStudentList = UiHelpers.CreateGrid("dgvClassStudentList", DemoDataFactory.GetClassStudents());
        listCard.Controls.Add(dgvClassStudentList);

        root.Controls.Add(filterCard, 0, 0);
        root.Controls.Add(summaryRow, 0, 1);
        root.Controls.Add(listCard, 0, 2);
        pnlModuleBody.Controls.Add(root);
    }
}

public sealed class FrmAttendance : ModuleFormBase
{
    private readonly ToolTip ttAttendance;
    private readonly ErrorProvider errAttendance;

    public FrmAttendance() : base("Điểm danh")
    {
        ttAttendance = new ToolTip();
        errAttendance = new ErrorProvider { ContainerControl = this, BlinkStyle = ErrorBlinkStyle.NeverBlink };

        var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1, BackColor = Color.Transparent };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var filterCard = UiHelpers.CreatePanel("pnlAttendanceFilterCard");
        AppTheme.StyleCard(filterCard);
        AppTheme.RoundPanelCorners(filterCard);
        filterCard.Height = 92;
        filterCard.Padding = new Padding(16);
        var filterBar = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, BackColor = Color.Transparent };
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblAttendanceClass", "Lớp", UiHelpers.CreateComboBox("cboAttendanceClass", "ENG-A1-01", "ENG-IELTS-02")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblAttendanceSession", "Buổi học", UiHelpers.CreateComboBox("cboAttendanceSession", "Buổi 01", "Buổi 02", "Buổi 03")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblAttendanceDate", "Ngày học", UiHelpers.CreateDateTimePicker("dtpAttendanceDate")));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnSearchAttendance", "Xem danh sách"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnSelectAllAttendance", "Chọn tất cả", "secondary"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnSaveAttendance", "Lưu điểm danh"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnClearAttendance", "Làm mới", "secondary"));
        filterCard.Controls.Add(filterBar);

        var listCard = UiHelpers.CreatePanel("pnlAttendanceListCard");
        AppTheme.StyleCard(listCard);
        AppTheme.RoundPanelCorners(listCard);
        var dgvAttendanceList = UiHelpers.CreateGrid("dgvAttendanceList", DemoDataFactory.GetAttendanceList());
        ttAttendance.SetToolTip(dgvAttendanceList, "Grid có cột checkbox để backend xử lý điểm danh hàng loạt.");
        listCard.Controls.Add(dgvAttendanceList);

        root.Controls.Add(filterCard, 0, 0);
        root.Controls.Add(listCard, 0, 1);
        pnlModuleBody.Controls.Add(root);
    }
}

public sealed class FrmScoreEntry : ModuleFormBase
{
    private readonly ErrorProvider errScoreEntry;

    public FrmScoreEntry() : base("Nhập điểm")
    {
        errScoreEntry = new ErrorProvider { ContainerControl = this, BlinkStyle = ErrorBlinkStyle.NeverBlink };

        var root = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1, BackColor = Color.Transparent };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var filterCard = UiHelpers.CreatePanel("pnlScoreFilterCard");
        AppTheme.StyleCard(filterCard);
        AppTheme.RoundPanelCorners(filterCard);
        filterCard.Height = 92;
        filterCard.Padding = new Padding(16);
        var filterBar = new FlowLayoutPanel { Dock = DockStyle.Fill, WrapContents = false, BackColor = Color.Transparent };
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblScoreClass", "Lớp", UiHelpers.CreateComboBox("cboScoreClass", "ENG-A1-01", "ENG-IELTS-02")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblScoreType", "Loại điểm", UiHelpers.CreateComboBox("cboScoreType", "Giữa kỳ", "Cuối kỳ", "Thực hành")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblScoreExamDate", "Ngày nhập", UiHelpers.CreateDateTimePicker("dtpScoreExamDate")));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnSearchScore", "Xem danh sách"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnSaveScore", "Lưu điểm"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnExportScore", "Xuất bảng điểm", "secondary"));
        filterCard.Controls.Add(filterBar);

        var listCard = UiHelpers.CreatePanel("pnlScoreListCard");
        AppTheme.StyleCard(listCard);
        AppTheme.RoundPanelCorners(listCard);
        var dgvScoreEntryList = UiHelpers.CreateGrid("dgvScoreEntryList", DemoDataFactory.GetScoreList());
        listCard.Controls.Add(dgvScoreEntryList);

        root.Controls.Add(filterCard, 0, 0);
        root.Controls.Add(listCard, 0, 1);
        pnlModuleBody.Controls.Add(root);
    }
}
