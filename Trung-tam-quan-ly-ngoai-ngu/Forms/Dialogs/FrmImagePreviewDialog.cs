namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmImagePreviewDialog : Form
{
    public string? SelectedImagePath { get; private set; }
    public bool RemoveRequested { get; private set; }

    public FrmImagePreviewDialog()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureDialogSurface(this, "Xem tr\u01b0\u1edbc \u1ea3nh", new Size(640, 520));
        ScaleDialogChrome();
        WireEvents();
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

    private void WireEvents()
    {
        btnChooseImage.Click += (_, _) => ChooseImage();
        btnRemoveImage.Click += (_, _) => RemoveImage();
    }

    private void ChooseImage()
    {
        using var dialog = new OpenFileDialog
        {
            Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp",
            Title = "Chọn ảnh"
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        SelectedImagePath = dialog.FileName;
        RemoveRequested = false;
        LoadPreview(dialog.FileName);
        DialogResult = DialogResult.OK;
    }

    private void RemoveImage()
    {
        SelectedImagePath = null;
        RemoveRequested = true;
        picPreviewImage.Image?.Dispose();
        picPreviewImage.Image = null;
        DialogResult = DialogResult.OK;
    }

    public void LoadPreview(string? imagePath)
    {
        picPreviewImage.Image?.Dispose();
        picPreviewImage.Image = null;

        if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath))
        {
            return;
        }

        using var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var image = Image.FromStream(stream);
        picPreviewImage.Image = new Bitmap(image);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        picPreviewImage.Image?.Dispose();
        picPreviewImage.Image = null;
        base.OnFormClosed(e);
    }
}
