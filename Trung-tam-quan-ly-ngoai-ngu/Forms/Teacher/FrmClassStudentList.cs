namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmClassStudentList : Form
{
    public FrmClassStudentList()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Danh sách học viên lớp");
        ConfigureView();
        BindMockData();
    }

    private void ConfigureView()
    {
        cboClassStudentClass.SelectedIndex = 0;
        cboClassStudentContext.SelectedIndex = 0;
        AppTheme.StyleGrid(dgvClassStudentList);
    }

    private void BindMockData()
    {
        dgvClassStudentList.DataSource = DemoDataFactory.GetClassStudents();
        lblClassStudentCountValue.Text = "18";
        lblClassStudentScheduleValue.Text = "2-4-6";
    }
}
