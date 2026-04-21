using System.Data;
using System.Drawing.Printing;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmTuitionReceipt : Form
{
    private DataTable receiptHistoryTable = new();

    public FrmTuitionReceipt()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Thu học phí / biên nhận");
        ConfigureView();
        BindMockData();
        WireEvents();
    }

    private void ConfigureView()
    {
        cboReceiptMethod.SelectedIndex = 0;
        ttTuitionReceipt.SetToolTip(btnCollectTuition, "Thêm một dòng biên nhận mẫu vào lịch sử phía dưới.");
        ttTuitionReceipt.SetToolTip(btnSavePrintReceipt, "Lưu demo rồi mở preview in biên nhận.");
        prdTuitionReceipt.PrintPage += PrintReceiptPreview;
    }

    private void BindMockData()
    {
        txtReceiptStudentCode.Text = "HV001";
        txtReceiptStudentName.Text = "Nguyễn Hải Đăng";
        txtReceiptClassCode.Text = "LP001";
        txtReceiptCourseName.Text = "English Foundation";
        txtReceiptAmount.Text = "1000000";
        txtReceiptNote.Text = "Đợt 1";
        receiptHistoryTable = DemoDataFactory.GetReceiptHistory();
        dgvReceiptHistory.DataSource = receiptHistoryTable;
    }

    private void WireEvents()
    {
        btnCollectTuition.Click += (_, _) => CollectReceipt();
        btnSavePrintReceipt.Click += (_, _) =>
        {
            if (CollectReceipt())
            {
                ppdTuitionReceiptPreview.ShowDialog(this);
            }
        };
        btnViewReceipt.Click += (_, _) => ppdTuitionReceiptPreview.ShowDialog(this);
        btnCancelReceipt.Click += (_, _) =>
        {
            errTuitionReceipt.Clear();
            txtReceiptAmount.Clear();
            txtReceiptNote.Clear();
            cboReceiptMethod.SelectedIndex = 0;
        };
    }

    private bool CollectReceipt()
    {
        errTuitionReceipt.Clear();
        if (string.IsNullOrWhiteSpace(txtReceiptStudentCode.Text))
        {
            errTuitionReceipt.SetError(txtReceiptStudentCode, "Mã học viên không được để trống.");
        }

        if (string.IsNullOrWhiteSpace(txtReceiptAmount.Text))
        {
            errTuitionReceipt.SetError(txtReceiptAmount, "Số tiền không được để trống.");
        }

        if (!string.IsNullOrWhiteSpace(errTuitionReceipt.GetError(txtReceiptStudentCode)) ||
            !string.IsNullOrWhiteSpace(errTuitionReceipt.GetError(txtReceiptAmount)))
        {
            return false;
        }

        var nextNumber = $"PT{receiptHistoryTable.Rows.Count + 1:000}";
        receiptHistoryTable.Rows.Add(nextNumber, DateTime.Today.ToString("dd/MM/yyyy"), cboReceiptMethod.Text, txtReceiptAmount.Text, txtReceiptNote.Text);
        using var dialog = new FrmStatusDialog("Thu học phí", "Biên nhận demo đã được thêm vào lịch sử thanh toán.");
        dialog.ShowDialog(this);
        return true;
    }

    private void PrintReceiptPreview(object? sender, PrintPageEventArgs e)
    {
        var graphics = e.Graphics;
        if (graphics is null)
        {
            return;
        }

        using var titleFont = new Font("Segoe UI", 16F, FontStyle.Bold);
        using var bodyFont = new Font("Segoe UI", 11F);
        graphics.DrawString("Biên nhận học phí", titleFont, Brushes.Black, 60, 60);
        graphics.DrawString($"Học viên: {txtReceiptStudentName.Text}", bodyFont, Brushes.Black, 60, 110);
        graphics.DrawString($"Mã học viên: {txtReceiptStudentCode.Text}", bodyFont, Brushes.Black, 60, 138);
        graphics.DrawString($"Lớp: {txtReceiptClassCode.Text}", bodyFont, Brushes.Black, 60, 166);
        graphics.DrawString($"Khóa học: {txtReceiptCourseName.Text}", bodyFont, Brushes.Black, 60, 194);
        graphics.DrawString($"Số tiền: {txtReceiptAmount.Text}", bodyFont, Brushes.Black, 60, 222);
        graphics.DrawString($"Phương thức: {cboReceiptMethod.Text}", bodyFont, Brushes.Black, 60, 250);
        graphics.DrawString($"Ghi chú: {txtReceiptNote.Text}", bodyFont, Brushes.Black, 60, 278);
    }
}
