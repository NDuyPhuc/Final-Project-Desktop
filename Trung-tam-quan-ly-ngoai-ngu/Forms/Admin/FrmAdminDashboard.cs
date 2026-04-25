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
        FormHostHelpers.ConfigureShellSurface(this, "Dashboard quản trị");
        ApplyShellStyling();
        BindDashboardData();
        WireEvents();
        ShowDashboardHome();
    }

    private void ApplyShellStyling()
    {
        lblCurrentUserAdmin.Text = _currentUserName;
        lblCurrentRoleAdmin.Text = "Admin";
        lblAdminUserCardName.Text = _currentUserName;
        lblAdminUserCardRole.Text = "Quản trị hệ thống";

        foreach (var card in new[]
                 {
                     pnlAdminHeroCard,
                     pnlKpiAccounts,
                     pnlKpiClasses,
                     pnlKpiRevenue,
                     pnlKpiDebt,
                     pnlAdminWarningsCard,
                     pnlAdminQuickViewCard,
                     pnlAdminUserCard
                 })
        {
            AppTheme.StyleCard(card);
        }

        foreach (var grid in new[] { dgvDashboardWarnings, dgvDashboardSnapshot })
        {
            AppTheme.StyleGrid(grid);
            grid.ReadOnly = true;
            grid.AllowUserToResizeRows = false;
        }

        AppTheme.StyleDangerButton(btnLogoutAdmin);

        var menuButtons = new[]
        {
            btnMenuAdminDashboard,
            btnMenuSystemMonitor,
            btnMenuAccountManagement,
            btnMenuAdminReports
        };

        foreach (var button in menuButtons)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Height = 46;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(18, 0, 0, 0);
        }
    }

    private void BindDashboardData()
    {
        dgvDashboardWarnings.DataSource = DemoDataFactory.GetAdminWarnings();
        dgvDashboardSnapshot.DataSource = DemoDataFactory.GetMonitorActivity();
    }

    private void WireEvents()
    {
        btnLogoutAdmin.Click += (_, _) => FormHostHelpers.OpenLoginAndClose(this);
        btnMenuAdminDashboard.Click += (_, _) => ShowDashboardHome();
        btnMenuSystemMonitor.Click += (_, _) => OpenModule(new FrmSystemMonitor(), btnMenuSystemMonitor);
        btnMenuAccountManagement.Click += (_, _) => OpenModule(new FrmAccountManagement(), btnMenuAccountManagement);
        btnMenuAdminReports.Click += (_, _) => OpenModule(new FrmAdminReports(), btnMenuAdminReports);
    }

    private void ShowDashboardHome()
    {
        pnlDashboardHome.Dock = DockStyle.Fill;
        pnlContentHostAdmin.Controls.Clear();
        pnlContentHostAdmin.Controls.Add(pnlDashboardHome);
        SetActiveMenuButton(btnMenuAdminDashboard);
    }

    private void OpenModule(Form moduleForm, Button activeButton)
    {
        FormHostHelpers.OpenChildForm(pnlContentHostAdmin, moduleForm);
        SetActiveMenuButton(activeButton);
    }

    private void SetActiveMenuButton(Button activeButton)
    {
        FormHostHelpers.SetActiveMenu(
            activeButton,
            btnMenuAdminDashboard,
            btnMenuSystemMonitor,
            btnMenuAccountManagement,
            btnMenuAdminReports);
    }

    private void pnlAdminHeroCard_Paint(object sender, PaintEventArgs e)
    {

    }
}
