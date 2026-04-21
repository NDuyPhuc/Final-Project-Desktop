using System.Windows.Forms.DataVisualization.Charting;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAdminReports : Form
{
    public FrmAdminReports()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Báo cáo thống kê");
        dgvAdminReportDetail.DataSource = DemoDataFactory.GetReportDetail();
        UiHelpers.BindRevenueSeries(chtAdminRevenue);
        lblReportRevenueValue.Text = "286.500.000";
        lblReportEnrollmentValue.Text = "152";
        lblReportClassCountValue.Text = "18";
    }
}
