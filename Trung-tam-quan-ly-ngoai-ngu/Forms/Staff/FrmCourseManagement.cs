namespace Trung_tam_quan_ly_ngoai_ngu;
public partial class FrmCourseManagement : Form
{
    public FrmCourseManagement(){ InitializeComponent(); FormHostHelpers.ConfigureModuleSurface(this, "Quản lý khóa học"); dgvCourseList.DataSource = DemoDataFactory.GetCourseList(); }
}
