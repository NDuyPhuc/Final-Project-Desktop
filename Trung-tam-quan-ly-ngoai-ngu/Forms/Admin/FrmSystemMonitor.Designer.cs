namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmSystemMonitor
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlSystemMonitorFilterCard;
    private ComboBox cboMonitorPeriod;
    private ComboBox cboMonitorViewType;
    private Button btnViewMonitor;
    private Button btnQuickExportMonitor;
    private Panel pnlMonitorStudentCount;
    private Panel pnlMonitorEnrollmentCount;
    private Panel pnlMonitorReceiptCount;
    private Panel pnlMonitorDebtTotal;
    private Label lblMonitorStudentCountValue;
    private Label lblMonitorEnrollmentCountValue;
    private Label lblMonitorReceiptCountValue;
    private Label lblMonitorDebtTotalValue;
    private DataGridView dgvMonitorActivity;
    private DataGridView dgvMonitorSource;

    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        pnlSystemMonitorFilterCard = new Panel(); cboMonitorPeriod = new ComboBox(); cboMonitorViewType = new ComboBox(); btnViewMonitor = new Button(); btnQuickExportMonitor = new Button();
        pnlMonitorStudentCount = new Panel(); pnlMonitorEnrollmentCount = new Panel(); pnlMonitorReceiptCount = new Panel(); pnlMonitorDebtTotal = new Panel();
        lblMonitorStudentCountValue = new Label(); lblMonitorEnrollmentCountValue = new Label(); lblMonitorReceiptCountValue = new Label(); lblMonitorDebtTotalValue = new Label();
        dgvMonitorActivity = new DataGridView(); dgvMonitorSource = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvMonitorActivity).BeginInit(); ((System.ComponentModel.ISupportInitialize)dgvMonitorSource).BeginInit();
        SuspendLayout();
        pnlSystemMonitorFilterCard.BorderStyle = BorderStyle.FixedSingle; pnlSystemMonitorFilterCard.Location = new Point(8,8); pnlSystemMonitorFilterCard.Size = new Size(1120,80);
        cboMonitorPeriod.Items.AddRange(new object[]{"Hôm nay","7 ngày","30 ngày"}); cboMonitorPeriod.Location = new Point(16,24); cboMonitorPeriod.Size = new Size(180,23);
        cboMonitorViewType.Items.AddRange(new object[]{"T?ng quan","V?n hành","C?nh báo"}); cboMonitorViewType.Location = new Point(212,24); cboMonitorViewType.Size = new Size(180,23);
        btnViewMonitor.Location = new Point(408,22); btnViewMonitor.Size = new Size(120,28); btnViewMonitor.Text = "Xem d? li?u";
        btnQuickExportMonitor.Location = new Point(540,22); btnQuickExportMonitor.Size = new Size(120,28); btnQuickExportMonitor.Text = "Xu?t nhanh";
        pnlSystemMonitorFilterCard.Controls.AddRange(new Control[]{cboMonitorPeriod,cboMonitorViewType,btnViewMonitor,btnQuickExportMonitor});
        pnlMonitorStudentCount.BorderStyle = BorderStyle.FixedSingle; pnlMonitorStudentCount.Location = new Point(8,104); pnlMonitorStudentCount.Size = new Size(260,84); pnlMonitorStudentCount.Controls.Add(lblMonitorStudentCountValue);
        pnlMonitorEnrollmentCount.BorderStyle = BorderStyle.FixedSingle; pnlMonitorEnrollmentCount.Location = new Point(284,104); pnlMonitorEnrollmentCount.Size = new Size(260,84); pnlMonitorEnrollmentCount.Controls.Add(lblMonitorEnrollmentCountValue);
        pnlMonitorReceiptCount.BorderStyle = BorderStyle.FixedSingle; pnlMonitorReceiptCount.Location = new Point(560,104); pnlMonitorReceiptCount.Size = new Size(260,84); pnlMonitorReceiptCount.Controls.Add(lblMonitorReceiptCountValue);
        pnlMonitorDebtTotal.BorderStyle = BorderStyle.FixedSingle; pnlMonitorDebtTotal.Location = new Point(836,104); pnlMonitorDebtTotal.Size = new Size(292,84); pnlMonitorDebtTotal.Controls.Add(lblMonitorDebtTotalValue);
        foreach (var lbl in new[]{lblMonitorStudentCountValue,lblMonitorEnrollmentCountValue,lblMonitorReceiptCountValue,lblMonitorDebtTotalValue}) { lbl.Dock = DockStyle.Fill; lbl.TextAlign = ContentAlignment.MiddleCenter; lbl.Font = AppTheme.FontKpi; }
        dgvMonitorActivity.Location = new Point(8,208); dgvMonitorActivity.Size = new Size(690,430); dgvMonitorActivity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dgvMonitorActivity.RowHeadersVisible = false;
        dgvMonitorSource.Location = new Point(714,208); dgvMonitorSource.Size = new Size(414,430); dgvMonitorSource.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dgvMonitorSource.RowHeadersVisible = false;
        Controls.AddRange(new Control[]{pnlSystemMonitorFilterCard,pnlMonitorStudentCount,pnlMonitorEnrollmentCount,pnlMonitorReceiptCount,pnlMonitorDebtTotal,dgvMonitorActivity,dgvMonitorSource});
        Name = "FrmSystemMonitor"; ClientSize = new Size(1140,650);
        ((System.ComponentModel.ISupportInitialize)dgvMonitorActivity).EndInit(); ((System.ComponentModel.ISupportInitialize)dgvMonitorSource).EndInit(); ResumeLayout(false);
    }
}
