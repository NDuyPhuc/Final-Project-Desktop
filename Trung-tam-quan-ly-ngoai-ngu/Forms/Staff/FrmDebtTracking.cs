using System.Data;
using System.Globalization;
using System.Text;
using TrungTamNgoaiNgu.Application.Infrastructure;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmDebtTracking : Form
{
    private DataTable _debtTable = new();

    public FrmDebtTracking()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Theo doi cong no");
        ConfigureView();
        LoadFilterSources();
        LoadDebtData();
        WireEvents();
    }

    private void ConfigureView()
    {
        AppTheme.StyleGrid(dgvDebtTrackingList);
        AppTheme.StyleSecondaryButton(btnSearchDebt);
        AppTheme.StyleSecondaryButton(btnRefreshDebt);
        AppTheme.StylePrimaryButton(btnOpenTuitionFromDebt);
        AppTheme.StyleSecondaryButton(btnExportDebt);
        AppTheme.StyleSecondaryButton(btnExportPdfDebt);

        dgvDebtTrackingList.AutoGenerateColumns = true;
        dgvDebtTrackingList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDebtTrackingList.RowTemplate.Height = 42;

        btnDebtPagePrev.Enabled = false;
        btnDebtPage1.Enabled = false;
        btnDebtPage2.Enabled = false;
        btnDebtPage3.Enabled = false;
        btnDebtPageNext.Enabled = false;
        lblDebtUpdatedAt.Text = $"Cap nhat: {DateTime.Now:dd/MM/yyyy HH:mm}";
    }

    private void WireEvents()
    {
        btnSearchDebt.Click += (_, _) => LoadDebtData();
        btnRefreshDebt.Click += (_, _) => ResetFilters();
        btnOpenTuitionFromDebt.Click += (_, _) => OpenReceiptFromDebt();
        btnExportDebt.Click += (_, _) => ExportDebtCsv();
        btnExportPdfDebt.Click += (_, _) => MessageBox.Show(this, "Ban co the dung CSV de demo xuat file. Nut PDF dang de o muc co ban.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void LoadFilterSources()
    {
        var courseTable = AppRuntime.DataService.GetCourseList();
        var classTable = AppRuntime.DataService.GetClassList();

        cboDebtCourseFilter.Items.Clear();
        cboDebtCourseFilter.Items.Add("Tat ca");
        foreach (DataRow row in courseTable.Rows)
        {
            cboDebtCourseFilter.Items.Add(row[1]?.ToString() ?? string.Empty);
        }

        cboDebtClassFilter.Items.Clear();
        cboDebtClassFilter.Items.Add("Tat ca");
        foreach (DataRow row in classTable.Rows)
        {
            cboDebtClassFilter.Items.Add(row[1]?.ToString() ?? string.Empty);
        }

        cboDebtCourseFilter.SelectedIndex = 0;
        cboDebtClassFilter.SelectedIndex = 0;
        dtpDebtFromDate.Value = new DateTime(DateTime.Today.Year, 1, 1);
        dtpDebtToDate.Value = DateTime.Today;
    }

    private void LoadDebtData()
    {
        try
        {
            _debtTable = AppRuntime.DataService.GetDebtList(
                cboDebtCourseFilter.Text,
                cboDebtClassFilter.Text,
                dtpDebtFromDate.Value.Date,
                dtpDebtToDate.Value.Date);

            dgvDebtTrackingList.DataSource = _debtTable;
            UpdateSummaryCards();
            lblDebtUpdatedAt.Text = $"Cap nhat: {DateTime.Now:dd/MM/yyyy HH:mm}";
            lblDebtFooterSummary.Text = $"Tong so ho so cong no: {_debtTable.Rows.Count}";
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmDebtTracking));
            MessageBox.Show(this, "Khong tai duoc cong no. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void UpdateSummaryCards()
    {
        lblDebtTotalCountValue.Text = _debtTable.Rows.Count.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));

        var totalDebt = _debtTable.AsEnumerable().Sum(row => ParseMoney(row["Con no"]?.ToString()));
        lblDebtTotalAmountValue.Text = totalDebt.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
        lblDebtTotalAmountUnit.Text = "VND";

        var dueSoonCount = _debtTable.AsEnumerable().Count(row =>
        {
            var status = row["Trang thai"]?.ToString() ?? string.Empty;
            return status.Contains("Qua", StringComparison.OrdinalIgnoreCase)
                || status.Contains("Sap", StringComparison.OrdinalIgnoreCase);
        });
        lblDebtDueSoonValue.Text = dueSoonCount.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
    }

    private void ResetFilters()
    {
        cboDebtCourseFilter.SelectedIndex = 0;
        cboDebtClassFilter.SelectedIndex = 0;
        dtpDebtFromDate.Value = new DateTime(DateTime.Today.Year, 1, 1);
        dtpDebtToDate.Value = DateTime.Today;
        LoadDebtData();
    }

    private void OpenReceiptFromDebt()
    {
        if (dgvDebtTrackingList.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            MessageBox.Show(this, "Hay chon mot hoc vien con no.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var studentId = rowView.Row["Ma hoc vien"]?.ToString();
        using var form = new FrmTuitionReceipt(null, studentId);
        form.ShowDialog(this);
        LoadDebtData();
    }

    private void ExportDebtCsv()
    {
        try
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = $"cong-no-{DateTime.Now:yyyyMMdd-HHmmss}.csv",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            File.WriteAllText(dialog.FileName, BuildCsv(_debtTable), new UTF8Encoding(true));
            MessageBox.Show(this, "Da xuat danh sach cong no ra CSV.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmDebtTracking));
            MessageBox.Show(this, "Khong xuat duoc file CSV. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static string BuildCsv(DataTable table)
    {
        var builder = new StringBuilder();
        builder.AppendLine(string.Join(",", table.Columns.Cast<DataColumn>().Select(column => EscapeCsv(column.ColumnName))));
        foreach (DataRow row in table.Rows)
        {
            builder.AppendLine(string.Join(",", row.ItemArray.Select(cell => EscapeCsv(cell?.ToString() ?? string.Empty))));
        }

        return builder.ToString();
    }

    private static string EscapeCsv(string value)
    {
        return $"\"{value.Replace("\"", "\"\"")}\"";
    }

    private static decimal ParseMoney(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return 0;
        }

        var sanitized = input.Replace(".", string.Empty).Replace(",", string.Empty).Replace("VND", string.Empty, StringComparison.OrdinalIgnoreCase).Trim();
        return decimal.TryParse(sanitized, NumberStyles.Number, CultureInfo.InvariantCulture, out var value) ? value : 0;
    }
}
