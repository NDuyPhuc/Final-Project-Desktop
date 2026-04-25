namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmConfirmDialog
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tblConfirmRoot;
    private FlowLayoutPanel flpConfirmActions;
    private Label lblConfirmTitle;
    private Label lblConfirmMessage;
    private Button btnConfirmAccept;
    private Button btnConfirmCancel;

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
        tblConfirmRoot = new TableLayoutPanel();
        lblConfirmTitle = new Label();
        lblConfirmMessage = new Label();
        flpConfirmActions = new FlowLayoutPanel();
        btnConfirmCancel = new Button();
        btnConfirmAccept = new Button();
        tblConfirmRoot.SuspendLayout();
        flpConfirmActions.SuspendLayout();
        SuspendLayout();
        // 
        // tblConfirmRoot
        // 
        tblConfirmRoot.ColumnCount = 1;
        tblConfirmRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblConfirmRoot.Controls.Add(lblConfirmTitle, 0, 0);
        tblConfirmRoot.Controls.Add(lblConfirmMessage, 0, 1);
        tblConfirmRoot.Controls.Add(flpConfirmActions, 0, 2);
        tblConfirmRoot.Dock = DockStyle.Fill;
        tblConfirmRoot.Location = new Point(0, 0);
        tblConfirmRoot.Name = "tblConfirmRoot";
        tblConfirmRoot.Padding = new Padding(24);
        tblConfirmRoot.RowCount = 3;
        tblConfirmRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tblConfirmRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblConfirmRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tblConfirmRoot.Size = new Size(444, 221);
        tblConfirmRoot.AutoScroll = false;
        tblConfirmRoot.TabIndex = 0;
        // 
        // lblConfirmTitle
        // 
        lblConfirmTitle.AutoSize = true;
        lblConfirmTitle.Dock = DockStyle.Fill;
        lblConfirmTitle.Font = AppTheme.FontSection;
        lblConfirmTitle.Location = new Point(24, 24);
        lblConfirmTitle.Margin = new Padding(0, 0, 0, 12);
        lblConfirmTitle.Name = "lblConfirmTitle";
        lblConfirmTitle.Size = new Size(396, 28);
        lblConfirmTitle.TabIndex = 0;
        lblConfirmTitle.Text = "Xác nhận thao tác";
        // 
        // lblConfirmMessage
        // 
        lblConfirmMessage.Dock = DockStyle.Fill;
        lblConfirmMessage.Location = new Point(24, 64);
        lblConfirmMessage.Margin = new Padding(0);
        lblConfirmMessage.Name = "lblConfirmMessage";
        lblConfirmMessage.Size = new Size(396, 89);
        lblConfirmMessage.AutoSize = true;
        lblConfirmMessage.TabIndex = 1;
        lblConfirmMessage.Text = "Bạn có chắc chắn muốn tiếp tục?";
        // 
        // flpConfirmActions
        // 
        flpConfirmActions.AutoSize = true;
        flpConfirmActions.Controls.Add(btnConfirmCancel);
        flpConfirmActions.Controls.Add(btnConfirmAccept);
        flpConfirmActions.Dock = DockStyle.Fill;
        flpConfirmActions.FlowDirection = FlowDirection.RightToLeft;
        flpConfirmActions.Location = new Point(24, 165);
        flpConfirmActions.Margin = new Padding(0, 12, 0, 0);
        flpConfirmActions.Name = "flpConfirmActions";
        flpConfirmActions.Size = new Size(396, 32);
        flpConfirmActions.AutoScroll = false;
        flpConfirmActions.WrapContents = true;
        flpConfirmActions.TabIndex = 2;
        flpConfirmActions.WrapContents = false;
        // 
        // btnConfirmCancel
        // 
        btnConfirmCancel.DialogResult = DialogResult.Cancel;
        btnConfirmCancel.Location = new Point(276, 0);
        btnConfirmCancel.Margin = new Padding(0, 0, 12, 0);
        btnConfirmCancel.Name = "btnConfirmCancel";
        btnConfirmCancel.Size = new Size(120, 32);
        btnConfirmCancel.TabIndex = 0;
        btnConfirmCancel.Text = "Hủy";
        btnConfirmCancel.UseVisualStyleBackColor = true;
        // 
        // btnConfirmAccept
        // 
        btnConfirmAccept.DialogResult = DialogResult.OK;
        btnConfirmAccept.Location = new Point(144, 0);
        btnConfirmAccept.Margin = new Padding(0);
        btnConfirmAccept.Name = "btnConfirmAccept";
        btnConfirmAccept.Size = new Size(120, 32);
        btnConfirmAccept.TabIndex = 1;
        btnConfirmAccept.Text = "Đồng ý";
        btnConfirmAccept.UseVisualStyleBackColor = true;
        // 
        // FrmConfirmDialog
        // 
        AcceptButton = btnConfirmAccept;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        CancelButton = btnConfirmCancel;
        ClientSize = new Size(444, 221);
        Font = new Font("Segoe UI", 10F);
        Controls.Add(tblConfirmRoot);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        MinimumSize = new Size(460, 260);
        Name = "FrmConfirmDialog";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        tblConfirmRoot.ResumeLayout(false);
        tblConfirmRoot.PerformLayout();
        flpConfirmActions.ResumeLayout(false);
        AutoScroll = true;
        ResumeLayout(false);
    }
}
