namespace Trung_tam_quan_ly_ngoai_ngu;

public sealed class FrmConfirmDialog : Form
{
    public Label lblConfirmTitle { get; }
    public Label lblConfirmMessage { get; }
    public Button btnConfirmAccept { get; }
    public Button btnConfirmCancel { get; }

    public FrmConfirmDialog(string title = "Xác nhận thao tác", string message = "Bạn có chắc chắn muốn tiếp tục?")
    {
        AppTheme.ApplyFormStyle(this, title);
        Width = 460;
        Height = 240;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        lblConfirmTitle = UiHelpers.CreateLabel("lblConfirmTitle", title, AppTheme.FontTitle, AppTheme.TextPrimary);
        lblConfirmMessage = UiHelpers.CreateLabel("lblConfirmMessage", message, AppTheme.FontBody, AppTheme.TextMuted);
        btnConfirmAccept = UiHelpers.CreateButton("btnConfirmAccept", "Đồng ý");
        btnConfirmCancel = UiHelpers.CreateButton("btnConfirmCancel", "Hủy", "secondary");

        btnConfirmAccept.Click += (_, _) => DialogResult = DialogResult.OK;
        btnConfirmCancel.Click += (_, _) => DialogResult = DialogResult.Cancel;

        var layout = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            Padding = new Padding(24),
            BackColor = Color.White
        };
        layout.Controls.Add(lblConfirmTitle);
        layout.Controls.Add(lblConfirmMessage);
        var buttonBar = UiHelpers.CreateButtonBar("pnlConfirmButtons");
        buttonBar.Controls.Add(btnConfirmAccept);
        buttonBar.Controls.Add(btnConfirmCancel);
        layout.Controls.Add(buttonBar);
        Controls.Add(layout);
    }
}

public sealed class FrmStatusDialog : Form
{
    public Label lblStatusTitle { get; }
    public Label lblStatusMessage { get; }
    public Button btnCloseStatusDialog { get; }

    public FrmStatusDialog(string title = "Thông báo", string message = "Thao tác đã hoàn tất.")
    {
        AppTheme.ApplyFormStyle(this, title);
        Width = 420;
        Height = 220;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        lblStatusTitle = UiHelpers.CreateLabel("lblStatusTitle", title, AppTheme.FontTitle, AppTheme.TextPrimary);
        lblStatusMessage = UiHelpers.CreateLabel("lblStatusMessage", message, AppTheme.FontBody, AppTheme.TextMuted);
        btnCloseStatusDialog = UiHelpers.CreateButton("btnCloseStatusDialog", "Đóng");
        btnCloseStatusDialog.Click += (_, _) => Close();

        var layout = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            Padding = new Padding(24),
            BackColor = Color.White
        };
        layout.Controls.Add(lblStatusTitle);
        layout.Controls.Add(lblStatusMessage);
        layout.Controls.Add(btnCloseStatusDialog);
        Controls.Add(layout);
    }
}

public sealed class FrmImagePreviewDialog : Form
{
    public PictureBox picPreviewImage { get; }
    public Label lblImageTitle { get; }
    public Button btnChooseImage { get; }
    public Button btnRemoveImage { get; }
    public Button btnClosePreview { get; }

    public FrmImagePreviewDialog()
    {
        AppTheme.ApplyFormStyle(this, "Xem ảnh đại diện");
        Width = 540;
        Height = 500;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;

        lblImageTitle = UiHelpers.CreateLabel("lblImageTitle", "Ảnh đại diện / ảnh minh họa", AppTheme.FontSection, AppTheme.TextPrimary);
        picPreviewImage = UiHelpers.CreatePictureBox("picPreviewImage");
        picPreviewImage.Width = 420;
        picPreviewImage.Height = 280;
        btnChooseImage = UiHelpers.CreateButton("btnChooseImage", "Chọn ảnh");
        btnRemoveImage = UiHelpers.CreateButton("btnRemoveImage", "Xóa ảnh", "danger");
        btnClosePreview = UiHelpers.CreateButton("btnClosePreview", "Đóng", "secondary");
        btnClosePreview.Click += (_, _) => Close();

        var layout = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            Padding = new Padding(24),
            BackColor = Color.White
        };
        layout.Controls.Add(lblImageTitle);
        layout.Controls.Add(picPreviewImage);
        var buttonBar = UiHelpers.CreateButtonBar("pnlImagePreviewButtons");
        buttonBar.Controls.Add(btnChooseImage);
        buttonBar.Controls.Add(btnRemoveImage);
        buttonBar.Controls.Add(btnClosePreview);
        layout.Controls.Add(buttonBar);
        Controls.Add(layout);
    }
}
