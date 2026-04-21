namespace Trung_tam_quan_ly_ngoai_ngu;
public partial class FrmTeachingClasses : Form
{
    public FrmTeachingClasses(){ InitializeComponent(); FormHostHelpers.ConfigureModuleSurface(this, "Lớp đang dạy"); dgvTeachingClassList.DataSource = DemoDataFactory.GetTeachingClasses(); }
}
