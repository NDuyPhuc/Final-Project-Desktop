using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmStaffDashboard : Form
{
    private readonly string _currentUserName;
    private bool _isApplyingResponsiveLayout;

    public FrmStaffDashboard() : this("Admin Staff")
    {
    }

    public FrmStaffDashboard(string currentUserName)
    {
        _currentUserName = currentUserName;
        InitializeComponent();
        FormHostHelpers.ConfigureShellSurface(this, "Dashboard vận hành");
        ApplyShellStyling();
        BindDashboardData();
        BuildTaskCards();
        BuildWeeklyProgressGrid();
        ShowDashboardHome();
    }

    private void ApplyShellStyling()
    {
        BackColor = Color.FromArgb(237, 247, 255);
        pnlSidebarStaff.Width = FormHostHelpers.ScaleForDpi(this, 248);
        pnlTopbarStaff.Height = FormHostHelpers.ScaleForDpi(this, 98);
        pnlContentHostStaff.Padding = FormHostHelpers.ScalePadding(this, new Padding(20, 0, 20, 20));
        pnlDashboardHome.BackColor = Color.FromArgb(237, 247, 255);
        pnlContentHostStaff.BackColor = Color.FromArgb(237, 247, 255);
        pnlTopbarStaff.BackColor = Color.FromArgb(237, 247, 255);
        pnlSidebarStaff.BackColor = Color.FromArgb(226, 243, 255);
        pnlSidebarFooterStaff.Height = FormHostHelpers.ScaleForDpi(this, 54);
        pnlSidebarFooterStaff.Padding = FormHostHelpers.ScalePadding(this, new Padding(18, 0, 18, 0));

        lblCurrentUserStaff.Text = _currentUserName;
        lblCurrentRoleStaff.Text = "Linguistic Architect CMS";
        lblTopbarAvatarStaff.Text = string.Concat(_currentUserName.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(part => part[0])).PadRight(2).Substring(0, 2).ToUpperInvariant();
        lblSidebarBrandLine1.Text = "LINGUISTIC";
        lblSidebarBrandLine2.Text = "ARCHITECT";
        lblSidebarBrandSubtitle.Text = "ĐIỀU PHỐI VẬN HÀNH";
        btnMenuStaffDashboard.Text = "    BẢNG ĐIỀU KHIỂN";
        btnMenuStudentManagement.Text = "    HỌC VIÊN";
        btnMenuTeacherManagement.Text = "    GIÁO VIÊN";
        btnMenuCourseManagement.Text = "    KHÓA HỌC";
        btnMenuClassManagement.Text = "    LỚP HỌC";
        btnMenuEnrollment.Text = "    GHI DANH";
        btnMenuTuitionReceipt.Text = "    THU HỌC PHÍ";
        btnMenuDebtTracking.Text = "    CÔNG NỢ";
        lblSidebarBrandLine1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblSidebarBrandLine2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTopbarTitleStaff.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblRecentReceiptTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblStaffActionTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblWeeklyProgressTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);

        foreach (var panel in new[] { pnlNewStudentsToday, pnlAvailableClasses, pnlTodayReceipts, pnlDebtStudents, pnlRecentReceiptCard, pnlStaffActionCard, pnlWeeklyProgressCard })
        {
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
        }

        pnlRecentReceiptHeader.BackColor = Color.FromArgb(215, 238, 252);
        pnlStaffActionHeader.BackColor = Color.FromArgb(215, 238, 252);
        pnlLegendDone.BackColor = Color.FromArgb(18, 120, 118);
        pnlLegendRemaining.BackColor = Color.FromArgb(198, 225, 244);

        pnlNewStudentsAccent.BackColor = Color.FromArgb(10, 73, 146);
        pnlAvailableClassesAccent.BackColor = Color.FromArgb(20, 128, 120);
        pnlTodayReceiptsAccent.BackColor = Color.FromArgb(20, 128, 120);
        pnlDebtStudentsAccent.BackColor = Color.FromArgb(204, 24, 31);

        lblDebtStudentsValue.ForeColor = Color.FromArgb(204, 24, 31);
        lblNewStudentsTodayValue.ForeColor = Color.FromArgb(10, 73, 146);
        lblAvailableClassesValue.ForeColor = Color.FromArgb(12, 26, 40);
        lblTodayReceiptsValue.ForeColor = Color.FromArgb(12, 26, 40);

        StyleBadge(lblNewStudentsTodayBadge, Color.FromArgb(147, 239, 231), Color.FromArgb(8, 95, 96));
        StyleBadge(lblAvailableClassesBadge, Color.FromArgb(224, 239, 248), Color.FromArgb(70, 84, 102));
        StyleBadge(lblTodayReceiptsBadge, Color.FromArgb(147, 239, 231), Color.FromArgb(8, 95, 96));
        StyleBadge(lblDebtStudentsBadge, Color.FromArgb(255, 222, 222), Color.FromArgb(181, 33, 39));

        dgvRecentReceipts.BorderStyle = BorderStyle.None;
        AppTheme.StyleGrid(dgvRecentReceipts);
        dgvRecentReceipts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(215, 238, 252);
        dgvRecentReceipts.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        dgvRecentReceipts.RowsDefaultCellStyle.BackColor = Color.White;
        dgvRecentReceipts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 251, 255);
        dgvRecentReceipts.DefaultCellStyle.Padding = FormHostHelpers.ScalePadding(this, new Padding(8, 10, 8, 10));
        dgvRecentReceipts.RowTemplate.Height = FormHostHelpers.ScaleForDpi(this, 68);

        StyleTopbarActionButton(btnTopbarNotifyStaff, "Thông tin", 124);
        StyleTopbarActionButton(btnTopbarSettingsStaff, "Cài đặt", 104);
        StyleTopbarActionButton(btnTopbarHelpStaff, "Hỗ trợ", 76);

        pnlTopbarAvatarStaff.BackColor = Color.FromArgb(24, 33, 47);
        lblTopbarAvatarStaff.ForeColor = Color.White;
        pnlDashboardHome.AutoSize = false;
        pnlDashboardHome.Dock = DockStyle.Top;
        pnlDashboardHome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        pnlDashboardHome.Margin = Padding.Empty;
        pnlDashboardHome.Padding = Padding.Empty;
        tblStaffDashboardRoot.AutoSize = false;
        tblStaffDashboardRoot.Dock = DockStyle.Fill;
        tblStaffDashboardRoot.Margin = Padding.Empty;

        btnAddTaskStaff.BackColor = Color.FromArgb(10, 73, 146);
        btnAddTaskStaff.ForeColor = Color.White;
        btnAddTaskStaff.FlatStyle = FlatStyle.Flat;
        btnAddTaskStaff.FlatAppearance.BorderSize = 0;
        btnAddTaskStaff.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);

        StyleSidebarButton(btnMenuStaffDashboard, true);
        StyleSidebarButton(btnMenuStudentManagement, false);
        StyleSidebarButton(btnMenuTeacherManagement, false);
        StyleSidebarButton(btnMenuCourseManagement, false);
        StyleSidebarButton(btnMenuClassManagement, false);
        StyleSidebarButton(btnMenuEnrollment, false);
        StyleSidebarButton(btnMenuTuitionReceipt, false);
        StyleSidebarButton(btnMenuDebtTracking, false);

        AppTheme.StyleDangerButton(btnLogoutStaff);
        btnLogoutStaff.Dock = DockStyle.Fill;
        btnLogoutStaff.Text = "Đăng xuất";
        btnLogoutStaff.TextAlign = ContentAlignment.MiddleCenter;
        btnLogoutStaff.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

        btnLogoutStaff.Click += (_, _) => FormHostHelpers.OpenLoginAndClose(this);

        var menuButtons = new[] { btnMenuStaffDashboard, btnMenuStudentManagement, btnMenuTeacherManagement, btnMenuCourseManagement, btnMenuClassManagement, btnMenuEnrollment, btnMenuTuitionReceipt, btnMenuDebtTracking };
        btnMenuStaffDashboard.Click += (_, _) => ShowDashboardHome();
        btnMenuStudentManagement.Click += (_, _) => OpenModule(() => new FrmStudentManagement(), btnMenuStudentManagement, menuButtons);
        btnMenuTeacherManagement.Click += (_, _) => OpenModule(() => new FrmTeacherManagement(), btnMenuTeacherManagement, menuButtons);
        btnMenuCourseManagement.Click += (_, _) => OpenModule(() => new FrmCourseManagement(), btnMenuCourseManagement, menuButtons);
        btnMenuClassManagement.Click += (_, _) => OpenModule(() => new FrmClassManagement(), btnMenuClassManagement, menuButtons);
        btnMenuEnrollment.Click += (_, _) => OpenModule(() => new FrmEnrollment(), btnMenuEnrollment, menuButtons);
        btnMenuTuitionReceipt.Click += (_, _) => OpenModule(() => new FrmTuitionReceipt(), btnMenuTuitionReceipt, menuButtons);
        btnMenuDebtTracking.Click += (_, _) => OpenModule(() => new FrmDebtTracking(), btnMenuDebtTracking, menuButtons);

        pnlNewStudentsToday.Resize += (_, _) => LayoutKpiCard(pnlNewStudentsToday, lblNewStudentsTodayTitle, lblNewStudentsTodayValue, lblNewStudentsTodayBadge);
        pnlAvailableClasses.Resize += (_, _) => LayoutKpiCard(pnlAvailableClasses, lblAvailableClassesTitle, lblAvailableClassesValue, lblAvailableClassesBadge);
        pnlTodayReceipts.Resize += (_, _) => LayoutKpiCard(pnlTodayReceipts, lblTodayReceiptsTitle, lblTodayReceiptsValue, lblTodayReceiptsBadge);
        pnlDebtStudents.Resize += (_, _) => LayoutKpiCard(pnlDebtStudents, lblDebtStudentsTitle, lblDebtStudentsValue, lblDebtStudentsBadge);
        Resize += (_, _) => ApplyResponsiveLayout();
        ApplyResponsiveLayout();
    }

    private void BindDashboardData()
    {
        var stats = AppRuntime.DataService.GetStaffDashboardStats();
        lblNewStudentsTodayValue.Text = stats.NewStudentsThisMonth.ToString();
        lblAvailableClassesValue.Text = stats.TotalActiveClasses.ToString();
        lblTodayReceiptsValue.Text = stats.TotalReceipts.ToString();
        lblDebtStudentsValue.Text = AppRuntime.DataService.GetDebtList().Rows.Count.ToString();
        dgvRecentReceipts.DataSource = AppRuntime.DataService.GetRecentReceipts();

        if (dgvRecentReceipts.Columns.Count > 0)
        {
            dgvRecentReceipts.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRecentReceipts.Columns[1].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvRecentReceipts.Columns[3].DefaultCellStyle.ForeColor = Color.FromArgb(10, 73, 146);
            dgvRecentReceipts.Columns[3].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvRecentReceipts.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }

    private void ShowDashboardHome()
    {
        var menuButtons = new[] { btnMenuStaffDashboard, btnMenuStudentManagement, btnMenuTeacherManagement, btnMenuCourseManagement, btnMenuClassManagement, btnMenuEnrollment, btnMenuTuitionReceipt, btnMenuDebtTracking };
        lblTopbarTitleStaff.Text = GetMenuCaption(btnMenuStaffDashboard);
        FormHostHelpers.LogUi("StaffDashboard:ShowDashboardHome:start");
        pnlContentHostStaff.SuspendLayout();
        try
        {
            pnlContentHostStaff.AutoScroll = true;
            pnlDashboardHome.Dock = DockStyle.Top;
            pnlDashboardHome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlDashboardHome.Location = Point.Empty;
            pnlContentHostStaff.Controls.Clear();
            pnlContentHostStaff.Controls.Add(pnlDashboardHome);
            SyncDashboardHomeHeight();
        }
        finally
        {
            pnlContentHostStaff.ResumeLayout(true);
        }

        FormHostHelpers.SetActiveMenu(btnMenuStaffDashboard, menuButtons);
        StyleSidebarButton(btnMenuStaffDashboard, true);
        FormHostHelpers.LogUi("StaffDashboard:ShowDashboardHome:done");
    }

    private void OpenModule(Func<Form> moduleFactory, Button activeButton, Button[] allButtons)
    {
        lblTopbarTitleStaff.Text = GetMenuCaption(activeButton);
        FormHostHelpers.LogUi($"StaffDashboard:OpenModule:start:{activeButton.Name}");
        pnlContentHostStaff.AutoScroll = false;

        try
        {
            using var _ = new CursorScope(Cursors.WaitCursor);
            var moduleForm = moduleFactory();
            FormHostHelpers.OpenChildForm(pnlContentHostStaff, moduleForm);
            FormHostHelpers.SetActiveMenu(activeButton, allButtons);
            FormHostHelpers.LogUi($"StaffDashboard:OpenModule:done:{activeButton.Name}:{moduleForm.GetType().Name}");
        }
        catch (Exception exception)
        {
            FormHostHelpers.LogUi($"StaffDashboard:OpenModule:error:{activeButton.Name}:{exception}");
            throw;
        }
    }

    private static string GetMenuCaption(Button button)
    {
        return button.Text.Replace("    ", string.Empty).Trim();
    }

    private void BuildTaskCards()
    {
        flpStaffTaskList.Controls.Clear();

        foreach (var task in GetTaskItems())
        {
            var card = new Panel
            {
                Width = Math.Max(FormHostHelpers.ScaleForDpi(this, 260), flpStaffTaskList.ClientSize.Width - FormHostHelpers.ScaleForDpi(this, 56)),
                Height = FormHostHelpers.ScaleForDpi(this, 150),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = FormHostHelpers.ScalePadding(this, new Padding(0, 0, 0, 18))
            };

            var chk = new CheckBox
            {
                Location = new Point(FormHostHelpers.ScaleForDpi(this, 20), FormHostHelpers.ScaleForDpi(this, 28)),
                Size = FormHostHelpers.ScaleSize(this, new Size(28, 28))
            };

            var title = new Label
            {
                AutoSize = false,
                Location = new Point(FormHostHelpers.ScaleForDpi(this, 64), FormHostHelpers.ScaleForDpi(this, 22)),
                Size = new Size(card.Width - FormHostHelpers.ScaleForDpi(this, 92), FormHostHelpers.ScaleForDpi(this, 32)),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Text = task.Title
            };

            var body = new Label
            {
                AutoSize = false,
                Location = new Point(FormHostHelpers.ScaleForDpi(this, 64), FormHostHelpers.ScaleForDpi(this, 58)),
                Size = new Size(card.Width - FormHostHelpers.ScaleForDpi(this, 92), FormHostHelpers.ScaleForDpi(this, 46)),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.FromArgb(72, 80, 94),
                Text = task.Description
            };

            var badge = new Label
            {
                AutoSize = true,
                Location = new Point(FormHostHelpers.ScaleForDpi(this, 64), FormHostHelpers.ScaleForDpi(this, 112)),
                Padding = FormHostHelpers.ScalePadding(this, new Padding(10, 4, 10, 4)),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Text = task.Priority
            };

            var due = new Label
            {
                AutoSize = true,
                Location = new Point(FormHostHelpers.ScaleForDpi(this, 64) + badge.PreferredWidth + FormHostHelpers.ScaleForDpi(this, 12), FormHostHelpers.ScaleForDpi(this, 116)),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(85, 92, 104),
                Text = task.Deadline
            };

            StylePriorityBadge(badge, task.PriorityType);

            card.Controls.Add(chk);
            card.Controls.Add(title);
            card.Controls.Add(body);
            card.Controls.Add(badge);
            card.Controls.Add(due);
            flpStaffTaskList.Controls.Add(card);
        }

        flpStaffTaskList.Resize += (_, _) =>
        {
            foreach (Control control in flpStaffTaskList.Controls)
            {
                control.Width = Math.Max(FormHostHelpers.ScaleForDpi(this, 260), flpStaffTaskList.ClientSize.Width - FormHostHelpers.ScaleForDpi(this, 56));
            }
        };

        flpStaffTaskList.Padding = FormHostHelpers.ScalePadding(this, new Padding(24, 28, 24, 28));
    }

    private void BuildWeeklyProgressGrid()
    {
        flpWeeklyProgressGrid.Controls.Clear();

        const int total = 60;
        const int done = 38;

        for (var index = 0; index < total; index++)
        {
            flpWeeklyProgressGrid.Controls.Add(new Panel
            {
                BackColor = index < done ? Color.FromArgb(18, 120, 118) : Color.FromArgb(198, 225, 244),
                Size = FormHostHelpers.ScaleSize(this, new Size(40, 40)),
                Margin = FormHostHelpers.ScalePadding(this, new Padding(8))
            });
        }

        lblWeeklyProgressSummary.Text = $"HIỆU SUẤT VẬN HÀNH: {done}/{total} CÔNG VIỆC HOÀN THÀNH ({Math.Round(done * 100d / total):0}%)";
    }

    private void ApplyResponsiveLayout()
    {
        if (_isApplyingResponsiveLayout)
        {
            return;
        }

        if (!pnlContentHostStaff.Controls.Contains(pnlDashboardHome))
        {
            return;
        }

        var contentWidth = pnlContentHostStaff.ClientSize.Width;
        if (contentWidth <= 0)
        {
            return;
        }

        _isApplyingResponsiveLayout = true;

        try
        {
            var compact = contentWidth < FormHostHelpers.ScaleForDpi(this, 1220);
            var veryCompact = contentWidth < FormHostHelpers.ScaleForDpi(this, 980);
            var ultraCompact = contentWidth < FormHostHelpers.ScaleForDpi(this, 760);

            tblStaffKpi.SuspendLayout();
            tblStaffMain.SuspendLayout();
            tblStaffDashboardRoot.SuspendLayout();
            tblTopbarStaff.SuspendLayout();

            pnlSidebarStaff.Width = contentWidth < FormHostHelpers.ScaleForDpi(this, 820)
                ? FormHostHelpers.ScaleForDpi(this, 220)
                : FormHostHelpers.ScaleForDpi(this, 248);
            pnlTopbarStaff.Height = ultraCompact
                ? FormHostHelpers.ScaleForDpi(this, 152)
                : veryCompact
                    ? FormHostHelpers.ScaleForDpi(this, 142)
                    : FormHostHelpers.ScaleForDpi(this, 98);
            pnlContentHostStaff.Padding = contentWidth < FormHostHelpers.ScaleForDpi(this, 820)
                ? FormHostHelpers.ScalePadding(this, new Padding(14, 0, 14, 14))
                : FormHostHelpers.ScalePadding(this, new Padding(20, 0, 20, 20));
            pnlSidebarFooterStaff.Height = FormHostHelpers.ScaleForDpi(this, 54);
            lblCurrentUserStaff.Font = new Font("Segoe UI", ultraCompact ? 10.5F : 11F, FontStyle.Bold);
            lblCurrentRoleStaff.Font = new Font("Segoe UI", ultraCompact ? 8.5F : 10F, FontStyle.Regular);

            foreach (var button in new[] { btnMenuStaffDashboard, btnMenuStudentManagement, btnMenuTeacherManagement, btnMenuCourseManagement, btnMenuClassManagement, btnMenuEnrollment, btnMenuTuitionReceipt, btnMenuDebtTracking })
            {
                button.Width = flpSidebarMenuStaff.ClientSize.Width;
            }

            if (ultraCompact)
            {
            tblStaffDashboardRoot.RowStyles.Clear();
            tblStaffDashboardRoot.RowCount = 3;
            tblStaffDashboardRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 540F));
            tblStaffDashboardRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 1040F));
            tblStaffDashboardRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 500F));

            tblStaffKpi.ColumnCount = 1;
            tblStaffKpi.RowCount = 4;
            tblStaffKpi.ColumnStyles.Clear();
            tblStaffKpi.RowStyles.Clear();
            tblStaffKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblStaffKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 126F));
            tblStaffKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 126F));
            tblStaffKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 126F));
            tblStaffKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 126F));

            SetGridPosition(pnlNewStudentsToday, 0, 0, new Padding(0, 0, 0, 12));
            SetGridPosition(pnlAvailableClasses, 0, 1, new Padding(0, 0, 0, 12));
            SetGridPosition(pnlTodayReceipts, 0, 2, new Padding(0, 0, 0, 12));
            SetGridPosition(pnlDebtStudents, 0, 3, Padding.Empty);

            tblStaffMain.ColumnCount = 1;
            tblStaffMain.RowCount = 2;
            tblStaffMain.ColumnStyles.Clear();
            tblStaffMain.RowStyles.Clear();
            tblStaffMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblStaffMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 560F));
            tblStaffMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 540F));
            tblStaffMain.SetColumn(pnlRecentReceiptCard, 0);
            tblStaffMain.SetRow(pnlRecentReceiptCard, 0);
            tblStaffMain.SetColumn(pnlStaffActionCard, 0);
            tblStaffMain.SetRow(pnlStaffActionCard, 1);
            pnlRecentReceiptCard.Margin = new Padding(0, 0, 0, 20);
            pnlStaffActionCard.Margin = Padding.Empty;
            pnlStaffActionHeader.Height = 74;
            pnlStaffActionFooter.Height = 88;

            tblTopbarStaff.RowCount = 3;
            tblTopbarStaff.RowStyles.Clear();
            tblTopbarStaff.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tblTopbarStaff.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblTopbarStaff.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tblTopbarStaff.ColumnStyles[1].Width = 0F;
            tblTopbarStaff.ColumnStyles[2].Width = 0F;
            tblTopbarStaff.SetColumn(lblTopbarTitleStaff, 0);
            tblTopbarStaff.SetRow(lblTopbarTitleStaff, 0);
            tblTopbarStaff.SetColumnSpan(lblTopbarTitleStaff, 3);
            tblTopbarStaff.SetColumn(flpTopbarActionsStaff, 0);
            tblTopbarStaff.SetRow(flpTopbarActionsStaff, 1);
            tblTopbarStaff.SetColumnSpan(flpTopbarActionsStaff, 3);
            tblTopbarStaff.SetColumn(pnlTopbarProfileStaff, 0);
            tblTopbarStaff.SetRow(pnlTopbarProfileStaff, 2);
            tblTopbarStaff.SetColumnSpan(pnlTopbarProfileStaff, 3);
            flpTopbarActionsStaff.Padding = new Padding(0, 4, 0, 0);
            flpTopbarActionsStaff.WrapContents = true;
            btnTopbarNotifyStaff.Text = "Thông tin";
            btnTopbarSettingsStaff.Text = "Cài đặt";
            btnTopbarHelpStaff.Text = "Hỗ trợ";
            btnTopbarNotifyStaff.Width = 124;
            btnTopbarSettingsStaff.Width = 104;
            btnTopbarHelpStaff.Width = 76;
            lblTopbarTitleStaff.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            }
            else if (compact)
            {
            tblStaffDashboardRoot.RowStyles.Clear();
            tblStaffDashboardRoot.RowCount = 3;
            tblStaffDashboardRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 352F));
            tblStaffDashboardRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 1040F));
            tblStaffDashboardRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 500F));

            tblStaffKpi.ColumnCount = 2;
            tblStaffKpi.RowCount = 2;
            tblStaffKpi.ColumnStyles.Clear();
            tblStaffKpi.RowStyles.Clear();
            tblStaffKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblStaffKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblStaffKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tblStaffKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));

            SetGridPosition(pnlNewStudentsToday, 0, 0, new Padding(0, 0, 12, 12));
            SetGridPosition(pnlAvailableClasses, 1, 0, new Padding(0, 0, 0, 12));
            SetGridPosition(pnlTodayReceipts, 0, 1, new Padding(0, 0, 12, 0));
            SetGridPosition(pnlDebtStudents, 1, 1, Padding.Empty);

            tblStaffMain.ColumnCount = 1;
            tblStaffMain.RowCount = 2;
            tblStaffMain.ColumnStyles.Clear();
            tblStaffMain.RowStyles.Clear();
            tblStaffMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblStaffMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 540F));
            tblStaffMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 540F));
            tblStaffMain.Controls.SetChildIndex(pnlRecentReceiptCard, 0);
            tblStaffMain.Controls.SetChildIndex(pnlStaffActionCard, 1);
            tblStaffMain.SetColumn(pnlRecentReceiptCard, 0);
            tblStaffMain.SetRow(pnlRecentReceiptCard, 0);
            tblStaffMain.SetColumn(pnlStaffActionCard, 0);
            tblStaffMain.SetRow(pnlStaffActionCard, 1);
            pnlRecentReceiptCard.Margin = new Padding(0, 0, 0, 20);
            pnlStaffActionCard.Margin = Padding.Empty;
            pnlStaffActionHeader.Height = 74;
            pnlStaffActionFooter.Height = 88;

            tblTopbarStaff.RowCount = 2;
            tblTopbarStaff.RowStyles.Clear();
            tblTopbarStaff.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tblTopbarStaff.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tblTopbarStaff.SetColumnSpan(lblTopbarTitleStaff, 3);
            tblTopbarStaff.SetColumn(lblTopbarTitleStaff, 0);
            tblTopbarStaff.SetRow(lblTopbarTitleStaff, 0);
            tblTopbarStaff.SetColumn(flpTopbarActionsStaff, 1);
            tblTopbarStaff.SetRow(flpTopbarActionsStaff, 1);
            tblTopbarStaff.SetColumn(pnlTopbarProfileStaff, 2);
            tblTopbarStaff.SetRow(pnlTopbarProfileStaff, 1);
            tblTopbarStaff.ColumnStyles[1].Width = 276F;
            tblTopbarStaff.ColumnStyles[2].Width = 252F;
            flpTopbarActionsStaff.Padding = new Padding(2, 6, 0, 0);
            flpTopbarActionsStaff.WrapContents = false;
            btnTopbarNotifyStaff.Text = "Thông tin";
            btnTopbarSettingsStaff.Text = "Cài đặt";
            btnTopbarHelpStaff.Text = "Hỗ trợ";
            btnTopbarNotifyStaff.Width = 124;
            btnTopbarSettingsStaff.Width = 104;
            btnTopbarHelpStaff.Width = 76;
            lblTopbarTitleStaff.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            }
            else
            {
            tblStaffDashboardRoot.RowStyles.Clear();
            tblStaffDashboardRoot.RowCount = 3;
            tblStaffDashboardRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            tblStaffDashboardRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 560F));
            tblStaffDashboardRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 500F));

            tblStaffKpi.ColumnCount = 4;
            tblStaffKpi.RowCount = 1;
            tblStaffKpi.ColumnStyles.Clear();
            tblStaffKpi.RowStyles.Clear();
            tblStaffKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStaffKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStaffKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStaffKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStaffKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            SetGridPosition(pnlNewStudentsToday, 0, 0, new Padding(0, 0, 16, 0));
            SetGridPosition(pnlAvailableClasses, 1, 0, new Padding(0, 0, 16, 0));
            SetGridPosition(pnlTodayReceipts, 2, 0, new Padding(0, 0, 16, 0));
            SetGridPosition(pnlDebtStudents, 3, 0, Padding.Empty);

            tblStaffMain.ColumnCount = 2;
            tblStaffMain.RowCount = 1;
            tblStaffMain.ColumnStyles.Clear();
            tblStaffMain.RowStyles.Clear();
            tblStaffMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63F));
            tblStaffMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37F));
            tblStaffMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblStaffMain.SetColumn(pnlRecentReceiptCard, 0);
            tblStaffMain.SetRow(pnlRecentReceiptCard, 0);
            tblStaffMain.SetColumn(pnlStaffActionCard, 1);
            tblStaffMain.SetRow(pnlStaffActionCard, 0);
            pnlRecentReceiptCard.Margin = new Padding(0, 0, 20, 0);
            pnlStaffActionCard.Margin = Padding.Empty;
            pnlStaffActionHeader.Height = 74;
            pnlStaffActionFooter.Height = 88;

            tblTopbarStaff.RowCount = 1;
            tblTopbarStaff.RowStyles.Clear();
            tblTopbarStaff.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblTopbarStaff.SetColumnSpan(lblTopbarTitleStaff, 1);
            tblTopbarStaff.SetColumn(lblTopbarTitleStaff, 0);
            tblTopbarStaff.SetRow(lblTopbarTitleStaff, 0);
            tblTopbarStaff.SetColumn(flpTopbarActionsStaff, 1);
            tblTopbarStaff.SetRow(flpTopbarActionsStaff, 0);
            tblTopbarStaff.SetColumn(pnlTopbarProfileStaff, 2);
            tblTopbarStaff.SetRow(pnlTopbarProfileStaff, 0);
            tblTopbarStaff.ColumnStyles[1].Width = 292F;
            tblTopbarStaff.ColumnStyles[2].Width = 314F;
            flpTopbarActionsStaff.Padding = new Padding(28, 14, 0, 0);
            flpTopbarActionsStaff.WrapContents = false;
            btnTopbarNotifyStaff.Text = "Thông tin";
            btnTopbarSettingsStaff.Text = "Cài đặt";
            btnTopbarHelpStaff.Text = "Hỗ trợ";
            btnTopbarNotifyStaff.Width = 124;
            btnTopbarSettingsStaff.Width = 104;
            btnTopbarHelpStaff.Width = 76;
            lblTopbarTitleStaff.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            }

            LayoutKpiCard(pnlNewStudentsToday, lblNewStudentsTodayTitle, lblNewStudentsTodayValue, lblNewStudentsTodayBadge);
            LayoutKpiCard(pnlAvailableClasses, lblAvailableClassesTitle, lblAvailableClassesValue, lblAvailableClassesBadge);
            LayoutKpiCard(pnlTodayReceipts, lblTodayReceiptsTitle, lblTodayReceiptsValue, lblTodayReceiptsBadge);
            LayoutKpiCard(pnlDebtStudents, lblDebtStudentsTitle, lblDebtStudentsValue, lblDebtStudentsBadge);
            SyncDashboardHomeHeight();

            tblTopbarStaff.ResumeLayout(true);
            tblStaffKpi.ResumeLayout(true);
            tblStaffMain.ResumeLayout(true);
            tblStaffDashboardRoot.ResumeLayout(true);
            pnlDashboardHome.PerformLayout();
        }
        finally
        {
            _isApplyingResponsiveLayout = false;
        }
    }

    private static void LayoutKpiCard(Panel host, Label title, Label value, Label badge)
    {
        var contentLeft = FormHostHelpers.ScaleForDpi(host, 54);
        var contentWidth = Math.Max(FormHostHelpers.ScaleForDpi(host, 120), host.ClientSize.Width - FormHostHelpers.ScaleForDpi(host, 86));
        var compact = host.ClientSize.Width < FormHostHelpers.ScaleForDpi(host, 300) || host.ClientSize.Height < FormHostHelpers.ScaleForDpi(host, 118);
        var badgeWidth = Math.Min(contentWidth, FormHostHelpers.ScaleForDpi(host, compact ? 150 : 176));

        title.AutoSize = false;
        title.Font = new Font("Segoe UI", compact ? 9.5F : 10.5F, FontStyle.Bold);
        title.Location = new Point(contentLeft, FormHostHelpers.ScaleForDpi(host, compact ? 8 : 12));
        title.Size = new Size(contentWidth, FormHostHelpers.ScaleForDpi(host, compact ? 26 : 30));
        title.TextAlign = ContentAlignment.MiddleCenter;

        value.AutoSize = false;
        value.Font = new Font("Segoe UI", compact ? 18F : 22F, FontStyle.Bold);
        value.Location = new Point(contentLeft, FormHostHelpers.ScaleForDpi(host, compact ? 32 : 38));
        value.Size = new Size(contentWidth, FormHostHelpers.ScaleForDpi(host, compact ? 34 : 40));
        value.TextAlign = ContentAlignment.MiddleCenter;

        badge.AutoSize = false;
        badge.Location = new Point(contentLeft + Math.Max(0, (contentWidth - badgeWidth) / 2), host.ClientSize.Height - FormHostHelpers.ScaleForDpi(host, compact ? 30 : 34));
        badge.Size = new Size(badgeWidth, FormHostHelpers.ScaleForDpi(host, compact ? 22 : 24));
        badge.TextAlign = ContentAlignment.MiddleCenter;
    }

    private static void SetGridPosition(Control control, int column, int row, Padding margin)
    {
        if (control.Parent is not TableLayoutPanel table)
        {
            return;
        }

        table.SetColumn(control, column);
        table.SetRow(control, row);
        control.Margin = margin;
    }

    private static (string Title, string Description, string Priority, string Deadline, string PriorityType)[] GetTaskItems()
    {
        return
        [
            ("Xác nhận ghi danh lớp IELTS", "Gửi email xác nhận cho 5 học viên mới lớp I-102", "GẤP", "HẠN: HÔM NAY", "danger"),
            ("Gọi điện nhắc phí học viên A", "Thông báo lịch đóng học phí tháng 11 cho chị Lan", "QUAN TRỌNG", "HẠN: 15:00", "info"),
            ("Cập nhật sĩ số lớp G1", "Kiểm tra danh sách học viên dự thính lớp Giao Tiếp 1", "BÌNH THƯỜNG", "HẠN: MAI", "neutral")
        ];
    }

    private static void StylePriorityBadge(Label badge, string priorityType)
    {
        badge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

        switch (priorityType)
        {
            case "danger":
                badge.BackColor = Color.FromArgb(255, 225, 225);
                badge.ForeColor = Color.FromArgb(181, 33, 39);
                break;
            case "info":
                badge.BackColor = Color.FromArgb(147, 239, 231);
                badge.ForeColor = Color.FromArgb(8, 95, 96);
                break;
            default:
                badge.BackColor = Color.FromArgb(224, 239, 248);
                badge.ForeColor = Color.FromArgb(70, 84, 102);
                break;
        }
    }

    private static void StyleBadge(Label badge, Color backColor, Color foreColor)
    {
        badge.BackColor = backColor;
        badge.ForeColor = foreColor;
        badge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        badge.Padding = new Padding(10, 4, 10, 4);
    }

    private static void StyleSidebarButton(Button button, bool active)
    {
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.TextAlign = ContentAlignment.MiddleLeft;
        button.Font = new Font("Segoe UI", active ? 10.5F : 10F, active ? FontStyle.Bold : FontStyle.Regular);
        button.ForeColor = active ? Color.FromArgb(12, 86, 92) : Color.FromArgb(35, 46, 61);
        button.BackColor = active ? Color.FromArgb(126, 227, 227) : Color.Transparent;
    }

    private void StyleTopbarActionButton(Button button, string text, int width)
    {
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.BackColor = Color.Transparent;
        button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        button.ForeColor = Color.FromArgb(52, 60, 70);
        button.Text = text;
        button.TextAlign = ContentAlignment.MiddleCenter;
        button.TabStop = false;
        button.AutoSize = false;
        button.Padding = FormHostHelpers.ScalePadding(this, new Padding(6, 0, 6, 0));
        button.Width = FormHostHelpers.ScaleForDpi(this, width);
        button.Height = FormHostHelpers.ScaleForDpi(this, 36);
    }

    private void SyncDashboardHomeHeight()
    {
        var totalHeight = 0;
        foreach (RowStyle rowStyle in tblStaffDashboardRoot.RowStyles)
        {
            totalHeight += (int)Math.Ceiling(rowStyle.Height);
        }

        totalHeight += tblStaffDashboardRoot.Margin.Vertical;
        pnlDashboardHome.Height = Math.Max(totalHeight, 1180);
    }

    private sealed class CursorScope : IDisposable
    {
        private readonly Cursor? _previousCursor;

        public CursorScope(Cursor nextCursor)
        {
            _previousCursor = Cursor.Current;
            Cursor.Current = nextCursor;
        }

        public void Dispose()
        {
            if (_previousCursor is not null)
            {
                Cursor.Current = _previousCursor;
            }
        }
    }
}
