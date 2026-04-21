using System.Windows.Forms.DataVisualization.Charting;

namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmAdminReports
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlAdminReportFilterCard; private ComboBox cboReportType; private DateTimePicker dtpReportFromDate; private DateTimePicker dtpReportToDate; private Button btnViewReport; private Button btnExportReportExcel; private Button btnExportReportPdf;
    private Panel pnlReportRevenue; private Panel pnlReportEnrollment; private Panel pnlReportClassCount; private Label lblReportRevenueValue; private Label lblReportEnrollmentValue; private Label lblReportClassCountValue;
    private Chart chtAdminRevenue; private DataGridView dgvAdminReportDetail;
    protected override void Dispose(bool disposing){ if(disposing && components!=null) components.Dispose(); base.Dispose(disposing);} 
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        pnlAdminReportFilterCard = new Panel(); cboReportType = new ComboBox(); dtpReportFromDate = new DateTimePicker(); dtpReportToDate = new DateTimePicker(); btnViewReport = new Button(); btnExportReportExcel = new Button(); btnExportReportPdf = new Button();
        pnlReportRevenue = new Panel(); pnlReportEnrollment = new Panel(); pnlReportClassCount = new Panel(); lblReportRevenueValue = new Label(); lblReportEnrollmentValue = new Label(); lblReportClassCountValue = new Label();
        chtAdminRevenue = new Chart(); dgvAdminReportDetail = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)chtAdminRevenue).BeginInit(); ((System.ComponentModel.ISupportInitialize)dgvAdminReportDetail).BeginInit(); SuspendLayout();
        pnlAdminReportFilterCard.BorderStyle = BorderStyle.FixedSingle; pnlAdminReportFilterCard.Location = new Point(8,8); pnlAdminReportFilterCard.Size = new Size(1120,80);
        cboReportType.Items.AddRange(new object[]{"Doanh thu","Ghi danh","Công n?"}); cboReportType.Location = new Point(16,24); cboReportType.Size = new Size(180,23); cboReportType.Name = "cboReportType";
        dtpReportFromDate.Location = new Point(212,24); dtpReportFromDate.Name = "dtpReportFromDate"; dtpReportToDate.Location = new Point(398,24); dtpReportToDate.Name = "dtpReportToDate";
        btnViewReport.Location = new Point(590,22); btnViewReport.Size = new Size(110,28); btnViewReport.Text = "Xem báo cáo"; btnExportReportExcel.Location = new Point(712,22); btnExportReportExcel.Size = new Size(110,28); btnExportReportExcel.Text = "Xu?t Excel"; btnExportReportPdf.Location = new Point(834,22); btnExportReportPdf.Size = new Size(110,28); btnExportReportPdf.Text = "Xu?t PDF";
        pnlAdminReportFilterCard.Controls.AddRange(new Control[]{cboReportType,dtpReportFromDate,dtpReportToDate,btnViewReport,btnExportReportExcel,btnExportReportPdf});
        pnlReportRevenue.BorderStyle = BorderStyle.FixedSingle; pnlReportRevenue.Location = new Point(8,104); pnlReportRevenue.Size = new Size(360,84); pnlReportRevenue.Controls.Add(lblReportRevenueValue);
        pnlReportEnrollment.BorderStyle = BorderStyle.FixedSingle; pnlReportEnrollment.Location = new Point(384,104); pnlReportEnrollment.Size = new Size(360,84); pnlReportEnrollment.Controls.Add(lblReportEnrollmentValue);
        pnlReportClassCount.BorderStyle = BorderStyle.FixedSingle; pnlReportClassCount.Location = new Point(760,104); pnlReportClassCount.Size = new Size(368,84); pnlReportClassCount.Controls.Add(lblReportClassCountValue);
        foreach (var lbl in new[]{lblReportRevenueValue,lblReportEnrollmentValue,lblReportClassCountValue}) { lbl.Dock = DockStyle.Fill; lbl.TextAlign = ContentAlignment.MiddleCenter; lbl.Font = AppTheme.FontKpi; }
        chtAdminRevenue.Location = new Point(8,208); chtAdminRevenue.Size = new Size(430,430); chtAdminRevenue.Name = "chtAdminRevenue"; chtAdminRevenue.ChartAreas.Add(new ChartArea("DefaultArea")); chtAdminRevenue.Legends.Add(new Legend("DefaultLegend"));
        dgvAdminReportDetail.Location = new Point(454,208); dgvAdminReportDetail.Size = new Size(674,430); dgvAdminReportDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dgvAdminReportDetail.RowHeadersVisible = false; dgvAdminReportDetail.Name = "dgvAdminReportDetail";
        Controls.AddRange(new Control[]{pnlAdminReportFilterCard,pnlReportRevenue,pnlReportEnrollment,pnlReportClassCount,chtAdminRevenue,dgvAdminReportDetail});
        Name = "FrmAdminReports"; ClientSize = new Size(1140,650);
        ((System.ComponentModel.ISupportInitialize)chtAdminRevenue).EndInit(); ((System.ComponentModel.ISupportInitialize)dgvAdminReportDetail).EndInit(); ResumeLayout(false);
    }
}
