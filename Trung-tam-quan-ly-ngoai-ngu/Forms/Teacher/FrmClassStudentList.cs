namespace Trung_tam_quan_ly_ngoai_ngu;
public partial class FrmClassStudentList : Form
{
    public FrmClassStudentList(){ InitializeComponent(); FormHostHelpers.ConfigureModuleSurface(this, "Danh sách học viên lớp"); dgvClassStudentList.DataSource = DemoDataFactory.GetClassStudents(); lblClassStudentCountValue.Text = "18"; lblClassStudentScheduleValue.Text = "2-4-6"; }
}
