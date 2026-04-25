using System.Data;
using System.Globalization;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Application.Models;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAttendance : Form
{
    private DataTable _classTable = new();
    private DataTable _attendanceTable = new();

    public FrmAttendance()
    {
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
        btnCheckAllPresent.Click += (_, _) => SetAllAttendanceStatus("Present");
        btnCheckAllAbsent.Click += (_, _) => SetAllAttendanceStatus("Absent");
        btnSaveAttendance.Click += (_, _) => SaveAttendance();
    }

    private void LoadTeachingClasses()
    {
        try
        {
            _classTable = AppRuntime.DataService.GetTeachingClasses(AppRuntime.CurrentUser?.Id);
            cboAttendanceClass.DataSource = _classTable;
            cboAttendanceClass.DisplayMember = "Ten lop";
            cboAttendanceClass.ValueMember = "Ma lop";
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
            var sessions = AppRuntime.DataService.GetSessions(classId);
            cboAttendanceSession.DataSource = sessions;
            cboAttendanceSession.DisplayMember = "Buoi";
            cboAttendanceSession.ValueMember = "Ngay hoc";
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

        if (DateTime.TryParseExact(rowView.Row["Ngay hoc"]?.ToString(), "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"), DateTimeStyles.None, out var sessionDate))
        {
            dtpAttendanceDate.Value = sessionDate;
        }
    }

    private void LoadAttendanceList()
    {
        try
        {
            var classId = GetSelectedClassId();
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
        if (!dgvAttendanceList.Columns.Contains("EnrollmentId"))
        {
            return;
        }

        dgvAttendanceList.Columns["EnrollmentId"].Visible = false;

        if (dgvAttendanceList.Columns["Trang thai"] is not null)
        {
            var displayIndex = dgvAttendanceList.Columns["Trang thai"].DisplayIndex;
            dgvAttendanceList.Columns.Remove("Trang thai");
            var comboColumn = new DataGridViewComboBoxColumn
            {
                DataPropertyName = "Trang thai",
                Name = "Trang thai",
                HeaderText = "Trạng thái",
                DataSource = new[] { "Present", "Late", "Absent" },
                FlatStyle = FlatStyle.Flat,
                DisplayIndex = displayIndex
            };
            dgvAttendanceList.Columns.Insert(displayIndex, comboColumn);
        }
    }

    private void SetAllAttendanceStatus(string status)
    {
        foreach (DataGridViewRow row in dgvAttendanceList.Rows)
        {
            if (!row.IsNewRow)
            {
                row.Cells["Trang thai"].Value = status;
            }
        }
    }

    private void SaveAttendance()
    {
        try
        {
            var classId = GetSelectedClassId();
            if (string.IsNullOrWhiteSpace(classId))
            {
                errAttendance.SetError(cboAttendanceClass, "Chưa chọn lớp học.");
                return;
            }

            errAttendance.Clear();
            var items = dgvAttendanceList.Rows
                .Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .Select(row => new AttendanceSaveItem
                {
                    EnrollmentId = row.Cells["EnrollmentId"].Value?.ToString() ?? string.Empty,
                    Status = row.Cells["Trang thai"].Value?.ToString() ?? "Present",
                    Note = row.Cells["Ghi chu"].Value?.ToString()
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
        return cboAttendanceClass.SelectedValue?.ToString();
    }
}
