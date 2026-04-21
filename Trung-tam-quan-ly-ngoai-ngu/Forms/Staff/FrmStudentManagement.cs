using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmStudentManagement : Form
{
    private DataTable studentTable = new();

    public FrmStudentManagement()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Quản lý học viên");
        ConfigureView();
        BindMockData();
        WireEvents();
    }

    private void ConfigureView()
    {
        cboStudentStatusFilter.SelectedIndex = 0;
        cboStudentStatus.SelectedIndex = 0;
        ttStudentManagement.SetToolTip(btnOpenEnrollment, "Mở màn ghi danh để tiếp tục quy trình thu học phí.");
        ttStudentManagement.SetToolTip(btnChooseStudentAvatar, "UI demo: backend có thể nối chọn ảnh thật sau.");

        dgvStudentList.EnableHeadersVisualStyles = false;
        dgvStudentList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(232, 242, 250);
        dgvStudentList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        dgvStudentList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 248);
        dgvStudentList.DefaultCellStyle.SelectionForeColor = Color.FromArgb(31, 41, 55);
    }

    private void BindMockData()
    {
        studentTable = DemoDataFactory.GetStudentList();
        dgvStudentList.DataSource = studentTable;
        if (dgvStudentList.Rows.Count > 0)
        {
            dgvStudentList.Rows[0].Selected = true;
            PopulateDetailFromSelection();
        }
    }

    private void WireEvents()
    {
        dgvStudentList.SelectionChanged += (_, _) => PopulateDetailFromSelection();
        btnSearchStudent.Click += (_, _) => ApplyFilters();
        btnRefreshStudent.Click += (_, _) => ResetFilters();
        btnResetStudent.Click += (_, _) => ResetDetailEditor();
        btnOpenEnrollment.Click += (_, _) =>
        {
            using var form = new FrmEnrollment();
            form.ShowDialog(this);
        };
        btnCreateStudent.Click += (_, _) =>
        {
            ResetDetailEditor();
            txtStudentId.Text = $"HV{studentTable.Rows.Count + 1:000}";
            txtStudentFullName.Focus();
        };
        btnSaveStudent.Click += (_, _) =>
        {
            if (!ValidateEditor())
            {
                return;
            }

            using var dialog = new FrmStatusDialog("Lưu học viên", "Dữ liệu demo đã được cập nhật trong màn hình hiện tại.");
            dialog.ShowDialog(this);
        };
        btnUpdateStudent.Click += (_, _) =>
        {
            if (!ValidateEditor())
            {
                return;
            }

            using var dialog = new FrmStatusDialog("Cập nhật học viên", "Thông tin hàng đang chọn đã được cập nhật ở tầng UI demo.");
            dialog.ShowDialog(this);
        };
        btnDeleteStudent.Click += (_, _) =>
        {
            using var dialog = new FrmConfirmDialog("Xóa học viên", "Bạn có chắc muốn xóa học viên đang chọn khỏi danh sách demo không?");
            if (dialog.ShowDialog(this) == DialogResult.OK && dgvStudentList.CurrentRow is not null)
            {
                dgvStudentList.Rows.Remove(dgvStudentList.CurrentRow);
                ResetDetailEditor();
            }
        };
        btnChooseStudentAvatar.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Ảnh đại diện", "Màn hình đã sẵn sàng để backend nối tính năng chọn ảnh từ máy.");
            dialog.ShowDialog(this);
        };
        btnRemoveStudentAvatar.Click += (_, _) => picStudentAvatar.Image = null;
    }

    private void ApplyFilters()
    {
        var keyword = txtStudentKeyword.Text.Trim();
        var status = cboStudentStatusFilter.Text;
        var filteredTable = studentTable.Clone();

        foreach (DataRow row in studentTable.Rows)
        {
            var matchesKeyword =
                string.IsNullOrWhiteSpace(keyword) ||
                row["Mã học viên"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                row["Họ tên"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase);

            var matchesStatus = status == "Tất cả" || row["Trạng thái"].ToString() == status;
            if (matchesKeyword && matchesStatus)
            {
                filteredTable.ImportRow(row);
            }
        }

        dgvStudentList.DataSource = filteredTable;
        if (dgvStudentList.Rows.Count > 0)
        {
            dgvStudentList.Rows[0].Selected = true;
            PopulateDetailFromSelection();
        }
        else
        {
            ResetDetailEditor();
        }
    }

    private void ResetFilters()
    {
        txtStudentKeyword.Clear();
        cboStudentStatusFilter.SelectedIndex = 0;
        dgvStudentList.DataSource = studentTable;
        if (dgvStudentList.Rows.Count > 0)
        {
            dgvStudentList.Rows[0].Selected = true;
            PopulateDetailFromSelection();
        }
    }

    private void PopulateDetailFromSelection()
    {
        if (dgvStudentList.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            return;
        }

        var row = rowView.Row;
        txtStudentId.Text = row["Mã học viên"].ToString();
        txtStudentFullName.Text = row["Họ tên"].ToString();
        txtStudentPhone.Text = row["Điện thoại"].ToString();
        txtStudentEmail.Text = BuildDemoEmail(txtStudentFullName.Text);
        cboStudentStatus.Text = row["Trạng thái"].ToString();

        if (DateTime.TryParse(row["Ngày sinh"].ToString(), out var birthDate))
        {
            dtpStudentBirthDate.Value = birthDate;
        }
    }

    private bool ValidateEditor()
    {
        errStudent.Clear();
        if (string.IsNullOrWhiteSpace(txtStudentId.Text))
        {
            errStudent.SetError(txtStudentId, "Mã học viên không được để trống.");
        }

        if (string.IsNullOrWhiteSpace(txtStudentFullName.Text))
        {
            errStudent.SetError(txtStudentFullName, "Họ tên không được để trống.");
        }

        if (string.IsNullOrWhiteSpace(txtStudentPhone.Text))
        {
            errStudent.SetError(txtStudentPhone, "Điện thoại không được để trống.");
        }

        return string.IsNullOrWhiteSpace(errStudent.GetError(txtStudentId))
            && string.IsNullOrWhiteSpace(errStudent.GetError(txtStudentFullName))
            && string.IsNullOrWhiteSpace(errStudent.GetError(txtStudentPhone));
    }

    private void ResetDetailEditor()
    {
        errStudent.Clear();
        txtStudentId.Clear();
        txtStudentFullName.Clear();
        txtStudentPhone.Clear();
        txtStudentEmail.Clear();
        cboStudentStatus.SelectedIndex = 0;
        dtpStudentBirthDate.Value = DateTime.Today;
        picStudentAvatar.Image = null;
    }

    private static string BuildDemoEmail(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            return string.Empty;
        }

        var normalized = fullName.ToLowerInvariant()
            .Replace(" ", ".")
            .Replace("đ", "d")
            .Replace("á", "a")
            .Replace("à", "a")
            .Replace("ả", "a")
            .Replace("ã", "a")
            .Replace("ạ", "a")
            .Replace("ă", "a")
            .Replace("ắ", "a")
            .Replace("ằ", "a")
            .Replace("ẳ", "a")
            .Replace("ẵ", "a")
            .Replace("ặ", "a")
            .Replace("â", "a")
            .Replace("ấ", "a")
            .Replace("ầ", "a")
            .Replace("ẩ", "a")
            .Replace("ẫ", "a")
            .Replace("ậ", "a")
            .Replace("é", "e")
            .Replace("è", "e")
            .Replace("ẻ", "e")
            .Replace("ẽ", "e")
            .Replace("ẹ", "e")
            .Replace("ê", "e")
            .Replace("ế", "e")
            .Replace("ề", "e")
            .Replace("ể", "e")
            .Replace("ễ", "e")
            .Replace("ệ", "e")
            .Replace("í", "i")
            .Replace("ì", "i")
            .Replace("ỉ", "i")
            .Replace("ĩ", "i")
            .Replace("ị", "i")
            .Replace("ó", "o")
            .Replace("ò", "o")
            .Replace("ỏ", "o")
            .Replace("õ", "o")
            .Replace("ọ", "o")
            .Replace("ô", "o")
            .Replace("ố", "o")
            .Replace("ồ", "o")
            .Replace("ổ", "o")
            .Replace("ỗ", "o")
            .Replace("ộ", "o")
            .Replace("ơ", "o")
            .Replace("ớ", "o")
            .Replace("ờ", "o")
            .Replace("ở", "o")
            .Replace("ỡ", "o")
            .Replace("ợ", "o")
            .Replace("ú", "u")
            .Replace("ù", "u")
            .Replace("ủ", "u")
            .Replace("ũ", "u")
            .Replace("ụ", "u")
            .Replace("ư", "u")
            .Replace("ứ", "u")
            .Replace("ừ", "u")
            .Replace("ử", "u")
            .Replace("ữ", "u")
            .Replace("ự", "u")
            .Replace("ý", "y")
            .Replace("ỳ", "y")
            .Replace("ỷ", "y")
            .Replace("ỹ", "y")
            .Replace("ỵ", "y");

        return $"{normalized}@demo.center";
    }
}
