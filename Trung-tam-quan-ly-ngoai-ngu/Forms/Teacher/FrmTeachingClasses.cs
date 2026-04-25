using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmTeachingClasses : Form
{
    private readonly DataTable _sourceTable = new();
    private readonly List<Panel> _kpiCards = [];
    private bool _isApplyingResponsiveLayout;
    private TableLayoutPanel? _tblHeader;
    private TableLayoutPanel? _tblKpi;
    private TableLayoutPanel? _tblFilter;
    private FlowLayoutPanel? _flpFilterActions;
    private Panel? _sectionCard;
    private Label? _lblFooterSummary;
    private FlowLayoutPanel? _flpFooterPager;
    private ComboBox? _cboCourseFilter;
    private Label? _lblSectionViewAll;

    public FrmTeachingClasses()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Lớp đang dạy");
        ConfigureView();
        BindMockData();
        Resize += (_, _) => ApplyResponsiveLayout();
        ApplyResponsiveLayout();
    }

    private void ConfigureView()
    {
        BackColor = Color.FromArgb(239, 248, 255);
        Padding = new Padding(12);

        txtTeachingClassKeyword.PlaceholderText = "Nhập mã hoặc tên lớp...";
        cboTeachingStatusFilter.Items.Clear();
        cboTeachingStatusFilter.Items.AddRange(["Đang dạy", "Sắp kết thúc", "Hoàn thành"]);
        cboTeachingStatusFilter.SelectedIndex = 0;

        AppTheme.StylePrimaryButton(btnSearchTeachingClass);
        AppTheme.StyleSecondaryButton(btnRefreshTeachingClass);
        AppTheme.StyleSecondaryButton(btnOpenClassStudentList);
        AppTheme.StyleSecondaryButton(btnOpenAttendance);
        AppTheme.StyleSecondaryButton(btnOpenScoreEntry);

        btnSearchTeachingClass.Text = "LỌC DỮ LIỆU";
        btnRefreshTeachingClass.Text = "LÀM MỚI";
        btnOpenClassStudentList.Text = "DS HỌC VIÊN";
        btnOpenAttendance.Text = "ĐIỂM DANH";
        btnOpenScoreEntry.Text = "NHẬP ĐIỂM";

        ConfigureActionButton(btnSearchTeachingClass, 118);
        ConfigureActionButton(btnRefreshTeachingClass, 112);
        ConfigureActionButton(btnOpenClassStudentList, 148);
        ConfigureActionButton(btnOpenAttendance, 154);
        ConfigureActionButton(btnOpenScoreEntry, 154);

        AppTheme.StyleGrid(dgvTeachingClassList);
        dgvTeachingClassList.Dock = DockStyle.Fill;
        dgvTeachingClassList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgvTeachingClassList.ScrollBars = ScrollBars.Both;
        dgvTeachingClassList.ColumnHeadersHeight = 46;
        dgvTeachingClassList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
        dgvTeachingClassList.RowTemplate.Height = 64;
        dgvTeachingClassList.DefaultCellStyle.Padding = new Padding(8, 6, 8, 6);
        dgvTeachingClassList.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 251, 255);

        BuildRuntimeLayout();
    }

    private void BuildRuntimeLayout()
    {
        tblTeachingClassRoot.SuspendLayout();
        tblTeachingClassRoot.Controls.Clear();
        tblTeachingClassRoot.Dock = DockStyle.Top;
        tblTeachingClassRoot.AutoSize = true;
        tblTeachingClassRoot.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        tblTeachingClassRoot.MinimumSize = new Size(0, 760);
        tblTeachingClassRoot.ColumnCount = 1;
        tblTeachingClassRoot.RowCount = 4;
        tblTeachingClassRoot.RowStyles.Clear();
        tblTeachingClassRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
        tblTeachingClassRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 148F));
        tblTeachingClassRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 148F));
        tblTeachingClassRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        BuildHeader();
        BuildKpiRow();
        BuildFilterCard();
        BuildSectionCard();

        tblTeachingClassRoot.Controls.Add(_tblHeader!, 0, 0);
        tblTeachingClassRoot.Controls.Add(_tblKpi!, 0, 1);
        tblTeachingClassRoot.Controls.Add(pnlTeachingClassFilterCard, 0, 2);
        tblTeachingClassRoot.Controls.Add(_sectionCard!, 0, 3);
        tblTeachingClassRoot.ResumeLayout(true);
    }

    private void BuildHeader()
    {
        _tblHeader = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            Margin = new Padding(0, 0, 0, 16)
        };
        _tblHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _tblHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280F));

        var titlePanel = new Panel { Dock = DockStyle.Fill };
        titlePanel.Controls.Add(new Label
        {
            Dock = DockStyle.Top,
            Height = 28,
            Text = "Theo dõi lớp phụ trách và truy cập nhanh đến điểm danh, nhập điểm",
            Font = new Font("Segoe UI", 9.5F),
            ForeColor = Color.FromArgb(104, 118, 137)
        });
        titlePanel.Controls.Add(new Label
        {
            Dock = DockStyle.Top,
            Height = 44,
            Text = "LỚP ĐANG DẠY",
            Font = new Font("Segoe UI", 18F, FontStyle.Bold),
            ForeColor = Color.FromArgb(19, 39, 60)
        });

        var alertCard = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(153, 91, 13),
            Padding = new Padding(16, 12, 16, 12)
        };
        alertCard.Controls.Add(new Label
        {
            Dock = DockStyle.Fill,
            Text = "THÔNG BÁO MỚI" + Environment.NewLine + "3 lịch thi cuối khóa cần cập nhật điểm.",
            Font = new Font("Segoe UI", 8.75F, FontStyle.Bold),
            ForeColor = Color.White
        });

        _tblHeader.Controls.Add(titlePanel, 0, 0);
        _tblHeader.Controls.Add(alertCard, 1, 0);
    }

    private void BuildKpiRow()
    {
        _tblKpi = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 4,
            RowCount = 1,
            Margin = new Padding(0, 0, 0, 16)
        };

        _kpiCards.Clear();
        _kpiCards.Add(CreateKpiCard("TỔNG SỐ LỚP", "08", "Lớp phụ trách", Color.FromArgb(155, 102, 26)));
        _kpiCards.Add(CreateKpiCard("TỔNG HỌC VIÊN", "142", "Học viên hoạt động", Color.FromArgb(0, 123, 118)));
        _kpiCards.Add(CreateKpiCard("GIỜ DẠY TUẦN NÀY", "24h", "Tính đến hôm nay", Color.FromArgb(0, 96, 168)));
        _kpiCards.Add(CreateKpiCard("THÔNG BÁO MỚI", "03", "Cần xử lý", Color.FromArgb(153, 91, 13)));

        for (var i = 0; i < 4; i++)
        {
            _tblKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            _tblKpi.Controls.Add(_kpiCards[i], i, 0);
        }
        _tblKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 118F));
    }

    private void BuildFilterCard()
    {
        pnlTeachingClassFilterCard.Controls.Clear();
        pnlTeachingClassFilterCard.Padding = new Padding(18, 14, 18, 14);
        pnlTeachingClassFilterCard.BackColor = Color.FromArgb(227, 243, 254);
        pnlTeachingClassFilterCard.BorderStyle = BorderStyle.None;

        _tblFilter = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 4,
            RowCount = 3
        };
        _tblFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
        _tblFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
        _tblFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
        _tblFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        _tblFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        _tblFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
        _tblFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));

        _cboCourseFilter = new ComboBox
        {
            Dock = DockStyle.Fill,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        _cboCourseFilter.Items.AddRange(["Tất cả khóa học", "IELTS Intensive", "Business Pro", "Young Learners", "Communication"]);
        _cboCourseFilter.SelectedIndex = 0;

        txtTeachingClassKeyword.Dock = DockStyle.Fill;
        cboTeachingStatusFilter.Dock = DockStyle.Fill;

        _flpFilterActions = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = true,
            Margin = Padding.Empty,
            Padding = new Padding(0, 4, 0, 0),
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink
        };
        _flpFilterActions.Controls.Add(btnSearchTeachingClass);
        _flpFilterActions.Controls.Add(btnRefreshTeachingClass);
        _flpFilterActions.Controls.Add(btnOpenClassStudentList);
        _flpFilterActions.Controls.Add(btnOpenAttendance);
        _flpFilterActions.Controls.Add(btnOpenScoreEntry);

        _tblFilter.Controls.Add(CreateFilterLabel("TÌM KIẾM / CHỌN LỚP"), 0, 0);
        _tblFilter.Controls.Add(CreateFilterLabel("TRẠNG THÁI"), 1, 0);
        _tblFilter.Controls.Add(CreateFilterLabel("KHÓA HỌC"), 2, 0);
        _tblFilter.Controls.Add(new Label(), 3, 0);

        _tblFilter.Controls.Add(txtTeachingClassKeyword, 0, 1);
        _tblFilter.Controls.Add(cboTeachingStatusFilter, 1, 1);
        _tblFilter.Controls.Add(_cboCourseFilter, 2, 1);
        _tblFilter.Controls.Add(_flpFilterActions, 0, 2);
        _tblFilter.SetColumnSpan(_flpFilterActions, 4);

        pnlTeachingClassFilterCard.Controls.Add(_tblFilter);
    }

    private void BuildSectionCard()
    {
        _sectionCard = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            MinimumSize = new Size(0, 320)
        };

        var root = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3
        };
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));

        var header = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.FromArgb(225, 242, 254),
            Padding = new Padding(16, 0, 16, 0)
        };
        _lblSectionViewAll = new Label
        {
            Dock = DockStyle.Right,
            Width = 188,
            Text = "XEM TẤT CẢ",
            TextAlign = ContentAlignment.MiddleRight,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(0, 96, 168)
        };
        header.Controls.Add(_lblSectionViewAll);
        header.Controls.Add(new Label
        {
            Dock = DockStyle.Left,
            Width = 280,
            Text = "DANH SÁCH LỚP PHỤ TRÁCH",
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 11F, FontStyle.Bold),
            ForeColor = Color.FromArgb(17, 40, 62)
        });

        var footer = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2
        };
        footer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        footer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));

        _lblFooterSummary = new Label
        {
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            ForeColor = Color.FromArgb(95, 108, 126),
            Padding = new Padding(16, 0, 0, 0)
        };

        _flpFooterPager = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            Padding = new Padding(0, 6, 0, 0)
        };
        _flpFooterPager.Controls.Add(CreatePagerButton("<", false));
        _flpFooterPager.Controls.Add(CreatePagerButton("1", true));
        _flpFooterPager.Controls.Add(CreatePagerButton("2", false));
        _flpFooterPager.Controls.Add(CreatePagerButton(">", false));

        footer.Controls.Add(_lblFooterSummary, 0, 0);
        footer.Controls.Add(_flpFooterPager, 1, 0);

        root.Controls.Add(header, 0, 0);
        root.Controls.Add(dgvTeachingClassList, 0, 1);
        root.Controls.Add(footer, 0, 2);
        dgvTeachingClassList.MinimumSize = new Size(0, 220);
        _sectionCard.Controls.Add(root);
    }

    private void BindMockData()
    {
        _sourceTable.Columns.Clear();
        _sourceTable.Rows.Clear();
        _sourceTable.Columns.Add("Mã lớp");
        _sourceTable.Columns.Add("Tên lớp");
        _sourceTable.Columns.Add("Khóa học");
        _sourceTable.Columns.Add("Lịch học");
        _sourceTable.Columns.Add("Sĩ số");
        _sourceTable.Columns.Add("Trạng thái");
        _sourceTable.Columns.Add("Thao tác");

        _sourceTable.Rows.Add("IELTS-24A-01", "IELTS Breakthrough 6.5+\nPhòng LAB-402", "IELTS Intensive", "Thứ 2, 4, 6\n18:00 - 20:30", "18/20", "ĐANG DẠY", "👤  📋");
        _sourceTable.Rows.Add("BE-F2-112", "Business English Foundation\nPhòng A-101", "Business Pro", "Thứ 3, 5\n18:30 - 21:00", "12/15", "ĐANG DẠY", "👤  📋");
        _sourceTable.Rows.Add("KIDS-A1-09", "Phonics & Fun Stage 1\nPhòng Zoom", "Young Learners", "Thứ 7, CN\n08:00 - 09:30", "10/10", "SẮP KẾT THÚC", "👤  📋");
        _sourceTable.Rows.Add("COM-U-405", "Upper Communication\nPhòng B-205", "Communication", "Thứ 3, 5\n18:00 - 19:30", "14/20", "ĐANG DẠY", "👤  📋");

        dgvTeachingClassList.DataSource = _sourceTable;
        ConfigureGrid();
        if (_lblFooterSummary is not null)
        {
            _lblFooterSummary.Text = "HIỂN THỊ 1 - 4 CỦA 8 LỚP";
        }
    }

    private void ConfigureGrid()
    {
        if (dgvTeachingClassList.Columns.Count == 0)
        {
            return;
        }

        var availableWidth = Math.Max(0, dgvTeachingClassList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 24);
        const int baseWidth0 = 130;
        const int baseWidth1 = 240;
        const int baseWidth2 = 170;
        const int baseWidth3 = 190;
        const int baseWidth4 = 90;
        const int baseWidth5 = 130;
        const int baseWidth6 = 70;
        var baseTotal = baseWidth0 + baseWidth1 + baseWidth2 + baseWidth3 + baseWidth4 + baseWidth5 + baseWidth6;
        var useFill = availableWidth >= baseTotal + 40;

        if (useFill)
        {
            dgvTeachingClassList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTeachingClassList.Columns[0].FillWeight = 11F;
            dgvTeachingClassList.Columns[1].FillWeight = 24F;
            dgvTeachingClassList.Columns[2].FillWeight = 17F;
            dgvTeachingClassList.Columns[3].FillWeight = 20F;
            dgvTeachingClassList.Columns[4].FillWeight = 9F;
            dgvTeachingClassList.Columns[5].FillWeight = 13F;
            dgvTeachingClassList.Columns[6].FillWeight = 6F;
        }
        else
        {
            dgvTeachingClassList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvTeachingClassList.Columns[0].Width = baseWidth0;
            dgvTeachingClassList.Columns[1].Width = baseWidth1;
            dgvTeachingClassList.Columns[2].Width = baseWidth2;
            dgvTeachingClassList.Columns[3].Width = baseWidth3;
            dgvTeachingClassList.Columns[4].Width = baseWidth4;
        dgvTeachingClassList.Columns[5].Width = baseWidth5;
        dgvTeachingClassList.Columns[6].Width = baseWidth6;
        }
        dgvTeachingClassList.Columns[6].HeaderText = "...";
        dgvTeachingClassList.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        dgvTeachingClassList.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        dgvTeachingClassList.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        dgvTeachingClassList.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        dgvTeachingClassList.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        dgvTeachingClassList.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        dgvTeachingClassList.Columns[6].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        dgvTeachingClassList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dgvTeachingClassList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        foreach (DataGridViewColumn column in dgvTeachingClassList.Columns)
        {
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        foreach (DataGridViewRow row in dgvTeachingClassList.Rows)
        {
            if (row.IsNewRow)
            {
                continue;
            }

            row.Cells[0].Style.ForeColor = Color.FromArgb(0, 96, 168);
            row.Cells[0].Style.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
            row.Cells[1].Style.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
            row.Cells[5].Style.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            row.Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            row.Cells[6].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var status = row.Cells[5].Value?.ToString();
            if (status == "ĐANG DẠY")
            {
                row.Cells[5].Style.BackColor = Color.FromArgb(208, 246, 243);
                row.Cells[5].Style.ForeColor = Color.FromArgb(8, 102, 99);
            }
            else
            {
                row.Cells[5].Style.BackColor = Color.FromArgb(255, 239, 222);
                row.Cells[5].Style.ForeColor = Color.FromArgb(166, 98, 18);
                row.Cells[4].Style.ForeColor = Color.FromArgb(207, 58, 58);
                row.Cells[4].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }
    }

    private void ApplyResponsiveLayout()
    {
        if (_isApplyingResponsiveLayout)
        {
            return;
        }

        _isApplyingResponsiveLayout = true;
        try
        {
            var width = ClientSize.Width;

            if (_tblHeader is not null)
            {
                _tblHeader.ColumnStyles[1].Width = width < 1120 ? 220F : 280F;
            }

            if (_tblFilter is not null && _flpFilterActions is not null)
            {
                var wrapActions = width < 1220;
                var compactActions = width < 1040;
                tblTeachingClassRoot.RowStyles[2].Height = compactActions ? 166F : 124F;
                _tblFilter.RowCount = 3;
                _tblFilter.RowStyles.Clear();
                _tblFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
                _tblFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
                _tblFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, compactActions ? 72F : 48F));
                _tblFilter.SetColumn(_flpFilterActions, 0);
                _tblFilter.SetRow(_flpFilterActions, 2);
                _tblFilter.SetColumnSpan(_flpFilterActions, 4);
                _flpFilterActions.WrapContents = wrapActions;
                _flpFilterActions.Height = compactActions ? 76 : 48;
            }

            if (_tblKpi is not null)
            {
                _tblKpi.SuspendLayout();
                _tblKpi.ColumnStyles.Clear();
                _tblKpi.RowStyles.Clear();
                if (width < 980)
                {
                    tblTeachingClassRoot.RowStyles[1].Height = 264F;
                    _tblKpi.ColumnCount = 2;
                    _tblKpi.RowCount = 2;
                    _tblKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                    _tblKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                    _tblKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 124F));
                    _tblKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 124F));
                    SetTablePosition(_tblKpi, _kpiCards[0], 0, 0, new Padding(0, 0, 10, 10));
                    SetTablePosition(_tblKpi, _kpiCards[1], 1, 0, new Padding(0, 0, 0, 10));
                    SetTablePosition(_tblKpi, _kpiCards[2], 0, 1, new Padding(0, 0, 10, 0));
                    SetTablePosition(_tblKpi, _kpiCards[3], 1, 1, Padding.Empty);
                }
                else
                {
                    tblTeachingClassRoot.RowStyles[1].Height = 148F;
                    _tblKpi.ColumnCount = 4;
                    _tblKpi.RowCount = 1;
                    for (var i = 0; i < 4; i++)
                    {
                        _tblKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                    }
                    _tblKpi.RowStyles.Add(new RowStyle(SizeType.Absolute, 136F));
                    for (var i = 0; i < _kpiCards.Count; i++)
                    {
                        SetTablePosition(_tblKpi, _kpiCards[i], i, 0, i < _kpiCards.Count - 1 ? new Padding(0, 0, 12, 0) : Padding.Empty);
                    }
                }
                _tblKpi.ResumeLayout(true);
            }

            if (_lblSectionViewAll is not null)
            {
                _lblSectionViewAll.Width = width < 1200 ? 208 : 188;
            }

            ConfigureGrid();
        }
        finally
        {
            _isApplyingResponsiveLayout = false;
        }
    }

    private static Panel CreateKpiCard(string title, string value, string hint, Color accent)
    {
        var card = new Panel
        {
            Dock = DockStyle.Fill,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.White,
            Padding = new Padding(18, 14, 18, 14)
        };

        var accentBar = new Panel
        {
            Dock = DockStyle.Left,
            Width = 4,
            BackColor = accent
        };

        var body = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(14, 0, 0, 0)
        };
        body.Controls.Add(new Label
        {
            Dock = DockStyle.Top,
            Height = 28,
            Text = hint,
            Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
            ForeColor = Color.FromArgb(108, 121, 140)
        });
        body.Controls.Add(new Label
        {
            Dock = DockStyle.Top,
            Height = 44,
            Text = value,
            Font = new Font("Segoe UI", 20F, FontStyle.Bold),
            ForeColor = accent
        });
        body.Controls.Add(new Label
        {
            Dock = DockStyle.Top,
            Height = 34,
            Text = title,
            Font = new Font("Segoe UI", 8.75F, FontStyle.Bold),
            ForeColor = Color.FromArgb(77, 91, 110)
        });

        card.Controls.Add(body);
        card.Controls.Add(accentBar);
        return card;
    }

    private static Label CreateFilterLabel(string text)
    {
        return new Label
        {
            Dock = DockStyle.Fill,
            Text = text,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(91, 107, 128),
            TextAlign = ContentAlignment.BottomLeft
        };
    }

    private static Button CreatePagerButton(string text, bool active)
    {
        var button = new Button
        {
            Text = text,
            Width = 34,
            Height = 32,
            Margin = new Padding(4, 0, 0, 0),
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
        };

        if (active)
        {
            button.BackColor = Color.FromArgb(0, 74, 132);
            button.ForeColor = Color.White;
            button.FlatAppearance.BorderSize = 0;
        }
        else
        {
            button.BackColor = Color.White;
            button.ForeColor = Color.FromArgb(89, 104, 122);
            button.FlatAppearance.BorderColor = Color.FromArgb(207, 219, 234);
            button.FlatAppearance.BorderSize = 1;
        }

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
