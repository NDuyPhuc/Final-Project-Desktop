namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmConfirmDialog : Form
{
    public FrmConfirmDialog() : this("Xác nhận thao tác", "Bạn có chắc chắn muốn tiếp tục?")
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
