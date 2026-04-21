using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmClassManagement : Form
{
    private DataTable classTable = new();

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
        dgvClassList.EnableHeadersVisualStyles = false;
        dgvClassList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(232, 242, 250);
        dgvClassList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
    }

    private void BindMockData()
    {
        classTable = DemoDataFactory.GetClassList();
        dgvClassList.DataSource = classTable;
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
            txtClassCode.Text = $"LP{classTable.Rows.Count + 1:000}";
            txtClassName.Clear();
            txtClassCourse.Clear();
            txtClassTeacher.Clear();
            txtClassSchedule.Clear();
            txtClassSize.Clear();
            cboClassDetailStatus.SelectedIndex = 0;
            tabClassManagement.SelectedTab = tpClassInfo;
            txtClassName.Focus();
        };
        btnSaveClass.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Lưu lớp học", "UI demo đã lưu trạng thái lớp học trong phiên làm việc hiện tại.");
            dialog.ShowDialog(this);
        };
    }

    private void ApplyFilters()
    {
        var keyword = txtClassKeyword.Text.Trim();
        var status = cboClassStatusFilter.Text;
        var filteredTable = classTable.Clone();

        foreach (DataRow row in classTable.Rows)
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
        dgvClassList.DataSource = classTable;
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
        txtClassSize.Text = row["Sĩ số"].ToString();
        cboClassDetailStatus.Text = row["Trạng thái"].ToString();
    }
}
