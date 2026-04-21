namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAdminDashboard : Form
{
    private readonly string _currentUserName;

    public FrmAdminDashboard() : this("admin")
    {
    }

    public FrmAdminDashboard(string currentUserName)
    {
        _currentUserName = currentUserName;
        InitializeComponent();
        FormHostHelpers.ConfigureShellSurface(this, "Quản trị hệ thống");
        ConfigureRuntimeBehavior();
        ShowAccessMatrix();
    }

    private void ConfigureRuntimeBehavior()
    {
        lblCurrentUserAdmin.Text = "System Admin";
        lblCurrentRoleAdmin.Text = "Precision Access";
        lblAppBrandAdmin.Text = "LINGUISTIC ARCHITECT";
        btnMenuAdminFinance.Visible = false;

        btnMenuAdminDashboard.Click += (_, _) => ShowAccessMatrix();
        btnMenuSystemMonitor.Click += (_, _) => OpenModule(new FrmSystemMonitor(), btnMenuSystemMonitor);
        btnMenuAccountManagement.Click += (_, _) => OpenModule(new FrmAccountManagement(), btnMenuAccountManagement);
        btnMenuAdminReports.Click += (_, _) => OpenModule(new FrmAdminReports(), btnMenuAdminReports);
        btnAddRoleAdmin.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Thêm vai trò", "UI demo đã sẵn sàng để backend nối quy trình tạo vai trò mới.");
            dialog.ShowDialog(this);
        };
        btnSidebarSupport.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Hỗ trợ", "Liên kết tài liệu hỗ trợ sẽ được nối ở tầng backend hoặc cấu hình sau.");
            dialog.ShowDialog(this);
        };
    }

    private void ShowAccessMatrix()
    {
        OpenModule(new FrmAccessMatrix(), btnMenuAdminDashboard);
        SetActiveMenuButton(btnMenuAdminDashboard);
    }

    private void OpenModule(Form moduleForm, Button activeButton)
    {
        FormHostHelpers.OpenChildForm(pnlContentHostAdmin, moduleForm);
        SetActiveMenuButton(activeButton);
    }

    private void SetActiveMenuButton(Button activeButton)
    {
        var menuButtons = new[]
        {
            btnMenuAdminDashboard,
            btnMenuSystemMonitor,
            btnMenuAccountManagement,
            btnMenuAdminReports
        };

        foreach (var button in menuButtons)
        {
            if (button == activeButton)
            {
                button.BackColor = AppTheme.SidebarActive;
                button.ForeColor = AppTheme.Accent;
                button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }
            else
            {
                button.BackColor = Color.Transparent;
                button.ForeColor = Color.FromArgb(55, 65, 81);
                button.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }
        }
    }
}
