namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmStatusDialog : Form
{
    public FrmStatusDialog() : this("Thong bao", "Thao tac da hoan tat.")
    {
    }

    public FrmStatusDialog(string title, string message)
    {
        InitializeComponent();
        Text = title;
        lblStatusTitle.Text = title;
        lblStatusMessage.Text = message;
    }
}
