using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmCourseManagement : Form
{
    private DataTable _courseTable = new();

    public FrmCourseManagement()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Quản lý khóa học");
        ConfigureView();
        BindMockData();
        WireEvents();
        ApplyResponsiveLayout();
    }

    private void ConfigureView()
    {
        BuildFilterLayout();
        LocalizeLabels();

        cboCourseStatusFilter.SelectedIndex = 0;

        AppTheme.StyleGroupBox(grpCourseInfo);
        AppTheme.StyleGroupBox(grpCourseClassList);
        AppTheme.StyleGrid(dgvCourseList);
        AppTheme.StyleGrid(dgvCourseClassList);
        AppTheme.StyleSecondaryButton(btnSearchCourse);
        AppTheme.StyleSecondaryButton(btnRefreshCourse);
        AppTheme.StylePrimaryButton(btnCreateCourse);
        AppTheme.StylePrimaryButton(btnSaveCourse);
        AppTheme.StyleSecondaryButton(btnUpdateCourse);
        AppTheme.StyleDangerButton(btnDeleteCourse);

        dgvCourseList.RowTemplate.Height = 42;
        dgvCourseClassList.RowTemplate.Height = 40;

        splCourseContent.Panel1MinSize = 320;
        splCourseContent.Panel2MinSize = 380;
        splCourseContent.FixedPanel = FixedPanel.None;

        if (tblCourseDetail.ColumnStyles.Count > 0)
        {
            tblCourseDetail.ColumnStyles[0].Width = 150F;
        }

        flpCourseActions.AutoSize = true;
        flpCourseActions.WrapContents = true;
        flpCourseActions.Dock = DockStyle.Fill;
        flpCourseActions.Margin = new Padding(0, 12, 0, 0);
        flpCourseActions.Padding = new Padding(0, 4, 0, 0);

        foreach (Control control in flpCourseActions.Controls)
        {
            control.Margin = new Padding(0, 0, 10, 10);
        }

        txtCourseDescription.Multiline = true;
        txtCourseDescription.ScrollBars = ScrollBars.Vertical;
        txtCourseDescription.MinimumSize = new Size(0, 94);
    }

    private void BindMockData()
    {
        _courseTable = DemoDataFactory.GetCourseList();
        dgvCourseList.DataSource = _courseTable;
        dgvCourseClassList.DataSource = DemoDataFactory.GetClassList();

        if (dgvCourseList.Rows.Count > 0)
        {
            dgvCourseList.Rows[0].Selected = true;
            PopulateCourseDetail();
        }
    }

    private void WireEvents()
    {
        dgvCourseList.SelectionChanged += (_, _) => PopulateCourseDetail();
        btnSearchCourse.Click += (_, _) => ApplyFilters();
        btnRefreshCourse.Click += (_, _) => ResetFilters();
        btnCreateCourse.Click += (_, _) =>
        {
            txtCourseCode.Text = $"KH{_courseTable.Rows.Count + 1:000}";
            txtCourseName.Clear();
            txtCourseLevel.Clear();
            txtCourseFee.Clear();
            txtCourseDescription.Clear();
            txtCourseName.Focus();
        };
        btnSaveCourse.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Lưu khóa học", "UI demo đã sẵn sàng để nối backend cho nghiệp vụ khóa học.");
            dialog.ShowDialog(this);
        };
        btnUpdateCourse.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Cập nhật khóa học", "Thông tin khóa học đang chọn đã được cập nhật ở tầng giao diện.");
            dialog.ShowDialog(this);
        };
        btnDeleteCourse.Click += (_, _) =>
        {
            using var dialog = new FrmConfirmDialog("Xóa khóa học", "Bạn có chắc muốn xóa khóa học đang chọn khỏi danh sách demo không?");
            if (dialog.ShowDialog(this) == DialogResult.OK && dgvCourseList.CurrentRow is not null)
            {
                dgvCourseList.Rows.Remove(dgvCourseList.CurrentRow);
            }
        };
        Resize += (_, _) => ApplyResponsiveLayout();
    }

    private void ApplyFilters()
    {
        var keyword = txtCourseKeyword.Text.Trim();
        var status = cboCourseStatusFilter.Text;
        var filteredTable = _courseTable.Clone();

        foreach (DataRow row in _courseTable.Rows)
        {
            var matchesKeyword =
                string.IsNullOrWhiteSpace(keyword) ||
                row["Mã khóa"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                row["Tên khóa"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase);
            var matchesStatus = status == "Tất cả" || row["Trạng thái"].ToString() == status;

            if (matchesKeyword && matchesStatus)
            {
                filteredTable.ImportRow(row);
            }
        }

        dgvCourseList.DataSource = filteredTable;
        if (dgvCourseList.Rows.Count > 0)
        {
            dgvCourseList.Rows[0].Selected = true;
            PopulateCourseDetail();
        }
    }

    private void ResetFilters()
    {
        txtCourseKeyword.Clear();
        cboCourseStatusFilter.SelectedIndex = 0;
        dgvCourseList.DataSource = _courseTable;
        if (dgvCourseList.Rows.Count > 0)
        {
            dgvCourseList.Rows[0].Selected = true;
            PopulateCourseDetail();
        }
    }

    private void PopulateCourseDetail()
    {
        if (dgvCourseList.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            return;
        }

        var row = rowView.Row;
        txtCourseCode.Text = row["Mã khóa"].ToString();
        txtCourseName.Text = row["Tên khóa"].ToString();
        txtCourseLevel.Text = row["Level"].ToString();
        txtCourseFee.Text = row["Học phí"].ToString();
        txtCourseDescription.Text = $"Khóa học {row["Tên khóa"]} hiện đang ở trạng thái {row["Trạng thái"]}.";
    }

    private void LocalizeLabels()
    {
        lblCourseKeyword.Text = "Từ khóa tìm kiếm";
        txtCourseKeyword.PlaceholderText = "Mã khóa hoặc tên khóa học";
        lblCourseStatus.Text = "Trạng thái";
        cboCourseStatusFilter.Items.Clear();
        cboCourseStatusFilter.Items.AddRange(["Tất cả", "Còn mở", "Tạm dừng"]);

        grpCourseInfo.Text = "Thông tin khóa học";
        grpCourseClassList.Text = "Danh sách lớp thuộc khóa";
        lblCourseCode.Text = "Mã khóa";
        lblCourseName.Text = "Tên khóa học";
        lblCourseLevel.Text = "Cấp độ";
        lblCourseFee.Text = "Học phí";
        lblCourseDescription.Text = "Mô tả chương trình";

        btnSearchCourse.Text = "Tìm kiếm";
        btnRefreshCourse.Text = "Làm mới";
        btnCreateCourse.Text = "Thêm khóa";
        btnSaveCourse.Text = "Lưu";
        btnUpdateCourse.Text = "Cập nhật";
        btnDeleteCourse.Text = "Xóa";
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
        actionBar.Controls.Add(btnSearchCourse);
        actionBar.Controls.Add(btnRefreshCourse);

        txtCourseKeyword.Dock = DockStyle.Fill;
        cboCourseStatusFilter.Dock = DockStyle.Fill;

        pnlCourseFilterCard.Controls.Clear();
        pnlCourseFilterCard.Controls.Add(filterLayout);
        pnlCourseFilterCard.Padding = new Padding(18, 16, 18, 14);
        pnlCourseFilterCard.Height = 112;
        pnlCourseFilterCard.MinimumSize = new Size(0, 112);

        filterLayout.Controls.Add(lblCourseKeyword, 0, 0);
        filterLayout.Controls.Add(lblCourseStatus, 1, 0);
        filterLayout.Controls.Add(txtCourseKeyword, 0, 1);
        filterLayout.Controls.Add(cboCourseStatusFilter, 1, 1);
        filterLayout.Controls.Add(actionBar, 2, 1);
    }

    private void ApplyResponsiveLayout()
    {
        var actionBar = btnSearchCourse.Parent;
        if (pnlCourseFilterCard.Controls.Count > 0 && pnlCourseFilterCard.Controls[0] is TableLayoutPanel filterLayout)
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
                filterLayout.SetColumn(lblCourseKeyword, 0);
                filterLayout.SetRow(lblCourseKeyword, 0);
                filterLayout.SetColumn(lblCourseStatus, 1);
                filterLayout.SetRow(lblCourseStatus, 0);
                filterLayout.SetColumn(txtCourseKeyword, 0);
                filterLayout.SetRow(txtCourseKeyword, 1);
                filterLayout.SetColumn(cboCourseStatusFilter, 1);
                filterLayout.SetRow(cboCourseStatusFilter, 1);
                if (actionBar is not null)
                {
                    filterLayout.SetColumn(actionBar, 0);
                    filterLayout.SetRow(actionBar, 2);
                    filterLayout.SetColumnSpan(actionBar, 2);
                }
                pnlCourseFilterCard.Height = 128;
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
                filterLayout.SetColumn(lblCourseKeyword, 0);
                filterLayout.SetRow(lblCourseKeyword, 0);
                filterLayout.SetColumn(lblCourseStatus, 1);
                filterLayout.SetRow(lblCourseStatus, 0);
                filterLayout.SetColumn(txtCourseKeyword, 0);
                filterLayout.SetRow(txtCourseKeyword, 1);
                filterLayout.SetColumn(cboCourseStatusFilter, 1);
                filterLayout.SetRow(cboCourseStatusFilter, 1);
                if (actionBar is not null)
                {
                    filterLayout.SetColumn(actionBar, 2);
                    filterLayout.SetRow(actionBar, 1);
                    filterLayout.SetColumnSpan(actionBar, 1);
                }
                pnlCourseFilterCard.Height = 112;
            }
        }

        if (ClientSize.Width < 980)
        {
            splCourseContent.Orientation = Orientation.Horizontal;
            splCourseContent.SplitterDistance = Math.Max(220, (int)(splCourseContent.Height * 0.4));

            if (tblCourseDetail.ColumnStyles.Count > 0)
            {
                tblCourseDetail.ColumnStyles[0].Width = 132F;
            }
        }
        else
        {
            splCourseContent.Orientation = Orientation.Vertical;
            splCourseContent.SplitterDistance = Math.Max(350, (int)(splCourseContent.Width * 0.4));

            if (tblCourseDetail.ColumnStyles.Count > 0)
            {
                tblCourseDetail.ColumnStyles[0].Width = 150F;
            }
        }
    }
}
