using System.Data;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Domain.Entities;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmClassManagement : Form
{
    private readonly ErrorProvider _errClass = new();
    private DataTable _classTable = new();
    private Button? _btnDeleteClass;

    public FrmClassManagement()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Quản lý lớp học");
        ConfigureView();
        LoadClasses();
        WireEvents();
    }

    private void ConfigureView()
    {
        LocalizeLabels();
        ConfigureClassInfoRows();
        MinimumSize = FormHostHelpers.ScaleSize(this, new Size(1140, 700));
        splClassContent.Panel1MinSize = FormHostHelpers.ScaleForDpi(this, 360);
        splClassContent.Panel2MinSize = FormHostHelpers.ScaleForDpi(this, 420);
        splClassContent.SplitterWidth = FormHostHelpers.ScaleForDpi(this, 8);
        pnlClassFilterCard.Height = FormHostHelpers.ScaleForDpi(this, 96);
        flpClassActions.WrapContents = true;
        flpClassActions.Padding = FormHostHelpers.ScalePadding(this, new Padding(0, 8, 0, 0));

        AppTheme.StyleGrid(dgvClassList);
        AppTheme.StyleGrid(dgvClassStudentList);
        AppTheme.StyleGrid(dgvClassSessionList);
        AppTheme.StyleSecondaryButton(btnSearchClass);
        AppTheme.StyleSecondaryButton(btnRefreshClass);
        AppTheme.StylePrimaryButton(btnCreateClass);
        AppTheme.StylePrimaryButton(btnSaveClass);
        AppTheme.StylePrimaryButton(btnUpdateClass);
        AppTheme.StyleSecondaryButton(btnOpenEnrollmentFromClass);
        AppTheme.StyleSecondaryButton(btnGenerateSessions);
        EnsureDeleteClassButton();
        if (_btnDeleteClass is not null)
        {
            AppTheme.StyleDangerButton(_btnDeleteClass);
        }

        dgvClassList.AutoGenerateColumns = true;
        dgvClassStudentList.AutoGenerateColumns = true;
        dgvClassSessionList.AutoGenerateColumns = true;
        dgvClassList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvClassStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvClassSessionList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dtpClassStartDate.Format = DateTimePickerFormat.Custom;
        dtpClassStartDate.CustomFormat = "dd/MM/yyyy";
        dtpClassEndDate.Format = DateTimePickerFormat.Custom;
        dtpClassEndDate.CustomFormat = "dd/MM/yyyy";

        txtClassCourse.PlaceholderText = "Gõ mã hoặc tên khóa, hệ thống sẽ gợi ý";
        txtClassTeacher.PlaceholderText = "Gõ mã GV hoặc họ tên, hệ thống sẽ gợi ý";
        ConfigureLookupAutoComplete();
        cboClassStatusFilter.SelectedIndex = 0;
        cboClassDetailStatus.SelectedIndex = 0;
        _errClass.BlinkStyle = ErrorBlinkStyle.NeverBlink;
    }

    private void ConfigureClassInfoRows()
    {
        tblClassInfo.SuspendLayout();
        try
        {
            tblClassInfo.RowStyles.Clear();
            tblClassInfo.RowCount = 10;
            var rowHeight = FormHostHelpers.ScaleForDpi(this, 40);
            for (var index = 0; index < tblClassInfo.RowCount; index++)
            {
                tblClassInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));
            }

            tblClassInfo.AutoScroll = true;
            txtClassSize.Dock = DockStyle.Left;
            txtClassSize.Width = FormHostHelpers.ScaleForDpi(this, 180);
            cboClassDetailStatus.Dock = DockStyle.Left;
            cboClassDetailStatus.Width = FormHostHelpers.ScaleForDpi(this, 180);
        }
        finally
        {
            tblClassInfo.ResumeLayout(true);
        }
    }

    private void WireEvents()
    {
        dgvClassList.SelectionChanged += (_, _) => PopulateDetailFromSelection();
        btnSearchClass.Click += (_, _) => LoadClasses(txtClassKeyword.Text.Trim(), cboClassStatusFilter.Text);
        btnRefreshClass.Click += (_, _) => ResetFilters();
        btnCreateClass.Click += (_, _) => StartCreateClass();
        btnSaveClass.Click += (_, _) => SaveCurrentClass();
        btnUpdateClass.Click += (_, _) => SaveCurrentClass();
        btnGenerateSessions.Click += (_, _) => RefreshSessionsForCurrentClass();
        if (_btnDeleteClass is not null)
        {
            _btnDeleteClass.Click += (_, _) => DeleteSelectedClass();
        }
        btnOpenEnrollmentFromClass.Click += (_, _) => OpenEnrollmentFromClass();
        txtClassCourse.Leave += (_, _) => NormalizeCourseInput();
        txtClassTeacher.Leave += (_, _) => NormalizeTeacherInput();
    }

    private void LoadClasses(string? keyword = null, string? status = null)
    {
        try
        {
            _classTable = AppRuntime.DataService.GetClassList(
                string.IsNullOrWhiteSpace(keyword) ? null : keyword,
                string.IsNullOrWhiteSpace(status) || status is "Tat ca" or "Tất cả" ? null : status);

            dgvClassList.DataSource = _classTable;
            SelectFirstClass();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmClassManagement));
            MessageBox.Show(this, "Không tải được danh sách lớp học. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void StartCreateClass()
    {
        ResetDetailEditor();
        txtClassCode.Text = AppRuntime.DataService.GetNextClassId();
        cboClassDetailStatus.Text = "Đang mở";
        dtpClassStartDate.Value = DateTime.Today;
        dtpClassEndDate.Value = DateTime.Today.AddMonths(2);
        txtClassName.Focus();
    }

    private void SaveCurrentClass()
    {
        if (!ValidateEditor(out var courseId, out var teacherId, out var maxStudents))
        {
            ValidationFeedback.ShowFirstError(this, _errClass,
                txtClassCode,
                txtClassName,
                txtClassCourse,
                txtClassTeacher,
                txtClassSize,
                dtpClassEndDate);
            return;
        }

        try
        {
            var classId = txtClassCode.Text.Trim();
            var isCreating = AppRuntime.DataService.GetClassById(classId) is null;
            var entity = new ClassEntity
            {
                Id = classId,
                Name = txtClassName.Text.Trim(),
                CourseId = courseId,
                TeacherId = teacherId,
                StartDate = dtpClassStartDate.Value.Date,
                EndDate = dtpClassEndDate.Value.Date,
                Schedule = txtClassSchedule.Text.Trim(),
                Room = txtClassRoom.Text.Trim(),
                MaxStudents = maxStudents,
                Status = cboClassDetailStatus.Text,
                IsDeleted = false
            };

            entity = AppRuntime.DataService.SaveClass(entity);
            LoadClasses(txtClassKeyword.Text.Trim(), cboClassStatusFilter.Text);
            FocusClass(entity.Id);
            MessageBox.Show(this, isCreating ? "Đã thêm lớp học thành công." : "Đã cập nhật lớp học thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmClassManagement));
            MessageBox.Show(this, $"Không lưu được lớp học: {ex.GetBaseException().Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DeleteSelectedClass()
    {
        if (string.IsNullOrWhiteSpace(txtClassCode.Text))
        {
            MessageBox.Show(this, "Hãy chọn lớp học cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (AppRuntime.DataService.GetClassById(txtClassCode.Text.Trim()) is null)
        {
            MessageBox.Show(this, "Lớp học chưa được lưu nên không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var dialog = new FrmConfirmDialog("Xóa lớp học", "Bạn có chắc muốn xóa mềm lớp học đang chọn không?");
        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        try
        {
            AppRuntime.DataService.SoftDeleteClass(txtClassCode.Text.Trim());
            LoadClasses(txtClassKeyword.Text.Trim(), cboClassStatusFilter.Text);
            ResetDetailEditor();
            MessageBox.Show(this, "Đã xóa mềm lớp học thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmClassManagement));
            MessageBox.Show(this, "Không xóa được lớp học. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void RefreshSessionsForCurrentClass()
    {
        var classId = txtClassCode.Text.Trim();
        if (string.IsNullOrWhiteSpace(classId) || AppRuntime.DataService.GetClassById(classId) is null)
        {
            MessageBox.Show(this, "Hãy chọn hoặc lưu lớp học trước khi làm mới danh sách buổi học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            dgvClassSessionList.DataSource = AppRuntime.DataService.GetSessions(classId);
            tabClassManagement.SelectedTab = tpClassSessions;
            MessageBox.Show(this, "Đã làm mới danh sách buổi học theo lịch học, ngày bắt đầu và ngày kết thúc của lớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmClassManagement));
            MessageBox.Show(this, "Không làm mới được danh sách buổi học. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void PopulateDetailFromSelection()
    {
        if (dgvClassList.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            return;
        }

        var classId = rowView.Row[0]?.ToString();
        if (string.IsNullOrWhiteSpace(classId))
        {
            return;
        }

        try
        {
            var entity = AppRuntime.DataService.GetClassById(classId);
            if (entity is null)
            {
                return;
            }

            txtClassCode.Text = entity.Id;
            txtClassName.Text = entity.Name;
            txtClassSchedule.Text = entity.Schedule ?? string.Empty;
            txtClassRoom.Text = entity.Room ?? string.Empty;
            txtClassSize.Text = entity.MaxStudents.ToString();
            dtpClassStartDate.Value = entity.StartDate == default ? DateTime.Today : entity.StartDate;
            dtpClassEndDate.Value = entity.EndDate == default ? DateTime.Today : entity.EndDate;
            cboClassDetailStatus.Text = string.IsNullOrWhiteSpace(entity.Status) ? "Đang mở" : entity.Status;

            var course = AppRuntime.DataService.GetCourseById(entity.CourseId);
            var teacher = AppRuntime.DataService.GetTeacherById(entity.TeacherId);
            txtClassCourse.Text = course is null ? entity.CourseId : $"{course.Id} - {course.Name}";
            txtClassTeacher.Text = teacher is null ? entity.TeacherId : $"{teacher.Id} - {teacher.FullName}";

            dgvClassStudentList.DataSource = AppRuntime.DataService.GetClassStudents(entity.Id);
            dgvClassSessionList.DataSource = AppRuntime.DataService.GetSessions(entity.Id);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmClassManagement));
            MessageBox.Show(this, "Không tải được chi tiết lớp học. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SelectFirstClass()
    {
        if (dgvClassList.Rows.Count > 0)
        {
            dgvClassList.Rows[0].Selected = true;
            PopulateDetailFromSelection();
            return;
        }

        ResetDetailEditor();
    }

    private void FocusClass(string classId)
    {
        foreach (DataGridViewRow row in dgvClassList.Rows)
        {
            if ((row.Cells[0].Value?.ToString() ?? string.Empty).Equals(classId, StringComparison.OrdinalIgnoreCase))
            {
                row.Selected = true;
                dgvClassList.CurrentCell = row.Cells[0];
                PopulateDetailFromSelection();
                return;
            }
        }
    }

    private bool ValidateEditor(out string courseId, out string teacherId, out int maxStudents)
    {
        _errClass.Clear();
        courseId = string.Empty;
        teacherId = string.Empty;
        maxStudents = 0;

        if (string.IsNullOrWhiteSpace(txtClassCode.Text))
        {
            _errClass.SetError(txtClassCode, "Mã lớp không được để trống.");
        }

        if (string.IsNullOrWhiteSpace(txtClassName.Text))
        {
            _errClass.SetError(txtClassName, "Tên lớp không được để trống.");
        }

        courseId = ResolveCourseId(txtClassCourse.Text.Trim());
        if (string.IsNullOrWhiteSpace(courseId))
        {
            _errClass.SetError(txtClassCourse, "Chọn khóa học từ danh sách gợi ý hoặc gõ đúng mã/tên khóa.");
        }

        teacherId = ResolveTeacherId(txtClassTeacher.Text.Trim());
        if (string.IsNullOrWhiteSpace(teacherId))
        {
            _errClass.SetError(txtClassTeacher, "Chọn giáo viên từ danh sách gợi ý hoặc gõ đúng mã/tên giáo viên.");
        }

        if (!int.TryParse(txtClassSize.Text.Trim(), out maxStudents) || maxStudents <= 0)
        {
            _errClass.SetError(txtClassSize, "Sĩ số tối đa phải > 0.");
        }
        else if (AppRuntime.DataService.GetClassById(txtClassCode.Text.Trim()) is not null)
        {
            var currentStudentCount = GetCurrentClassStudentCount(txtClassCode.Text.Trim());
            if (maxStudents < currentStudentCount)
            {
                _errClass.SetError(txtClassSize, $"Sĩ số tối đa không được nhỏ hơn số học viên hiện tại ({currentStudentCount}).");
            }
        }

        if (dtpClassStartDate.Value.Date > dtpClassEndDate.Value.Date)
        {
            _errClass.SetError(dtpClassEndDate, "Ngày kết thúc phải >= ngày bắt đầu.");
        }

        return string.IsNullOrWhiteSpace(_errClass.GetError(txtClassCode))
            && string.IsNullOrWhiteSpace(_errClass.GetError(txtClassName))
            && string.IsNullOrWhiteSpace(_errClass.GetError(txtClassCourse))
            && string.IsNullOrWhiteSpace(_errClass.GetError(txtClassTeacher))
            && string.IsNullOrWhiteSpace(_errClass.GetError(txtClassSize))
            && string.IsNullOrWhiteSpace(_errClass.GetError(dtpClassEndDate));
    }

    private string ResolveCourseId(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        var exactId = input.Split('-', 2)[0].Trim();
        if (AppRuntime.DataService.GetCourseById(exactId) is not null)
        {
            return exactId;
        }

        var table = AppRuntime.DataService.GetCourseList();
        var partialMatches = new List<string>();
        foreach (DataRow row in table.Rows)
        {
            var id = row[0]?.ToString() ?? string.Empty;
            var name = row[1]?.ToString() ?? string.Empty;
            var display = $"{id} - {name}";
            if (id.Equals(input, StringComparison.OrdinalIgnoreCase)
                || name.Equals(input, StringComparison.OrdinalIgnoreCase)
                || display.Equals(input, StringComparison.OrdinalIgnoreCase))
            {
                return id;
            }

            if (IsLookupPartialMatch(input, id, name, display))
            {
                partialMatches.Add(id);
            }
        }

        return partialMatches.Distinct(StringComparer.OrdinalIgnoreCase).Take(2).Count() == 1
            ? partialMatches[0]
            : string.Empty;
    }

    private string ResolveTeacherId(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        var exactId = input.Split('-', 2)[0].Trim();
        if (AppRuntime.DataService.GetTeacherById(exactId) is not null)
        {
            return exactId;
        }

        var table = AppRuntime.DataService.GetTeacherList();
        var partialMatches = new List<string>();
        foreach (DataRow row in table.Rows)
        {
            var id = row[0]?.ToString() ?? string.Empty;
            var name = row[1]?.ToString() ?? string.Empty;
            var display = $"{id} - {name}";
            if (id.Equals(input, StringComparison.OrdinalIgnoreCase)
                || name.Equals(input, StringComparison.OrdinalIgnoreCase)
                || display.Equals(input, StringComparison.OrdinalIgnoreCase))
            {
                return id;
            }

            if (IsLookupPartialMatch(input, id, name, display))
            {
                partialMatches.Add(id);
            }
        }

        return partialMatches.Distinct(StringComparer.OrdinalIgnoreCase).Take(2).Count() == 1
            ? partialMatches[0]
            : string.Empty;
    }

    private void ConfigureLookupAutoComplete()
    {
        ConfigureTextBoxAutoComplete(txtClassCourse, AppRuntime.DataService.GetCourseList());
        ConfigureTextBoxAutoComplete(txtClassTeacher, AppRuntime.DataService.GetTeacherList());
    }

    private static void ConfigureTextBoxAutoComplete(TextBox textBox, DataTable table)
    {
        var source = new AutoCompleteStringCollection();
        foreach (DataRow row in table.Rows)
        {
            var id = row[0]?.ToString()?.Trim() ?? string.Empty;
            var name = row[1]?.ToString()?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(id))
            {
                continue;
            }

            source.Add(id);
            if (!string.IsNullOrWhiteSpace(name))
            {
                source.Add(name);
                source.Add($"{id} - {name}");
            }
        }

        textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        textBox.AutoCompleteCustomSource = source;
    }

    private void NormalizeCourseInput()
    {
        var courseId = ResolveCourseId(txtClassCourse.Text.Trim());
        if (string.IsNullOrWhiteSpace(courseId))
        {
            return;
        }

        var course = AppRuntime.DataService.GetCourseById(courseId);
        txtClassCourse.Text = course is null ? courseId : $"{course.Id} - {course.Name}";
    }

    private void NormalizeTeacherInput()
    {
        var teacherId = ResolveTeacherId(txtClassTeacher.Text.Trim());
        if (string.IsNullOrWhiteSpace(teacherId))
        {
            return;
        }

        var teacher = AppRuntime.DataService.GetTeacherById(teacherId);
        txtClassTeacher.Text = teacher is null ? teacherId : $"{teacher.Id} - {teacher.FullName}";
    }

    private static bool IsLookupPartialMatch(string input, string id, string name, string display)
    {
        if (input.Length < 2)
        {
            return false;
        }

        return id.Contains(input, StringComparison.OrdinalIgnoreCase)
            || name.Contains(input, StringComparison.OrdinalIgnoreCase)
            || display.Contains(input, StringComparison.OrdinalIgnoreCase)
            || input.Contains(id, StringComparison.OrdinalIgnoreCase);
    }

    private void ResetDetailEditor()
    {
        _errClass.Clear();
        txtClassCode.Clear();
        txtClassName.Clear();
        txtClassCourse.Clear();
        txtClassTeacher.Clear();
        txtClassSchedule.Clear();
        txtClassRoom.Clear();
        txtClassSize.Clear();
        cboClassDetailStatus.SelectedIndex = 0;
        dtpClassStartDate.Value = DateTime.Today;
        dtpClassEndDate.Value = DateTime.Today;
        dgvClassStudentList.DataSource = null;
        dgvClassSessionList.DataSource = null;
    }

    private void EnsureDeleteClassButton()
    {
        if (_btnDeleteClass is not null)
        {
            return;
        }

        _btnDeleteClass = new Button
        {
            Name = "btnDeleteClass",
            Text = "Xóa mềm lớp",
            Width = FormHostHelpers.ScaleForDpi(this, 130),
            Height = FormHostHelpers.ScaleForDpi(this, 34),
            Margin = btnGenerateSessions.Margin
        };

        flpClassActions.Controls.Add(_btnDeleteClass);
        flpClassActions.Controls.SetChildIndex(_btnDeleteClass, Math.Min(3, flpClassActions.Controls.Count - 1));
    }

    private void ResetFilters()
    {
        txtClassKeyword.Clear();
        cboClassStatusFilter.SelectedIndex = 0;
        LoadClasses();
    }

    private void OpenEnrollmentFromClass()
    {
        var classId = txtClassCode.Text.Trim();
        if (string.IsNullOrWhiteSpace(classId) || AppRuntime.DataService.GetClassById(classId) is null)
        {
            MessageBox.Show(this, "Lưu lớp học trước khi ghi danh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var form = new FrmEnrollment(null, classId);
        form.ShowDialog(this);
        PopulateDetailFromSelection();
    }

    private static int GetCurrentClassStudentCount(string classId)
    {
        return string.IsNullOrWhiteSpace(classId)
            ? 0
            : AppRuntime.DataService.GetClassStudents(classId).Rows.Count;
    }

    private void LocalizeLabels()
    {
        lblClassKeyword.Text = "Từ khóa";
        txtClassKeyword.PlaceholderText = "Mã lớp hoặc tên lớp";
        lblClassStatus.Text = "Trạng thái";
        cboClassStatusFilter.Items.Clear();
        cboClassStatusFilter.Items.AddRange(["Tất cả", "Đang mở", "Đang học", "Đầy", "Đã đóng", "Hoàn thành", "Đã hủy"]);
        cboClassDetailStatus.Items.Clear();
        cboClassDetailStatus.Items.AddRange(["Đang mở", "Đang học", "Đã đóng", "Hoàn thành", "Đã hủy"]);

        lblClassCode.Text = "Mã lớp";
        lblClassName.Text = "Tên lớp";
        lblClassCourse.Text = "Khóa học";
        lblClassTeacher.Text = "Giáo viên";
        lblClassSchedule.Text = "Lịch học";
        lblClassSize.Text = "Sĩ số tối đa";
        lblClassDetailStatus.Text = "Trạng thái";
        lblClassRoom.Text = "Phòng học";
        lblClassStartDate.Text = "Ngày bắt đầu";
        lblClassEndDate.Text = "Ngày kết thúc";

        btnSearchClass.Text = "Tìm kiếm";
        btnRefreshClass.Text = "Làm mới";
        btnCreateClass.Text = "Thêm lớp";
        btnSaveClass.Text = "Lưu";
        btnUpdateClass.Text = "Cập nhật";
        btnGenerateSessions.Text = "Làm mới buổi học";
        if (_btnDeleteClass is not null)
        {
            _btnDeleteClass.Text = "Xóa mềm lớp";
        }
        btnOpenEnrollmentFromClass.Text = "Mở ghi danh";
    }
}
