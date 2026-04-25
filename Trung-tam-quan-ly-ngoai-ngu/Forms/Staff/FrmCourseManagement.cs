using System.Data;
using System.Globalization;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Domain.Entities;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmCourseManagement : Form
{
    private readonly ErrorProvider _errCourse = new();
    private DataTable _courseTable = new();
    private string? _currentCourseStatus;

    public FrmCourseManagement()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Quan ly khoa hoc");
        ConfigureView();
        LoadCourses();
        WireEvents();
    }

    private void ConfigureView()
    {
        LocalizeLabels();

        AppTheme.StyleGrid(dgvCourseList);
        AppTheme.StyleGrid(dgvCourseClassList);
        AppTheme.StyleSecondaryButton(btnSearchCourse);
        AppTheme.StyleSecondaryButton(btnRefreshCourse);
        AppTheme.StylePrimaryButton(btnCreateCourse);
        AppTheme.StylePrimaryButton(btnSaveCourse);
        AppTheme.StylePrimaryButton(btnUpdateCourse);
        AppTheme.StyleDangerButton(btnDeleteCourse);

        dgvCourseList.AutoGenerateColumns = true;
        dgvCourseClassList.AutoGenerateColumns = true;
        dgvCourseList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCourseClassList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCourseList.RowTemplate.Height = 42;
        dgvCourseClassList.RowTemplate.Height = 38;

        cboCourseStatusFilter.SelectedIndex = 0;
        _errCourse.BlinkStyle = ErrorBlinkStyle.NeverBlink;
    }

    private void WireEvents()
    {
        dgvCourseList.SelectionChanged += (_, _) => PopulateDetailFromSelection();
        btnSearchCourse.Click += (_, _) => LoadCourses(txtCourseKeyword.Text.Trim(), cboCourseStatusFilter.Text);
        btnRefreshCourse.Click += (_, _) => ResetFilters();
        btnCreateCourse.Click += (_, _) => StartCreateCourse();
        btnSaveCourse.Click += (_, _) => SaveCurrentCourse();
        btnUpdateCourse.Click += (_, _) => SaveCurrentCourse();
        btnDeleteCourse.Click += (_, _) => DeleteSelectedCourse();
    }

    private void LoadCourses(string? keyword = null, string? status = null)
    {
        try
        {
            _courseTable = AppRuntime.DataService.GetCourseList(
                string.IsNullOrWhiteSpace(keyword) ? null : keyword,
                string.IsNullOrWhiteSpace(status) || status == "Tat ca" ? null : status);

            dgvCourseList.DataSource = _courseTable;
            SelectFirstCourse();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmCourseManagement));
            MessageBox.Show(this, "Khong tai duoc danh sach khoa hoc. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void StartCreateCourse()
    {
        ResetDetailEditor();
        txtCourseCode.Text = AppRuntime.DataService.GetNextCourseId();
        _currentCourseStatus = "Con mo";
        txtCourseName.Focus();
        dgvCourseClassList.DataSource = AppRuntime.DataService.GetClassList(courseId: "__empty__");
    }

    private void SaveCurrentCourse()
    {
        if (!ValidateEditor(out var tuitionFee))
        {
            return;
        }

        try
        {
            var course = new CourseEntity
            {
                Id = txtCourseCode.Text.Trim(),
                Name = txtCourseName.Text.Trim(),
                Description = BuildCourseDescription(txtCourseLevel.Text.Trim(), txtCourseDescription.Text.Trim()),
                TuitionFee = tuitionFee,
                Status = string.IsNullOrWhiteSpace(_currentCourseStatus) ? "Con mo" : _currentCourseStatus,
                IsDeleted = false
            };

            course = AppRuntime.DataService.SaveCourse(course);
            _currentCourseStatus = course.Status;
            LoadCourses(txtCourseKeyword.Text.Trim(), cboCourseStatusFilter.Text);
            FocusCourse(course.Id);
            MessageBox.Show(this, "Da luu khoa hoc thanh cong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmCourseManagement));
            MessageBox.Show(this, "Khong luu duoc khoa hoc. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DeleteSelectedCourse()
    {
        if (string.IsNullOrWhiteSpace(txtCourseCode.Text))
        {
            return;
        }

        using var dialog = new FrmConfirmDialog("Xoa khoa hoc", "Ban co chac muon xoa mem khoa hoc dang chon khong?");
        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        try
        {
            AppRuntime.DataService.SoftDeleteCourse(txtCourseCode.Text.Trim());
            LoadCourses(txtCourseKeyword.Text.Trim(), cboCourseStatusFilter.Text);
            ResetDetailEditor();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmCourseManagement));
            MessageBox.Show(this, "Khong xoa duoc khoa hoc. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void PopulateDetailFromSelection()
    {
        if (dgvCourseList.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            return;
        }

        var courseId = rowView.Row[0]?.ToString();
        if (string.IsNullOrWhiteSpace(courseId))
        {
            return;
        }

        try
        {
            var course = AppRuntime.DataService.GetCourseById(courseId);
            if (course is null)
            {
                return;
            }

            txtCourseCode.Text = course.Id;
            txtCourseName.Text = course.Name;
            ParseCourseDescription(course.Description, out var level, out var description);
            txtCourseLevel.Text = level;
            txtCourseDescription.Text = description;
            txtCourseFee.Text = course.TuitionFee.ToString("0.##", CultureInfo.InvariantCulture);
            _currentCourseStatus = course.Status;
            dgvCourseClassList.DataSource = AppRuntime.DataService.GetClassList(courseId: course.Id);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmCourseManagement));
            MessageBox.Show(this, "Khong tai duoc chi tiet khoa hoc. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SelectFirstCourse()
    {
        if (dgvCourseList.Rows.Count > 0)
        {
            dgvCourseList.Rows[0].Selected = true;
            PopulateDetailFromSelection();
            return;
        }

        ResetDetailEditor();
    }

    private void FocusCourse(string courseId)
    {
        foreach (DataGridViewRow row in dgvCourseList.Rows)
        {
            if ((row.Cells[0].Value?.ToString() ?? string.Empty).Equals(courseId, StringComparison.OrdinalIgnoreCase))
            {
                row.Selected = true;
                dgvCourseList.CurrentCell = row.Cells[0];
                PopulateDetailFromSelection();
                return;
            }
        }
    }

    private bool ValidateEditor(out decimal tuitionFee)
    {
        _errCourse.Clear();
        tuitionFee = 0M;

        if (string.IsNullOrWhiteSpace(txtCourseCode.Text))
        {
            _errCourse.SetError(txtCourseCode, "Ma khoa hoc khong duoc de trong.");
        }

        if (string.IsNullOrWhiteSpace(txtCourseName.Text))
        {
            _errCourse.SetError(txtCourseName, "Ten khoa hoc khong duoc de trong.");
        }

        if (string.IsNullOrWhiteSpace(txtCourseFee.Text))
        {
            _errCourse.SetError(txtCourseFee, "Hoc phi khong duoc de trong.");
        }
        else if (!decimal.TryParse(txtCourseFee.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out tuitionFee) || tuitionFee < 0)
        {
            _errCourse.SetError(txtCourseFee, "Hoc phi phai la so >= 0.");
        }

        return string.IsNullOrWhiteSpace(_errCourse.GetError(txtCourseCode))
            && string.IsNullOrWhiteSpace(_errCourse.GetError(txtCourseName))
            && string.IsNullOrWhiteSpace(_errCourse.GetError(txtCourseFee));
    }

    private void ResetDetailEditor()
    {
        _errCourse.Clear();
        txtCourseCode.Clear();
        txtCourseName.Clear();
        txtCourseLevel.Clear();
        txtCourseFee.Clear();
        txtCourseDescription.Clear();
        _currentCourseStatus = null;
        dgvCourseClassList.DataSource = null;
    }

    private void ResetFilters()
    {
        txtCourseKeyword.Clear();
        cboCourseStatusFilter.SelectedIndex = 0;
        LoadCourses();
    }

    private void LocalizeLabels()
    {
        lblCourseKeyword.Text = "Tu khoa";
        txtCourseKeyword.PlaceholderText = "Ma khoa hoac ten khoa hoc";
        lblCourseStatus.Text = "Trang thai";
        cboCourseStatusFilter.Items.Clear();
        cboCourseStatusFilter.Items.AddRange(["Tat ca", "Con mo", "Tam dung"]);

        lblCourseCode.Text = "Ma khoa";
        lblCourseName.Text = "Ten khoa hoc";
        lblCourseLevel.Text = "Level";
        lblCourseFee.Text = "Hoc phi";
        lblCourseDescription.Text = "Mo ta";

        btnSearchCourse.Text = "Tim kiem";
        btnRefreshCourse.Text = "Lam moi";
        btnCreateCourse.Text = "Them khoa";
        btnSaveCourse.Text = "Luu";
        btnUpdateCourse.Text = "Cap nhat";
        btnDeleteCourse.Text = "Xoa mem";
    }

    private static string BuildCourseDescription(string level, string description)
    {
        var safeLevel = string.IsNullOrWhiteSpace(level) ? "A1" : level.Trim();
        return string.IsNullOrWhiteSpace(description)
            ? safeLevel
            : $"{safeLevel} | {description.Trim()}";
    }

    private static void ParseCourseDescription(string? value, out string level, out string description)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            level = string.Empty;
            description = string.Empty;
            return;
        }

        var parts = value.Split('|', 2, StringSplitOptions.TrimEntries);
        level = parts[0];
        description = parts.Length > 1 ? parts[1] : string.Empty;
    }
}
