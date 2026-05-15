using System.Data;
using TrungTamNgoaiNgu.Application.Contracts;
using TrungTamNgoaiNgu.Application.Infrastructure;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAccessMatrix : Form
{
    private readonly ILanguageCenterDataService _dataService;

    public FrmAccessMatrix() : this(AppRuntime.DataService)
    {
    }

    public FrmAccessMatrix(ILanguageCenterDataService dataService)
    {
        _dataService = dataService;
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Tổng quan quyền truy cập");
        BindMockData();
        WireEvents();
    }

    private void BindMockData()
    {
        dgvAccessMatrix.DataSource = _dataService.GetAccessMatrix();
    }

    private void WireEvents()
    {
        AppTheme.StyleSecondaryButton(btnExportAccessMatrix);
        btnExportAccessMatrix.Text = "XUẤT MA TRẬN QUYỀN";
        btnExportAccessMatrix.Click += (_, _) => ExportAccessMatrix();
    }

    private void ExportAccessMatrix()
    {
        if (dgvAccessMatrix.DataSource is not DataTable table || table.Rows.Count == 0)
        {
            MessageBox.Show(this, "Không có dữ liệu phân quyền để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FileName = $"ma-tran-quyen-{DateTime.Now:yyyyMMdd-HHmmss}.xlsx",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            ExportFileHelper.ExportDataTableToExcel(table, dialog.FileName, "PhanQuyen");
            MessageBox.Show(this, "Đã xuất ma trận quyền ra Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmAccessMatrix));
            MessageBox.Show(this, "Không xuất được ma trận quyền. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
