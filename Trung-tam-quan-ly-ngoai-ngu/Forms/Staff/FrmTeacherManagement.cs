using System.Data;
using System.Text.RegularExpressions;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Domain.Entities;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmTeacherManagement : Form
{
    private static readonly Regex PhoneRegex = new(@"^0\d{9}$", RegexOptions.Compiled);
    private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
    private DataTable _teacherTable = new();
    private string? _currentTeacherStatus;
    private string? _currentTeacherAccountId;
    private string? _currentAvatarPath;
    private string? _pendingAvatarSourcePath;
    private PictureBox? _picTeacherAvatar;
    private Button? _btnChooseTeacherAvatar;
    private Button? _btnRemoveTeacherAvatar;
    private ComboBox? _cboTeacherDetailStatus;
    private ComboBox? _cboTeacherGender;

    public FrmTeacherManagement()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Quản lý giáo viên");
        ConfigureView();
        LoadTeachers();
        WireEvents();
    }

    private void ConfigureView()
    {
        LocalizeLabels();
        MinimumSize = FormHostHelpers.ScaleSize(this, new Size(1100, 680));
        splTeacherContent.Panel1MinSize = FormHostHelpers.ScaleForDpi(this, 360);
        splTeacherContent.Panel2MinSize = FormHostHelpers.ScaleForDpi(this, 420);
        splTeacherContent.SplitterWidth = FormHostHelpers.ScaleForDpi(this, 8);
        pnlTeacherFilterCard.Height = FormHostHelpers.ScaleForDpi(this, 96);
        flpTeacherActions.WrapContents = true;
        flpTeacherActions.Padding = FormHostHelpers.ScalePadding(this, new Padding(0, 8, 0, 0));
        AppTheme.StyleGrid(dgvTeacherList);
        AppTheme.StyleSecondaryButton(btnSearchTeacher);
        AppTheme.StyleSecondaryButton(btnRefreshTeacher);
        AppTheme.StylePrimaryButton(btnCreateTeacher);
        AppTheme.StylePrimaryButton(btnSaveTeacher);
        AppTheme.StylePrimaryButton(btnUpdateTeacher);
        AppTheme.StyleDangerButton(btnDeleteTeacher);
        InitializeGenderControl();
        InitializeStatusControls();
        InitializeAvatarControls();
        if (_btnChooseTeacherAvatar is not null)
        {
            AppTheme.StyleSecondaryButton(_btnChooseTeacherAvatar);
        }
        if (_btnRemoveTeacherAvatar is not null)
        {
            AppTheme.StyleSecondaryButton(_btnRemoveTeacherAvatar);
        }

        dgvTeacherList.AutoGenerateColumns = true;
        dgvTeacherList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvTeacherList.RowTemplate.Height = 42;
        txtTeacherAddress.ScrollBars = ScrollBars.Vertical;

        cboTeacherStatusFilter.SelectedIndex = 0;
    }

    private void WireEvents()
    {
        dgvTeacherList.SelectionChanged += (_, _) => PopulateDetailFromSelection();
        btnSearchTeacher.Click += (_, _) => LoadTeachers(txtTeacherKeyword.Text.Trim(), cboTeacherStatusFilter.Text);
        btnRefreshTeacher.Click += (_, _) => ResetFilters();
        btnCreateTeacher.Click += (_, _) => StartCreateTeacher();
        btnSaveTeacher.Click += (_, _) => SaveCurrentTeacher();
        btnUpdateTeacher.Click += (_, _) => SaveCurrentTeacher();
        btnDeleteTeacher.Click += (_, _) => DeleteSelectedTeacher();
        if (_btnChooseTeacherAvatar is not null)
        {
            _btnChooseTeacherAvatar.Click += (_, _) => ChooseTeacherAvatar();
        }
        if (_btnRemoveTeacherAvatar is not null)
        {
            _btnRemoveTeacherAvatar.Click += (_, _) => RemoveTeacherAvatar();
        }
    }

    private void LoadTeachers(string? keyword = null, string? status = null)
    {
        try
        {
            _teacherTable = AppRuntime.DataService.GetTeacherList(
                string.IsNullOrWhiteSpace(keyword) ? null : keyword,
                string.IsNullOrWhiteSpace(status) || status is "Tat ca" or "Tất cả" ? null : status);

            dgvTeacherList.DataSource = _teacherTable;
            SelectFirstTeacher();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTeacherManagement));
            MessageBox.Show(this, "Không tải được danh sách giáo viên. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void StartCreateTeacher()
    {
        ResetDetailEditor();
        txtTeacherCode.Text = AppRuntime.DataService.GetNextTeacherId();
        _currentTeacherStatus = "Đang dạy";
        if (_cboTeacherDetailStatus is not null)
        {
            _cboTeacherDetailStatus.Text = _currentTeacherStatus;
        }
        txtTeacherName.Focus();
    }

    private void SaveCurrentTeacher()
    {
        if (!ValidateEditor())
        {
            ValidationFeedback.ShowFirstError(this, errTeacher,
                txtTeacherCode,
                txtTeacherName,
                txtTeacherPhone,
                txtTeacherEmail);
            return;
        }

        try
        {
            var teacherId = txtTeacherCode.Text.Trim();
            var isCreating = AppRuntime.DataService.GetTeacherById(teacherId) is null;
            var teacher = new TeacherEntity
            {
                Id = teacherId,
                FullName = txtTeacherName.Text.Trim(),
                Phone = txtTeacherPhone.Text.Trim(),
                Email = txtTeacherEmail.Text.Trim(),
                Specialization = txtTeacherSpecialty.Text.Trim(),
                Address = txtTeacherAddress.Text.Trim(),
                Gender = GetTeacherGenderText(),
                AvatarPath = _currentAvatarPath,
                AccountId = _currentTeacherAccountId,
                Status = _cboTeacherDetailStatus?.Text ?? (string.IsNullOrWhiteSpace(_currentTeacherStatus) ? "Đang dạy" : _currentTeacherStatus),
                IsDeleted = false
            };

            teacher = AppRuntime.DataService.SaveTeacher(teacher);
            if (!string.IsNullOrWhiteSpace(_pendingAvatarSourcePath))
            {
                teacher.AvatarPath = AppRuntime.DataService.SaveTeacherAvatar(teacher.Id, _pendingAvatarSourcePath);
                teacher = AppRuntime.DataService.SaveTeacher(teacher);
                _pendingAvatarSourcePath = null;
            }

            _currentAvatarPath = teacher.AvatarPath;
            _currentTeacherStatus = teacher.Status;
            _currentTeacherAccountId = teacher.AccountId;

            LoadTeachers(txtTeacherKeyword.Text.Trim(), cboTeacherStatusFilter.Text);
            FocusTeacher(teacher.Id);
            MessageBox.Show(this, isCreating ? "Đã thêm giáo viên thành công." : "Đã cập nhật giáo viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTeacherManagement));
            MessageBox.Show(this, $"Không lưu được giáo viên: {ex.GetBaseException().Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DeleteSelectedTeacher()
    {
        if (string.IsNullOrWhiteSpace(txtTeacherCode.Text))
        {
            MessageBox.Show(this, "Hãy chọn giáo viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (AppRuntime.DataService.GetTeacherById(txtTeacherCode.Text.Trim()) is null)
        {
            MessageBox.Show(this, "Giáo viên chưa được lưu nên không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var dialog = new FrmConfirmDialog("Xóa giáo viên", "Bạn có chắc muốn xóa mềm giáo viên đang chọn không?");
        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        try
        {
            AppRuntime.DataService.SoftDeleteTeacher(txtTeacherCode.Text.Trim());
            LoadTeachers(txtTeacherKeyword.Text.Trim(), cboTeacherStatusFilter.Text);
            ResetDetailEditor();
            MessageBox.Show(this, "Đã xóa mềm giáo viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTeacherManagement));
            MessageBox.Show(this, "Không xóa được giáo viên. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void PopulateDetailFromSelection()
    {
        if (dgvTeacherList.CurrentRow?.DataBoundItem is not DataRowView rowView)
        {
            return;
        }

        var teacherId = rowView.Row[0]?.ToString();
        if (string.IsNullOrWhiteSpace(teacherId))
        {
            return;
        }

        try
        {
            var teacher = AppRuntime.DataService.GetTeacherById(teacherId);
            if (teacher is null)
            {
                return;
            }

            txtTeacherCode.Text = teacher.Id;
            txtTeacherName.Text = teacher.FullName;
            txtTeacherPhone.Text = teacher.Phone;
            txtTeacherEmail.Text = teacher.Email;
            txtTeacherSpecialty.Text = teacher.Specialization ?? string.Empty;
            txtTeacherAddress.Text = teacher.Address ?? string.Empty;
            txtTeacherNote.Text = teacher.Gender ?? string.Empty;
            SetTeacherGender(teacher.Gender);
            _currentAvatarPath = teacher.AvatarPath;
            _pendingAvatarSourcePath = null;
            LoadTeacherAvatarPreview(_currentAvatarPath);
            _currentTeacherStatus = teacher.Status;
            if (_cboTeacherDetailStatus is not null)
            {
                _cboTeacherDetailStatus.Text = string.IsNullOrWhiteSpace(teacher.Status) ? "Đang dạy" : teacher.Status;
            }
            _currentTeacherAccountId = teacher.AccountId;
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTeacherManagement));
            MessageBox.Show(this, "Không tải được chi tiết giáo viên. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SelectFirstTeacher()
    {
        if (dgvTeacherList.Rows.Count > 0)
        {
            dgvTeacherList.Rows[0].Selected = true;
            PopulateDetailFromSelection();
            return;
        }

        ResetDetailEditor();
    }

    private void FocusTeacher(string teacherId)
    {
        foreach (DataGridViewRow row in dgvTeacherList.Rows)
        {
            if ((row.Cells[0].Value?.ToString() ?? string.Empty).Equals(teacherId, StringComparison.OrdinalIgnoreCase))
            {
                row.Selected = true;
                dgvTeacherList.CurrentCell = row.Cells[0];
                PopulateDetailFromSelection();
                return;
            }
        }
    }

    private bool ValidateEditor()
    {
        errTeacher.Clear();

        if (string.IsNullOrWhiteSpace(txtTeacherCode.Text))
        {
            errTeacher.SetError(txtTeacherCode, "Mã giáo viên không được để trống.");
        }

        if (string.IsNullOrWhiteSpace(txtTeacherName.Text))
        {
            errTeacher.SetError(txtTeacherName, "Họ tên không được để trống.");
        }

        if (string.IsNullOrWhiteSpace(txtTeacherPhone.Text))
        {
            errTeacher.SetError(txtTeacherPhone, "Số điện thoại không được để trống.");
        }
        else if (!PhoneRegex.IsMatch(txtTeacherPhone.Text.Trim()))
        {
            errTeacher.SetError(txtTeacherPhone, "Số điện thoại phải bắt đầu bằng 0 và đủ 10 chữ số, không nhập chữ.");
        }

        if (string.IsNullOrWhiteSpace(txtTeacherEmail.Text))
        {
            errTeacher.SetError(txtTeacherEmail, "Email không được để trống.");
        }
        else if (!EmailRegex.IsMatch(txtTeacherEmail.Text.Trim()))
        {
            errTeacher.SetError(txtTeacherEmail, "Email phải có @ và tên miền, ví dụ ten@gmail.com.");
        }

        return string.IsNullOrWhiteSpace(errTeacher.GetError(txtTeacherCode))
            && string.IsNullOrWhiteSpace(errTeacher.GetError(txtTeacherName))
            && string.IsNullOrWhiteSpace(errTeacher.GetError(txtTeacherPhone))
            && string.IsNullOrWhiteSpace(errTeacher.GetError(txtTeacherEmail));
    }

    private void ResetDetailEditor()
    {
        errTeacher.Clear();
        txtTeacherCode.Clear();
        txtTeacherName.Clear();
        txtTeacherPhone.Clear();
        txtTeacherEmail.Clear();
        txtTeacherSpecialty.Clear();
        txtTeacherAddress.Clear();
        txtTeacherNote.Clear();
        SetTeacherGender(null);
        _currentAvatarPath = null;
        _pendingAvatarSourcePath = null;
        if (_picTeacherAvatar is not null)
        {
            _picTeacherAvatar.Image?.Dispose();
            _picTeacherAvatar.Image = null;
        }
        _currentTeacherStatus = null;
        if (_cboTeacherDetailStatus is not null)
        {
            _cboTeacherDetailStatus.Text = "Đang dạy";
        }
        _currentTeacherAccountId = null;
    }

    private void ResetFilters()
    {
        txtTeacherKeyword.Clear();
        cboTeacherStatusFilter.SelectedIndex = 0;
        LoadTeachers();
    }

    private void LocalizeLabels()
    {
        lblTeacherKeyword.Text = "Từ khóa";
        txtTeacherKeyword.PlaceholderText = "Mã giáo viên, họ tên hoặc số điện thoại";
        cboTeacherStatusFilter.Items.Clear();
        cboTeacherStatusFilter.Items.AddRange(["Tất cả", "Đang dạy", "Tạm nghỉ"]);

        lblTeacherStatus.Text = "Trạng thái";
        lblTeacherCode.Text = "Mã giáo viên";
        lblTeacherName.Text = "Họ và tên";
        lblTeacherPhone.Text = "Điện thoại";
        lblTeacherEmail.Text = "Email";
        lblTeacherSpecialty.Text = "Chuyên môn";
        lblTeacherAddress.Text = "Địa chỉ";
        lblTeacherNote.Text = "Giới tính";

        btnSearchTeacher.Text = "Tìm kiếm";
        btnRefreshTeacher.Text = "Làm mới";
        btnCreateTeacher.Text = "Thêm giáo viên";
        btnSaveTeacher.Text = "Lưu";
        btnUpdateTeacher.Text = "Cập nhật";
        btnDeleteTeacher.Text = "Xóa mềm";
    }

    private void InitializeGenderControl()
    {
        if (_cboTeacherGender is not null || tblTeacherDetail.Controls.ContainsKey("cboTeacherGender"))
        {
            return;
        }

        var genderRow = tblTeacherDetail.GetPositionFromControl(txtTeacherNote).Row;
        if (genderRow < 0)
        {
            genderRow = 6;
        }

        tblTeacherDetail.Controls.Remove(txtTeacherNote);
        txtTeacherNote.Visible = false;
        txtTeacherNote.Enabled = false;

        if (genderRow < tblTeacherDetail.RowStyles.Count)
        {
            tblTeacherDetail.RowStyles[genderRow].SizeType = SizeType.Absolute;
            tblTeacherDetail.RowStyles[genderRow].Height = FormHostHelpers.ScaleForDpi(this, 38);
        }

        _cboTeacherGender = new ComboBox
        {
            Name = "cboTeacherGender",
            Dock = DockStyle.Left,
            Width = FormHostHelpers.ScaleForDpi(this, 180),
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        _cboTeacherGender.Items.AddRange(["Nam", "Nữ", "Khác"]);
        _cboTeacherGender.SelectedIndex = 0;

        tblTeacherDetail.Controls.Add(_cboTeacherGender, 1, genderRow);
    }

    private string GetTeacherGenderText()
    {
        return _cboTeacherGender?.SelectedItem?.ToString()
            ?? _cboTeacherGender?.Text.Trim()
            ?? txtTeacherNote.Text.Trim();
    }

    private void SetTeacherGender(string? value)
    {
        if (_cboTeacherGender is null)
        {
            return;
        }

        var normalized = (value ?? string.Empty).Trim();
        var selected = normalized switch
        {
            "" => "Nam",
            "Male" or "Nam" => "Nam",
            "Female" or "Nữ" or "Nu" => "Nữ",
            _ => "Khác"
        };
        _cboTeacherGender.SelectedItem = selected;
        txtTeacherNote.Text = selected;
    }

    private void InitializeStatusControls()
    {
        if (_cboTeacherDetailStatus is not null || tblTeacherDetail.Controls.ContainsKey("cboTeacherDetailStatus"))
        {
            return;
        }

        var label = new Label
        {
            Name = "lblTeacherDetailStatus",
            Text = "Trạng thái",
            Anchor = AnchorStyles.Left,
            AutoSize = true
        };

        _cboTeacherDetailStatus = new ComboBox
        {
            Name = "cboTeacherDetailStatus",
            Dock = DockStyle.Fill,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        _cboTeacherDetailStatus.Items.AddRange(["Đang dạy", "Tạm nghỉ"]);
        _cboTeacherDetailStatus.SelectedIndex = 0;

        tblTeacherDetail.RowCount += 1;
        tblTeacherDetail.RowStyles.Add(new RowStyle());
        tblTeacherDetail.Controls.Add(label, 0, tblTeacherDetail.RowCount - 1);
        tblTeacherDetail.Controls.Add(_cboTeacherDetailStatus, 1, tblTeacherDetail.RowCount - 1);
    }

    private void InitializeAvatarControls()
    {
        _picTeacherAvatar ??= new PictureBox
        {
            Name = "picTeacherAvatar",
            Dock = DockStyle.Left,
            Width = FormHostHelpers.ScaleForDpi(this, 104),
            Height = FormHostHelpers.ScaleForDpi(this, 104),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.FromArgb(233, 239, 248),
            SizeMode = PictureBoxSizeMode.Zoom
        };

        _btnChooseTeacherAvatar ??= new Button
        {
            Name = "btnChooseTeacherAvatar",
            Text = "Chọn ảnh",
            Width = FormHostHelpers.ScaleForDpi(this, 116),
            Height = FormHostHelpers.ScaleForDpi(this, 32),
            Margin = new Padding(0, 8, 8, 0)
        };

        _btnRemoveTeacherAvatar ??= new Button
        {
            Name = "btnRemoveTeacherAvatar",
            Text = "Xóa ảnh",
            Width = FormHostHelpers.ScaleForDpi(this, 116),
            Height = FormHostHelpers.ScaleForDpi(this, 32),
            Margin = new Padding(8, 8, 0, 0)
        };

        if (tblTeacherDetail.Controls.ContainsKey("pnlTeacherAvatarHost"))
        {
            return;
        }

        var panel = new Panel
        {
            Name = "pnlTeacherAvatarHost",
            Dock = DockStyle.Fill,
            Height = FormHostHelpers.ScaleForDpi(this, 118)
        };

        var actionPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = true,
            Margin = Padding.Empty,
            Padding = new Padding(12, 8, 0, 0)
        };
        actionPanel.Controls.Add(_btnChooseTeacherAvatar);
        actionPanel.Controls.Add(_btnRemoveTeacherAvatar);
        panel.Controls.Add(actionPanel);
        panel.Controls.Add(_picTeacherAvatar);

        var label = new Label
        {
            Name = "lblTeacherAvatar",
            Text = "Avatar",
            Anchor = AnchorStyles.Left | AnchorStyles.Top,
            AutoSize = true
        };

        tblTeacherDetail.RowCount += 1;
        tblTeacherDetail.RowStyles.Add(new RowStyle(SizeType.Absolute, FormHostHelpers.ScaleForDpi(this, 128)));
        tblTeacherDetail.Controls.Add(label, 0, tblTeacherDetail.RowCount - 1);
        tblTeacherDetail.Controls.Add(panel, 1, tblTeacherDetail.RowCount - 1);
    }

    private void RemoveTeacherAvatar()
    {
        _pendingAvatarSourcePath = null;
        _currentAvatarPath = null;
        if (_picTeacherAvatar is not null)
        {
            _picTeacherAvatar.Image?.Dispose();
            _picTeacherAvatar.Image = null;
        }

        MessageBox.Show(this, "Đã bỏ ảnh đại diện. Bấm Lưu để áp dụng thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ChooseTeacherAvatar()
    {
        try
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Chọn avatar giáo viên"
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            if (!File.Exists(dialog.FileName))
            {
                MessageBox.Show(this, "File ảnh không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var extension = Path.GetExtension(dialog.FileName).ToLowerInvariant();
            if (extension is not ".jpg" and not ".jpeg" and not ".png" and not ".bmp")
            {
                MessageBox.Show(this, "Chỉ hỗ trợ ảnh .jpg, .jpeg, .png, .bmp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _pendingAvatarSourcePath = dialog.FileName;
            LoadTeacherAvatarPreview(dialog.FileName);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTeacherManagement));
            MessageBox.Show(this, "Không mở được ảnh giáo viên. Vui lòng kiểm tra log.txt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadTeacherAvatarPreview(string? avatarPath)
    {
        if (_picTeacherAvatar is null)
        {
            return;
        }

        _picTeacherAvatar.Image?.Dispose();
        _picTeacherAvatar.Image = null;

        if (string.IsNullOrWhiteSpace(avatarPath))
        {
            return;
        }

        var absolutePath = File.Exists(avatarPath)
            ? avatarPath
            : AppRuntime.DataService.ResolveAbsoluteImagePath(avatarPath);

        if (string.IsNullOrWhiteSpace(absolutePath) || !File.Exists(absolutePath))
        {
            return;
        }

        using var stream = new FileStream(absolutePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var image = Image.FromStream(stream);
        _picTeacherAvatar.Image = new Bitmap(image);
    }
}
