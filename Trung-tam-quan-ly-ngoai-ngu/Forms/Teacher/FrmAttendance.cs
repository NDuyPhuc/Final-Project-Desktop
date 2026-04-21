using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAttendance : Form
{
    private DataTable _attendanceTable = new();

    public FrmAttendance()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Điểm danh");
        ConfigureView();
        BindMockData();
        WireEvents();
    }

    private void ConfigureView()
    {
        cboAttendanceClass.SelectedIndex = 0;
        cboAttendanceSession.SelectedIndex = 0;
        AppTheme.StyleGrid(dgvAttendanceList);
        ttAttendance.SetToolTip(btnCheckAllPresent, "Đánh dấu có mặt cho toàn bộ học viên trong danh sách.");
        ttAttendance.SetToolTip(btnCheckAllAbsent, "Đánh dấu vắng cho toàn bộ học viên trong danh sách.");
        ttAttendance.SetToolTip(btnSaveAttendance, "Lưu trạng thái điểm danh tạm thời trong phiên UI demo.");
    }

    private void BindMockData()
    {
        _attendanceTable = DemoDataFactory.GetAttendanceList();
        dgvAttendanceList.DataSource = _attendanceTable;
    }

    private void WireEvents()
    {
        btnSearchAttendance.Click += (_, _) => dgvAttendanceList.DataSource = _attendanceTable;
        btnCheckAllPresent.Click += (_, _) =>
        {
            foreach (DataRow row in _attendanceTable.Rows)
            {
                row["Có mặt"] = true;
                row["Ghi chú"] = string.Empty;
            }
        };
        btnCheckAllAbsent.Click += (_, _) =>
        {
            foreach (DataRow row in _attendanceTable.Rows)
            {
                row["Có mặt"] = false;
            }
        };
        btnSaveAttendance.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Lưu điểm danh", "Điểm danh mẫu đã được cập nhật trong bộ dữ liệu demo.");
            dialog.ShowDialog(this);
        };
        dgvAttendanceList.CurrentCellDirtyStateChanged += (_, _) =>
        {
            if (dgvAttendanceList.IsCurrentCellDirty)
            {
                dgvAttendanceList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        };
    }
}
