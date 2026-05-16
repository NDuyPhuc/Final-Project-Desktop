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
        MinimumSize = FormHostHelpers.ScaleSize(this, new Size(1120, 680));

        AppTheme.StyleGroupBox(grpEnrollmentInfo);
        AppTheme.StyleGroupBox(grpPaymentInfo);
        AppTheme.StyleGrid(dgvReceiptHistory);
        AppTheme.StylePrimaryButton(btnCollectTuition);
        AppTheme.StyleSecondaryButton(btnSavePrintReceipt);
        AppTheme.StyleSecondaryButton(btnExportReceiptPdf);
        AppTheme.StyleSecondaryButton(btnViewReceipt);
        AppTheme.StyleDangerButton(btnCancelReceipt);

        cboReceiptMethod.SelectedIndex = 0;
        ttTuitionReceipt.SetToolTip(btnCollectTuition, "Lưu biên lai thu học phí.");
        ttTuitionReceipt.SetToolTip(btnSavePrintReceipt, "Lưu biên lai và mở Print Preview.");
        ttTuitionReceipt.SetToolTip(btnExportReceiptPdf, "Lưu biên lai đang chọn ra file PDF.");
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
        txtReceiptStudentCode.PlaceholderText = "Gõ mã hoặc tên học viên, hệ thống sẽ gợi ý";
        ConfigureStudentCodeAutoComplete();
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
        btnExportReceiptPdf.Click += (_, _) => ExportActiveReceiptPdf();
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
            var previousEnrollmentId = _currentEnrollmentId;
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
            if (!string.Equals(previousEnrollmentId, _currentEnrollmentId, StringComparison.OrdinalIgnoreCase))
            {
                _lastReceiptId = null;
                _currentPrintInfo = null;
            }

            txtReceiptStudentCode.ReadOnly = false;
            txtReceiptStudentCode.Text = _currentContext.StudentCode;
            txtReceiptStudentName.Text = _currentContext.StudentName;
            txtReceiptClassCode.Text = $"{_currentContext.ClassCode} - {_currentContext.ClassName}";
            txtReceiptCourseName.Text = $"{_currentContext.CourseName} | Học phí: {FormatMoney(_currentContext.TuitionFee)} | Còn nợ: {FormatMoney(_currentContext.OutstandingBalance)}";
            txtReceiptAmount.Text = _currentContext.OutstandingBalance > 0
                ? _currentContext.OutstandingBalance.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"))
                : "0";
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
            var studentId = ResolveReceiptStudentId(txtReceiptStudentCode.Text.Trim());
            var context = AppRuntime.DataService.GetLatestEnrollmentReceiptContextByStudentId(studentId);
            if (context is null)
            {
                MessageBox.Show(this, "Không tìm thấy ghi danh phù hợp cho học viên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _currentContext = context;
            _currentEnrollmentId = context.EnrollmentId;
            _lastReceiptId = null;
            _currentPrintInfo = null;
            txtReceiptStudentCode.Text = context.StudentCode;
            txtReceiptStudentName.Text = context.StudentName;
            txtReceiptClassCode.Text = $"{context.ClassCode} - {context.ClassName}";
            txtReceiptCourseName.Text = $"{context.CourseName} | Học phí: {FormatMoney(context.TuitionFee)} | Còn nợ: {FormatMoney(context.OutstandingBalance)}";
            txtReceiptAmount.Text = context.OutstandingBalance > 0
                ? context.OutstandingBalance.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"))
                : "0";

            LoadReceiptHistory();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTuitionReceipt));
            MessageBox.Show(this, "Không tìm thấy ghi danh phù hợp cho học viên này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ConfigureStudentCodeAutoComplete()
    {
        try
        {
            var source = new AutoCompleteStringCollection();
            var students = AppRuntime.DataService.GetEnrollmentStudents();
            foreach (DataRow row in students.Rows)
            {
                var id = row[0]?.ToString()?.Trim() ?? string.Empty;
                var name = row[1]?.ToString()?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(id))
                {
                    continue;
                }

                source.Add(id);
                if (!string.IsNullOrWhiteSpace(name))
                {
                    source.Add(name);
                    source.Add($"{id} - {name}");
                }
            }

            txtReceiptStudentCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtReceiptStudentCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtReceiptStudentCode.AutoCompleteCustomSource = source;
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTuitionReceipt));
        }
    }

    private string ResolveReceiptStudentId(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        var exactId = input.Split('-', 2)[0].Trim();
        var students = AppRuntime.DataService.GetEnrollmentStudents();
        var partialMatches = new List<string>();

        foreach (DataRow row in students.Rows)
        {
            var id = row[0]?.ToString()?.Trim() ?? string.Empty;
            var name = row[1]?.ToString()?.Trim() ?? string.Empty;
            var display = $"{id} - {name}";
            if (id.Equals(exactId, StringComparison.OrdinalIgnoreCase)
                || id.Equals(input, StringComparison.OrdinalIgnoreCase)
                || name.Equals(input, StringComparison.OrdinalIgnoreCase)
                || display.Equals(input, StringComparison.OrdinalIgnoreCase))
            {
                return id;
            }

            if (input.Length >= 2
                && (id.Contains(input, StringComparison.OrdinalIgnoreCase)
                    || name.Contains(input, StringComparison.OrdinalIgnoreCase)
                    || display.Contains(input, StringComparison.OrdinalIgnoreCase)))
            {
                partialMatches.Add(id);
            }
        }

        return partialMatches.Distinct(StringComparer.OrdinalIgnoreCase).Take(2).Count() == 1
            ? partialMatches[0]
            : exactId;
    }

    private void LoadReceiptHistory()
    {
        try
        {
            dgvReceiptHistory.DataSource = AppRuntime.DataService.GetReceiptHistory(
                _currentEnrollmentId,
                string.IsNullOrWhiteSpace(txtReceiptStudentCode.Text) ? null : txtReceiptStudentCode.Text.Trim());

            if (dgvReceiptHistory.Rows.Count == 0)
            {
                _lastReceiptId = null;
                _currentPrintInfo = null;
            }
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
            ValidationFeedback.ShowFirstError(this, errTuitionReceipt,
                txtReceiptStudentCode,
                txtReceiptAmount);
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
            SelectReceiptHistoryRow(receipt.Id);
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
        if (!TryLoadActiveReceiptPrintInfo())
        {
            MessageBox.Show(this, "Chưa có biên lai nào để xem trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        ppdTuitionReceiptPreview.ShowDialog(this);
    }

    private void ExportActiveReceiptPdf()
    {
        if (!TryLoadActiveReceiptPrintInfo())
        {
            MessageBox.Show(this, "Chưa có biên lai nào để xuất PDF.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = BuildReceiptPdfFileName(_currentPrintInfo!.ReceiptId),
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            ExportFileHelper.ExportReceiptToPdf(_currentPrintInfo, dialog.FileName);
            MessageBox.Show(this, "Đã lưu biên lai ra PDF.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTuitionReceipt));
            MessageBox.Show(this, "Không xuất được biên lai PDF. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool TryLoadActiveReceiptPrintInfo()
    {
        var receiptId = GetActiveReceiptId();
        if (string.IsNullOrWhiteSpace(receiptId))
        {
            return false;
        }

        try
        {
            _currentPrintInfo = AppRuntime.DataService.GetReceiptPrintInfo(receiptId);
            if (_currentContext is not null
                && !_currentPrintInfo.StudentCode.Equals(_currentContext.StudentCode, StringComparison.OrdinalIgnoreCase))
            {
                _currentPrintInfo = null;
                return false;
            }

            _lastReceiptId = receiptId;
            return true;
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTuitionReceipt));
            return false;
        }
    }

    private string? GetActiveReceiptId()
    {
        var currentRow = dgvReceiptHistory.CurrentRow;
        if (currentRow?.Cells.Count > 0)
        {
            var selectedReceiptId = currentRow.Cells[0].Value?.ToString();
            if (!string.IsNullOrWhiteSpace(selectedReceiptId))
            {
                return selectedReceiptId;
            }
        }

        if (string.IsNullOrWhiteSpace(_lastReceiptId))
        {
            return null;
        }

        foreach (DataGridViewRow row in dgvReceiptHistory.Rows)
        {
            if (string.Equals(row.Cells[0].Value?.ToString(), _lastReceiptId, StringComparison.OrdinalIgnoreCase))
            {
                return _lastReceiptId;
            }
        }

        return null;
    }

    private void SyncSelectedReceipt()
    {
        var currentRow = dgvReceiptHistory.CurrentRow;
        if (currentRow?.Cells.Count > 0)
        {
            _lastReceiptId = currentRow.Cells[0].Value?.ToString();
        }
    }

    private void SelectReceiptHistoryRow(string receiptId)
    {
        foreach (DataGridViewRow row in dgvReceiptHistory.Rows)
        {
            if (string.Equals(row.Cells[0].Value?.ToString(), receiptId, StringComparison.OrdinalIgnoreCase))
            {
                dgvReceiptHistory.CurrentCell = row.Cells[0];
                row.Selected = true;
                return;
            }
        }
    }

    private static string BuildReceiptPdfFileName(string receiptId)
    {
        var safeReceiptId = new string(receiptId
            .Select(ch => Path.GetInvalidFileNameChars().Contains(ch) ? '-' : ch)
            .ToArray());

        return $"bien-lai-{safeReceiptId}.pdf";
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

        if (_currentContext is not null && _currentContext.OutstandingBalance <= 0)
        {
            errTuitionReceipt.SetError(txtReceiptAmount, "Ghi danh này đã thanh toán đủ học phí.");
        }
        else if (_currentContext is not null && amount > _currentContext.OutstandingBalance)
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

        graphics.DrawString("BIÊN LAI THU HỌC PHÍ", titleFont, Brushes.Black, left, top);
        top += 50;

        graphics.DrawString($"Số biên lai: {_currentPrintInfo.ReceiptId}", boldFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Học viên: {_currentPrintInfo.StudentName} ({_currentPrintInfo.StudentCode})", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Lớp: {_currentPrintInfo.ClassName}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Khóa học: {_currentPrintInfo.CourseName}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Học phí: {FormatMoney(_currentPrintInfo.TuitionFee)}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Số tiền thu kỳ này: {FormatMoney(_currentPrintInfo.AmountPaid)}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Tổng đã thu: {FormatMoney(_currentPrintInfo.TotalPaid)}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Còn lại: {FormatMoney(_currentPrintInfo.OutstandingBalance)}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Ngày nộp: {_currentPrintInfo.PayDate:dd/MM/yyyy}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Phương thức: {_currentPrintInfo.PaymentMethod}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Nhân viên thu: {_currentPrintInfo.StaffName ?? "Staff"}", bodyFont, Brushes.Black, left, top);
        top += line;
        graphics.DrawString($"Ghi chú: {_currentPrintInfo.Note ?? string.Empty}", bodyFont, Brushes.Black, left, top);
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
        btnExportReceiptPdf.Text = "Xuất PDF";
        btnViewReceipt.Text = "Xem biên lai";
        btnCancelReceipt.Text = "Đặt lại";
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
            if (ClientSize.Width < FormHostHelpers.ScaleForDpi(this, 940))
            {
                tblReceiptTop.ColumnCount = 1;
                tblReceiptTop.RowCount = 2;
                tblReceiptTop.ColumnStyles.Clear();
                tblReceiptTop.RowStyles.Clear();
                tblReceiptTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                tblReceiptTop.RowStyles.Add(new RowStyle(SizeType.Absolute, FormHostHelpers.ScaleForDpi(this, 220)));
                tblReceiptTop.RowStyles.Add(new RowStyle(SizeType.Absolute, FormHostHelpers.ScaleForDpi(this, 280)));
            }
            else
            {
                tblReceiptTop.ColumnCount = 2;
                tblReceiptTop.RowCount = 1;
                tblReceiptTop.ColumnStyles.Clear();
                tblReceiptTop.RowStyles.Clear();
                tblReceiptTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tblReceiptTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tblReceiptTop.RowStyles.Add(new RowStyle(SizeType.Absolute, FormHostHelpers.ScaleForDpi(this, 236)));
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
