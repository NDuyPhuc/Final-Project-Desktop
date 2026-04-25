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

        dgvClassStudentList.AutoGenerateColumns = true;
        dgvClassStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        txtClassStudentKeyword.PlaceholderText = "Tìm theo mã hoặc tên học viên";

        cboClassStudentContext.Items.Clear();
        cboClassStudentContext.Items.AddRange(["Tất cả", "Đang học", "Bảo lưu", "Đã nghỉ"]);
        cboClassStudentContext.SelectedIndex = 0;
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
            cboClassStudentClass.DataSource = _classTable;
            cboClassStudentClass.DisplayMember = "Ten lop";
            cboClassStudentClass.ValueMember = "Ma lop";
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
            var classId = cboClassStudentClass.SelectedValue?.ToString();
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
            var studentId = row["Ma hoc vien"]?.ToString() ?? string.Empty;
            var fullName = row["Ho ten"]?.ToString() ?? string.Empty;
            var studentStatus = row["Trang thai"]?.ToString() ?? string.Empty;

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

        var teachingClass = _classTable.AsEnumerable().FirstOrDefault(row => (row["Ma lop"]?.ToString() ?? string.Empty) == classId);
        lblClassStudentScheduleValue.Text = teachingClass is null
            ? "-"
            : $"{teachingClass["Lich hoc"]} | {teachingClass["Trang thai"]}";
    }
}
