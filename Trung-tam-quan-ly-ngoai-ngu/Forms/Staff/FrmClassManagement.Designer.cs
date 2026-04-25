namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmClassManagement
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tblClassRoot;
    private Panel pnlClassFilterCard;
    private Label lblClassKeyword;
    private TextBox txtClassKeyword;
    private Label lblClassStatus;
    private ComboBox cboClassStatusFilter;
    private Button btnSearchClass;
    private Button btnRefreshClass;
    private SplitContainer splClassContent;
    private DataGridView dgvClassList;
    private TabControl tabClassManagement;
    private TabPage tpClassInfo;
    private TabPage tpClassStudents;
    private TabPage tpClassSessions;
    private TableLayoutPanel tblClassInfo;
    private Label lblClassCode;
    private TextBox txtClassCode;
    private Label lblClassName;
    private TextBox txtClassName;
    private Label lblClassCourse;
    private TextBox txtClassCourse;
    private Label lblClassTeacher;
    private TextBox txtClassTeacher;
    private Label lblClassSchedule;
    private TextBox txtClassSchedule;
    private Label lblClassSize;
    private TextBox txtClassSize;
    private Label lblClassDetailStatus;
    private ComboBox cboClassDetailStatus;
    private DataGridView dgvClassStudentList;
    private DataGridView dgvClassSessionList;
    private FlowLayoutPanel flpClassActions;
    private Button btnCreateClass;
    private Button btnSaveClass;
    private Label lblClassRoom;
    private TextBox txtClassRoom;
    private Label lblClassStartDate;
    private DateTimePicker dtpClassStartDate;
    private Label lblClassEndDate;
    private DateTimePicker dtpClassEndDate;
    private Button btnUpdateClass;
    private Button btnGenerateSessions;
    private Button btnOpenEnrollmentFromClass;

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
        tblClassRoot = new TableLayoutPanel();
        pnlClassFilterCard = new Panel();
        btnRefreshClass = new Button();
        btnSearchClass = new Button();
        cboClassStatusFilter = new ComboBox();
        lblClassStatus = new Label();
        txtClassKeyword = new TextBox();
        lblClassKeyword = new Label();
        splClassContent = new SplitContainer();
        dgvClassList = new DataGridView();
        tabClassManagement = new TabControl();
        tpClassInfo = new TabPage();
        tblClassInfo = new TableLayoutPanel();
        lblClassCode = new Label();
        txtClassCode = new TextBox();
        lblClassName = new Label();
        txtClassName = new TextBox();
        lblClassCourse = new Label();
        txtClassCourse = new TextBox();
        lblClassTeacher = new Label();
        txtClassTeacher = new TextBox();
        lblClassSchedule = new Label();
        txtClassSchedule = new TextBox();
        lblClassRoom = new Label();
        txtClassRoom = new TextBox();
        lblClassStartDate = new Label();
        dtpClassStartDate = new DateTimePicker();
        lblClassEndDate = new Label();
        dtpClassEndDate = new DateTimePicker();
        lblClassSize = new Label();
        txtClassSize = new TextBox();
        lblClassDetailStatus = new Label();
        cboClassDetailStatus = new ComboBox();
        tpClassStudents = new TabPage();
        dgvClassStudentList = new DataGridView();
        tpClassSessions = new TabPage();
        dgvClassSessionList = new DataGridView();
        flpClassActions = new FlowLayoutPanel();
        btnCreateClass = new Button();
        btnSaveClass = new Button();
        btnUpdateClass = new Button();
        btnGenerateSessions = new Button();
        btnOpenEnrollmentFromClass = new Button();
        tblClassRoot.SuspendLayout();
        pnlClassFilterCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splClassContent).BeginInit();
        splClassContent.Panel1.SuspendLayout();
        splClassContent.Panel2.SuspendLayout();
        splClassContent.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvClassList).BeginInit();
        tabClassManagement.SuspendLayout();
        tpClassInfo.SuspendLayout();
        tblClassInfo.SuspendLayout();
        tpClassStudents.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvClassStudentList).BeginInit();
        tpClassSessions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvClassSessionList).BeginInit();
        flpClassActions.SuspendLayout();
        SuspendLayout();
        // 
        // tblClassRoot
        // 
        tblClassRoot.ColumnCount = 1;
        tblClassRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblClassRoot.Controls.Add(pnlClassFilterCard, 0, 0);
        tblClassRoot.Controls.Add(splClassContent, 0, 1);
        tblClassRoot.Controls.Add(flpClassActions, 0, 2);
        tblClassRoot.Dock = DockStyle.Fill;
        tblClassRoot.Location = new Point(12, 12);
        tblClassRoot.Name = "tblClassRoot";
        tblClassRoot.RowCount = 3;
        tblClassRoot.RowStyles.Add(new RowStyle());
        tblClassRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblClassRoot.RowStyles.Add(new RowStyle());
        tblClassRoot.Size = new Size(976, 616);
        tblClassRoot.TabIndex = 0;
        // 
        // pnlClassFilterCard
        // 
        pnlClassFilterCard.BorderStyle = BorderStyle.FixedSingle;
        pnlClassFilterCard.Controls.Add(btnRefreshClass);
        pnlClassFilterCard.Controls.Add(btnSearchClass);
        pnlClassFilterCard.Controls.Add(cboClassStatusFilter);
        pnlClassFilterCard.Controls.Add(lblClassStatus);
        pnlClassFilterCard.Controls.Add(txtClassKeyword);
        pnlClassFilterCard.Controls.Add(lblClassKeyword);
        pnlClassFilterCard.Dock = DockStyle.Fill;
        pnlClassFilterCard.Location = new Point(3, 3);
        pnlClassFilterCard.Name = "pnlClassFilterCard";
        pnlClassFilterCard.Padding = new Padding(16, 14, 16, 14);
        pnlClassFilterCard.Size = new Size(970, 82);
        pnlClassFilterCard.TabIndex = 0;
        // 
        // btnRefreshClass
        // 
        btnRefreshClass.Location = new Point(620, 39);
        btnRefreshClass.Name = "btnRefreshClass";
        btnRefreshClass.Size = new Size(108, 30);
        btnRefreshClass.TabIndex = 5;
        btnRefreshClass.Text = "LÃ m má»›i";
        btnRefreshClass.UseVisualStyleBackColor = true;
        // 
        // btnSearchClass
        // 
        btnSearchClass.Location = new Point(512, 39);
        btnSearchClass.Name = "btnSearchClass";
        btnSearchClass.Size = new Size(100, 30);
        btnSearchClass.TabIndex = 4;
        btnSearchClass.Text = "TÃ¬m kiáº¿m";
        btnSearchClass.UseVisualStyleBackColor = true;
        // 
        // cboClassStatusFilter
        // 
        cboClassStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cboClassStatusFilter.FormattingEnabled = true;
        cboClassStatusFilter.Items.AddRange(new object[] { "Táº¥t cáº£", "Äang má»Ÿ", "Äáº§y", "ÄÃ£ Ä‘Ã³ng" });
        cboClassStatusFilter.Location = new Point(318, 41);
        cboClassStatusFilter.Name = "cboClassStatusFilter";
        cboClassStatusFilter.Size = new Size(170, 28);
        cboClassStatusFilter.TabIndex = 3;
        // 
        // lblClassStatus
        // 
        lblClassStatus.AutoSize = true;
        lblClassStatus.Location = new Point(318, 18);
        lblClassStatus.Name = "lblClassStatus";
        lblClassStatus.Size = new Size(75, 20);
        lblClassStatus.TabIndex = 2;
        lblClassStatus.Text = "Tráº¡ng thÃ¡i";
        // 
        // txtClassKeyword
        // 
        txtClassKeyword.Location = new Point(16, 41);
        txtClassKeyword.Name = "txtClassKeyword";
        txtClassKeyword.PlaceholderText = "MÃ£ lá»›p hoáº·c tÃªn lá»›p";
        txtClassKeyword.Size = new Size(280, 27);
        txtClassKeyword.TabIndex = 1;
        // 
        // lblClassKeyword
        // 
        lblClassKeyword.AutoSize = true;
        lblClassKeyword.Location = new Point(16, 18);
        lblClassKeyword.Name = "lblClassKeyword";
        lblClassKeyword.Size = new Size(88, 20);
        lblClassKeyword.TabIndex = 0;
        lblClassKeyword.Text = "Tá»« khÃ³a tÃ¬m";
        // 
        // splClassContent
        // 
        splClassContent.Dock = DockStyle.Fill;
        splClassContent.Location = new Point(3, 91);
        splClassContent.Name = "splClassContent";
        // 
        // splClassContent.Panel1
        // 
        splClassContent.Panel1.Controls.Add(dgvClassList);
        splClassContent.Panel1.Padding = new Padding(0, 0, 6, 0);
        // 
        // splClassContent.Panel2
        // 
        splClassContent.Panel2.Controls.Add(tabClassManagement);
        splClassContent.Panel2.Padding = new Padding(6, 0, 0, 0);
        splClassContent.Size = new Size(970, 476);
        splClassContent.SplitterDistance = 390;
        splClassContent.TabIndex = 1;
        // 
        // dgvClassList
        // 
        dgvClassList.AllowUserToAddRows = false;
        dgvClassList.AllowUserToDeleteRows = false;
        dgvClassList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvClassList.BackgroundColor = Color.White;
        dgvClassList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvClassList.Dock = DockStyle.Fill;
        dgvClassList.Location = new Point(0, 0);
        dgvClassList.MultiSelect = false;
        dgvClassList.Name = "dgvClassList";
        dgvClassList.ReadOnly = true;
        dgvClassList.RowHeadersVisible = false;
        dgvClassList.RowHeadersWidth = 51;
        dgvClassList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvClassList.Size = new Size(384, 476);
        dgvClassList.TabIndex = 0;
        // 
        // tabClassManagement
        // 
        tabClassManagement.Controls.Add(tpClassInfo);
        tabClassManagement.Controls.Add(tpClassStudents);
        tabClassManagement.Controls.Add(tpClassSessions);
        tabClassManagement.Dock = DockStyle.Fill;
        tabClassManagement.Location = new Point(6, 0);
        tabClassManagement.Name = "tabClassManagement";
        tabClassManagement.SelectedIndex = 0;
        tabClassManagement.Size = new Size(570, 476);
        tabClassManagement.TabIndex = 0;
        // 
        // tpClassInfo
        // 
        tpClassInfo.Controls.Add(tblClassInfo);
        tpClassInfo.Location = new Point(4, 29);
        tpClassInfo.Name = "tpClassInfo";
        tpClassInfo.Padding = new Padding(12);
        tpClassInfo.Size = new Size(562, 443);
        tpClassInfo.TabIndex = 0;
        tpClassInfo.Text = "ThÃ´ng tin lá»›p";
        tpClassInfo.UseVisualStyleBackColor = true;
        // 
        // tblClassInfo
        // 
        tblClassInfo.ColumnCount = 2;
        tblClassInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
        tblClassInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblClassInfo.Controls.Add(lblClassCode, 0, 0);
        tblClassInfo.Controls.Add(txtClassCode, 1, 0);
        tblClassInfo.Controls.Add(lblClassName, 0, 1);
        tblClassInfo.Controls.Add(txtClassName, 1, 1);
        tblClassInfo.Controls.Add(lblClassCourse, 0, 2);
        tblClassInfo.Controls.Add(txtClassCourse, 1, 2);
        tblClassInfo.Controls.Add(lblClassTeacher, 0, 3);
        tblClassInfo.Controls.Add(txtClassTeacher, 1, 3);
        tblClassInfo.Controls.Add(lblClassSchedule, 0, 4);
        tblClassInfo.Controls.Add(txtClassSchedule, 1, 4);
        tblClassInfo.Controls.Add(lblClassRoom, 0, 5);
        tblClassInfo.Controls.Add(txtClassRoom, 1, 5);
        tblClassInfo.Controls.Add(lblClassStartDate, 0, 6);
        tblClassInfo.Controls.Add(dtpClassStartDate, 1, 6);
        tblClassInfo.Controls.Add(lblClassEndDate, 0, 7);
        tblClassInfo.Controls.Add(dtpClassEndDate, 1, 7);
        tblClassInfo.Controls.Add(lblClassSize, 0, 8);
        tblClassInfo.Controls.Add(txtClassSize, 1, 8);
        tblClassInfo.Controls.Add(lblClassDetailStatus, 0, 9);
        tblClassInfo.Controls.Add(cboClassDetailStatus, 1, 9);
        tblClassInfo.Dock = DockStyle.Fill;
        tblClassInfo.Location = new Point(12, 12);
        tblClassInfo.Name = "tblClassInfo";
        tblClassInfo.RowCount = 10;
        tblClassInfo.RowStyles.Add(new RowStyle());
        tblClassInfo.RowStyles.Add(new RowStyle());
        tblClassInfo.RowStyles.Add(new RowStyle());
        tblClassInfo.RowStyles.Add(new RowStyle());
        tblClassInfo.RowStyles.Add(new RowStyle());
        tblClassInfo.RowStyles.Add(new RowStyle());
        tblClassInfo.RowStyles.Add(new RowStyle());
        tblClassInfo.RowStyles.Add(new RowStyle());
        tblClassInfo.RowStyles.Add(new RowStyle());
        tblClassInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblClassInfo.Size = new Size(538, 419);
        tblClassInfo.TabIndex = 0;
        // 
        // lblClassCode
        // 
        lblClassCode.Anchor = AnchorStyles.Left;
        lblClassCode.AutoSize = true;
        lblClassCode.Location = new Point(3, 6);
        lblClassCode.Name = "lblClassCode";
        lblClassCode.Size = new Size(56, 20);
        lblClassCode.TabIndex = 0;
        lblClassCode.Text = "MÃ£ lá»›p";
        // 
        // txtClassCode
        // 
        txtClassCode.Dock = DockStyle.Fill;
        txtClassCode.Location = new Point(133, 3);
        txtClassCode.Name = "txtClassCode";
        txtClassCode.Size = new Size(402, 27);
        txtClassCode.TabIndex = 1;
        // 
        // lblClassName
        // 
        lblClassName.Anchor = AnchorStyles.Left;
        lblClassName.AutoSize = true;
        lblClassName.Location = new Point(3, 39);
        lblClassName.Name = "lblClassName";
        lblClassName.Size = new Size(58, 20);
        lblClassName.TabIndex = 2;
        lblClassName.Text = "TÃªn lá»›p";
        // 
        // txtClassName
        // 
        txtClassName.Dock = DockStyle.Fill;
        txtClassName.Location = new Point(133, 36);
        txtClassName.Name = "txtClassName";
        txtClassName.Size = new Size(402, 27);
        txtClassName.TabIndex = 3;
        // 
        // lblClassCourse
        // 
        lblClassCourse.Anchor = AnchorStyles.Left;
        lblClassCourse.AutoSize = true;
        lblClassCourse.Location = new Point(3, 72);
        lblClassCourse.Name = "lblClassCourse";
        lblClassCourse.Size = new Size(71, 20);
        lblClassCourse.TabIndex = 4;
        lblClassCourse.Text = "KhÃ³a há»c";
        // 
        // txtClassCourse
        // 
        txtClassCourse.Dock = DockStyle.Fill;
        txtClassCourse.Location = new Point(133, 69);
        txtClassCourse.Name = "txtClassCourse";
        txtClassCourse.Size = new Size(402, 27);
        txtClassCourse.TabIndex = 5;
        // 
        // lblClassTeacher
        // 
        lblClassTeacher.Anchor = AnchorStyles.Left;
        lblClassTeacher.AutoSize = true;
        lblClassTeacher.Location = new Point(3, 105);
        lblClassTeacher.Name = "lblClassTeacher";
        lblClassTeacher.Size = new Size(71, 20);
        lblClassTeacher.TabIndex = 6;
        lblClassTeacher.Text = "GiÃ¡o viÃªn";
        // 
        // txtClassTeacher
        // 
        txtClassTeacher.Dock = DockStyle.Fill;
        txtClassTeacher.Location = new Point(133, 102);
        txtClassTeacher.Name = "txtClassTeacher";
        txtClassTeacher.Size = new Size(402, 27);
        txtClassTeacher.TabIndex = 7;
        // 
        // lblClassSchedule
        // 
        lblClassSchedule.Anchor = AnchorStyles.Left;
        lblClassSchedule.AutoSize = true;
        lblClassSchedule.Location = new Point(3, 138);
        lblClassSchedule.Name = "lblClassSchedule";
        lblClassSchedule.Size = new Size(63, 20);
        lblClassSchedule.TabIndex = 8;
        lblClassSchedule.Text = "Lá»‹ch há»c";
        // 
        // txtClassSchedule
        // 
        txtClassSchedule.Dock = DockStyle.Fill;
        txtClassSchedule.Location = new Point(133, 135);
        txtClassSchedule.Name = "txtClassSchedule";
        txtClassSchedule.Size = new Size(402, 27);
        txtClassSchedule.TabIndex = 9;
        // 
        // lblClassRoom
        // 
        lblClassRoom.Anchor = AnchorStyles.Left;
        lblClassRoom.AutoSize = true;
        lblClassRoom.Location = new Point(3, 171);
        lblClassRoom.Name = "lblClassRoom";
        lblClassRoom.Size = new Size(79, 20);
        lblClassRoom.TabIndex = 10;
        lblClassRoom.Text = "PhÃ²ng há»c";
        // 
        // txtClassRoom
        // 
        txtClassRoom.Dock = DockStyle.Fill;
        txtClassRoom.Location = new Point(133, 168);
        txtClassRoom.Name = "txtClassRoom";
        txtClassRoom.Size = new Size(402, 27);
        txtClassRoom.TabIndex = 11;
        // 
        // lblClassStartDate
        // 
        lblClassStartDate.Anchor = AnchorStyles.Left;
        lblClassStartDate.AutoSize = true;
        lblClassStartDate.Location = new Point(3, 204);
        lblClassStartDate.Name = "lblClassStartDate";
        lblClassStartDate.Size = new Size(99, 20);
        lblClassStartDate.TabIndex = 12;
        lblClassStartDate.Text = "NgÃ y báº¯t Ä‘áº§u";
        // 
        // dtpClassStartDate
        // 
        dtpClassStartDate.Dock = DockStyle.Left;
        dtpClassStartDate.Format = DateTimePickerFormat.Short;
        dtpClassStartDate.Location = new Point(133, 201);
        dtpClassStartDate.Name = "dtpClassStartDate";
        dtpClassStartDate.Size = new Size(160, 27);
        dtpClassStartDate.TabIndex = 13;
        // 
        // lblClassEndDate
        // 
        lblClassEndDate.Anchor = AnchorStyles.Left;
        lblClassEndDate.AutoSize = true;
        lblClassEndDate.Location = new Point(3, 237);
        lblClassEndDate.Name = "lblClassEndDate";
        lblClassEndDate.Size = new Size(100, 20);
        lblClassEndDate.TabIndex = 14;
        lblClassEndDate.Text = "NgÃ y káº¿t thÃºc";
        // 
        // dtpClassEndDate
        // 
        dtpClassEndDate.Dock = DockStyle.Left;
        dtpClassEndDate.Format = DateTimePickerFormat.Short;
        dtpClassEndDate.Location = new Point(133, 234);
        dtpClassEndDate.Name = "dtpClassEndDate";
        dtpClassEndDate.Size = new Size(160, 27);
        dtpClassEndDate.TabIndex = 15;
        // 
        // lblClassSize
        // 
        lblClassSize.Anchor = AnchorStyles.Left;
        lblClassSize.AutoSize = true;
        lblClassSize.Location = new Point(3, 270);
        lblClassSize.Name = "lblClassSize";
        lblClassSize.Size = new Size(40, 20);
        lblClassSize.TabIndex = 16;
        lblClassSize.Text = "SÄ© sá»‘";
        // 
        // txtClassSize
        // 
        txtClassSize.Dock = DockStyle.Fill;
        txtClassSize.Location = new Point(133, 267);
        txtClassSize.Name = "txtClassSize";
        txtClassSize.Size = new Size(402, 27);
        txtClassSize.TabIndex = 17;
        // 
        // lblClassDetailStatus
        // 
        lblClassDetailStatus.Anchor = AnchorStyles.Left;
        lblClassDetailStatus.AutoSize = true;
        lblClassDetailStatus.Location = new Point(3, 348);
        lblClassDetailStatus.Name = "lblClassDetailStatus";
        lblClassDetailStatus.Size = new Size(75, 20);
        lblClassDetailStatus.TabIndex = 18;
        lblClassDetailStatus.Text = "Tráº¡ng thÃ¡i";
        // 
        // cboClassDetailStatus
        // 
        cboClassDetailStatus.Dock = DockStyle.Left;
        cboClassDetailStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboClassDetailStatus.FormattingEnabled = true;
        cboClassDetailStatus.Items.AddRange(new object[] { "Äang má»Ÿ", "Äáº§y", "ÄÃ£ Ä‘Ã³ng" });
        cboClassDetailStatus.Location = new Point(133, 300);
        cboClassDetailStatus.Name = "cboClassDetailStatus";
        cboClassDetailStatus.Size = new Size(180, 28);
        cboClassDetailStatus.TabIndex = 19;
        // 
        // tpClassStudents
        // 
        tpClassStudents.Controls.Add(dgvClassStudentList);
        tpClassStudents.Location = new Point(4, 29);
        tpClassStudents.Name = "tpClassStudents";
        tpClassStudents.Padding = new Padding(12);
        tpClassStudents.Size = new Size(562, 443);
        tpClassStudents.TabIndex = 1;
        tpClassStudents.Text = "Há»c viÃªn lá»›p";
        tpClassStudents.UseVisualStyleBackColor = true;
        // 
        // dgvClassStudentList
        // 
        dgvClassStudentList.AllowUserToAddRows = false;
        dgvClassStudentList.AllowUserToDeleteRows = false;
        dgvClassStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvClassStudentList.BackgroundColor = Color.White;
        dgvClassStudentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvClassStudentList.Dock = DockStyle.Fill;
        dgvClassStudentList.Location = new Point(12, 12);
        dgvClassStudentList.Name = "dgvClassStudentList";
        dgvClassStudentList.ReadOnly = true;
        dgvClassStudentList.RowHeadersVisible = false;
        dgvClassStudentList.RowHeadersWidth = 51;
        dgvClassStudentList.Size = new Size(538, 419);
        dgvClassStudentList.TabIndex = 0;
        // 
        // tpClassSessions
        // 
        tpClassSessions.Controls.Add(dgvClassSessionList);
        tpClassSessions.Location = new Point(4, 29);
        tpClassSessions.Name = "tpClassSessions";
        tpClassSessions.Padding = new Padding(12);
        tpClassSessions.Size = new Size(562, 443);
        tpClassSessions.TabIndex = 2;
        tpClassSessions.Text = "Buá»•i há»c";
        tpClassSessions.UseVisualStyleBackColor = true;
        // 
        // dgvClassSessionList
        // 
        dgvClassSessionList.AllowUserToAddRows = false;
        dgvClassSessionList.AllowUserToDeleteRows = false;
        dgvClassSessionList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvClassSessionList.BackgroundColor = Color.White;
        dgvClassSessionList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvClassSessionList.Dock = DockStyle.Fill;
        dgvClassSessionList.Location = new Point(12, 12);
        dgvClassSessionList.Name = "dgvClassSessionList";
        dgvClassSessionList.ReadOnly = true;
        dgvClassSessionList.RowHeadersVisible = false;
        dgvClassSessionList.RowHeadersWidth = 51;
        dgvClassSessionList.Size = new Size(538, 419);
        dgvClassSessionList.TabIndex = 0;
        // 
        // flpClassActions
        // 
        flpClassActions.AutoSize = true;
        flpClassActions.Controls.Add(btnCreateClass);
        flpClassActions.Controls.Add(btnSaveClass);
        flpClassActions.Controls.Add(btnUpdateClass);
        flpClassActions.Controls.Add(btnGenerateSessions);
        flpClassActions.Controls.Add(btnOpenEnrollmentFromClass);
        flpClassActions.Dock = DockStyle.Fill;
        flpClassActions.Location = new Point(3, 573);
        flpClassActions.Name = "flpClassActions";
        flpClassActions.Size = new Size(970, 40);
        flpClassActions.TabIndex = 2;
        flpClassActions.WrapContents = false;
        // 
        // btnCreateClass
        // 
        btnCreateClass.Location = new Point(3, 3);
        btnCreateClass.Name = "btnCreateClass";
        btnCreateClass.Size = new Size(110, 34);
        btnCreateClass.TabIndex = 0;
        btnCreateClass.Text = "ThÃªm lá»›p";
        btnCreateClass.UseVisualStyleBackColor = true;
        // 
        // btnSaveClass
        // 
        btnSaveClass.Location = new Point(119, 3);
        btnSaveClass.Name = "btnSaveClass";
        btnSaveClass.Size = new Size(110, 34);
        btnSaveClass.TabIndex = 1;
        btnSaveClass.Text = "LÆ°u";
        btnSaveClass.UseVisualStyleBackColor = true;
        // 
        // btnUpdateClass
        // 
        btnUpdateClass.Location = new Point(235, 3);
        btnUpdateClass.Name = "btnUpdateClass";
        btnUpdateClass.Size = new Size(110, 34);
        btnUpdateClass.TabIndex = 2;
        btnUpdateClass.Text = "Cáº­p nháº­t";
        btnUpdateClass.UseVisualStyleBackColor = true;
        // 
        // btnGenerateSessions
        // 
        btnGenerateSessions.Location = new Point(351, 3);
        btnGenerateSessions.Name = "btnGenerateSessions";
        btnGenerateSessions.Size = new Size(130, 34);
        btnGenerateSessions.TabIndex = 3;
        btnGenerateSessions.Text = "Sinh buá»•i há»c";
        btnGenerateSessions.UseVisualStyleBackColor = true;
        // 
        // btnOpenEnrollmentFromClass
        // 
        btnOpenEnrollmentFromClass.Location = new Point(487, 3);
        btnOpenEnrollmentFromClass.Name = "btnOpenEnrollmentFromClass";
        btnOpenEnrollmentFromClass.Size = new Size(150, 34);
        btnOpenEnrollmentFromClass.TabIndex = 4;
        btnOpenEnrollmentFromClass.Text = "Má»Ÿ ghi danh lá»›p";
        btnOpenEnrollmentFromClass.UseVisualStyleBackColor = true;
        // 
        // FrmClassManagement
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(1000, 640);
        Controls.Add(tblClassRoot);
        Name = "FrmClassManagement";
        Padding = new Padding(12);
        Text = "Quáº£n lÃ½ lá»›p há»c";
        tblClassRoot.ResumeLayout(false);
        tblClassRoot.PerformLayout();
        pnlClassFilterCard.ResumeLayout(false);
        pnlClassFilterCard.PerformLayout();
        splClassContent.Panel1.ResumeLayout(false);
        splClassContent.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splClassContent).EndInit();
        splClassContent.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvClassList).EndInit();
        tabClassManagement.ResumeLayout(false);
        tpClassInfo.ResumeLayout(false);
        tblClassInfo.ResumeLayout(false);
        tblClassInfo.PerformLayout();
        tpClassStudents.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvClassStudentList).EndInit();
        tpClassSessions.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvClassSessionList).EndInit();
        flpClassActions.ResumeLayout(false);
        ResumeLayout(false);
    }
}

