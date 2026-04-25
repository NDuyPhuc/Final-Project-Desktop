using TrungTamNgoaiNgu.Application.Contracts;

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
    }

    private void BindMockData()
    {
        dgvAccessMatrix.DataSource = _dataService.GetAccessMatrix();
    }
}
