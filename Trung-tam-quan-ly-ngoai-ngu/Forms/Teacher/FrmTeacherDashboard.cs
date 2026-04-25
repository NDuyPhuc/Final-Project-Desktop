using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmTeacherDashboard : Form
{
    private readonly string _currentUserName;
    private bool _isApplyingResponsiveLayout;
    private Panel? _sidebarFooterPanel;
    private Button? _btnTeacherNewSession;
    private Button? _btnTeacherSettings;
    private TableLayoutPanel? _topbarLayout;
    private TextBox? _txtTopbarSearch;
    private FlowLayoutPanel? _flpTopbarActions;
    private Panel? _pnlProfileCard;
    private FlowLayoutPanel? _flpDashboardTasks;
    private Panel? _pnlUpcomingSchedule;

    public FrmTeacherDashboard() : this("Nguyễn Văn A")
    {
    }

    public FrmTeacherDashboard(string currentUserName)
    {
        _currentUserName = currentUserName;
        InitializeComponent();
        FormHostHelpers.ConfigureShellSurface(this, "Dashboard giảng dạy");
        ApplyShellStyling();
        BindDashboardData();
        ShowDashboardHome();
    }

    private void ApplyShellStyling()
    {
        MinimumSize = new Size(1220, 780);
        BackColor = Color.FromArgb(236, 247, 255);
        pnlSidebarTeacher.Width = 340;
        pnlTopbarTeacher.Height = 104;
        pnlSidebarTeacher.BackColor = Color.FromArgb(225, 243, 255);
        pnlTopbarTeacher.BackColor = Color.White;
        pnlContentHostTeacher.BackColor = Color.FromArgb(236, 247, 255);
        pnlContentHostTeacher.Padding = new Padding(18, 0, 18, 18);
        pnlContentHostTeacher.AutoScroll = true;
        pnlDashboardHome.BackColor = Color.FromArgb(236, 247, 255);
        pnlDashboardHome.AutoScroll = true;
        pnlSidebarTeacherBrand.Height = 110;
        pnlSidebarTeacherBrand.Padding = new Padding(6, 0, 0, 0);

        lblSidebarTeacherTitle.Text = "LINGUISTIC\r\nARCHITECT";
        lblSidebarTeacherTitle.AutoSize = false;
        lblSidebarTeacherTitle.Dock = DockStyle.Top;
        lblSidebarTeacherTitle.Height = 76;
        lblSidebarTeacherTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblSidebarTeacherTitle.Font = new Font("Segoe UI", 14.5F, FontStyle.Bold);
        lblSidebarTeacherTitle.ForeColor = Color.FromArgb(12, 33, 49);
        lblSidebarTeacherSubtitle.Text = "TEACHER PORTAL";
        lblSidebarTeacherSubtitle.AutoSize = false;
        lblSidebarTeacherSubtitle.Dock = DockStyle.Top;
        lblSidebarTeacherSubtitle.Height = 26;
        lblSidebarTeacherSubtitle.TextAlign = ContentAlignment.MiddleLeft;
        lblSidebarTeacherSubtitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblSidebarTeacherSubtitle.ForeColor = Color.FromArgb(91, 110, 132);

        btnMenuTeacherDashboard.Text = "    DASHBOARD GIẢNG DẠY";
        btnMenuTeachingClasses.Text = "    LỚP ĐANG DẠY";
        btnMenuClassStudentList.Text = "    DANH SÁCH HỌC SINH LỚP";
        btnMenuAttendance.Text = "    ĐIỂM DANH";
        btnMenuScoreEntry.Text = "    NHẬP ĐIỂM";

        flpSidebarTeacherMenu.Dock = DockStyle.Fill;
        flpSidebarTeacherMenu.AutoScroll = true;

        foreach (var button in GetMenuButtons())
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(202, 237, 237);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(234, 246, 250);
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(18, 0, 12, 0);
            button.Width = Math.Max(292, flpSidebarTeacherMenu.ClientSize.Width - 4);
            button.Height = 58;
            button.Margin = new Padding(0, 0, 0, 10);
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        flpSidebarTeacherMenu.Padding = new Padding(0, 22, 0, 0);
        flpSidebarTeacherMenu.WrapContents = false;

        EnsureSidebarFooter();
        EnsureTopbarChrome();

        AppTheme.StyleDangerButton(btnLogoutTeacher);
        btnLogoutTeacher.Text = "Đăng xuất";
        btnLogoutTeacher.Dock = DockStyle.Top;
        btnLogoutTeacher.Height = 44;
        btnLogoutTeacher.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnLogoutTeacher.Margin = Padding.Empty;
        btnLogoutTeacher.TextAlign = ContentAlignment.MiddleCenter;
        btnLogoutTeacher.Click += (_, _) => FormHostHelpers.OpenLoginAndClose(this);

        foreach (var card in new[] { pnlTeacherHeroCard, pnlTeachingClassesCount, pnlTeachingStudentCount, pnlTeachingTodaySessions, pnlTeachingPendingScores, pnlTeacherClassCard, pnlTeacherTaskCard })
        {
            AppTheme.StyleCard(card);
            card.Margin = Padding.Empty;
        }

        ConfigureHeroCard();
        ConfigureKpiCards();
        ConfigureClassOverviewCard();
        ConfigureTaskCard();
        splTeacherDashboard.FixedPanel = FixedPanel.None;
        splTeacherDashboard.Panel1MinSize = 540;
        splTeacherDashboard.Panel2MinSize = 300;
        splTeacherDashboard.SplitterWidth = 10;

        var menuButtons = GetMenuButtons();
        btnMenuTeacherDashboard.Click += (_, _) => ShowDashboardHome();
        btnMenuTeachingClasses.Click += (_, _) => OpenModule(new FrmTeachingClasses(), btnMenuTeachingClasses, menuButtons);
        btnMenuClassStudentList.Click += (_, _) => OpenModule(new FrmClassStudentList(), btnMenuClassStudentList, menuButtons);
        btnMenuAttendance.Click += (_, _) => OpenModule(new FrmAttendance(), btnMenuAttendance, menuButtons);
        btnMenuScoreEntry.Click += (_, _) => OpenModule(new FrmScoreEntry(), btnMenuScoreEntry, menuButtons);

        Resize += (_, _) => ApplyResponsiveLayout();
        ApplyResponsiveLayout();
    }

    private void BindDashboardData()
    {
        lblTeachingClassesCountValue.Text = "12";
        lblTeachingStudentCountValue.Text = "186";
        lblTeachingTodaySessionsValue.Text = "04";
        lblTeachingPendingScoresValue.Text = "01";

        dgvTeacherClassOverview.DataSource = CreateTeachingOverviewTable();
        ConfigureTeacherOverviewGrid();
        RebuildTaskCards();
    }

    private void ShowDashboardHome()
    {
        pnlDashboardHome.Dock = DockStyle.Fill;
        pnlContentHostTeacher.Controls.Clear();
        pnlContentHostTeacher.Controls.Add(pnlDashboardHome);
        FormHostHelpers.SetActiveMenu(btnMenuTeacherDashboard, GetMenuButtons());
    }

    private void OpenModule(Form moduleForm, Button activeButton, Button[] allButtons)
    {
        FormHostHelpers.OpenChildForm(pnlContentHostTeacher, moduleForm);
        FormHostHelpers.SetActiveMenu(activeButton, allButtons);
    }

    private Button[] GetMenuButtons()
    {
        return new[]
        {
            btnMenuTeacherDashboard,
            btnMenuTeachingClasses,
            btnMenuClassStudentList,
            btnMenuAttendance,
            btnMenuScoreEntry
        };
    }

    private void EnsureSidebarFooter()
    {
        if (_sidebarFooterPanel is not null)
        {
            return;
        }

        _sidebarFooterPanel = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 188,
            Padding = new Padding(0, 10, 0, 0),
            BackColor = Color.Transparent
        };

        _btnTeacherNewSession = new Button
        {
            Dock = DockStyle.Top,
            Height = 42,
            FlatStyle = FlatStyle.Flat,
            Text = "Tạo buổi học mới",
            TextAlign = ContentAlignment.MiddleCenter,
            BackColor = Color.FromArgb(0, 78, 140),
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            Margin = new Padding(0, 0, 0, 10)
        };
        _btnTeacherNewSession.FlatAppearance.BorderSize = 0;
        _btnTeacherNewSession.FlatAppearance.MouseOverBackColor = Color.FromArgb(10, 96, 166);
        _btnTeacherNewSession.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Tạo buổi học mới", "Khung teacher đã sẵn chỗ cho hành động tạo buổi học mới.");
            dialog.ShowDialog(this);
        };

        _btnTeacherSettings = new Button
        {
            Dock = DockStyle.Top,
            Height = 38,
            FlatStyle = FlatStyle.Flat,
            Text = "Cài đặt",
            TextAlign = ContentAlignment.MiddleLeft,
            Padding = new Padding(12, 0, 0, 0),
            BackColor = Color.Transparent,
            ForeColor = Color.FromArgb(83, 97, 116),
            Font = new Font("Segoe UI", 9.25F, FontStyle.Bold)
        };
        _btnTeacherSettings.FlatAppearance.BorderSize = 0;
        _btnTeacherSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(234, 246, 250);

        pnlSidebarTeacher.Controls.Remove(btnLogoutTeacher);
        _sidebarFooterPanel.Controls.Add(btnLogoutTeacher);
        _sidebarFooterPanel.Controls.Add(_btnTeacherSettings);
        _sidebarFooterPanel.Controls.Add(_btnTeacherNewSession);
        pnlSidebarTeacher.Controls.Add(_sidebarFooterPanel);
        _sidebarFooterPanel.BringToFront();
    }

    private void EnsureTopbarChrome()
    {
        pnlTopbarTeacher.Controls.Clear();

        _topbarLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 1,
            Margin = Padding.Empty,
            Padding = new Padding(18, 12, 18, 12),
            BackColor = Color.White
        };
        _topbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _topbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 112F));
        _topbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 360F));

        _txtTopbarSearch = new TextBox
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(0, 8, 24, 8),
            PlaceholderText = "Tìm kiếm lớp học, học viên...",
            BorderStyle = BorderStyle.FixedSingle
        };

        _flpTopbarActions = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            Margin = Padding.Empty,
            Padding = new Padding(8, 12, 0, 0)
        };

        var btnNotify = CreateTopbarMiniButton("🔔");
        var btnHelp = CreateTopbarMiniButton("?");
        _flpTopbarActions.Controls.Add(btnNotify);
        _flpTopbarActions.Controls.Add(btnHelp);

        _pnlProfileCard = new Panel
        {
            Dock = DockStyle.Fill,
            Margin = Padding.Empty,
            BackColor = Color.White
        };

        var avatar = new Panel
        {
            Dock = DockStyle.Right,
            Width = 40,
            BackColor = Color.FromArgb(25, 40, 58),
            Margin = Padding.Empty
        };

        var avatarText = new Label
        {
            Dock = DockStyle.Fill,
            Text = string.Concat(_currentUserName.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(part => part[0])).PadRight(2).Substring(0, 2).ToUpperInvariant(),
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold)
        };
        avatar.Controls.Add(avatarText);

        lblCurrentUserTeacher.AutoSize = false;
        lblCurrentUserTeacher.Dock = DockStyle.Top;
        lblCurrentUserTeacher.Height = 28;
        lblCurrentUserTeacher.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCurrentUserTeacher.ForeColor = Color.FromArgb(26, 38, 55);
        lblCurrentUserTeacher.TextAlign = ContentAlignment.BottomRight;
        lblCurrentUserTeacher.Text = _currentUserName;

        lblCurrentRoleTeacher.AutoSize = false;
        lblCurrentRoleTeacher.Dock = DockStyle.Top;
        lblCurrentRoleTeacher.Height = 20;
        lblCurrentRoleTeacher.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblCurrentRoleTeacher.ForeColor = Color.FromArgb(111, 126, 144);
        lblCurrentRoleTeacher.TextAlign = ContentAlignment.BottomRight;
        lblCurrentRoleTeacher.Text = "SENIOR TEACHER";

        var profileText = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2,
            Padding = new Padding(0, 2, 10, 0)
        };
        profileText.RowStyles.Add(new RowStyle(SizeType.Percent, 52F));
        profileText.RowStyles.Add(new RowStyle(SizeType.Percent, 48F));
        profileText.Controls.Add(lblCurrentUserTeacher, 0, 0);
        profileText.Controls.Add(lblCurrentRoleTeacher, 0, 1);

        _pnlProfileCard.Controls.Add(profileText);
        _pnlProfileCard.Controls.Add(avatar);

        _topbarLayout.Controls.Add(_txtTopbarSearch, 0, 0);
        _topbarLayout.Controls.Add(_flpTopbarActions, 1, 0);
        _topbarLayout.Controls.Add(_pnlProfileCard, 2, 0);
        pnlTopbarTeacher.Controls.Add(_topbarLayout);
    }

    private void ConfigureHeroCard()
    {
        pnlTeacherHeroCard.Padding = new Padding(0);
        pnlTeacherHeroCard.Controls.Clear();

        var header = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 1,
            Padding = new Padding(12, 4, 0, 4)
        };
        header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220F));

        var left = new Panel { Dock = DockStyle.Fill };
        lblTeacherDashboardTitle.AutoSize = false;
        lblTeacherDashboardTitle.Dock = DockStyle.Top;
        lblTeacherDashboardTitle.Height = 42;
        lblTeacherDashboardTitle.Text = "Dashboard giảng dạy";
        lblTeacherDashboardTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTeacherDashboardTitle.ForeColor = Color.FromArgb(17, 34, 54);

        lblTeacherDashboardSubtitle.AutoSize = false;
        lblTeacherDashboardSubtitle.Dock = DockStyle.Top;
        lblTeacherDashboardSubtitle.Height = 22;
        lblTeacherDashboardSubtitle.Text = "Theo dõi lớp phụ trách, buổi học hôm nay và tác vụ cần xử lý";
        lblTeacherDashboardSubtitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
        lblTeacherDashboardSubtitle.ForeColor = Color.FromArgb(106, 119, 138);

        left.Controls.Add(lblTeacherDashboardSubtitle);
        left.Controls.Add(lblTeacherDashboardTitle);

        var rightHint = new Label
        {
            Dock = DockStyle.Fill,
            Text = "XEM TỔNG QUAN GIẢNG DẠY",
            TextAlign = ContentAlignment.MiddleRight,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(0, 96, 168)
        };

        header.Controls.Add(left, 0, 0);
        header.Controls.Add(rightHint, 1, 0);
        pnlTeacherHeroCard.Controls.Add(header);
    }

    private void ConfigureKpiCards()
    {
        SetupKpiCard(pnlTeachingClassesCount, "LỚP ĐANG DẠY", lblTeachingClassesCountValue, "HỌC KỲ 2026-Q1", Color.FromArgb(8, 73, 132));
        SetupKpiCard(pnlTeachingStudentCount, "BUỔI HỌC HÔM NAY", lblTeachingStudentCountValue, "CẬP NHẬT 08:30", Color.FromArgb(0, 123, 118));
        SetupKpiCard(pnlTeachingTodaySessions, "CHỜ ĐIỂM DANH", lblTeachingTodaySessionsValue, "YÊU CẦU XỬ LÝ NGAY", Color.FromArgb(154, 103, 21));
        SetupKpiCard(pnlTeachingPendingScores, "CHỜ NHẬP ĐIỂM", lblTeachingPendingScoresValue, "THỜI HẠN 2 NGÀY", Color.FromArgb(204, 33, 48));
    }

    private void SetupKpiCard(Panel host, string title, Label valueLabel, string hint, Color accent)
    {
        host.Controls.Clear();
        host.Padding = new Padding(18, 16, 18, 16);

        var accentBar = new Panel
        {
            Dock = DockStyle.Left,
            Width = 4,
            BackColor = accent
        };

        valueLabel.AutoSize = false;
        valueLabel.Dock = DockStyle.Top;
        valueLabel.Height = 42;
        valueLabel.TextAlign = ContentAlignment.MiddleLeft;
        valueLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        valueLabel.ForeColor = Color.FromArgb(17, 34, 54);

        var titleLabel = new Label
        {
            Dock = DockStyle.Top,
            Height = 26,
            Text = title,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            ForeColor = Color.FromArgb(86, 98, 117)
        };

        var hintLabel = new Label
        {
            Dock = DockStyle.Top,
            Height = 22,
            Text = hint,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            ForeColor = accent
        };

        var body = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(14, 0, 0, 0)
        };
        body.Controls.Add(hintLabel);
        body.Controls.Add(valueLabel);
        body.Controls.Add(titleLabel);

        host.Controls.Add(body);
        host.Controls.Add(accentBar);
    }

    private void ConfigureClassOverviewCard()
    {
        pnlTeacherClassCard.Padding = new Padding(0);
        pnlTeacherClassCard.Controls.Clear();

        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2
        };
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        var header = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(225, 242, 254),
            Padding = new Padding(16, 0, 16, 0)
        };

        lblTeacherClassCardTitle.AutoSize = false;
        lblTeacherClassCardTitle.Dock = DockStyle.Left;
        lblTeacherClassCardTitle.Width = 280;
        lblTeacherClassCardTitle.Text = "DANH SÁCH LỚP PHỤ TRÁCH";
        lblTeacherClassCardTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTeacherClassCardTitle.TextAlign = ContentAlignment.MiddleLeft;

        lblTeacherClassCardHint.AutoSize = false;
        lblTeacherClassCardHint.Dock = DockStyle.Right;
        lblTeacherClassCardHint.Width = 180;
        lblTeacherClassCardHint.Text = "XEM TẤT CẢ";
        lblTeacherClassCardHint.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblTeacherClassCardHint.ForeColor = Color.FromArgb(0, 96, 168);
        lblTeacherClassCardHint.TextAlign = ContentAlignment.MiddleRight;

        header.Controls.Add(lblTeacherClassCardHint);
        header.Controls.Add(lblTeacherClassCardTitle);

        dgvTeacherClassOverview.Dock = DockStyle.Fill;
        AppTheme.StyleGrid(dgvTeacherClassOverview);
        dgvTeacherClassOverview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgvTeacherClassOverview.ScrollBars = ScrollBars.Both;
        dgvTeacherClassOverview.ColumnHeadersHeight = 56;
        dgvTeacherClassOverview.RowTemplate.Height = 56;
        dgvTeacherClassOverview.DefaultCellStyle.Padding = new Padding(8, 6, 8, 6);
        dgvTeacherClassOverview.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 252, 255);

        root.Controls.Add(header, 0, 0);
        root.Controls.Add(dgvTeacherClassOverview, 0, 1);
        pnlTeacherClassCard.Controls.Add(root);
    }

    private void ConfigureTeacherOverviewGrid()
    {
        if (dgvTeacherClassOverview.Columns.Count == 0)
        {
            return;
        }

        dgvTeacherClassOverview.Columns[0].HeaderText = "MÃ LỚP";
        dgvTeacherClassOverview.Columns[1].HeaderText = "TÊN LỚP";
        dgvTeacherClassOverview.Columns[2].HeaderText = "KHÓA HỌC";
        dgvTeacherClassOverview.Columns[3].HeaderText = "LỊCH HỌC";
        dgvTeacherClassOverview.Columns[4].HeaderText = "SĨ SỐ";
        dgvTeacherClassOverview.Columns[5].HeaderText = "TRẠNG THÁI";
        dgvTeacherClassOverview.Columns[6].HeaderText = "THAO TÁC";

        dgvTeacherClassOverview.Columns[0].Width = 110;
        dgvTeacherClassOverview.Columns[1].Width = 210;
        dgvTeacherClassOverview.Columns[2].Width = 180;
        dgvTeacherClassOverview.Columns[3].Width = 170;
        dgvTeacherClassOverview.Columns[4].Width = 84;
        dgvTeacherClassOverview.Columns[5].Width = 148;
        dgvTeacherClassOverview.Columns[6].Width = 52;
        dgvTeacherClassOverview.Columns[6].HeaderText = "...";
        foreach (DataGridViewRow row in dgvTeacherClassOverview.Rows)
        {
            if (row.IsNewRow)
            {
                continue;
            }

            row.Cells[0].Style.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
            row.Cells[0].Style.ForeColor = Color.FromArgb(0, 96, 168);
            row.Cells[1].Style.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
            row.Cells[5].Style.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            row.Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var status = row.Cells[5].Value?.ToString();
            if (string.Equals(status, "ĐANG DẠY", StringComparison.OrdinalIgnoreCase))
            {
                row.Cells[5].Style.BackColor = Color.FromArgb(210, 245, 244);
                row.Cells[5].Style.ForeColor = Color.FromArgb(8, 102, 99);
            }
            else
            {
                row.Cells[5].Style.BackColor = Color.FromArgb(255, 239, 222);
                row.Cells[5].Style.ForeColor = Color.FromArgb(166, 98, 18);
            }
        }
    }

    private void ConfigureTaskCard()
    {
        pnlTeacherTaskCard.Padding = new Padding(0);
        pnlTeacherTaskCard.Controls.Clear();

        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3
        };
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 168F));

        var header = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(225, 242, 254),
            Padding = new Padding(16, 0, 16, 0)
        };

        lblTeacherTaskTitle.AutoSize = false;
        lblTeacherTaskTitle.Dock = DockStyle.Fill;
        lblTeacherTaskTitle.Text = "NHIỆM VỤ GIẢNG DẠY";
        lblTeacherTaskTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTeacherTaskTitle.TextAlign = ContentAlignment.MiddleLeft;
        header.Controls.Add(lblTeacherTaskTitle);

        _flpDashboardTasks = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = true,
            Padding = new Padding(14, 16, 14, 10),
            BackColor = Color.White
        };
        _flpDashboardTasks.Resize += (_, _) => ResizeDashboardTaskCards();

        _pnlUpcomingSchedule = new Panel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(14, 0, 14, 14),
            BackColor = Color.FromArgb(0, 78, 140),
            Padding = new Padding(16, 14, 16, 12)
        };

        root.Controls.Add(header, 0, 0);
        root.Controls.Add(_flpDashboardTasks, 0, 1);
        root.Controls.Add(_pnlUpcomingSchedule, 0, 2);
        pnlTeacherTaskCard.Controls.Add(root);

        lstTeacherTaskQueue.Visible = false;
        lblTeacherTaskHint.Visible = false;
        BuildUpcomingSchedule();
    }

    private void RebuildTaskCards()
    {
        if (_flpDashboardTasks is null)
        {
            return;
        }

        _flpDashboardTasks.Controls.Clear();
        foreach (var task in GetTeachingTaskItems())
        {
            var accent = new Panel
            {
                Dock = DockStyle.Left,
                Width = 4,
                BackColor = task.Accent
            };

            var title = new Label
            {
                Dock = DockStyle.Top,
                Height = 42,
                Text = task.Title,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(25, 39, 57)
            };

            var body = new Label
            {
                Dock = DockStyle.Top,
                Height = 52,
                Text = task.Description,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(97, 109, 128)
            };

            var button = new Button
            {
                Text = task.Action,
                Width = 148,
                Height = 32,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.75F, FontStyle.Bold)
            };
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = task.Accent;
            button.ForeColor = Color.White;

            var due = new Label
            {
                AutoSize = true,
                Text = task.Deadline,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = task.Accent,
                Margin = new Padding(10, 8, 0, 0)
            };

            var actionRow = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 60,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Margin = Padding.Empty
            };
            actionRow.Controls.Add(button);
            actionRow.Controls.Add(due);

            var content = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(14, 12, 12, 10)
            };
            content.Controls.Add(actionRow);
            content.Controls.Add(body);
            content.Controls.Add(title);

            var card = new Panel
            {
                Width = 320,
                Height = 168,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 14)
            };
            card.Controls.Add(content);
            card.Controls.Add(accent);
            _flpDashboardTasks.Controls.Add(card);
        }

        ResizeDashboardTaskCards();
    }

    private void BuildUpcomingSchedule()
    {
        if (_pnlUpcomingSchedule is null)
        {
            return;
        }

        _pnlUpcomingSchedule.Controls.Clear();

        var title = new Label
        {
            Dock = DockStyle.Top,
            Height = 28,
            Text = "LỊCH DẠY SẮP TỚI",
            Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
            ForeColor = Color.White
        };

        var itemOne = CreateScheduleItem("22 TH5", "IELTS Listening Test", "PHÒNG 4A • 18:30");
        var itemTwo = CreateScheduleItem("23 TH5", "TOEIC Mock Exam", "PHÒNG LAB 1 • 19:00");

        _pnlUpcomingSchedule.Controls.Add(itemTwo);
        _pnlUpcomingSchedule.Controls.Add(itemOne);
        _pnlUpcomingSchedule.Controls.Add(title);
    }

    private static Panel CreateScheduleItem(string date, string title, string subtitle)
    {
        var panel = new Panel
        {
            Dock = DockStyle.Top,
            Height = 62,
            Padding = new Padding(0, 4, 0, 4)
        };

        var dateLabel = new Label
        {
            Dock = DockStyle.Left,
            Width = 60,
            Text = date,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(183, 217, 244),
            TextAlign = ContentAlignment.MiddleLeft
        };

        var titleLabel = new Label
        {
            Dock = DockStyle.Top,
            Height = 22,
            Text = title,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            ForeColor = Color.White
        };

        var subtitleLabel = new Label
        {
            Dock = DockStyle.Top,
            Height = 20,
            Text = subtitle,
            Font = new Font("Segoe UI", 8F, FontStyle.Regular),
            ForeColor = Color.FromArgb(183, 217, 244)
        };

        var textPanel = new Panel { Dock = DockStyle.Fill };
        textPanel.Controls.Add(subtitleLabel);
        textPanel.Controls.Add(titleLabel);

        panel.Controls.Add(textPanel);
        panel.Controls.Add(dateLabel);
        return panel;
    }

    private Button CreateTopbarMiniButton(string text)
    {
        var button = new Button
        {
            Width = 46,
            Height = 36,
            Text = text,
            FlatStyle = FlatStyle.Flat,
            Margin = new Padding(0, 0, 8, 0),
            BackColor = Color.White,
            ForeColor = Color.FromArgb(57, 68, 85),
            Font = new Font("Segoe UI", 10.5F, FontStyle.Bold)
        };
        button.FlatAppearance.BorderSize = 0;
        return button;
    }

    private void ApplyResponsiveLayout()
    {
        if (_isApplyingResponsiveLayout)
        {
            return;
        }

        _isApplyingResponsiveLayout = true;
        try
        {
            var width = ClientSize.Width;
            var compact = width < 1480;
            var veryCompact = width < 1320;

            pnlSidebarTeacher.Width = veryCompact ? 312 : 340;
            pnlTopbarTeacher.Height = veryCompact ? 116 : 104;

            if (_topbarLayout is not null)
            {
                _topbarLayout.ColumnStyles[1].Width = compact ? 96F : 112F;
                _topbarLayout.ColumnStyles[2].Width = veryCompact ? 292F : 360F;
            }

            foreach (var button in GetMenuButtons())
            {
                button.Width = Math.Max(272, flpSidebarTeacherMenu.ClientSize.Width - 8);
            }

            tblTeacherKpi.SuspendLayout();
            if (veryCompact)
            {
                tblTeacherKpi.ColumnCount = 2;
                tblTeacherKpi.RowCount = 2;
                tblTeacherKpi.ColumnStyles.Clear();
                tblTeacherKpi.RowStyles.Clear();
                tblTeacherKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tblTeacherKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tblTeacherKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 118F));
                tblTeacherKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 118F));

                SetTablePosition(pnlTeachingClassesCount, 0, 0, new Padding(0, 0, 10, 10));
                SetTablePosition(pnlTeachingStudentCount, 1, 0, new Padding(0, 0, 0, 10));
                SetTablePosition(pnlTeachingTodaySessions, 0, 1, new Padding(0, 0, 10, 0));
                SetTablePosition(pnlTeachingPendingScores, 1, 1, Padding.Empty);
            }
            else
            {
                tblTeacherKpi.ColumnCount = 4;
                tblTeacherKpi.RowCount = 1;
                tblTeacherKpi.ColumnStyles.Clear();
                tblTeacherKpi.RowStyles.Clear();
                for (var i = 0; i < 4; i++)
                {
                    tblTeacherKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                }
                tblTeacherKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 118F));

                SetTablePosition(pnlTeachingClassesCount, 0, 0, new Padding(0, 0, 12, 0));
                SetTablePosition(pnlTeachingStudentCount, 1, 0, new Padding(0, 0, 12, 0));
                SetTablePosition(pnlTeachingTodaySessions, 2, 0, new Padding(0, 0, 12, 0));
                SetTablePosition(pnlTeachingPendingScores, 3, 0, Padding.Empty);
            }
            tblTeacherKpi.ResumeLayout(true);
            ApplyDashboardSplit();
            ResizeDashboardTaskCards();
        }
        finally
        {
            _isApplyingResponsiveLayout = false;
        }
    }

    private static void SetTablePosition(Control control, int column, int row, Padding margin)
    {
        if (control.Parent is not TableLayoutPanel table)
        {
            return;
        }

        table.SetColumn(control, column);
        table.SetRow(control, row);
        control.Margin = margin;
    }

    private void ApplyDashboardSplit()
    {
        if (!splTeacherDashboard.IsHandleCreated || splTeacherDashboard.Width <= 0 || splTeacherDashboard.Height <= 0)
        {
            return;
        }

        var availableWidth = splTeacherDashboard.Width - splTeacherDashboard.SplitterWidth;
        if (availableWidth <= 0)
        {
            return;
        }

        if (splTeacherDashboard.Orientation != Orientation.Vertical)
        {
            splTeacherDashboard.Panel1MinSize = 120;
            splTeacherDashboard.Panel2MinSize = 120;
            var safeVerticalDistance = Math.Clamp((int)(availableWidth * 0.66), 120, Math.Max(120, availableWidth - 120));
            splTeacherDashboard.SplitterDistance = safeVerticalDistance;
            splTeacherDashboard.Orientation = Orientation.Vertical;
        }

        var panel2Min = Math.Min(300, Math.Max(180, availableWidth / 4));
        var panel1Min = Math.Min(540, Math.Max(260, availableWidth - panel2Min));

        if (panel1Min + panel2Min > availableWidth)
        {
            panel1Min = Math.Max(220, availableWidth - panel2Min);
            panel2Min = Math.Max(180, availableWidth - panel1Min);
        }

        splTeacherDashboard.Panel1MinSize = panel1Min;
        splTeacherDashboard.Panel2MinSize = panel2Min;

        var maxDistance = Math.Max(panel1Min, availableWidth - panel2Min);
        var desiredDistance = Math.Max(panel1Min, (int)(availableWidth * 0.70));
        splTeacherDashboard.SplitterDistance = Math.Clamp(desiredDistance, panel1Min, maxDistance);
    }

    private void ResizeDashboardTaskCards()
    {
        if (_flpDashboardTasks is null)
        {
            return;
        }

        var availableWidth = Math.Max(250, _flpDashboardTasks.ClientSize.Width - (_flpDashboardTasks.VerticalScroll.Visible ? 34 : 24));
        foreach (Control control in _flpDashboardTasks.Controls)
        {
            control.Width = availableWidth;
            var narrow = availableWidth < 310;
            control.Height = narrow ? 196 : 168;

            if (control.Controls.Count > 0 && control.Controls[0] is Panel content)
            {
                FlowLayoutPanel? actionRow = null;
                Label? body = null;
                Label? title = null;

                foreach (Control inner in content.Controls)
                {
                    if (inner is FlowLayoutPanel flow)
                    {
                        actionRow = flow;
                    }
                    else if (inner is Label label && label.Font.Bold)
                    {
                        title = label;
                    }
                    else if (inner is Label label2)
                    {
                        body = label2;
                    }
                }

                if (title is not null)
                {
                    title.Height = narrow ? 52 : 42;
                }

                if (body is not null)
                {
                    body.Height = narrow ? 64 : 52;
                }

                if (actionRow is not null)
                {
                    actionRow.Height = narrow ? 72 : 60;
                    if (actionRow.Controls.Count > 0 && actionRow.Controls[0] is Button button)
                    {
                        button.Width = narrow ? 132 : 148;
                    }
                }
            }
        }
    }

    private static DataTable CreateTeachingOverviewTable()
    {
        var table = new DataTable();
        table.Columns.Add("Mã lớp");
        table.Columns.Add("Tên lớp");
        table.Columns.Add("Khóa học");
        table.Columns.Add("Lịch học");
        table.Columns.Add("Sĩ số");
        table.Columns.Add("Trạng thái");
        table.Columns.Add("Thao tác");

        table.Rows.Add("IELTS-01", "IELTS Foundation", "IELTS Track A", "Thứ 2-4-6 (18:00)", "15/20", "ĐANG DẠY", "⋯");
        table.Rows.Add("TOEIC-A2", "TOEIC 500+", "TOEIC Intensive", "Thứ 3-5 (19:30)", "12/15", "KẾT THÚC", "⋯");
        table.Rows.Add("COM-B1", "Giao tiếp cơ bản", "General English", "Thứ 7-CN (08:00)", "18/20", "ĐANG DẠY", "⋯");
        table.Rows.Add("IELTS-03", "IELTS Advanced", "IELTS Track B", "Thứ 2-4-6 (20:00)", "08/12", "ĐANG DẠY", "⋯");
        return table;
    }

    private static (string Title, string Description, string Action, string Deadline, Color Accent)[] GetTeachingTaskItems()
    {
        return
        [
            ("Điểm danh lớp IELTS-01", "Hôm nay, lúc 18:00", "THỰC HIỆN NGAY", "Ưu tiên đầu ngày", Color.FromArgb(8, 102, 99)),
            ("Nhập điểm cuối khóa TOEIC-A2", "Hạn chót 20/05/2026 (đã trễ)", "NHẬP ĐIỂM", "Báo cáo trễ", Color.FromArgb(209, 53, 53)),
            ("Chuẩn bị tài liệu lớp COM-B1", "Thứ 7, lúc 08:00", "XEM CHI TIẾT", "Cần in trước buổi học", Color.FromArgb(0, 96, 168))
        ];
    }
}
