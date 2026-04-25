using System.Data;
using System.Drawing.Printing;
using System.Globalization;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Application.Models;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmTuitionReceipt : Form
{
    private EnrollmentReceiptContext? _currentContext;
    private ReceiptPrintInfo? _currentPrintInfo;
    private string? _currentEnrollmentId;
    private readonly string? _initialStudentId;
    private string? _lastReceiptId;
    private bool _isApplyingResponsiveLayout;

    public FrmTuitionReceipt() : this(null, null)
    {
    }

    public FrmTuitionReceipt(string? enrollmentId) : this(enrollmentId, null)
    {
    }

    public FrmTuitionReceipt(string? enrollmentId, string? studentId)
    {
        _currentEnrollmentId = enrollmentId;
        _initialStudentId = studentId;

        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Thu học phí / biên nhận");
        ConfigureView();
        LoadInitialData();
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
        ttTuitionReceipt.SetToolTip(btnCollectTuition, "Lưu biên lai thu học phí vào SQL Server.");
        ttTuitionReceipt.SetToolTip(btnSavePrintReceipt, "Lưu biên lai và mở Print Preview.");
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
        txtReceiptStudentName.ReadOnly = true;
        txtReceiptClassCode.ReadOnly = true;
        txtReceiptCourseName.ReadOnly = true;
        dgvReceiptHistory.AutoGenerateColumns = true;
        dgvReceiptHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvReceiptHistory.RowTemplate.Height = 40;
    }

    private void LoadInitialData()
    {
        if (!string.IsNullOrWhiteSpace(_initialStudentId))
        {
            txtReceiptStudentCode.Text = _initialStudentId;
        }

        LoadEnrollmentContext(_currentEnrollmentId);
        LoadReceiptHistory();
    }

    private void WireEvents()
    {
        btnCollectTuition.Click += (_, _) => SaveReceipt(false);
        btnSavePrintReceipt.Click += (_, _) => SaveReceipt(true);
        btnViewReceipt.Click += (_, _) => PreviewSelectedReceipt();
        btnCancelReceipt.Click += (_, _) => ResetPaymentEditor();
        txtReceiptStudentCode.Leave += (_, _) => TryResolveContextFromStudentCode();
        dgvReceiptHistory.SelectionChanged += (_, _) => SyncSelectedReceipt();
        Resize += (_, _) => ApplyResponsiveLayout();
    }

    private void LoadEnrollmentContext(string? enrollmentId)
    {
        try
        {
            _currentContext = string.IsNullOrWhiteSpace(enrollmentId)
                ? null
                : AppRuntime.DataService.GetEnrollmentReceiptContext(enrollmentId);

            if (_currentContext is null)
            {
                if (!string.IsNullOrWhiteSpace(txtReceiptStudentCode.Text))
                {
                    TryResolveContextFromStudentCode();
                }

                if (_currentContext is null)
                {
                    txtReceiptStudentCode.ReadOnly = false;
                    txtReceiptStudentCode.Text = txtReceiptStudentCode.Text.Trim();
                    txtReceiptStudentName.Text = string.Empty;
                    txtReceiptClassCode.Text = string.Empty;
                    txtReceiptCourseName.Text = string.Empty;
                    txtReceiptAmount.Text = string.Empty;
                    return;
                }
            }

            _currentEnrollmentId = _currentContext.EnrollmentId;
            txtReceiptStudentCode.ReadOnly = false;
            txtReceiptStudentCode.Text = _currentContext.StudentCode;
            txtReceiptStudentName.Text = _currentContext.StudentName;
            txtReceiptClassCode.Text = $"{_currentContext.ClassCode} - {_currentContext.ClassName}";
            txtReceiptCourseName.Text = $"{_currentContext.CourseName} | Hoc phi: {FormatMoney(_currentContext.TuitionFee)} | Con no: {FormatMoney(_currentContext.OutstandingBalance)}";
            txtReceiptAmount.Text = _currentContext.OutstandingBalance > 0
                ? _currentContext.OutstandingBalance.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"))
                : _currentContext.TuitionFee.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTuitionReceipt));
            MessageBox.Show(this, "Không tải được thông tin ghi danh. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void TryResolveContextFromStudentCode()
    {
        if (string.IsNullOrWhiteSpace(txtReceiptStudentCode.Text))
        {
            return;
        }

        try
        {
            var context = AppRuntime.DataService.GetLatestEnrollmentReceiptContextByStudentId(txtReceiptStudentCode.Text.Trim());
            if (context is null)
            {
                return;
            }

            _currentContext = context;
            _currentEnrollmentId = context.EnrollmentId;
            txtReceiptStudentName.Text = context.StudentName;
            txtReceiptClassCode.Text = $"{context.ClassCode} - {context.ClassName}";
            txtReceiptCourseName.Text = $"{context.CourseName} | Hoc phi: {FormatMoney(context.TuitionFee)} | Con no: {FormatMoney(context.OutstandingBalance)}";
            if (string.IsNullOrWhiteSpace(txtReceiptAmount.Text))
            {
                txtReceiptAmount.Text = context.OutstandingBalance.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
            }

            LoadReceiptHistory();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTuitionReceipt));
            MessageBox.Show(this, "Không tìm thấy ghi danh phù hợp cho học viên này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadReceiptHistory()
    {
        try
        {
            dgvReceiptHistory.DataSource = AppRuntime.DataService.GetReceiptHistory(
                _currentEnrollmentId,
                string.IsNullOrWhiteSpace(txtReceiptStudentCode.Text) ? null : txtReceiptStudentCode.Text.Trim());
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTuitionReceipt));
            MessageBox.Show(this, "Không tải được lịch sử biên lai. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SaveReceipt(bool openPreview)
    {
        if (!ValidateReceipt())
        {
            return;
        }

        try
        {
            var receipt = AppRuntime.DataService.SaveReceipt(
                null,
                _currentEnrollmentId!,
                ParseMoney(txtReceiptAmount.Text),
                DateTime.Today,
                cboReceiptMethod.Text,
                txtReceiptNote.Text.Trim(),
                AppRuntime.CurrentUser?.Id);

            _lastReceiptId = receipt.Id;
            _currentPrintInfo = AppRuntime.DataService.GetReceiptPrintInfo(receipt.Id);
            LoadEnrollmentContext(_currentEnrollmentId);
            LoadReceiptHistory();
            ResetPaymentEditor(keepAmount: true);

            MessageBox.Show(this, "Đã thu học phí và lưu biên lai thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (openPreview)
            {
                ppdTuitionReceiptPreview.ShowDialog(this);
            }
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTuitionReceipt));
            MessageBox.Show(this, "Không lưu được biên lai. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void PreviewSelectedReceipt()
    {
        if (!string.IsNullOrWhiteSpace(_lastReceiptId))
        {
            try
            {
                _currentPrintInfo = AppRuntime.DataService.GetReceiptPrintInfo(_lastReceiptId);
                ppdTuitionReceiptPreview.ShowDialog(this);
                return;
            }
            catch (Exception ex)
            {
                ErrorLogger.Log(ex, nameof(FrmTuitionReceipt));
            }
        }

        var currentRow = dgvReceiptHistory.CurrentRow;
        if (currentRow?.Cells.Count > 0)
        {
            var selectedReceiptId = currentRow.Cells[0].Value?.ToString();
            if (!string.IsNullOrWhiteSpace(selectedReceiptId))
            {
                try
                {
                    _currentPrintInfo = AppRuntime.DataService.GetReceiptPrintInfo(selectedReceiptId);
                    _lastReceiptId = selectedReceiptId;
                    ppdTuitionReceiptPreview.ShowDialog(this);
                    return;
                }
                catch (Exception ex)
                {
                    ErrorLogger.Log(ex, nameof(FrmTuitionReceipt));
                }
            }
        }

        MessageBox.Show(this, "Chưa có biên lai nào để xem trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void SyncSelectedReceipt()
    {
        var currentRow = dgvReceiptHistory.CurrentRow;
        if (currentRow?.Cells.Count > 0)
        {
            _lastReceiptId = currentRow.Cells[0].Value?.ToString();
        }
    }

    private bool ValidateReceipt()
    {
        errTuitionReceipt.Clear();

        if (string.IsNullOrWhiteSpace(_currentEnrollmentId))
        {
            errTuitionReceipt.SetError(txtReceiptStudentCode, "Không tìm thấy ghi danh để thu học phí.");
        }

        var amount = ParseMoney(txtReceiptAmount.Text);
        if (amount <= 0)
        {
            errTuitionReceipt.SetError(txtReceiptAmount, "Số tiền thu phải > 0.");
        }

        if (_currentContext is not null && amount > _currentContext.OutstandingBalance && _currentContext.OutstandingBalance > 0)
        {
            errTuitionReceipt.SetError(txtReceiptAmount, "Số tiền thu không được vượt quá công nợ hiện tại.");
        }

        return string.IsNullOrWhiteSpace(errTuitionReceipt.GetError(txtReceiptStudentCode))
            && string.IsNullOrWhiteSpace(errTuitionReceipt.GetError(txtReceiptAmount));
    }

    private void ResetPaymentEditor(bool keepAmount = false)
    {
        errTuitionReceipt.Clear();
        if (!keepAmount)
        {
            txtReceiptAmount.Clear();
        }

        txtReceiptNote.Clear();
        cboReceiptMethod.SelectedIndex = 0;
    }

    private void PrintReceiptPreview(object? sender, PrintPageEventArgs e)
    {
        var graphics = e.Graphics;
        if (graphics is null || _currentPrintInfo is null)
        {
            return;
        }

        using var titleFont = new Font("Segoe UI", 16F, FontStyle.Bold);
        using var bodyFont = new Font("Segoe UI", 11F);
        using var boldFont = new Font("Segoe UI", 11F, FontStyle.Bold);

        var left = 60;
        var top = 60;
        var line = 30;

        graphics.DrawString("BIEN LAI THU HOC PHI", titleFont, Brushes.Black, left, top);
        top += 50;

        graphics.DrawString($"So bien lai: {_currentPrintInfo.ReceiptId}", boldFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Hoc vien: {_currentPrintInfo.StudentName} ({_currentPrintInfo.StudentCode})", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Lop: {_currentPrintInfo.ClassName}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Khoa hoc: {_currentPrintInfo.CourseName}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Hoc phi: {FormatMoney(_currentPrintInfo.TuitionFee)}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"So tien da thu ky nay: {FormatMoney(_currentPrintInfo.AmountPaid)}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Tong da thu: {FormatMoney(_currentPrintInfo.TotalPaid)}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Con lai: {FormatMoney(_currentPrintInfo.OutstandingBalance)}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Ngay nop: {_currentPrintInfo.PayDate:dd/MM/yyyy}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Phuong thuc: {_currentPrintInfo.PaymentMethod}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Nhan vien thu: {_currentPrintInfo.StaffName ?? "Staff"}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Ghi chu: {_currentPrintInfo.Note ?? string.Empty}", bodyFont, Brushes.Black, left, top);
    }

    private void LocalizeLabels()
    {
        grpEnrollmentInfo.Text = "Thông tin ghi danh";
        grpPaymentInfo.Text = "Thông tin thanh toán";

        lblReceiptStudentCode.Text = "Mã học viên";
        lblReceiptStudentName.Text = "Họ và tên";
        lblReceiptClassCode.Text = "Lớp";
        lblReceiptCourseName.Text = "Khóa học / công nợ";

        lblReceiptAmount.Text = "Số tiền thu";
        lblReceiptMethod.Text = "Phương thức thanh toán";
        cboReceiptMethod.Items.Clear();
        cboReceiptMethod.Items.AddRange(["Tiền mặt", "Chuyển khoản"]);
        lblReceiptNote.Text = "Ghi chú";

        btnCollectTuition.Text = "Thu học phí";
        btnSavePrintReceipt.Text = "Lưu và in";
        btnViewReceipt.Text = "Xem biên lai";
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
            }
        }
        finally
        {
            tblReceiptTop.ResumeLayout(true);
            tblReceiptRoot.ResumeLayout(true);
            _isApplyingResponsiveLayout = false;
        }
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

    private static string FormatMoney(decimal amount)
    {
        return amount.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " VND";
    }
}
