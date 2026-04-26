using System.Data;
using TrungTamNgoaiNgu.Application.Infrastructure;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmTeachingClasses : Form
{
    private DataTable _sourceTable = new();

    public FrmTeachingClasses()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Lớp đang dạy");
        ConfigureView();
        LoadTeachingClasses();
        WireEvents();
    }

    private void ConfigureView()
    {
        AppTheme.StyleGrid(dgvTeachingClassList);
        AppTheme.StyleSecondaryButton(btnSearchTeachingClass);
        AppTheme.StyleSecondaryButton(btnRefreshTeachingClass);
        AppTheme.StylePrimaryButton(btnOpenClassStudentList);
        AppTheme.StylePrimaryButton(btnOpenAttendance);
        AppTheme.StylePrimaryButton(btnOpenScoreEntry);

        dgvTeachingClassList.AutoGenerateColumns = true;
        dgvTeachingClassList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        txtTeachingClassKeyword.PlaceholderText = "Nhập mã hoặc tên lớp";

        cboTeachingStatusFilter.Items.Clear();
        cboTeachingStatusFilter.Items.AddRange(["Tất cả", "Đang mở", "Đã đóng"]);
        cboTeachingStatusFilter.SelectedIndex = 0;
    }

    private void WireEvents()
    {
        btnSearchTeachingClass.Click += (_, _) => ApplyFilters();
        btnRefreshTeachingClass.Click += (_, _) => ResetFilters();
        btnOpenClassStudentList.Click += (_, _) =>
        {
            using var form = new FrmClassStudentList();
            form.ShowDialog(this);
        };
        btnOpenAttendance.Click += (_, _) =>
        {
            using var form = new FrmAttendance();
            form.ShowDialog(this);
        };
        btnOpenScoreEntry.Click += (_, _) =>
        {
            using var form = new FrmScoreEntry();
            form.ShowDialog(this);
        };
    }

    private void LoadTeachingClasses()
    {
        try
        {
            _sourceTable = AppRuntime.DataService.GetTeachingClasses(AppRuntime.CurrentUser?.Id);
            dgvTeachingClassList.DataSource = _sourceTable;
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTeachingClasses));
            MessageBox.Show(this, "Không tải được danh sách lớp đang dạy. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ApplyFilters()
    {
        var keyword = txtTeachingClassKeyword.Text.Trim();
        var status = cboTeachingStatusFilter.Text;
        var filtered = _sourceTable.Clone();

        foreach (DataRow row in _sourceTable.Rows)
        {
            var classId = GetField(row, "Ma lop");
            var className = GetField(row, "Ten lop");
            var classStatus = GetField(row, "Trang thai");

            var matchesKeyword = string.IsNullOrWhiteSpace(keyword)
                || classId.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                || className.Contains(keyword, StringComparison.OrdinalIgnoreCase);

            var matchesStatus = status is "Tat ca" or "Tất cả" || classStatus.Equals(status, StringComparison.OrdinalIgnoreCase);
            if (matchesKeyword && matchesStatus)
            {
                filtered.ImportRow(row);
            }
        }

        dgvTeachingClassList.DataSource = filtered;
    }

    private void ResetFilters()
    {
        txtTeachingClassKeyword.Clear();
        cboTeachingStatusFilter.SelectedIndex = 0;
        dgvTeachingClassList.DataSource = _sourceTable;
    }

    private static string GetField(DataRow row, string columnName)
    {
        return row.Table.Columns.Contains(columnName)
            ? row[columnName]?.ToString() ?? string.Empty
            : string.Empty;
    }
}
