using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmClassManagement : Form
{
    private DataTable _classTable = new();

    public FrmClassManagement()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Quản lý lớp học");
        ConfigureView();
        BindMockData();
        WireEvents();
    }

    private void ConfigureView()
    {
        cboClassStatusFilter.SelectedIndex = 0;
        cboClassDetailStatus.SelectedIndex = 0;
        dtpClassStartDate.Value = DateTime.Today;
        dtpClassEndDate.Value = DateTime.Today.AddMonths(3);
        AppTheme.StyleGrid(dgvClassList);
        AppTheme.StyleGrid(dgvClassStudentList);
        AppTheme.StyleGrid(dgvClassSessionList);
    }

    private void BindMockData()
    {
        _classTable = DemoDataFactory.GetClassList();
        dgvClassList.DataSource = _classTable;
        dgvClassStudentList.DataSource = DemoDataFactory.GetClassStudents();
        dgvClassSessionList.DataSource = DemoDataFactory.GetSessions();
        if (dgvClassList.Rows.Count > 0)
        {
            dgvClassList.Rows[0].Selected = true;
            PopulateClassDetail();
        }
    }

    private void WireEvents()
    {
        dgvClassList.SelectionChanged += (_, _) => PopulateClassDetail();
        btnSearchClass.Click += (_, _) => ApplyFilters();
        btnRefreshClass.Click += (_, _) => ResetFilters();
        btnCreateClass.Click += (_, _) =>
        {
            txtClassCode.Text = $"LP{_classTable.Rows.Count + 1:000}";
            txtClassName.Clear();
            txtClassCourse.Clear();
            txtClassTeacher.Clear();
            txtClassSchedule.Clear();
            txtClassRoom.Clear();
            txtClassSize.Clear();
            dtpClassStartDate.Value = DateTime.Today;
            dtpClassEndDate.Value = DateTime.Today.AddMonths(3);
            cboClassDetailStatus.SelectedIndex = 0;
            tabClassManagement.SelectedTab = tpClassInfo;
            txtClassName.Focus();
        };
        btnSaveClass.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Lưu lớp học", "UI demo đã lưu trạng thái lớp học trong phiên làm việc hiện tại.");
            dialog.ShowDialog(this);
        };
        btnGenerateSessions.Click += (_, _) => tabClassManagement.SelectedTab = tpClassSessions;
        btnOpenEnrollmentFromClass.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Mở ghi danh lớp", "UI demo đã sẵn sàng chuyển sang nghiệp vụ ghi danh / xếp lớp.");
            dialog.ShowDialog(this);
        };
    }

    private void ApplyFilters()
    {
        var keyword = txtClassKeyword.Text.Trim();
        var status = cboClassStatusFilter.Text;
        var filteredTable = _classTable.Clone();

        foreach (DataRow row in _classTable.Rows)
        {
            var matchesKeyword =
                string.IsNullOrWhiteSpace(keyword) ||
                row["Mã lớp"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                row["Tên lớp"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase);
            var matchesStatus = status == "Tất cả" || row["Trạng thái"].ToString() == status;

            if (matchesKeyword && matchesStatus)
            {
                filteredTable.ImportRow(row);
            }
        }

        dgvClassList.DataSource = filteredTable;
        if (dgvClassList.Rows.Count > 0)
        {
            dgvClassList.Rows[0].Selected = true;
            PopulateClassDetail();
        }
    }

    private void ResetFilters()
    {
        txtClassKeyword.Clear();
        cboClassStatusFilter.SelectedIndex = 0;
        dgvClassList.DataSource = _classTable;
        if (dgvClassList.Rows.Count > 0)
        {
            dgvClassList.Rows[0].Selected = true;
            PopulateClassDetail();
        }
    }

    private void PopulateClassDetail()
    {
        if (dgvClassList.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            return;
        }

        var row = rowView.Row;
        txtClassCode.Text = row["Mã lớp"].ToString();
        txtClassName.Text = row["Tên lớp"].ToString();
        txtClassCourse.Text = row["Khóa học"].ToString();
        txtClassTeacher.Text = row["Giáo viên"].ToString();
        txtClassSchedule.Text = row["Lịch học"].ToString();
        txtClassRoom.Text = "P201";
        dtpClassStartDate.Value = DateTime.Today;
        dtpClassEndDate.Value = DateTime.Today.AddMonths(3);
        txtClassSize.Text = row["Sĩ số"].ToString();
        cboClassDetailStatus.Text = row["Trạng thái"].ToString();
    }
}
