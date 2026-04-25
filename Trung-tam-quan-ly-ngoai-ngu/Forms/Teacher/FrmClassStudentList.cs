using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmClassStudentList : Form
{
    private readonly DataTable _studentTable = new();
    private readonly List<Panel> _kpiCards = [];
    private TableLayoutPanel? _tblHeader;
    private TableLayoutPanel? _tblFilter;
    private TableLayoutPanel? _tblKpi;
    private FlowLayoutPanel? _flpFilterActions;
    private FlowLayoutPanel? _flpBottomActions;
    private Panel? _pnlBottomActions;

    public FrmClassStudentList()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Danh sách học sinh lớp");
        ConfigureView();
        BindMockData();
        Resize += (_, _) => ApplyResponsiveLayout();
        ApplyResponsiveLayout();
    }

    private void ConfigureView()
    {
        BackColor = Color.FromArgb(239, 248, 255);
        Padding = new Padding(12);

        cboClassStudentClass.Items.Clear();
        cboClassStudentClass.Items.AddRange(["ENG-ADV-2024-B1", "IELTS-FOUND-01", "TOEIC-A2"]);
        cboClassStudentClass.SelectedIndex = 0;

        cboClassStudentContext.Items.Clear();
        cboClassStudentContext.Items.AddRange(["Buổi 12: Phrasal Verbs", "Buổi 11: Mid-term Review", "Tổng quan lớp"]);
        cboClassStudentContext.SelectedIndex = 0;

        AppTheme.StyleGrid(dgvClassStudentList);
        dgvClassStudentList.Dock = DockStyle.Fill;
        dgvClassStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgvClassStudentList.ScrollBars = ScrollBars.Both;
        dgvClassStudentList.ColumnHeadersHeight = 46;
        dgvClassStudentList.RowTemplate.Height = 48;
        dgvClassStudentList.DefaultCellStyle.Padding = new Padding(8, 6, 8, 6);

        AppTheme.StyleSecondaryButton(btnSearchClassStudent);
        AppTheme.StyleSecondaryButton(btnRefreshClassStudent);
        AppTheme.StylePrimaryButton(btnOpenAttendanceFromStudentList);
        AppTheme.StyleSecondaryButton(btnOpenScoreFromStudentList);
        AppTheme.StyleSecondaryButton(btnBackToTeachingClasses);

        btnSearchClassStudent.Text = "ÁP DỤNG";
        btnRefreshClassStudent.Text = "LÀM MỚI";
        btnOpenAttendanceFromStudentList.Text = "ĐIỂM DANH TOÀN BỘ";
        btnOpenScoreFromStudentList.Text = "LƯU THAY ĐỔI";
        btnBackToTeachingClasses.Text = "XUẤT DANH SÁCH";

        ConfigureActionButton(btnSearchClassStudent, 98);
        ConfigureActionButton(btnRefreshClassStudent, 102);
        ConfigureActionButton(btnBackToTeachingClasses, 150);
        ConfigureActionButton(btnOpenAttendanceFromStudentList, 172);
        ConfigureActionButton(btnOpenScoreFromStudentList, 148);

        BuildLayout();
    }

    private void BuildLayout()
    {
        tblClassStudentRoot.SuspendLayout();
        tblClassStudentRoot.Controls.Clear();
        tblClassStudentRoot.ColumnCount = 1;
        tblClassStudentRoot.RowCount = 5;
        tblClassStudentRoot.RowStyles.Clear();
        tblClassStudentRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
        tblClassStudentRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 94F));
        tblClassStudentRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
        tblClassStudentRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblClassStudentRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));

        BuildHeader();
        BuildFilterCard();
        BuildKpiRow();
        BuildContentHost();
        BuildBottomBar();

        tblClassStudentRoot.Controls.Add(_tblHeader!, 0, 0);
        tblClassStudentRoot.Controls.Add(pnlClassStudentFilterCard, 0, 1);
        tblClassStudentRoot.Controls.Add(_tblKpi!, 0, 2);
        tblClassStudentRoot.Controls.Add(splClassStudentContent, 0, 3);
        tblClassStudentRoot.Controls.Add(_pnlBottomActions!, 0, 4);
        tblClassStudentRoot.ResumeLayout(true);
    }

    private void BuildHeader()
    {
        _tblHeader = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            Margin = new Padding(0, 0, 0, 12)
        };
        _tblHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _tblHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 320F));
        _tblHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260F));

        _tblHeader.Controls.Add(new Label
        {
            Dock = DockStyle.Fill,
            Text = "DANH SÁCH HỌC SINH LỚP",
            Font = new Font("Segoe UI", 18F, FontStyle.Bold),
            ForeColor = Color.FromArgb(18, 38, 59),
            TextAlign = ContentAlignment.MiddleLeft
        }, 0, 0);
        _tblHeader.Controls.Add(new Label
        {
            Dock = DockStyle.Fill,
            Text = "Linguistic Architect v2.4",
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = Color.FromArgb(102, 117, 136)
        }, 1, 0);
        _tblHeader.Controls.Add(new Label
        {
            Dock = DockStyle.Fill,
            Text = "GV: Nguyễn Văn A",
            TextAlign = ContentAlignment.MiddleRight,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            ForeColor = Color.FromArgb(102, 117, 136)
        }, 2, 0);
    }

    private void BuildFilterCard()
    {
        pnlClassStudentFilterCard.Controls.Clear();
        pnlClassStudentFilterCard.BorderStyle = BorderStyle.None;
        pnlClassStudentFilterCard.BackColor = Color.FromArgb(227, 243, 254);
        pnlClassStudentFilterCard.Padding = new Padding(18, 10, 18, 10);

        _tblFilter = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 4,
            RowCount = 2
        };
        _tblFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27F));
        _tblFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27F));
        _tblFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
        _tblFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
        _tblFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
        _tblFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));

        txtClassStudentKeyword.Dock = DockStyle.Fill;
        txtClassStudentKeyword.PlaceholderText = "Nhập tên hoặc mã HV...";
        cboClassStudentClass.Dock = DockStyle.Fill;
        cboClassStudentContext.Dock = DockStyle.Fill;

        _flpFilterActions = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            Margin = Padding.Empty
        };
        _flpFilterActions.Controls.Add(btnSearchClassStudent);
        _flpFilterActions.Controls.Add(btnRefreshClassStudent);

        _tblFilter.Controls.Add(CreateMiniLabel("LỚP HỌC"), 0, 0);
        _tblFilter.Controls.Add(CreateMiniLabel("BUỔI HỌC"), 1, 0);
        _tblFilter.Controls.Add(CreateMiniLabel("TÌM KIẾM HỌC VIÊN"), 2, 0);
        _tblFilter.Controls.Add(new Label(), 3, 0);

        _tblFilter.Controls.Add(cboClassStudentClass, 0, 1);
        _tblFilter.Controls.Add(cboClassStudentContext, 1, 1);
        _tblFilter.Controls.Add(txtClassStudentKeyword, 2, 1);
        _tblFilter.Controls.Add(_flpFilterActions, 3, 1);

        pnlClassStudentFilterCard.Controls.Add(_tblFilter);
    }

    private void BuildKpiRow()
    {
        _tblKpi = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 4,
            RowCount = 1,
            Margin = new Padding(0, 0, 0, 12)
        };

        _kpiCards.Clear();
        _kpiCards.Add(CreateKpiCard("TỔNG SỐ HỌC VIÊN", "24", Color.FromArgb(0, 96, 168)));
        _kpiCards.Add(CreateKpiCard("TỶ LỆ CHUYÊN CẦN", "92.5%", Color.FromArgb(0, 123, 118)));
        _kpiCards.Add(CreateKpiCard("ĐIỂM TRUNG BÌNH LỚP", "7.8/10", Color.FromArgb(186, 127, 28)));
        _kpiCards.Add(CreateKpiCard("TIẾN ĐỘ KHÓA HỌC", "12/32 BUỔI", Color.FromArgb(79, 121, 151)));

        for (var i = 0; i < 4; i++)
        {
            _tblKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            _tblKpi.Controls.Add(_kpiCards[i], i, 0);
        }
        _tblKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 108F));
    }

    private void BuildContentHost()
    {
        splClassStudentContent.Panel1.Controls.Clear();
        splClassStudentContent.Panel2.Controls.Clear();
        splClassStudentContent.Dock = DockStyle.Fill;
        splClassStudentContent.Orientation = Orientation.Horizontal;
        splClassStudentContent.SplitterDistance = 0;
        splClassStudentContent.IsSplitterFixed = true;
        splClassStudentContent.Panel1Collapsed = true;
        splClassStudentContent.Panel2.Controls.Add(dgvClassStudentList);
    }

    private void BuildBottomBar()
    {
        _pnlBottomActions = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        var pager = new FlowLayoutPanel
        {
            Dock = DockStyle.Left,
            Width = 170,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            Padding = new Padding(0, 10, 0, 0)
        };
        pager.Controls.Add(new Label
        {
            AutoSize = true,
            Text = "Trang 1/1",
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(92, 106, 125),
            Margin = new Padding(0, 6, 8, 0)
        });
        pager.Controls.Add(CreatePagerButton("<"));
        pager.Controls.Add(CreatePagerButton(">"));

        _flpBottomActions = new FlowLayoutPanel
        {
            Dock = DockStyle.Right,
            Width = 500,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            Padding = new Padding(0, 8, 0, 0)
        };
        _flpBottomActions.Controls.Add(btnBackToTeachingClasses);
        _flpBottomActions.Controls.Add(btnOpenAttendanceFromStudentList);
        _flpBottomActions.Controls.Add(btnOpenScoreFromStudentList);

        _pnlBottomActions.Controls.Add(_flpBottomActions);
        _pnlBottomActions.Controls.Add(pager);
    }

    private void BindMockData()
    {
        _studentTable.Columns.Clear();
        _studentTable.Rows.Clear();
        _studentTable.Columns.Add("Mã HV");
        _studentTable.Columns.Add("Họ tên");
        _studentTable.Columns.Add("Ngày sinh");
        _studentTable.Columns.Add("Số điện thoại");
        _studentTable.Columns.Add("Trạng thái");
        _studentTable.Columns.Add("Ghi chú");
        _studentTable.Columns.Add("Thao tác");

        _studentTable.Rows.Add("HV-240801", "Nguyễn Văn An", "15/04/2005", "0912 345 678", "ĐANG HỌC", "Kỹ năng Speaking tốt", "◉ ↗");
        _studentTable.Rows.Add("HV-240805", "Lê Thị Mai", "22/11/2004", "0988 123 456", "THỬ THÁCH", "Thường xuyên đi trễ", "◉ ↗");
        _studentTable.Rows.Add("HV-240812", "Trần Minh Hoàng", "05/09/2006", "0345 999 888", "ĐANG HỌC", "-", "◉ ↗");
        _studentTable.Rows.Add("HV-240822", "Phạm Diệu Linh", "30/01/2005", "0909 777 666", "ĐÃ NGHỈ", "Bảo lưu từ tháng trước", "◉ ↗");
        _studentTable.Rows.Add("HV-240825", "Vũ Quốc Trung", "12/12/2004", "0912 888 111", "ĐANG HỌC", "Cần chú ý Writing", "◉ ↗");

        dgvClassStudentList.DataSource = _studentTable;
        ConfigureGrid();
    }

    private void ConfigureGrid()
    {
        if (dgvClassStudentList.Columns.Count == 0)
        {
            return;
        }

        dgvClassStudentList.Columns[0].Width = 130;
        dgvClassStudentList.Columns[1].Width = 220;
        dgvClassStudentList.Columns[2].Width = 120;
        dgvClassStudentList.Columns[3].Width = 140;
        dgvClassStudentList.Columns[4].Width = 120;
        dgvClassStudentList.Columns[5].Width = 240;
        dgvClassStudentList.Columns[6].Width = 80;
        dgvClassStudentList.Columns[6].HeaderText = "...";

        foreach (DataGridViewColumn column in dgvClassStudentList.Columns)
        {
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        foreach (DataGridViewRow row in dgvClassStudentList.Rows)
        {
            if (row.IsNewRow)
            {
                continue;
            }

            row.Cells[0].Style.ForeColor = Color.FromArgb(0, 96, 168);
            row.Cells[0].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            row.Cells[1].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            row.Cells[4].Style.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            row.Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            row.Cells[6].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var status = row.Cells[4].Value?.ToString();
            if (status == "ĐANG HỌC")
            {
                row.Cells[4].Style.BackColor = Color.FromArgb(208, 246, 243);
                row.Cells[4].Style.ForeColor = Color.FromArgb(8, 102, 99);
            }
            else if (status == "THỬ THÁCH")
            {
                row.Cells[4].Style.BackColor = Color.FromArgb(255, 239, 222);
                row.Cells[4].Style.ForeColor = Color.FromArgb(166, 98, 18);
            }
            else
            {
                row.Cells[4].Style.BackColor = Color.FromArgb(255, 230, 230);
                row.Cells[4].Style.ForeColor = Color.FromArgb(201, 61, 61);
            }
        }
    }

    private void ApplyResponsiveLayout()
    {
        if (_tblHeader is null || _tblFilter is null || _tblKpi is null || _flpFilterActions is null || _flpBottomActions is null || _pnlBottomActions is null)
        {
            return;
        }

        var width = ClientSize.Width;
        _tblHeader.ColumnStyles[1].Width = width < 1120 ? 260F : 320F;
        _tblHeader.ColumnStyles[2].Width = width < 1120 ? 220F : 260F;

        if (width < 1260)
        {
            tblClassStudentRoot.RowStyles[1].Height = 144F;
            _tblFilter.RowCount = 3;
            _tblFilter.RowStyles.Clear();
            _tblFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
            _tblFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            _tblFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            _tblFilter.SetColumn(_flpFilterActions, 0);
            _tblFilter.SetRow(_flpFilterActions, 2);
            _tblFilter.SetColumnSpan(_flpFilterActions, 4);
        }
        else
        {
            tblClassStudentRoot.RowStyles[1].Height = 102F;
            _tblFilter.RowCount = 2;
            _tblFilter.RowStyles.Clear();
            _tblFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
            _tblFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            _tblFilter.SetColumn(_flpFilterActions, 3);
            _tblFilter.SetRow(_flpFilterActions, 1);
            _tblFilter.SetColumnSpan(_flpFilterActions, 1);
        }

        _tblKpi.SuspendLayout();
        _tblKpi.ColumnStyles.Clear();
        _tblKpi.RowStyles.Clear();
        if (width < 1060)
        {
            _tblKpi.ColumnCount = 2;
            _tblKpi.RowCount = 2;
            _tblKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _tblKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _tblKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 108F));
            _tblKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 108F));
            SetTablePosition(_tblKpi, _kpiCards[0], 0, 0, new Padding(0, 0, 10, 10));
            SetTablePosition(_tblKpi, _kpiCards[1], 1, 0, new Padding(0, 0, 0, 10));
            SetTablePosition(_tblKpi, _kpiCards[2], 0, 1, new Padding(0, 0, 10, 0));
            SetTablePosition(_tblKpi, _kpiCards[3], 1, 1, Padding.Empty);
        }
        else
        {
            _tblKpi.ColumnCount = 4;
            _tblKpi.RowCount = 1;
            for (var i = 0; i < 4; i++)
            {
                _tblKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }
            _tblKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 108F));
            for (var i = 0; i < _kpiCards.Count; i++)
            {
                SetTablePosition(_tblKpi, _kpiCards[i], i, 0, i < _kpiCards.Count - 1 ? new Padding(0, 0, 12, 0) : Padding.Empty);
            }
        }
        _tblKpi.ResumeLayout(true);

        if (width < 1320)
        {
            tblClassStudentRoot.RowStyles[4].Height = 112F;
            _flpBottomActions.Dock = DockStyle.Fill;
            _flpBottomActions.WrapContents = true;
            _flpBottomActions.Height = 80;
        }
        else
        {
            tblClassStudentRoot.RowStyles[4].Height = 64F;
            _flpBottomActions.Dock = DockStyle.Right;
            _flpBottomActions.WrapContents = false;
            _flpBottomActions.Height = 44;
            _flpBottomActions.Width = 500;
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

    private static Panel CreateKpiCard(string title, string value, Color accent)
    {
        var card = new Panel
        {
            Dock = DockStyle.Fill,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.White,
            Padding = new Padding(16, 12, 16, 12)
        };

        card.Controls.Add(new Label
        {
            Dock = DockStyle.Top,
            Height = 36,
            Text = value,
            Font = new Font("Segoe UI", 15F, FontStyle.Bold),
            ForeColor = accent
        });
        card.Controls.Add(new Label
        {
            Dock = DockStyle.Top,
            Height = 28,
            Text = title,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(93, 109, 128)
        });

        var accentBar = new Panel
        {
            Dock = DockStyle.Left,
            Width = 4,
            BackColor = accent
        };
        card.Controls.Add(accentBar);
        accentBar.BringToFront();
        return card;
    }

    private static Button CreatePagerButton(string text)
    {
        var button = new Button
        {
            Text = text,
            Width = 34,
            Height = 32,
            Margin = new Padding(4, 0, 0, 0),
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            BackColor = Color.White,
            ForeColor = Color.FromArgb(88, 103, 121)
        };
        button.FlatAppearance.BorderColor = Color.FromArgb(207, 219, 234);
        button.FlatAppearance.BorderSize = 1;
        return button;
    }

    private static void ConfigureActionButton(Button button, int width)
    {
        button.Width = width;
        button.Height = 38;
        button.Margin = new Padding(0, 0, 10, 0);
        button.AutoSize = false;
        button.TextAlign = ContentAlignment.MiddleCenter;
    }

    private static void SetTablePosition(TableLayoutPanel table, Control control, int column, int row, Padding margin)
    {
        table.SetColumn(control, column);
        table.SetRow(control, row);
        control.Margin = margin;
    }
}
