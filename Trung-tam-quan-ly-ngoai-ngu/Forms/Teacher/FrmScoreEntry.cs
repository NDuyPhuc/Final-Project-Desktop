using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmScoreEntry : Form
{
    private readonly DataTable _scoreTable = new();
    private Label? _lblScoreClass;
    private Label? _lblScoreType;
    private Label? _lblScoreWeight;
    private Panel? _pnlBottomBar;
    private TableLayoutPanel? _tblTopFilter;
    private FlowLayoutPanel? _flpScoreLegend;
    private FlowLayoutPanel? _flpScoreActions;

    public FrmScoreEntry()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Nhập điểm");
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

        cboScoreClass.Items.Clear();
        cboScoreClass.Items.AddRange(["IELTS Foundation - IF.2310.10", "TOEIC A2 - TC.2204.02", "Business English - BE.2010.02"]);
        cboScoreClass.SelectedIndex = 0;

        cboScoreType.Items.Clear();
        cboScoreType.Items.AddRange(["Final Exam", "Midterm", "Listening Quiz", "Speaking Assessment"]);
        cboScoreType.SelectedIndex = 0;
        txtScoreWeight.Text = "2";

        AppTheme.StylePrimaryButton(btnLoadScoreList);
        btnLoadScoreList.Text = "TẢI DANH SÁCH";
        btnLoadScoreList.Height = 38;
        AppTheme.StylePrimaryButton(btnSaveScore);
        btnSaveScore.Text = "LƯU BẢNG ĐIỂM";
        btnSaveScore.Width = 154;
        btnSaveScore.Height = 38;

        AppTheme.StyleGrid(dgvScoreList);
        dgvScoreList.Dock = DockStyle.Fill;
        dgvScoreList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgvScoreList.ScrollBars = ScrollBars.Both;
        dgvScoreList.ColumnHeadersHeight = 46;
        dgvScoreList.RowTemplate.Height = 44;
        dgvScoreList.DefaultCellStyle.Padding = new Padding(6, 4, 6, 4);

        BuildLayout();
    }

    private void BuildLayout()
    {
        tblScoreRoot.SuspendLayout();
        tblScoreRoot.Controls.Clear();
        tblScoreRoot.ColumnCount = 1;
        tblScoreRoot.RowCount = 4;
        tblScoreRoot.RowStyles.Clear();
        tblScoreRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
        tblScoreRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 88F));
        tblScoreRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblScoreRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));

        var title = new Label
        {
            Dock = DockStyle.Fill,
            Text = "NHẬP ĐIỂM",
            Font = new Font("Segoe UI", 18F, FontStyle.Bold),
            ForeColor = Color.FromArgb(19, 39, 60),
            TextAlign = ContentAlignment.MiddleLeft
        };

        BuildFilterCard();
        BuildBottomBar();

        tblScoreRoot.Controls.Add(title, 0, 0);
        tblScoreRoot.Controls.Add(pnlScoreFilterCard, 0, 1);
        tblScoreRoot.Controls.Add(dgvScoreList, 0, 2);
        tblScoreRoot.Controls.Add(_pnlBottomBar!, 0, 3);
        tblScoreRoot.ResumeLayout(true);
    }

    private void BuildFilterCard()
    {
        pnlScoreFilterCard.Controls.Clear();
        pnlScoreFilterCard.BorderStyle = BorderStyle.None;
        pnlScoreFilterCard.BackColor = Color.White;
        pnlScoreFilterCard.Padding = new Padding(16, 12, 16, 12);

        _tblTopFilter = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 4,
            RowCount = 2
        };
        _tblTopFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
        _tblTopFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26F));
        _tblTopFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
        _tblTopFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
        _tblTopFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
        _tblTopFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));

        _lblScoreClass = CreateMiniLabel("CHỌN LỚP HỌC");
        _lblScoreType = CreateMiniLabel("LOẠI ĐIỂM");
        _lblScoreWeight = CreateMiniLabel("HỆ SỐ");

        cboScoreClass.Dock = DockStyle.Fill;
        cboScoreType.Dock = DockStyle.Fill;
        txtScoreWeight.Dock = DockStyle.Fill;
        btnLoadScoreList.Dock = DockStyle.Fill;

        _tblTopFilter.Controls.Add(_lblScoreClass, 0, 0);
        _tblTopFilter.Controls.Add(_lblScoreType, 1, 0);
        _tblTopFilter.Controls.Add(_lblScoreWeight, 2, 0);
        _tblTopFilter.Controls.Add(new Label(), 3, 0);
        _tblTopFilter.Controls.Add(cboScoreClass, 0, 1);
        _tblTopFilter.Controls.Add(cboScoreType, 1, 1);
        _tblTopFilter.Controls.Add(txtScoreWeight, 2, 1);
        _tblTopFilter.Controls.Add(btnLoadScoreList, 3, 1);

        pnlScoreFilterCard.Controls.Add(_tblTopFilter);
    }

    private void BuildBottomBar()
    {
        _pnlBottomBar = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent
        };

        _flpScoreLegend = new FlowLayoutPanel
        {
            Dock = DockStyle.Left,
            Width = 460,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            Padding = new Padding(0, 20, 0, 0)
        };
        _flpScoreLegend.Controls.Add(CreateLegend("XUẤT SẮC (8.5+)", Color.FromArgb(255, 225, 201)));
        _flpScoreLegend.Controls.Add(CreateLegend("GIỎI (7.5 - 8.4)", Color.FromArgb(208, 246, 243)));
        _flpScoreLegend.Controls.Add(CreateLegend("KHÁ (6.5 - 7.4)", Color.FromArgb(225, 242, 254)));

        _flpScoreActions = new FlowLayoutPanel
        {
            Dock = DockStyle.Right,
            Width = 560,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            Padding = new Padding(0, 8, 0, 0)
        };

        var btnExport = new Button
        {
            Text = "XUẤT BÁO CÁO",
            Width = 154,
            Height = 38,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            BackColor = Color.White,
            ForeColor = Color.FromArgb(63, 76, 93)
        };
        btnExport.FlatAppearance.BorderColor = Color.FromArgb(208, 219, 233);
        btnExport.FlatAppearance.BorderSize = 1;

        var summaryCard = new Panel
        {
            Width = 220,
            Height = 72,
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(14, 10, 14, 10),
            Margin = new Padding(12, 0, 0, 0)
        };
        summaryCard.Controls.Add(new Label
        {
            Dock = DockStyle.Top,
            Height = 28,
            Text = "24 HỌC VIÊN",
            Font = new Font("Segoe UI", 14F, FontStyle.Bold),
            ForeColor = Color.FromArgb(0, 96, 168),
            TextAlign = ContentAlignment.MiddleRight
        });
        summaryCard.Controls.Add(new Label
        {
            Dock = DockStyle.Top,
            Height = 22,
            Text = "Đã nhập: 05/24",
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(91, 107, 125),
            TextAlign = ContentAlignment.MiddleRight
        });

        _flpScoreActions.Controls.Add(btnExport);
        _flpScoreActions.Controls.Add(btnSaveScore);
        _flpScoreActions.Controls.Add(summaryCard);

        _pnlBottomBar.Controls.Add(_flpScoreActions);
        _pnlBottomBar.Controls.Add(_flpScoreLegend);
    }

    private void BindMockData()
    {
        _scoreTable.Columns.Clear();
        _scoreTable.Rows.Clear();
        _scoreTable.Columns.Add("STT");
        _scoreTable.Columns.Add("Mã học viên");
        _scoreTable.Columns.Add("Họ và tên");
        _scoreTable.Columns.Add("Điểm số");
        _scoreTable.Columns.Add("Xếp loại");
        _scoreTable.Columns.Add("Ghi chú");

        _scoreTable.Rows.Add("01", "HV2310045", "Lê Hoàng Nam", "8.5", "GIỎI", "Tiến bộ vượt bậc phần Writing");
        _scoreTable.Rows.Add("02", "HV2310112", "Nguyễn Thị Mai Chi", "7.0", "KHÁ", "Cần tập trung Listening");
        _scoreTable.Rows.Add("03", "HV2310156", "Trần Minh Quân", "4.5", "YẾU", "Vắng nhiều buổi ôn tập");
        _scoreTable.Rows.Add("04", "HV2310221", "Phạm Bảo Ngọc", "9.5", "XUẤT SẮC", "Excellent Performance");
        _scoreTable.Rows.Add("05", "HV2310333", "Đặng Lê Kim", "6.5", "TB KHÁ", "");

        dgvScoreList.DataSource = _scoreTable;
        ConfigureGrid();
    }

    private void ConfigureGrid()
    {
        if (dgvScoreList.Columns.Count == 0)
        {
            return;
        }

        dgvScoreList.Columns[0].Width = 80;
        dgvScoreList.Columns[1].Width = 170;
        dgvScoreList.Columns[2].Width = 240;
        dgvScoreList.Columns[3].Width = 110;
        dgvScoreList.Columns[4].Width = 130;
        dgvScoreList.Columns[5].Width = 280;

        foreach (DataGridViewColumn column in dgvScoreList.Columns)
        {
            column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        foreach (DataGridViewRow row in dgvScoreList.Rows)
        {
            if (row.IsNewRow)
            {
                continue;
            }

            row.Cells[1].Style.ForeColor = Color.FromArgb(0, 96, 168);
            row.Cells[1].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            row.Cells[2].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            row.Cells[3].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            row.Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            row.Cells[4].Style.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            row.Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var rank = row.Cells[4].Value?.ToString();
            switch (rank)
            {
                case "XUẤT SẮC":
                    row.Cells[4].Style.BackColor = Color.FromArgb(255, 225, 201);
                    row.Cells[4].Style.ForeColor = Color.FromArgb(161, 96, 16);
                    break;
                case "GIỎI":
                    row.Cells[4].Style.BackColor = Color.FromArgb(208, 246, 243);
                    row.Cells[4].Style.ForeColor = Color.FromArgb(8, 102, 99);
                    break;
                case "KHÁ":
                case "TB KHÁ":
                    row.Cells[4].Style.BackColor = Color.FromArgb(225, 242, 254);
                    row.Cells[4].Style.ForeColor = Color.FromArgb(84, 105, 128);
                    break;
                default:
                    row.Cells[4].Style.BackColor = Color.FromArgb(255, 231, 231);
                    row.Cells[4].Style.ForeColor = Color.FromArgb(201, 61, 61);
                    break;
            }

            if (double.TryParse(row.Cells[3].Value?.ToString(), out var score) && score < 5)
            {
                row.Cells[3].Style.ForeColor = Color.FromArgb(201, 61, 61);
            }
            else
            {
                row.Cells[3].Style.ForeColor = Color.FromArgb(0, 96, 168);
            }
        }
    }

    private void WireEvents()
    {
        btnLoadScoreList.Click += (_, _) => dgvScoreList.DataSource = _scoreTable;
        btnSaveScore.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Lưu điểm", "UI demo đã cập nhật bảng nhập điểm trong phiên hiện tại.");
            dialog.ShowDialog(this);
        };
    }

    private void ApplyResponsiveLayout()
    {
        if (_tblTopFilter is null || _lblScoreClass is null || _lblScoreType is null || _lblScoreWeight is null || _flpScoreLegend is null || _flpScoreActions is null)
        {
            return;
        }

        var width = ClientSize.Width;
        if (width < 980)
        {
            _tblTopFilter.ColumnCount = 2;
            _tblTopFilter.RowCount = 4;
            _tblTopFilter.ColumnStyles.Clear();
            _tblTopFilter.RowStyles.Clear();
            _tblTopFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            _tblTopFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            _tblTopFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
            _tblTopFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            _tblTopFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
            _tblTopFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));

            _tblTopFilter.SetColumn(_lblScoreClass, 0);
            _tblTopFilter.SetRow(_lblScoreClass, 0);
            _tblTopFilter.SetColumn(_lblScoreType, 1);
            _tblTopFilter.SetRow(_lblScoreType, 0);
            _tblTopFilter.SetColumn(cboScoreClass, 0);
            _tblTopFilter.SetRow(cboScoreClass, 1);
            _tblTopFilter.SetColumn(cboScoreType, 1);
            _tblTopFilter.SetRow(cboScoreType, 1);
            _tblTopFilter.SetColumn(_lblScoreWeight, 0);
            _tblTopFilter.SetRow(_lblScoreWeight, 2);
            _tblTopFilter.SetColumn(txtScoreWeight, 0);
            _tblTopFilter.SetRow(txtScoreWeight, 3);
            _tblTopFilter.SetColumn(btnLoadScoreList, 1);
            _tblTopFilter.SetRow(btnLoadScoreList, 3);
        }
        else
        {
            _tblTopFilter.ColumnCount = 4;
            _tblTopFilter.RowCount = 2;
            _tblTopFilter.ColumnStyles.Clear();
            _tblTopFilter.RowStyles.Clear();
            _tblTopFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
            _tblTopFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26F));
            _tblTopFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14F));
            _tblTopFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            _tblTopFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
            _tblTopFilter.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));

            _tblTopFilter.SetColumn(_lblScoreClass, 0);
            _tblTopFilter.SetRow(_lblScoreClass, 0);
            _tblTopFilter.SetColumn(_lblScoreType, 1);
            _tblTopFilter.SetRow(_lblScoreType, 0);
            _tblTopFilter.SetColumn(_lblScoreWeight, 2);
            _tblTopFilter.SetRow(_lblScoreWeight, 0);
            _tblTopFilter.SetColumn(cboScoreClass, 0);
            _tblTopFilter.SetRow(cboScoreClass, 1);
            _tblTopFilter.SetColumn(cboScoreType, 1);
            _tblTopFilter.SetRow(cboScoreType, 1);
            _tblTopFilter.SetColumn(txtScoreWeight, 2);
            _tblTopFilter.SetRow(txtScoreWeight, 1);
            _tblTopFilter.SetColumn(btnLoadScoreList, 3);
            _tblTopFilter.SetRow(btnLoadScoreList, 1);
        }

        if (width < 1180)
        {
            tblScoreRoot.RowStyles[3].Height = 166F;
            _flpScoreLegend.Dock = DockStyle.Top;
            _flpScoreLegend.WrapContents = true;
            _flpScoreLegend.Height = 62;
            _flpScoreLegend.Width = 0;
            _flpScoreLegend.Padding = new Padding(0, 8, 0, 0);

            _flpScoreActions.Dock = DockStyle.Top;
            _flpScoreActions.WrapContents = true;
            _flpScoreActions.Height = 96;
            _flpScoreActions.Width = 0;
            _flpScoreActions.Padding = new Padding(0, 8, 0, 0);
        }
        else
        {
            tblScoreRoot.RowStyles[3].Height = 100F;
            _flpScoreLegend.Dock = DockStyle.Left;
            _flpScoreLegend.WrapContents = false;
            _flpScoreLegend.Width = 460;
            _flpScoreLegend.Height = 0;
            _flpScoreLegend.Padding = new Padding(0, 20, 0, 0);

            _flpScoreActions.Dock = DockStyle.Right;
            _flpScoreActions.WrapContents = false;
            _flpScoreActions.Width = 560;
            _flpScoreActions.Height = 0;
            _flpScoreActions.Padding = new Padding(0, 8, 0, 0);
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

    private static Panel CreateLegend(string text, Color color)
    {
        var host = new Panel
        {
            Width = 144,
            Height = 22,
            Margin = new Padding(0, 0, 12, 0)
        };

        var swatch = new Panel
        {
            Width = 8,
            Height = 8,
            BackColor = color,
            Location = new Point(0, 7)
        };
        var label = new Label
        {
            AutoSize = false,
            Location = new Point(14, 0),
            Size = new Size(126, 22),
            Text = text,
            Font = new Font("Segoe UI", 7.75F, FontStyle.Bold),
            ForeColor = Color.FromArgb(93, 108, 126)
        };

        host.Controls.Add(label);
        host.Controls.Add(swatch);
        return host;
    }
}
