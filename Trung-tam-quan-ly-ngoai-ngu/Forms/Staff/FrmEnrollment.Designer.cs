namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmEnrollment
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tblEnrollmentRoot;
    private TableLayoutPanel tblEnrollmentColumns;
    private GroupBox grpEnrollmentStudentSelect;
    private GroupBox grpEnrollmentClassSelect;
    private GroupBox grpEnrollmentSummary;
    private DataGridView dgvEnrollmentStudentList;
    private DataGridView dgvEnrollmentClassList;
    private TableLayoutPanel tblEnrollmentSummary;
    private Label lblEnrollmentDate;
    private DateTimePicker dtpEnrollmentDate;
    private Label lblEnrollmentStudent;
    private TextBox txtEnrollmentStudent;
    private Label lblEnrollmentCourseClass;
    private TextBox txtEnrollmentCourseClass;
    private Label lblEnrollmentOriginalFee;
    private TextBox txtEnrollmentOriginalFee;
    private Label lblEnrollmentDiscount;
    private TextBox txtEnrollmentDiscount;
    private Label lblEnrollmentFinalFee;
    private TextBox txtEnrollmentFinalFee;
    private Label lblEnrollmentStatus;
    private ComboBox cboEnrollmentStatus;
    private Label lblEnrollmentNote;
    private TextBox txtEnrollmentNote;
    private FlowLayoutPanel flpEnrollmentActions;
    private Button btnCreateEnrollment;
    private Button btnRefreshEnrollment;
    private Button btnOpenTuitionReceipt;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        tblEnrollmentRoot = new TableLayoutPanel();
        tblEnrollmentColumns = new TableLayoutPanel();
        grpEnrollmentStudentSelect = new GroupBox();
        dgvEnrollmentStudentList = new DataGridView();
        grpEnrollmentClassSelect = new GroupBox();
        dgvEnrollmentClassList = new DataGridView();
        grpEnrollmentSummary = new GroupBox();
        tblEnrollmentSummary = new TableLayoutPanel();
        lblEnrollmentDate = new Label();
        dtpEnrollmentDate = new DateTimePicker();
        lblEnrollmentStudent = new Label();
        txtEnrollmentStudent = new TextBox();
        lblEnrollmentCourseClass = new Label();
        txtEnrollmentCourseClass = new TextBox();
        lblEnrollmentOriginalFee = new Label();
        txtEnrollmentOriginalFee = new TextBox();
        lblEnrollmentDiscount = new Label();
        txtEnrollmentDiscount = new TextBox();
        lblEnrollmentFinalFee = new Label();
        txtEnrollmentFinalFee = new TextBox();
        lblEnrollmentStatus = new Label();
        cboEnrollmentStatus = new ComboBox();
        lblEnrollmentNote = new Label();
        txtEnrollmentNote = new TextBox();
        flpEnrollmentActions = new FlowLayoutPanel();
        btnCreateEnrollment = new Button();
        btnRefreshEnrollment = new Button();
        btnOpenTuitionReceipt = new Button();
        tblEnrollmentRoot.SuspendLayout();
        tblEnrollmentColumns.SuspendLayout();
        grpEnrollmentStudentSelect.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvEnrollmentStudentList).BeginInit();
        grpEnrollmentClassSelect.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvEnrollmentClassList).BeginInit();
        grpEnrollmentSummary.SuspendLayout();
        tblEnrollmentSummary.SuspendLayout();
        flpEnrollmentActions.SuspendLayout();
        SuspendLayout();
        // 
        // tblEnrollmentRoot
        // 
        tblEnrollmentRoot.ColumnCount = 1;
        tblEnrollmentRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblEnrollmentRoot.Controls.Add(tblEnrollmentColumns, 0, 0);
        tblEnrollmentRoot.Dock = DockStyle.Fill;
        tblEnrollmentRoot.Location = new Point(12, 12);
        tblEnrollmentRoot.Name = "tblEnrollmentRoot";
        tblEnrollmentRoot.RowCount = 1;
        tblEnrollmentRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblEnrollmentRoot.Size = new Size(1116, 626);
        tblEnrollmentRoot.AutoScroll = false;
        tblEnrollmentRoot.TabIndex = 0;
        // 
        // tblEnrollmentColumns
        // 
        tblEnrollmentColumns.ColumnCount = 3;
        tblEnrollmentColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
        tblEnrollmentColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
        tblEnrollmentColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
        tblEnrollmentColumns.Controls.Add(grpEnrollmentStudentSelect, 0, 0);
        tblEnrollmentColumns.Controls.Add(grpEnrollmentClassSelect, 1, 0);
        tblEnrollmentColumns.Controls.Add(grpEnrollmentSummary, 2, 0);
        tblEnrollmentColumns.Dock = DockStyle.Fill;
        tblEnrollmentColumns.Location = new Point(0, 0);
        tblEnrollmentColumns.Margin = new Padding(0);
        tblEnrollmentColumns.Name = "tblEnrollmentColumns";
        tblEnrollmentColumns.RowCount = 1;
        tblEnrollmentColumns.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblEnrollmentColumns.Size = new Size(1116, 626);
        tblEnrollmentColumns.AutoScroll = false;
        tblEnrollmentColumns.TabIndex = 0;
        // 
        // grpEnrollmentStudentSelect
        // 
        grpEnrollmentStudentSelect.Controls.Add(dgvEnrollmentStudentList);
        grpEnrollmentStudentSelect.Dock = DockStyle.Fill;
        grpEnrollmentStudentSelect.Location = new Point(0, 0);
        grpEnrollmentStudentSelect.Margin = new Padding(0, 0, 12, 0);
        grpEnrollmentStudentSelect.Name = "grpEnrollmentStudentSelect";
        grpEnrollmentStudentSelect.Padding = new Padding(12);
        grpEnrollmentStudentSelect.Size = new Size(367, 626);
        grpEnrollmentStudentSelect.TabIndex = 0;
        grpEnrollmentStudentSelect.TabStop = false;
        grpEnrollmentStudentSelect.Text = "1. Chọn học viên";
        // 
        // dgvEnrollmentStudentList
        // 
        dgvEnrollmentStudentList.AllowUserToAddRows = false;
        dgvEnrollmentStudentList.AllowUserToDeleteRows = false;
        dgvEnrollmentStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvEnrollmentStudentList.BackgroundColor = Color.White;
        dgvEnrollmentStudentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvEnrollmentStudentList.Dock = DockStyle.Fill;
        dgvEnrollmentStudentList.Location = new Point(12, 32);
        dgvEnrollmentStudentList.MultiSelect = false;
        dgvEnrollmentStudentList.Name = "dgvEnrollmentStudentList";
        dgvEnrollmentStudentList.ReadOnly = true;
        dgvEnrollmentStudentList.RowHeadersVisible = false;
        dgvEnrollmentStudentList.RowHeadersWidth = 51;
        dgvEnrollmentStudentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvEnrollmentStudentList.Size = new Size(343, 582);
        dgvEnrollmentStudentList.TabIndex = 0;
        // 
        // grpEnrollmentClassSelect
        // 
        grpEnrollmentClassSelect.Controls.Add(dgvEnrollmentClassList);
        grpEnrollmentClassSelect.Dock = DockStyle.Fill;
        grpEnrollmentClassSelect.Location = new Point(379, 0);
        grpEnrollmentClassSelect.Margin = new Padding(0, 0, 12, 0);
        grpEnrollmentClassSelect.Name = "grpEnrollmentClassSelect";
        grpEnrollmentClassSelect.Padding = new Padding(12);
        grpEnrollmentClassSelect.Size = new Size(367, 626);
        grpEnrollmentClassSelect.TabIndex = 1;
        grpEnrollmentClassSelect.TabStop = false;
        grpEnrollmentClassSelect.Text = "2. Chọn lớp phù hợp";
        // 
        // dgvEnrollmentClassList
        // 
        dgvEnrollmentClassList.AllowUserToAddRows = false;
        dgvEnrollmentClassList.AllowUserToDeleteRows = false;
        dgvEnrollmentClassList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvEnrollmentClassList.BackgroundColor = Color.White;
        dgvEnrollmentClassList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvEnrollmentClassList.Dock = DockStyle.Fill;
        dgvEnrollmentClassList.Location = new Point(12, 32);
        dgvEnrollmentClassList.MultiSelect = false;
        dgvEnrollmentClassList.Name = "dgvEnrollmentClassList";
        dgvEnrollmentClassList.ReadOnly = true;
        dgvEnrollmentClassList.RowHeadersVisible = false;
        dgvEnrollmentClassList.RowHeadersWidth = 51;
        dgvEnrollmentClassList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvEnrollmentClassList.Size = new Size(343, 582);
        dgvEnrollmentClassList.TabIndex = 0;
        // 
        // grpEnrollmentSummary
        // 
        grpEnrollmentSummary.Controls.Add(tblEnrollmentSummary);
        grpEnrollmentSummary.Dock = DockStyle.Fill;
        grpEnrollmentSummary.Location = new Point(758, 0);
        grpEnrollmentSummary.Margin = new Padding(0);
        grpEnrollmentSummary.Name = "grpEnrollmentSummary";
        grpEnrollmentSummary.Padding = new Padding(14, 12, 14, 14);
        grpEnrollmentSummary.Size = new Size(358, 626);
        grpEnrollmentSummary.TabIndex = 2;
        grpEnrollmentSummary.TabStop = false;
        grpEnrollmentSummary.Text = "3. Xác nhận ghi danh";
        // 
        // tblEnrollmentSummary
        // 
        tblEnrollmentSummary.ColumnCount = 2;
        tblEnrollmentSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        tblEnrollmentSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblEnrollmentSummary.Controls.Add(lblEnrollmentDate, 0, 0);
        tblEnrollmentSummary.Controls.Add(dtpEnrollmentDate, 1, 0);
        tblEnrollmentSummary.Controls.Add(lblEnrollmentStudent, 0, 1);
        tblEnrollmentSummary.Controls.Add(txtEnrollmentStudent, 1, 1);
        tblEnrollmentSummary.Controls.Add(lblEnrollmentCourseClass, 0, 2);
        tblEnrollmentSummary.Controls.Add(txtEnrollmentCourseClass, 1, 2);
        tblEnrollmentSummary.Controls.Add(lblEnrollmentOriginalFee, 0, 3);
        tblEnrollmentSummary.Controls.Add(txtEnrollmentOriginalFee, 1, 3);
        tblEnrollmentSummary.Controls.Add(lblEnrollmentDiscount, 0, 4);
        tblEnrollmentSummary.Controls.Add(txtEnrollmentDiscount, 1, 4);
        tblEnrollmentSummary.Controls.Add(lblEnrollmentFinalFee, 0, 5);
        tblEnrollmentSummary.Controls.Add(txtEnrollmentFinalFee, 1, 5);
        tblEnrollmentSummary.Controls.Add(lblEnrollmentStatus, 0, 6);
        tblEnrollmentSummary.Controls.Add(cboEnrollmentStatus, 1, 6);
        tblEnrollmentSummary.Controls.Add(lblEnrollmentNote, 0, 7);
        tblEnrollmentSummary.Controls.Add(txtEnrollmentNote, 1, 7);
        tblEnrollmentSummary.Controls.Add(flpEnrollmentActions, 0, 8);
        tblEnrollmentSummary.Dock = DockStyle.Fill;
        tblEnrollmentSummary.Location = new Point(14, 36);
        tblEnrollmentSummary.Name = "tblEnrollmentSummary";
        tblEnrollmentSummary.RowCount = 9;
        tblEnrollmentSummary.RowStyles.Add(new RowStyle());
        tblEnrollmentSummary.RowStyles.Add(new RowStyle());
        tblEnrollmentSummary.RowStyles.Add(new RowStyle());
        tblEnrollmentSummary.RowStyles.Add(new RowStyle());
        tblEnrollmentSummary.RowStyles.Add(new RowStyle());
        tblEnrollmentSummary.RowStyles.Add(new RowStyle());
        tblEnrollmentSummary.RowStyles.Add(new RowStyle());
        tblEnrollmentSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblEnrollmentSummary.RowStyles.Add(new RowStyle());
        tblEnrollmentSummary.Size = new Size(330, 576);
        tblEnrollmentSummary.AutoScroll = true;
        tblEnrollmentSummary.TabIndex = 0;
        // 
        // lblEnrollmentDate
        // 
        lblEnrollmentDate.Anchor = AnchorStyles.Left;
        lblEnrollmentDate.AutoSize = true;
        lblEnrollmentDate.Location = new Point(3, 6);
        lblEnrollmentDate.Name = "lblEnrollmentDate";
        lblEnrollmentDate.Size = new Size(87, 28);
        lblEnrollmentDate.AutoSize = true;
        lblEnrollmentDate.TabIndex = 0;
        lblEnrollmentDate.Text = "Ngày đăng ký";
        // 
        // dtpEnrollmentDate
        // 
        dtpEnrollmentDate.Dock = DockStyle.Fill;
        dtpEnrollmentDate.Format = DateTimePickerFormat.Short;
        dtpEnrollmentDate.Location = new Point(123, 3);
        dtpEnrollmentDate.Name = "dtpEnrollmentDate";
        dtpEnrollmentDate.Size = new Size(204, 27);
        dtpEnrollmentDate.TabIndex = 1;
        // 
        // lblEnrollmentStudent
        // 
        lblEnrollmentStudent.Anchor = AnchorStyles.Left;
        lblEnrollmentStudent.AutoSize = true;
        lblEnrollmentStudent.Location = new Point(3, 39);
        lblEnrollmentStudent.Name = "lblEnrollmentStudent";
        lblEnrollmentStudent.Size = new Size(70, 28);
        lblEnrollmentStudent.AutoSize = true;
        lblEnrollmentStudent.TabIndex = 2;
        lblEnrollmentStudent.Text = "Học viên";
        // 
        // txtEnrollmentStudent
        // 
        txtEnrollmentStudent.Dock = DockStyle.Fill;
        txtEnrollmentStudent.Location = new Point(123, 36);
        txtEnrollmentStudent.Multiline = true;
        txtEnrollmentStudent.Name = "txtEnrollmentStudent";
        txtEnrollmentStudent.ReadOnly = true;
        txtEnrollmentStudent.Size = new Size(204, 48);
        txtEnrollmentStudent.TabIndex = 3;
        // 
        // lblEnrollmentCourseClass
        // 
        lblEnrollmentCourseClass.Anchor = AnchorStyles.Left;
        lblEnrollmentCourseClass.AutoSize = true;
        lblEnrollmentCourseClass.Location = new Point(3, 96);
        lblEnrollmentCourseClass.Name = "lblEnrollmentCourseClass";
        lblEnrollmentCourseClass.Size = new Size(61, 28);
        lblEnrollmentCourseClass.AutoSize = true;
        lblEnrollmentCourseClass.TabIndex = 4;
        lblEnrollmentCourseClass.Text = "Lớp học";
        // 
        // txtEnrollmentCourseClass
        // 
        txtEnrollmentCourseClass.Dock = DockStyle.Fill;
        txtEnrollmentCourseClass.Location = new Point(123, 90);
        txtEnrollmentCourseClass.Multiline = true;
        txtEnrollmentCourseClass.Name = "txtEnrollmentCourseClass";
        txtEnrollmentCourseClass.ReadOnly = true;
        txtEnrollmentCourseClass.Size = new Size(204, 48);
        txtEnrollmentCourseClass.TabIndex = 5;
        // 
        // lblEnrollmentOriginalFee
        // 
        lblEnrollmentOriginalFee.Anchor = AnchorStyles.Left;
        lblEnrollmentOriginalFee.AutoSize = true;
        lblEnrollmentOriginalFee.Location = new Point(3, 150);
        lblEnrollmentOriginalFee.Name = "lblEnrollmentOriginalFee";
        lblEnrollmentOriginalFee.Size = new Size(85, 28);
        lblEnrollmentOriginalFee.AutoSize = true;
        lblEnrollmentOriginalFee.TabIndex = 6;
        lblEnrollmentOriginalFee.Text = "Hoc phi goc";
        // 
        // txtEnrollmentOriginalFee
        // 
        txtEnrollmentOriginalFee.Dock = DockStyle.Fill;
        txtEnrollmentOriginalFee.Location = new Point(123, 144);
        txtEnrollmentOriginalFee.Name = "txtEnrollmentOriginalFee";
        txtEnrollmentOriginalFee.ReadOnly = true;
        txtEnrollmentOriginalFee.Size = new Size(204, 27);
        txtEnrollmentOriginalFee.TabIndex = 7;
        // 
        // lblEnrollmentDiscount
        // 
        lblEnrollmentDiscount.Anchor = AnchorStyles.Left;
        lblEnrollmentDiscount.AutoSize = true;
        lblEnrollmentDiscount.Location = new Point(3, 183);
        lblEnrollmentDiscount.Name = "lblEnrollmentDiscount";
        lblEnrollmentDiscount.Size = new Size(62, 28);
        lblEnrollmentDiscount.AutoSize = true;
        lblEnrollmentDiscount.TabIndex = 8;
        lblEnrollmentDiscount.Text = "Giam gia";
        // 
        // txtEnrollmentDiscount
        // 
        txtEnrollmentDiscount.Dock = DockStyle.Fill;
        txtEnrollmentDiscount.Location = new Point(123, 177);
        txtEnrollmentDiscount.Name = "txtEnrollmentDiscount";
        txtEnrollmentDiscount.Size = new Size(204, 27);
        txtEnrollmentDiscount.TabIndex = 9;
        // 
        // lblEnrollmentFinalFee
        // 
        lblEnrollmentFinalFee.Anchor = AnchorStyles.Left;
        lblEnrollmentFinalFee.AutoSize = true;
        lblEnrollmentFinalFee.Location = new Point(3, 216);
        lblEnrollmentFinalFee.Name = "lblEnrollmentFinalFee";
        lblEnrollmentFinalFee.Size = new Size(86, 28);
        lblEnrollmentFinalFee.AutoSize = true;
        lblEnrollmentFinalFee.TabIndex = 10;
        lblEnrollmentFinalFee.Text = "Hoc phi cuoi";
        // 
        // txtEnrollmentFinalFee
        // 
        txtEnrollmentFinalFee.Dock = DockStyle.Fill;
        txtEnrollmentFinalFee.Location = new Point(123, 210);
        txtEnrollmentFinalFee.Name = "txtEnrollmentFinalFee";
        txtEnrollmentFinalFee.ReadOnly = true;
        txtEnrollmentFinalFee.Size = new Size(204, 27);
        txtEnrollmentFinalFee.TabIndex = 11;
        // 
        // lblEnrollmentStatus
        // 
        lblEnrollmentStatus.Anchor = AnchorStyles.Left;
        lblEnrollmentStatus.AutoSize = true;
        lblEnrollmentStatus.Location = new Point(3, 249);
        lblEnrollmentStatus.Name = "lblEnrollmentStatus";
        lblEnrollmentStatus.Size = new Size(75, 28);
        lblEnrollmentStatus.AutoSize = true;
        lblEnrollmentStatus.TabIndex = 12;
        lblEnrollmentStatus.Text = "Trang thai";
        // 
        // cboEnrollmentStatus
        // 
        cboEnrollmentStatus.Dock = DockStyle.Left;
        cboEnrollmentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEnrollmentStatus.FormattingEnabled = true;
        cboEnrollmentStatus.Items.AddRange(new object[] { "Chờ xác nhận", "Đã ghi danh", "Chờ thu học phí" });
        cboEnrollmentStatus.Location = new Point(123, 243);
        cboEnrollmentStatus.Name = "cboEnrollmentStatus";
        cboEnrollmentStatus.Size = new Size(180, 28);
        cboEnrollmentStatus.TabIndex = 13;
        // 
        // lblEnrollmentNote
        // 
        lblEnrollmentNote.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        lblEnrollmentNote.AutoSize = true;
        lblEnrollmentNote.Location = new Point(3, 279);
        lblEnrollmentNote.Name = "lblEnrollmentNote";
        lblEnrollmentNote.Size = new Size(57, 28);
        lblEnrollmentNote.AutoSize = true;
        lblEnrollmentNote.TabIndex = 14;
        lblEnrollmentNote.Text = "Ghi chu";
        // 
        // txtEnrollmentNote
        // 
        txtEnrollmentNote.Dock = DockStyle.Fill;
        txtEnrollmentNote.Location = new Point(123, 276);
        txtEnrollmentNote.Multiline = true;
        txtEnrollmentNote.Name = "txtEnrollmentNote";
        txtEnrollmentNote.ScrollBars = ScrollBars.Vertical;
        txtEnrollmentNote.Size = new Size(204, 245);
        txtEnrollmentNote.TabIndex = 15;
        // 
        // flpEnrollmentActions
        // 
        flpEnrollmentActions.AutoSize = true;
        tblEnrollmentSummary.SetColumnSpan(flpEnrollmentActions, 2);
        flpEnrollmentActions.Controls.Add(btnCreateEnrollment);
        flpEnrollmentActions.Controls.Add(btnRefreshEnrollment);
        flpEnrollmentActions.Controls.Add(btnOpenTuitionReceipt);
        flpEnrollmentActions.Dock = DockStyle.Fill;
        flpEnrollmentActions.Location = new Point(0, 524);
        flpEnrollmentActions.Margin = new Padding(0);
        flpEnrollmentActions.Name = "flpEnrollmentActions";
        flpEnrollmentActions.Size = new Size(330, 52);
        flpEnrollmentActions.AutoScroll = false;
        flpEnrollmentActions.TabIndex = 16;
        // 
        // btnCreateEnrollment
        // 
        btnCreateEnrollment.Location = new Point(3, 3);
        btnCreateEnrollment.Name = "btnCreateEnrollment";
        btnCreateEnrollment.Size = new Size(112, 40);
        btnCreateEnrollment.TabIndex = 0;
        btnCreateEnrollment.Text = "Tạo ghi danh";
        btnCreateEnrollment.UseVisualStyleBackColor = true;
        // 
        // btnRefreshEnrollment
        // 
        btnRefreshEnrollment.Location = new Point(121, 3);
        btnRefreshEnrollment.Name = "btnRefreshEnrollment";
        btnRefreshEnrollment.Size = new Size(100, 40);
        btnRefreshEnrollment.TabIndex = 1;
        btnRefreshEnrollment.Text = "Làm mới";
        btnRefreshEnrollment.UseVisualStyleBackColor = true;
        // 
        // btnOpenTuitionReceipt
        // 
        btnOpenTuitionReceipt.Location = new Point(3, 49);
        btnOpenTuitionReceipt.Name = "btnOpenTuitionReceipt";
        btnOpenTuitionReceipt.Size = new Size(170, 40);
        btnOpenTuitionReceipt.TabIndex = 2;
        btnOpenTuitionReceipt.Text = "Sang thu học phí";
        btnOpenTuitionReceipt.UseVisualStyleBackColor = true;
        // 
        // FrmEnrollment
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(1140, 650);
        Font = new Font("Segoe UI", 10F);
        Controls.Add(tblEnrollmentRoot);
        MinimumSize = new Size(980, 620);
        Name = "FrmEnrollment";
        Padding = new Padding(12);
        Text = "Ghi danh / xếp lớp";
        tblEnrollmentRoot.ResumeLayout(false);
        tblEnrollmentColumns.ResumeLayout(false);
        grpEnrollmentStudentSelect.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvEnrollmentStudentList).EndInit();
        grpEnrollmentClassSelect.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvEnrollmentClassList).EndInit();
        grpEnrollmentSummary.ResumeLayout(false);
        tblEnrollmentSummary.ResumeLayout(false);
        tblEnrollmentSummary.PerformLayout();
        flpEnrollmentActions.ResumeLayout(false);
        AutoScroll = true;
        ResumeLayout(false);
    }
}

