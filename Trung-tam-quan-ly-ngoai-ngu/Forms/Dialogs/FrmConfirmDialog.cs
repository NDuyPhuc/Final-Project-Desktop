namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmConfirmDialog : Form
{
    public FrmConfirmDialog() : this("Xác nhận thao tác", "Bạn có chắc chắn muốn tiếp tục?")
    {
    }

    public FrmConfirmDialog(string title, string message)
    {
        InitializeComponent();
        FormHostHelpers.ConfigureDialogSurface(this, title, new Size(460, 260));
        lblConfirmTitle.Text = title;
        lblConfirmMessage.Text = message;
        ScaleDialogChrome();
    }

    private void ScaleDialogChrome()
    {
        tblConfirmRoot.Padding = FormHostHelpers.ScalePadding(this, new Padding(24));
        lblConfirmTitle.Margin = FormHostHelpers.ScalePadding(this, new Padding(0, 0, 0, 12));
        flpConfirmActions.Margin = FormHostHelpers.ScalePadding(this, new Padding(0, 12, 0, 0));
        btnConfirmCancel.Size = FormHostHelpers.ScaleSize(this, new Size(120, 32));
        btnConfirmAccept.Size = FormHostHelpers.ScaleSize(this, new Size(120, 32));
        btnConfirmCancel.Margin = FormHostHelpers.ScalePadding(this, new Padding(0, 0, 12, 0));
    }
}
