namespace Trung_tam_quan_ly_ngoai_ngu;
public partial class FrmScoreEntry : Form
{
    public FrmScoreEntry(){ InitializeComponent(); FormHostHelpers.ConfigureModuleSurface(this, "Nhập điểm"); dgvScoreEntryList.DataSource = DemoDataFactory.GetScoreList(); }
}
