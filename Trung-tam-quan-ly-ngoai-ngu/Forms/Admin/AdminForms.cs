using System.Windows.Forms.DataVisualization.Charting;

namespace Trung_tam_quan_ly_ngoai_ngu;

public sealed class FrmAdminDashboard : ShellFormBase
{
    public FrmAdminDashboard(string currentUserName)
        : base(
            "Dashboard quản trị",
            "Admin",
            currentUserName,
            new ShellChromeNames(
                "pnlSidebarAdmin",
                "pnlTopbarAdmin",
                "pnlContentHostAdmin",
                "lblCurrentRoleAdmin",
                "lblCurrentUserAdmin",
                "btnLogoutAdmin"))
    {
    }

    protected override IReadOnlyList<MenuDefinition> GetMenuDefinitions() =>
    [
        new("dashboard", "Dashboard quản trị", "btnMenuAdminDashboard"),
        new("systemMonitor", "Giám sát hệ thống", "btnMenuSystemMonitor"),
        new("accountManagement", "Tài khoản & phân quyền", "btnMenuAccountManagement"),
        new("adminReports", "Báo cáo thống kê", "btnMenuAdminReports")
    ];

    protected override Control BuildDashboardHome()
    {
        var root = new Panel { Dock = DockStyle.Fill, BackColor = AppTheme.Background };
        var title = UiHelpers.CreateLabel("lblAdminDashboardTitle", "Tổng quan quản trị", AppTheme.FontTitle, AppTheme.TextPrimary);
        title.Location = new Point(0, 0);
        root.Controls.Add(title);

        var kpiRow = new FlowLayoutPanel
        {
            Name = "pnlAdminKpiRow",
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            AutoSize = true,
            Location = new Point(0, 56),
            BackColor = Color.Transparent
        };
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlKpiTotalAccounts", "lblKpiTotalAccountsTitle", "lblKpiTotalAccountsValue", "Tổng tài khoản", "18", AppTheme.Accent));
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlKpiActiveClasses", "lblKpiActiveClassesTitle", "lblKpiActiveClassesValue", "Lớp đang mở", "18", AppTheme.Success));
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlKpiRevenue", "lblKpiRevenueTitle", "lblKpiRevenueValue", "Doanh thu đã thu", "286.500.000", AppTheme.Warning));
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlKpiDebtStudents", "lblKpiDebtStudentsTitle", "lblKpiDebtStudentsValue", "HV còn nợ", "27", AppTheme.Danger));
        root.Controls.Add(kpiRow);

        var bottomGrid = UiHelpers.CreateContentGrid("tblAdminDashboardContent", 44F, 56F);
        bottomGrid.Location = new Point(0, 188);
        bottomGrid.Size = new Size(1120, 430);

        var grpAdminTasks = UiHelpers.CreateGroupBox("grpAdminTasks", "Việc cần xử lý đầu ngày");
        var taskStack = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            BackColor = Color.Transparent
        };
        taskStack.Controls.Add(UiHelpers.CreateLabel("lblAdminTask01", "1. Kiểm tra số lớp gần đầy và lớp sắp khai giảng.", AppTheme.FontBody, AppTheme.TextMuted));
        taskStack.Controls.Add(UiHelpers.CreateLabel("lblAdminTask02", "2. Theo dõi công nợ và biên nhận lập trong ngày.", AppTheme.FontBody, AppTheme.TextMuted));
        taskStack.Controls.Add(UiHelpers.CreateLabel("lblAdminTask03", "3. Rà soát tài khoản bị khóa / mật khẩu mặc định.", AppTheme.FontBody, AppTheme.TextMuted));
        taskStack.Controls.Add(UiHelpers.CreateLabel("lblAdminTask04", "4. Xem nhanh báo cáo doanh thu để kiểm tra số liệu bất thường.", AppTheme.FontBody, AppTheme.TextMuted));
        var quickButtons = UiHelpers.CreateButtonBar("pnlAdminQuickButtons");
        var btnOpenSystemMonitor = UiHelpers.CreateButton("btnOpenSystemMonitor", "Mở giám sát");
        var btnOpenAccountManagement = UiHelpers.CreateButton("btnOpenAccountManagement", "Mở tài khoản", "secondary");
        var btnOpenAdminReports = UiHelpers.CreateButton("btnOpenAdminReports", "Mở báo cáo", "secondary");
        btnOpenSystemMonitor.Click += (_, _) =>
        {
            HighlightMenu("systemMonitor");
            UiHelpers.ShowChildForm(pnlContentHost, new FrmSystemMonitor());
        };
        btnOpenAccountManagement.Click += (_, _) =>
        {
            HighlightMenu("accountManagement");
            UiHelpers.ShowChildForm(pnlContentHost, new FrmAccountManagement());
        };
        btnOpenAdminReports.Click += (_, _) =>
        {
            HighlightMenu("adminReports");
            UiHelpers.ShowChildForm(pnlContentHost, new FrmAdminReports());
        };
        quickButtons.Controls.Add(btnOpenSystemMonitor);
        quickButtons.Controls.Add(btnOpenAccountManagement);
        quickButtons.Controls.Add(btnOpenAdminReports);
        taskStack.Controls.Add(quickButtons);
        grpAdminTasks.Controls.Add(taskStack);

