namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmConfirmDialog : Form
{
    public FrmConfirmDialog() : this("Xac nhan thao tac", "Ban co chac chan muon tiep tuc?")
    {
    }

    public FrmConfirmDialog(string title, string message)
    {
        InitializeComponent();
        Text = title;
        lblConfirmTitle.Text = title;
        lblConfirmMessage.Text = message;
    }
}
