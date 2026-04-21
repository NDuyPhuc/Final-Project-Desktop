namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAccountManagement : Form
{
    public FrmAccountManagement()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Tài khoản và phân quyền");
        dgvAccountList.DataSource = DemoDataFactory.GetAccountList();
    }
}
