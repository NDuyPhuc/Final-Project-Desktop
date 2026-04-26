using System.ComponentModel;
using System.Data;
using TrungTamNgoaiNgu.Application.Contracts;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Domain.Entities;
using TrungTamNgoaiNgu.Domain.Enums;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAccountManagement : Form
{
    private readonly ILanguageCenterDataService _dataService;
    private readonly List<AccountRecord> _accounts = [];
    private readonly Dictionary<string, Panel> _accountCards = new();
    private AccountRecord? _selectedAccount;
    private bool _creatingAccount;

    public FrmAccountManagement() : this(AppRuntime.DataService)
    {
    }

    public FrmAccountManagement(ILanguageCenterDataService dataService)
    {
        _dataService = dataService;

        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Tài khoản và phân quyền");

        ApplyLocalizedText();
        ConfigureVisualStyle();
        ConfigureResponsiveLayout();
        WireEvents();
        SeedAccounts();
        ApplyFilters();
    }

    private void ApplyLocalizedText()
    {
        Text = "Tài khoản và phân quyền";
        lblAccountListTitle.Text = "Danh sách tài khoản";
        txtAccountKeyword.PlaceholderText = "Tìm kiếm tài khoản...";
        lblAccountTitle.Text = "CHI TIẾT TÀI KHOẢN";
        btnCreateAccount.Text = "+ Tạo tài khoản mới";
        lblDisplayName.Text = "HỌ VÀ TÊN";
        lblUsername.Text = "TÊN ĐĂNG NHẬP";
        lblEmail.Text = "EMAIL";
        lblPhone.Text = "SỐ ĐIỆN THOẠI";
        lblRole.Text = "VAI TRÒ";
        lblStatus.Text = "TRẠNG THÁI";
        rdoAccountActive.Text = "Hoạt động";
        rdoAccountLocked.Text = "Khóa";
        btnSaveAccount.Text = "LƯU THAY ĐỔI";
        btnResetPassword.Text = "ĐẶT LẠI MẬT KHẨU";
        btnToggleAccountStatus.Text = "KHÓA TÀI KHOẢN";
        lblPermissionRuleTitle.Text = "QUY TẮC PHÂN QUYỀN HỆ THỐNG";
        lblPermissionAdminTitle.Text = "ADMIN";
        lblPermissionAdminBody.Text = "Quản trị toàn diện và giám sát các hoạt động hệ thống tối cao.";
        lblPermissionStaffTitle.Text = "NHÂN VIÊN (STAFF)";
        lblPermissionStaffBody.Text = "Vận hành các quy trình tác nghiệp: Tuyển sinh, thu phí, xếp lớp.";
        lblPermissionTeacherTitle.Text = "GIÁO VIÊN (TEACHER)";
        lblPermissionTeacherBody.Text = "Truy cập học liệu, quản lý lớp học được giảng dạy và đánh giá học viên.";
        lblPermissionFooter.Text = "LINGUISTIC ARCHITECT SECURITY PROTOCOL V2.4";
        btnSearchAccount.Text = "Tìm";
        btnRefreshAccount.Text = "Mới";

        cboAccountRoleFilter.Items.Clear();
        cboAccountRoleFilter.Items.AddRange(["Tất cả", "Admin", "Staff", "Teacher"]);
        cboAccountRoleFilter.SelectedIndex = 0;

        cboAccountRole.Items.Clear();
        cboAccountRole.Items.AddRange(["Admin", "Staff", "Teacher"]);
        cboAccountRole.SelectedIndex = 0;
    }

    private void ConfigureVisualStyle()
    {
        BackColor = Color.FromArgb(241, 248, 255);
        Padding = new Padding(20);
        MinimumSize = new Size(920, 640);

        tblAccountRoot.Padding = Padding.Empty;
        tblAccountRoot.BackColor = Color.Transparent;
        tblAccountRoot.AutoScroll = false;

        pnlAccountListColumn.BackColor = Color.FromArgb(231, 244, 255);
        pnlAccountDetailColumn.BackColor = Color.Transparent;
        pnlAccountListColumn.AutoScroll = false;
        pnlAccountDetailColumn.AutoScroll = false;
        pnlAccountInfoCard.Dock = DockStyle.Top;
        pnlPermissionRuleCard.Dock = DockStyle.Fill;

        lblAccountListTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblAccountTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblAccountIdentifier.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
        lblAccountIdentifier.ForeColor = Color.FromArgb(100, 112, 126);

        StyleSurfacePanel(pnlAccountFilterCard, Color.FromArgb(231, 244, 255));
        StyleSurfacePanel(pnlAccountInfoCard, Color.White);
        StyleSurfacePanel(pnlPermissionRuleCard, Color.FromArgb(224, 243, 255));

        StyleInput(txtAccountKeyword);
        StyleInput(txtDisplayName);
        StyleInput(txtUsername);
        StyleInput(txtEmail);
        StyleInput(txtPhone);
        StyleCombo(cboAccountRoleFilter);
        StyleCombo(cboAccountRole);

        StylePrimaryAction(btnCreateAccount, Color.FromArgb(11, 79, 144), Color.White);
        StylePrimaryAction(btnSaveAccount, Color.FromArgb(8, 87, 146), Color.White);
        StylePrimaryAction(btnResetPassword, Color.FromArgb(218, 236, 248), Color.FromArgb(58, 77, 98));
        StylePrimaryAction(btnToggleAccountStatus, Color.FromArgb(249, 229, 231), Color.FromArgb(181, 73, 91));
        StylePrimaryAction(btnSearchAccount, Color.White, Color.FromArgb(58, 77, 98));
        StylePrimaryAction(btnRefreshAccount, Color.White, Color.FromArgb(58, 77, 98));

        StylePermissionPanel(pnlPermissionAdmin, lblPermissionAdminTitle, Color.FromArgb(9, 80, 144), Color.White);
        StylePermissionPanel(pnlPermissionStaff, lblPermissionStaffTitle, Color.FromArgb(148, 164, 185), Color.White);
        StylePermissionPanel(pnlPermissionTeacher, lblPermissionTeacherTitle, Color.FromArgb(28, 148, 136), Color.White);

        flpAccountCards.BackColor = Color.Transparent;
        flpAccountCards.Padding = new Padding(0, 8, 0, 0);
        flpAccountCards.WrapContents = false;
        flpAccountCards.AutoScroll = true;

        flpAccountActions.Padding = new Padding(0, 12, 0, 0);
        flpAccountActions.AutoSize = true;
        flpAccountActions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        flpAccountActions.WrapContents = true;
        flpAccountActions.Dock = DockStyle.Top;

        flpAccountStatus.Padding = new Padding(0, 6, 0, 0);
        flpAccountStatus.WrapContents = true;

        tblAccountInfo.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
        tblAccountInfo.AutoSize = false;
        tblAccountInfo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        tblAccountInfo.Dock = DockStyle.Fill;

        ConfigureAccountStructure();
        LayoutFilterCard();
        LayoutDetailCards();
    }

    private void ConfigureAccountStructure()
    {
        ConfigureAccountListStructure();
        ConfigureAccountDetailStructure();
    }

    private void ConfigureAccountListStructure()
    {
        var listLayout = new TableLayoutPanel
        {
            Name = "tblAccountListLayout",
            BackColor = Color.Transparent,
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
            Margin = Padding.Empty,
            Padding = Padding.Empty
        };
        listLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        listLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
        listLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
        listLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        lblAccountListTitle.AutoSize = false;
        lblAccountListTitle.Dock = DockStyle.Fill;
        lblAccountListTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblAccountListTitle.Margin = Padding.Empty;

        pnlAccountFilterCard.Dock = DockStyle.Fill;
        pnlAccountFilterCard.Margin = new Padding(0, 0, 0, 8);

        flpAccountCards.Dock = DockStyle.Fill;
        flpAccountCards.FlowDirection = FlowDirection.TopDown;
        flpAccountCards.WrapContents = false;
        flpAccountCards.AutoScroll = false;
        flpAccountCards.AutoScrollMargin = Size.Empty;
        flpAccountCards.AutoScrollMinSize = Size.Empty;
        flpAccountCards.Margin = Padding.Empty;

        pnlAccountListColumn.SuspendLayout();
        pnlAccountListColumn.Controls.Clear();
        listLayout.Controls.Add(lblAccountListTitle, 0, 0);
        listLayout.Controls.Add(pnlAccountFilterCard, 0, 1);
        listLayout.Controls.Add(flpAccountCards, 0, 2);
        pnlAccountListColumn.Controls.Add(listLayout);
        pnlAccountListColumn.ResumeLayout(true);
    }

    private void ConfigureAccountDetailStructure()
    {
        var detailLayout = new TableLayoutPanel
        {
            Name = "tblAccountDetailLayout",
            BackColor = Color.Transparent,
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
            Margin = Padding.Empty,
            Padding = Padding.Empty
        };
        detailLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        detailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 94F));
        detailLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 274F));
        detailLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        pnlAccountHeader.Dock = DockStyle.Fill;
        pnlAccountHeader.Margin = new Padding(0, 0, 0, 8);
        pnlAccountHeader.Height = 94;

        ConfigureAccountInfoCardStructure();
        ConfigurePermissionCardStructure();

        pnlAccountDetailColumn.SuspendLayout();
        pnlAccountDetailColumn.Controls.Clear();
        detailLayout.Controls.Add(pnlAccountHeader, 0, 0);
        detailLayout.Controls.Add(pnlAccountInfoCard, 0, 1);
        detailLayout.Controls.Add(pnlPermissionRuleCard, 0, 2);
        pnlAccountDetailColumn.Controls.Add(detailLayout);
        pnlAccountDetailColumn.ResumeLayout(true);
    }

    private void ConfigureAccountInfoCardStructure()
    {
        var infoLayout = new TableLayoutPanel
        {
            Name = "tblAccountInfoCardLayout",
            BackColor = Color.Transparent,
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2,
            Margin = Padding.Empty,
            Padding = Padding.Empty
        };
        infoLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        infoLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        infoLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));

        tblAccountInfo.RowStyles.Clear();
        tblAccountInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tblAccountInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        tblAccountInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tblAccountInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
        tblAccountInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
        tblAccountInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblAccountInfo.Margin = Padding.Empty;
        tblAccountInfo.Dock = DockStyle.Fill;

        flpAccountActions.AutoSize = false;
        flpAccountActions.Dock = DockStyle.Fill;
        flpAccountActions.Margin = Padding.Empty;
        flpAccountActions.Padding = new Padding(0, 10, 0, 0);
        flpAccountActions.WrapContents = false;

        pnlAccountInfoCard.Dock = DockStyle.Fill;
        pnlAccountInfoCard.Margin = new Padding(0, 0, 0, 12);
        pnlAccountInfoCard.Padding = new Padding(24, 20, 24, 18);

        pnlAccountInfoCard.SuspendLayout();
        pnlAccountInfoCard.Controls.Clear();
        infoLayout.Controls.Add(tblAccountInfo, 0, 0);
        infoLayout.Controls.Add(flpAccountActions, 0, 1);
        pnlAccountInfoCard.Controls.Add(infoLayout);
        pnlAccountInfoCard.ResumeLayout(true);
    }

    private void ConfigurePermissionCardStructure()
    {
        pnlPermissionRuleCard.Dock = DockStyle.Fill;
        pnlPermissionRuleCard.Margin = Padding.Empty;
        pnlPermissionRuleCard.Padding = new Padding(24, 18, 24, 16);
        pnlPermissionRuleCard.AutoScroll = false;

        lblPermissionRuleTitle.AutoSize = false;
        lblPermissionRuleTitle.Dock = DockStyle.Top;
        lblPermissionRuleTitle.Height = 34;
        lblPermissionRuleTitle.TextAlign = ContentAlignment.MiddleLeft;

        lblPermissionFooter.AutoSize = false;
        lblPermissionFooter.Dock = DockStyle.Bottom;
        lblPermissionFooter.Height = 26;
        lblPermissionFooter.TextAlign = ContentAlignment.MiddleLeft;

        tblPermissionCards.Dock = DockStyle.Fill;
        tblPermissionCards.Margin = new Padding(0, 6, 0, 8);
        ConfigurePermissionPanelContent(pnlPermissionAdmin, lblPermissionAdminTitle, lblPermissionAdminBody);
        ConfigurePermissionPanelContent(pnlPermissionStaff, lblPermissionStaffTitle, lblPermissionStaffBody);
        ConfigurePermissionPanelContent(pnlPermissionTeacher, lblPermissionTeacherTitle, lblPermissionTeacherBody);

        pnlPermissionRuleCard.SuspendLayout();
        pnlPermissionRuleCard.Controls.Clear();
        pnlPermissionRuleCard.Controls.Add(tblPermissionCards);
        pnlPermissionRuleCard.Controls.Add(lblPermissionFooter);
        pnlPermissionRuleCard.Controls.Add(lblPermissionRuleTitle);
        pnlPermissionRuleCard.ResumeLayout(true);
    }

    private void ConfigureResponsiveLayout()
    {
        Resize += (_, _) =>
        {
            LayoutFilterCard();
            LayoutDetailCards();
            ApplyResponsiveBreakpoints();
        };

        flpAccountCards.Resize += (_, _) => ResizeAccountCards();
        ApplyResponsiveBreakpoints();
    }

    private static void ConfigurePermissionPanelContent(Panel panel, Label title, Label body)
    {
        panel.SuspendLayout();
        panel.Controls.Clear();
        panel.Padding = new Padding(18, 16, 18, 16);

        title.AutoSize = false;
        title.Dock = DockStyle.Top;
        title.Height = 34;
        title.TextAlign = ContentAlignment.MiddleLeft;

        body.AutoSize = false;
        body.Dock = DockStyle.Fill;
        body.TextAlign = ContentAlignment.TopLeft;
        body.MaximumSize = Size.Empty;
        body.Padding = new Padding(0, 8, 0, 0);
        body.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

        panel.Controls.Add(body);
        panel.Controls.Add(title);
        panel.ResumeLayout(true);
    }

    private void ApplyResponsiveBreakpoints()
    {
        var compact = ClientSize.Width < 1240;

        ConfigureRootLayout(compact);
        ConfigurePermissionLayout(compact);
        LayoutDetailCards();

        btnCreateAccount.Width = compact ? 180 : 217;
        lblAccountTitle.Font = compact
            ? new Font("Segoe UI", 16F, FontStyle.Bold)
            : new Font("Segoe UI", 18F, FontStyle.Bold);
    }

    private void ConfigureRootLayout(bool compact)
    {
        tblAccountRoot.SuspendLayout();
        tblAccountRoot.Controls.Clear();
        tblAccountRoot.ColumnStyles.Clear();
        tblAccountRoot.RowStyles.Clear();

        if (compact)
        {
            tblAccountRoot.ColumnCount = 1;
            tblAccountRoot.RowCount = 2;
            tblAccountRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblAccountRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 290F));
            tblAccountRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            pnlAccountListColumn.Padding = new Padding(0, 0, 0, 18);
            pnlAccountDetailColumn.Padding = Padding.Empty;

            tblAccountRoot.Controls.Add(pnlAccountListColumn, 0, 0);
            tblAccountRoot.Controls.Add(pnlAccountDetailColumn, 0, 1);
        }
        else
        {
            tblAccountRoot.ColumnCount = 2;
            tblAccountRoot.RowCount = 1;
            tblAccountRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tblAccountRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66F));
            tblAccountRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            pnlAccountListColumn.Padding = new Padding(0, 0, 20, 0);
            pnlAccountDetailColumn.Padding = new Padding(8, 0, 0, 0);

            tblAccountRoot.Controls.Add(pnlAccountListColumn, 0, 0);
            tblAccountRoot.Controls.Add(pnlAccountDetailColumn, 1, 0);
        }

        tblAccountRoot.ResumeLayout(true);
    }

    private void ConfigurePermissionLayout(bool compact)
    {
        tblPermissionCards.SuspendLayout();
        tblPermissionCards.Controls.Clear();
        tblPermissionCards.ColumnStyles.Clear();
        tblPermissionCards.RowStyles.Clear();

        if (compact)
        {
            tblPermissionCards.ColumnCount = 1;
            tblPermissionCards.RowCount = 3;
            tblPermissionCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblPermissionCards.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tblPermissionCards.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tblPermissionCards.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));

            AddPermissionCard(pnlPermissionAdmin, 0, 0, new Padding(0, 0, 0, 12));
            AddPermissionCard(pnlPermissionStaff, 0, 1, new Padding(0, 0, 0, 12));
            AddPermissionCard(pnlPermissionTeacher, 0, 2, Padding.Empty);
        }
        else
        {
            tblPermissionCards.ColumnCount = 3;
            tblPermissionCards.RowCount = 1;
            tblPermissionCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tblPermissionCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tblPermissionCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tblPermissionCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            AddPermissionCard(pnlPermissionAdmin, 0, 0, new Padding(0, 0, 12, 0));
            AddPermissionCard(pnlPermissionStaff, 1, 0, new Padding(0, 0, 12, 0));
            AddPermissionCard(pnlPermissionTeacher, 2, 0, Padding.Empty);
        }

        tblPermissionCards.ResumeLayout(true);
    }

    private void AddPermissionCard(Control card, int column, int row, Padding margin)
    {
        card.Dock = DockStyle.Fill;
        card.Margin = margin;
        tblPermissionCards.Controls.Add(card, column, row);
    }

    private void LayoutFilterCard()
    {
        pnlAccountFilterCard.SuspendLayout();
        pnlAccountFilterCard.Controls.Clear();
        pnlAccountFilterCard.AutoScroll = false;
        pnlAccountFilterCard.Padding = new Padding(0, 10, 0, 0);

        var filterLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 4,
            RowCount = 1,
            Margin = Padding.Empty,
            Padding = Padding.Empty
        };
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 64F));
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
        filterLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        cboAccountRoleFilter.Dock = DockStyle.Fill;
        cboAccountRoleFilter.Margin = new Padding(0, 2, 8, 8);
        txtAccountKeyword.Dock = DockStyle.Fill;
        txtAccountKeyword.Margin = new Padding(0, 1, 8, 8);
        btnSearchAccount.Dock = DockStyle.Fill;
        btnSearchAccount.Margin = new Padding(0, 0, 8, 8);
        btnRefreshAccount.Dock = DockStyle.Fill;
        btnRefreshAccount.Margin = new Padding(0, 0, 0, 8);

        filterLayout.Controls.Add(cboAccountRoleFilter, 0, 0);
        filterLayout.Controls.Add(txtAccountKeyword, 1, 0);
        filterLayout.Controls.Add(btnSearchAccount, 2, 0);
        filterLayout.Controls.Add(btnRefreshAccount, 3, 0);
        pnlAccountFilterCard.Controls.Add(filterLayout);
        pnlAccountFilterCard.ResumeLayout(true);
    }

    private void LayoutDetailCards()
    {
        var infoHeight = tblAccountInfo.GetPreferredSize(new Size(Math.Max(420, pnlAccountInfoCard.ClientSize.Width), 0)).Height
            + flpAccountActions.GetPreferredSize(new Size(Math.Max(420, pnlAccountInfoCard.ClientSize.Width), 0)).Height
            + pnlAccountInfoCard.Padding.Vertical
            + 12;

        if (pnlAccountDetailColumn.Controls.OfType<TableLayoutPanel>().FirstOrDefault(panel => panel.Name == "tblAccountDetailLayout") is { } detailLayout
            && detailLayout.RowStyles.Count > 1)
        {
            detailLayout.RowStyles[1].Height = Math.Clamp(infoHeight, 248, 292);
        }
    }

    private void WireEvents()
    {
        btnSearchAccount.Click += (_, _) => ApplyFilters();
        btnRefreshAccount.Click += (_, _) => ResetFilters();
        txtAccountKeyword.TextChanged += (_, _) => ApplyFilters();
        cboAccountRoleFilter.SelectedIndexChanged += (_, _) => ApplyFilters();
        btnCreateAccount.Click += (_, _) => StartCreatingAccount();
        btnSaveAccount.Click += (_, _) => SaveCurrentAccountPersisted();
        btnResetPassword.Click += (_, _) => ResetSelectedAccountPassword();
        btnToggleAccountStatus.Click += (_, _) => ToggleSelectedAccountStatus();
        cboAccountRole.SelectedIndexChanged += (_, _) => HighlightPermissionRole(cboAccountRole.Text);
    }

    private void SeedAccounts()
    {
        _accounts.Clear();

        foreach (var account in _dataService.GetAccounts())
        {
            _accounts.Add(AccountRecord.FromEntity(account));
        }
    }

    private void ReloadAccounts(string? preferredAccountId = null)
    {
        SeedAccounts();
        if (!string.IsNullOrWhiteSpace(preferredAccountId))
        {
            _selectedAccount = _accounts.FirstOrDefault(account => account.AccountId == preferredAccountId);
        }

        ApplyFilters();
    }

    private void ApplyFilters()
    {
        var keyword = txtAccountKeyword.Text.Trim();
        var roleFilter = cboAccountRoleFilter.SelectedItem?.ToString() ?? "Tất cả";

        var filteredAccounts = _accounts.Where(account =>
            (string.IsNullOrWhiteSpace(keyword)
                || account.DisplayName.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                || account.Username.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                || account.AccountId.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            && (roleFilter == "Tất cả"
                || account.Role.Equals(roleFilter, StringComparison.OrdinalIgnoreCase)))
            .ToList();

        RenderAccountCards(filteredAccounts);

        if (_selectedAccount is null || filteredAccounts.All(account => account.AccountId != _selectedAccount.AccountId))
        {
            SelectAccount(filteredAccounts.FirstOrDefault());
            return;
        }

        RefreshCardSelection();
    }

    private void ResetFilters()
    {
        txtAccountKeyword.Clear();
        cboAccountRoleFilter.SelectedIndex = 0;
        ApplyFilters();
    }

    private void RenderAccountCards(IEnumerable<AccountRecord> accounts)
    {
        flpAccountCards.SuspendLayout();
        flpAccountCards.Controls.Clear();
        _accountCards.Clear();

        foreach (var account in accounts)
        {
            var card = CreateAccountCard(account);
            _accountCards[account.AccountId] = card;
            flpAccountCards.Controls.Add(card);
        }

        flpAccountCards.ResumeLayout(true);
        ResizeAccountCards();
        RefreshCardSelection();
    }

    private Panel CreateAccountCard(AccountRecord account)
    {
        var card = new Panel
        {
            Height = 100,
            Margin = new Padding(0, 0, 0, 12),
            Padding = new Padding(16, 12, 14, 12),
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Cursor = Cursors.Hand,
            Tag = account
        };

        var accent = new Panel
        {
            Dock = DockStyle.Left,
            Width = 5,
            BackColor = GetRoleColor(account.Role)
        };

        var avatar = new Label
        {
            Location = new Point(20, 20),
            Size = new Size(44, 44),
            BackColor = Color.FromArgb(236, 241, 247),
            ForeColor = Color.FromArgb(57, 74, 95),
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            Text = GetInitials(account.DisplayName)
        };

        var nameLabel = new Label
        {
            AutoSize = false,
            Location = new Point(82, 14),
            Size = new Size(292, 27),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(31, 41, 55),
            Text = account.DisplayName
        };

        var usernameLabel = new Label
        {
            AutoSize = false,
            Location = new Point(82, 40),
            Size = new Size(292, 21),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            Font = new Font("Segoe UI", 8.5F),
            ForeColor = Color.FromArgb(99, 115, 129),
            Text = account.Username
        };

        var roleBadge = new Label
        {
            AutoSize = false,
            Location = new Point(82, 66),
            Size = new Size(96, 22),
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
            Text = account.Role.ToUpperInvariant(),
            BackColor = GetRoleBadgeBackColor(account.Role),
            ForeColor = GetRoleBadgeForeColor(account.Role)
        };

        card.Controls.Add(roleBadge);
        card.Controls.Add(usernameLabel);
        card.Controls.Add(nameLabel);
        card.Controls.Add(avatar);
        card.Controls.Add(accent);

        BindCardClick(card, account);
        return card;
    }

    private void BindCardClick(Control root, AccountRecord account)
    {
        root.Click += (_, _) => SelectAccount(account);
        foreach (Control child in root.Controls)
        {
            BindCardClick(child, account);
        }
    }

    private void ResizeAccountCards()
    {
        var width = Math.Max(120, flpAccountCards.ClientSize.Width - 8);
        foreach (Control control in flpAccountCards.Controls)
        {
            control.Width = width;
        }
    }

    private void SelectAccount(AccountRecord? account)
    {
        _selectedAccount = account;
        _creatingAccount = account is null;

        if (account is null)
        {
            ClearDetailPanel();
            return;
        }

        lblAccountIdentifier.Text = $"ID: {account.AccountId}";
        txtDisplayName.Text = account.DisplayName;
        txtUsername.Text = account.Username;
        txtEmail.Text = account.Email;
        txtPhone.Text = account.Phone;
        cboAccountRole.SelectedItem = account.Role;
        rdoAccountActive.Checked = account.Status == "Hoạt động";
        rdoAccountLocked.Checked = account.Status != "Hoạt động";
        btnToggleAccountStatus.Text = "KHÓA TÀI KHOẢN";
        HighlightPermissionRole(account.Role);
        RefreshCardSelection();
    }

    private void ClearDetailPanel()
    {
        lblAccountIdentifier.Text = "ID: --";
        txtDisplayName.Clear();
        txtUsername.Clear();
        txtEmail.Clear();
        txtPhone.Clear();
        cboAccountRole.SelectedIndex = 0;
        rdoAccountActive.Checked = true;
        btnToggleAccountStatus.Text = "KHÓA TÀI KHOẢN";
        HighlightPermissionRole(cboAccountRole.Text);
        RefreshCardSelection();
    }

    private void RefreshCardSelection()
    {
        foreach (var entry in _accountCards)
        {
            var isActive = _selectedAccount is not null && entry.Key == _selectedAccount.AccountId;
            entry.Value.BackColor = isActive ? Color.FromArgb(218, 238, 255) : Color.White;
        }
    }

    private void StartCreatingAccount()
    {
        _creatingAccount = true;
        _selectedAccount = null;
        errAccount.Clear();
        lblAccountIdentifier.Text = $"ID: {_dataService.GetNextAccountId()}";
        txtDisplayName.Clear();
        txtUsername.Clear();
        txtEmail.Clear();
        txtPhone.Clear();
        cboAccountRole.SelectedIndex = 0;
        rdoAccountActive.Checked = true;
        btnToggleAccountStatus.Text = "KHÓA TÀI KHOẢN";
        HighlightPermissionRole(cboAccountRole.Text);
        RefreshCardSelection();
        txtDisplayName.Focus();
    }

    private void SaveCurrentAccountPersisted()
    {
        if (!ValidateInputs())
        {
            return;
        }

        try
        {
            var accountId = _creatingAccount || _selectedAccount is null
                ? lblAccountIdentifier.Text.Replace("ID:", string.Empty).Trim()
                : _selectedAccount.AccountId;

            var savedAccount = _dataService.SaveAccount(new AccountEntity
            {
                Id = accountId,
                Username = txtUsername.Text.Trim(),
                PasswordHash = string.Empty,
                DisplayName = txtDisplayName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Role = Enum.TryParse<AccountRole>(cboAccountRole.Text, true, out var role) ? role : AccountRole.Staff,
                Status = rdoAccountActive.Checked ? AccountStatus.Active : AccountStatus.Locked,
                IsDeleted = false
            });

            _creatingAccount = false;
            ReloadAccounts(savedAccount.Id);
            MessageBox.Show(this, "Đã lưu tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, nameof(FrmAccountManagement));
            MessageBox.Show(this, "Không lưu được tài khoản. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ResetSelectedAccountPassword()
    {
        if (_selectedAccount is null)
        {
            MessageBox.Show(this, "Chọn tài khoản cần đặt lại mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            const string temporaryPassword = "123456";
            _dataService.ResetAccountPassword(_selectedAccount.AccountId, temporaryPassword);
            MessageBox.Show(
                this,
                $"Mật khẩu tạm thời của tài khoản {_selectedAccount.Username} đã được đặt lại thành {temporaryPassword}.",
                "Đặt lại mật khẩu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, nameof(FrmAccountManagement));
            MessageBox.Show(this, "Không đặt lại được mật khẩu. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ToggleSelectedAccountStatus()
    {
        if (_selectedAccount is null)
        {
            rdoAccountLocked.Checked = !rdoAccountActive.Checked;
            return;
        }

        try
        {
            _dataService.ToggleAccountStatus(_selectedAccount.AccountId);
            ReloadAccounts(_selectedAccount.AccountId);
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, nameof(FrmAccountManagement));
            MessageBox.Show(this, "Không đổi được trạng thái tài khoản. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SaveCurrentAccount()
    {
        if (!ValidateInputs())
        {
            return;
        }
        var status = rdoAccountActive.Checked ? "Hoạt động" : "Khóa";

        if (_creatingAccount || _selectedAccount is null)
        {
            var newAccount = new AccountRecord
            {
                AccountId = lblAccountIdentifier.Text.Replace("ID:", string.Empty).Trim(),
                DisplayName = txtDisplayName.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Role = cboAccountRole.Text,
                Status = status
            };

            _accounts.Insert(0, newAccount);
            _selectedAccount = newAccount;
            _creatingAccount = false;
        }
        else
        {
            _selectedAccount.DisplayName = txtDisplayName.Text.Trim();
            _selectedAccount.Username = txtUsername.Text.Trim();
            _selectedAccount.Email = txtEmail.Text.Trim();
            _selectedAccount.Phone = txtPhone.Text.Trim();
            _selectedAccount.Role = cboAccountRole.Text;
            _selectedAccount.Status = status;
        }

        ApplyFilters();
    }

    private bool ValidateInputs()
    {
        errAccount.Clear();
        var valid = true;

        if (string.IsNullOrWhiteSpace(txtDisplayName.Text))
        {
            errAccount.SetError(txtDisplayName, "Nhập họ và tên.");
            valid = false;
        }

        if (string.IsNullOrWhiteSpace(txtUsername.Text))
        {
            errAccount.SetError(txtUsername, "Nhập tên đăng nhập.");
            valid = false;
        }

        if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains('@'))
        {
            errAccount.SetError(txtEmail, "Email chưa hợp lệ.");
            valid = false;
        }

        if (string.IsNullOrWhiteSpace(txtPhone.Text))
        {
            errAccount.SetError(txtPhone, "Nhập số điện thoại.");
            valid = false;
        }

        return valid;
    }

    private void ResetPasswordForCurrentAccount()
    {
        if (_selectedAccount is null && !_creatingAccount)
        {
            return;
        }

        MessageBox.Show(
            "Mật khẩu tạm thời đã được cấp lại cho tài khoản đang chọn.",
            "Đặt lại mật khẩu",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void ToggleCurrentAccountStatus()
    {
        if (_selectedAccount is null)
        {
            rdoAccountLocked.Checked = !rdoAccountActive.Checked;
            return;
        }
        _selectedAccount.Status = _selectedAccount.Status == "Hoạt động" ? "Khóa" : "Hoạt động";
        SelectAccount(_selectedAccount);
        ApplyFilters();
    }

    private void HighlightPermissionRole(string role)
    {
        ApplyPermissionState(pnlPermissionAdmin, lblPermissionAdminTitle, role == "Admin", Color.FromArgb(9, 80, 144));
        ApplyPermissionState(pnlPermissionStaff, lblPermissionStaffTitle, role == "Staff", Color.FromArgb(128, 145, 170));
        ApplyPermissionState(pnlPermissionTeacher, lblPermissionTeacherTitle, role == "Teacher", Color.FromArgb(28, 148, 136));
    }

    private static void ApplyPermissionState(Panel panel, Label title, bool active, Color accent)
    {
        panel.BackColor = active ? ControlPaint.Light(accent, 0.88F) : Color.White;
        panel.Padding = new Padding(16, 14, 16, 14);
        title.ForeColor = accent;
    }

    private static void StyleSurfacePanel(Panel panel, Color backColor)
    {
        panel.BackColor = backColor;
        panel.BorderStyle = BorderStyle.FixedSingle;
        panel.Margin = new Padding(0, 0, 0, 18);
    }

    private static void StyleInput(TextBox textBox)
    {
        textBox.BorderStyle = BorderStyle.FixedSingle;
        textBox.BackColor = Color.White;
        textBox.Margin = new Padding(3, 0, 16, 12);
        textBox.Dock = DockStyle.Fill;
    }

    private static void StyleCombo(ComboBox comboBox)
    {
        comboBox.FlatStyle = FlatStyle.Flat;
        comboBox.BackColor = Color.White;
        comboBox.Margin = new Padding(3, 0, 16, 12);
    }

    private static void StylePrimaryAction(Button button, Color backColor, Color foreColor)
    {
        button.BackColor = backColor;
        button.ForeColor = foreColor;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.Cursor = Cursors.Hand;
        button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        button.Height = 38;
        button.Margin = new Padding(0, 0, 10, 10);
    }

    private static void StylePermissionPanel(Panel panel, Label titleLabel, Color accent, Color background)
    {
        panel.BackColor = background;
        panel.BorderStyle = BorderStyle.FixedSingle;
        titleLabel.ForeColor = accent;
    }

    private static Color GetRoleColor(string role) => role switch
    {
        "Admin" => Color.FromArgb(9, 80, 144),
        "Staff" => Color.FromArgb(102, 112, 133),
        _ => Color.FromArgb(28, 148, 136)
    };

    private static Color GetRoleBadgeBackColor(string role) => role switch
    {
        "Admin" => Color.FromArgb(216, 231, 247),
        "Staff" => Color.FromArgb(235, 239, 244),
        _ => Color.FromArgb(214, 244, 240)
    };

    private static Color GetRoleBadgeForeColor(string role) => role switch
    {
        "Admin" => Color.FromArgb(9, 80, 144),
        "Staff" => Color.FromArgb(80, 93, 110),
        _ => Color.FromArgb(18, 118, 107)
    };

    private static string GetInitials(string displayName)
    {
        var parts = displayName
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Take(2)
            .Select(part => char.ToUpperInvariant(part[0]));

        return string.Concat(parts);
    }

    private sealed class AccountRecord
    {
        public required string AccountId { get; set; }
        public required string Username { get; set; }
        public required string DisplayName { get; set; }
        public required string Role { get; set; }
        public required string Status { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }

        public static AccountRecord FromEntity(AccountEntity entity)
        {
            return new AccountRecord
            {
                AccountId = entity.Id,
                Username = entity.Username,
                DisplayName = entity.DisplayName,
                Email = entity.Email,
                Phone = entity.Phone,
                Role = entity.Role.ToString(),
                Status = entity.Status == AccountStatus.Active ? "Hoạt động" : "Khóa"
            };
        }
    }

    private void pnlPermissionRuleCard_Paint(object sender, PaintEventArgs e)
    {
    }

    private void btnToggleAccountStatus_Click(object sender, EventArgs e)
    {
    }
}
