namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmSystemMonitor : Form
{
    public FrmSystemMonitor()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Giám sát hệ thống");
        ConfigureView();
        BindMockData();
    }

    private void ConfigureView()
    {
        BackColor = Color.FromArgb(241, 248, 255);
        cboMonitorPeriod.SelectedIndex = 0;
        cboMonitorDepartment.SelectedIndex = 0;
        cboMonitorViewType.SelectedIndex = 0;

        pnlMonitorHeader.BackColor = Color.Transparent;
        lblMonitorEyebrow.BackColor = Color.FromArgb(19, 72, 135);

        foreach (var card in new[]
                 {
                     pnlSystemMonitorFilterCard,
                     pnlMonitorStudentCount,
                     pnlMonitorEnrollmentCount,
                     pnlMonitorReceiptCount,
                     pnlMonitorDebtTotal,
                     pnlMonitorActivityCard,
                     pnlMonitorSourceCardStaff,
                     pnlMonitorSourceCardTeacher,
                     pnlMonitorHealthCard
                 })
        {
            AppTheme.StyleCard(card);
        }

        pnlSystemMonitorFilterCard.BackColor = Color.FromArgb(220, 239, 252);
        pnlMonitorSourceColumn.AutoScroll = true;
        btnMonitorToday.BackColor = Color.FromArgb(212, 233, 252);
        btnMonitorToday.ForeColor = Color.FromArgb(16, 67, 126);
        btnMonitorToday.FlatAppearance.BorderSize = 0;
        btnMonitorToday.FlatStyle = FlatStyle.Flat;
        btnMonitorToday.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

        btnViewMonitor.BackColor = Color.FromArgb(12, 71, 130);
        btnViewMonitor.ForeColor = Color.White;
        btnViewMonitor.FlatAppearance.BorderSize = 0;
        btnViewMonitor.FlatStyle = FlatStyle.Flat;
        btnViewMonitor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

        StyleKpiCard(pnlMonitorStudentCount, Color.FromArgb(18, 129, 122), Color.FromArgb(152, 241, 235));
        StyleKpiCard(pnlMonitorEnrollmentCount, Color.FromArgb(32, 91, 185), Color.FromArgb(205, 226, 255));
        StyleKpiCard(pnlMonitorReceiptCount, Color.FromArgb(22, 82, 167), Color.FromArgb(217, 232, 255));
        StyleKpiCard(pnlMonitorDebtTotal, Color.FromArgb(130, 58, 18), Color.FromArgb(255, 226, 197));

        AppTheme.StyleGrid(dgvMonitorActivity);
        dgvMonitorActivity.ReadOnly = true;
        dgvMonitorActivity.AllowUserToResizeRows = false;
        dgvMonitorActivity.DefaultCellStyle.SelectionBackColor = Color.FromArgb(216, 235, 251);

        StyleSourceCard(pnlMonitorSourceCardStaff, Color.FromArgb(20, 72, 136));
        StyleSourceCard(pnlMonitorSourceCardTeacher, Color.FromArgb(126, 55, 18));

        prgMonitorSourceStaff1.Style = ProgressBarStyle.Continuous;
        prgMonitorSourceStaff2.Style = ProgressBarStyle.Continuous;
        prgMonitorSourceTeacher1.Style = ProgressBarStyle.Continuous;
        prgMonitorSourceTeacher2.Style = ProgressBarStyle.Continuous;

        foreach (var panel in new[]
                 {
                     pnlHealth01, pnlHealth02, pnlHealth03, pnlHealth04, pnlHealth05,
                     pnlHealth06, pnlHealth07, pnlHealth08, pnlHealth09, pnlHealth10,
                     pnlHealth11, pnlHealth12, pnlHealth13, pnlHealth14, pnlHealth15,
                     pnlHealth16, pnlHealth17, pnlHealth18, pnlHealth19, pnlHealth20
                 })
        {
            panel.Margin = new Padding(3);
            panel.BorderStyle = BorderStyle.FixedSingle;
        }

        pnlHealth18.BackColor = Color.FromArgb(227, 128, 135);
        foreach (var panel in new[]
                 {
                     pnlHealth01, pnlHealth02, pnlHealth03, pnlHealth04, pnlHealth05,
                     pnlHealth06, pnlHealth07, pnlHealth08, pnlHealth09, pnlHealth10,
                     pnlHealth11, pnlHealth12, pnlHealth13, pnlHealth14, pnlHealth15,
                     pnlHealth16, pnlHealth17, pnlHealth19, pnlHealth20
                 })
        {
            panel.BackColor = Color.FromArgb(15, 120, 114);
        }
    }

    private void BindMockData()
    {
        dgvMonitorActivity.DataSource = DemoDataFactory.GetMonitorDetailedLog();

        lblMonitorStudentCountValue.Text = "99.9%";
        lblMonitorEnrollmentCountValue.Text = "142";
        lblMonitorReceiptCountValue.Text = "1,240";
        lblMonitorDebtTotalValue.Text = "856";

        lblMonitorSourceStaffRate1.Text = "Hồ sơ Ghi danh              482 flows/hr";
        lblMonitorSourceStaffRate2.Text = "Giao dịch Thanh toán      124 flows/hr";
        lblMonitorSourceTeacherRate1.Text = "Nhật ký Điểm danh         2,105 flows/hr";
        lblMonitorSourceTeacherRate2.Text = "Hệ thống Điểm số              15 flows/hr";

        prgMonitorSourceStaff1.Value = 82;
        prgMonitorSourceStaff2.Value = 36;
        prgMonitorSourceTeacher1.Value = 93;
        prgMonitorSourceTeacher2.Value = 14;
    }

    private static void StyleKpiCard(Panel panel, Color accentColor, Color tagBackColor)
    {
        var accentBar = new Panel
        {
            Dock = DockStyle.Left,
            Width = 4,
            BackColor = accentColor
        };

        panel.Controls.Add(accentBar);
        accentBar.BringToFront();

        foreach (var label in panel.Controls.OfType<Label>())
        {
            if (label.Name.EndsWith("Tag", StringComparison.Ordinal))
            {
                label.BackColor = tagBackColor;
                label.ForeColor = accentColor;
                label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                label.Padding = new Padding(10, 4, 10, 4);
            }
        }
    }

    private static void StyleSourceCard(Panel panel, Color accentColor)
    {
        var accentBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 3,
            BackColor = accentColor
        };

        panel.Controls.Add(accentBar);
        accentBar.BringToFront();

        foreach (var label in panel.Controls.OfType<Label>())
        {
            if (label.Name.EndsWith("Live", StringComparison.Ordinal))
            {
                label.BackColor = accentColor;
                label.ForeColor = Color.White;
                label.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                label.Padding = new Padding(8, 3, 8, 3);
            }
        }
    }

    private void lblMonitorStudentCountTag_Click(object sender, EventArgs e)
    {

    }

    private void lblMonitorEnrollmentCountTag_Click(object sender, EventArgs e)
    {

    }
}
