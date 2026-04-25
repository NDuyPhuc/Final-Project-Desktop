using System.Data;
using System.Globalization;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmDebtTracking : Form
{
    private readonly DataTable _debtTable = new();
    private bool _isApplyingResponsiveLayout;

    public FrmDebtTracking()
    {
        FormHostHelpers.LogUi("FrmDebtTracking:ctor:start");
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Công nợ học viên");
        ConfigureView();
        BindMockData();
        WireEvents();
        ApplyResponsiveLayout();
        FormHostHelpers.LogUi("FrmDebtTracking:ctor:done");
    }

    private void ConfigureView()
    {
        LocalizeLabels();

        pnlDebtFilterCard.BackColor = AppTheme.Surface;
        pnlDebtSectionCard.BackColor = AppTheme.Surface;

        AppTheme.StylePrimaryButton(btnSearchDebt);
        AppTheme.StyleSecondaryButton(btnRefreshDebt);
        AppTheme.StylePrimaryButton(btnOpenTuitionFromDebt);
        AppTheme.StyleSecondaryButton(btnExportDebt);
        AppTheme.StyleSecondaryButton(btnExportPdfDebt);
        AppTheme.StyleGrid(dgvDebtTrackingList);

        StyleKpiCard(pnlDebtTotalCount, lblDebtTotalCountBadge, pnlDebtTotalCountAccent, AppTheme.Accent);
        StyleKpiCard(pnlDebtTotalAmount, lblDebtTotalAmountBadge, pnlDebtTotalAmountAccent, Color.FromArgb(0, 96, 168));
        StyleKpiCard(pnlDebtDueSoon, lblDebtDueSoonBadge, pnlDebtDueSoonAccent, AppTheme.Danger);

        ConfigureDatePickers();
        ConfigurePagerButton(btnDebtPagePrev, false);
        ConfigurePagerButton(btnDebtPage1, true);
        ConfigurePagerButton(btnDebtPage2, false);
        ConfigurePagerButton(btnDebtPage3, false);
        ConfigurePagerButton(btnDebtPageNext, false);

        dgvDebtTrackingList.BorderStyle = BorderStyle.None;
        dgvDebtTrackingList.ColumnHeadersHeight = 50;
        dgvDebtTrackingList.RowTemplate.Height = 54;
        dgvDebtTrackingList.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
        dgvDebtTrackingList.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        dgvDebtTrackingList.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 251, 255);
        dgvDebtTrackingList.MultiSelect = false;
        dgvDebtTrackingList.AutoGenerateColumns = true;

        lblDebtSectionTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        lblDebtSectionTitle.ForeColor = Color.FromArgb(0, 96, 168);
        lblDebtUpdatedAt.AutoSize = true;

        flpDebtFilterActions.Padding = Padding.Empty;
        flpDebtActions.Padding = Padding.Empty;
        flpDebtActions.WrapContents = false;
    }

    private void BindMockData()
    {
        if (_debtTable.Columns.Count == 0)
        {
            _debtTable.Columns.Add("Mã học viên");
            _debtTable.Columns.Add("Họ tên học viên");
            _debtTable.Columns.Add("Lớp học");
            _debtTable.Columns.Add("Khóa học");
            _debtTable.Columns.Add("Tổng học phí");
            _debtTable.Columns.Add("Đã đóng");
            _debtTable.Columns.Add("Còn nợ");
            _debtTable.Columns.Add("Hạn thanh toán");
            _debtTable.Columns.Add("Trạng thái");
            _debtTable.Columns.Add("Thao tác");

            _debtTable.Rows.Add("HV2023-00124", "Nguyễn Văn Kiến Trúc", "IELTS-2023-A1", "IELTS Intensive", "12.500.000", "5.000.000", "7.500.000", "15/10/2026", "Quá hạn", ">");
            _debtTable.Rows.Add("HV2023-00451", "Trần Thị Minh Ngôn", "IELTS-2023-B2", "IELTS Intensive", "18.000.000", "14.000.000", "4.000.000", "28/10/2026", "Sắp đến hạn", ">");
            _debtTable.Rows.Add("HV2023-00892", "Lê Hoàng Văn Bản", "BE-PRO-01", "Giao tiếp chuyên nghiệp", "25.000.000", "10.000.000", "15.000.000", "12/10/2026", "Quá hạn", ">");
            _debtTable.Rows.Add("HV2023-01056", "Phạm Mỹ Tú", "IELTS-2023-A1", "IELTS Intensive", "12.500.000", "8.000.000", "4.500.000", "01/11/2026", "Đang theo dõi", ">");
            _debtTable.Rows.Add("HV2023-01120", "Võ Ngữ Pháp", "BE-PRO-01", "Giao tiếp chuyên nghiệp", "25.000.000", "20.000.000", "5.000.000", "05/11/2026", "Đang theo dõi", ">");
            _debtTable.Rows.Add("HV2023-01143", "Nguyễn Hải Đăng", "ENG-A1-01", "English Foundation", "2.400.000", "1.500.000", "900.000", "30/04/2026", "Sắp đến hạn", ">");
            _debtTable.Rows.Add("HV2023-01158", "Trần Ngọc Hân", "TIN-CB-03", "Tin học cơ bản", "1.800.000", "800.000", "1.000.000", "02/05/2026", "Đang theo dõi", ">");
            _debtTable.Rows.Add("HV2023-01172", "Hoàng Gia Bích", "TOEIC-09B", "TOEIC Bứt phá", "3.200.000", "2.000.000", "1.200.000", "27/04/2026", "Sắp đến hạn", ">");
        }

        PopulateFilter(cboDebtCourseFilter, "Khóa học");
        PopulateFilter(cboDebtClassFilter, "Lớp học");
        cboDebtCourseFilter.SelectedIndex = 0;
        cboDebtClassFilter.SelectedIndex = 0;
        RefreshGridState(_debtTable);
    }

    private void WireEvents()
    {
        btnSearchDebt.Click += (_, _) => ApplyFilters();
        btnRefreshDebt.Click += (_, _) => ResetFilters();
        btnExportDebt.Click += (_, _) => ShowInfo("Xuất Excel", "Màn hình demo đã sẵn sàng cho thao tác xuất danh sách công nợ ra Excel.");
        btnExportPdfDebt.Click += (_, _) => ShowInfo("Xuất PDF", "Màn hình demo đã sẵn sàng cho thao tác xuất báo cáo công nợ ra PDF.");
        btnOpenTuitionFromDebt.Click += (_, _) =>
        {
            using var form = new FrmTuitionReceipt();
            form.ShowDialog(this);
        };
        Resize += (_, _) => ApplyResponsiveLayout();
    }

    private void PopulateFilter(ComboBox comboBox, string columnName)
    {
        comboBox.Items.Clear();
        comboBox.Items.Add("Tất cả");

        foreach (var value in _debtTable.AsEnumerable()
                     .Select(row => row.Field<string>(columnName))
                     .Where(value => !string.IsNullOrWhiteSpace(value))
                     .Cast<string>()
                     .Distinct())
        {
            comboBox.Items.Add(value);
        }
    }

    private void ConfigureDatePickers()
    {
        dtpDebtFromDate.Format = DateTimePickerFormat.Custom;
        dtpDebtToDate.Format = DateTimePickerFormat.Custom;
        dtpDebtFromDate.CustomFormat = "dd/MM/yyyy";
        dtpDebtToDate.CustomFormat = "dd/MM/yyyy";
        dtpDebtFromDate.Value = DateTime.Today.AddDays(-30);
        dtpDebtToDate.Value = DateTime.Today.AddDays(14);
    }

    private void ApplyFilters()
    {
        var selectedCourse = cboDebtCourseFilter.Text;
        var selectedClass = cboDebtClassFilter.Text;
        var fromDate = dtpDebtFromDate.Value.Date;
        var toDate = dtpDebtToDate.Value.Date;
        var filtered = _debtTable.Clone();

        foreach (DataRow row in _debtTable.Rows)
        {
            var matchesCourse = selectedCourse == "Tất cả" || string.Equals(row["Khóa học"]?.ToString(), selectedCourse, StringComparison.OrdinalIgnoreCase);
            var matchesClass = selectedClass == "Tất cả" || string.Equals(row["Lớp học"]?.ToString(), selectedClass, StringComparison.OrdinalIgnoreCase);
            var dueDate = ParseDate(row["Hạn thanh toán"]?.ToString());
            var matchesDate = dueDate is null || (dueDate.Value.Date >= fromDate && dueDate.Value.Date <= toDate);

            if (matchesCourse && matchesClass && matchesDate)
            {
                filtered.ImportRow(row);
            }
        }

        RefreshGridState(filtered);
    }

    private void ResetFilters()
    {
        cboDebtCourseFilter.SelectedIndex = 0;
        cboDebtClassFilter.SelectedIndex = 0;
        dtpDebtFromDate.Value = DateTime.Today.AddDays(-30);
        dtpDebtToDate.Value = DateTime.Today.AddDays(14);
        RefreshGridState(_debtTable);
    }

    private void RefreshGridState(DataTable source)
    {
        FormHostHelpers.LogUi($"FrmDebtTracking:RefreshGridState:rows={source.Rows.Count}");
        dgvDebtTrackingList.SuspendLayout();

        try
        {
            dgvDebtTrackingList.DataSource = null;
            dgvDebtTrackingList.DataSource = source;
            RefreshKpi(source);
            ConfigureGridColumns();
            ApplyRowStyles();
            UpdateFooter(source.Rows.Count, _debtTable.Rows.Count);
            UpdateUpdatedLabel();
            SelectAccentRow(source.Rows.Count);
        }
        finally
        {
            dgvDebtTrackingList.ResumeLayout(true);
        }
    }

    private void RefreshKpi(DataTable source)
    {
        var totalDebt = source.AsEnumerable().Sum(row => ParseMoney(row["Còn nợ"]?.ToString()));
        var dueCount = source.AsEnumerable().Count(row =>
        {
            var status = row["Trạng thái"]?.ToString();
            return string.Equals(status, "Quá hạn", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(status, "Sắp đến hạn", StringComparison.OrdinalIgnoreCase);
        });

        lblDebtTotalCountValue.Text = source.Rows.Count.ToString("00");
        lblDebtTotalAmountValue.Text = totalDebt.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
        lblDebtTotalAmountUnit.Text = "VND";
        lblDebtDueSoonValue.Text = dueCount.ToString("00");
    }

    private void LocalizeLabels()
    {
        lblDebtCourseFilter.Text = "Khóa học";
        lblDebtClassFilter.Text = "Lớp học";
        lblDebtFromDate.Text = "Từ ngày";
        lblDebtToDate.Text = "Đến ngày";

        btnSearchDebt.Text = "Lọc dữ liệu";
        btnRefreshDebt.Text = "Làm mới";
        btnOpenTuitionFromDebt.Text = "Mở thu học phí";
        btnExportDebt.Text = "Xuất Excel";
        btnExportPdfDebt.Text = "Xuất PDF";

        lblDebtTotalCountTitle.Text = "Học viên nợ phí";
        lblDebtTotalAmountTitle.Text = "Tổng nợ công bố";
        lblDebtDueSoonTitle.Text = "Phát sinh đến hạn";

        lblDebtTotalCountBadge.Text = "HV";
        lblDebtTotalAmountBadge.Text = "VND";
        lblDebtDueSoonBadge.Text = "!";

        lblDebtSectionTitle.Text = "Bảng kê chi tiết công nợ";
    }

    private void ConfigureGridColumns()
    {
        if (dgvDebtTrackingList.Columns.Count == 0)
        {
            return;
        }

        foreach (DataGridViewColumn column in dgvDebtTrackingList.Columns)
        {
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        SetColumn("Mã học viên", "Mã HV", 13F, DataGridViewContentAlignment.MiddleLeft);
        SetColumn("Họ tên học viên", "Họ tên học viên", 18F, DataGridViewContentAlignment.MiddleLeft);
        SetColumn("Lớp học", "Lớp học", 12F, DataGridViewContentAlignment.MiddleLeft);
        SetColumn("Khóa học", "Khóa học", 0F, DataGridViewContentAlignment.MiddleLeft, false);
        SetColumn("Tổng học phí", "Tổng học phí", 13F, DataGridViewContentAlignment.MiddleRight);
        SetColumn("Đã đóng", "Đã đóng", 12F, DataGridViewContentAlignment.MiddleRight);
        SetColumn("Còn nợ", "Còn nợ", 12F, DataGridViewContentAlignment.MiddleRight);
        SetColumn("Hạn thanh toán", "Hạn thanh toán", 12F, DataGridViewContentAlignment.MiddleCenter);
        SetColumn("Trạng thái", "Trạng thái", 12F, DataGridViewContentAlignment.MiddleCenter);
        SetColumn("Thao tác", "Thao tác", 8F, DataGridViewContentAlignment.MiddleCenter);
    }

    private void SetColumn(string name, string header, float fillWeight, DataGridViewContentAlignment alignment, bool visible = true)
    {
        if (!dgvDebtTrackingList.Columns.Contains(name))
        {
            return;
        }

        var column = dgvDebtTrackingList.Columns[name];
        column.HeaderText = header;
        column.Visible = visible;

        if (visible)
        {
            column.FillWeight = fillWeight;
            column.DefaultCellStyle.Alignment = alignment;
        }
    }

    private void ApplyRowStyles()
    {
        foreach (DataGridViewRow row in dgvDebtTrackingList.Rows)
        {
            if (row.IsNewRow)
            {
                continue;
            }

            row.Height = 56;
            row.DefaultCellStyle.ForeColor = AppTheme.TextPrimary;
            row.DefaultCellStyle.BackColor = Color.White;

            var status = row.Cells["Trạng thái"].Value?.ToString() ?? string.Empty;
            if (string.Equals(status, "Quá hạn", StringComparison.OrdinalIgnoreCase))
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 247, 247);
            }
            else if (string.Equals(status, "Sắp đến hạn", StringComparison.OrdinalIgnoreCase))
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(242, 252, 252);
            }

            StyleMoneyCell(row, "Tổng học phí", AppTheme.TextPrimary);
            StyleMoneyCell(row, "Đã đóng", AppTheme.Success);
            StyleMoneyCell(row, "Còn nợ", string.Equals(status, "Quá hạn", StringComparison.OrdinalIgnoreCase) ? AppTheme.Danger : Color.FromArgb(0, 96, 168));

            if (row.Cells["Mã học viên"] is DataGridViewCell codeCell)
            {
                codeCell.Style.Font = AppTheme.FontBodyBold;
                codeCell.Style.ForeColor = Color.FromArgb(0, 96, 168);
            }

            if (row.Cells["Họ tên học viên"] is DataGridViewCell nameCell)
            {
                nameCell.Style.Font = AppTheme.FontBodyBold;
            }

            if (row.Cells["Trạng thái"] is DataGridViewCell statusCell)
            {
                ApplyStatusStyle(statusCell, status);
            }

            if (row.Cells["Thao tác"] is DataGridViewCell actionCell)
            {
                actionCell.Style.Font = AppTheme.FontBodyBold;
                actionCell.Style.ForeColor = Color.FromArgb(0, 96, 168);
            }
        }
    }

    private void StyleMoneyCell(DataGridViewRow row, string columnName, Color color)
    {
        var grid = row.DataGridView;
        if (grid is null || !grid.Columns.Contains(columnName))
        {
            return;
        }

        var cell = row.Cells[columnName];
        cell.Style.ForeColor = color;
        cell.Style.Font = AppTheme.FontBodyBold;
    }

    private void ApplyStatusStyle(DataGridViewCell cell, string status)
    {
        cell.Style.Font = AppTheme.FontBodyBold;
        cell.Style.SelectionForeColor = cell.Style.ForeColor;

        if (string.Equals(status, "Quá hạn", StringComparison.OrdinalIgnoreCase))
        {
            cell.Style.BackColor = Color.FromArgb(255, 235, 235);
            cell.Style.ForeColor = AppTheme.Danger;
        }
        else if (string.Equals(status, "Sắp đến hạn", StringComparison.OrdinalIgnoreCase))
        {
            cell.Style.BackColor = Color.FromArgb(255, 246, 230);
            cell.Style.ForeColor = Color.FromArgb(187, 112, 22);
        }
        else
        {
            cell.Style.BackColor = Color.FromArgb(233, 242, 251);
            cell.Style.ForeColor = Color.FromArgb(92, 112, 132);
        }
    }

    private void SelectAccentRow(int rowCount)
    {
        if (rowCount == 0 || dgvDebtTrackingList.Rows.Count == 0)
        {
            return;
        }

        var rowIndex = Math.Min(2, dgvDebtTrackingList.Rows.Count - 1);
        dgvDebtTrackingList.ClearSelection();
        dgvDebtTrackingList.Rows[rowIndex].Selected = true;
    }

    private void UpdateFooter(int visibleCount, int totalCount)
    {
        if (visibleCount <= 0)
        {
            lblDebtFooterSummary.Text = $"Hiển thị 0 trên tổng số {totalCount} học viên";
            return;
        }

        lblDebtFooterSummary.Text = $"Hiển thị 1-{visibleCount} trên tổng số {totalCount} học viên";
    }

    private void UpdateUpdatedLabel()
    {
        lblDebtUpdatedAt.Text = $"Cập nhật: {DateTime.Now:HH:mm dd/MM/yyyy}";
    }

    private void ApplyResponsiveLayout()
    {
        if (_isApplyingResponsiveLayout || IsDisposed)
        {
            return;
        }

        var width = ClientSize.Width - Padding.Horizontal;
        if (width <= 0)
        {
            return;
        }

        _isApplyingResponsiveLayout = true;
        tblDebtFilterLayout.SuspendLayout();
        tblDebtKpi.SuspendLayout();
        tblDebtSectionHeader.SuspendLayout();
        tblDebtFooter.SuspendLayout();

        try
        {
            if (width < 980)
            {
                tblDebtFilterLayout.ColumnCount = 2;
                tblDebtFilterLayout.RowCount = 5;
                tblDebtFilterLayout.ColumnStyles.Clear();
                tblDebtFilterLayout.RowStyles.Clear();
                tblDebtFilterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tblDebtFilterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                for (var row = 0; row < 5; row++)
                {
                    tblDebtFilterLayout.RowStyles.Add(new RowStyle());
                }

                SetFilterLayout(lblDebtCourseFilter, 0, 0);
                SetFilterLayout(cboDebtCourseFilter, 0, 1);
                SetFilterLayout(lblDebtClassFilter, 1, 0);
                SetFilterLayout(cboDebtClassFilter, 1, 1);
                SetFilterLayout(lblDebtFromDate, 0, 2);
                SetFilterLayout(dtpDebtFromDate, 0, 3);
                SetFilterLayout(lblDebtToDate, 1, 2);
                SetFilterLayout(dtpDebtToDate, 1, 3);
                SetFilterLayout(flpDebtFilterActions, 0, 4, 2);

                flpDebtFilterActions.FlowDirection = FlowDirection.LeftToRight;
                flpDebtFilterActions.WrapContents = true;

                tblDebtKpi.ColumnCount = 1;
                tblDebtKpi.RowCount = 3;
                tblDebtKpi.ColumnStyles.Clear();
                tblDebtKpi.RowStyles.Clear();
                tblDebtKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                tblDebtKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
                tblDebtKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
                tblDebtKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
                SetKpiPosition(pnlDebtTotalCount, 0, 0, new Padding(0, 0, 0, 14));
                SetKpiPosition(pnlDebtTotalAmount, 0, 1, new Padding(0, 0, 0, 14));
                SetKpiPosition(pnlDebtDueSoon, 0, 2, Padding.Empty);

                tblDebtSectionHeader.ColumnCount = 1;
                tblDebtSectionHeader.RowCount = 3;
                tblDebtSectionHeader.ColumnStyles.Clear();
                tblDebtSectionHeader.RowStyles.Clear();
                tblDebtSectionHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                tblDebtSectionHeader.RowStyles.Add(new RowStyle());
                tblDebtSectionHeader.RowStyles.Add(new RowStyle());
                tblDebtSectionHeader.RowStyles.Add(new RowStyle());
                SetHeaderLayout(lblDebtSectionTitle, 0, 0);
                SetHeaderLayout(lblDebtUpdatedAt, 0, 1);
                SetHeaderLayout(flpDebtActions, 0, 2);
                flpDebtActions.WrapContents = true;

                tblDebtFooter.ColumnCount = 1;
                tblDebtFooter.RowCount = 2;
                tblDebtFooter.ColumnStyles.Clear();
                tblDebtFooter.RowStyles.Clear();
                tblDebtFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                tblDebtFooter.RowStyles.Add(new RowStyle());
                tblDebtFooter.RowStyles.Add(new RowStyle());
                tblDebtFooter.SetColumn(lblDebtFooterSummary, 0);
                tblDebtFooter.SetRow(lblDebtFooterSummary, 0);
                tblDebtFooter.SetColumn(flpDebtPager, 0);
                tblDebtFooter.SetRow(flpDebtPager, 1);
            }
            else
            {
                tblDebtFilterLayout.ColumnCount = 5;
                tblDebtFilterLayout.RowCount = 2;
                tblDebtFilterLayout.ColumnStyles.Clear();
                tblDebtFilterLayout.RowStyles.Clear();
                tblDebtFilterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
                tblDebtFilterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
                tblDebtFilterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
                tblDebtFilterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
                tblDebtFilterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
                tblDebtFilterLayout.RowStyles.Add(new RowStyle());
                tblDebtFilterLayout.RowStyles.Add(new RowStyle());

                SetFilterLayout(lblDebtCourseFilter, 0, 0);
                SetFilterLayout(cboDebtCourseFilter, 0, 1);
                SetFilterLayout(lblDebtClassFilter, 1, 0);
                SetFilterLayout(cboDebtClassFilter, 1, 1);
                SetFilterLayout(lblDebtFromDate, 2, 0);
                SetFilterLayout(dtpDebtFromDate, 2, 1);
                SetFilterLayout(lblDebtToDate, 3, 0);
                SetFilterLayout(dtpDebtToDate, 3, 1);
                SetFilterLayout(flpDebtFilterActions, 4, 0, 1, 2);

                flpDebtFilterActions.FlowDirection = FlowDirection.TopDown;
                flpDebtFilterActions.WrapContents = false;

                tblDebtKpi.ColumnCount = 3;
                tblDebtKpi.RowCount = 1;
                tblDebtKpi.ColumnStyles.Clear();
                tblDebtKpi.RowStyles.Clear();
                tblDebtKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
                tblDebtKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
                tblDebtKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
                tblDebtKpi.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                SetKpiPosition(pnlDebtTotalCount, 0, 0, new Padding(0, 0, 16, 0));
                SetKpiPosition(pnlDebtTotalAmount, 1, 0, new Padding(0, 0, 16, 0));
                SetKpiPosition(pnlDebtDueSoon, 2, 0, Padding.Empty);

                if (width < 1180)
                {
                    tblDebtSectionHeader.ColumnCount = 1;
                    tblDebtSectionHeader.RowCount = 3;
                    tblDebtSectionHeader.ColumnStyles.Clear();
                    tblDebtSectionHeader.RowStyles.Clear();
                    tblDebtSectionHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                    tblDebtSectionHeader.RowStyles.Add(new RowStyle());
                    tblDebtSectionHeader.RowStyles.Add(new RowStyle());
                    tblDebtSectionHeader.RowStyles.Add(new RowStyle());
                    SetHeaderLayout(lblDebtSectionTitle, 0, 0);
                    SetHeaderLayout(lblDebtUpdatedAt, 0, 1);
                    SetHeaderLayout(flpDebtActions, 0, 2);
                    flpDebtActions.WrapContents = true;
                }
                else
                {
                    tblDebtSectionHeader.ColumnCount = 3;
                    tblDebtSectionHeader.RowCount = 1;
                    tblDebtSectionHeader.ColumnStyles.Clear();
                    tblDebtSectionHeader.RowStyles.Clear();
                    tblDebtSectionHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                    tblDebtSectionHeader.ColumnStyles.Add(new ColumnStyle());
                    tblDebtSectionHeader.ColumnStyles.Add(new ColumnStyle());
                    tblDebtSectionHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                    SetHeaderLayout(lblDebtSectionTitle, 0, 0);
                    SetHeaderLayout(lblDebtUpdatedAt, 1, 0);
                    SetHeaderLayout(flpDebtActions, 2, 0);
                    flpDebtActions.WrapContents = false;
                }

                tblDebtFooter.ColumnCount = 2;
                tblDebtFooter.RowCount = 1;
                tblDebtFooter.ColumnStyles.Clear();
                tblDebtFooter.RowStyles.Clear();
                tblDebtFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                tblDebtFooter.ColumnStyles.Add(new ColumnStyle());
                tblDebtFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                tblDebtFooter.SetColumn(lblDebtFooterSummary, 0);
                tblDebtFooter.SetRow(lblDebtFooterSummary, 0);
                tblDebtFooter.SetColumn(flpDebtPager, 1);
                tblDebtFooter.SetRow(flpDebtPager, 0);
            }
        }
        finally
        {
            tblDebtFooter.ResumeLayout(true);
            tblDebtSectionHeader.ResumeLayout(true);
            tblDebtKpi.ResumeLayout(true);
            tblDebtFilterLayout.ResumeLayout(true);
            _isApplyingResponsiveLayout = false;
        }
    }

    private void SetFilterLayout(Control control, int column, int row, int columnSpan = 1, int rowSpan = 1)
    {
        tblDebtFilterLayout.SetColumn(control, column);
        tblDebtFilterLayout.SetRow(control, row);
        tblDebtFilterLayout.SetColumnSpan(control, columnSpan);
        tblDebtFilterLayout.SetRowSpan(control, rowSpan);
    }

    private void SetHeaderLayout(Control control, int column, int row)
    {
        tblDebtSectionHeader.SetColumn(control, column);
        tblDebtSectionHeader.SetRow(control, row);
    }

    private static void SetKpiPosition(Control control, int column, int row, Padding margin)
    {
        if (control.Parent is not TableLayoutPanel table)
        {
            return;
        }

        table.SetColumn(control, column);
        table.SetRow(control, row);
        control.Margin = margin;
    }

    private void StyleKpiCard(Panel panel, Label badge, Panel accent, Color accentColor)
    {
        AppTheme.StyleCard(panel);
        panel.Padding = new Padding(22, 18, 22, 18);
        panel.Margin = new Padding(0, 0, 16, 0);
        badge.ForeColor = accentColor;
        accent.BackColor = accentColor;
    }

    private void ConfigurePagerButton(Button button, bool isActive)
    {
        button.FlatStyle = FlatStyle.Flat;
        button.Cursor = Cursors.Hand;
        button.Font = AppTheme.FontBodyBold;

        if (isActive)
        {
            button.BackColor = Color.FromArgb(0, 66, 118);
            button.ForeColor = Color.White;
            button.FlatAppearance.BorderSize = 0;
        }
        else
        {
            button.BackColor = Color.White;
            button.ForeColor = AppTheme.TextMuted;
            button.FlatAppearance.BorderColor = AppTheme.Border;
            button.FlatAppearance.BorderSize = 1;
        }
    }

    private void ShowInfo(string title, string message)
    {
        using var dialog = new FrmStatusDialog(title, message);
        dialog.ShowDialog(this);
    }

    private static decimal ParseMoney(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return 0M;
        }

        var digits = new string(value.Where(char.IsDigit).ToArray());
        return decimal.TryParse(digits, out var result) ? result : 0M;
    }

    private static DateTime? ParseDate(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return DateTime.TryParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date)
            ? date
            : null;
    }
}
