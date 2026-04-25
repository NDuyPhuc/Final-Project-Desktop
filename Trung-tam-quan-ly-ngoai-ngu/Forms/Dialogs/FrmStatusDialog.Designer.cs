namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmStatusDialog
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tblStatusRoot;
    private FlowLayoutPanel flpStatusActions;
    private Label lblStatusTitle;
    private Label lblStatusMessage;
    private Button btnCloseStatusDialog;

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
        tblStatusRoot = new TableLayoutPanel();
        lblStatusTitle = new Label();
        lblStatusMessage = new Label();
        flpStatusActions = new FlowLayoutPanel();
        btnCloseStatusDialog = new Button();
        tblStatusRoot.SuspendLayout();
        flpStatusActions.SuspendLayout();
        SuspendLayout();
        // 
        // tblStatusRoot
        // 
        tblStatusRoot.ColumnCount = 1;
        tblStatusRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblStatusRoot.Controls.Add(lblStatusTitle, 0, 0);
        tblStatusRoot.Controls.Add(lblStatusMessage, 0, 1);
        tblStatusRoot.Controls.Add(flpStatusActions, 0, 2);
        tblStatusRoot.Dock = DockStyle.Fill;
        tblStatusRoot.Location = new Point(0, 0);
        tblStatusRoot.Name = "tblStatusRoot";
        tblStatusRoot.Padding = new Padding(24);
        tblStatusRoot.RowCount = 3;
        tblStatusRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tblStatusRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblStatusRoot.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        tblStatusRoot.Size = new Size(424, 221);
        tblStatusRoot.AutoScroll = false;
        tblStatusRoot.TabIndex = 0;
        // 
        // lblStatusTitle
        // 
        lblStatusTitle.AutoSize = true;
        lblStatusTitle.Dock = DockStyle.Fill;
        lblStatusTitle.Font = AppTheme.FontSection;
        lblStatusTitle.Location = new Point(24, 24);
        lblStatusTitle.Margin = new Padding(0, 0, 0, 12);
        lblStatusTitle.Name = "lblStatusTitle";
        lblStatusTitle.Size = new Size(376, 28);
        lblStatusTitle.TabIndex = 0;
        lblStatusTitle.Text = "Thông báo";
        // 
        // lblStatusMessage
        // 
        lblStatusMessage.Dock = DockStyle.Fill;
        lblStatusMessage.Location = new Point(24, 64);
        lblStatusMessage.Margin = new Padding(0);
        lblStatusMessage.Name = "lblStatusMessage";
        lblStatusMessage.Size = new Size(376, 89);
        lblStatusMessage.AutoSize = true;
        lblStatusMessage.TabIndex = 1;
        lblStatusMessage.Text = "Nội dung thông báo";
        // 
        // flpStatusActions
        // 
        flpStatusActions.AutoSize = true;
        flpStatusActions.Controls.Add(btnCloseStatusDialog);
        flpStatusActions.Dock = DockStyle.Fill;
        flpStatusActions.FlowDirection = FlowDirection.RightToLeft;
        flpStatusActions.Location = new Point(24, 165);
        flpStatusActions.Margin = new Padding(0, 12, 0, 0);
        flpStatusActions.Name = "flpStatusActions";
        flpStatusActions.Size = new Size(376, 32);
        flpStatusActions.AutoScroll = false;
        flpStatusActions.WrapContents = true;
        flpStatusActions.TabIndex = 2;
        flpStatusActions.WrapContents = false;
        // 
        // btnCloseStatusDialog
        // 
        btnCloseStatusDialog.Location = new Point(256, 0);
        btnCloseStatusDialog.Margin = new Padding(0);
        btnCloseStatusDialog.Name = "btnCloseStatusDialog";
        btnCloseStatusDialog.Size = new Size(120, 32);
        btnCloseStatusDialog.TabIndex = 0;
        btnCloseStatusDialog.Text = "Đóng";
        btnCloseStatusDialog.Click += (_, _) => Close();
        btnCloseStatusDialog.UseVisualStyleBackColor = true;
        // 
        // FrmStatusDialog
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(424, 221);
        Font = new Font("Segoe UI", 10F);
        Controls.Add(tblStatusRoot);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        MinimumSize = new Size(440, 260);
        Name = "FrmStatusDialog";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        tblStatusRoot.ResumeLayout(false);
        tblStatusRoot.PerformLayout();
        flpStatusActions.ResumeLayout(false);
        AutoScroll = true;
        ResumeLayout(false);
    }
}
