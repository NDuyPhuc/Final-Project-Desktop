using TrungTamNgoaiNgu.Application.Contracts;
using System.ComponentModel;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAdminDashboard : Form
{
    private readonly string _currentUserName;
    private readonly ILanguageCenterDataService _dataService;

    public FrmAdminDashboard() : this("admin", AppRuntime.DataService)
    {
    }

    public FrmAdminDashboard(string currentUserName) : this(currentUserName, AppRuntime.DataService)
    {
    }

    public FrmAdminDashboard(string currentUserName, ILanguageCenterDataService dataService)
    {
        _currentUserName = currentUserName;
        _dataService = dataService;

        InitializeComponent();

        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        {
            return;
        }

        FormHostHelpers.ConfigureShellSurface(this, "Dashboard quản trị");

        ApplyLocalizedText();
        ApplyShellStyling();
        ConfigureResponsiveLayout();
        BindDashboardData();
        WireEvents();
        ShowDashboardHome();
    }

    private void ApplyLocalizedText()
    {
        lblSidebarBrandTitle.Text = "ADMIN";
        lblSidebarBrandSubtitle.Text = "Quản trị hệ thống";
        lblAdminHeaderTitle.Text = "Dashboard Admin";
        lblAdminHeaderSubtitle.Text = "Chỉ hiển thị dữ liệu quản trị tổng hợp, không thao tác nghiệp vụ.";
        lblDashboardTitle.Text = "Dashboard quản trị";
        lblDashboardSubtitle.Text = "Theo dõi tài khoản, lớp đang mở, doanh thu đã thu và danh sách cảnh báo cần chú ý.";

        btnMenuAdminDashboard.Text = "Dashboard";
        btnMenuSystemMonitor.Text = "Giám sát hệ thống";
        btnMenuAccountManagement.Text = "Tài khoản và phân quyền";
        btnMenuAdminReports.Text = "Báo cáo thống kê";
        btnLogoutAdmin.Text = "Đăng xuất";
        lblKpiAccountsTitle.Text = "Tổng tài khoản";
        lblKpiAccountsNote.Text = "Toàn bộ tài khoản hệ thống";
        lblKpiClassesTitle.Text = "Lớp đang mở";
        lblKpiClassesNote.Text = "Lớp có lịch khai giảng gần nhất";
        lblKpiRevenueTitle.Text = "Doanh thu đã thu";
        lblKpiRevenueNote.Text = "Doanh thu đã xác nhận";
        lblKpiDebtTitle.Text = "Học viên còn nợ";
        lblKpiDebtNote.Text = "Học viên còn nợ cần theo dõi";
        lblAdminWarningsTitle.Text = "Cảnh báo quản trị";
        lblAdminWarningsHint.Text = "Danh sách read-only các cảnh báo cần Admin theo dõi.";
        lblAdminQuickViewTitle.Text = "Số liệu nhanh";
        lblAdminQuickViewHint.Text = "Số liệu nhanh để đánh giá tình hình trung tâm trước khi mở báo cáo chi tiết.";
    }

    private void ApplyShellStyling()
    {
        MinimumSize = new Size(1080, 720);
        pnlSidebarAdmin.Width = 252;
        pnlTopbarAdmin.Height = 122;
        pnlSidebarAdmin.Padding = new Padding(18, 18, 18, 16);
        pnlTopbarAdmin.Padding = new Padding(28, 16, 28, 16);
        pnlContentHostAdmin.Padding = new Padding(20, 0, 20, 20);

        lblAdminUserCardName.Text = _currentUserName;
        lblAdminUserCardRole.Text = "Quản trị hệ thống";

        pnlAdminUserCard.Width = 240;
        pnlAdminUserCard.Height = 74;
        pnlAdminUserCard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        LayoutAdminUserCard();

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
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
        }

        StyleSidebarButton(btnMenuAdminDashboard);
        StyleSidebarButton(btnMenuSystemMonitor);
        StyleSidebarButton(btnMenuAccountManagement);
        StyleSidebarButton(btnMenuAdminReports);
        AppTheme.StyleDangerButton(btnLogoutAdmin);

        lblDashboardTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblDashboardSubtitle.MaximumSize = new Size(960, 0);
        lblDashboardSubtitle.AutoSize = true;

        StyleKpiValue(lblKpiAccountsValue, Color.FromArgb(0, 66, 118));
        StyleKpiValue(lblKpiClassesValue, Color.FromArgb(0, 110, 110));
        StyleKpiValue(lblKpiRevenueValue, Color.FromArgb(124, 45, 18));
        StyleKpiValue(lblKpiDebtValue, AppTheme.Danger);
    }

    private void ConfigureResponsiveLayout()
    {
        tblAdminDashboardRoot.AutoSize = false;
        tblAdminDashboardRoot.Dock = DockStyle.Fill;
        tblAdminDashboardRoot.RowStyles[0] = new RowStyle(SizeType.AutoSize);
        tblAdminDashboardRoot.RowStyles[1] = new RowStyle(SizeType.AutoSize);
        tblAdminDashboardRoot.RowStyles[2] = new RowStyle(SizeType.Percent, 100F);

        splAdminDashboardBottom.FixedPanel = FixedPanel.None;
        splAdminDashboardBottom.Panel1MinSize = 320;
        splAdminDashboardBottom.Panel2MinSize = 320;
        splAdminDashboardBottom.SplitterWidth = 10;

        Resize += (_, _) => ApplyResponsiveBreakpoints();
        pnlContentHostAdmin.Resize += (_, _) => ApplyResponsiveBreakpoints();
        ApplyResponsiveBreakpoints();
    }

    private void ApplyResponsiveBreakpoints()
    {
        var contentWidth = Math.Max(920, pnlContentHostAdmin.ClientSize.Width);
        var compact = contentWidth < 1200;

        pnlAdminUserCard.Width = compact ? 220 : 248;
        lblAdminHeaderSubtitle.MaximumSize = new Size(compact ? 560 : 760, 0);
        LayoutAdminUserCard();

        ConfigureKpiLayout(compact);

        var desired = compact
            ? Math.Max(220, splAdminDashboardBottom.ClientSize.Height / 2)
            : Math.Max(320, splAdminDashboardBottom.ClientSize.Width / 2);

        FormHostHelpers.ApplyResponsiveSplit(
            splAdminDashboardBottom,
            compact ? Orientation.Horizontal : Orientation.Vertical,
            desired);
    }

    private void LayoutAdminUserCard()
    {
        var contentWidth = Math.Max(120, pnlAdminUserCard.ClientSize.Width - 32);

        lblAdminUserCardName.AutoSize = true;
        lblAdminUserCardName.MaximumSize = new Size(contentWidth, 0);
        lblAdminUserCardName.Location = new Point(16, 8);

        lblAdminUserCardRole.AutoSize = true;
        lblAdminUserCardRole.MaximumSize = new Size(contentWidth, 0);
        lblAdminUserCardRole.Location = new Point(16, lblAdminUserCardName.Bottom + 4);

        var desiredHeight = Math.Max(64, lblAdminUserCardRole.Bottom + 10);
        pnlAdminUserCard.Height = desiredHeight;
    }

    private void ConfigureKpiLayout(bool compact)
    {
        tblAdminKpi.SuspendLayout();
        tblAdminKpi.Controls.Clear();
        tblAdminKpi.ColumnStyles.Clear();
        tblAdminKpi.RowStyles.Clear();

        if (compact)
        {
            tblAdminKpi.ColumnCount = 2;
            tblAdminKpi.RowCount = 2;
            tblAdminKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblAdminKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblAdminKpi.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblAdminKpi.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            AddKpiCard(pnlKpiAccounts, 0, 0, new Padding(0, 0, 12, 12));
            AddKpiCard(pnlKpiClasses, 1, 0, new Padding(0, 0, 0, 12));
            AddKpiCard(pnlKpiRevenue, 0, 1, new Padding(0, 0, 12, 0));
            AddKpiCard(pnlKpiDebt, 1, 1, Padding.Empty);
            tblAdminKpi.Height = 272;
        }
        else
        {
            tblAdminKpi.ColumnCount = 4;
            tblAdminKpi.RowCount = 1;
            for (var i = 0; i < 4; i++)
            {
                tblAdminKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }

            tblAdminKpi.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            AddKpiCard(pnlKpiAccounts, 0, 0, new Padding(0, 0, 12, 0));
            AddKpiCard(pnlKpiClasses, 1, 0, new Padding(0, 0, 12, 0));
            AddKpiCard(pnlKpiRevenue, 2, 0, new Padding(0, 0, 12, 0));
            AddKpiCard(pnlKpiDebt, 3, 0, Padding.Empty);
            tblAdminKpi.Height = 128;
        }

        tblAdminKpi.ResumeLayout(true);
    }

    private void AddKpiCard(Control card, int column, int row, Padding margin)
    {
        card.Dock = DockStyle.Fill;
        card.Margin = margin;
        tblAdminKpi.Controls.Add(card, column, row);
    }

    private void StyleSidebarButton(Button button)
    {
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.Height = 46;
        button.Width = 206;
        button.TextAlign = ContentAlignment.MiddleLeft;
        button.Padding = new Padding(18, 0, 12, 0);
        button.Margin = new Padding(0, 0, 0, 8);
    }

    private static void StyleKpiValue(Label label, Color color)
    {
        label.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        label.ForeColor = color;
    }

    private void BindDashboardData()
    {
        var stats = _dataService.GetAdminDashboardStats();
        lblKpiAccountsValue.Text = _dataService.GetAccounts().Count.ToString();
        lblKpiClassesValue.Text = stats.TotalActiveClasses.ToString();
        lblKpiRevenueValue.Text = $"{stats.TotalRevenue:N0}";
        lblKpiDebtValue.Text = $"{stats.TotalDebt:N0}";
        dgvDashboardWarnings.DataSource = _dataService.GetAdminWarnings();
        dgvDashboardSnapshot.DataSource = _dataService.GetMonitorActivity();
    }

    private void WireEvents()
    {
        btnLogoutAdmin.Click += (_, _) => FormHostHelpers.OpenLoginAndClose(this);
        btnMenuAdminDashboard.Click += (_, _) => ShowDashboardHome();
        btnMenuSystemMonitor.Click += (_, _) => OpenModule(new FrmSystemMonitor(_dataService), btnMenuSystemMonitor);
        btnMenuAccountManagement.Click += (_, _) => OpenModule(new FrmAccountManagement(_dataService), btnMenuAccountManagement);
        btnMenuAdminReports.Click += (_, _) => OpenModule(new FrmAdminReports(_dataService), btnMenuAdminReports);
    }

    private void ShowDashboardHome()
    {
        pnlDashboardHome.Dock = DockStyle.Fill;
        pnlContentHostAdmin.Controls.Clear();
        pnlContentHostAdmin.Controls.Add(pnlDashboardHome);
        ApplyResponsiveBreakpoints();
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

    private void lblCurrentUserAdmin_Click(object sender, EventArgs e)
    {

    }
}
