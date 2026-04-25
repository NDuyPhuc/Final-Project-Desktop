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
        FormHostHelpers.ConfigureModuleSurface(this, "Quan ly lop hoc");
        ConfigureView();
        LoadClasses();
        WireEvents();
    }

    private void ConfigureView()
    {
        LocalizeLabels();

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

        txtClassCourse.PlaceholderText = "Nhap ma khoa hoac ten khoa";
        txtClassTeacher.PlaceholderText = "Nhap ma GV hoac ho ten";
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
                string.IsNullOrWhiteSpace(status) || status == "Tat ca" ? null : status);

            dgvClassList.DataSource = _classTable;
            SelectFirstClass();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmClassManagement));
            MessageBox.Show(this, "Khong tai duoc danh sach lop hoc. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void StartCreateClass()
    {
        ResetDetailEditor();
        txtClassCode.Text = AppRuntime.DataService.GetNextClassId();
        cboClassDetailStatus.Text = "Dang mo";
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
            MessageBox.Show(this, "Da luu lop hoc thanh cong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmClassManagement));
            MessageBox.Show(this, "Khong luu duoc lop hoc. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DeleteSelectedClass()
    {
        if (string.IsNullOrWhiteSpace(txtClassCode.Text))
        {
            return;
        }

        using var dialog = new FrmConfirmDialog("Xoa lop hoc", "Ban co chac muon xoa mem lop hoc dang chon khong?");
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
            MessageBox.Show(this, "Khong xoa duoc lop hoc. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cboClassDetailStatus.Text = string.IsNullOrWhiteSpace(entity.Status) ? "Dang mo" : entity.Status;

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
            MessageBox.Show(this, "Khong tai duoc chi tiet lop hoc. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _errClass.SetError(txtClassCode, "Ma lop khong duoc de trong.");
        }

        if (string.IsNullOrWhiteSpace(txtClassName.Text))
        {
            _errClass.SetError(txtClassName, "Ten lop khong duoc de trong.");
        }

        courseId = ResolveCourseId(txtClassCourse.Text.Trim());
        if (string.IsNullOrWhiteSpace(courseId))
        {
            _errClass.SetError(txtClassCourse, "Khong tim thay khoa hoc.");
        }

        teacherId = ResolveTeacherId(txtClassTeacher.Text.Trim());
        if (string.IsNullOrWhiteSpace(teacherId))
        {
            _errClass.SetError(txtClassTeacher, "Khong tim thay giao vien.");
        }

        if (!int.TryParse(txtClassSize.Text.Trim(), out maxStudents) || maxStudents <= 0)
        {
            _errClass.SetError(txtClassSize, "Si so toi da phai > 0.");
        }

        if (dtpClassStartDate.Value.Date > dtpClassEndDate.Value.Date)
        {
            _errClass.SetError(dtpClassEndDate, "Ngay ket thuc phai >= ngay bat dau.");
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
        lblClassKeyword.Text = "Tu khoa";
        txtClassKeyword.PlaceholderText = "Ma lop hoac ten lop";
        lblClassStatus.Text = "Trang thai";
        cboClassStatusFilter.Items.Clear();
        cboClassStatusFilter.Items.AddRange(["Tat ca", "Dang mo", "Dang hoc", "Day", "Da dong", "Hoan thanh", "Da huy"]);
        cboClassDetailStatus.Items.Clear();
        cboClassDetailStatus.Items.AddRange(["Dang mo", "Dang hoc", "Da dong", "Hoan thanh", "Da huy"]);

        lblClassCode.Text = "Ma lop";
        lblClassName.Text = "Ten lop";
        lblClassCourse.Text = "Khoa hoc";
        lblClassTeacher.Text = "Giao vien";
        lblClassSchedule.Text = "Lich hoc";
        lblClassSize.Text = "Si so toi da";
        lblClassDetailStatus.Text = "Trang thai";
        lblClassRoom.Text = "Phong hoc";
        lblClassStartDate.Text = "Ngay bat dau";
        lblClassEndDate.Text = "Ngay ket thuc";

        btnSearchClass.Text = "Tim kiem";
        btnRefreshClass.Text = "Lam moi";
        btnCreateClass.Text = "Them lop";
        btnSaveClass.Text = "Luu";
        btnUpdateClass.Text = "Cap nhat";
        btnGenerateSessions.Text = "Xoa mem lop";
        btnOpenEnrollmentFromClass.Text = "Mo ghi danh";
    }
}
