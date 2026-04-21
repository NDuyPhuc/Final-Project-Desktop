namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmTeacherDashboard : Form
{
    private readonly string _currentUserName;
    public FrmTeacherDashboard() : this("teacher") { }
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
        lblCurrentRoleTeacher.Text = "Teacher";
        lblCurrentUserTeacher.Text = _currentUserName;
        btnLogoutTeacher.Click += (_, _) => FormHostHelpers.OpenLoginAndClose(this);
        var menuButtons = new[] { btnMenuTeacherDashboard, btnMenuTeachingClasses, btnMenuClassStudentList, btnMenuAttendance, btnMenuScoreEntry };
        foreach (var button in menuButtons)
        {
            button.FlatStyle = FlatStyle.Flat; button.FlatAppearance.BorderSize = 0; button.Height = 40; button.TextAlign = ContentAlignment.MiddleLeft; button.Padding = new Padding(16, 0, 0, 0); button.BackColor = Color.Transparent; button.ForeColor = AppTheme.SidebarText; button.Font = AppTheme.FontSidebarItem;
        }
        btnMenuTeacherDashboard.Click += (_, _) => ShowDashboardHome();
        btnMenuTeachingClasses.Click += (_, _) => OpenModule(new FrmTeachingClasses(), btnMenuTeachingClasses, menuButtons);
        btnMenuClassStudentList.Click += (_, _) => OpenModule(new FrmClassStudentList(), btnMenuClassStudentList, menuButtons);
        btnMenuAttendance.Click += (_, _) => OpenModule(new FrmAttendance(), btnMenuAttendance, menuButtons);
        btnMenuScoreEntry.Click += (_, _) => OpenModule(new FrmScoreEntry(), btnMenuScoreEntry, menuButtons);
    }
    private void BindDashboardData()
    {
        lblTeachingClassesCountValue.Text = "4";
        lblTeachingStudentCountValue.Text = "52";
        lblTeachingTodaySessionsValue.Text = "3";
        lblTeachingPendingScoresValue.Text = "1";
        dgvTeacherClassOverview.DataSource = DemoDataFactory.GetTeachingClasses();
    }
    private void ShowDashboardHome()
    {
        var menuButtons = new[] { btnMenuTeacherDashboard, btnMenuTeachingClasses, btnMenuClassStudentList, btnMenuAttendance, btnMenuScoreEntry };
        pnlDashboardHome.Dock = DockStyle.Fill; pnlContentHostTeacher.Controls.Clear(); pnlContentHostTeacher.Controls.Add(pnlDashboardHome); FormHostHelpers.SetActiveMenu(btnMenuTeacherDashboard, menuButtons);
    }
    private void OpenModule(Form moduleForm, Button activeButton, Button[] allButtons)
    {
        FormHostHelpers.OpenChildForm(pnlContentHostTeacher, moduleForm); FormHostHelpers.SetActiveMenu(activeButton, allButtons);
    }
}
