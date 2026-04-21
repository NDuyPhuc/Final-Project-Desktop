namespace Trung_tam_quan_ly_ngoai_ngu;
public partial class FrmDebtTracking : Form
{
    public FrmDebtTracking(){ InitializeComponent(); FormHostHelpers.ConfigureModuleSurface(this, "Công nợ học viên"); dgvDebtTrackingList.DataSource = DemoDataFactory.GetDebtList(); lblDebtTotalCountValue.Text = "27"; lblDebtTotalAmountValue.Text = "54.300.000"; }
}
