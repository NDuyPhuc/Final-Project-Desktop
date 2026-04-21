namespace Trung_tam_quan_ly_ngoai_ngu;
partial class FrmConfirmDialog
{
    private System.ComponentModel.IContainer components=null; private Label lblConfirmTitle; private Label lblConfirmMessage; private Button btnConfirmAccept; private Button btnConfirmCancel;
    protected override void Dispose(bool disposing){ if(disposing && components!=null) components.Dispose(); base.Dispose(disposing);} 
    private void InitializeComponent(){ lblConfirmTitle=new Label(); lblConfirmMessage=new Label(); btnConfirmAccept=new Button(); btnConfirmCancel=new Button(); SuspendLayout(); lblConfirmTitle.Location=new Point(24,24); lblConfirmTitle.Size=new Size(360,30); lblConfirmTitle.Font=AppTheme.FontSection; lblConfirmMessage.Location=new Point(24,72); lblConfirmMessage.Size=new Size(360,60); btnConfirmAccept.Location=new Point(24,156); btnConfirmAccept.Size=new Size(120,32); btnConfirmAccept.Text="Đ?ng ư"; btnConfirmAccept.DialogResult=DialogResult.OK; btnConfirmCancel.Location=new Point(156,156); btnConfirmCancel.Size=new Size(120,32); btnConfirmCancel.Text="H?y"; btnConfirmCancel.DialogResult=DialogResult.Cancel; ClientSize=new Size(420,220); Controls.AddRange(new Control[]{lblConfirmTitle,lblConfirmMessage,btnConfirmAccept,btnConfirmCancel}); FormBorderStyle=FormBorderStyle.FixedDialog; MaximizeBox=false; MinimizeBox=false; Name="FrmConfirmDialog"; ResumeLayout(false);} 
}
