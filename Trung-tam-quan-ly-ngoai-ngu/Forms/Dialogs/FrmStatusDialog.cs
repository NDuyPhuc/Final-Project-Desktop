namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmStatusDialog : Form
{
    public FrmStatusDialog() : this("Thông báo", "Thao tác đã hoàn tất.")
    {
    }

    public FrmStatusDialog(string title, string message)
    {
        InitializeComponent();
        FormHostHelpers.ConfigureDialogSurface(this, title, new Size(440, 260));
        lblStatusTitle.Text = title;
        lblStatusMessage.Text = message;
        ScaleDialogChrome();
    }

    private void ScaleDialogChrome()
    {
        tblStatusRoot.Padding = FormHostHelpers.ScalePadding(this, new Padding(24));
        lblStatusTitle.Margin = FormHostHelpers.ScalePadding(this, new Padding(0, 0, 0, 12));
        flpStatusActions.Margin = FormHostHelpers.ScalePadding(this, new Padding(0, 12, 0, 0));
        btnCloseStatusDialog.Size = FormHostHelpers.ScaleSize(this, new Size(120, 32));
    }
}
