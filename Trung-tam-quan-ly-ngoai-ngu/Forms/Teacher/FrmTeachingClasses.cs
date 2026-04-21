namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmTeachingClasses : Form
{
    public FrmTeachingClasses()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Lớp đang dạy");
        ConfigureView();
        BindMockData();
    }

    private void ConfigureView()
    {
        cboTeachingStatusFilter.SelectedIndex = 0;
        AppTheme.StyleGrid(dgvTeachingClassList);
    }

    private void BindMockData()
    {
        dgvTeachingClassList.DataSource = DemoDataFactory.GetTeachingClasses();
    }
}
