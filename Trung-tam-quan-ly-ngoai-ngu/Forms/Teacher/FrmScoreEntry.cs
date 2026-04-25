using System.Data;
using System.Globalization;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Application.Models;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmScoreEntry : Form
{
    private DataTable _classTable = new();
    private DataTable _scoreTable = new();

    public FrmScoreEntry()
    {
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
        cboScoreType.Items.AddRange(["Tổng hợp điểm", "Midterm", "Final"]);
        cboScoreType.SelectedIndex = 0;
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
            cboScoreClass.DataSource = _classTable;
            cboScoreClass.DisplayMember = "Ten lop";
            cboScoreClass.ValueMember = "Ma lop";
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
            var classId = cboScoreClass.SelectedValue?.ToString();
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
        if (!dgvScoreList.Columns.Contains("EnrollmentId"))
        {
            return;
        }

        dgvScoreList.Columns["EnrollmentId"].Visible = false;
        dgvScoreList.Columns["Ma hoc vien"].ReadOnly = true;
        dgvScoreList.Columns["Ho ten"].ReadOnly = true;
    }

    private void SaveScores()
    {
        try
        {
            errScore.Clear();
            var classId = cboScoreClass.SelectedValue?.ToString();
            if (string.IsNullOrWhiteSpace(classId))
            {
                errScore.SetError(cboScoreClass, "Chưa chọn lớp học.");
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

                var midterm = ParseScore(row.Cells["Diem giua ky"].Value?.ToString(), "Diem giua ky");
                var final = ParseScore(row.Cells["Diem cuoi ky"].Value?.ToString(), "Diem cuoi ky");

                items.Add(new ScoreSaveItem
                {
                    EnrollmentId = enrollmentId,
                    MidtermScore = midterm,
                    FinalScore = final,
                    Note = row.Cells["Ghi chu"].Value?.ToString()
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

        if (!decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var score))
        {
            throw new InvalidOperationException($"{fieldName} phai la so.");
        }

        if (score < 0 || score > 10)
        {
            throw new InvalidOperationException($"{fieldName} phai nam trong khoang 0 den 10.");
        }

        return score;
    }
}
