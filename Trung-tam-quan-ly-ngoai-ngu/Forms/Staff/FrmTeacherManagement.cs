using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmTeacherManagement : Form
{
    private DataTable _teacherTable = new();

    public FrmTeacherManagement()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Quản lý giáo viên");
        ConfigureView();
        BindMockData();
        WireEvents();
    }

    private void ConfigureView()
    {
        cboTeacherStatusFilter.SelectedIndex = 0;
        AppTheme.StyleGrid(dgvTeacherList);
    }

    private void BindMockData()
    {
        _teacherTable = DemoDataFactory.GetTeacherList();
        dgvTeacherList.DataSource = _teacherTable;
        if (dgvTeacherList.Rows.Count > 0)
        {
            dgvTeacherList.Rows[0].Selected = true;
            PopulateTeacherDetail();
        }
    }

    private void WireEvents()
    {
        dgvTeacherList.SelectionChanged += (_, _) => PopulateTeacherDetail();
        btnSearchTeacher.Click += (_, _) => ApplyFilters();
        btnRefreshTeacher.Click += (_, _) => ResetFilters();
        btnCreateTeacher.Click += (_, _) =>
        {
            txtTeacherCode.Text = $"GV{_teacherTable.Rows.Count + 1:000}";
            txtTeacherName.Clear();
            txtTeacherPhone.Clear();
            txtTeacherEmail.Clear();
            txtTeacherSpecialty.Clear();
            txtTeacherAddress.Clear();
            txtTeacherNote.Clear();
            txtTeacherName.Focus();
        };
        btnSaveTeacher.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Lưu giáo viên", "UI demo đã chuẩn bị sẵn để nối nghiệp vụ quản lý hồ sơ giáo viên.");
            dialog.ShowDialog(this);
        };
    }

    private void ApplyFilters()
    {
        var keyword = txtTeacherKeyword.Text.Trim();
        var status = cboTeacherStatusFilter.Text;
        var filteredTable = _teacherTable.Clone();

        foreach (DataRow row in _teacherTable.Rows)
        {
            var matchesKeyword =
                string.IsNullOrWhiteSpace(keyword) ||
                row["Mã giáo viên"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                row["Họ tên"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                row["Điện thoại"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase);

            var matchesStatus = status == "Tất cả" || status == "Đang dạy";
            if (matchesKeyword && matchesStatus)
            {
                filteredTable.ImportRow(row);
            }
        }

        dgvTeacherList.DataSource = filteredTable;
        if (dgvTeacherList.Rows.Count > 0)
        {
            dgvTeacherList.Rows[0].Selected = true;
            PopulateTeacherDetail();
        }
    }

    private void ResetFilters()
    {
        txtTeacherKeyword.Clear();
        cboTeacherStatusFilter.SelectedIndex = 0;
        dgvTeacherList.DataSource = _teacherTable;
        if (dgvTeacherList.Rows.Count > 0)
        {
            dgvTeacherList.Rows[0].Selected = true;
            PopulateTeacherDetail();
        }
    }

    private void PopulateTeacherDetail()
    {
        if (dgvTeacherList.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            return;
        }

        var row = rowView.Row;
        txtTeacherCode.Text = row["Mã giáo viên"].ToString();
        txtTeacherName.Text = row["Họ tên"].ToString();
        txtTeacherPhone.Text = row["Điện thoại"].ToString();
        txtTeacherEmail.Text = row["Email"].ToString();
        txtTeacherSpecialty.Text = row["Chuyên môn"].ToString();
        txtTeacherAddress.Text = "Bổ sung địa chỉ từ nguồn dữ liệu thực tế.";
        txtTeacherNote.Text = "Giáo viên được dùng để phân công vào lớp học.";
    }
}
