using System.Data;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Domain.Entities;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmStudentManagement : Form
{
    private static readonly DateTime StudentBirthDateMax = new(2020, 12, 31);
    private static readonly DateTime StudentBirthDateMin = new(1900, 1, 1);
    private static readonly DateTime DefaultStudentBirthDate = new(2012, 1, 1);
    private static readonly Regex PhoneRegex = new(@"^0\d{9}$", RegexOptions.Compiled);
    private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
    private DataTable _studentTable = new();
    private string? _pendingAvatarSourcePath;
    private string? _currentAvatarPath;
    private Label? _lblStudentAddress;
    private TextBox? _txtStudentAddress;

    public FrmStudentManagement()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Quản lý học viên");
        ConfigureView();
        LoadStudents();
        WireEvents();
        ApplyResponsiveLayout();
    }

    private void ConfigureView()
    {
        BuildFilterLayout();
        EnsureAddressControls();
        LocalizeLabels();

        cboStudentStatusFilter.SelectedIndex = 0;
        cboStudentStatus.SelectedIndex = 0;

        ttStudentManagement.SetToolTip(btnOpenEnrollment, "Mở màn hình ghi danh để xếp lớp và thu học phí.");
        ttStudentManagement.SetToolTip(btnChooseStudentAvatar, "Chọn ảnh đại diện và lưu vào thư mục Images.");
        ttStudentManagement.SetToolTip(btnRemoveStudentAvatar, "Xóa ảnh khỏi hồ sơ. Bấm Lưu để áp dụng.");

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

        dtpStudentBirthDate.Format = DateTimePickerFormat.Custom;
        dtpStudentBirthDate.CustomFormat = "dd/MM/yyyy";
        dtpStudentBirthDate.MinDate = StudentBirthDateMin;
        dtpStudentBirthDate.Value = DefaultStudentBirthDate;
        dtpStudentBirthDate.MaxDate = StudentBirthDateMax;

        picStudentAvatar.BackColor = Color.FromArgb(233, 239, 248);
        picStudentAvatar.BorderStyle = BorderStyle.FixedSingle;
        picStudentAvatar.SizeMode = PictureBoxSizeMode.Zoom;
        picStudentAvatar.MinimumSize = new Size(88, 88);
        picStudentAvatar.Size = new Size(96, 96);
        picStudentAvatar.Anchor = AnchorStyles.Top;
        picStudentAvatar.Margin = new Padding(0, 0, 0, 8);

        dgvStudentList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 248);
        dgvStudentList.DefaultCellStyle.SelectionForeColor = Color.FromArgb(31, 41, 55);
        dgvStudentList.RowTemplate.Height = 42;
        dgvStudentList.AutoGenerateColumns = true;
        dgvStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

        cboStudentStatus.Dock = DockStyle.Left;
        cboStudentStatus.Width = 180;
    }

    private void WireEvents()
    {
        dgvStudentList.SelectionChanged += (_, _) => PopulateDetailFromSelection();
        btnSearchStudent.Click += (_, _) => LoadStudents(txtStudentKeyword.Text.Trim(), cboStudentStatusFilter.Text);
        btnRefreshStudent.Click += (_, _) => ResetFilters();
        btnResetStudent.Click += (_, _) => ResetDetailEditor();
        btnOpenEnrollment.Click += (_, _) =>
        {
            var studentId = txtStudentId.Text.Trim();
            using var form = new FrmEnrollment(string.IsNullOrWhiteSpace(studentId) ? null : studentId, null);
            form.ShowDialog(this);
        };
        btnCreateStudent.Click += (_, _) => StartCreateStudent();
        btnSaveStudent.Click += (_, _) => SaveCurrentStudent();
        btnUpdateStudent.Click += (_, _) => SaveCurrentStudent();
        btnDeleteStudent.Click += (_, _) => DeleteSelectedStudent();
        btnChooseStudentAvatar.Click += (_, _) => ChooseAvatar();
        btnRemoveStudentAvatar.Click += (_, _) => RemoveAvatar();
        Resize += (_, _) => ApplyResponsiveLayout();
    }

    private void LoadStudents(string? keyword = null, string? status = null)
    {
        try
        {
            _studentTable = AppRuntime.DataService.GetStudentList(
                string.IsNullOrWhiteSpace(keyword) ? null : keyword,
                string.IsNullOrWhiteSpace(status) || status is "Tat ca" or "Tất cả" ? null : status);

            dgvStudentList.DataSource = _studentTable;
            SelectFirstStudentRow();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmStudentManagement));
            MessageBox.Show(this, "Không tải được danh sách học viên. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void StartCreateStudent()
    {
        ResetDetailEditor();
        txtStudentId.Text = AppRuntime.DataService.GetNextStudentId();
        txtStudentFullName.Focus();
    }

    private void SaveCurrentStudent()
    {
        if (!ValidateEditor())
        {
            ValidationFeedback.ShowFirstError(this, errStudent,
                txtStudentId,
                txtStudentFullName,
                dtpStudentBirthDate,
                txtStudentPhone,
                txtStudentEmail);
            return;
        }

        try
        {
            var studentId = txtStudentId.Text.Trim();
            var isCreating = AppRuntime.DataService.GetStudentById(studentId) is null;
            var student = new StudentEntity
            {
                Id = studentId,
                FullName = txtStudentFullName.Text.Trim(),
                BirthDate = dtpStudentBirthDate.Value.Date,
                Phone = txtStudentPhone.Text.Trim(),
                Email = txtStudentEmail.Text.Trim(),
                Address = GetStudentAddressText(),
                AvatarPath = _currentAvatarPath,
                Status = cboStudentStatus.Text,
                IsDeleted = false
            };

            student = AppRuntime.DataService.SaveStudent(student);
            if (!string.IsNullOrWhiteSpace(_pendingAvatarSourcePath))
            {
                student.AvatarPath = AppRuntime.DataService.SaveStudentAvatar(student.Id, _pendingAvatarSourcePath);
                student = AppRuntime.DataService.SaveStudent(student);
                _pendingAvatarSourcePath = null;
            }

            _currentAvatarPath = student.AvatarPath;
            LoadStudents(txtStudentKeyword.Text.Trim(), cboStudentStatusFilter.Text);
            FocusStudent(student.Id);
            MessageBox.Show(this, isCreating ? "Đã thêm học viên thành công." : "Đã cập nhật học viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmStudentManagement));
            MessageBox.Show(this, $"Không lưu được học viên: {ex.GetBaseException().Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DeleteSelectedStudent()
    {
        if (string.IsNullOrWhiteSpace(txtStudentId.Text))
        {
            MessageBox.Show(this, "Hãy chọn học viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (AppRuntime.DataService.GetStudentById(txtStudentId.Text.Trim()) is null)
        {
            MessageBox.Show(this, "Học viên chưa được lưu nên không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var dialog = new FrmConfirmDialog("Xóa học viên", "Bạn có chắc muốn xóa mềm học viên đang chọn không?");
        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        try
        {
            AppRuntime.DataService.SoftDeleteStudent(txtStudentId.Text.Trim());
            LoadStudents(txtStudentKeyword.Text.Trim(), cboStudentStatusFilter.Text);
            ResetDetailEditor();
            MessageBox.Show(this, "Đã xóa mềm học viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmStudentManagement));
            MessageBox.Show(this, "Không xóa được học viên. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ChooseAvatar()
    {
        try
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Chọn avatar học viên"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            _pendingAvatarSourcePath = dialog.FileName;
            LoadAvatarPreview(dialog.FileName);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmStudentManagement));
            MessageBox.Show(this, "Không mở được file ảnh. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void RemoveAvatar()
    {
        _pendingAvatarSourcePath = null;
        _currentAvatarPath = null;
        picStudentAvatar.Image?.Dispose();
        picStudentAvatar.Image = null;
        MessageBox.Show(this, "Đã bỏ ảnh đại diện. Bấm Lưu để áp dụng thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void SelectFirstStudentRow()
    {
        if (dgvStudentList.Rows.Count > 0)
        {
            dgvStudentList.Rows[0].Selected = true;
            PopulateDetailFromSelection();
            return;
        }

        ResetDetailEditor();
    }

    private void FocusStudent(string studentId)
    {
        foreach (DataGridViewRow row in dgvStudentList.Rows)
        {
            if ((row.Cells[0].Value?.ToString() ?? string.Empty).Equals(studentId, StringComparison.OrdinalIgnoreCase))
            {
                row.Selected = true;
                dgvStudentList.CurrentCell = row.Cells[0];
                PopulateDetailFromSelection();
                return;
            }
        }
    }

    private void PopulateDetailFromSelection()
    {
        if (dgvStudentList.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            return;
        }

        var studentId = rowView.Row[0]?.ToString();
        if (string.IsNullOrWhiteSpace(studentId))
        {
            return;
        }

        try
        {
            var student = AppRuntime.DataService.GetStudentById(studentId);
            if (student is null)
            {
                return;
            }

            txtStudentId.Text = student.Id;
            txtStudentFullName.Text = student.FullName;
            txtStudentPhone.Text = student.Phone;
            txtStudentEmail.Text = student.Email ?? string.Empty;
            SetStudentAddressText(student.Address);
            cboStudentStatus.Text = string.IsNullOrWhiteSpace(student.Status) ? "Đang học" : student.Status;
            dtpStudentBirthDate.Value = ClampStudentBirthDate(student.BirthDate);
            _currentAvatarPath = student.AvatarPath;
            _pendingAvatarSourcePath = null;
            LoadAvatarPreview(AppRuntime.DataService.ResolveAbsoluteImagePath(student.AvatarPath));
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmStudentManagement));
            MessageBox.Show(this, "Không tải được chi tiết học viên. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadAvatarPreview(string? imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath))
        {
            picStudentAvatar.Image?.Dispose();
            picStudentAvatar.Image = null;
            return;
        }

        picStudentAvatar.Image?.Dispose();
        picStudentAvatar.Image = null;

        using var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var image = Image.FromStream(stream);
        picStudentAvatar.Image = new Bitmap(image);
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
            errStudent.SetError(txtStudentPhone, "Số điện thoại không được để trống.");
        }
        else if (!PhoneRegex.IsMatch(txtStudentPhone.Text.Trim()))
        {
            errStudent.SetError(txtStudentPhone, "Số điện thoại phải bắt đầu bằng 0 và đủ 10 chữ số, không nhập chữ.");
        }

        if (string.IsNullOrWhiteSpace(txtStudentEmail.Text))
        {
            errStudent.SetError(txtStudentEmail, "Email không được để trống.");
        }
        else if (!EmailRegex.IsMatch(txtStudentEmail.Text.Trim()))
        {
            errStudent.SetError(txtStudentEmail, "Email phải có @ và tên miền, ví dụ ten@gmail.com.");
        }

        if (dtpStudentBirthDate.Value.Date > StudentBirthDateMax)
        {
            errStudent.SetError(dtpStudentBirthDate, "Ngày sinh phải từ năm 2020 trở về trước.");
        }

        return string.IsNullOrWhiteSpace(errStudent.GetError(txtStudentId))
            && string.IsNullOrWhiteSpace(errStudent.GetError(txtStudentFullName))
            && string.IsNullOrWhiteSpace(errStudent.GetError(txtStudentPhone))
            && string.IsNullOrWhiteSpace(errStudent.GetError(txtStudentEmail))
            && string.IsNullOrWhiteSpace(errStudent.GetError(dtpStudentBirthDate));
    }

    private void ResetDetailEditor()
    {
        errStudent.Clear();
        txtStudentId.Clear();
        txtStudentFullName.Clear();
        txtStudentPhone.Clear();
        txtStudentEmail.Clear();
        SetStudentAddressText(string.Empty);
        cboStudentStatus.SelectedIndex = 0;
        dtpStudentBirthDate.Value = DefaultStudentBirthDate;
        _pendingAvatarSourcePath = null;
        _currentAvatarPath = null;
        picStudentAvatar.Image = null;
    }

    private void ResetFilters()
    {
        txtStudentKeyword.Clear();
        cboStudentStatusFilter.SelectedIndex = 0;
        LoadStudents();
    }

    private void LocalizeLabels()
    {
        lblStudentKeyword.Text = "Từ khóa tìm kiếm";
        txtStudentKeyword.PlaceholderText = "Tên học viên, mã học viên hoặc số điện thoại";
        lblStudentStatusFilter.Text = "Trạng thái";
        cboStudentStatusFilter.Items.Clear();
        cboStudentStatusFilter.Items.AddRange(["Tất cả", "Đang học", "Bảo lưu", "Hoàn thành", "Đã nghỉ"]);

        grpStudentInfo.Text = "Thông tin học viên";
        lblStudentId.Text = "Mã học viên";
        lblStudentFullName.Text = "Họ và tên";
        lblStudentBirthDate.Text = "Ngày sinh";
        lblStudentPhone.Text = "Điện thoại";
        lblStudentEmail.Text = "Email";
        if (_lblStudentAddress is not null)
        {
            _lblStudentAddress.Text = "Địa chỉ";
        }
        lblStudentStatus.Text = "Trạng thái";
        cboStudentStatus.Items.Clear();
        cboStudentStatus.Items.AddRange(["Đang học", "Bảo lưu", "Hoàn thành", "Đã nghỉ"]);

        btnSearchStudent.Text = "Tìm kiếm";
        btnRefreshStudent.Text = "Làm mới";
        btnChooseStudentAvatar.Text = "Chọn ảnh";
        btnRemoveStudentAvatar.Text = "Bỏ ảnh";
        btnCreateStudent.Text = "Thêm học viên";
        btnSaveStudent.Text = "Lưu";
        btnUpdateStudent.Text = "Cập nhật";
        btnDeleteStudent.Text = "Xóa mềm";
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
            FormHostHelpers.ApplyResponsiveSplit(
                splStudentContent,
                Orientation.Horizontal,
                Math.Max(220, (int)(splStudentContent.ClientSize.Height * 0.42)));
        }
        else
        {
            FormHostHelpers.ApplyResponsiveSplit(
                splStudentContent,
                Orientation.Vertical,
                Math.Max(420, (int)(splStudentContent.ClientSize.Width * 0.47)));
        }
    }

    private void EnsureAddressControls()
    {
        if (_txtStudentAddress is not null)
        {
            return;
        }

        _lblStudentAddress = new Label
        {
            Name = "lblStudentAddressDynamic",
            Text = "Địa chỉ",
            Anchor = AnchorStyles.Left,
            AutoSize = true
        };

        _txtStudentAddress = new TextBox
        {
            Name = "txtStudentAddressDynamic",
            Dock = DockStyle.Fill,
            Multiline = true,
            Height = 52,
            ScrollBars = ScrollBars.Vertical
        };

        tblStudentInfo.RowCount += 1;
        tblStudentInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
        tblStudentInfo.Controls.Add(_lblStudentAddress, 0, 7);
        tblStudentInfo.Controls.Add(_txtStudentAddress, 1, 7);
        tblStudentInfo.SetRow(lblStudentStatus, 8);
        tblStudentInfo.SetRow(cboStudentStatus, 8);
    }

    private string GetStudentAddressText() => _txtStudentAddress?.Text.Trim() ?? string.Empty;

    private void SetStudentAddressText(string? value)
    {
        if (_txtStudentAddress is not null)
        {
            _txtStudentAddress.Text = value ?? string.Empty;
        }
    }

    private static DateTime ClampStudentBirthDate(DateTime birthDate)
    {
        if (birthDate == default)
        {
            return DefaultStudentBirthDate;
        }

        if (birthDate < StudentBirthDateMin)
        {
            return StudentBirthDateMin;
        }

        return birthDate > StudentBirthDateMax ? StudentBirthDateMax : birthDate;
    }

    private static string BuildDemoEmail(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            return string.Empty;
        }

        var builder = new StringBuilder();
        foreach (var character in fullName.Normalize(NormalizationForm.FormD))
        {
            if (CharUnicodeInfo.GetUnicodeCategory(character) != UnicodeCategory.NonSpacingMark)
            {
                builder.Append(character);
            }
        }

        return builder.ToString()
            .Normalize(NormalizationForm.FormC)
            .Replace("\u0111", "d")
            .Replace("\u0110", "d")
            .ToLowerInvariant()
            .Replace(" ", ".")
            + "@demo.local";
    }
}