        var warningsPanel = UiHelpers.CreatePanel("pnlAdminWarningsCard");
        AppTheme.StyleCard(warningsPanel);
        AppTheme.RoundPanelCorners(warningsPanel);
        warningsPanel.Dock = DockStyle.Fill;
        var warningTitle = UiHelpers.CreateLabel("lblAdminWarningsTitle", "Cảnh báo nhanh", AppTheme.FontSection, AppTheme.TextPrimary);
        warningTitle.Dock = DockStyle.Top;
        var dgvAdminWarnings = UiHelpers.CreateGrid("dgvAdminWarnings", DemoDataFactory.GetAdminWarnings());
        dgvAdminWarnings.Dock = DockStyle.Fill;
        warningsPanel.Controls.Add(dgvAdminWarnings);
        warningsPanel.Controls.Add(warningTitle);

        bottomGrid.Controls.Add(grpAdminTasks, 0, 0);
        bottomGrid.Controls.Add(warningsPanel, 1, 0);
        root.Controls.Add(bottomGrid);
        return root;
    }

    protected override Form? CreateModuleForm(string key) => key switch
    {
        "systemMonitor" => new FrmSystemMonitor(),
        "accountManagement" => new FrmAccountManagement(),
        "adminReports" => new FrmAdminReports(),
        _ => null
    };
}

public sealed class FrmSystemMonitor : ModuleFormBase
{
    public FrmSystemMonitor() : base("Giám sát hệ thống")
    {
        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 3,
            ColumnCount = 1,
            BackColor = Color.Transparent
        };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var filterCard = UiHelpers.CreatePanel("pnlSystemMonitorFilterCard");
        AppTheme.StyleCard(filterCard);
        AppTheme.RoundPanelCorners(filterCard);
        filterCard.Height = 92;
        filterCard.Dock = DockStyle.Top;
        filterCard.Padding = new Padding(16);

        var filterBar = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            BackColor = Color.Transparent
        };
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblMonitorPeriod", "Kỳ xem", UiHelpers.CreateComboBox("cboMonitorPeriod", "Hôm nay", "7 ngày", "30 ngày")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblMonitorViewType", "Loại theo dõi", UiHelpers.CreateComboBox("cboMonitorViewType", "Tổng quan", "Dữ liệu vận hành", "Cảnh báo")));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnViewMonitor", "Xem dữ liệu"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnQuickExportMonitor", "Xuất nhanh", "secondary"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnOpenAdminReports", "Mở báo cáo", "secondary"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnBackAdminDashboard", "Quay lại", "secondary"));
        filterCard.Controls.Add(filterBar);

        var kpiRow = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            AutoSize = true,
            BackColor = Color.Transparent
        };
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlMonitorStudentCount", "lblMonitorStudentCountTitle", "lblMonitorStudentCountValue", "Học viên", "245", AppTheme.Accent));
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlMonitorEnrollmentCount", "lblMonitorEnrollmentCountTitle", "lblMonitorEnrollmentCountValue", "Đăng ký hoạt động", "126", AppTheme.Success));
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlMonitorReceiptCount", "lblMonitorReceiptCountTitle", "lblMonitorReceiptCountValue", "Biên nhận", "47", AppTheme.Warning));
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlMonitorDebtTotal", "lblMonitorDebtTotalTitle", "lblMonitorDebtTotalValue", "Tổng công nợ", "54.300.000", AppTheme.Danger));

        var contentGrid = UiHelpers.CreateContentGrid("tblSystemMonitorContent", 60F, 40F);
        var leftCard = UiHelpers.CreatePanel("pnlSystemMonitorLeft");
        var rightCard = UiHelpers.CreatePanel("pnlSystemMonitorRight");
        AppTheme.StyleCard(leftCard);
        AppTheme.StyleCard(rightCard);
        AppTheme.RoundPanelCorners(leftCard);
        AppTheme.RoundPanelCorners(rightCard);
        var dgvMonitorActivity = UiHelpers.CreateGrid("dgvMonitorActivity", DemoDataFactory.GetMonitorActivity());
        var dgvMonitorSource = UiHelpers.CreateGrid("dgvMonitorSource", DemoDataFactory.GetMonitorSource());
        leftCard.Controls.Add(dgvMonitorActivity);
        rightCard.Controls.Add(dgvMonitorSource);
        contentGrid.Controls.Add(leftCard, 0, 0);
        contentGrid.Controls.Add(rightCard, 1, 0);

        root.Controls.Add(filterCard, 0, 0);
        root.Controls.Add(kpiRow, 0, 1);
        root.Controls.Add(contentGrid, 0, 2);
        pnlModuleBody.Controls.Add(root);
    }
}

