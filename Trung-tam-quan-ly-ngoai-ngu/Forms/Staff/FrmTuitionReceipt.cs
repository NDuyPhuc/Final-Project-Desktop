using System.Data;
using System.Drawing.Printing;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmTuitionReceipt : Form
{
    private DataTable receiptHistoryTable = new();
    private bool _isApplyingResponsiveLayout;

    public FrmTuitionReceipt()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Thu học phí / biên nhận");
        ConfigureView();
        BindMockData();
        WireEvents();
        ApplyResponsiveLayout();
    }

    private void ConfigureView()
    {
        LocalizeLabels();

        AppTheme.StyleGroupBox(grpEnrollmentInfo);
        AppTheme.StyleGroupBox(grpPaymentInfo);
        AppTheme.StyleGrid(dgvReceiptHistory);
        AppTheme.StylePrimaryButton(btnCollectTuition);
        AppTheme.StyleSecondaryButton(btnSavePrintReceipt);
        AppTheme.StyleSecondaryButton(btnViewReceipt);
        AppTheme.StyleDangerButton(btnCancelReceipt);

        cboReceiptMethod.SelectedIndex = 0;
        ttTuitionReceipt.SetToolTip(btnCollectTuition, "Thêm một dòng biên nhận mẫu vào lịch sử phía dưới.");
        ttTuitionReceipt.SetToolTip(btnSavePrintReceipt, "Lưu demo rồi mở preview in biên nhận.");
        prdTuitionReceipt.PrintPage += PrintReceiptPreview;

        flpReceiptActions.AutoSize = true;
        flpReceiptActions.WrapContents = true;
        flpReceiptActions.Dock = DockStyle.Fill;
        flpReceiptActions.Margin = new Padding(0, 12, 0, 0);
        flpReceiptActions.Padding = new Padding(0, 4, 0, 0);
        flpReceiptActions.FlowDirection = FlowDirection.LeftToRight;

        foreach (Control control in flpReceiptActions.Controls)
        {
            control.Margin = new Padding(0, 0, 10, 10);
        }

        txtReceiptNote.Multiline = true;
        txtReceiptNote.ScrollBars = ScrollBars.Vertical;
        txtReceiptAmount.TextAlign = HorizontalAlignment.Left;
        cboReceiptMethod.Dock = DockStyle.Fill;

        if (tblEnrollmentInfo.ColumnStyles.Count > 0)
        {
            tblEnrollmentInfo.ColumnStyles[0].Width = 132F;
        }

        if (tblPaymentInfo.ColumnStyles.Count > 0)
        {
            tblPaymentInfo.ColumnStyles[0].Width = 188F;
        }

        tblReceiptTop.Margin = Padding.Empty;
        tblReceiptTop.Padding = Padding.Empty;
        grpEnrollmentInfo.MinimumSize = new Size(0, 208);
        grpPaymentInfo.MinimumSize = new Size(0, 236);
        dgvReceiptHistory.Margin = new Padding(0, 16, 0, 0);
        dgvReceiptHistory.RowTemplate.Height = 40;
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
        Resize += (_, _) => ApplyResponsiveLayout();
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

    private void LocalizeLabels()
    {
        grpEnrollmentInfo.Text = "Thông tin ghi danh";
        grpPaymentInfo.Text = "Thông tin thanh toán";

        lblReceiptStudentCode.Text = "Mã học viên";
        lblReceiptStudentName.Text = "Họ và tên";
        lblReceiptClassCode.Text = "Mã lớp";
        lblReceiptCourseName.Text = "Khóa học";

        lblReceiptAmount.Text = "Số tiền";
        lblReceiptMethod.Text = "Phương thức thanh toán";
        cboReceiptMethod.Items.Clear();
        cboReceiptMethod.Items.AddRange(["Tiền mặt", "Chuyển khoản"]);
        lblReceiptNote.Text = "Ghi chú";

        btnCollectTuition.Text = "Thu học phí";
        btnSavePrintReceipt.Text = "Lưu và in";
        btnViewReceipt.Text = "Xem biên nhận";
        btnCancelReceipt.Text = "Hủy";
    }

    private void ApplyResponsiveLayout()
    {
        if (_isApplyingResponsiveLayout || IsDisposed)
        {
            return;
        }

        _isApplyingResponsiveLayout = true;
        tblReceiptRoot.SuspendLayout();
        tblReceiptTop.SuspendLayout();

        try
        {
            if (ClientSize.Width < 900)
            {
                tblReceiptTop.ColumnCount = 1;
                tblReceiptTop.RowCount = 2;
                tblReceiptTop.ColumnStyles.Clear();
                tblReceiptTop.RowStyles.Clear();
                tblReceiptTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                tblReceiptTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 220F));
                tblReceiptTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 280F));
                tblReceiptTop.SetColumn(grpEnrollmentInfo, 0);
                tblReceiptTop.SetRow(grpEnrollmentInfo, 0);
                tblReceiptTop.SetColumn(grpPaymentInfo, 0);
                tblReceiptTop.SetRow(grpPaymentInfo, 1);

                if (tblEnrollmentInfo.ColumnStyles.Count > 0)
                {
                    tblEnrollmentInfo.ColumnStyles[0].Width = 116F;
                }

                if (tblPaymentInfo.ColumnStyles.Count > 0)
                {
                    tblPaymentInfo.ColumnStyles[0].Width = 156F;
                }
            }
            else
            {
                tblReceiptTop.ColumnCount = 2;
                tblReceiptTop.RowCount = 1;
                tblReceiptTop.ColumnStyles.Clear();
                tblReceiptTop.RowStyles.Clear();
                tblReceiptTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tblReceiptTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tblReceiptTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 236F));
                tblReceiptTop.SetColumn(grpEnrollmentInfo, 0);
                tblReceiptTop.SetRow(grpEnrollmentInfo, 0);
                tblReceiptTop.SetColumn(grpPaymentInfo, 1);
                tblReceiptTop.SetRow(grpPaymentInfo, 0);

                if (tblEnrollmentInfo.ColumnStyles.Count > 0)
                {
                    tblEnrollmentInfo.ColumnStyles[0].Width = 132F;
                }

                if (tblPaymentInfo.ColumnStyles.Count > 0)
                {
                    tblPaymentInfo.ColumnStyles[0].Width = 188F;
                }
            }
        }
        finally
        {
            tblReceiptTop.ResumeLayout(true);
            tblReceiptRoot.ResumeLayout(true);
            _isApplyingResponsiveLayout = false;
        }
    }
}
