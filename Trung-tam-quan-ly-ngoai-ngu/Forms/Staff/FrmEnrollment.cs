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

    public FrmEnrollment()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Ghi danh học viên");
        ConfigureView();
        LoadData();
        WireEvents();
    }

    private void ConfigureView()
    {
        LocalizeLabels();

        AppTheme.StyleGrid(dgvEnrollmentStudentList);
        AppTheme.StyleGrid(dgvEnrollmentClassList);
        AppTheme.StylePrimaryButton(btnCreateEnrollment);
        AppTheme.StyleSecondaryButton(btnRefreshEnrollment);
        AppTheme.StyleSecondaryButton(btnOpenTuitionReceipt);

        dgvEnrollmentStudentList.AutoGenerateColumns = true;
        dgvEnrollmentClassList.AutoGenerateColumns = true;
        dgvEnrollmentStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvEnrollmentClassList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        cboEnrollmentStatus.SelectedIndex = 0;
        txtEnrollmentDiscount.Text = "0";
        txtEnrollmentOriginalFee.ReadOnly = true;
        txtEnrollmentFinalFee.ReadOnly = true;
        btnOpenTuitionReceipt.Enabled = false;
        _errEnrollment.BlinkStyle = ErrorBlinkStyle.NeverBlink;
    }

    private void WireEvents()
    {
        dgvEnrollmentStudentList.SelectionChanged += (_, _) => UpdateSelectedStudent();
        dgvEnrollmentClassList.SelectionChanged += (_, _) => UpdateSelectedClass();
        btnRefreshEnrollment.Click += (_, _) => LoadData();
        btnCreateEnrollment.Click += (_, _) => CreateEnrollment();
        btnOpenTuitionReceipt.Click += (_, _) => OpenTuitionReceipt();
        txtEnrollmentDiscount.TextChanged += (_, _) => RecalculateFinalFee();
    }

    private void LoadData()
    {
        try
        {
            _studentTable = AppRuntime.DataService.GetEnrollmentStudents();
            _classTable = AppRuntime.DataService.GetEnrollmentClasses();
            dgvEnrollmentStudentList.DataSource = _studentTable;
            dgvEnrollmentClassList.DataSource = _classTable;

            if (dgvEnrollmentStudentList.Rows.Count > 0)
            {
                dgvEnrollmentStudentList.Rows[0].Selected = true;
                UpdateSelectedStudent();
            }

            if (dgvEnrollmentClassList.Rows.Count > 0)
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
}
