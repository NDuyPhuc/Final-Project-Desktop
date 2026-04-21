namespace Trung_tam_quan_ly_ngoai_ngu;
public partial class FrmTeacherManagement : Form
{
    public FrmTeacherManagement(){ InitializeComponent(); FormHostHelpers.ConfigureModuleSurface(this, "Quản lý giáo viên"); dgvTeacherList.DataSource = DemoDataFactory.GetTeacherList(); }
}
