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
        pnlSystemMonitorFilterCard = new Panel();
        cboMonitorPeriod = new ComboBox();
        cboMonitorViewType = new ComboBox();
        btnViewMonitor = new Button();
        btnQuickExportMonitor = new Button();
        pnlMonitorStudentCount = new Panel();
        lblMonitorStudentCountValue = new Label();
        pnlMonitorEnrollmentCount = new Panel();
        lblMonitorEnrollmentCountValue = new Label();
        pnlMonitorReceiptCount = new Panel();
        lblMonitorReceiptCountValue = new Label();
        pnlMonitorDebtTotal = new Panel();
        lblMonitorDebtTotalValue = new Label();
        dgvMonitorActivity = new DataGridView();
        dgvMonitorSource = new DataGridView();
        pnlSystemMonitorFilterCard.SuspendLayout();
        pnlMonitorStudentCount.SuspendLayout();
        pnlMonitorEnrollmentCount.SuspendLayout();
        pnlMonitorReceiptCount.SuspendLayout();
        pnlMonitorDebtTotal.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMonitorActivity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvMonitorSource).BeginInit();
        SuspendLayout();
        // 
        // pnlSystemMonitorFilterCard
        // 
        pnlSystemMonitorFilterCard.BorderStyle = BorderStyle.FixedSingle;
        pnlSystemMonitorFilterCard.Controls.Add(cboMonitorPeriod);
        pnlSystemMonitorFilterCard.Controls.Add(cboMonitorViewType);
        pnlSystemMonitorFilterCard.Controls.Add(btnViewMonitor);
        pnlSystemMonitorFilterCard.Controls.Add(btnQuickExportMonitor);
        pnlSystemMonitorFilterCard.Location = new Point(8, 8);
        pnlSystemMonitorFilterCard.Name = "pnlSystemMonitorFilterCard";
        pnlSystemMonitorFilterCard.Size = new Size(1120, 80);
        pnlSystemMonitorFilterCard.TabIndex = 0;
        // 
        // cboMonitorPeriod
        // 
        cboMonitorPeriod.Items.AddRange(new object[] { "Hôm nay", "7 ngày", "30 ngày" });
        cboMonitorPeriod.Location = new Point(16, 24);
        cboMonitorPeriod.Name = "cboMonitorPeriod";
        cboMonitorPeriod.Size = new Size(180, 28);
        cboMonitorPeriod.TabIndex = 0;
        // 
        // cboMonitorViewType
        // 
        cboMonitorViewType.Items.AddRange(new object[] { "T?ng quan", "V?n hành", "C?nh báo" });
        cboMonitorViewType.Location = new Point(212, 24);
        cboMonitorViewType.Name = "cboMonitorViewType";
        cboMonitorViewType.Size = new Size(180, 28);
        cboMonitorViewType.TabIndex = 1;
        // 
        // btnViewMonitor
        // 
        btnViewMonitor.Location = new Point(408, 22);
        btnViewMonitor.Name = "btnViewMonitor";
        btnViewMonitor.Size = new Size(120, 28);
        btnViewMonitor.TabIndex = 2;
        btnViewMonitor.Text = "Xem dữ liệu";
        // 
        // btnQuickExportMonitor
        // 
        btnQuickExportMonitor.Location = new Point(540, 22);
        btnQuickExportMonitor.Name = "btnQuickExportMonitor";
        btnQuickExportMonitor.Size = new Size(120, 28);
        btnQuickExportMonitor.TabIndex = 3;
        btnQuickExportMonitor.Text = "Xuất nhanh";
        // 
        // pnlMonitorStudentCount
        // 
        pnlMonitorStudentCount.BorderStyle = BorderStyle.FixedSingle;
        pnlMonitorStudentCount.Controls.Add(lblMonitorStudentCountValue);
        pnlMonitorStudentCount.Location = new Point(8, 104);
        pnlMonitorStudentCount.Name = "pnlMonitorStudentCount";
        pnlMonitorStudentCount.Size = new Size(260, 84);
        pnlMonitorStudentCount.TabIndex = 1;
        // 
        // lblMonitorStudentCountValue
        // 
        lblMonitorStudentCountValue.Dock = DockStyle.Fill;
        lblMonitorStudentCountValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblMonitorStudentCountValue.Location = new Point(0, 0);
        lblMonitorStudentCountValue.Name = "lblMonitorStudentCountValue";
        lblMonitorStudentCountValue.Size = new Size(258, 82);
        lblMonitorStudentCountValue.TabIndex = 0;
        lblMonitorStudentCountValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlMonitorEnrollmentCount
        // 
        pnlMonitorEnrollmentCount.BorderStyle = BorderStyle.FixedSingle;
        pnlMonitorEnrollmentCount.Controls.Add(lblMonitorEnrollmentCountValue);
        pnlMonitorEnrollmentCount.Location = new Point(284, 104);
        pnlMonitorEnrollmentCount.Name = "pnlMonitorEnrollmentCount";
        pnlMonitorEnrollmentCount.Size = new Size(260, 84);
        pnlMonitorEnrollmentCount.TabIndex = 2;
        // 
        // lblMonitorEnrollmentCountValue
        // 
        lblMonitorEnrollmentCountValue.Dock = DockStyle.Fill;
        lblMonitorEnrollmentCountValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblMonitorEnrollmentCountValue.Location = new Point(0, 0);
        lblMonitorEnrollmentCountValue.Name = "lblMonitorEnrollmentCountValue";
        lblMonitorEnrollmentCountValue.Size = new Size(258, 82);
        lblMonitorEnrollmentCountValue.TabIndex = 0;
        lblMonitorEnrollmentCountValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlMonitorReceiptCount
        // 
        pnlMonitorReceiptCount.BorderStyle = BorderStyle.FixedSingle;
        pnlMonitorReceiptCount.Controls.Add(lblMonitorReceiptCountValue);
        pnlMonitorReceiptCount.Location = new Point(560, 104);
        pnlMonitorReceiptCount.Name = "pnlMonitorReceiptCount";
        pnlMonitorReceiptCount.Size = new Size(260, 84);
        pnlMonitorReceiptCount.TabIndex = 3;
        // 
        // lblMonitorReceiptCountValue
        // 
        lblMonitorReceiptCountValue.Dock = DockStyle.Fill;
        lblMonitorReceiptCountValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblMonitorReceiptCountValue.Location = new Point(0, 0);
        lblMonitorReceiptCountValue.Name = "lblMonitorReceiptCountValue";
        lblMonitorReceiptCountValue.Size = new Size(258, 82);
        lblMonitorReceiptCountValue.TabIndex = 0;
        lblMonitorReceiptCountValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlMonitorDebtTotal
        // 
        pnlMonitorDebtTotal.BorderStyle = BorderStyle.FixedSingle;
        pnlMonitorDebtTotal.Controls.Add(lblMonitorDebtTotalValue);
        pnlMonitorDebtTotal.Location = new Point(836, 104);
        pnlMonitorDebtTotal.Name = "pnlMonitorDebtTotal";
        pnlMonitorDebtTotal.Size = new Size(292, 84);
        pnlMonitorDebtTotal.TabIndex = 4;
        // 
        // lblMonitorDebtTotalValue
        // 
        lblMonitorDebtTotalValue.Dock = DockStyle.Fill;
        lblMonitorDebtTotalValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblMonitorDebtTotalValue.Location = new Point(0, 0);
        lblMonitorDebtTotalValue.Name = "lblMonitorDebtTotalValue";
        lblMonitorDebtTotalValue.Size = new Size(290, 82);
        lblMonitorDebtTotalValue.TabIndex = 0;
        lblMonitorDebtTotalValue.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // dgvMonitorActivity
        // 
        dgvMonitorActivity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvMonitorActivity.ColumnHeadersHeight = 29;
        dgvMonitorActivity.Location = new Point(8, 208);
        dgvMonitorActivity.Name = "dgvMonitorActivity";
        dgvMonitorActivity.RowHeadersVisible = false;
        dgvMonitorActivity.RowHeadersWidth = 51;
        dgvMonitorActivity.Size = new Size(690, 430);
        dgvMonitorActivity.TabIndex = 5;
        // 
        // dgvMonitorSource
        // 
        dgvMonitorSource.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvMonitorSource.ColumnHeadersHeight = 29;
        dgvMonitorSource.Location = new Point(714, 208);
        dgvMonitorSource.Name = "dgvMonitorSource";
        dgvMonitorSource.RowHeadersVisible = false;
        dgvMonitorSource.RowHeadersWidth = 51;
        dgvMonitorSource.Size = new Size(414, 430);
        dgvMonitorSource.TabIndex = 6;
        // 
        // FrmSystemMonitor
        // 
        ClientSize = new Size(1140, 650);
        Controls.Add(pnlSystemMonitorFilterCard);
        Controls.Add(pnlMonitorStudentCount);
        Controls.Add(pnlMonitorEnrollmentCount);
        Controls.Add(pnlMonitorReceiptCount);
        Controls.Add(pnlMonitorDebtTotal);
        Controls.Add(dgvMonitorActivity);
        Controls.Add(dgvMonitorSource);
        Name = "FrmSystemMonitor";
        pnlSystemMonitorFilterCard.ResumeLayout(false);
        pnlMonitorStudentCount.ResumeLayout(false);
        pnlMonitorEnrollmentCount.ResumeLayout(false);
        pnlMonitorReceiptCount.ResumeLayout(false);
        pnlMonitorDebtTotal.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvMonitorActivity).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvMonitorSource).EndInit();
        ResumeLayout(false);
    }
}
