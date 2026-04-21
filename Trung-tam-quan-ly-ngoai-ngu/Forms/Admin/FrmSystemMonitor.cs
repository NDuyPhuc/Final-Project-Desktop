using System.Windows.Forms.DataVisualization.Charting;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmSystemMonitor : Form
{
    public FrmSystemMonitor()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Giám sát hệ thống");
        dgvMonitorActivity.DataSource = DemoDataFactory.GetMonitorActivity();
        dgvMonitorSource.DataSource = DemoDataFactory.GetMonitorSource();
        lblMonitorStudentCountValue.Text = "245";
        lblMonitorEnrollmentCountValue.Text = "126";
        lblMonitorReceiptCountValue.Text = "47";
        lblMonitorDebtTotalValue.Text = "54.300.000";
    }
}
