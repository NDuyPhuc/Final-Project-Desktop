namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmStudentManagement
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tblStudentRoot;
    private Panel pnlStudentFilterCard;
    private Label lblStudentKeyword;
    private TextBox txtStudentKeyword;
    private Label lblStudentStatusFilter;
    private ComboBox cboStudentStatusFilter;
    private Button btnSearchStudent;
    private Button btnRefreshStudent;
    private SplitContainer splStudentContent;
    private DataGridView dgvStudentList;
    private GroupBox grpStudentInfo;
    private TableLayoutPanel tblStudentInfo;
    private PictureBox picStudentAvatar;
    private Button btnChooseStudentAvatar;
    private Button btnRemoveStudentAvatar;
    private Label lblStudentId;
    private TextBox txtStudentId;
    private Label lblStudentFullName;
    private TextBox txtStudentFullName;
    private Label lblStudentBirthDate;
    private DateTimePicker dtpStudentBirthDate;
    private Label lblStudentPhone;
    private TextBox txtStudentPhone;
    private Label lblStudentEmail;
    private TextBox txtStudentEmail;
    private Label lblStudentStatus;
    private ComboBox cboStudentStatus;
    private FlowLayoutPanel flpStudentActions;
    private Button btnCreateStudent;
    private Button btnSaveStudent;
    private Button btnUpdateStudent;
    private Button btnDeleteStudent;
    private Button btnResetStudent;
    private Button btnOpenEnrollment;
    private ErrorProvider errStudent;
    private ToolTip ttStudentManagement;

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
        components = new System.ComponentModel.Container();
        tblStudentRoot = new TableLayoutPanel();
        pnlStudentFilterCard = new Panel();
        lblStudentKeyword = new Label();
        txtStudentKeyword = new TextBox();
        lblStudentStatusFilter = new Label();
        cboStudentStatusFilter = new ComboBox();
        btnSearchStudent = new Button();
        btnRefreshStudent = new Button();
        splStudentContent = new SplitContainer();
        dgvStudentList = new DataGridView();
        grpStudentInfo = new GroupBox();
        tblStudentInfo = new TableLayoutPanel();
        picStudentAvatar = new PictureBox();
        btnChooseStudentAvatar = new Button();
        btnRemoveStudentAvatar = new Button();
        lblStudentId = new Label();
        txtStudentId = new TextBox();
        lblStudentFullName = new Label();
        txtStudentFullName = new TextBox();
        lblStudentBirthDate = new Label();
        dtpStudentBirthDate = new DateTimePicker();
        lblStudentPhone = new Label();
        txtStudentPhone = new TextBox();
        lblStudentEmail = new Label();
        txtStudentEmail = new TextBox();
        lblStudentStatus = new Label();
        cboStudentStatus = new ComboBox();
        flpStudentActions = new FlowLayoutPanel();
        btnCreateStudent = new Button();
        btnSaveStudent = new Button();
        btnUpdateStudent = new Button();
        btnDeleteStudent = new Button();
        btnResetStudent = new Button();
        btnOpenEnrollment = new Button();
        errStudent = new ErrorProvider(components);
        ttStudentManagement = new ToolTip(components);
        tblStudentRoot.SuspendLayout();
        pnlStudentFilterCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splStudentContent).BeginInit();
        splStudentContent.Panel1.SuspendLayout();
        splStudentContent.Panel2.SuspendLayout();
        splStudentContent.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvStudentList).BeginInit();
        grpStudentInfo.SuspendLayout();
        tblStudentInfo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picStudentAvatar).BeginInit();
        flpStudentActions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)errStudent).BeginInit();
        SuspendLayout();
        // 
        // tblStudentRoot
        // 
        tblStudentRoot.ColumnCount = 1;
        tblStudentRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblStudentRoot.Controls.Add(pnlStudentFilterCard, 0, 0);
        tblStudentRoot.Controls.Add(splStudentContent, 0, 1);
        tblStudentRoot.Controls.Add(flpStudentActions, 0, 2);
        tblStudentRoot.Dock = DockStyle.Fill;
        tblStudentRoot.Location = new Point(12, 12);
        tblStudentRoot.Name = "tblStudentRoot";
        tblStudentRoot.RowCount = 3;
        tblStudentRoot.RowStyles.Add(new RowStyle());
        tblStudentRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblStudentRoot.RowStyles.Add(new RowStyle());
        tblStudentRoot.Size = new Size(956, 596);
        tblStudentRoot.TabIndex = 0;
        // 
        // pnlStudentFilterCard
        // 
        pnlStudentFilterCard.BorderStyle = BorderStyle.FixedSingle;
        pnlStudentFilterCard.Controls.Add(btnRefreshStudent);
        pnlStudentFilterCard.Controls.Add(btnSearchStudent);
        pnlStudentFilterCard.Controls.Add(cboStudentStatusFilter);
        pnlStudentFilterCard.Controls.Add(lblStudentStatusFilter);
        pnlStudentFilterCard.Controls.Add(txtStudentKeyword);
        pnlStudentFilterCard.Controls.Add(lblStudentKeyword);
        pnlStudentFilterCard.Dock = DockStyle.Fill;
        pnlStudentFilterCard.Location = new Point(3, 3);
        pnlStudentFilterCard.Name = "pnlStudentFilterCard";
        pnlStudentFilterCard.Padding = new Padding(16, 14, 16, 14);
        pnlStudentFilterCard.Size = new Size(950, 82);
        pnlStudentFilterCard.TabIndex = 0;
        // 
        // lblStudentKeyword
        // 
        lblStudentKeyword.AutoSize = true;
        lblStudentKeyword.Location = new Point(16, 18);
        lblStudentKeyword.Name = "lblStudentKeyword";
        lblStudentKeyword.Size = new Size(95, 20);
        lblStudentKeyword.TabIndex = 0;
        lblStudentKeyword.Text = "Tá»« khÃ³a tÃ¬m";
        // 
        // txtStudentKeyword
        // 
        txtStudentKeyword.Location = new Point(16, 41);
        txtStudentKeyword.Name = "txtStudentKeyword";
        txtStudentKeyword.PlaceholderText = "TÃªn há»c viÃªn hoáº·c mÃ£ há»c viÃªn";
        txtStudentKeyword.Size = new Size(280, 27);
        txtStudentKeyword.TabIndex = 1;
        // 
        // lblStudentStatusFilter
        // 
        lblStudentStatusFilter.AutoSize = true;
        lblStudentStatusFilter.Location = new Point(318, 18);
        lblStudentStatusFilter.Name = "lblStudentStatusFilter";
        lblStudentStatusFilter.Size = new Size(78, 20);
        lblStudentStatusFilter.TabIndex = 2;
        lblStudentStatusFilter.Text = "Tráº¡ng thÃ¡i";
        // 
        // cboStudentStatusFilter
        // 
        cboStudentStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cboStudentStatusFilter.FormattingEnabled = true;
        cboStudentStatusFilter.Items.AddRange(new object[] { "Táº¥t cáº£", "Äang há»c", "Báº£o lÆ°u", "Ngá»«ng há»c" });
        cboStudentStatusFilter.Location = new Point(318, 41);
        cboStudentStatusFilter.Name = "cboStudentStatusFilter";
        cboStudentStatusFilter.Size = new Size(170, 28);
        cboStudentStatusFilter.TabIndex = 3;
        // 
        // btnSearchStudent
        // 
        btnSearchStudent.Location = new Point(512, 39);
        btnSearchStudent.Name = "btnSearchStudent";
        btnSearchStudent.Size = new Size(100, 30);
        btnSearchStudent.TabIndex = 4;
        btnSearchStudent.Text = "TÃ¬m kiáº¿m";
        btnSearchStudent.UseVisualStyleBackColor = true;
        // 
        // btnRefreshStudent
        // 
        btnRefreshStudent.Location = new Point(620, 39);
        btnRefreshStudent.Name = "btnRefreshStudent";
        btnRefreshStudent.Size = new Size(108, 30);
        btnRefreshStudent.TabIndex = 5;
        btnRefreshStudent.Text = "LÃ m má»›i";
        btnRefreshStudent.UseVisualStyleBackColor = true;
        // 
        // splStudentContent
        // 
        splStudentContent.Dock = DockStyle.Fill;
        splStudentContent.Location = new Point(3, 91);
        splStudentContent.Name = "splStudentContent";
        // 
        // splStudentContent.Panel1
        // 
        splStudentContent.Panel1.Controls.Add(dgvStudentList);
        splStudentContent.Panel1.Padding = new Padding(0, 0, 6, 0);
        // 
        // splStudentContent.Panel2
        // 
        splStudentContent.Panel2.Controls.Add(grpStudentInfo);
        splStudentContent.Panel2.Padding = new Padding(6, 0, 0, 0);
        splStudentContent.Size = new Size(950, 458);
        splStudentContent.SplitterDistance = 470;
        splStudentContent.TabIndex = 1;
        // 
        // dgvStudentList
        // 
        dgvStudentList.AllowUserToAddRows = false;
        dgvStudentList.AllowUserToDeleteRows = false;
        dgvStudentList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvStudentList.BackgroundColor = Color.White;
        dgvStudentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvStudentList.Dock = DockStyle.Fill;
        dgvStudentList.Location = new Point(0, 0);
        dgvStudentList.MultiSelect = false;
        dgvStudentList.Name = "dgvStudentList";
        dgvStudentList.ReadOnly = true;
        dgvStudentList.RowHeadersVisible = false;
        dgvStudentList.RowHeadersWidth = 51;
        dgvStudentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvStudentList.Size = new Size(464, 458);
        dgvStudentList.TabIndex = 0;
        // 
        // grpStudentInfo
        // 
        grpStudentInfo.Controls.Add(tblStudentInfo);
        grpStudentInfo.Dock = DockStyle.Fill;
        grpStudentInfo.Location = new Point(6, 0);
        grpStudentInfo.Name = "grpStudentInfo";
        grpStudentInfo.Padding = new Padding(12);
        grpStudentInfo.Size = new Size(464, 458);
        grpStudentInfo.TabIndex = 0;
        grpStudentInfo.TabStop = false;
        grpStudentInfo.Text = "ThÃ´ng tin há»c viÃªn";
        // 
        // tblStudentInfo
        // 
        tblStudentInfo.ColumnCount = 2;
        tblStudentInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
        tblStudentInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblStudentInfo.Controls.Add(picStudentAvatar, 0, 0);
        tblStudentInfo.Controls.Add(btnChooseStudentAvatar, 0, 1);
        tblStudentInfo.Controls.Add(btnRemoveStudentAvatar, 1, 1);
        tblStudentInfo.Controls.Add(lblStudentId, 0, 2);
        tblStudentInfo.Controls.Add(txtStudentId, 1, 2);
        tblStudentInfo.Controls.Add(lblStudentFullName, 0, 3);
        tblStudentInfo.Controls.Add(txtStudentFullName, 1, 3);
        tblStudentInfo.Controls.Add(lblStudentBirthDate, 0, 4);
        tblStudentInfo.Controls.Add(dtpStudentBirthDate, 1, 4);
        tblStudentInfo.Controls.Add(lblStudentPhone, 0, 5);
        tblStudentInfo.Controls.Add(txtStudentPhone, 1, 5);
        tblStudentInfo.Controls.Add(lblStudentEmail, 0, 6);
        tblStudentInfo.Controls.Add(txtStudentEmail, 1, 6);
        tblStudentInfo.Controls.Add(lblStudentStatus, 0, 7);
        tblStudentInfo.Controls.Add(cboStudentStatus, 1, 7);
        tblStudentInfo.Dock = DockStyle.Fill;
        tblStudentInfo.Location = new Point(12, 32);
        tblStudentInfo.Name = "tblStudentInfo";
        tblStudentInfo.RowCount = 8;
        tblStudentInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));
        tblStudentInfo.RowStyles.Add(new RowStyle());
        tblStudentInfo.RowStyles.Add(new RowStyle());
        tblStudentInfo.RowStyles.Add(new RowStyle());
        tblStudentInfo.RowStyles.Add(new RowStyle());
        tblStudentInfo.RowStyles.Add(new RowStyle());
        tblStudentInfo.RowStyles.Add(new RowStyle());
        tblStudentInfo.RowStyles.Add(new RowStyle());
        tblStudentInfo.Size = new Size(440, 414);
        tblStudentInfo.TabIndex = 0;
        // 
        // picStudentAvatar
        // 
        picStudentAvatar.BackColor = Color.FromArgb(232, 240, 250);
        tblStudentInfo.SetColumnSpan(picStudentAvatar, 2);
        picStudentAvatar.Dock = DockStyle.Fill;
        picStudentAvatar.Location = new Point(3, 3);
        picStudentAvatar.Name = "picStudentAvatar";
        picStudentAvatar.Size = new Size(434, 174);
        picStudentAvatar.SizeMode = PictureBoxSizeMode.Zoom;
        picStudentAvatar.TabIndex = 0;
        picStudentAvatar.TabStop = false;
        // 
        // btnChooseStudentAvatar
        // 
        btnChooseStudentAvatar.Dock = DockStyle.Fill;
        btnChooseStudentAvatar.Location = new Point(3, 183);
        btnChooseStudentAvatar.Name = "btnChooseStudentAvatar";
        btnChooseStudentAvatar.Size = new Size(114, 30);
        btnChooseStudentAvatar.TabIndex = 1;
        btnChooseStudentAvatar.Text = "Chá»n áº£nh";
        btnChooseStudentAvatar.UseVisualStyleBackColor = true;
        // 
        // btnRemoveStudentAvatar
        // 
        btnRemoveStudentAvatar.Dock = DockStyle.Left;
        btnRemoveStudentAvatar.Location = new Point(123, 183);
        btnRemoveStudentAvatar.Name = "btnRemoveStudentAvatar";
        btnRemoveStudentAvatar.Size = new Size(120, 30);
        btnRemoveStudentAvatar.TabIndex = 2;
        btnRemoveStudentAvatar.Text = "XÃ³a áº£nh";
        btnRemoveStudentAvatar.UseVisualStyleBackColor = true;
        // 
        // lblStudentId
        // 
        lblStudentId.Anchor = AnchorStyles.Left;
        lblStudentId.AutoSize = true;
        lblStudentId.Location = new Point(3, 222);
        lblStudentId.Name = "lblStudentId";
        lblStudentId.Size = new Size(92, 20);
        lblStudentId.TabIndex = 3;
        lblStudentId.Text = "MÃ£ há»c viÃªn";
        // 
        // txtStudentId
        // 
        txtStudentId.Dock = DockStyle.Fill;
        txtStudentId.Location = new Point(123, 219);
        txtStudentId.Name = "txtStudentId";
        txtStudentId.Size = new Size(314, 27);
        txtStudentId.TabIndex = 4;
        // 
        // lblStudentFullName
        // 
        lblStudentFullName.Anchor = AnchorStyles.Left;
        lblStudentFullName.AutoSize = true;
        lblStudentFullName.Location = new Point(3, 255);
        lblStudentFullName.Name = "lblStudentFullName";
        lblStudentFullName.Size = new Size(58, 20);
        lblStudentFullName.TabIndex = 5;
        lblStudentFullName.Text = "Há» tÃªn";
        // 
        // txtStudentFullName
        // 
        txtStudentFullName.Dock = DockStyle.Fill;
        txtStudentFullName.Location = new Point(123, 252);
        txtStudentFullName.Name = "txtStudentFullName";
        txtStudentFullName.Size = new Size(314, 27);
        txtStudentFullName.TabIndex = 6;
        // 
        // lblStudentBirthDate
        // 
        lblStudentBirthDate.Anchor = AnchorStyles.Left;
        lblStudentBirthDate.AutoSize = true;
        lblStudentBirthDate.Location = new Point(3, 288);
        lblStudentBirthDate.Name = "lblStudentBirthDate";
        lblStudentBirthDate.Size = new Size(79, 20);
        lblStudentBirthDate.TabIndex = 7;
        lblStudentBirthDate.Text = "NgÃ y sinh";
        // 
        // dtpStudentBirthDate
        // 
        dtpStudentBirthDate.Dock = DockStyle.Left;
        dtpStudentBirthDate.Format = DateTimePickerFormat.Short;
        dtpStudentBirthDate.Location = new Point(123, 285);
        dtpStudentBirthDate.Name = "dtpStudentBirthDate";
        dtpStudentBirthDate.Size = new Size(160, 27);
        dtpStudentBirthDate.TabIndex = 8;
        // 
        // lblStudentPhone
        // 
        lblStudentPhone.Anchor = AnchorStyles.Left;
        lblStudentPhone.AutoSize = true;
        lblStudentPhone.Location = new Point(3, 321);
        lblStudentPhone.Name = "lblStudentPhone";
        lblStudentPhone.Size = new Size(85, 20);
        lblStudentPhone.TabIndex = 9;
        lblStudentPhone.Text = "Äiá»‡n thoáº¡i";
        // 
        // txtStudentPhone
        // 
        txtStudentPhone.Dock = DockStyle.Fill;
        txtStudentPhone.Location = new Point(123, 318);
        txtStudentPhone.Name = "txtStudentPhone";
        txtStudentPhone.Size = new Size(314, 27);
        txtStudentPhone.TabIndex = 10;
        // 
        // lblStudentEmail
        // 
        lblStudentEmail.Anchor = AnchorStyles.Left;
        lblStudentEmail.AutoSize = true;
        lblStudentEmail.Location = new Point(3, 354);
        lblStudentEmail.Name = "lblStudentEmail";
        lblStudentEmail.Size = new Size(46, 20);
        lblStudentEmail.TabIndex = 11;
        lblStudentEmail.Text = "Email";
        // 
        // txtStudentEmail
        // 
        txtStudentEmail.Dock = DockStyle.Fill;
        txtStudentEmail.Location = new Point(123, 351);
        txtStudentEmail.Name = "txtStudentEmail";
        txtStudentEmail.Size = new Size(314, 27);
        txtStudentEmail.TabIndex = 12;
        // 
        // lblStudentStatus
        // 
        lblStudentStatus.Anchor = AnchorStyles.Left;
        lblStudentStatus.AutoSize = true;
        lblStudentStatus.Location = new Point(3, 389);
        lblStudentStatus.Name = "lblStudentStatus";
        lblStudentStatus.Size = new Size(78, 20);
        lblStudentStatus.TabIndex = 13;
        lblStudentStatus.Text = "Tráº¡ng thÃ¡i";
        // 
        // cboStudentStatus
        // 
        cboStudentStatus.Dock = DockStyle.Left;
        cboStudentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
        cboStudentStatus.FormattingEnabled = true;
        cboStudentStatus.Items.AddRange(new object[] { "Äang há»c", "Báº£o lÆ°u", "Ngá»«ng há»c" });
        cboStudentStatus.Location = new Point(123, 384);
        cboStudentStatus.Name = "cboStudentStatus";
        cboStudentStatus.Size = new Size(180, 28);
        cboStudentStatus.TabIndex = 14;
        // 
        // flpStudentActions
        // 
        flpStudentActions.AutoSize = true;
        flpStudentActions.Controls.Add(btnCreateStudent);
        flpStudentActions.Controls.Add(btnSaveStudent);
        flpStudentActions.Controls.Add(btnUpdateStudent);
        flpStudentActions.Controls.Add(btnDeleteStudent);
        flpStudentActions.Controls.Add(btnResetStudent);
        flpStudentActions.Controls.Add(btnOpenEnrollment);
        flpStudentActions.Dock = DockStyle.Fill;
        flpStudentActions.FlowDirection = FlowDirection.LeftToRight;
        flpStudentActions.Location = new Point(3, 555);
        flpStudentActions.Name = "flpStudentActions";
        flpStudentActions.Size = new Size(950, 38);
        flpStudentActions.TabIndex = 2;
        flpStudentActions.WrapContents = false;
        // 
        // btnCreateStudent
        // 
        btnCreateStudent.Location = new Point(3, 3);
        btnCreateStudent.Name = "btnCreateStudent";
        btnCreateStudent.Size = new Size(100, 32);
        btnCreateStudent.TabIndex = 0;
        btnCreateStudent.Text = "ThÃªm má»›i";
        btnCreateStudent.UseVisualStyleBackColor = true;
        // 
        // btnSaveStudent
        // 
        btnSaveStudent.Location = new Point(109, 3);
        btnSaveStudent.Name = "btnSaveStudent";
        btnSaveStudent.Size = new Size(100, 32);
        btnSaveStudent.TabIndex = 1;
        btnSaveStudent.Text = "LÆ°u";
        btnSaveStudent.UseVisualStyleBackColor = true;
        // 
        // btnUpdateStudent
        // 
        btnUpdateStudent.Location = new Point(215, 3);
        btnUpdateStudent.Name = "btnUpdateStudent";
        btnUpdateStudent.Size = new Size(110, 32);
        btnUpdateStudent.TabIndex = 2;
        btnUpdateStudent.Text = "Cáº­p nháº­t";
        btnUpdateStudent.UseVisualStyleBackColor = true;
        // 
        // btnDeleteStudent
        // 
        btnDeleteStudent.Location = new Point(331, 3);
        btnDeleteStudent.Name = "btnDeleteStudent";
        btnDeleteStudent.Size = new Size(90, 32);
        btnDeleteStudent.TabIndex = 3;
        btnDeleteStudent.Text = "XÃ³a";
        btnDeleteStudent.UseVisualStyleBackColor = true;
        // 
        // btnResetStudent
        // 
        btnResetStudent.Location = new Point(427, 3);
        btnResetStudent.Name = "btnResetStudent";
        btnResetStudent.Size = new Size(100, 32);
        btnResetStudent.TabIndex = 4;
        btnResetStudent.Text = "LÃ m má»›i";
        btnResetStudent.UseVisualStyleBackColor = true;
        // 
        // btnOpenEnrollment
        // 
        btnOpenEnrollment.Location = new Point(533, 3);
        btnOpenEnrollment.Name = "btnOpenEnrollment";
        btnOpenEnrollment.Size = new Size(140, 32);
        btnOpenEnrollment.TabIndex = 5;
        btnOpenEnrollment.Text = "Má»Ÿ ghi danh";
        btnOpenEnrollment.UseVisualStyleBackColor = true;
        // 
        // errStudent
        // 
        errStudent.ContainerControl = this;
        // 
        // FrmStudentManagement
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(980, 620);
        Controls.Add(tblStudentRoot);
        Name = "FrmStudentManagement";
        Padding = new Padding(12);
        Text = "Quáº£n lÃ½ há»c viÃªn";
        tblStudentRoot.ResumeLayout(false);
        tblStudentRoot.PerformLayout();
        pnlStudentFilterCard.ResumeLayout(false);
        pnlStudentFilterCard.PerformLayout();
        splStudentContent.Panel1.ResumeLayout(false);
        splStudentContent.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splStudentContent).EndInit();
        splStudentContent.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvStudentList).EndInit();
        grpStudentInfo.ResumeLayout(false);
        tblStudentInfo.ResumeLayout(false);
        tblStudentInfo.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)picStudentAvatar).EndInit();
        flpStudentActions.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)errStudent).EndInit();
        ResumeLayout(false);
    }
}

