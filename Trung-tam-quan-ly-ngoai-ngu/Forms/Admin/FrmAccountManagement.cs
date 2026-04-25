using System.ComponentModel;
using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAccountManagement : Form
{
    private readonly List<AccountRecord> _accounts = [];
    private readonly Dictionary<string, Panel> _accountCards = new();
    private AccountRecord? _selectedAccount;
    private bool _creatingAccount;

    public FrmAccountManagement()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Tài khoản và phân quyền");
        ApplyLocalizedText();
        ConfigureVisualStyle();
        WireEvents();
        SeedAccounts();
        ApplyFilters();
    }

    private void ApplyLocalizedText()
    {
        Text = "Tài khoản và phân quyền";
        lblAccountListTitle.Text = "Danh sách Tài khoản";
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
        lblPermissionStaffBody.Text = "Vận hành các quy trình tác nghiệp: Tuyển sinh, Thu phí, Xếp lớp.";
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
        AutoScroll = true;

        tblAccountRoot.Padding = new Padding(0);
        tblAccountRoot.BackColor = Color.Transparent;

        pnlAccountListColumn.BackColor = Color.FromArgb(231, 244, 255);
        pnlAccountDetailColumn.BackColor = Color.Transparent;

        lblAccountListTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblAccountTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblAccountIdentifier.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
        lblAccountIdentifier.ForeColor = Color.FromArgb(100, 112, 126);

        StyleSurfacePanel(pnlAccountFilterCard, Color.FromArgb(231, 244, 255), Color.FromArgb(209, 225, 241));
        StyleSurfacePanel(pnlAccountInfoCard, Color.White, Color.FromArgb(216, 228, 240));
        StyleSurfacePanel(pnlPermissionRuleCard, Color.FromArgb(224, 243, 255), Color.FromArgb(200, 221, 237));

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

        StylePermissionPanel(
            pnlPermissionAdmin,
            lblPermissionAdminTitle,
            Color.FromArgb(9, 80, 144),
            Color.White);
        StylePermissionPanel(
            pnlPermissionStaff,
            lblPermissionStaffTitle,
            Color.FromArgb(148, 164, 185),
            Color.White);
        StylePermissionPanel(
            pnlPermissionTeacher,
            lblPermissionTeacherTitle,
            Color.FromArgb(28, 148, 136),
            Color.White);

        flpAccountCards.BackColor = Color.Transparent;
        flpAccountCards.Padding = new Padding(0, 8, 0, 0);
        flpAccountCards.WrapContents = false;

        flpAccountActions.Padding = new Padding(0, 10, 0, 0);
        flpAccountActions.AutoSize = true;
        flpAccountActions.AutoSizeMode = AutoSizeMode.GrowAndShrink;

        flpAccountStatus.Padding = new Padding(0, 6, 0, 0);
        rdoAccountActive.ForeColor = Color.FromArgb(26, 38, 53);
        rdoAccountLocked.ForeColor = Color.FromArgb(26, 38, 53);

        tblAccountInfo.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
    }

    private void WireEvents()
    {
        btnSearchAccount.Click += (_, _) => ApplyFilters();
        btnRefreshAccount.Click += (_, _) => ResetFilters();
        txtAccountKeyword.TextChanged += (_, _) => ApplyFilters();
        cboAccountRoleFilter.SelectedIndexChanged += (_, _) => ApplyFilters();
        btnCreateAccount.Click += (_, _) => StartCreatingAccount();
        btnSaveAccount.Click += (_, _) => SaveCurrentAccount();
        btnResetPassword.Click += (_, _) => ResetPasswordForCurrentAccount();
        btnToggleAccountStatus.Click += (_, _) => ToggleCurrentAccountStatus();
        cboAccountRole.SelectedIndexChanged += (_, _) => HighlightPermissionRole(cboAccountRole.Text);
        flpAccountCards.Resize += (_, _) => ResizeAccountCards();
    }

    private void SeedAccounts()
    {
        _accounts.Clear();

        foreach (var account in CreateSampleAccounts())
        {
            _accounts.Add(account);
        }
    }

    private List<AccountRecord> CreateSampleAccounts()
    {
        var result = new List<AccountRecord>
        {
            new()
            {
                AccountId = "USER-8842-ANV",
                Username = "admin_an_nv",
                DisplayName = "Nguyễn Văn An",
                Role = "Admin",
                Status = "Hoạt động",
                Email = "an.nguyen@architect.edu.vn",
                Phone = "0905 123 456"
            },
            new()
            {
                AccountId = "USER-7721-BTB",
                Username = "bich.teacher",
                DisplayName = "Trần Thị Bích",
                Role = "Teacher",
                Status = "Hoạt động",
                Email = "bich.tran@architect.edu.vn",
                Phone = "0903 222 118"
            },
            new()
            {
                AccountId = "USER-4216-LMT",
                Username = "tam_staff_01",
                DisplayName = "Lê Minh Tâm",
                Role = "Staff",
                Status = "Hoạt động",
                Email = "tam.le@architect.edu.vn",
                Phone = "0908 417 015"
            },
            new()
            {
                AccountId = "USER-6084-PHN",
                Username = "phung.nguyen",
                DisplayName = "Phạm Hồng Nhung",
                Role = "Teacher",
                Status = "Khóa",
                Email = "nhung.pham@architect.edu.vn",
                Phone = "0907 610 228"
            }
        };

        var fallback = DemoDataFactory.GetAccountList();
        if (fallback.Rows.Count > result.Count)
        {
            foreach (DataRow row in fallback.Rows)
            {
                var username = row[0]?.ToString()?.Trim() ?? string.Empty;
                if (result.Exists(account => account.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }

                result.Add(new AccountRecord
                {
                    AccountId = $"USER-{7000 + result.Count * 37}-{username[..Math.Min(3, username.Length)].ToUpperInvariant()}",
                    Username = username,
                    DisplayName = row[1]?.ToString()?.Trim() ?? username,
                    Role = NormalizeRole(row[2]?.ToString()),
                    Status = NormalizeStatus(row[3]?.ToString()),
                    Email = $"{username.Replace('.', '_')}@architect.edu.vn",
                    Phone = $"090{result.Count + 1} 100 {120 + result.Count * 7:000}"
                });
            }
        }

        return result;
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

        flpAccountCards.ResumeLayout();
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
            Size = new Size(94, 22),
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
        var width = Math.Max(360, flpAccountCards.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 6);
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
        btnToggleAccountStatus.Text = account.Status == "Hoạt động" ? "KHÓA TÀI KHOẢN" : "MỞ KHÓA TÀI KHOẢN";
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
        lblAccountIdentifier.Text = $"ID: USER-{DateTime.Now:HHmm}-{_accounts.Count + 1:000}";
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

    private static void StyleSurfacePanel(Panel panel, Color backColor, Color borderColor)
    {
        panel.BackColor = backColor;
        panel.BorderStyle = BorderStyle.FixedSingle;
        panel.Margin = new Padding(0, 0, 0, 18);
        panel.Tag = borderColor;
    }

    private static void StyleInput(TextBox textBox)
    {
        textBox.BorderStyle = BorderStyle.FixedSingle;
        textBox.BackColor = Color.White;
        textBox.Margin = new Padding(3, 0, 16, 12);
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

    private static string NormalizeRole(string? rawRole)
    {
        if (string.IsNullOrWhiteSpace(rawRole))
        {
            return "Staff";
        }

        if (rawRole.Contains("Admin", StringComparison.OrdinalIgnoreCase))
        {
            return "Admin";
        }

        if (rawRole.Contains("Teacher", StringComparison.OrdinalIgnoreCase))
        {
            return "Teacher";
        }

        return "Staff";
    }

    private static string NormalizeStatus(string? rawStatus)
    {
        if (string.IsNullOrWhiteSpace(rawStatus))
        {
            return "Hoạt động";
        }

        return rawStatus.Contains("Inactive", StringComparison.OrdinalIgnoreCase)
            || rawStatus.Contains("Khóa", StringComparison.OrdinalIgnoreCase)
            ? "Khóa"
            : "Hoạt động";
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
    }

    private void pnlPermissionRuleCard_Paint(object sender, PaintEventArgs e)
    {

    }
}
