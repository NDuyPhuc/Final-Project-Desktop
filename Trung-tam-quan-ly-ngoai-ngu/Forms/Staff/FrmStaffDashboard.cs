namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmStaffDashboard : Form
{
    private readonly string _currentUserName;

    public FrmStaffDashboard() : this("staff")
    {
    }

    public FrmStaffDashboard(string currentUserName)
    {
        _currentUserName = currentUserName;
        InitializeComponent();
        FormHostHelpers.ConfigureShellSurface(this, "Dashboard vận hành");
        ApplyShellStyling();
        BindDashboardData();
        ShowDashboardHome();
    }

    private void ApplyShellStyling()
    {
        lblCurrentRoleStaff.Text = "Staff";
        lblCurrentUserStaff.Text = _currentUserName;
        btnLogoutStaff.Click += (_, _) => FormHostHelpers.OpenLoginAndClose(this);
        var menuButtons = new[] { btnMenuStaffDashboard, btnMenuStudentManagement, btnMenuTeacherManagement, btnMenuCourseManagement, btnMenuClassManagement, btnMenuEnrollment, btnMenuTuitionReceipt, btnMenuDebtTracking };
        foreach (var button in menuButtons)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Height = 40;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(16, 0, 0, 0);
            button.BackColor = Color.Transparent;
            button.ForeColor = AppTheme.SidebarText;
            button.Font = AppTheme.FontSidebarItem;
        }
        btnMenuStaffDashboard.Click += (_, _) => ShowDashboardHome();
        btnMenuStudentManagement.Click += (_, _) => OpenModule(new FrmStudentManagement(), btnMenuStudentManagement, menuButtons);
        btnMenuTeacherManagement.Click += (_, _) => OpenModule(new FrmTeacherManagement(), btnMenuTeacherManagement, menuButtons);
        btnMenuCourseManagement.Click += (_, _) => OpenModule(new FrmCourseManagement(), btnMenuCourseManagement, menuButtons);
        btnMenuClassManagement.Click += (_, _) => OpenModule(new FrmClassManagement(), btnMenuClassManagement, menuButtons);
        btnMenuEnrollment.Click += (_, _) => OpenModule(new FrmEnrollment(), btnMenuEnrollment, menuButtons);
        btnMenuTuitionReceipt.Click += (_, _) => OpenModule(new FrmTuitionReceipt(), btnMenuTuitionReceipt, menuButtons);
        btnMenuDebtTracking.Click += (_, _) => OpenModule(new FrmDebtTracking(), btnMenuDebtTracking, menuButtons);
    }

    private void BindDashboardData()
    {
        lblNewStudentsTodayValue.Text = "12";
        lblAvailableClassesValue.Text = "9";
        lblTodayReceiptsValue.Text = "18";
        lblDebtStudentsValue.Text = "27";
        dgvRecentReceipts.DataSource = DemoDataFactory.GetRecentReceipts();
    }

    private void ShowDashboardHome()
    {
        var menuButtons = new[] { btnMenuStaffDashboard, btnMenuStudentManagement, btnMenuTeacherManagement, btnMenuCourseManagement, btnMenuClassManagement, btnMenuEnrollment, btnMenuTuitionReceipt, btnMenuDebtTracking };
        pnlDashboardHome.Dock = DockStyle.Fill;
        pnlContentHostStaff.Controls.Clear();
        pnlContentHostStaff.Controls.Add(pnlDashboardHome);
        FormHostHelpers.SetActiveMenu(btnMenuStaffDashboard, menuButtons);
    }

    private void OpenModule(Form moduleForm, Button activeButton, Button[] allButtons)
    {
        FormHostHelpers.OpenChildForm(pnlContentHostStaff, moduleForm);
        FormHostHelpers.SetActiveMenu(activeButton, allButtons);
    }
}
