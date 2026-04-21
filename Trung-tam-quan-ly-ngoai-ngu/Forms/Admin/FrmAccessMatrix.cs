namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAccessMatrix : Form
{
    public FrmAccessMatrix()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Tổng quan quyền truy cập");
        BindMockData();
    }

    private void BindMockData()
    {
        dgvAccessMatrix.DataSource = DemoDataFactory.GetAccessMatrix();
    }
}
