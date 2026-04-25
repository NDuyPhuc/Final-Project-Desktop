using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmAttendance : Form
{
    private DataTable _attendanceTable = new();
    private TableLayoutPanel? _tblHeader;
    private Panel? _pnlQuickActions;
    private Panel? _pnlFooterStats;
    private Panel? _pnlFooterButtons;

    public FrmAttendance()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Điểm danh");
        ConfigureView();
        BindMockData();
        WireEvents();
        Resize += (_, _) => ApplyResponsiveLayout();
        ApplyResponsiveLayout();
    }

    private void ConfigureView()
    {
        BackColor = Color.FromArgb(239, 248, 255);
        Padding = new Padding(12);

        cboAttendanceClass.Items.Clear();
        cboAttendanceClass.Items.AddRange(["ENG-ADV-2024-B1", "IELTS-FOUND-01", "TOEIC-A2"]);
        cboAttendanceClass.SelectedIndex = 0;

        cboAttendanceSession.Items.Clear();
        cboAttendanceSession.Items.AddRange(["Buổi 12: Phrasal Verbs in Context", "Buổi 11: Review", "Buổi 10: Listening"]);
        cboAttendanceSession.SelectedIndex = 0;

        dtpAttendanceDate.Format = DateTimePickerFormat.Custom;
        dtpAttendanceDate.CustomFormat = "dd/MM/yyyy";

        AppTheme.StyleGrid(dgvAttendanceList);
        dgvAttendanceList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgvAttendanceList.ScrollBars = ScrollBars.Both;
        dgvAttendanceList.ColumnHeadersHeight = 44;
        dgvAttendanceList.RowTemplate.Height = 44;
        dgvAttendanceList.DefaultCellStyle.Padding = new Padding(6, 4, 6, 4);

        AppTheme.StylePrimaryButton(btnSearchAttendance);
        btnSearchAttendance.Text = "XEM DANH SÁCH";
        AppTheme.StylePrimaryButton(btnCheckAllPresent);
        btnCheckAllPresent.Text = "CÓ MẶT TẤT CẢ";
        AppTheme.StyleSecondaryButton(btnCheckAllAbsent);
        btnCheckAllAbsent.Text = "VẮNG TẤT CẢ";
        AppTheme.StylePrimaryButton(btnSaveAttendance);
        btnSaveAttendance.Text = "LƯU ĐIỂM DANH";

        ttAttendance.SetToolTip(btnCheckAllPresent, "Đánh dấu có mặt cho toàn bộ học viên.");
        ttAttendance.SetToolTip(btnCheckAllAbsent, "Đánh dấu vắng cho toàn bộ học viên.");
        ttAttendance.SetToolTip(btnSaveAttendance, "Lưu dữ liệu điểm danh demo.");

        BuildLayout();
    }

    private void BuildLayout()
    {
        tblAttendanceRoot.SuspendLayout();
        tblAttendanceRoot.Controls.Clear();
        tblAttendanceRoot.ColumnCount = 1;
        tblAttendanceRoot.RowCount = 5;
        tblAttendanceRoot.RowStyles.Clear();
        tblAttendanceRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
        tblAttendanceRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 98F));
        tblAttendanceRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
        tblAttendanceRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblAttendanceRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));

        _tblHeader = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            Margin = new Padding(0, 0, 0, 12)
        };
        _tblHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _tblHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 240F));

        var title = new Label
        {
            Dock = DockStyle.Fill,
            Text = "ĐIỂM DANH BUỔI HỌC",
            Font = new Font("Segoe UI", 18F, FontStyle.Bold),
            ForeColor = Color.FromArgb(19, 39, 60),
            TextAlign = ContentAlignment.MiddleLeft
        };
        var meta = new Label
        {
            Dock = DockStyle.Fill,
            Text = "Đã điểm danh: 18/24 học viên",
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(0, 96, 168),
            TextAlign = ContentAlignment.MiddleRight
        };
        _tblHeader.Controls.Add(title, 0, 0);
        _tblHeader.Controls.Add(meta, 1, 0);

        pnlAttendanceFilterCard.Controls.Clear();
        pnlAttendanceFilterCard.BorderStyle = BorderStyle.None;
        pnlAttendanceFilterCard.BackColor = Color.FromArgb(227, 243, 254);
        pnlAttendanceFilterCard.Padding = new Padding(18, 12, 18, 12);

        var filterTable = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 4,
            RowCount = 2
        };
        filterTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
        filterTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
        filterTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
        filterTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
        filterTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
        filterTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));

        var lblClass = CreateMiniLabel("CHỌN LỚP HỌC");
        var lblSession = CreateMiniLabel("CHỌN BUỔI HỌC");
        var lblDate = CreateMiniLabel("NGÀY HỌC");

        cboAttendanceClass.Dock = DockStyle.Fill;
        cboAttendanceSession.Dock = DockStyle.Fill;
        dtpAttendanceDate.Dock = DockStyle.Fill;

        filterTable.Controls.Add(lblClass, 0, 0);
        filterTable.Controls.Add(lblSession, 1, 0);
        filterTable.Controls.Add(lblDate, 2, 0);
        filterTable.Controls.Add(new Label(), 3, 0);
        filterTable.Controls.Add(cboAttendanceClass, 0, 1);
        filterTable.Controls.Add(cboAttendanceSession, 1, 1);
        filterTable.Controls.Add(dtpAttendanceDate, 2, 1);
        filterTable.Controls.Add(btnSearchAttendance, 3, 1);
        pnlAttendanceFilterCard.Controls.Add(filterTable);

        _pnlQuickActions = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };
        var quickFlow = new FlowLayoutPanel
        {
            Dock = DockStyle.Left,
            Width = 320,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false
        };
        quickFlow.Controls.Add(btnCheckAllPresent);
        quickFlow.Controls.Add(btnCheckAllAbsent);
        _pnlQuickActions.Controls.Add(quickFlow);

        dgvAttendanceList.Dock = DockStyle.Fill;

        _pnlFooterStats = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };
        _pnlFooterButtons = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        var footer = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2
        };
        footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
        footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));

        var statsFlow = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            Padding = new Padding(0, 10, 0, 0)
        };
        statsFlow.Controls.Add(CreateFooterStat("SĨ SỐ LỚP", "24", Color.FromArgb(19, 39, 60)));
        statsFlow.Controls.Add(CreateFooterStat("HIỆN DIỆN", "21", Color.FromArgb(0, 123, 118)));
        statsFlow.Controls.Add(CreateFooterStat("VẮNG MẶT", "03", Color.FromArgb(153, 91, 13)));
        _pnlFooterStats.Controls.Add(statsFlow);

        var buttonFlow = new FlowLayoutPanel
        {
            Dock = DockStyle.Right,
            Width = 270,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            Padding = new Padding(0, 10, 0, 0)
        };
        var btnCancel = new Button
        {
            Text = "HỦY BỎ",
            Width = 110,
            Height = 36,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            BackColor = Color.FromArgb(225, 242, 254),
            ForeColor = Color.FromArgb(0, 96, 168)
        };
        btnCancel.FlatAppearance.BorderColor = Color.FromArgb(187, 216, 240);
        buttonFlow.Controls.Add(btnCancel);
        buttonFlow.Controls.Add(btnSaveAttendance);
        _pnlFooterButtons.Controls.Add(buttonFlow);

        footer.Controls.Add(_pnlFooterStats, 0, 0);
        footer.Controls.Add(_pnlFooterButtons, 1, 0);

        tblAttendanceRoot.Controls.Add(_tblHeader, 0, 0);
        tblAttendanceRoot.Controls.Add(pnlAttendanceFilterCard, 0, 1);
        tblAttendanceRoot.Controls.Add(_pnlQuickActions, 0, 2);
        tblAttendanceRoot.Controls.Add(dgvAttendanceList, 0, 3);
        tblAttendanceRoot.Controls.Add(footer, 0, 4);
        tblAttendanceRoot.ResumeLayout(true);
    }

    private void BindMockData()
    {
        _attendanceTable = new DataTable();
        _attendanceTable.Columns.Add("STT");
        _attendanceTable.Columns.Add("Mã HV");
        _attendanceTable.Columns.Add("Họ và tên");
        _attendanceTable.Columns.Add("Có mặt", typeof(bool));
        _attendanceTable.Columns.Add("Đi muộn", typeof(bool));
        _attendanceTable.Columns.Add("Ghi chú");

        _attendanceTable.Rows.Add("01", "HV-240105", "Nguyễn Hoàng Nam", true, false, "");
        _attendanceTable.Rows.Add("02", "HV-240112", "Lê Thị Minh Khai", true, true, "Vào muộn 5p");
        _attendanceTable.Rows.Add("03", "HV-240128", "Trần Quốc Toàn", false, false, "Nghỉ có phép");
        _attendanceTable.Rows.Add("04", "HV-240145", "Phạm Hồng Thái", true, false, "");
        _attendanceTable.Rows.Add("05", "HV-240167", "Đặng Trần Côn", true, false, "");

        dgvAttendanceList.DataSource = _attendanceTable;
        ConfigureGrid();
    }

    private void ConfigureGrid()
    {
        if (dgvAttendanceList.Columns.Count == 0)
        {
            return;
        }

        dgvAttendanceList.Columns[0].Width = 70;
        dgvAttendanceList.Columns[1].Width = 150;
        dgvAttendanceList.Columns[2].Width = 220;
        dgvAttendanceList.Columns[3].Width = 100;
        dgvAttendanceList.Columns[4].Width = 100;
        dgvAttendanceList.Columns[5].Width = 260;
        foreach (DataGridViewRow row in dgvAttendanceList.Rows)
        {
            if (row.IsNewRow)
            {
                continue;
            }

            row.Cells[0].Style.ForeColor = Color.FromArgb(156, 171, 189);
            row.Cells[1].Style.ForeColor = Color.FromArgb(0, 96, 168);
            row.Cells[1].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            row.Cells[2].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            if (row.Cells[5].Value?.ToString() == "Nghỉ có phép")
            {
                row.Cells[5].Style.ForeColor = Color.FromArgb(209, 53, 53);
                row.Cells[5].Style.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            }
        }
    }

    private void WireEvents()
    {
        btnSearchAttendance.Click += (_, _) => dgvAttendanceList.DataSource = _attendanceTable;
        btnCheckAllPresent.Click += (_, _) =>
        {
            foreach (DataRow row in _attendanceTable.Rows)
            {
                row["Có mặt"] = true;
                row["Đi muộn"] = false;
                row["Ghi chú"] = string.Empty;
            }
        };
        btnCheckAllAbsent.Click += (_, _) =>
        {
            foreach (DataRow row in _attendanceTable.Rows)
            {
                row["Có mặt"] = false;
            }
        };
        btnSaveAttendance.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Lưu điểm danh", "Điểm danh mẫu đã được cập nhật trong bộ dữ liệu demo.");
            dialog.ShowDialog(this);
        };
        dgvAttendanceList.CurrentCellDirtyStateChanged += (_, _) =>
        {
            if (dgvAttendanceList.IsCurrentCellDirty)
            {
                dgvAttendanceList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        };
    }

    private void ApplyResponsiveLayout()
    {
        if (_tblHeader is null)
        {
            return;
        }

        _tblHeader.ColumnStyles[1].Width = ClientSize.Width < 1060 ? 180F : 240F;
        if (_pnlQuickActions?.Controls[0] is FlowLayoutPanel quickFlow)
        {
            var compact = ClientSize.Width < 980;
            quickFlow.WrapContents = compact;
            quickFlow.Height = compact ? 78 : 40;
            tblAttendanceRoot.RowStyles[2].Height = compact ? 84F : 52F;
        }

        if (_pnlFooterButtons?.Controls[0] is FlowLayoutPanel buttonFlow)
        {
            var compactFooter = ClientSize.Width < 1180;
            buttonFlow.WrapContents = compactFooter;
            buttonFlow.Width = compactFooter ? 220 : 270;
            buttonFlow.Height = compactFooter ? 78 : 40;
            tblAttendanceRoot.RowStyles[4].Height = compactFooter ? 86F : 62F;
        }
    }

    private static Label CreateMiniLabel(string text)
    {
        return new Label
        {
            Dock = DockStyle.Fill,
            Text = text,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(92, 106, 124),
            TextAlign = ContentAlignment.BottomLeft
        };
    }

    private static Panel CreateFooterStat(string title, string value, Color accent)
    {
        var panel = new Panel
        {
            Width = 110,
            Height = 44,
            Margin = new Padding(0, 0, 18, 0)
        };
        panel.Controls.Add(new Label
        {
            Dock = DockStyle.Top,
            Height = 24,
            Text = value,
            Font = new Font("Segoe UI", 14F, FontStyle.Bold),
            ForeColor = accent
        });
        panel.Controls.Add(new Label
        {
            Dock = DockStyle.Top,
            Height = 18,
            Text = title,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(103, 116, 135)
        });
        return panel;
    }
}
