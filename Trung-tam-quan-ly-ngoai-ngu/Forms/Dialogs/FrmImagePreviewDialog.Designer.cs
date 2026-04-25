namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmImagePreviewDialog
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tblImagePreviewRoot;
    private FlowLayoutPanel flpImagePreviewActions;
    private Label lblImageTitle;
    private PictureBox picPreviewImage;
    private Button btnChooseImage;
    private Button btnRemoveImage;
    private Button btnClosePreview;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        tblImagePreviewRoot = new TableLayoutPanel();
        lblImageTitle = new Label();
        picPreviewImage = new PictureBox();
        flpImagePreviewActions = new FlowLayoutPanel();
        btnClosePreview = new Button();
        btnRemoveImage = new Button();
        btnChooseImage = new Button();
        tblImagePreviewRoot.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picPreviewImage).BeginInit();
        flpImagePreviewActions.SuspendLayout();
        SuspendLayout();
        // 
        // tblImagePreviewRoot
        // 
        tblImagePreviewRoot.ColumnCount = 1;
        tblImagePreviewRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblImagePreviewRoot.Controls.Add(lblImageTitle, 0, 0);
        tblImagePreviewRoot.Controls.Add(picPreviewImage, 0, 1);
        tblImagePreviewRoot.Controls.Add(flpImagePreviewActions, 0, 2);
        tblImagePreviewRoot.Dock = DockStyle.Fill;
        tblImagePreviewRoot.Location = new Point(0, 0);
        tblImagePreviewRoot.Name = "tblImagePreviewRoot";
        tblImagePreviewRoot.Padding = new Padding(24);
        tblImagePreviewRoot.RowCount = 3;
        tblImagePreviewRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tblImagePreviewRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblImagePreviewRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tblImagePreviewRoot.Size = new Size(624, 481);
        tblImagePreviewRoot.AutoScroll = false;
        tblImagePreviewRoot.TabIndex = 0;
        // 
        // lblImageTitle
        // 
        lblImageTitle.AutoSize = true;
        lblImageTitle.Dock = DockStyle.Fill;
        lblImageTitle.Location = new Point(24, 24);
        lblImageTitle.Margin = new Padding(0, 0, 0, 12);
        lblImageTitle.Name = "lblImageTitle";
        lblImageTitle.Size = new Size(576, 28);
        lblImageTitle.AutoSize = true;
        lblImageTitle.TabIndex = 0;
        lblImageTitle.Text = "Ảnh đại diện / ảnh minh họa";
        // 
        // picPreviewImage
        // 
        picPreviewImage.BorderStyle = BorderStyle.FixedSingle;
        picPreviewImage.Dock = DockStyle.Fill;
        picPreviewImage.Location = new Point(24, 56);
        picPreviewImage.Margin = new Padding(0);
        picPreviewImage.MinimumSize = new Size(300, 220);
        picPreviewImage.Name = "picPreviewImage";
        picPreviewImage.Size = new Size(576, 357);
        picPreviewImage.SizeMode = PictureBoxSizeMode.Zoom;
        picPreviewImage.TabIndex = 1;
        picPreviewImage.TabStop = false;
        // 
        // flpImagePreviewActions
        // 
        flpImagePreviewActions.AutoSize = true;
        flpImagePreviewActions.Controls.Add(btnClosePreview);
        flpImagePreviewActions.Controls.Add(btnRemoveImage);
        flpImagePreviewActions.Controls.Add(btnChooseImage);
        flpImagePreviewActions.Dock = DockStyle.Fill;
        flpImagePreviewActions.FlowDirection = FlowDirection.RightToLeft;
        flpImagePreviewActions.Location = new Point(24, 425);
        flpImagePreviewActions.Margin = new Padding(0, 12, 0, 0);
        flpImagePreviewActions.Name = "flpImagePreviewActions";
        flpImagePreviewActions.Size = new Size(576, 32);
        flpImagePreviewActions.AutoScroll = false;
        flpImagePreviewActions.WrapContents = true;
        flpImagePreviewActions.TabIndex = 2;
        flpImagePreviewActions.WrapContents = false;
        // 
        // btnClosePreview
        // 
        btnClosePreview.Location = new Point(456, 0);
        btnClosePreview.Margin = new Padding(0);
        btnClosePreview.Name = "btnClosePreview";
        btnClosePreview.Size = new Size(120, 32);
        btnClosePreview.TabIndex = 0;
        btnClosePreview.Text = "Đóng";
        btnClosePreview.Click += (_, _) => Close();
        btnClosePreview.UseVisualStyleBackColor = true;
        // 
        // btnRemoveImage
        // 
        btnRemoveImage.Location = new Point(324, 0);
        btnRemoveImage.Margin = new Padding(0, 0, 12, 0);
        btnRemoveImage.Name = "btnRemoveImage";
        btnRemoveImage.Size = new Size(120, 32);
        btnRemoveImage.TabIndex = 1;
        btnRemoveImage.Text = "Xóa ảnh";
        btnRemoveImage.UseVisualStyleBackColor = true;
        // 
        // btnChooseImage
        // 
        btnChooseImage.Location = new Point(192, 0);
        btnChooseImage.Margin = new Padding(0, 0, 12, 0);
        btnChooseImage.Name = "btnChooseImage";
        btnChooseImage.Size = new Size(120, 32);
        btnChooseImage.TabIndex = 2;
        btnChooseImage.Text = "Chọn ảnh";
        btnChooseImage.UseVisualStyleBackColor = true;
        // 
        // FrmImagePreviewDialog
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(624, 481);
        Font = new Font("Segoe UI", 10F);
        Controls.Add(tblImagePreviewRoot);
        MinimumSize = new Size(640, 520);
        Name = "FrmImagePreviewDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Xem trước ảnh";
        tblImagePreviewRoot.ResumeLayout(false);
        tblImagePreviewRoot.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)picPreviewImage).EndInit();
        flpImagePreviewActions.ResumeLayout(false);
        AutoScroll = true;
        ResumeLayout(false);
    }
}
