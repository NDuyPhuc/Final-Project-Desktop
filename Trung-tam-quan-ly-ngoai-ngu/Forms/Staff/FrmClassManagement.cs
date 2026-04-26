using System.Data;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Domain.Entities;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmClassManagement : Form
{
    private readonly ErrorProvider _errClass = new();
    private DataTable _classTable = new();

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
        AppTheme.StyleDangerButton(btnGenerateSessions);

        dgvClassList.AutoGenerateColumns = true;
        dgvClassStudentList.AutoGenerateColumns = true;
        dgvClassSessionList.AutoGenerateColumns = true;
        dgvClassList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvClassStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvClassSessionList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        txtClassCourse.PlaceholderText = "Nhập mã khóa hoặc tên khóa";
        txtClassTeacher.PlaceholderText = "Nhập mã GV hoặc họ tên";
        cboClassStatusFilter.SelectedIndex = 0;
        cboClassDetailStatus.SelectedIndex = 0;
        _errClass.BlinkStyle = ErrorBlinkStyle.NeverBlink;
    }

    private void WireEvents()
    {
        dgvClassList.SelectionChanged += (_, _) => PopulateDetailFromSelection();
        btnSearchClass.Click += (_, _) => LoadClasses(txtClassKeyword.Text.Trim(), cboClassStatusFilter.Text);
        btnRefreshClass.Click += (_, _) => ResetFilters();
        btnCreateClass.Click += (_, _) => StartCreateClass();
        btnSaveClass.Click += (_, _) => SaveCurrentClass();
        btnUpdateClass.Click += (_, _) => SaveCurrentClass();
        btnGenerateSessions.Click += (_, _) => DeleteSelectedClass();
        btnOpenEnrollmentFromClass.Click += (_, _) =>
        {
            using var form = new FrmEnrollment();
            form.ShowDialog(this);
        };
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
            return;
        }

        try
        {
            var entity = new ClassEntity
            {
                Id = txtClassCode.Text.Trim(),
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
            MessageBox.Show(this, "Đã lưu lớp học thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmClassManagement));
            MessageBox.Show(this, "Không lưu được lớp học. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DeleteSelectedClass()
    {
        if (string.IsNullOrWhiteSpace(txtClassCode.Text))
        {
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
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmClassManagement));
            MessageBox.Show(this, "Không xóa được lớp học. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _errClass.SetError(txtClassCourse, "Không tìm thấy khóa học.");
        }

        teacherId = ResolveTeacherId(txtClassTeacher.Text.Trim());
        if (string.IsNullOrWhiteSpace(teacherId))
        {
            _errClass.SetError(txtClassTeacher, "Không tìm thấy giáo viên.");
        }

        if (!int.TryParse(txtClassSize.Text.Trim(), out maxStudents) || maxStudents <= 0)
        {
            _errClass.SetError(txtClassSize, "Sĩ số tối đa phải > 0.");
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
        foreach (DataRow row in table.Rows)
        {
            var id = row[0]?.ToString() ?? string.Empty;
            var name = row[1]?.ToString() ?? string.Empty;
            if (id.Equals(input, StringComparison.OrdinalIgnoreCase)
                || name.Equals(input, StringComparison.OrdinalIgnoreCase)
                || $"{id} - {name}".Equals(input, StringComparison.OrdinalIgnoreCase))
            {
                return id;
            }
        }

        return string.Empty;
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
        foreach (DataRow row in table.Rows)
        {
            var id = row[0]?.ToString() ?? string.Empty;
            var name = row[1]?.ToString() ?? string.Empty;
            if (id.Equals(input, StringComparison.OrdinalIgnoreCase)
                || name.Equals(input, StringComparison.OrdinalIgnoreCase)
                || $"{id} - {name}".Equals(input, StringComparison.OrdinalIgnoreCase))
            {
                return id;
            }
        }

        return string.Empty;
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

    private void ResetFilters()
    {
        txtClassKeyword.Clear();
        cboClassStatusFilter.SelectedIndex = 0;
        LoadClasses();
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
        btnGenerateSessions.Text = "Xóa mềm lớp";
        btnOpenEnrollmentFromClass.Text = "Mở ghi danh";
    }
}
