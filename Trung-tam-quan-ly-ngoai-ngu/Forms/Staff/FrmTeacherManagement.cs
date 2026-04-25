using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmTeacherManagement : Form
{
    private DataTable _teacherTable = new();

    public FrmTeacherManagement()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Quản lý giáo viên");
        ConfigureView();
        BindMockData();
        WireEvents();
        ApplyResponsiveLayout();
    }

    private void ConfigureView()
    {
        BuildFilterLayout();
        LocalizeLabels();

        cboTeacherStatusFilter.SelectedIndex = 0;
        AppTheme.StyleGroupBox(grpTeacherInfo);
        AppTheme.StyleGrid(dgvTeacherList);
        AppTheme.StyleSecondaryButton(btnSearchTeacher);
        AppTheme.StyleSecondaryButton(btnRefreshTeacher);
        AppTheme.StylePrimaryButton(btnCreateTeacher);
        AppTheme.StylePrimaryButton(btnSaveTeacher);
        AppTheme.StyleSecondaryButton(btnUpdateTeacher);
        AppTheme.StyleDangerButton(btnDeleteTeacher);

        dgvTeacherList.RowTemplate.Height = 42;

        splTeacherContent.Panel1MinSize = 320;
        splTeacherContent.Panel2MinSize = 360;
        splTeacherContent.FixedPanel = FixedPanel.None;

        if (tblTeacherDetail.ColumnStyles.Count > 0)
        {
            tblTeacherDetail.ColumnStyles[0].Width = 150F;
        }

        flpTeacherActions.AutoSize = true;
        flpTeacherActions.WrapContents = true;
        flpTeacherActions.Dock = DockStyle.Fill;
        flpTeacherActions.Margin = new Padding(0, 12, 0, 0);
        flpTeacherActions.Padding = new Padding(0, 4, 0, 0);

        foreach (Control control in flpTeacherActions.Controls)
        {
            control.Margin = new Padding(0, 0, 10, 10);
        }

        txtTeacherAddress.Multiline = true;
        txtTeacherAddress.ScrollBars = ScrollBars.Vertical;
        txtTeacherNote.Multiline = true;
        txtTeacherNote.ScrollBars = ScrollBars.Vertical;
        txtTeacherAddress.MinimumSize = new Size(0, 74);
        txtTeacherNote.MinimumSize = new Size(0, 90);
    }

    private void BindMockData()
    {
        _teacherTable = DemoDataFactory.GetTeacherList();
        dgvTeacherList.DataSource = _teacherTable;
        if (dgvTeacherList.Rows.Count > 0)
        {
            dgvTeacherList.Rows[0].Selected = true;
            PopulateTeacherDetail();
        }
    }

    private void WireEvents()
    {
        dgvTeacherList.SelectionChanged += (_, _) => PopulateTeacherDetail();
        btnSearchTeacher.Click += (_, _) => ApplyFilters();
        btnRefreshTeacher.Click += (_, _) => ResetFilters();
        btnCreateTeacher.Click += (_, _) =>
        {
            txtTeacherCode.Text = $"GV{_teacherTable.Rows.Count + 1:000}";
            txtTeacherName.Clear();
            txtTeacherPhone.Clear();
            txtTeacherEmail.Clear();
            txtTeacherSpecialty.Clear();
            txtTeacherAddress.Clear();
            txtTeacherNote.Clear();
            txtTeacherName.Focus();
        };
        btnSaveTeacher.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Lưu giáo viên", "UI demo đã chuẩn bị sẵn để nối nghiệp vụ quản lý hồ sơ giáo viên.");
            dialog.ShowDialog(this);
        };
        btnUpdateTeacher.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Cập nhật giáo viên", "Thông tin giáo viên đang chọn đã được cập nhật ở tầng giao diện.");
            dialog.ShowDialog(this);
        };
        btnDeleteTeacher.Click += (_, _) =>
        {
            using var dialog = new FrmConfirmDialog("Xóa giáo viên", "Bạn có chắc muốn xóa giáo viên đang chọn khỏi danh sách demo không?");
            if (dialog.ShowDialog(this) == DialogResult.OK && dgvTeacherList.CurrentRow is not null)
            {
                dgvTeacherList.Rows.Remove(dgvTeacherList.CurrentRow);
            }
        };
        Resize += (_, _) => ApplyResponsiveLayout();
    }

    private void ApplyFilters()
    {
        var keyword = txtTeacherKeyword.Text.Trim();
        var status = cboTeacherStatusFilter.Text;
        var filteredTable = _teacherTable.Clone();

        foreach (DataRow row in _teacherTable.Rows)
        {
            var matchesKeyword =
                string.IsNullOrWhiteSpace(keyword) ||
                row["Mã giáo viên"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                row["Họ tên"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                row["Điện thoại"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase);

            var matchesStatus = status == "Tất cả" || status == "Đang giảng dạy";
            if (matchesKeyword && matchesStatus)
            {
                filteredTable.ImportRow(row);
            }
        }

        dgvTeacherList.DataSource = filteredTable;
        if (dgvTeacherList.Rows.Count > 0)
        {
            dgvTeacherList.Rows[0].Selected = true;
            PopulateTeacherDetail();
        }
    }

    private void ResetFilters()
    {
        txtTeacherKeyword.Clear();
        cboTeacherStatusFilter.SelectedIndex = 0;
        dgvTeacherList.DataSource = _teacherTable;
        if (dgvTeacherList.Rows.Count > 0)
        {
            dgvTeacherList.Rows[0].Selected = true;
            PopulateTeacherDetail();
        }
    }

    private void PopulateTeacherDetail()
    {
        if (dgvTeacherList.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            return;
        }

        var row = rowView.Row;
        txtTeacherCode.Text = row["Mã giáo viên"].ToString();
        txtTeacherName.Text = row["Họ tên"].ToString();
        txtTeacherPhone.Text = row["Điện thoại"].ToString();
        txtTeacherEmail.Text = row["Email"].ToString();
        txtTeacherSpecialty.Text = row["Chuyên môn"].ToString();
        txtTeacherAddress.Text = "Bổ sung địa chỉ từ nguồn dữ liệu thực tế.";
        txtTeacherNote.Text = "Giáo viên được dùng để phân công vào lớp học.";
    }

    private void LocalizeLabels()
    {
        lblTeacherKeyword.Text = "Từ khóa tìm kiếm";
        txtTeacherKeyword.PlaceholderText = "Mã giáo viên, họ tên hoặc số điện thoại";
        lblTeacherStatus.Text = "Trạng thái";
        cboTeacherStatusFilter.Items.Clear();
        cboTeacherStatusFilter.Items.AddRange(["Tất cả", "Đang giảng dạy", "Tạm nghỉ"]);

        grpTeacherInfo.Text = "Thông tin giáo viên";
        lblTeacherCode.Text = "Mã giáo viên";
        lblTeacherName.Text = "Họ và tên";
        lblTeacherPhone.Text = "Điện thoại";
        lblTeacherEmail.Text = "Email";
        lblTeacherSpecialty.Text = "Chuyên môn";
        lblTeacherAddress.Text = "Địa chỉ";
        lblTeacherNote.Text = "Ghi chú hồ sơ";

        btnSearchTeacher.Text = "Tìm kiếm";
        btnRefreshTeacher.Text = "Làm mới";
        btnCreateTeacher.Text = "Thêm giáo viên";
        btnSaveTeacher.Text = "Lưu";
        btnUpdateTeacher.Text = "Cập nhật";
        btnDeleteTeacher.Text = "Xóa";
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
        actionBar.Controls.Add(btnSearchTeacher);
        actionBar.Controls.Add(btnRefreshTeacher);

        txtTeacherKeyword.Dock = DockStyle.Fill;
        cboTeacherStatusFilter.Dock = DockStyle.Fill;

        pnlTeacherFilterCard.Controls.Clear();
        pnlTeacherFilterCard.Controls.Add(filterLayout);
        pnlTeacherFilterCard.Padding = new Padding(18, 16, 18, 14);
        pnlTeacherFilterCard.Height = 112;
        pnlTeacherFilterCard.MinimumSize = new Size(0, 112);

        filterLayout.Controls.Add(lblTeacherKeyword, 0, 0);
        filterLayout.Controls.Add(lblTeacherStatus, 1, 0);
        filterLayout.Controls.Add(txtTeacherKeyword, 0, 1);
        filterLayout.Controls.Add(cboTeacherStatusFilter, 1, 1);
        filterLayout.Controls.Add(actionBar, 2, 1);
    }

    private void ApplyResponsiveLayout()
    {
        var actionBar = btnSearchTeacher.Parent;
        if (pnlTeacherFilterCard.Controls.Count > 0 && pnlTeacherFilterCard.Controls[0] is TableLayoutPanel filterLayout)
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
                filterLayout.SetColumn(lblTeacherKeyword, 0);
                filterLayout.SetRow(lblTeacherKeyword, 0);
                filterLayout.SetColumn(lblTeacherStatus, 1);
                filterLayout.SetRow(lblTeacherStatus, 0);
                filterLayout.SetColumn(txtTeacherKeyword, 0);
                filterLayout.SetRow(txtTeacherKeyword, 1);
                filterLayout.SetColumn(cboTeacherStatusFilter, 1);
                filterLayout.SetRow(cboTeacherStatusFilter, 1);
                if (actionBar is not null)
                {
                    filterLayout.SetColumn(actionBar, 0);
                    filterLayout.SetRow(actionBar, 2);
                    filterLayout.SetColumnSpan(actionBar, 2);
                }
                pnlTeacherFilterCard.Height = 128;
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
                filterLayout.SetColumn(lblTeacherKeyword, 0);
                filterLayout.SetRow(lblTeacherKeyword, 0);
                filterLayout.SetColumn(lblTeacherStatus, 1);
                filterLayout.SetRow(lblTeacherStatus, 0);
                filterLayout.SetColumn(txtTeacherKeyword, 0);
                filterLayout.SetRow(txtTeacherKeyword, 1);
                filterLayout.SetColumn(cboTeacherStatusFilter, 1);
                filterLayout.SetRow(cboTeacherStatusFilter, 1);
                if (actionBar is not null)
                {
                    filterLayout.SetColumn(actionBar, 2);
                    filterLayout.SetRow(actionBar, 1);
                    filterLayout.SetColumnSpan(actionBar, 1);
                }
                pnlTeacherFilterCard.Height = 112;
            }
        }

        if (ClientSize.Width < 960)
        {
            splTeacherContent.Orientation = Orientation.Horizontal;
            splTeacherContent.SplitterDistance = Math.Max(220, (int)(splTeacherContent.Height * 0.42));

            if (tblTeacherDetail.ColumnStyles.Count > 0)
            {
                tblTeacherDetail.ColumnStyles[0].Width = 132F;
            }
        }
        else
        {
            splTeacherContent.Orientation = Orientation.Vertical;
            splTeacherContent.SplitterDistance = Math.Max(360, (int)(splTeacherContent.Width * 0.42));

            if (tblTeacherDetail.ColumnStyles.Count > 0)
            {
                tblTeacherDetail.ColumnStyles[0].Width = 150F;
            }
        }
    }
}
