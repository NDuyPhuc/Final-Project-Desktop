using System.Data;
using TrungTamNgoaiNgu.Application.Infrastructure;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmClassStudentList : Form
{
    private DataTable _classTable = new();
    private DataTable _studentTable = new();

    public FrmClassStudentList()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Danh sách học viên lớp");
        ConfigureView();
        LoadClasses();
        WireEvents();
    }

    private void ConfigureView()
    {
        AppTheme.StyleGrid(dgvClassStudentList);
        AppTheme.StyleSecondaryButton(btnSearchClassStudent);
        AppTheme.StyleSecondaryButton(btnRefreshClassStudent);
        AppTheme.StylePrimaryButton(btnOpenAttendanceFromStudentList);
        AppTheme.StylePrimaryButton(btnOpenScoreFromStudentList);
        AppTheme.StyleSecondaryButton(btnBackToTeachingClasses);
        ConfigureClassStudentLayout();

        dgvClassStudentList.AutoGenerateColumns = true;
        dgvClassStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvClassStudentList.ScrollBars = ScrollBars.Vertical;
        txtClassStudentKeyword.PlaceholderText = "Tìm theo mã hoặc tên học viên";

        cboClassStudentContext.Items.Clear();
        cboClassStudentContext.Items.AddRange(["Tất cả", "Đang học", "Bảo lưu", "Đã nghỉ"]);
        cboClassStudentContext.SelectedIndex = 0;
    }

    private void ConfigureClassStudentLayout()
    {
        AutoScroll = false;
        MinimumSize = FormHostHelpers.ScaleSize(this, new Size(1100, 660));

        tblClassStudentRoot.SuspendLayout();
        tblClassStudentRoot.Controls.Clear();
        tblClassStudentRoot.ColumnStyles.Clear();
        tblClassStudentRoot.RowStyles.Clear();
        tblClassStudentRoot.ColumnCount = 1;
        tblClassStudentRoot.RowCount = 3;
        tblClassStudentRoot.Dock = DockStyle.Fill;
        tblClassStudentRoot.Padding = new Padding(16);
        tblClassStudentRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblClassStudentRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, FormHostHelpers.ScaleForDpi(this, 96)));
        tblClassStudentRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, FormHostHelpers.ScaleForDpi(this, 104)));
        tblClassStudentRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        ConfigureFilterCardLayout();
        ConfigureSummaryLayout();

        pnlClassStudentFilterCard.Dock = DockStyle.Fill;
        pnlClassStudentFilterCard.Margin = new Padding(0, 0, 0, 10);
        pnlClassStudentSummary.Dock = DockStyle.Fill;
        pnlClassStudentSummary.Margin = new Padding(0, 0, 0, 12);
        dgvClassStudentList.Dock = DockStyle.Fill;
        dgvClassStudentList.Margin = Padding.Empty;

        tblClassStudentRoot.Controls.Add(pnlClassStudentFilterCard, 0, 0);
        tblClassStudentRoot.Controls.Add(pnlClassStudentSummary, 0, 1);
        tblClassStudentRoot.Controls.Add(dgvClassStudentList, 0, 2);
        tblClassStudentRoot.ResumeLayout(true);
    }

    private void ConfigureFilterCardLayout()
    {
        pnlClassStudentFilterCard.SuspendLayout();
        pnlClassStudentFilterCard.Controls.Clear();
        pnlClassStudentFilterCard.BackColor = Color.White;
        pnlClassStudentFilterCard.BorderStyle = BorderStyle.FixedSingle;
        pnlClassStudentFilterCard.Padding = new Padding(16, 12, 16, 12);
        pnlClassStudentFilterCard.AutoScroll = false;

        lblClassStudentClass.AutoSize = false;
        lblClassStudentClass.Dock = DockStyle.Fill;
        lblClassStudentClass.TextAlign = ContentAlignment.BottomLeft;
        lblClassStudentClass.Margin = new Padding(0, 0, 12, 4);

        lblClassStudentContext.AutoSize = false;
        lblClassStudentContext.Dock = DockStyle.Fill;
        lblClassStudentContext.TextAlign = ContentAlignment.BottomLeft;
        lblClassStudentContext.Margin = new Padding(0, 0, 12, 4);

        cboClassStudentClass.Dock = DockStyle.Fill;
        cboClassStudentClass.Margin = new Padding(0, 0, 12, 0);
        cboClassStudentContext.Dock = DockStyle.Fill;
        cboClassStudentContext.Margin = new Padding(0, 0, 12, 0);
        txtClassStudentKeyword.Dock = DockStyle.Fill;
        txtClassStudentKeyword.Margin = new Padding(0, 0, 12, 0);

        var keywordLabel = new Label
        {
            Text = "Tim hoc vien",
            AutoSize = false,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.BottomLeft,
            Margin = new Padding(0, 0, 12, 4),
            Font = new Font("Segoe UI", 9F, FontStyle.Regular),
            ForeColor = Color.FromArgb(58, 77, 98)
        };

        var actionFlow = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = true,
            AutoScroll = false,
            Margin = Padding.Empty,
            Padding = Padding.Empty
        };

        foreach (var button in new[]
        {
            btnSearchClassStudent,
            btnRefreshClassStudent,
            btnOpenAttendanceFromStudentList,
            btnOpenScoreFromStudentList,
            btnBackToTeachingClasses
        })
        {
            button.Height = FormHostHelpers.ScaleForDpi(this, 34);
            button.Width = button == btnBackToTeachingClasses
                ? FormHostHelpers.ScaleForDpi(this, 116)
                : FormHostHelpers.ScaleForDpi(this, 104);
            button.Margin = new Padding(0, 0, 8, 8);
        }

        actionFlow.Controls.Add(btnSearchClassStudent);
        actionFlow.Controls.Add(btnRefreshClassStudent);
        actionFlow.Controls.Add(btnOpenAttendanceFromStudentList);
        actionFlow.Controls.Add(btnOpenScoreFromStudentList);
        actionFlow.Controls.Add(btnBackToTeachingClasses);

        var filterLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 4,
            RowCount = 2,
            Margin = Padding.Empty,
            Padding = Padding.Empty
        };
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, FormHostHelpers.ScaleForDpi(this, 200)));
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, FormHostHelpers.ScaleForDpi(this, 210)));
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, FormHostHelpers.ScaleForDpi(this, 510)));
        filterLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, FormHostHelpers.ScaleForDpi(this, 28)));
        filterLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        filterLayout.Controls.Add(lblClassStudentClass, 0, 0);
        filterLayout.Controls.Add(lblClassStudentContext, 1, 0);
        filterLayout.Controls.Add(keywordLabel, 2, 0);
        filterLayout.Controls.Add(cboClassStudentClass, 0, 1);
        filterLayout.Controls.Add(cboClassStudentContext, 1, 1);
        filterLayout.Controls.Add(txtClassStudentKeyword, 2, 1);
        filterLayout.Controls.Add(actionFlow, 3, 0);
        filterLayout.SetRowSpan(actionFlow, 2);

        pnlClassStudentFilterCard.Controls.Add(filterLayout);
        pnlClassStudentFilterCard.ResumeLayout(true);
    }

    private void ConfigureSummaryLayout()
    {
        pnlClassStudentSummary.SuspendLayout();
        pnlClassStudentSummary.Controls.Clear();
        pnlClassStudentSummary.BackColor = Color.Transparent;
        pnlClassStudentSummary.AutoScroll = false;
        pnlClassStudentCount.Visible = true;
        pnlClassStudentSchedule.Visible = true;

        ConfigureSummaryCard(pnlClassStudentCount, lblClassStudentCountValue, "Hoc vien", 18F);
        ConfigureSummaryCard(pnlClassStudentSchedule, lblClassStudentScheduleValue, "Lich hoc / trang thai", 13F);

        var summaryLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Left,
            Width = FormHostHelpers.ScaleForDpi(this, 520),
            ColumnCount = 2,
            RowCount = 1,
            Margin = Padding.Empty,
            Padding = Padding.Empty
        };
        summaryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
        summaryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62F));
        summaryLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        summaryLayout.Controls.Add(pnlClassStudentCount, 0, 0);
        summaryLayout.Controls.Add(pnlClassStudentSchedule, 1, 0);

        pnlClassStudentSummary.Controls.Add(summaryLayout);
        pnlClassStudentSummary.ResumeLayout(true);
    }

    private static void ConfigureSummaryCard(Panel panel, Label valueLabel, string title, float valueFontSize)
    {
        panel.SuspendLayout();
        panel.Controls.Clear();
        panel.Dock = DockStyle.Fill;
        panel.Margin = new Padding(0, 0, 12, 0);
        panel.Padding = new Padding(14, 10, 14, 10);
        panel.BackColor = Color.White;
        panel.BorderStyle = BorderStyle.FixedSingle;

        var titleLabel = new Label
        {
            Text = title,
            AutoSize = false,
            Dock = DockStyle.Top,
            Height = 24,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            ForeColor = Color.FromArgb(58, 77, 98)
        };

        valueLabel.AutoSize = false;
        valueLabel.Dock = DockStyle.Fill;
        valueLabel.TextAlign = ContentAlignment.MiddleLeft;
        valueLabel.Font = new Font("Segoe UI", valueFontSize, FontStyle.Bold);
        valueLabel.Padding = new Padding(0, 4, 0, 0);

        panel.Controls.Add(valueLabel);
        panel.Controls.Add(titleLabel);
        panel.ResumeLayout(true);
    }

    private void WireEvents()
    {
        cboClassStudentClass.SelectedIndexChanged += (_, _) => LoadStudents();
        btnSearchClassStudent.Click += (_, _) => ApplyFilters();
        btnRefreshClassStudent.Click += (_, _) => ResetFilters();
        btnOpenAttendanceFromStudentList.Click += (_, _) =>
        {
            using var form = new FrmAttendance();
            form.ShowDialog(this);
        };
        btnOpenScoreFromStudentList.Click += (_, _) =>
        {
            using var form = new FrmScoreEntry();
            form.ShowDialog(this);
        };
        btnBackToTeachingClasses.Click += (_, _) =>
        {
            using var form = new FrmTeachingClasses();
            form.ShowDialog(this);
        };
    }

    private void LoadClasses()
    {
        try
        {
            _classTable = AppRuntime.DataService.GetTeachingClasses(AppRuntime.CurrentUser?.Id);
            cboClassStudentClass.DisplayMember = "Ten lop";
            cboClassStudentClass.ValueMember = "Ma lop";
            cboClassStudentClass.DataSource = _classTable;
            LoadStudents();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmClassStudentList));
            MessageBox.Show(this, "Không tải được danh sách lớp. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadStudents()
    {
        try
        {
            var classId = GetSelectedClassId();
            _studentTable = AppRuntime.DataService.GetClassStudents(classId);
            dgvClassStudentList.DataSource = _studentTable;
            UpdateSummary(classId);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmClassStudentList));
            MessageBox.Show(this, "Không tải được danh sách học viên lớp. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ApplyFilters()
    {
        var keyword = txtClassStudentKeyword.Text.Trim();
        var status = cboClassStudentContext.Text;
        var filtered = _studentTable.Clone();

        foreach (DataRow row in _studentTable.Rows)
        {
            var studentId = GetField(row, "Ma hoc vien");
            var fullName = GetField(row, "Ho ten");
            var studentStatus = GetField(row, "Trang thai");

            var matchesKeyword = string.IsNullOrWhiteSpace(keyword)
                || studentId.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                || fullName.Contains(keyword, StringComparison.OrdinalIgnoreCase);
            var matchesStatus = status is "Tat ca" or "Tất cả" || studentStatus.Equals(status, StringComparison.OrdinalIgnoreCase);

            if (matchesKeyword && matchesStatus)
            {
                filtered.ImportRow(row);
            }
        }

        dgvClassStudentList.DataSource = filtered;
        lblClassStudentCountValue.Text = filtered.Rows.Count.ToString();
    }

    private void ResetFilters()
    {
        txtClassStudentKeyword.Clear();
        cboClassStudentContext.SelectedIndex = 0;
        dgvClassStudentList.DataSource = _studentTable;
        lblClassStudentCountValue.Text = _studentTable.Rows.Count.ToString();
    }

    private void UpdateSummary(string? classId)
    {
        lblClassStudentCountValue.Text = _studentTable.Rows.Count.ToString();
        lblClassStudentContext.Text = "Trạng thái học viên";

        if (string.IsNullOrWhiteSpace(classId))
        {
            lblClassStudentScheduleValue.Text = "-";
            return;
        }

        var teachingClass = _classTable.AsEnumerable().FirstOrDefault(row => GetField(row, "Ma lop") == classId);
        lblClassStudentScheduleValue.Text = teachingClass is null
            ? "-"
            : $"{GetField(teachingClass, "Lich hoc")} | {GetField(teachingClass, "Trang thai")}";
    }

    private string? GetSelectedClassId()
    {
        return cboClassStudentClass.SelectedValue is string value
            ? value
            : cboClassStudentClass.SelectedItem is DataRowView rowView
                ? GetField(rowView.Row, "Ma lop")
                : null;
    }

    private static string GetField(DataRow row, string columnName)
    {
        return row.Table.Columns.Contains(columnName)
            ? row[columnName]?.ToString() ?? string.Empty
            : string.Empty;
    }
}
