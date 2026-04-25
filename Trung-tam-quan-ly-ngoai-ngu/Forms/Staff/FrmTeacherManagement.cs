using System.Data;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Domain.Entities;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmTeacherManagement : Form
{
    private DataTable _teacherTable = new();
    private string? _currentTeacherStatus;
    private string? _currentTeacherAccountId;

    public FrmTeacherManagement()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Quan ly giao vien");
        ConfigureView();
        LoadTeachers();
        WireEvents();
    }

    private void ConfigureView()
    {
        LocalizeLabels();
        AppTheme.StyleGrid(dgvTeacherList);
        AppTheme.StyleSecondaryButton(btnSearchTeacher);
        AppTheme.StyleSecondaryButton(btnRefreshTeacher);
        AppTheme.StylePrimaryButton(btnCreateTeacher);
        AppTheme.StylePrimaryButton(btnSaveTeacher);
        AppTheme.StylePrimaryButton(btnUpdateTeacher);
        AppTheme.StyleDangerButton(btnDeleteTeacher);

        dgvTeacherList.AutoGenerateColumns = true;
        dgvTeacherList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvTeacherList.RowTemplate.Height = 42;

        cboTeacherStatusFilter.SelectedIndex = 0;
        txtTeacherNote.PlaceholderText = "Nam / Nu";
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
    }

    private void LoadTeachers(string? keyword = null, string? status = null)
    {
        try
        {
            _teacherTable = AppRuntime.DataService.GetTeacherList(
                string.IsNullOrWhiteSpace(keyword) ? null : keyword,
                string.IsNullOrWhiteSpace(status) || status == "Tat ca" ? null : status);

            dgvTeacherList.DataSource = _teacherTable;
            SelectFirstTeacher();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTeacherManagement));
            MessageBox.Show(this, "Khong tai duoc danh sach giao vien. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void StartCreateTeacher()
    {
        ResetDetailEditor();
        txtTeacherCode.Text = AppRuntime.DataService.GetNextTeacherId();
        _currentTeacherStatus = "Dang day";
        txtTeacherName.Focus();
    }

    private void SaveCurrentTeacher()
    {
        if (!ValidateEditor())
        {
            return;
        }

        try
        {
            var teacher = new TeacherEntity
            {
                Id = txtTeacherCode.Text.Trim(),
                FullName = txtTeacherName.Text.Trim(),
                Phone = txtTeacherPhone.Text.Trim(),
                Email = txtTeacherEmail.Text.Trim(),
                Specialization = txtTeacherSpecialty.Text.Trim(),
                Address = txtTeacherAddress.Text.Trim(),
                Gender = txtTeacherNote.Text.Trim(),
                AvatarPath = null,
                AccountId = _currentTeacherAccountId,
                Status = string.IsNullOrWhiteSpace(_currentTeacherStatus) ? "Dang day" : _currentTeacherStatus,
                IsDeleted = false
            };

            teacher = AppRuntime.DataService.SaveTeacher(teacher);
            _currentTeacherStatus = teacher.Status;
            _currentTeacherAccountId = teacher.AccountId;

            LoadTeachers(txtTeacherKeyword.Text.Trim(), cboTeacherStatusFilter.Text);
            FocusTeacher(teacher.Id);
            MessageBox.Show(this, "Da luu giao vien thanh cong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTeacherManagement));
            MessageBox.Show(this, "Khong luu duoc giao vien. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DeleteSelectedTeacher()
    {
        if (string.IsNullOrWhiteSpace(txtTeacherCode.Text))
        {
            return;
        }

        using var dialog = new FrmConfirmDialog("Xoa giao vien", "Ban co chac muon xoa mem giao vien dang chon khong?");
        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        try
        {
            AppRuntime.DataService.SoftDeleteTeacher(txtTeacherCode.Text.Trim());
            LoadTeachers(txtTeacherKeyword.Text.Trim(), cboTeacherStatusFilter.Text);
            ResetDetailEditor();
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTeacherManagement));
            MessageBox.Show(this, "Khong xoa duoc giao vien. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _currentTeacherStatus = teacher.Status;
            _currentTeacherAccountId = teacher.AccountId;
        }
        catch (Exception ex)
        {
            ErrorLogger.Log(ex, nameof(FrmTeacherManagement));
            MessageBox.Show(this, "Khong tai duoc chi tiet giao vien. Vui long kiem tra log.txt.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            errTeacher.SetError(txtTeacherCode, "Ma giao vien khong duoc de trong.");
        }

        if (string.IsNullOrWhiteSpace(txtTeacherName.Text))
        {
            errTeacher.SetError(txtTeacherName, "Ho ten khong duoc de trong.");
        }

        if (string.IsNullOrWhiteSpace(txtTeacherPhone.Text))
        {
            errTeacher.SetError(txtTeacherPhone, "So dien thoai khong duoc de trong.");
        }

        if (string.IsNullOrWhiteSpace(txtTeacherEmail.Text))
        {
            errTeacher.SetError(txtTeacherEmail, "Email khong duoc de trong.");
        }
        else if (!txtTeacherEmail.Text.Contains('@') || !txtTeacherEmail.Text.Contains('.'))
        {
            errTeacher.SetError(txtTeacherEmail, "Email khong hop le.");
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
        _currentTeacherStatus = null;
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
        lblTeacherKeyword.Text = "Tu khoa";
        txtTeacherKeyword.PlaceholderText = "Ma giao vien, ho ten hoac so dien thoai";
        cboTeacherStatusFilter.Items.Clear();
        cboTeacherStatusFilter.Items.AddRange(["Tat ca", "Dang day", "Tam nghi"]);

        lblTeacherStatus.Text = "Trang thai";
        lblTeacherCode.Text = "Ma giao vien";
        lblTeacherName.Text = "Ho va ten";
        lblTeacherPhone.Text = "Dien thoai";
        lblTeacherEmail.Text = "Email";
        lblTeacherSpecialty.Text = "Chuyen mon";
        lblTeacherAddress.Text = "Dia chi";
        lblTeacherNote.Text = "Gioi tinh";

        btnSearchTeacher.Text = "Tim kiem";
        btnRefreshTeacher.Text = "Lam moi";
        btnCreateTeacher.Text = "Them giao vien";
        btnSaveTeacher.Text = "Luu";
        btnUpdateTeacher.Text = "Cap nhat";
        btnDeleteTeacher.Text = "Xoa mem";
    }
}
