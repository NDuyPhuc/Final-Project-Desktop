using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmStudentManagement : Form
{
    private DataTable studentTable = new();

    public FrmStudentManagement()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Quản lý học viên");
        ConfigureView();
        BindMockData();
        WireEvents();
        ApplyResponsiveLayout();
    }

    private void ConfigureView()
    {
        BuildFilterLayout();
        LocalizeLabels();

        cboStudentStatusFilter.SelectedIndex = 0;
        cboStudentStatus.SelectedIndex = 0;

        ttStudentManagement.SetToolTip(btnOpenEnrollment, "Mở màn ghi danh để tiếp tục quy trình thu học phí.");
        ttStudentManagement.SetToolTip(btnChooseStudentAvatar, "UI demo đã sẵn sàng để nối tính năng chọn ảnh thật sau này.");

        AppTheme.StyleGroupBox(grpStudentInfo);
        AppTheme.StyleGrid(dgvStudentList);
        AppTheme.StyleSecondaryButton(btnSearchStudent);
        AppTheme.StyleSecondaryButton(btnRefreshStudent);
        AppTheme.StyleSecondaryButton(btnChooseStudentAvatar);
        AppTheme.StyleSecondaryButton(btnRemoveStudentAvatar);
        AppTheme.StyleSecondaryButton(btnResetStudent);
        AppTheme.StyleSecondaryButton(btnOpenEnrollment);
        AppTheme.StylePrimaryButton(btnCreateStudent);
        AppTheme.StylePrimaryButton(btnSaveStudent);
        AppTheme.StylePrimaryButton(btnUpdateStudent);
        AppTheme.StyleDangerButton(btnDeleteStudent);

        picStudentAvatar.BackColor = Color.FromArgb(233, 239, 248);
        picStudentAvatar.BorderStyle = BorderStyle.FixedSingle;
        picStudentAvatar.SizeMode = PictureBoxSizeMode.Zoom;
        picStudentAvatar.MinimumSize = new Size(112, 112);
        picStudentAvatar.Size = new Size(128, 128);
        picStudentAvatar.Anchor = AnchorStyles.Top;
        picStudentAvatar.Margin = new Padding(0, 0, 0, 8);

        if (tblStudentInfo.ColumnStyles.Count > 0)
        {
            tblStudentInfo.ColumnStyles[0].Width = 148F;
        }

        dgvStudentList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 248);
        dgvStudentList.DefaultCellStyle.SelectionForeColor = Color.FromArgb(31, 41, 55);
        dgvStudentList.RowTemplate.Height = 42;

        splStudentContent.Panel1MinSize = 320;
        splStudentContent.Panel2MinSize = 340;
        splStudentContent.FixedPanel = FixedPanel.None;

        flpStudentActions.AutoSize = true;
        flpStudentActions.WrapContents = true;
        flpStudentActions.Dock = DockStyle.Fill;
        flpStudentActions.FlowDirection = FlowDirection.LeftToRight;
        flpStudentActions.Padding = new Padding(0, 4, 0, 0);
        flpStudentActions.Margin = new Padding(0, 12, 0, 0);

        foreach (Control control in flpStudentActions.Controls)
        {
            control.Margin = new Padding(0, 0, 10, 10);
        }

        txtStudentId.TextAlign = HorizontalAlignment.Left;
        txtStudentFullName.TextAlign = HorizontalAlignment.Left;
        txtStudentPhone.TextAlign = HorizontalAlignment.Left;
        txtStudentEmail.TextAlign = HorizontalAlignment.Left;
        cboStudentStatus.Dock = DockStyle.Left;
    }

    private void BindMockData()
    {
        studentTable = DemoDataFactory.GetStudentList();
        dgvStudentList.DataSource = studentTable;
        if (dgvStudentList.Rows.Count > 0)
        {
            dgvStudentList.Rows[0].Selected = true;
            PopulateDetailFromSelection();
        }
    }

    private void WireEvents()
    {
        dgvStudentList.SelectionChanged += (_, _) => PopulateDetailFromSelection();
        btnSearchStudent.Click += (_, _) => ApplyFilters();
        btnRefreshStudent.Click += (_, _) => ResetFilters();
        btnResetStudent.Click += (_, _) => ResetDetailEditor();
        btnOpenEnrollment.Click += (_, _) =>
        {
            using var form = new FrmEnrollment();
            form.ShowDialog(this);
        };
        btnCreateStudent.Click += (_, _) =>
        {
            ResetDetailEditor();
            txtStudentId.Text = $"HV{studentTable.Rows.Count + 1:000}";
            txtStudentFullName.Focus();
        };
        btnSaveStudent.Click += (_, _) =>
        {
            if (!ValidateEditor())
            {
                return;
            }

            using var dialog = new FrmStatusDialog("Lưu học viên", "Dữ liệu demo đã được cập nhật trong màn hình hiện tại.");
            dialog.ShowDialog(this);
        };
        btnUpdateStudent.Click += (_, _) =>
        {
            if (!ValidateEditor())
            {
                return;
            }

            using var dialog = new FrmStatusDialog("Cập nhật học viên", "Thông tin hàng đang chọn đã được cập nhật ở tầng UI demo.");
            dialog.ShowDialog(this);
        };
        btnDeleteStudent.Click += (_, _) =>
        {
            using var dialog = new FrmConfirmDialog("Xóa học viên", "Bạn có chắc muốn xóa học viên đang chọn khỏi danh sách demo không?");
            if (dialog.ShowDialog(this) == DialogResult.OK && dgvStudentList.CurrentRow is not null)
            {
                dgvStudentList.Rows.Remove(dgvStudentList.CurrentRow);
                ResetDetailEditor();
            }
        };
        btnChooseStudentAvatar.Click += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Ảnh đại diện", "Màn hình đã sẵn sàng để backend nối tính năng chọn ảnh từ máy.");
            dialog.ShowDialog(this);
        };
        btnRemoveStudentAvatar.Click += (_, _) => picStudentAvatar.Image = null;
        Resize += (_, _) => ApplyResponsiveLayout();
    }

    private void ApplyFilters()
    {
        var keyword = txtStudentKeyword.Text.Trim();
        var status = cboStudentStatusFilter.Text;
        var filteredTable = studentTable.Clone();

        foreach (DataRow row in studentTable.Rows)
        {
            var matchesKeyword =
                string.IsNullOrWhiteSpace(keyword) ||
                row["Mã học viên"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                row["Họ tên"].ToString()!.Contains(keyword, StringComparison.OrdinalIgnoreCase);

            var matchesStatus = status == "Tất cả" || row["Trạng thái"].ToString() == status;
            if (matchesKeyword && matchesStatus)
            {
                filteredTable.ImportRow(row);
            }
        }

        dgvStudentList.DataSource = filteredTable;
        if (dgvStudentList.Rows.Count > 0)
        {
            dgvStudentList.Rows[0].Selected = true;
            PopulateDetailFromSelection();
        }
        else
        {
            ResetDetailEditor();
        }
    }

    private void ResetFilters()
    {
        txtStudentKeyword.Clear();
        cboStudentStatusFilter.SelectedIndex = 0;
        dgvStudentList.DataSource = studentTable;
        if (dgvStudentList.Rows.Count > 0)
        {
            dgvStudentList.Rows[0].Selected = true;
            PopulateDetailFromSelection();
        }
    }

    private void PopulateDetailFromSelection()
    {
        if (dgvStudentList.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            return;
        }

        var row = rowView.Row;
        txtStudentId.Text = row["Mã học viên"].ToString();
        txtStudentFullName.Text = row["Họ tên"].ToString();
        txtStudentPhone.Text = row["Điện thoại"].ToString();
        txtStudentEmail.Text = BuildDemoEmail(txtStudentFullName.Text);
        cboStudentStatus.Text = row["Trạng thái"].ToString();

        if (DateTime.TryParse(row["Ngày sinh"].ToString(), out var birthDate))
        {
            dtpStudentBirthDate.Value = birthDate;
        }
    }

    private bool ValidateEditor()
    {
        errStudent.Clear();
        if (string.IsNullOrWhiteSpace(txtStudentId.Text))
        {
            errStudent.SetError(txtStudentId, "Mã học viên không được để trống.");
        }

        if (string.IsNullOrWhiteSpace(txtStudentFullName.Text))
        {
            errStudent.SetError(txtStudentFullName, "Họ tên không được để trống.");
        }

        if (string.IsNullOrWhiteSpace(txtStudentPhone.Text))
        {
            errStudent.SetError(txtStudentPhone, "Điện thoại không được để trống.");
        }

        return string.IsNullOrWhiteSpace(errStudent.GetError(txtStudentId))
            && string.IsNullOrWhiteSpace(errStudent.GetError(txtStudentFullName))
            && string.IsNullOrWhiteSpace(errStudent.GetError(txtStudentPhone));
    }

    private void ResetDetailEditor()
    {
        errStudent.Clear();
        txtStudentId.Clear();
        txtStudentFullName.Clear();
        txtStudentPhone.Clear();
        txtStudentEmail.Clear();
        cboStudentStatus.SelectedIndex = 0;
        dtpStudentBirthDate.Value = DateTime.Today;
        picStudentAvatar.Image = null;
    }

    private void LocalizeLabels()
    {
        lblStudentKeyword.Text = "Từ khóa tìm kiếm";
        txtStudentKeyword.PlaceholderText = "Tên học viên, mã học viên hoặc số điện thoại";
        lblStudentStatusFilter.Text = "Trạng thái";
        cboStudentStatusFilter.Items.Clear();
        cboStudentStatusFilter.Items.AddRange(["Tất cả", "Đang học", "Bảo lưu", "Ngừng học"]);

        grpStudentInfo.Text = "Thông tin học viên";
        lblStudentId.Text = "Mã học viên";
        lblStudentFullName.Text = "Họ và tên";
        lblStudentBirthDate.Text = "Ngày sinh";
        lblStudentPhone.Text = "Điện thoại";
        lblStudentEmail.Text = "Email";
        lblStudentStatus.Text = "Trạng thái";
        cboStudentStatus.Items.Clear();
        cboStudentStatus.Items.AddRange(["Đang học", "Bảo lưu", "Ngừng học"]);

        btnSearchStudent.Text = "Tìm kiếm";
        btnRefreshStudent.Text = "Làm mới";
        btnChooseStudentAvatar.Text = "Chọn ảnh";
        btnRemoveStudentAvatar.Text = "Bỏ ảnh";
        btnCreateStudent.Text = "Thêm học viên";
        btnSaveStudent.Text = "Lưu";
        btnUpdateStudent.Text = "Cập nhật";
        btnDeleteStudent.Text = "Xóa";
        btnResetStudent.Text = "Đặt lại";
        btnOpenEnrollment.Text = "Mở ghi danh";
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
        actionBar.Controls.Add(btnSearchStudent);
        actionBar.Controls.Add(btnRefreshStudent);

        txtStudentKeyword.Dock = DockStyle.Fill;
        cboStudentStatusFilter.Dock = DockStyle.Fill;

        pnlStudentFilterCard.Controls.Clear();
        pnlStudentFilterCard.Controls.Add(filterLayout);
        pnlStudentFilterCard.Padding = new Padding(18, 16, 18, 14);
        pnlStudentFilterCard.Height = 112;
        pnlStudentFilterCard.MinimumSize = new Size(0, 112);

        filterLayout.Controls.Add(lblStudentKeyword, 0, 0);
        filterLayout.Controls.Add(lblStudentStatusFilter, 1, 0);
        filterLayout.Controls.Add(txtStudentKeyword, 0, 1);
        filterLayout.Controls.Add(cboStudentStatusFilter, 1, 1);
        filterLayout.Controls.Add(actionBar, 2, 1);
    }

    private void ApplyResponsiveLayout()
    {
        var actionBar = btnSearchStudent.Parent;
        if (pnlStudentFilterCard.Controls.Count > 0 && pnlStudentFilterCard.Controls[0] is TableLayoutPanel filterLayout)
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

                filterLayout.SetColumn(lblStudentKeyword, 0);
                filterLayout.SetRow(lblStudentKeyword, 0);
                filterLayout.SetColumn(lblStudentStatusFilter, 1);
                filterLayout.SetRow(lblStudentStatusFilter, 0);
                filterLayout.SetColumn(txtStudentKeyword, 0);
                filterLayout.SetRow(txtStudentKeyword, 1);
                filterLayout.SetColumn(cboStudentStatusFilter, 1);
                filterLayout.SetRow(cboStudentStatusFilter, 1);
                if (actionBar is not null)
                {
                    filterLayout.SetColumn(actionBar, 0);
                    filterLayout.SetRow(actionBar, 2);
                    filterLayout.SetColumnSpan(actionBar, 2);
                }
                pnlStudentFilterCard.Height = 128;
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

                filterLayout.SetColumn(lblStudentKeyword, 0);
                filterLayout.SetRow(lblStudentKeyword, 0);
                filterLayout.SetColumn(lblStudentStatusFilter, 1);
                filterLayout.SetRow(lblStudentStatusFilter, 0);
                filterLayout.SetColumn(txtStudentKeyword, 0);
                filterLayout.SetRow(txtStudentKeyword, 1);
                filterLayout.SetColumn(cboStudentStatusFilter, 1);
                filterLayout.SetRow(cboStudentStatusFilter, 1);
                if (actionBar is not null)
                {
                    filterLayout.SetColumn(actionBar, 2);
                    filterLayout.SetRow(actionBar, 1);
                    filterLayout.SetColumnSpan(actionBar, 1);
                }
                pnlStudentFilterCard.Height = 112;
            }
        }

        if (ClientSize.Width < 940)
        {
            splStudentContent.Orientation = Orientation.Horizontal;
            splStudentContent.SplitterDistance = Math.Max(220, (int)(splStudentContent.Height * 0.42));

            if (tblStudentInfo.ColumnStyles.Count > 0)
            {
                tblStudentInfo.ColumnStyles[0].Width = 132F;
            }
        }
        else
        {
            splStudentContent.Orientation = Orientation.Vertical;
            splStudentContent.SplitterDistance = Math.Max(420, (int)(splStudentContent.Width * 0.47));

            if (tblStudentInfo.ColumnStyles.Count > 0)
            {
                tblStudentInfo.ColumnStyles[0].Width = 148F;
            }
        }
    }

    private static string BuildDemoEmail(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            return string.Empty;
        }

        var normalized = fullName.ToLowerInvariant()
            .Replace(" ", ".")
            .Replace("đ", "d")
            .Replace("á", "a")
            .Replace("à", "a")
            .Replace("ả", "a")
            .Replace("ã", "a")
            .Replace("ạ", "a")
            .Replace("ă", "a")
            .Replace("ắ", "a")
            .Replace("ằ", "a")
            .Replace("ẳ", "a")
            .Replace("ẵ", "a")
            .Replace("ặ", "a")
            .Replace("â", "a")
            .Replace("ấ", "a")
            .Replace("ầ", "a")
            .Replace("ẩ", "a")
            .Replace("ẫ", "a")
            .Replace("ậ", "a")
            .Replace("é", "e")
            .Replace("è", "e")
            .Replace("ẻ", "e")
            .Replace("ẽ", "e")
            .Replace("ẹ", "e")
            .Replace("ê", "e")
            .Replace("ế", "e")
            .Replace("ề", "e")
            .Replace("ể", "e")
            .Replace("ễ", "e")
            .Replace("ệ", "e")
            .Replace("í", "i")
            .Replace("ì", "i")
            .Replace("ỉ", "i")
            .Replace("ĩ", "i")
            .Replace("ị", "i")
            .Replace("ó", "o")
            .Replace("ò", "o")
            .Replace("ỏ", "o")
            .Replace("õ", "o")
            .Replace("ọ", "o")
            .Replace("ô", "o")
            .Replace("ố", "o")
            .Replace("ồ", "o")
            .Replace("ổ", "o")
            .Replace("ỗ", "o")
            .Replace("ộ", "o")
            .Replace("ơ", "o")
            .Replace("ớ", "o")
            .Replace("ờ", "o")
            .Replace("ở", "o")
            .Replace("ỡ", "o")
            .Replace("ợ", "o")
            .Replace("ú", "u")
            .Replace("ù", "u")
            .Replace("ủ", "u")
            .Replace("ũ", "u")
            .Replace("ụ", "u")
            .Replace("ư", "u")
            .Replace("ứ", "u")
            .Replace("ừ", "u")
            .Replace("ử", "u")
            .Replace("ữ", "u")
            .Replace("ự", "u")
            .Replace("ý", "y")
            .Replace("ỳ", "y")
            .Replace("ỷ", "y")
            .Replace("ỹ", "y")
            .Replace("ỵ", "y");

        return $"{normalized}@demo.center";
    }
}
