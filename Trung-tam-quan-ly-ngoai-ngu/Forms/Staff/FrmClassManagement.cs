using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmClassManagement : Form
{
    private DataTable _classTable = new();

    public FrmClassManagement()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Quản lý lớp học");
        ConfigureView();
        BindMockData();
        WireEvents();
        ApplyResponsiveLayout();
    }

    private void ConfigureView()
    {
        BuildFilterLayout();
        LocalizeLabels();

        cboClassStatusFilter.SelectedIndex = 0;
        cboClassDetailStatus.SelectedIndex = 0;
        dtpClassStartDate.Value = DateTime.Today;
        dtpClassEndDate.Value = DateTime.Today.AddMonths(3);

        AppTheme.StyleGrid(dgvClassList);
        AppTheme.StyleGrid(dgvClassStudentList);
        AppTheme.StyleGrid(dgvClassSessionList);
        AppTheme.StyleSecondaryButton(btnSearchClass);
        AppTheme.StyleSecondaryButton(btnRefreshClass);
        AppTheme.StylePrimaryButton(btnCreateClass);
        AppTheme.StylePrimaryButton(btnSaveClass);
        AppTheme.StyleSecondaryButton(btnUpdateClass);
        AppTheme.StyleSecondaryButton(btnGenerateSessions);
        AppTheme.StyleSecondaryButton(btnOpenEnrollmentFromClass);

        dgvClassList.RowTemplate.Height = 42;
        dgvClassStudentList.RowTemplate.Height = 40;
        dgvClassSessionList.RowTemplate.Height = 40;

        splClassContent.Panel1MinSize = 320;
        splClassContent.Panel2MinSize = 380;
        splClassContent.FixedPanel = FixedPanel.None;

        if (tblClassInfo.ColumnStyles.Count > 0)
        {
            tblClassInfo.ColumnStyles[0].Width = 146F;
        }
        tblClassInfo.RowStyles.Clear();
        for (var index = 0; index < 10; index++)
        {
            tblClassInfo.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        flpClassActions.AutoSize = true;
        flpClassActions.WrapContents = true;
        flpClassActions.Dock = DockStyle.Fill;
        flpClassActions.Margin = new Padding(0, 12, 0, 0);
        flpClassActions.Padding = new Padding(0, 4, 0, 0);

        foreach (Control control in flpClassActions.Controls)
        {
            control.Margin = new Padding(0, 0, 10, 10);
        }
    }

    private void BindMockData()
    {
        _classTable = DemoDataFactory.GetClassList();
        dgvClassList.DataSource = _classTable;
        dgvClassStudentList.DataSource = DemoDataFactory.GetClassStudents();
        dgvClassSessionList.DataSource = DemoDataFactory.GetSessions();
        if (dgvClassList.Rows.Count > 0)
        {
            dgvClassList.Rows[0].Selected = true;
            PopulateClassDetail();
        }
    }

    private void WireEvents()
    {
        dgvClassList.SelectionChanged += (_, _) => PopulateClassDetail();
        btnSearchClass.Click += (_, _) => ApplyFilters();
        btnRefreshClass.Click += (_, _) => ResetFilters();
        btnCreateClass.Click += (_, _) =>
        {
            txtClassCode.Text = $"LP{_classTable.Rows.Count + 1:000}";
            txtClassName.Clear();
            txtClassCourse.Clear();
            txtClassTeacher.Clear();
            txtClassSchedule.Clear();
            txtClassRoom.Clear();
            txtClassSize.Clear();
            dtpClassStartDate.Value = DateTime.Today;
            dtpClassEndDate.Value = DateTime.Today.AddMonths(3);
            cboClassDetailStatus.SelectedIndex = 0;
            tabClassManagement.SelectedTab = tpClassInfo;
            txtClassName.Focus();
        };
        btnSaveClass.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Lưu lớp học", "UI demo đã lưu trạng thái lớp học trong phiên làm việc hiện tại.");
            dialog.ShowDialog(this);
        };
        btnUpdateClass.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Cập nhật lớp học", "Thông tin lớp học đang chọn đã được cập nhật ở tầng giao diện.");
            dialog.ShowDialog(this);
        };
        btnGenerateSessions.Click += (_, _) => tabClassManagement.SelectedTab = tpClassSessions;
        btnOpenEnrollmentFromClass.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Mở ghi danh lớp", "UI demo đã sẵn sàng chuyển sang nghiệp vụ ghi danh / xếp lớp.");
            dialog.ShowDialog(this);
        };
        Resize += (_, _) => ApplyResponsiveLayout();
    }

    private void ApplyFilters()
    {
        var keyword = txtClassKeyword.Text.Trim();
        var status = cboClassStatusFilter.Text;
        var filteredTable = _classTable.Clone();

        foreach (DataRow row in _classTable.Rows)
        {
            var matchesKeyword =
                string.IsNullOrWhiteSpace(keyword) ||
                row["Mã lớp"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                row["Tên lớp"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase);
            var matchesStatus = status == "Tất cả" || row["Trạng thái"].ToString() == status;

            if (matchesKeyword && matchesStatus)
            {
                filteredTable.ImportRow(row);
            }
        }

        dgvClassList.DataSource = filteredTable;
        if (dgvClassList.Rows.Count > 0)
        {
            dgvClassList.Rows[0].Selected = true;
            PopulateClassDetail();
        }
    }

    private void ResetFilters()
    {
        txtClassKeyword.Clear();
        cboClassStatusFilter.SelectedIndex = 0;
        dgvClassList.DataSource = _classTable;
        if (dgvClassList.Rows.Count > 0)
        {
            dgvClassList.Rows[0].Selected = true;
            PopulateClassDetail();
        }
    }

    private void PopulateClassDetail()
    {
        if (dgvClassList.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            return;
        }

        var row = rowView.Row;
        txtClassCode.Text = row["Mã lớp"].ToString();
        txtClassName.Text = row["Tên lớp"].ToString();
        txtClassCourse.Text = row["Khóa học"].ToString();
        txtClassTeacher.Text = row["Giáo viên"].ToString();
        txtClassSchedule.Text = row["Lịch học"].ToString();
        txtClassRoom.Text = "P201";
        dtpClassStartDate.Value = DateTime.Today;
        dtpClassEndDate.Value = DateTime.Today.AddMonths(3);
        txtClassSize.Text = row["Sĩ số"].ToString();
        cboClassDetailStatus.Text = row["Trạng thái"].ToString();
    }

    private void LocalizeLabels()
    {
        lblClassKeyword.Text = "Từ khóa tìm kiếm";
        txtClassKeyword.PlaceholderText = "Mã lớp hoặc tên lớp";
        lblClassStatus.Text = "Trạng thái";
        cboClassStatusFilter.Items.Clear();
        cboClassStatusFilter.Items.AddRange(["Tất cả", "Đang mở", "Đầy", "Đã đóng"]);

        tpClassInfo.Text = "Thông tin lớp";
        tpClassStudents.Text = "Danh sách học viên";
        tpClassSessions.Text = "Lịch học";
        lblClassCode.Text = "Mã lớp";
        lblClassName.Text = "Tên lớp";
        lblClassCourse.Text = "Khóa học";
        lblClassTeacher.Text = "Giáo viên";
        lblClassSchedule.Text = "Lịch học";
        lblClassRoom.Text = "Phòng học";
        lblClassStartDate.Text = "Ngày khai giảng";
        lblClassEndDate.Text = "Ngày kết thúc";
        lblClassSize.Text = "Sĩ số";
        lblClassDetailStatus.Text = "Trạng thái";
        cboClassDetailStatus.Items.Clear();
        cboClassDetailStatus.Items.AddRange(["Đang mở", "Đầy", "Đã đóng"]);

        btnSearchClass.Text = "Tìm kiếm";
        btnRefreshClass.Text = "Làm mới";
        btnCreateClass.Text = "Thêm lớp";
        btnSaveClass.Text = "Lưu";
        btnUpdateClass.Text = "Cập nhật";
        btnGenerateSessions.Text = "Tạo lịch học";
        btnOpenEnrollmentFromClass.Text = "Mở ghi danh";
    }

    private void BuildFilterLayout()
    {
        var filterLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 2,
            BackColor = Color.Transparent,
            Margin = Padding.Empty
        };
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
        filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
        filterLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        filterLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        var actionBar = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = true,
            AutoSize = true,
            Margin = new Padding(0, 22, 0, 0)
        };
        actionBar.Controls.Add(btnSearchClass);
        actionBar.Controls.Add(btnRefreshClass);

        txtClassKeyword.Dock = DockStyle.Fill;
        cboClassStatusFilter.Dock = DockStyle.Fill;

        pnlClassFilterCard.Controls.Clear();
        pnlClassFilterCard.Controls.Add(filterLayout);
        pnlClassFilterCard.Padding = new Padding(18, 16, 18, 14);
        pnlClassFilterCard.Height = 112;
        pnlClassFilterCard.MinimumSize = new Size(0, 112);

        filterLayout.Controls.Add(lblClassKeyword, 0, 0);
        filterLayout.Controls.Add(lblClassStatus, 1, 0);
        filterLayout.Controls.Add(txtClassKeyword, 0, 1);
        filterLayout.Controls.Add(cboClassStatusFilter, 1, 1);
        filterLayout.Controls.Add(actionBar, 2, 1);
    }

    private void ApplyResponsiveLayout()
    {
        var actionBar = btnSearchClass.Parent;
        if (pnlClassFilterCard.Controls.Count > 0 && pnlClassFilterCard.Controls[0] is TableLayoutPanel filterLayout)
        {
            if (ClientSize.Width < 980)
            {
                filterLayout.ColumnCount = 2;
                filterLayout.RowCount = 3;
                filterLayout.ColumnStyles.Clear();
                filterLayout.RowStyles.Clear();
                filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
                filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
                filterLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                filterLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                filterLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                filterLayout.SetColumn(lblClassKeyword, 0);
                filterLayout.SetRow(lblClassKeyword, 0);
                filterLayout.SetColumn(lblClassStatus, 1);
                filterLayout.SetRow(lblClassStatus, 0);
                filterLayout.SetColumn(txtClassKeyword, 0);
                filterLayout.SetRow(txtClassKeyword, 1);
                filterLayout.SetColumn(cboClassStatusFilter, 1);
                filterLayout.SetRow(cboClassStatusFilter, 1);
                if (actionBar is not null)
                {
                    filterLayout.SetColumn(actionBar, 0);
                    filterLayout.SetRow(actionBar, 2);
                    filterLayout.SetColumnSpan(actionBar, 2);
                }
                pnlClassFilterCard.Height = 128;
            }
            else
            {
                filterLayout.ColumnCount = 3;
                filterLayout.RowCount = 2;
                filterLayout.ColumnStyles.Clear();
                filterLayout.RowStyles.Clear();
                filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52F));
                filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
                filterLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
                filterLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                filterLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                filterLayout.SetColumn(lblClassKeyword, 0);
                filterLayout.SetRow(lblClassKeyword, 0);
                filterLayout.SetColumn(lblClassStatus, 1);
                filterLayout.SetRow(lblClassStatus, 0);
                filterLayout.SetColumn(txtClassKeyword, 0);
                filterLayout.SetRow(txtClassKeyword, 1);
                filterLayout.SetColumn(cboClassStatusFilter, 1);
                filterLayout.SetRow(cboClassStatusFilter, 1);
                if (actionBar is not null)
                {
                    filterLayout.SetColumn(actionBar, 2);
                    filterLayout.SetRow(actionBar, 1);
                    filterLayout.SetColumnSpan(actionBar, 1);
                }
                pnlClassFilterCard.Height = 112;
            }
        }

        if (ClientSize.Width < 980)
        {
            splClassContent.Orientation = Orientation.Horizontal;
            splClassContent.SplitterDistance = Math.Max(220, (int)(splClassContent.Height * 0.38));

            if (tblClassInfo.ColumnStyles.Count > 0)
            {
                tblClassInfo.ColumnStyles[0].Width = 132F;
            }
        }
        else
        {
            splClassContent.Orientation = Orientation.Vertical;
            splClassContent.SplitterDistance = Math.Max(360, (int)(splClassContent.Width * 0.42));

            if (tblClassInfo.ColumnStyles.Count > 0)
            {
                tblClassInfo.ColumnStyles[0].Width = 146F;
            }
        }
    }
}
