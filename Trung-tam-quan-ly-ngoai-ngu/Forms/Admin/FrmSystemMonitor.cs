using TrungTamNgoaiNgu.Application.Contracts;
using System.Data;
using TrungTamNgoaiNgu.Application.Infrastructure;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmSystemMonitor : Form
{
    private readonly ILanguageCenterDataService _dataService;

    public FrmSystemMonitor() : this(AppRuntime.DataService)
    {
    }

    public FrmSystemMonitor(ILanguageCenterDataService dataService)
    {
        _dataService = dataService;

        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Giám sát hệ thống");

        ApplyLocalizedText();
        ConfigureView();
        ConfigureResponsiveLayout();
        btnViewMonitor.Click += (_, _) => BindMonitorData();
        btnMonitorToday.Click += (_, _) => BindMonitorData();
        btnQuickExportMonitor.Click += (_, _) => ExportMonitorLog();
        BindMonitorData();
    }

    private void ApplyLocalizedText()
    {
        Text = "Giám sát hệ thống";
        lblMonitorTitle.Text = "GIÁM SÁT HỆ THỐNG";
        lblMonitorSubtitle.Text = "Dữ liệu hệ thống thời gian thực | Trạng thái: đang kiểm tra";
        btnMonitorToday.Text = "HÔM NAY";

        lblMonitorPeriod.Text = "KHOẢNG THỜI GIAN";
        lblMonitorDepartment.Text = "BỘ PHẬN QUẢN LÝ";
        lblMonitorViewType.Text = "LOẠI HOẠT ĐỘNG";
        btnViewMonitor.Text = "LÀM MỚI";
        btnQuickExportMonitor.Text = "XUẤT NHANH";

        lblMonitorStudentCountTitle.Text = "TỔNG HỌC VIÊN";
        lblMonitorStudentCountTag.Text = "DỮ LIỆU THẬT";
        lblMonitorEnrollmentCountTitle.Text = "TÀI KHOẢN ACTIVE";
        lblMonitorEnrollmentCountTag.Text = "DỮ LIỆU THẬT";
        lblMonitorReceiptCountTitle.Text = "TỔNG GIÁO VIÊN";
        lblMonitorReceiptCountTag.Text = "DỮ LIỆU THẬT";
        lblMonitorDebtTotalTitle.Text = "TỔNG LỚP HỌC";
        lblMonitorDebtTotalTag.Text = "DỮ LIỆU THẬT";
        lblMonitorActivityTitle.Text = "NHẬT KÝ HOẠT ĐỘNG CHI TIẾT";
        lblMonitorActivityFooter.Text = "NHẬT KÝ TẢI TỪ HỆ THỐNG";
        lblMonitorSourceTitle.Text = "NGUỒN DỮ LIỆU / CHỈ BÁO";
        lblMonitorSourceStaffTitle.Text = "SỐ LIỆU HỆ THỐNG";
        lblMonitorSourceTeacherTitle.Text = "CHỈ BÁO DEMO";
        lblMonitorHealthTitle.Text = "MA TRẬN SỨC KHỎE HỆ THỐNG";
        lblMonitorHealthFootnote.Text = "* Các progress bar ở khối demo chỉ mang tính minh họa giao diện";
    }

    private void ConfigureView()
    {
        BackColor = Color.FromArgb(241, 248, 255);
        Padding = new Padding(16);
        MinimumSize = new Size(860, 620);

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
        btnViewMonitor.Dock = DockStyle.Fill;

        StyleKpiCard(pnlMonitorStudentCount, Color.FromArgb(18, 129, 122), Color.FromArgb(152, 241, 235));
        StyleKpiCard(pnlMonitorEnrollmentCount, Color.FromArgb(32, 91, 185), Color.FromArgb(205, 226, 255));
        StyleKpiCard(pnlMonitorReceiptCount, Color.FromArgb(22, 82, 167), Color.FromArgb(217, 232, 255));
        StyleKpiCard(pnlMonitorDebtTotal, Color.FromArgb(130, 58, 18), Color.FromArgb(255, 226, 197));

        AppTheme.StyleGrid(dgvMonitorActivity);
        dgvMonitorActivity.ReadOnly = true;
        dgvMonitorActivity.AllowUserToResizeRows = false;
        dgvMonitorActivity.DefaultCellStyle.SelectionBackColor = Color.FromArgb(216, 235, 251);
        dgvMonitorActivity.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        dgvMonitorActivity.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

        StyleSourceCard(pnlMonitorSourceCardStaff, Color.FromArgb(20, 72, 136));
        StyleSourceCard(pnlMonitorSourceCardTeacher, Color.FromArgb(126, 55, 18));

        foreach (var progressBar in new[] { prgMonitorSourceStaff1, prgMonitorSourceStaff2, prgMonitorSourceTeacher1, prgMonitorSourceTeacher2 })
        {
            progressBar.Style = ProgressBarStyle.Continuous;
        }

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
            panel.BackColor = Color.FromArgb(15, 120, 114);
        }

        pnlHealth18.BackColor = Color.FromArgb(227, 128, 135);
    }

    private void ConfigureResponsiveLayout()
    {
        splMonitorMain.FixedPanel = FixedPanel.None;
        splMonitorMain.Panel1MinSize = 420;
        splMonitorMain.Panel2MinSize = 280;
        splMonitorMain.SplitterWidth = 10;

        Resize += (_, _) => ApplyResponsiveBreakpoints();
        ApplyResponsiveBreakpoints();
    }

    private void ApplyResponsiveBreakpoints()
    {
        var width = Math.Max(780, ClientSize.Width - Padding.Horizontal);
        var compact = width < 1120;

        ConfigureFilterLayout(compact);
        ConfigureKpiLayout(compact);

        var desired = compact
            ? Math.Max(250, splMonitorMain.ClientSize.Height / 2)
            : Math.Max(420, splMonitorMain.ClientSize.Width - 330);

        FormHostHelpers.ApplyResponsiveSplit(
            splMonitorMain,
            compact ? Orientation.Horizontal : Orientation.Vertical,
            desired);

        btnMonitorToday.Width = compact ? 128 : 146;
        lblMonitorTitle.Font = compact
            ? new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic)
            : new Font("Segoe UI", 24F, FontStyle.Bold | FontStyle.Italic);
    }

    private void ConfigureFilterLayout(bool compact)
    {
        tblMonitorFilter.SuspendLayout();
        tblMonitorFilter.Controls.Clear();
        tblMonitorFilter.ColumnStyles.Clear();
        tblMonitorFilter.RowStyles.Clear();

        if (compact)
        {
            tblMonitorFilter.ColumnCount = 2;
            tblMonitorFilter.RowCount = 4;
            tblMonitorFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMonitorFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMonitorFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblMonitorFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblMonitorFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblMonitorFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            AddFilterControl(lblMonitorPeriod, 0, 0);
            AddFilterControl(lblMonitorDepartment, 1, 0);
            AddFilterControl(cboMonitorPeriod, 0, 1);
            AddFilterControl(cboMonitorDepartment, 1, 1);
            AddFilterControl(lblMonitorViewType, 0, 2);
            tblMonitorFilter.SetColumnSpan(lblMonitorViewType, 2);
            AddFilterControl(cboMonitorViewType, 0, 3);
            flpMonitorActions.Dock = DockStyle.Right;
            flpMonitorActions.FlowDirection = FlowDirection.LeftToRight;
            flpMonitorActions.AutoSize = true;
            AddFilterControl(flpMonitorActions, 1, 3);
        }
        else
        {
            tblMonitorFilter.ColumnCount = 4;
            tblMonitorFilter.RowCount = 2;
            tblMonitorFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            tblMonitorFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            tblMonitorFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            tblMonitorFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            tblMonitorFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblMonitorFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            AddFilterControl(lblMonitorPeriod, 0, 0);
            AddFilterControl(lblMonitorDepartment, 1, 0);
            AddFilterControl(lblMonitorViewType, 2, 0);
            AddFilterControl(cboMonitorPeriod, 0, 1);
            AddFilterControl(cboMonitorDepartment, 1, 1);
            AddFilterControl(cboMonitorViewType, 2, 1);
            flpMonitorActions.Dock = DockStyle.Fill;
            flpMonitorActions.FlowDirection = FlowDirection.TopDown;
            flpMonitorActions.AutoSize = false;
            AddFilterControl(flpMonitorActions, 3, 1);
        }

        tblMonitorFilter.ResumeLayout(true);
    }

    private void AddFilterControl(Control control, int column, int row)
    {
        control.Dock = control is FlowLayoutPanel ? control.Dock : DockStyle.Fill;
        tblMonitorFilter.Controls.Add(control, column, row);
    }

    private void ConfigureKpiLayout(bool compact)
    {
        tblMonitorKpi.SuspendLayout();
        tblMonitorKpi.Controls.Clear();
        tblMonitorKpi.ColumnStyles.Clear();
        tblMonitorKpi.RowStyles.Clear();

        if (compact)
        {
            tblMonitorKpi.ColumnCount = 2;
            tblMonitorKpi.RowCount = 2;
            tblMonitorKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMonitorKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMonitorKpi.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tblMonitorKpi.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            AddKpiControl(pnlMonitorStudentCount, 0, 0, new Padding(0, 0, 12, 12));
            AddKpiControl(pnlMonitorEnrollmentCount, 1, 0, new Padding(0, 0, 0, 12));
            AddKpiControl(pnlMonitorReceiptCount, 0, 1, new Padding(0, 0, 12, 0));
            AddKpiControl(pnlMonitorDebtTotal, 1, 1, Padding.Empty);
            tblMonitorKpi.Height = 272;
        }
        else
        {
            tblMonitorKpi.ColumnCount = 4;
            tblMonitorKpi.RowCount = 1;
            for (var index = 0; index < 4; index++)
            {
                tblMonitorKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }

            tblMonitorKpi.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            AddKpiControl(pnlMonitorStudentCount, 0, 0, new Padding(0, 0, 12, 0));
            AddKpiControl(pnlMonitorEnrollmentCount, 1, 0, new Padding(0, 0, 12, 0));
            AddKpiControl(pnlMonitorReceiptCount, 2, 0, new Padding(0, 0, 12, 0));
            AddKpiControl(pnlMonitorDebtTotal, 3, 0, Padding.Empty);
            tblMonitorKpi.Height = 128;
        }

        tblMonitorKpi.ResumeLayout(true);
    }

    private void AddKpiControl(Control control, int column, int row, Padding margin)
    {
        control.Dock = DockStyle.Fill;
        control.Margin = margin;
        tblMonitorKpi.Controls.Add(control, column, row);
    }

    private void BindMonitorData()
    {
        try
        {
            var logs = _dataService.GetMonitorDetailedLog();
            dgvMonitorActivity.DataSource = logs;

            var studentCount = _dataService.GetStudentList().Rows.Count;
            var teacherCount = _dataService.GetTeacherList().Rows.Count;
            var classCount = _dataService.GetClassList().Rows.Count;
            var activeAccounts = _dataService.GetAccounts().Count(x => !x.IsDeleted && x.Status.ToString().Equals("Active", StringComparison.OrdinalIgnoreCase));

            lblMonitorStudentCountValue.Text = studentCount.ToString("N0");
            lblMonitorEnrollmentCountValue.Text = activeAccounts.ToString("N0");
            lblMonitorReceiptCountValue.Text = teacherCount.ToString("N0");
            lblMonitorDebtTotalValue.Text = classCount.ToString("N0");
            lblMonitorSubtitle.Text = $"Lần cập nhật: {DateTime.Now:dd/MM/yyyy HH:mm:ss} | Trạng thái DB: sẵn sàng";
            lblMonitorActivityFooter.Text = $"HIỂN THỊ {logs.Rows.Count:N0} BẢN GHI NHẬT KÝ";

            lblMonitorSourceStaffRate1.Text = $"Học viên đang quản lý: {studentCount:N0}";
            lblMonitorSourceStaffRate2.Text = $"Giáo viên đang quản lý: {teacherCount:N0}";
            lblMonitorSourceTeacherRate1.Text = $"Chỉ báo giao diện 1 (mô phỏng)";
            lblMonitorSourceTeacherRate2.Text = $"Chỉ báo giao diện 2 (mô phỏng)";

            prgMonitorSourceStaff1.Value = Math.Min(100, Math.Max(5, studentCount % 101));
            prgMonitorSourceStaff2.Value = Math.Min(100, Math.Max(5, teacherCount % 101));
            prgMonitorSourceTeacher1.Value = 55;
            prgMonitorSourceTeacher2.Value = 25;
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmSystemMonitor));
            lblMonitorSubtitle.Text = $"Lần cập nhật: {DateTime.Now:dd/MM/yyyy HH:mm:ss} | Trạng thái DB: lỗi";
            MessageBox.Show(this, "Không tải được dữ liệu giám sát hệ thống. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ExportMonitorLog()
    {
        try
        {
            var table = dgvMonitorActivity.DataSource as DataTable ?? _dataService.GetMonitorDetailedLog();
            using var dialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FileName = $"system-monitor-{DateTime.Now:yyyyMMdd-HHmmss}.xlsx",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            ExportFileHelper.ExportDataTableToExcel(table, dialog.FileName, "SystemMonitor");
            MessageBox.Show(this, "Đã xuất nhanh nhật ký hệ thống ra Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmSystemMonitor));
            MessageBox.Show(this, "Không xuất được nhật ký hệ thống. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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
