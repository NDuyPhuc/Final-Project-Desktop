using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmCourseManagement : Form
{
    private DataTable _courseTable = new();

    public FrmCourseManagement()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Quản lý khóa học");
        ConfigureView();
        BindMockData();
        WireEvents();
    }

    private void ConfigureView()
    {
        cboCourseStatusFilter.SelectedIndex = 0;
        AppTheme.StyleGrid(dgvCourseList);
        AppTheme.StyleGrid(dgvCourseClassList);
    }

    private void BindMockData()
    {
        _courseTable = DemoDataFactory.GetCourseList();
        dgvCourseList.DataSource = _courseTable;
        dgvCourseClassList.DataSource = DemoDataFactory.GetClassList();

        if (dgvCourseList.Rows.Count > 0)
        {
            dgvCourseList.Rows[0].Selected = true;
            PopulateCourseDetail();
        }
    }

    private void WireEvents()
    {
        dgvCourseList.SelectionChanged += (_, _) => PopulateCourseDetail();
        btnSearchCourse.Click += (_, _) => ApplyFilters();
        btnRefreshCourse.Click += (_, _) => ResetFilters();
        btnCreateCourse.Click += (_, _) =>
        {
            txtCourseCode.Text = $"KH{_courseTable.Rows.Count + 1:000}";
            txtCourseName.Clear();
            txtCourseLevel.Clear();
            txtCourseFee.Clear();
            txtCourseDescription.Clear();
            txtCourseName.Focus();
        };
        btnSaveCourse.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Lưu khóa học", "UI demo đã sẵn sàng để nối backend cho nghiệp vụ khóa học.");
            dialog.ShowDialog(this);
        };
    }

    private void ApplyFilters()
    {
        var keyword = txtCourseKeyword.Text.Trim();
        var status = cboCourseStatusFilter.Text;
        var filteredTable = _courseTable.Clone();

        foreach (DataRow row in _courseTable.Rows)
        {
            var matchesKeyword =
                string.IsNullOrWhiteSpace(keyword) ||
                row["Mã khóa"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                row["Tên khóa"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase);
            var matchesStatus = status == "Tất cả" || row["Trạng thái"].ToString() == status;

            if (matchesKeyword && matchesStatus)
            {
                filteredTable.ImportRow(row);
            }
        }

        dgvCourseList.DataSource = filteredTable;
        if (dgvCourseList.Rows.Count > 0)
        {
            dgvCourseList.Rows[0].Selected = true;
            PopulateCourseDetail();
        }
    }

    private void ResetFilters()
    {
        txtCourseKeyword.Clear();
        cboCourseStatusFilter.SelectedIndex = 0;
        dgvCourseList.DataSource = _courseTable;
        if (dgvCourseList.Rows.Count > 0)
        {
            dgvCourseList.Rows[0].Selected = true;
            PopulateCourseDetail();
        }
    }

    private void PopulateCourseDetail()
    {
        if (dgvCourseList.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            return;
        }

        var row = rowView.Row;
        txtCourseCode.Text = row["Mã khóa"].ToString();
        txtCourseName.Text = row["Tên khóa"].ToString();
        txtCourseLevel.Text = row["Level"].ToString();
        txtCourseFee.Text = row["Học phí"].ToString();
        txtCourseDescription.Text = $"Khóa học {row["Tên khóa"]} đang ở trạng thái {row["Trạng thái"]}.";
    }
}
