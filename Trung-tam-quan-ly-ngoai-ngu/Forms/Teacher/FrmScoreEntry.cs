using System.Data;
using System.Globalization;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Application.Models;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmScoreEntry : Form
{
    private DataTable _classTable = new();
    private DataTable _scoreTable = new();
    private readonly string? _preselectedClassId;

    public FrmScoreEntry(string? preselectedClassId = null)
    {
        _preselectedClassId = preselectedClassId;
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Nhập điểm");
        ConfigureView();
        LoadTeachingClasses();
        WireEvents();
    }

    private void ConfigureView()
    {
        AppTheme.StyleGrid(dgvScoreList);
        AppTheme.StylePrimaryButton(btnLoadScoreList);
        AppTheme.StylePrimaryButton(btnSaveScore);

        btnLoadScoreList.Text = "Tải danh sách";
        btnSaveScore.Text = "Lưu bảng điểm";

        cboScoreType.Items.Clear();
        cboScoreType.Items.AddRange(["Tổng hợp điểm"]);
        cboScoreType.SelectedIndex = 0;
        cboScoreType.Enabled = false;
        lblScoreType.Text = "Loại điểm";
        txtScoreWeight.Text = "0-10";
        txtScoreWeight.ReadOnly = true;

        dgvScoreList.AutoGenerateColumns = true;
        dgvScoreList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvScoreList.RowTemplate.Height = 42;
    }

    private void WireEvents()
    {
        btnLoadScoreList.Click += (_, _) => LoadScoreList();
        btnSaveScore.Click += (_, _) => SaveScores();
        cboScoreClass.SelectedIndexChanged += (_, _) => LoadScoreList();
    }

    private void LoadTeachingClasses()
    {
        try
        {
            _classTable = AppRuntime.DataService.GetTeachingClasses(AppRuntime.CurrentUser?.Id);
            cboScoreClass.DisplayMember = "Ten lop";
            cboScoreClass.ValueMember = "Ma lop";
            cboScoreClass.DataSource = _classTable;
            SelectClass(_preselectedClassId);
            LoadScoreList();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmScoreEntry));
            MessageBox.Show(this, "Không tải được lớp giảng dạy. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadScoreList()
    {
        try
        {
            var classId = GetSelectedClassId();
            if (string.IsNullOrWhiteSpace(classId))
            {
                _scoreTable = BuildEmptyScoreTable();
                dgvScoreList.DataSource = _scoreTable;
                ConfigureGrid();
                return;
            }

            _scoreTable = AppRuntime.DataService.GetScoreList(classId);
            dgvScoreList.DataSource = _scoreTable;
            ConfigureGrid();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmScoreEntry));
            MessageBox.Show(this, "Không tải được bảng điểm. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ConfigureGrid()
    {
        SetHeader("Ma hoc vien", "Mã học viên");
        SetHeader("Ho ten", "Họ tên");
        SetHeader("Diem giua ky", "Điểm giữa kỳ");
        SetHeader("Diem cuoi ky", "Điểm cuối kỳ");
        SetHeader("Ghi chu", "Ghi chú");

        if (!dgvScoreList.Columns.Contains("EnrollmentId"))
        {
            return;
        }

        dgvScoreList.Columns["EnrollmentId"].Visible = false;
        if (dgvScoreList.Columns.Contains("Ma hoc vien"))
        {
            dgvScoreList.Columns["Ma hoc vien"].ReadOnly = true;
        }

        if (dgvScoreList.Columns.Contains("Ho ten"))
        {
            dgvScoreList.Columns["Ho ten"].ReadOnly = true;
        }
    }

    private void SaveScores()
    {
        try
        {
            errScore.Clear();
            dgvScoreList.EndEdit();

            var classId = GetSelectedClassId();
            if (string.IsNullOrWhiteSpace(classId))
            {
                errScore.SetError(cboScoreClass, "Chưa chọn lớp học.");
                ValidationFeedback.ShowFirstError(this, errScore, cboScoreClass);
                return;
            }

            if (!dgvScoreList.Columns.Contains("EnrollmentId"))
            {
                MessageBox.Show(this, "Danh sách điểm chưa sẵn sàng để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var items = new List<ScoreSaveItem>();
            foreach (DataGridViewRow row in dgvScoreList.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                var enrollmentId = row.Cells["EnrollmentId"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(enrollmentId))
                {
                    continue;
                }

                var midterm = ParseScore(GetCellValue(row, "Diem giua ky", "Điểm giữa kỳ", "Giua ky"), "Điểm giữa kỳ");
                var final = ParseScore(GetCellValue(row, "Diem cuoi ky", "Điểm cuối kỳ", "Cuoi ky"), "Điểm cuối kỳ");

                items.Add(new ScoreSaveItem
                {
                    EnrollmentId = enrollmentId,
                    MidtermScore = midterm,
                    FinalScore = final,
                    Note = GetCellValue(row, "Ghi chu")
                });
            }

            AppRuntime.DataService.SaveScores(classId, items);
            MessageBox.Show(this, "Đã lưu bảng điểm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadScoreList();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmScoreEntry));
            MessageBox.Show(this, ex is InvalidOperationException
                ? ex.Message
                : "Không lưu được bảng điểm. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static decimal? ParseScore(string? value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        var normalizedValue = value.Trim();
        var viCulture = CultureInfo.GetCultureInfo("vi-VN");
        if (!decimal.TryParse(normalizedValue, NumberStyles.Number, viCulture, out var score)
            && !decimal.TryParse(normalizedValue, NumberStyles.Number, CultureInfo.InvariantCulture, out score))
        {
            throw new InvalidOperationException($"{fieldName} phải là số.");
        }

        if (score < 0 || score > 10)
        {
            throw new InvalidOperationException($"{fieldName} phải nằm trong khoảng 0 đến 10.");
        }

        return score;
    }

    private string? GetSelectedClassId()
    {
        return cboScoreClass.SelectedValue is string value
            ? value
            : cboScoreClass.SelectedItem is DataRowView rowView && rowView.Row.Table.Columns.Contains("Ma lop")
                ? rowView.Row["Ma lop"]?.ToString()
                : null;
    }

    private static string? GetCellValue(DataGridViewRow row, params string[] columnNames)
    {
        if (row.DataGridView is null)
        {
            return null;
        }

        foreach (var columnName in columnNames)
        {
            if (row.DataGridView.Columns.Contains(columnName))
            {
                return row.Cells[columnName].Value?.ToString();
            }
        }

        return null;
    }

    private void SelectClass(string? classId)
    {
        if (string.IsNullOrWhiteSpace(classId))
        {
            return;
        }

        foreach (DataRowView item in cboScoreClass.Items)
        {
            if (string.Equals(item.Row["Ma lop"]?.ToString(), classId, StringComparison.OrdinalIgnoreCase))
            {
                cboScoreClass.SelectedItem = item;
                return;
            }
        }
    }

    private void SetHeader(string columnName, string headerText)
    {
        if (dgvScoreList.Columns.Contains(columnName))
        {
            dgvScoreList.Columns[columnName].HeaderText = headerText;
        }
    }

    private static DataTable BuildEmptyScoreTable()
    {
        var table = new DataTable();
        table.Columns.Add("EnrollmentId");
        table.Columns.Add("Ma hoc vien");
        table.Columns.Add("Ho ten");
        table.Columns.Add("Diem giua ky");
        table.Columns.Add("Diem cuoi ky");
        table.Columns.Add("Ghi chu");
        return table;
    }
}
