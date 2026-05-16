using System.Data;
using System.Globalization;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Application.Models;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAttendance : Form
{
    private DataTable _classTable = new();
    private DataTable _attendanceTable = new();
    private readonly string? _preselectedClassId;

    public FrmAttendance(string? preselectedClassId = null)
    {
        _preselectedClassId = preselectedClassId;
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Điểm danh");
        ConfigureView();
        LoadTeachingClasses();
        WireEvents();
    }

    private void ConfigureView()
    {
        AppTheme.StyleGrid(dgvAttendanceList);
        AppTheme.StylePrimaryButton(btnSearchAttendance);
        AppTheme.StylePrimaryButton(btnCheckAllPresent);
        AppTheme.StyleSecondaryButton(btnCheckAllAbsent);
        AppTheme.StylePrimaryButton(btnSaveAttendance);

        btnSearchAttendance.Text = "Xem danh sách";
        btnCheckAllPresent.Text = "Tất cả có mặt";
        btnCheckAllAbsent.Text = "Tất cả vắng";
        btnSaveAttendance.Text = "Lưu điểm danh";

        ttAttendance.SetToolTip(btnSaveAttendance, "Lưu lịch sử chuyên cần vào database.");
        cboAttendanceSession.DropDownStyle = ComboBoxStyle.DropDownList;
        cboAttendanceClass.DropDownStyle = ComboBoxStyle.DropDownList;
        dtpAttendanceDate.Format = DateTimePickerFormat.Custom;
        dtpAttendanceDate.CustomFormat = "dd/MM/yyyy";
        dgvAttendanceList.AutoGenerateColumns = true;
        dgvAttendanceList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    private void WireEvents()
    {
        cboAttendanceClass.SelectedIndexChanged += (_, _) => LoadSessions();
        cboAttendanceSession.SelectedIndexChanged += (_, _) => SyncDateFromSession();
        btnSearchAttendance.Click += (_, _) => LoadAttendanceList();
        btnCheckAllPresent.Click += (_, _) => SetAllAttendanceStatus(true);
        btnCheckAllAbsent.Click += (_, _) => SetAllAttendanceStatus(false);
        btnSaveAttendance.Click += (_, _) => SaveAttendance();
    }

    private void LoadTeachingClasses()
    {
        try
        {
            _classTable = AppRuntime.DataService.GetTeachingClasses(AppRuntime.CurrentUser?.Id);
            cboAttendanceClass.DisplayMember = "Ten lop";
            cboAttendanceClass.ValueMember = "Ma lop";
            cboAttendanceClass.DataSource = _classTable;
            SelectClass(_preselectedClassId);
            LoadSessions();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmAttendance));
            MessageBox.Show(this, "Không tải được danh sách lớp đang dạy. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadSessions()
    {
        try
        {
            var classId = GetSelectedClassId();
            if (string.IsNullOrWhiteSpace(classId))
            {
                cboAttendanceSession.DataSource = BuildEmptySessionTable();
                _attendanceTable = BuildEmptyAttendanceTable();
                dgvAttendanceList.DataSource = _attendanceTable;
                ConfigureGrid();
                return;
            }

            var sessions = AppRuntime.DataService.GetSessions(classId);
            cboAttendanceSession.DisplayMember = "Buoi";
            cboAttendanceSession.ValueMember = "Ngay hoc";
            cboAttendanceSession.DataSource = sessions;
            SyncDateFromSession();
            LoadAttendanceList();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmAttendance));
            MessageBox.Show(this, "Không tải được lịch học. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SyncDateFromSession()
    {
        if (cboAttendanceSession.SelectedItem is not DataRowView rowView)
        {
            return;
        }

        var dateText = rowView.Row.Table.Columns.Contains("Ngay hoc")
            ? rowView.Row["Ngay hoc"]?.ToString()
            : null;
        if (DateTime.TryParseExact(dateText, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"), DateTimeStyles.None, out var sessionDate))
        {
            dtpAttendanceDate.Value = sessionDate;
        }
    }

    private void LoadAttendanceList()
    {
        try
        {
            var classId = GetSelectedClassId();
            if (string.IsNullOrWhiteSpace(classId))
            {
                _attendanceTable = BuildEmptyAttendanceTable();
                dgvAttendanceList.DataSource = _attendanceTable;
                ConfigureGrid();
                return;
            }

            _attendanceTable = AppRuntime.DataService.GetAttendanceList(classId, dtpAttendanceDate.Value.Date);
            dgvAttendanceList.DataSource = _attendanceTable;
            ConfigureGrid();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmAttendance));
            MessageBox.Show(this, "Không tải được danh sách điểm danh. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ConfigureGrid()
    {
        SetHeader("Ma hoc vien", "Mã học viên");
        SetHeader("Ho ten", "Họ tên");
        SetHeader("Co mat", "Có mặt");
        SetHeader("Trang thai", "Trạng thái");
        SetHeader("Ghi chu", "Ghi chú");

        if (!dgvAttendanceList.Columns.Contains("EnrollmentId"))
        {
            return;
        }

        dgvAttendanceList.Columns["EnrollmentId"].Visible = false;

        if (!dgvAttendanceList.Columns.Contains("Co mat"))
        {
            var statusColumn = dgvAttendanceList.Columns.Contains("Trang thai")
                ? dgvAttendanceList.Columns["Trang thai"]
                : null;
            var displayIndex = statusColumn?.DisplayIndex ?? 3;
            var checkboxColumn = new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "Co mat",
                Name = "Co mat",
                HeaderText = "Có mặt",
                DisplayIndex = displayIndex
            };
            dgvAttendanceList.Columns.Insert(displayIndex, checkboxColumn);
        }

        SetHeader("Co mat", "Có mặt");
    }

    private void SetAllAttendanceStatus(bool present)
    {
        if (!dgvAttendanceList.Columns.Contains("Co mat"))
        {
            return;
        }

        foreach (DataGridViewRow row in dgvAttendanceList.Rows)
        {
            if (!row.IsNewRow)
            {
                row.Cells["Co mat"].Value = present;
            }
        }
    }

    private void SaveAttendance()
    {
        try
        {
            errAttendance.Clear();
            dgvAttendanceList.EndEdit();

            var classId = GetSelectedClassId();
            if (string.IsNullOrWhiteSpace(classId))
            {
                errAttendance.SetError(cboAttendanceClass, "Chưa chọn lớp học.");
                ValidationFeedback.ShowFirstError(this, errAttendance, cboAttendanceClass);
                return;
            }

            if (!dgvAttendanceList.Columns.Contains("EnrollmentId") || !dgvAttendanceList.Columns.Contains("Co mat"))
            {
                MessageBox.Show(this, "Danh sách điểm danh chưa sẵn sàng để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var items = dgvAttendanceList.Rows
                .Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .Select(row => new AttendanceSaveItem
                {
                    EnrollmentId = row.Cells["EnrollmentId"].Value?.ToString() ?? string.Empty,
                    Status = row.Cells["Co mat"].Value is true ? "Present" : "Absent",
                    Note = dgvAttendanceList.Columns.Contains("Ghi chu") ? row.Cells["Ghi chu"].Value?.ToString() : null
                })
                .Where(item => !string.IsNullOrWhiteSpace(item.EnrollmentId))
                .ToList();

            AppRuntime.DataService.SaveAttendance(classId, dtpAttendanceDate.Value.Date, items);
            MessageBox.Show(this, "Đã lưu điểm danh thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadAttendanceList();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmAttendance));
            MessageBox.Show(this, "Không lưu được điểm danh. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string? GetSelectedClassId()
    {
        return cboAttendanceClass.SelectedValue is string value
            ? value
            : cboAttendanceClass.SelectedItem is DataRowView rowView && rowView.Row.Table.Columns.Contains("Ma lop")
                ? rowView.Row["Ma lop"]?.ToString()
                : null;
    }

    private void SelectClass(string? classId)
    {
        if (string.IsNullOrWhiteSpace(classId))
        {
            return;
        }

        foreach (DataRowView item in cboAttendanceClass.Items)
        {
            if (string.Equals(item.Row["Ma lop"]?.ToString(), classId, StringComparison.OrdinalIgnoreCase))
            {
                cboAttendanceClass.SelectedItem = item;
                return;
            }
        }
    }

    private void SetHeader(string columnName, string headerText)
    {
        if (dgvAttendanceList.Columns.Contains(columnName))
        {
            dgvAttendanceList.Columns[columnName].HeaderText = headerText;
        }
    }

    private static DataTable BuildEmptySessionTable()
    {
        var table = new DataTable();
        table.Columns.Add("Buoi");
        table.Columns.Add("Ngay hoc");
        table.Columns.Add("Khung gio");
        table.Columns.Add("Phong");
        table.Columns.Add("Trang thai");
        return table;
    }

    private static DataTable BuildEmptyAttendanceTable()
    {
        var table = new DataTable();
        table.Columns.Add("EnrollmentId");
        table.Columns.Add("Ma hoc vien");
        table.Columns.Add("Ho ten");
        table.Columns.Add("Co mat", typeof(bool));
        table.Columns.Add("Trang thai");
        table.Columns.Add("Ghi chu");
        return table;
    }
}
