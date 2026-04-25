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
        FormHostHelpers.ConfigureModuleSurface(this, "Diem danh");
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

        btnSearchAttendance.Text = "Xem danh sach";
        btnCheckAllPresent.Text = "Present all";
        btnCheckAllAbsent.Text = "Absent all";
        btnSaveAttendance.Text = "Luu diem danh";

        ttAttendance.SetToolTip(btnSaveAttendance, "Luu lich su chuyen can vao database.");
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
            MessageBox.Show(this, "Khong tai duoc danh sach lop dang day. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show(this, "Khong tai duoc lich hoc. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show(this, "Khong tai duoc danh sach diem danh. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                HeaderText = "Trang thai",
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
                errAttendance.SetError(cboAttendanceClass, "Chua chon lop hoc.");
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
            MessageBox.Show(this, "Da luu diem danh thanh cong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadAttendanceList();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmAttendance));
            MessageBox.Show(this, "Khong luu duoc diem danh. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string? GetSelectedClassId()
    {
        return cboAttendanceClass.SelectedValue?.ToString();
    }
}
