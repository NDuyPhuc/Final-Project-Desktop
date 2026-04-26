namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmImagePreviewDialog : Form
{
    public FrmImagePreviewDialog()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureDialogSurface(this, "Xem tr\u01b0\u1edbc \u1ea3nh", new Size(640, 520));
        ScaleDialogChrome();
    }

    private void ScaleDialogChrome()
    {
        tblImagePreviewRoot.Padding = FormHostHelpers.ScalePadding(this, new Padding(24));
        lblImageTitle.Margin = FormHostHelpers.ScalePadding(this, new Padding(0, 0, 0, 12));
        flpImagePreviewActions.Margin = FormHostHelpers.ScalePadding(this, new Padding(0, 12, 0, 0));
        btnClosePreview.Size = FormHostHelpers.ScaleSize(this, new Size(120, 32));
        btnRemoveImage.Size = FormHostHelpers.ScaleSize(this, new Size(120, 32));
        btnChooseImage.Size = FormHostHelpers.ScaleSize(this, new Size(120, 32));
        btnRemoveImage.Margin = FormHostHelpers.ScalePadding(this, new Padding(0, 0, 12, 0));
        btnChooseImage.Margin = FormHostHelpers.ScalePadding(this, new Padding(0, 0, 12, 0));
        picPreviewImage.MinimumSize = FormHostHelpers.ScaleSize(this, new Size(300, 220));
    }
}