public sealed class FrmAccountManagement : ModuleFormBase
{
    private readonly ErrorProvider errAccount;

    public FrmAccountManagement() : base("Tài khoản và phân quyền")
    {
        errAccount = new ErrorProvider { ContainerControl = this, BlinkStyle = ErrorBlinkStyle.NeverBlink };

        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 2,
            ColumnCount = 1,
            BackColor = Color.Transparent
        };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var filterCard = UiHelpers.CreatePanel("pnlAccountFilterCard");
        AppTheme.StyleCard(filterCard);
        AppTheme.RoundPanelCorners(filterCard);
        filterCard.Height = 90;
        filterCard.Padding = new Padding(16);
        var filterBar = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            BackColor = Color.Transparent
        };
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblAccountKeyword", "Từ khóa", UiHelpers.CreateTextBox("txtAccountKeyword", "Tìm username / display name")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblAccountRoleFilter", "Vai trò", UiHelpers.CreateComboBox("cboAccountRoleFilter", "Tất cả", "Admin", "Staff", "Teacher")));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnSearchAccount", "Tìm"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnRefreshAccount", "Làm mới", "secondary"));
        filterCard.Controls.Add(filterBar);

        var contentGrid = UiHelpers.CreateContentGrid("tblAccountContent", 52F, 48F);
        var leftCard = UiHelpers.CreatePanel("pnlAccountListCard");
        AppTheme.StyleCard(leftCard);
        AppTheme.RoundPanelCorners(leftCard);
        var dgvAccountList = UiHelpers.CreateGrid("dgvAccountList", DemoDataFactory.GetAccountList());
        leftCard.Controls.Add(dgvAccountList);

        var rightLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 3,
            ColumnCount = 1,
            BackColor = Color.Transparent
        };
        rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 58F));
        rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
        rightLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        var grpAccountInfo = UiHelpers.CreateGroupBox("grpAccountInfo", "Thông tin tài khoản");
        var accountFields = UiHelpers.CreateFieldGrid("tblAccountInfoFields", 4, 2);
        accountFields.Controls.Add(UiHelpers.CreateLabeledField("lblUsername", "Username", UiHelpers.CreateTextBox("txtUsername")), 0, 0);
        accountFields.Controls.Add(UiHelpers.CreateLabeledField("lblPassword", "Mật khẩu", UiHelpers.CreateTextBox("txtPassword")), 1, 0);
        accountFields.Controls.Add(UiHelpers.CreateLabeledField("lblDisplayName", "Tên hiển thị", UiHelpers.CreateTextBox("txtDisplayName")), 0, 1);
        accountFields.Controls.Add(UiHelpers.CreateLabeledField("lblAccountRole", "Vai trò", UiHelpers.CreateComboBox("cboAccountRole", "Admin", "Staff", "Teacher")), 1, 1);
        accountFields.Controls.Add(UiHelpers.CreateLabeledField("lblAccountStatus", "Trạng thái", UiHelpers.CreateComboBox("cboAccountStatus", "Active", "Inactive")), 0, 2);
        grpAccountInfo.Controls.Add(accountFields);

        var grpPermissionRule = UiHelpers.CreateGroupBox("grpPermissionRule", "Quy tắc phân quyền");
        var permissionStack = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            BackColor = Color.Transparent
        };
        permissionStack.Controls.Add(UiHelpers.CreateLabel("lblRuleAdmin", "Admin: xem giám sát, tài khoản, báo cáo.", AppTheme.FontBody, AppTheme.TextMuted));
        permissionStack.Controls.Add(UiHelpers.CreateLabel("lblRuleStaff", "Staff: vận hành học viên, giáo viên, khóa, lớp, ghi danh, học phí, công nợ.", AppTheme.FontBody, AppTheme.TextMuted));
        permissionStack.Controls.Add(UiHelpers.CreateLabel("lblRuleTeacher", "Teacher: chỉ thao tác lớp đang dạy, danh sách học viên, điểm danh, nhập điểm.", AppTheme.FontBody, AppTheme.TextMuted));
        grpPermissionRule.Controls.Add(permissionStack);

        var actionBar = UiHelpers.CreateButtonBar("pnlAccountActions");
        actionBar.Controls.Add(UiHelpers.CreateButton("btnCreateAccount", "Tạo mới"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnSaveAccount", "Lưu"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnToggleAccountStatus", "Khóa / Mở", "secondary"));
        actionBar.Controls.Add(UiHelpers.CreateButton("btnResetPassword", "Reset mật khẩu", "danger"));

        rightLayout.Controls.Add(grpAccountInfo, 0, 0);
        rightLayout.Controls.Add(grpPermissionRule, 0, 1);
        rightLayout.Controls.Add(actionBar, 0, 2);

        contentGrid.Controls.Add(leftCard, 0, 0);
        contentGrid.Controls.Add(rightLayout, 1, 0);

        root.Controls.Add(filterCard, 0, 0);
        root.Controls.Add(contentGrid, 0, 1);
        pnlModuleBody.Controls.Add(root);
    }
}

