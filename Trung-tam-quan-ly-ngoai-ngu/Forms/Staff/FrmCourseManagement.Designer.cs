namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmCourseManagement
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlCourseFilterCard;
    private TextBox txtCourseKeyword;
    private ComboBox cboCourseStatusFilter;
    private Button btnSearchCourse;
    private Button btnRefreshCourse;
    private DataGridView dgvCourseList;
    private GroupBox grpCourseInfo;
    private Button btnCreateCourse;
    private Button btnSaveCourse;
    private Button btnUpdateCourse;
    private Button btnDeleteCourse;
    private TableLayoutPanel tblCourseRoot;
    private Label lblCourseKeyword;
    private Label lblCourseStatus;
    private SplitContainer splCourseContent;
    private TableLayoutPanel tblCourseDetail;
    private Label lblCourseCode;
    private TextBox txtCourseCode;
    private Label lblCourseName;
    private TextBox txtCourseName;
    private Label lblCourseLevel;
    private TextBox txtCourseLevel;
    private Label lblCourseFee;
    private TextBox txtCourseFee;
    private Label lblCourseDescription;
    private TextBox txtCourseDescription;
    private GroupBox grpCourseClassList;
    private DataGridView dgvCourseClassList;
    private FlowLayoutPanel flpCourseActions;

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
        pnlCourseFilterCard = new Panel();
        lblCourseKeyword = new Label();
        txtCourseKeyword = new TextBox();
        lblCourseStatus = new Label();
        cboCourseStatusFilter = new ComboBox();
        btnSearchCourse = new Button();
        btnRefreshCourse = new Button();
        dgvCourseList = new DataGridView();
        grpCourseInfo = new GroupBox();
        tblCourseDetail = new TableLayoutPanel();
        lblCourseCode = new Label();
        txtCourseCode = new TextBox();
        lblCourseName = new Label();
        txtCourseName = new TextBox();
        lblCourseLevel = new Label();
        txtCourseLevel = new TextBox();
        lblCourseFee = new Label();
        txtCourseFee = new TextBox();
        lblCourseDescription = new Label();
        txtCourseDescription = new TextBox();
        btnCreateCourse = new Button();
        btnSaveCourse = new Button();
        btnUpdateCourse = new Button();
        btnDeleteCourse = new Button();
        tblCourseRoot = new TableLayoutPanel();
        splCourseContent = new SplitContainer();
        grpCourseClassList = new GroupBox();
        dgvCourseClassList = new DataGridView();
        flpCourseActions = new FlowLayoutPanel();
        pnlCourseFilterCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCourseList).BeginInit();
        grpCourseInfo.SuspendLayout();
        tblCourseDetail.SuspendLayout();
        tblCourseRoot.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splCourseContent).BeginInit();
        splCourseContent.Panel1.SuspendLayout();
        splCourseContent.Panel2.SuspendLayout();
        splCourseContent.SuspendLayout();
        grpCourseClassList.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCourseClassList).BeginInit();
        flpCourseActions.SuspendLayout();
        SuspendLayout();
        // 
        // pnlCourseFilterCard
        // 
        pnlCourseFilterCard.BorderStyle = BorderStyle.FixedSingle;
        pnlCourseFilterCard.Controls.Add(btnRefreshCourse);
        pnlCourseFilterCard.Controls.Add(btnSearchCourse);
        pnlCourseFilterCard.Controls.Add(cboCourseStatusFilter);
        pnlCourseFilterCard.Controls.Add(lblCourseStatus);
        pnlCourseFilterCard.Controls.Add(txtCourseKeyword);
        pnlCourseFilterCard.Controls.Add(lblCourseKeyword);
        pnlCourseFilterCard.Dock = DockStyle.Fill;
        pnlCourseFilterCard.Location = new Point(3, 3);
        pnlCourseFilterCard.Name = "pnlCourseFilterCard";
        pnlCourseFilterCard.Padding = new Padding(16, 14, 16, 14);
        pnlCourseFilterCard.Size = new Size(974, 82);
        pnlCourseFilterCard.TabIndex = 0;
        // 
        // lblCourseKeyword
        // 
        lblCourseKeyword.AutoSize = true;
        lblCourseKeyword.Location = new Point(16, 18);
        lblCourseKeyword.Name = "lblCourseKeyword";
        lblCourseKeyword.Size = new Size(95, 20);
        lblCourseKeyword.TabIndex = 0;
        lblCourseKeyword.Text = "Từ khóa tìm";
        // 
        // txtCourseKeyword
        // 
        txtCourseKeyword.Location = new Point(16, 41);
        txtCourseKeyword.Name = "txtCourseKeyword";
        txtCourseKeyword.PlaceholderText = "Mã khóa hoặc tên khóa học";
        txtCourseKeyword.Size = new Size(280, 27);
        txtCourseKeyword.TabIndex = 1;
        // 
        // lblCourseStatus
        // 
        lblCourseStatus.AutoSize = true;
        lblCourseStatus.Location = new Point(318, 18);
        lblCourseStatus.Name = "lblCourseStatus";
        lblCourseStatus.Size = new Size(78, 20);
        lblCourseStatus.TabIndex = 2;
        lblCourseStatus.Text = "Trạng thái";
        // 
        // cboCourseStatusFilter
        // 
        cboCourseStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCourseStatusFilter.FormattingEnabled = true;
        cboCourseStatusFilter.Items.AddRange(new object[] { "Tất cả", "Còn mở", "Tạm dừng" });
        cboCourseStatusFilter.Location = new Point(318, 41);
        cboCourseStatusFilter.Name = "cboCourseStatusFilter";
        cboCourseStatusFilter.Size = new Size(190, 28);
        cboCourseStatusFilter.TabIndex = 3;
        // 
        // btnSearchCourse
        // 
        btnSearchCourse.Location = new Point(532, 39);
        btnSearchCourse.Name = "btnSearchCourse";
        btnSearchCourse.Size = new Size(100, 30);
        btnSearchCourse.TabIndex = 4;
        btnSearchCourse.Text = "Tìm kiếm";
        btnSearchCourse.UseVisualStyleBackColor = true;
        // 
        // btnRefreshCourse
        // 
        btnRefreshCourse.Location = new Point(640, 39);
        btnRefreshCourse.Name = "btnRefreshCourse";
        btnRefreshCourse.Size = new Size(108, 30);
        btnRefreshCourse.TabIndex = 5;
        btnRefreshCourse.Text = "Làm mới";
        btnRefreshCourse.UseVisualStyleBackColor = true;
        // 
        // dgvCourseList
        // 
        dgvCourseList.AllowUserToAddRows = false;
        dgvCourseList.AllowUserToDeleteRows = false;
        dgvCourseList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCourseList.BackgroundColor = Color.White;
        dgvCourseList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCourseList.Dock = DockStyle.Fill;
        dgvCourseList.Location = new Point(0, 0);
        dgvCourseList.MultiSelect = false;
        dgvCourseList.Name = "dgvCourseList";
        dgvCourseList.ReadOnly = true;
        dgvCourseList.RowHeadersVisible = false;
        dgvCourseList.RowHeadersWidth = 51;
        dgvCourseList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvCourseList.Size = new Size(376, 458);
        dgvCourseList.TabIndex = 0;
        // 
        // grpCourseInfo
        // 
        grpCourseInfo.Controls.Add(tblCourseDetail);
        grpCourseInfo.Dock = DockStyle.Top;
        grpCourseInfo.Location = new Point(0, 0);
        grpCourseInfo.Name = "grpCourseInfo";
        grpCourseInfo.Padding = new Padding(14, 10, 14, 14);
        grpCourseInfo.Size = new Size(580, 248);
        grpCourseInfo.TabIndex = 0;
        grpCourseInfo.TabStop = false;
        grpCourseInfo.Text = "Thông tin khóa học";
        // 
        // tblCourseDetail
        // 
        tblCourseDetail.ColumnCount = 2;
        tblCourseDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
        tblCourseDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblCourseDetail.Controls.Add(lblCourseCode, 0, 0);
        tblCourseDetail.Controls.Add(txtCourseCode, 1, 0);
        tblCourseDetail.Controls.Add(lblCourseName, 0, 1);
        tblCourseDetail.Controls.Add(txtCourseName, 1, 1);
        tblCourseDetail.Controls.Add(lblCourseLevel, 0, 2);
        tblCourseDetail.Controls.Add(txtCourseLevel, 1, 2);
        tblCourseDetail.Controls.Add(lblCourseFee, 0, 3);
        tblCourseDetail.Controls.Add(txtCourseFee, 1, 3);
        tblCourseDetail.Controls.Add(lblCourseDescription, 0, 4);
        tblCourseDetail.Controls.Add(txtCourseDescription, 1, 4);
        tblCourseDetail.Dock = DockStyle.Fill;
        tblCourseDetail.Location = new Point(14, 32);
        tblCourseDetail.Name = "tblCourseDetail";
        tblCourseDetail.RowCount = 5;
        tblCourseDetail.RowStyles.Add(new RowStyle());
        tblCourseDetail.RowStyles.Add(new RowStyle());
        tblCourseDetail.RowStyles.Add(new RowStyle());
        tblCourseDetail.RowStyles.Add(new RowStyle());
        tblCourseDetail.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblCourseDetail.Size = new Size(552, 202);
        tblCourseDetail.TabIndex = 0;
        // 
        // lblCourseCode
        // 
        lblCourseCode.Anchor = AnchorStyles.Left;
        lblCourseCode.AutoSize = true;
        lblCourseCode.Location = new Point(3, 6);
        lblCourseCode.Name = "lblCourseCode";
        lblCourseCode.Size = new Size(65, 20);
        lblCourseCode.TabIndex = 0;
        lblCourseCode.Text = "Mã khóa";
        // 
        // txtCourseCode
        // 
        txtCourseCode.Dock = DockStyle.Fill;
        txtCourseCode.Location = new Point(143, 3);
        txtCourseCode.Name = "txtCourseCode";
        txtCourseCode.Size = new Size(406, 27);
        txtCourseCode.TabIndex = 1;
        // 
        // lblCourseName
        // 
        lblCourseName.Anchor = AnchorStyles.Left;
        lblCourseName.AutoSize = true;
        lblCourseName.Location = new Point(3, 39);
        lblCourseName.Name = "lblCourseName";
        lblCourseName.Size = new Size(91, 20);
        lblCourseName.TabIndex = 2;
        lblCourseName.Text = "Tên khóa học";
        // 
        // txtCourseName
        // 
        txtCourseName.Dock = DockStyle.Fill;
        txtCourseName.Location = new Point(143, 36);
        txtCourseName.Name = "txtCourseName";
        txtCourseName.Size = new Size(406, 27);
        txtCourseName.TabIndex = 3;
        // 
        // lblCourseLevel
        // 
        lblCourseLevel.Anchor = AnchorStyles.Left;
        lblCourseLevel.AutoSize = true;
        lblCourseLevel.Location = new Point(3, 72);
        lblCourseLevel.Name = "lblCourseLevel";
        lblCourseLevel.Size = new Size(48, 20);
        lblCourseLevel.TabIndex = 4;
        lblCourseLevel.Text = "Trình độ";
        // 
        // txtCourseLevel
        // 
        txtCourseLevel.Dock = DockStyle.Fill;
        txtCourseLevel.Location = new Point(143, 69);
        txtCourseLevel.Name = "txtCourseLevel";
        txtCourseLevel.Size = new Size(406, 27);
        txtCourseLevel.TabIndex = 5;
        // 
        // lblCourseFee
        // 
        lblCourseFee.Anchor = AnchorStyles.Left;
        lblCourseFee.AutoSize = true;
        lblCourseFee.Location = new Point(3, 105);
        lblCourseFee.Name = "lblCourseFee";
        lblCourseFee.Size = new Size(60, 20);
        lblCourseFee.TabIndex = 6;
        lblCourseFee.Text = "Học phí";
        // 
        // txtCourseFee
        // 
        txtCourseFee.Dock = DockStyle.Fill;
        txtCourseFee.Location = new Point(143, 102);
        txtCourseFee.Name = "txtCourseFee";
        txtCourseFee.Size = new Size(406, 27);
        txtCourseFee.TabIndex = 7;
        // 
        // lblCourseDescription
        // 
        lblCourseDescription.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        lblCourseDescription.AutoSize = true;
        lblCourseDescription.Location = new Point(3, 138);
        lblCourseDescription.Name = "lblCourseDescription";
        lblCourseDescription.Size = new Size(48, 20);
        lblCourseDescription.TabIndex = 8;
        lblCourseDescription.Text = "Mô tả";
        // 
        // txtCourseDescription
        // 
        txtCourseDescription.Dock = DockStyle.Fill;
        txtCourseDescription.Location = new Point(143, 135);
        txtCourseDescription.Multiline = true;
        txtCourseDescription.Name = "txtCourseDescription";
        txtCourseDescription.ScrollBars = ScrollBars.Vertical;
        txtCourseDescription.Size = new Size(406, 64);
        txtCourseDescription.TabIndex = 9;
        // 
        // btnCreateCourse
        // 
        btnCreateCourse.Location = new Point(3, 3);
        btnCreateCourse.Name = "btnCreateCourse";
        btnCreateCourse.Size = new Size(110, 34);
        btnCreateCourse.TabIndex = 0;
        btnCreateCourse.Text = "Thêm mới";
        btnCreateCourse.UseVisualStyleBackColor = true;
        // 
        // btnSaveCourse
        // 
        btnSaveCourse.Location = new Point(119, 3);
        btnSaveCourse.Name = "btnSaveCourse";
        btnSaveCourse.Size = new Size(110, 34);
        btnSaveCourse.TabIndex = 1;
        btnSaveCourse.Text = "Lưu";
        btnSaveCourse.UseVisualStyleBackColor = true;
        // 
        // btnUpdateCourse
        // 
        btnUpdateCourse.Location = new Point(235, 3);
        btnUpdateCourse.Name = "btnUpdateCourse";
        btnUpdateCourse.Size = new Size(110, 34);
        btnUpdateCourse.TabIndex = 2;
        btnUpdateCourse.Text = "Cập nhật";
        btnUpdateCourse.UseVisualStyleBackColor = true;
        // 
        // btnDeleteCourse
        // 
        btnDeleteCourse.Location = new Point(351, 3);
        btnDeleteCourse.Name = "btnDeleteCourse";
        btnDeleteCourse.Size = new Size(110, 34);
        btnDeleteCourse.TabIndex = 3;
        btnDeleteCourse.Text = "Xóa mềm";
        btnDeleteCourse.UseVisualStyleBackColor = true;
        // 
        // tblCourseRoot
        // 
        tblCourseRoot.ColumnCount = 1;
        tblCourseRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblCourseRoot.Controls.Add(pnlCourseFilterCard, 0, 0);
        tblCourseRoot.Controls.Add(splCourseContent, 0, 1);
        tblCourseRoot.Controls.Add(flpCourseActions, 0, 2);
        tblCourseRoot.Dock = DockStyle.Fill;
        tblCourseRoot.Location = new Point(12, 12);
        tblCourseRoot.Name = "tblCourseRoot";
        tblCourseRoot.RowCount = 3;
        tblCourseRoot.RowStyles.Add(new RowStyle());
        tblCourseRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblCourseRoot.RowStyles.Add(new RowStyle());
        tblCourseRoot.Size = new Size(980, 616);
        tblCourseRoot.TabIndex = 0;
        // 
        // splCourseContent
        // 
        splCourseContent.Dock = DockStyle.Fill;
        splCourseContent.Location = new Point(3, 91);
        splCourseContent.Name = "splCourseContent";
        // 
        // splCourseContent.Panel1
        // 
        splCourseContent.Panel1.Controls.Add(dgvCourseList);
        splCourseContent.Panel1.Padding = new Padding(0, 0, 6, 0);
        // 
        // splCourseContent.Panel2
        // 
        splCourseContent.Panel2.Controls.Add(grpCourseClassList);
        splCourseContent.Panel2.Controls.Add(grpCourseInfo);
        splCourseContent.Panel2.Padding = new Padding(6, 0, 0, 0);
        splCourseContent.Size = new Size(974, 458);
        splCourseContent.SplitterDistance = 382;
        splCourseContent.TabIndex = 1;
        // 
        // grpCourseClassList
        // 
        grpCourseClassList.Controls.Add(dgvCourseClassList);
        grpCourseClassList.Dock = DockStyle.Fill;
        grpCourseClassList.Location = new Point(6, 248);
        grpCourseClassList.Name = "grpCourseClassList";
        grpCourseClassList.Padding = new Padding(14, 10, 14, 14);
        grpCourseClassList.Size = new Size(580, 210);
        grpCourseClassList.TabIndex = 1;
        grpCourseClassList.TabStop = false;
        grpCourseClassList.Text = "Danh sách lớp thuộc khóa";
        // 
        // dgvCourseClassList
        // 
        dgvCourseClassList.AllowUserToAddRows = false;
        dgvCourseClassList.AllowUserToDeleteRows = false;
        dgvCourseClassList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCourseClassList.BackgroundColor = Color.White;
        dgvCourseClassList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCourseClassList.Dock = DockStyle.Fill;
        dgvCourseClassList.Location = new Point(14, 32);
        dgvCourseClassList.Name = "dgvCourseClassList";
        dgvCourseClassList.ReadOnly = true;
        dgvCourseClassList.RowHeadersVisible = false;
        dgvCourseClassList.RowHeadersWidth = 51;
        dgvCourseClassList.Size = new Size(552, 164);
        dgvCourseClassList.TabIndex = 0;
        // 
        // flpCourseActions
        // 
        flpCourseActions.AutoSize = true;
        flpCourseActions.Controls.Add(btnCreateCourse);
        flpCourseActions.Controls.Add(btnSaveCourse);
        flpCourseActions.Controls.Add(btnUpdateCourse);
        flpCourseActions.Controls.Add(btnDeleteCourse);
        flpCourseActions.Dock = DockStyle.Fill;
        flpCourseActions.Location = new Point(3, 555);
        flpCourseActions.Name = "flpCourseActions";
        flpCourseActions.Size = new Size(974, 58);
        flpCourseActions.TabIndex = 2;
        flpCourseActions.WrapContents = false;
        // 
        // FrmCourseManagement
        // 
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(1004, 640);
        Controls.Add(tblCourseRoot);
        Name = "FrmCourseManagement";
        Padding = new Padding(12);
        Text = "Quản lý khóa học";
        pnlCourseFilterCard.ResumeLayout(false);
        pnlCourseFilterCard.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCourseList).EndInit();
        grpCourseInfo.ResumeLayout(false);
        tblCourseDetail.ResumeLayout(false);
        tblCourseDetail.PerformLayout();
        tblCourseRoot.ResumeLayout(false);
        tblCourseRoot.PerformLayout();
        splCourseContent.Panel1.ResumeLayout(false);
        splCourseContent.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splCourseContent).EndInit();
        splCourseContent.ResumeLayout(false);
        grpCourseClassList.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvCourseClassList).EndInit();
        flpCourseActions.ResumeLayout(false);
        ResumeLayout(false);
    }
}
