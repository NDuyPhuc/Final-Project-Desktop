namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmScoreEntry : Form
{
    public FrmScoreEntry()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Nhập điểm");
        ConfigureView();
        BindMockData();
        WireEvents();
    }

    private void ConfigureView()
    {
        cboScoreClass.SelectedIndex = 0;
        cboScoreType.SelectedIndex = 0;
        txtScoreWeight.Text = "1";
        AppTheme.StyleGrid(dgvScoreList);
    }

    private void BindMockData()
    {
        dgvScoreList.DataSource = DemoDataFactory.GetScoreList();
    }

    private void WireEvents()
    {
        btnLoadScoreList.Click += (_, _) => dgvScoreList.DataSource = DemoDataFactory.GetScoreList();
        btnSaveScore.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Lưu điểm", "UI demo đã cập nhật bảng nhập điểm trong phiên hiện tại.");
            dialog.ShowDialog(this);
        };
    }
}
