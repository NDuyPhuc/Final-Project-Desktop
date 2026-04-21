namespace Trung_tam_quan_ly_ngoai_ngu;
partial class FrmStatusDialog
{
    private System.ComponentModel.IContainer components=null; private Label lblStatusTitle; private Label lblStatusMessage; private Button btnCloseStatusDialog;
    protected override void Dispose(bool disposing){ if(disposing && components!=null) components.Dispose(); base.Dispose(disposing);} 
    private void InitializeComponent(){ lblStatusTitle=new Label(); lblStatusMessage=new Label(); btnCloseStatusDialog=new Button(); SuspendLayout(); lblStatusTitle.Location=new Point(24,24); lblStatusTitle.Size=new Size(340,30); lblStatusTitle.Font=AppTheme.FontSection; lblStatusMessage.Location=new Point(24,72); lblStatusMessage.Size=new Size(340,60); btnCloseStatusDialog.Location=new Point(24,156); btnCloseStatusDialog.Size=new Size(120,32); btnCloseStatusDialog.Text="Đóng"; btnCloseStatusDialog.Click += (_, _) => Close(); ClientSize=new Size(400,220); Controls.AddRange(new Control[]{lblStatusTitle,lblStatusMessage,btnCloseStatusDialog}); FormBorderStyle=FormBorderStyle.FixedDialog; MaximizeBox=false; MinimizeBox=false; Name="FrmStatusDialog"; ResumeLayout(false);} 
}
