using System.Data;
using System.Globalization;
using TrungTamNgoaiNgu.Application.Infrastructure;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmEnrollment : Form
{
    private readonly ErrorProvider _errEnrollment = new();
    private DataTable _studentTable = new();
    private DataTable _classTable = new();
    private string? _selectedStudentId;
    private string? _selectedClassId;
    private string? _currentEnrollmentId;
    private readonly string? _preselectedStudentId;
    private readonly string? _preselectedClassId;
    private ComboBox? _cboEnrollmentCourseFilter;

    public FrmEnrollment(string? preselectedStudentId = null, string? preselectedClassId = null)
    {
        _preselectedStudentId = preselectedStudentId;
        _preselectedClassId = preselectedClassId;
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Ghi danh học viên");
        ConfigureView();
        LoadData();
        WireEvents();
    }

    private void ConfigureView()
    {
        LocalizeLabels();
        MinimumSize = FormHostHelpers.ScaleSize(this, new Size(1200, 700));
        ConfigureEnrollmentLayout();
        flpEnrollmentActions.WrapContents = true;
        flpEnrollmentActions.Padding = FormHostHelpers.ScalePadding(this, new Padding(0, 8, 0, 0));

        AppTheme.StyleGrid(dgvEnrollmentStudentList);
        AppTheme.StyleGrid(dgvEnrollmentClassList);
        AppTheme.StylePrimaryButton(btnCreateEnrollment);
        AppTheme.StyleSecondaryButton(btnRefreshEnrollment);
        AppTheme.StyleSecondaryButton(btnOpenTuitionReceipt);
        InitializeCourseFilterUi();

        dgvEnrollmentStudentList.AutoGenerateColumns = true;
        dgvEnrollmentClassList.AutoGenerateColumns = true;
        dgvEnrollmentStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvEnrollmentClassList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvEnrollmentClassList.ScrollBars = ScrollBars.Vertical;

        cboEnrollmentStatus.SelectedIndex = 0;
        txtEnrollmentDiscount.Text = "0";
        txtEnrollmentOriginalFee.ReadOnly = true;
        txtEnrollmentFinalFee.ReadOnly = true;
        txtEnrollmentNote.ScrollBars = ScrollBars.Vertical;
        btnOpenTuitionReceipt.Enabled = false;
        _errEnrollment.BlinkStyle = ErrorBlinkStyle.NeverBlink;
    }

    private void ConfigureEnrollmentLayout()
    {
        AutoScroll = false;
        tblEnrollmentColumns.AutoScroll = false;
        tblEnrollmentColumns.SuspendLayout();
        try
        {
            tblEnrollmentColumns.Controls.Clear();
            tblEnrollmentColumns.ColumnStyles.Clear();
            tblEnrollmentColumns.RowStyles.Clear();
            tblEnrollmentColumns.ColumnCount = 2;
            tblEnrollmentColumns.RowCount = 1;
            tblEnrollmentColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68F));
            tblEnrollmentColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            tblEnrollmentColumns.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            var selectionStack = new TableLayoutPanel
            {
                Name = "tblEnrollmentSelectionStack",
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Margin = new Padding(0, 0, 12, 0),
                Padding = Padding.Empty,
                AutoScroll = false
            };
            selectionStack.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            selectionStack.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            selectionStack.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            grpEnrollmentStudentSelect.Dock = DockStyle.Fill;
            grpEnrollmentStudentSelect.Margin = new Padding(0, 0, 0, 10);
            grpEnrollmentClassSelect.Dock = DockStyle.Fill;
            grpEnrollmentClassSelect.Margin = new Padding(0);
            grpEnrollmentSummary.Dock = DockStyle.Fill;
            grpEnrollmentSummary.Margin = Padding.Empty;

            selectionStack.Controls.Add(grpEnrollmentStudentSelect, 0, 0);
            selectionStack.Controls.Add(grpEnrollmentClassSelect, 0, 1);
            tblEnrollmentColumns.Controls.Add(selectionStack, 0, 0);
            tblEnrollmentColumns.Controls.Add(grpEnrollmentSummary, 1, 0);
        }
        finally
        {
            tblEnrollmentColumns.ResumeLayout(true);
        }

        dgvEnrollmentStudentList.Dock = DockStyle.Fill;
        dgvEnrollmentClassList.Dock = DockStyle.Fill;
        dgvEnrollmentStudentList.ScrollBars = ScrollBars.Vertical;
        dgvEnrollmentClassList.ScrollBars = ScrollBars.Vertical;
    }

    private void WireEvents()
    {
        dgvEnrollmentStudentList.SelectionChanged += (_, _) => UpdateSelectedStudent();
        dgvEnrollmentClassList.SelectionChanged += (_, _) => UpdateSelectedClass();
        btnRefreshEnrollment.Click += (_, _) => LoadData();
        btnCreateEnrollment.Click += (_, _) => CreateEnrollment();
        btnOpenTuitionReceipt.Click += (_, _) => OpenTuitionReceipt();
        txtEnrollmentDiscount.TextChanged += (_, _) => RecalculateFinalFee();
        if (_cboEnrollmentCourseFilter is not null)
        {
            _cboEnrollmentCourseFilter.SelectedIndexChanged += (_, _) => LoadClassData();
        }
    }

    private void LoadData()
    {
        try
        {
            _studentTable = AppRuntime.DataService.GetEnrollmentStudents();
            dgvEnrollmentStudentList.DataSource = _studentTable;
            BindCourseFilter();
            LoadClassData();

            var studentFocused = !string.IsNullOrWhiteSpace(_preselectedStudentId) && FocusRowById(dgvEnrollmentStudentList, _preselectedStudentId);
            if (!studentFocused && dgvEnrollmentStudentList.Rows.Count > 0)
            {
                dgvEnrollmentStudentList.Rows[0].Selected = true;
                UpdateSelectedStudent();
            }

            var classFocused = !string.IsNullOrWhiteSpace(_preselectedClassId) && FocusRowById(dgvEnrollmentClassList, _preselectedClassId);
            if (!classFocused && dgvEnrollmentClassList.Rows.Count > 0)
            {
                dgvEnrollmentClassList.Rows[0].Selected = true;
                UpdateSelectedClass();
            }

            btnOpenTuitionReceipt.Enabled = !string.IsNullOrWhiteSpace(_currentEnrollmentId);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmEnrollment));
            MessageBox.Show(this, "Không tải được dữ liệu ghi danh. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadClassData()
    {
        var courseId = _cboEnrollmentCourseFilter?.SelectedValue?.ToString();
        if (string.Equals(courseId, "ALL", StringComparison.OrdinalIgnoreCase))
        {
            courseId = null;
        }

        _classTable = AppRuntime.DataService.GetEnrollmentClasses(courseId, true);
        dgvEnrollmentClassList.DataSource = _classTable;
        ConfigureClassGrid();
    }

    private void InitializeCourseFilterUi()
    {
        if (grpEnrollmentClassSelect.Controls.ContainsKey("pnlEnrollmentCourseFilter"))
        {
            return;
        }

        var panel = new Panel { Name = "pnlEnrollmentCourseFilter", Dock = DockStyle.Top, Height = 38 };
        var label = new Label { Text = "Khóa học", AutoSize = true, Dock = DockStyle.Left, Width = 80, TextAlign = ContentAlignment.MiddleLeft };
        _cboEnrollmentCourseFilter = new ComboBox { Name = "cboEnrollmentCourseFilter", Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
        panel.Controls.Add(_cboEnrollmentCourseFilter);
        panel.Controls.Add(label);
        grpEnrollmentClassSelect.Controls.Add(panel);
        panel.BringToFront();
    }

    private void BindCourseFilter()
    {
        if (_cboEnrollmentCourseFilter is null)
        {
            return;
        }

        var courses = AppRuntime.DataService.GetCourseList();
        var filterTable = new DataTable();
        filterTable.Columns.Add("Id");
        filterTable.Columns.Add("Name");
        filterTable.Rows.Add("ALL", "Tất cả khóa học");
        foreach (DataRow row in courses.Rows)
        {
            filterTable.Rows.Add(row[0]?.ToString() ?? string.Empty, row[1]?.ToString() ?? string.Empty);
        }

        _cboEnrollmentCourseFilter.DisplayMember = "Name";
        _cboEnrollmentCourseFilter.ValueMember = "Id";
        _cboEnrollmentCourseFilter.DataSource = filterTable;

        if (!string.IsNullOrWhiteSpace(_preselectedClassId))
        {
            var classEntity = AppRuntime.DataService.GetClassById(_preselectedClassId);
            if (classEntity is not null)
            {
                _cboEnrollmentCourseFilter.SelectedValue = classEntity.CourseId;
                return;
            }
        }

        _cboEnrollmentCourseFilter.SelectedValue = "ALL";
    }

    private static bool FocusRowById(DataGridView grid, string id)
    {
        foreach (DataGridViewRow row in grid.Rows)
        {
            if ((row.Cells[0].Value?.ToString() ?? string.Empty).Equals(id, StringComparison.OrdinalIgnoreCase))
            {
                row.Selected = true;
                grid.CurrentCell = row.Cells[0];
                return true;
            }
        }

        return false;
    }

    private void UpdateSelectedStudent()
    {
        if (dgvEnrollmentStudentList.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            return;
        }

        _selectedStudentId = rowView.Row[0]?.ToString();
        txtEnrollmentStudent.Text = BuildStudentSummary(rowView.Row);
    }

    private void UpdateSelectedClass()
    {
        if (dgvEnrollmentClassList.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            return;
        }

        _selectedClassId = rowView.Row[0]?.ToString();
        txtEnrollmentCourseClass.Text = BuildClassSummary(rowView.Row);
        txtEnrollmentOriginalFee.Text = rowView.Row[6]?.ToString() ?? "0";
        RecalculateFinalFee();
    }

    private void RecalculateFinalFee()
    {
        var originalFee = ParseMoney(txtEnrollmentOriginalFee.Text);
        var discount = ParseMoney(txtEnrollmentDiscount.Text);
        if (discount < 0)
        {
            discount = 0;
        }

        var finalFee = Math.Max(0, originalFee - discount);
        txtEnrollmentFinalFee.Text = finalFee.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
    }

    private void CreateEnrollment()
    {
        if (!ValidateEditor())
        {
            return;
        }

        try
        {
            if (AppRuntime.DataService.StudentAlreadyEnrolled(_selectedStudentId!, _selectedClassId!))
            {
                MessageBox.Show(this, "Học viên đã tồn tại trong lớp này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!AppRuntime.DataService.ClassHasAvailableSlot(_selectedClassId!))
            {
                MessageBox.Show(this, "Lớp học đã hết chỗ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var note = txtEnrollmentNote.Text.Trim();
            var discount = ParseMoney(txtEnrollmentDiscount.Text);
            if (discount > 0)
            {
                note = string.IsNullOrWhiteSpace(note)
                    ? $"Discount tu van: {discount:N0}"
                    : $"{note} | Discount tu van: {discount:N0}";
            }

            var enrollment = AppRuntime.DataService.CreateEnrollment(
                _selectedStudentId!,
                _selectedClassId!,
                dtpEnrollmentDate.Value.Date,
                cboEnrollmentStatus.Text,
                note);

            _currentEnrollmentId = enrollment.Id;
            btnOpenTuitionReceipt.Enabled = true;

            MessageBox.Show(this, "Đã tạo ghi danh thành công. Tiếp tục thu học phí ở bước tiếp theo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenTuitionReceipt();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmEnrollment));
            MessageBox.Show(this, "Không tạo được ghi danh. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void OpenTuitionReceipt()
    {
        if (string.IsNullOrWhiteSpace(_currentEnrollmentId))
        {
            MessageBox.Show(this, "Hãy tạo ghi danh trước khi thu học phí.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var form = new FrmTuitionReceipt(_currentEnrollmentId);
        form.ShowDialog(this);
    }

    private bool ValidateEditor()
    {
        _errEnrollment.Clear();

        if (string.IsNullOrWhiteSpace(_selectedStudentId))
        {
            _errEnrollment.SetError(dgvEnrollmentStudentList, "Chưa chọn học viên.");
        }

        if (string.IsNullOrWhiteSpace(_selectedClassId))
        {
            _errEnrollment.SetError(dgvEnrollmentClassList, "Chưa chọn lớp học.");
        }

        if (ParseMoney(txtEnrollmentDiscount.Text) < 0)
        {
            _errEnrollment.SetError(txtEnrollmentDiscount, "Mức giảm phải >= 0.");
        }

        return string.IsNullOrWhiteSpace(_errEnrollment.GetError(dgvEnrollmentStudentList))
            && string.IsNullOrWhiteSpace(_errEnrollment.GetError(dgvEnrollmentClassList))
            && string.IsNullOrWhiteSpace(_errEnrollment.GetError(txtEnrollmentDiscount));
    }

    private void LocalizeLabels()
    {
        lblEnrollmentDate.Text = "Ngày ghi danh";
        lblEnrollmentStudent.Text = "Học viên";
        lblEnrollmentCourseClass.Text = "Lớp học / khóa học";
        lblEnrollmentOriginalFee.Text = "Học phí gốc";
        lblEnrollmentDiscount.Text = "Giảm trừ";
        lblEnrollmentFinalFee.Text = "Học phí tạm tính";
        lblEnrollmentStatus.Text = "Trạng thái";
        lblEnrollmentNote.Text = "Ghi chú";

        cboEnrollmentStatus.Items.Clear();
        cboEnrollmentStatus.Items.AddRange(["Đang học", "Bảo lưu", "Đã nghỉ"]);

        btnCreateEnrollment.Text = "Tạo ghi danh";
        btnRefreshEnrollment.Text = "Làm mới";
        btnOpenTuitionReceipt.Text = "Thu học phí";
    }

    private static string BuildStudentSummary(DataRow row)
    {
        var studentId = row[0]?.ToString() ?? string.Empty;
        var fullName = row[1]?.ToString() ?? string.Empty;
        var phone = row[3]?.ToString() ?? string.Empty;
        return $"{studentId}{Environment.NewLine}{fullName}{Environment.NewLine}SDT: {phone}";
    }

    private static string BuildClassSummary(DataRow row)
    {
        var classId = row[0]?.ToString() ?? string.Empty;
        var className = row[1]?.ToString() ?? string.Empty;
        var courseName = row[2]?.ToString() ?? string.Empty;
        var schedule = row[4]?.ToString() ?? string.Empty;
        return $"{classId} - {className}{Environment.NewLine}{courseName}{Environment.NewLine}{schedule}";
    }

    private static decimal ParseMoney(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return 0;
        }

        var sanitized = input.Replace(".", string.Empty).Replace(",", string.Empty).Trim();
        return decimal.TryParse(sanitized, NumberStyles.Number, CultureInfo.InvariantCulture, out var value) ? value : 0;
    }

    private void ConfigureClassGrid()
    {
        foreach (DataGridViewColumn column in dgvEnrollmentClassList.Columns)
        {
            column.MinimumWidth = 60;
        }

        SetFillWeight("Ma lop", 70);
        SetFillWeight("Ten lop", 110);
        SetFillWeight("Khoa hoc", 110);
        SetFillWeight("Giao vien", 95);
        SetFillWeight("Lich hoc", 105);
        SetFillWeight("Si so", 55);
        SetFillWeight("Con cho", 55);
    }

    private void SetFillWeight(string columnName, float weight)
    {
        if (dgvEnrollmentClassList.Columns.Contains(columnName))
        {
            dgvEnrollmentClassList.Columns[columnName].FillWeight = weight;
        }
    }
}