public sealed class FrmAdminReports : ModuleFormBase
{
    public FrmAdminReports() : base("Báo cáo thống kê")
    {
        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 3,
            ColumnCount = 1,
            BackColor = Color.Transparent
        };
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var filterCard = UiHelpers.CreatePanel("pnlAdminReportFilterCard");
        AppTheme.StyleCard(filterCard);
        AppTheme.RoundPanelCorners(filterCard);
        filterCard.Height = 96;
        filterCard.Padding = new Padding(16);
        var filterBar = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            BackColor = Color.Transparent
        };
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblReportType", "Loại báo cáo", UiHelpers.CreateComboBox("cboReportType", "Doanh thu", "Ghi danh", "Công nợ")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblFromDate", "Từ ngày", UiHelpers.CreateDateTimePicker("dtpReportFromDate")));
        filterBar.Controls.Add(UiHelpers.CreateLabeledField("lblToDate", "Đến ngày", UiHelpers.CreateDateTimePicker("dtpReportToDate")));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnViewReport", "Xem báo cáo"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnExportReportExcel", "Xuất Excel", "secondary"));
        filterBar.Controls.Add(UiHelpers.CreateButton("btnExportReportPdf", "Xuất PDF", "secondary"));
        filterCard.Controls.Add(filterBar);

        var kpiRow = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            AutoSize = true,
            BackColor = Color.Transparent
        };
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlReportRevenue", "lblReportRevenueTitle", "lblReportRevenueValue", "Doanh thu", "286.500.000", AppTheme.Accent));
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlReportEnrollment", "lblReportEnrollmentTitle", "lblReportEnrollmentValue", "Ghi danh", "152", AppTheme.Success));
        kpiRow.Controls.Add(UiHelpers.CreateMetricCard("pnlReportClassCount", "lblReportClassCountTitle", "lblReportClassCountValue", "Lớp đang mở", "18", AppTheme.Warning));

        var contentGrid = UiHelpers.CreateContentGrid("tblAdminReportContent", 40F, 60F);
        var chartCard = UiHelpers.CreatePanel("pnlAdminReportChartCard");
        AppTheme.StyleCard(chartCard);
        AppTheme.RoundPanelCorners(chartCard);
        var chtAdminRevenue = UiHelpers.CreateChart("chtAdminRevenue");
        UiHelpers.BindRevenueSeries(chtAdminRevenue);
        chartCard.Controls.Add(chtAdminRevenue);

        var detailCard = UiHelpers.CreatePanel("pnlAdminReportDetailCard");
        AppTheme.StyleCard(detailCard);
        AppTheme.RoundPanelCorners(detailCard);
        var dgvAdminReportDetail = UiHelpers.CreateGrid("dgvAdminReportDetail", DemoDataFactory.GetReportDetail());
        detailCard.Controls.Add(dgvAdminReportDetail);

        contentGrid.Controls.Add(chartCard, 0, 0);
        contentGrid.Controls.Add(detailCard, 1, 0);

        root.Controls.Add(filterCard, 0, 0);
        root.Controls.Add(kpiRow, 0, 1);
        root.Controls.Add(contentGrid, 0, 2);
        pnlModuleBody.Controls.Add(root);
    }
}
