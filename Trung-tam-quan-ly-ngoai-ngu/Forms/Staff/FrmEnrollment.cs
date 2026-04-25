using System.Data;

namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmEnrollment : Form
{
    private DataTable _studentTable = new();
    private DataTable _classTable = new();

    public FrmEnrollment()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Ghi danh / xếp lớp");
        ConfigureView();
        BindMockData();
        WireEvents();
        ApplyResponsiveLayout();
        UpdateEnrollmentSummary();
    }

    private void ConfigureView()
    {
        LocalizeLabels();

        AppTheme.StyleGroupBox(grpEnrollmentStudentSelect);
        AppTheme.StyleGroupBox(grpEnrollmentClassSelect);
        AppTheme.StyleGroupBox(grpEnrollmentSummary);
        AppTheme.StyleGrid(dgvEnrollmentStudentList);
        AppTheme.StyleGrid(dgvEnrollmentClassList);
        AppTheme.StylePrimaryButton(btnCreateEnrollment);
        AppTheme.StyleSecondaryButton(btnRefreshEnrollment);
        AppTheme.StyleSecondaryButton(btnOpenTuitionReceipt);

        txtEnrollmentStudent.BackColor = Color.White;
        txtEnrollmentCourseClass.BackColor = Color.White;
        txtEnrollmentOriginalFee.BackColor = Color.White;
        txtEnrollmentFinalFee.BackColor = Color.White;
        txtEnrollmentNote.BackColor = Color.White;
        txtEnrollmentStudent.ScrollBars = ScrollBars.Vertical;
        txtEnrollmentCourseClass.ScrollBars = ScrollBars.Vertical;
        txtEnrollmentNote.ScrollBars = ScrollBars.Vertical;
        txtEnrollmentStudent.MinimumSize = new Size(0, 58);
        txtEnrollmentCourseClass.MinimumSize = new Size(0, 58);
        dtpEnrollmentDate.Dock = DockStyle.Fill;
        cboEnrollmentStatus.Dock = DockStyle.Fill;

        if (tblEnrollmentSummary.ColumnStyles.Count > 0)
        {
            tblEnrollmentSummary.ColumnStyles[0].Width = 136F;
        }

        flpEnrollmentActions.AutoSize = true;
        flpEnrollmentActions.WrapContents = true;
        flpEnrollmentActions.Dock = DockStyle.Fill;
        flpEnrollmentActions.Margin = new Padding(0, 12, 0, 0);
        flpEnrollmentActions.Padding = new Padding(0, 4, 0, 0);
        flpEnrollmentActions.FlowDirection = FlowDirection.LeftToRight;

        foreach (Control control in flpEnrollmentActions.Controls)
        {
            control.Margin = new Padding(0, 0, 10, 10);
        }

        dgvEnrollmentStudentList.RowTemplate.Height = 42;
        dgvEnrollmentClassList.RowTemplate.Height = 42;

        cboEnrollmentStatus.SelectedIndex = 1;
        dtpEnrollmentDate.Value = DateTime.Today;
        txtEnrollmentDiscount.Text = "0";
    }

    private void BindMockData()
    {
        _studentTable = DemoDataFactory.GetEnrollmentStudents();
        _classTable = DemoDataFactory.GetEnrollmentClasses();
        dgvEnrollmentStudentList.DataSource = _studentTable;
        dgvEnrollmentClassList.DataSource = _classTable;

        if (dgvEnrollmentStudentList.Rows.Count > 0)
        {
            dgvEnrollmentStudentList.Rows[0].Selected = true;
        }

        if (dgvEnrollmentClassList.Rows.Count > 0)
        {
            dgvEnrollmentClassList.Rows[0].Selected = true;
        }
    }

    private void WireEvents()
    {
        dgvEnrollmentStudentList.SelectionChanged += (_, _) => UpdateEnrollmentSummary();
        dgvEnrollmentClassList.SelectionChanged += (_, _) => UpdateEnrollmentSummary();
        txtEnrollmentDiscount.TextChanged += (_, _) => UpdateEnrollmentSummary();
        btnRefreshEnrollment.Click += (_, _) => ResetEnrollmentSummary();
        btnCreateEnrollment.Click += (_, _) => CreateEnrollment();
        btnOpenTuitionReceipt.Click += (_, _) =>
        {
            using var form = new FrmTuitionReceipt();
            form.ShowDialog(this);
        };

        Resize += (_, _) => ApplyResponsiveLayout();
    }

    private void ResetEnrollmentSummary()
    {
        txtEnrollmentDiscount.Text = "0";
        txtEnrollmentNote.Clear();
        cboEnrollmentStatus.SelectedIndex = 1;
        dtpEnrollmentDate.Value = DateTime.Today;
        UpdateEnrollmentSummary();
    }

    private void UpdateEnrollmentSummary()
    {
        txtEnrollmentStudent.Text = BuildSelectedStudentText();
        txtEnrollmentCourseClass.Text = BuildSelectedClassText();

        var originalFee = GetSelectedClassFee();
        txtEnrollmentOriginalFee.Text = FormatCurrency(originalFee);

        var discount = ParseMoney(txtEnrollmentDiscount.Text);
        var finalFee = Math.Max(0M, originalFee - discount);
        txtEnrollmentFinalFee.Text = FormatCurrency(finalFee);
    }

    private string BuildSelectedStudentText()
    {
        if (dgvEnrollmentStudentList.CurrentRow?.DataBoundItem is not DataRowView studentView)
        {
            return string.Empty;
        }

        var row = studentView.Row;
        return $"{row["Họ tên"]}\r\n{row["Mã học viên"]} - {row["Điện thoại"]}";
    }

    private string BuildSelectedClassText()
    {
        if (dgvEnrollmentClassList.CurrentRow?.DataBoundItem is not DataRowView classView)
        {
            return string.Empty;
        }

        var row = classView.Row;
        return $"{row["Tên lớp"]}\r\n{row["Lịch học"]} - Còn chỗ: {row["Còn chỗ"]}";
    }

    private decimal GetSelectedClassFee()
    {
        if (dgvEnrollmentClassList.CurrentRow?.DataBoundItem is not DataRowView classView)
        {
            return 0M;
        }

        return ParseMoney(classView.Row["Học phí"]?.ToString());
    }

    private void CreateEnrollment()
    {
        if (dgvEnrollmentStudentList.CurrentRow is null || dgvEnrollmentClassList.CurrentRow is null)
        {
            using var warning = new FrmStatusDialog("Ghi danh", "Cần chọn học viên và lớp học trước khi tạo ghi danh.");
            warning.ShowDialog(this);
            return;
        }

        using var dialog = new FrmStatusDialog(
            "Ghi danh / xếp lớp",
            $"Đã tạo ghi danh demo cho {txtEnrollmentStudent.Text.Split(Environment.NewLine)[0]} với mức học phí {txtEnrollmentFinalFee.Text}.");
        dialog.ShowDialog(this);
    }

    private void LocalizeLabels()
    {
        grpEnrollmentStudentSelect.Text = "1. Chọn học viên";
        grpEnrollmentClassSelect.Text = "2. Chọn lớp phù hợp";
        grpEnrollmentSummary.Text = "3. Xác nhận ghi danh";

        lblEnrollmentDate.Text = "Ngày đăng ký";
        lblEnrollmentStudent.Text = "Học viên";
        lblEnrollmentCourseClass.Text = "Lớp học";
        lblEnrollmentOriginalFee.Text = "Học phí gốc";
        lblEnrollmentDiscount.Text = "Giảm giá";
        lblEnrollmentFinalFee.Text = "Học phí cuối";
        lblEnrollmentStatus.Text = "Trạng thái";
        lblEnrollmentNote.Text = "Ghi chú";

        cboEnrollmentStatus.Items.Clear();
        cboEnrollmentStatus.Items.AddRange(["Chờ xác nhận", "Đã ghi danh", "Chờ thu học phí"]);

        btnCreateEnrollment.Text = "Tạo ghi danh";
        btnRefreshEnrollment.Text = "Làm mới";
        btnOpenTuitionReceipt.Text = "Mở thu học phí";
    }

    private void ApplyResponsiveLayout()
    {
        var width = ClientSize.Width - Padding.Horizontal;
        if (width <= 0)
        {
            return;
        }

        tblEnrollmentColumns.SuspendLayout();

        if (width < 980)
        {
            tblEnrollmentColumns.ColumnCount = 1;
            tblEnrollmentColumns.RowCount = 3;
            tblEnrollmentColumns.ColumnStyles.Clear();
            tblEnrollmentColumns.RowStyles.Clear();
            tblEnrollmentColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblEnrollmentColumns.RowStyles.Add(new RowStyle(SizeType.Absolute, 220F));
            tblEnrollmentColumns.RowStyles.Add(new RowStyle(SizeType.Absolute, 220F));
            tblEnrollmentColumns.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            tblEnrollmentColumns.SetColumn(grpEnrollmentStudentSelect, 0);
            tblEnrollmentColumns.SetRow(grpEnrollmentStudentSelect, 0);
            tblEnrollmentColumns.SetColumn(grpEnrollmentClassSelect, 0);
            tblEnrollmentColumns.SetRow(grpEnrollmentClassSelect, 1);
            tblEnrollmentColumns.SetColumn(grpEnrollmentSummary, 0);
            tblEnrollmentColumns.SetRow(grpEnrollmentSummary, 2);

            grpEnrollmentStudentSelect.Margin = new Padding(0, 0, 0, 12);
            grpEnrollmentClassSelect.Margin = new Padding(0, 0, 0, 12);
            grpEnrollmentSummary.Margin = Padding.Empty;

            if (tblEnrollmentSummary.ColumnStyles.Count > 0)
            {
                tblEnrollmentSummary.ColumnStyles[0].Width = 112F;
            }
        }
        else
        {
            tblEnrollmentColumns.ColumnCount = 3;
            tblEnrollmentColumns.RowCount = 1;
            tblEnrollmentColumns.ColumnStyles.Clear();
            tblEnrollmentColumns.RowStyles.Clear();
            tblEnrollmentColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31F));
            tblEnrollmentColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31F));
            tblEnrollmentColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38F));
            tblEnrollmentColumns.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            tblEnrollmentColumns.SetColumn(grpEnrollmentStudentSelect, 0);
            tblEnrollmentColumns.SetRow(grpEnrollmentStudentSelect, 0);
            tblEnrollmentColumns.SetColumn(grpEnrollmentClassSelect, 1);
            tblEnrollmentColumns.SetRow(grpEnrollmentClassSelect, 0);
            tblEnrollmentColumns.SetColumn(grpEnrollmentSummary, 2);
            tblEnrollmentColumns.SetRow(grpEnrollmentSummary, 0);

            grpEnrollmentStudentSelect.Margin = new Padding(0, 0, 12, 0);
            grpEnrollmentClassSelect.Margin = new Padding(0, 0, 12, 0);
            grpEnrollmentSummary.Margin = Padding.Empty;

            if (tblEnrollmentSummary.ColumnStyles.Count > 0)
            {
                tblEnrollmentSummary.ColumnStyles[0].Width = 136F;
            }
        }

        tblEnrollmentColumns.ResumeLayout(true);
    }

    private static decimal ParseMoney(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return 0M;
        }

        var digits = new string(value.Where(char.IsDigit).ToArray());
        return decimal.TryParse(digits, out var result) ? result : 0M;
    }

    private static string FormatCurrency(decimal value)
    {
        return string.Format("{0:N0} VND", value);
    }
}
