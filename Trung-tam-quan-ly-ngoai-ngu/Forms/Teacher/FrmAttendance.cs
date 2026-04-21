using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAttendance : Form
{
    private DataTable attendanceTable = new();

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
        ttAttendance.SetToolTip(btnSelectAllAttendance, "Đánh dấu có mặt cho toàn bộ học viên trong danh sách.");
        ttAttendance.SetToolTip(btnSaveAttendance, "Lưu trạng thái điểm danh tạm thời trong phiên UI demo.");
    }

    private void BindMockData()
    {
        attendanceTable = DemoDataFactory.GetAttendanceList();
        dgvAttendanceList.DataSource = attendanceTable;
    }

    private void WireEvents()
    {
        btnSearchAttendance.Click += (_, _) => dgvAttendanceList.DataSource = attendanceTable;
        btnSelectAllAttendance.Click += (_, _) =>
        {
            foreach (DataRow row in attendanceTable.Rows)
            {
                row["Có mặt"] = true;
                row["Ghi chú"] = string.Empty;
            }
        };
        btnClearAttendance.Click += (_, _) =>
        {
            foreach (DataRow row in attendanceTable.Rows)
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
