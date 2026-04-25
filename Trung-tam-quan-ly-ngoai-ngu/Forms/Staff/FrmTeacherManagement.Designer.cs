namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmTeacherManagement
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlTeacherFilterCard;
    private TextBox txtTeacherKeyword;
    private ComboBox cboTeacherStatusFilter;
    private Button btnSearchTeacher;
    private Button btnRefreshTeacher;
    private DataGridView dgvTeacherList;
    private GroupBox grpTeacherInfo;
    private ErrorProvider errTeacher;
    private Button btnCreateTeacher;
    private Button btnSaveTeacher;
    private Button btnUpdateTeacher;
    private Button btnDeleteTeacher;
    private TableLayoutPanel tblTeacherRoot;
    private Label lblTeacherKeyword;
    private Label lblTeacherStatus;
    private SplitContainer splTeacherContent;
    private TableLayoutPanel tblTeacherDetail;
    private Label lblTeacherCode;
    private TextBox txtTeacherCode;
    private Label lblTeacherName;
    private TextBox txtTeacherName;
    private Label lblTeacherPhone;
    private TextBox txtTeacherPhone;
    private Label lblTeacherEmail;
    private TextBox txtTeacherEmail;
    private Label lblTeacherSpecialty;
    private TextBox txtTeacherSpecialty;
    private Label lblTeacherAddress;
    private TextBox txtTeacherAddress;
    private Label lblTeacherNote;
    private TextBox txtTeacherNote;
    private FlowLayoutPanel flpTeacherActions;

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
        pnlTeacherFilterCard = new Panel();
        lblTeacherKeyword = new Label();
        txtTeacherKeyword = new TextBox();
        lblTeacherStatus = new Label();
        cboTeacherStatusFilter = new ComboBox();
        btnSearchTeacher = new Button();
        btnRefreshTeacher = new Button();
        dgvTeacherList = new DataGridView();
        grpTeacherInfo = new GroupBox();
        tblTeacherDetail = new TableLayoutPanel();
        lblTeacherCode = new Label();
        txtTeacherCode = new TextBox();
        lblTeacherName = new Label();
        txtTeacherName = new TextBox();
        lblTeacherPhone = new Label();
        txtTeacherPhone = new TextBox();
        lblTeacherEmail = new Label();
        txtTeacherEmail = new TextBox();
        lblTeacherSpecialty = new Label();
        txtTeacherSpecialty = new TextBox();
        lblTeacherAddress = new Label();
        txtTeacherAddress = new TextBox();
        lblTeacherNote = new Label();
        txtTeacherNote = new TextBox();
        errTeacher = new ErrorProvider(components);
        btnCreateTeacher = new Button();
        btnSaveTeacher = new Button();
        btnUpdateTeacher = new Button();
        btnDeleteTeacher = new Button();
        tblTeacherRoot = new TableLayoutPanel();
        splTeacherContent = new SplitContainer();
        flpTeacherActions = new FlowLayoutPanel();
        pnlTeacherFilterCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvTeacherList).BeginInit();
        grpTeacherInfo.SuspendLayout();
        tblTeacherDetail.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)errTeacher).BeginInit();
        tblTeacherRoot.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splTeacherContent).BeginInit();
        splTeacherContent.Panel1.SuspendLayout();
        splTeacherContent.Panel2.SuspendLayout();
        splTeacherContent.SuspendLayout();
        flpTeacherActions.SuspendLayout();
        SuspendLayout();
        // 
        // pnlTeacherFilterCard
        // 
        pnlTeacherFilterCard.BorderStyle = BorderStyle.FixedSingle;
        pnlTeacherFilterCard.Controls.Add(btnRefreshTeacher);
        pnlTeacherFilterCard.Controls.Add(btnSearchTeacher);
        pnlTeacherFilterCard.Controls.Add(cboTeacherStatusFilter);
        pnlTeacherFilterCard.Controls.Add(lblTeacherStatus);
        pnlTeacherFilterCard.Controls.Add(txtTeacherKeyword);
        pnlTeacherFilterCard.Controls.Add(lblTeacherKeyword);
        pnlTeacherFilterCard.Dock = DockStyle.Fill;
        pnlTeacherFilterCard.Location = new Point(3, 3);
        pnlTeacherFilterCard.Name = "pnlTeacherFilterCard";
        pnlTeacherFilterCard.Padding = new Padding(16, 14, 16, 14);
        pnlTeacherFilterCard.Size = new Size(974, 82);
        pnlTeacherFilterCard.TabIndex = 0;
        // 
        // lblTeacherKeyword
        // 
        lblTeacherKeyword.AutoSize = true;
        lblTeacherKeyword.Location = new Point(16, 18);
        lblTeacherKeyword.Name = "lblTeacherKeyword";
        lblTeacherKeyword.Size = new Size(95, 20);
        lblTeacherKeyword.TabIndex = 0;
        lblTeacherKeyword.Text = "Tá»« khÃ³a tÃ¬m";
        // 
        // txtTeacherKeyword
        // 
        txtTeacherKeyword.Location = new Point(16, 41);
        txtTeacherKeyword.Name = "txtTeacherKeyword";
        txtTeacherKeyword.PlaceholderText = "MÃ£ giÃ¡o viÃªn, há» tÃªn hoáº·c Ä‘iá»‡n thoáº¡i";
        txtTeacherKeyword.Size = new Size(280, 27);
        txtTeacherKeyword.TabIndex = 1;
        // 
        // lblTeacherStatus
        // 
        lblTeacherStatus.AutoSize = true;
        lblTeacherStatus.Location = new Point(318, 18);
        lblTeacherStatus.Name = "lblTeacherStatus";
        lblTeacherStatus.Size = new Size(78, 20);
        lblTeacherStatus.TabIndex = 2;
        lblTeacherStatus.Text = "Tráº¡ng thÃ¡i";
        // 
        // cboTeacherStatusFilter
        // 
        cboTeacherStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTeacherStatusFilter.FormattingEnabled = true;
        cboTeacherStatusFilter.Items.AddRange(new object[] { "Táº¥t cáº£", "Äang dáº¡y", "Táº¡m nghá»‰" });
        cboTeacherStatusFilter.Location = new Point(318, 41);
        cboTeacherStatusFilter.Name = "cboTeacherStatusFilter";
        cboTeacherStatusFilter.Size = new Size(190, 28);
        cboTeacherStatusFilter.TabIndex = 3;
        // 
        // btnSearchTeacher
        // 
        btnSearchTeacher.Location = new Point(532, 39);
        btnSearchTeacher.Name = "btnSearchTeacher";
        btnSearchTeacher.Size = new Size(100, 30);
        btnSearchTeacher.TabIndex = 4;
        btnSearchTeacher.Text = "TÃ¬m kiáº¿m";
        btnSearchTeacher.UseVisualStyleBackColor = true;
        // 
        // btnRefreshTeacher
        // 
        btnRefreshTeacher.Location = new Point(640, 39);
        btnRefreshTeacher.Name = "btnRefreshTeacher";
        btnRefreshTeacher.Size = new Size(108, 30);
        btnRefreshTeacher.TabIndex = 5;
        btnRefreshTeacher.Text = "LÃ m má»›i";
        btnRefreshTeacher.UseVisualStyleBackColor = true;
        // 
        // dgvTeacherList
        // 
        dgvTeacherList.AllowUserToAddRows = false;
        dgvTeacherList.AllowUserToDeleteRows = false;
        dgvTeacherList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvTeacherList.BackgroundColor = Color.White;
        dgvTeacherList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvTeacherList.Dock = DockStyle.Fill;
        dgvTeacherList.Location = new Point(0, 0);
        dgvTeacherList.MultiSelect = false;
        dgvTeacherList.Name = "dgvTeacherList";
        dgvTeacherList.ReadOnly = true;
        dgvTeacherList.RowHeadersVisible = false;
        dgvTeacherList.RowHeadersWidth = 51;
        dgvTeacherList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvTeacherList.Size = new Size(388, 458);
        dgvTeacherList.TabIndex = 0;
        // 
        // grpTeacherInfo
        // 
        grpTeacherInfo.Controls.Add(tblTeacherDetail);
        grpTeacherInfo.Dock = DockStyle.Fill;
        grpTeacherInfo.Location = new Point(6, 0);
        grpTeacherInfo.Name = "grpTeacherInfo";
        grpTeacherInfo.Padding = new Padding(14, 10, 14, 14);
        grpTeacherInfo.Size = new Size(580, 458);
        grpTeacherInfo.TabIndex = 0;
        grpTeacherInfo.TabStop = false;
        grpTeacherInfo.Text = "ThÃ´ng tin giÃ¡o viÃªn";
        // 
        // tblTeacherDetail
        // 
        tblTeacherDetail.ColumnCount = 2;
        tblTeacherDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
        tblTeacherDetail.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblTeacherDetail.Controls.Add(lblTeacherCode, 0, 0);
        tblTeacherDetail.Controls.Add(txtTeacherCode, 1, 0);
        tblTeacherDetail.Controls.Add(lblTeacherName, 0, 1);
        tblTeacherDetail.Controls.Add(txtTeacherName, 1, 1);
        tblTeacherDetail.Controls.Add(lblTeacherPhone, 0, 2);
        tblTeacherDetail.Controls.Add(txtTeacherPhone, 1, 2);
        tblTeacherDetail.Controls.Add(lblTeacherEmail, 0, 3);
        tblTeacherDetail.Controls.Add(txtTeacherEmail, 1, 3);
        tblTeacherDetail.Controls.Add(lblTeacherSpecialty, 0, 4);
        tblTeacherDetail.Controls.Add(txtTeacherSpecialty, 1, 4);
        tblTeacherDetail.Controls.Add(lblTeacherAddress, 0, 5);
        tblTeacherDetail.Controls.Add(txtTeacherAddress, 1, 5);
        tblTeacherDetail.Controls.Add(lblTeacherNote, 0, 6);
        tblTeacherDetail.Controls.Add(txtTeacherNote, 1, 6);
        tblTeacherDetail.Dock = DockStyle.Fill;
        tblTeacherDetail.Location = new Point(14, 32);
        tblTeacherDetail.Name = "tblTeacherDetail";
        tblTeacherDetail.RowCount = 7;
        tblTeacherDetail.RowStyles.Add(new RowStyle());
        tblTeacherDetail.RowStyles.Add(new RowStyle());
        tblTeacherDetail.RowStyles.Add(new RowStyle());
        tblTeacherDetail.RowStyles.Add(new RowStyle());
        tblTeacherDetail.RowStyles.Add(new RowStyle());
        tblTeacherDetail.RowStyles.Add(new RowStyle());
        tblTeacherDetail.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblTeacherDetail.Size = new Size(552, 412);
        tblTeacherDetail.TabIndex = 0;
        // 
        // lblTeacherCode
        // 
        lblTeacherCode.Anchor = AnchorStyles.Left;
        lblTeacherCode.AutoSize = true;
        lblTeacherCode.Location = new Point(3, 6);
        lblTeacherCode.Name = "lblTeacherCode";
        lblTeacherCode.Size = new Size(99, 20);
        lblTeacherCode.TabIndex = 0;
        lblTeacherCode.Text = "MÃ£ giÃ¡o viÃªn";
        // 
        // txtTeacherCode
        // 
        txtTeacherCode.Dock = DockStyle.Fill;
        txtTeacherCode.Location = new Point(143, 3);
        txtTeacherCode.Name = "txtTeacherCode";
        txtTeacherCode.Size = new Size(406, 27);
        txtTeacherCode.TabIndex = 1;
        // 
        // lblTeacherName
        // 
        lblTeacherName.Anchor = AnchorStyles.Left;
        lblTeacherName.AutoSize = true;
        lblTeacherName.Location = new Point(3, 39);
        lblTeacherName.Name = "lblTeacherName";
        lblTeacherName.Size = new Size(54, 20);
        lblTeacherName.TabIndex = 2;
        lblTeacherName.Text = "Há» tÃªn";
        // 
        // txtTeacherName
        // 
        txtTeacherName.Dock = DockStyle.Fill;
        txtTeacherName.Location = new Point(143, 36);
        txtTeacherName.Name = "txtTeacherName";
        txtTeacherName.Size = new Size(406, 27);
        txtTeacherName.TabIndex = 3;
        // 
        // lblTeacherPhone
        // 
        lblTeacherPhone.Anchor = AnchorStyles.Left;
        lblTeacherPhone.AutoSize = true;
        lblTeacherPhone.Location = new Point(3, 72);
        lblTeacherPhone.Name = "lblTeacherPhone";
        lblTeacherPhone.Size = new Size(95, 20);
        lblTeacherPhone.TabIndex = 4;
        lblTeacherPhone.Text = "Sá»‘ Ä‘iá»‡n thoáº¡i";
        // 
        // txtTeacherPhone
        // 
        txtTeacherPhone.Dock = DockStyle.Fill;
        txtTeacherPhone.Location = new Point(143, 69);
        txtTeacherPhone.Name = "txtTeacherPhone";
        txtTeacherPhone.Size = new Size(406, 27);
        txtTeacherPhone.TabIndex = 5;
        // 
        // lblTeacherEmail
        // 
        lblTeacherEmail.Anchor = AnchorStyles.Left;
        lblTeacherEmail.AutoSize = true;
        lblTeacherEmail.Location = new Point(3, 105);
        lblTeacherEmail.Name = "lblTeacherEmail";
        lblTeacherEmail.Size = new Size(46, 20);
        lblTeacherEmail.TabIndex = 6;
        lblTeacherEmail.Text = "Email";
        // 
        // txtTeacherEmail
        // 
        txtTeacherEmail.Dock = DockStyle.Fill;
        txtTeacherEmail.Location = new Point(143, 102);
        txtTeacherEmail.Name = "txtTeacherEmail";
        txtTeacherEmail.Size = new Size(406, 27);
        txtTeacherEmail.TabIndex = 7;
        // 
        // lblTeacherSpecialty
        // 
        lblTeacherSpecialty.Anchor = AnchorStyles.Left;
        lblTeacherSpecialty.AutoSize = true;
        lblTeacherSpecialty.Location = new Point(3, 138);
        lblTeacherSpecialty.Name = "lblTeacherSpecialty";
        lblTeacherSpecialty.Size = new Size(82, 20);
        lblTeacherSpecialty.TabIndex = 8;
        lblTeacherSpecialty.Text = "ChuyÃªn mÃ´n";
        // 
        // txtTeacherSpecialty
        // 
        txtTeacherSpecialty.Dock = DockStyle.Fill;
        txtTeacherSpecialty.Location = new Point(143, 135);
        txtTeacherSpecialty.Name = "txtTeacherSpecialty";
        txtTeacherSpecialty.Size = new Size(406, 27);
        txtTeacherSpecialty.TabIndex = 9;
        // 
        // lblTeacherAddress
        // 
        lblTeacherAddress.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        lblTeacherAddress.AutoSize = true;
        lblTeacherAddress.Location = new Point(3, 171);
        lblTeacherAddress.Name = "lblTeacherAddress";
        lblTeacherAddress.Size = new Size(55, 20);
        lblTeacherAddress.TabIndex = 10;
        lblTeacherAddress.Text = "Äá»‹a chá»‰";
        // 
        // txtTeacherAddress
        // 
        txtTeacherAddress.Dock = DockStyle.Fill;
        txtTeacherAddress.Location = new Point(143, 168);
        txtTeacherAddress.Multiline = true;
        txtTeacherAddress.Name = "txtTeacherAddress";
        txtTeacherAddress.Size = new Size(406, 60);
        txtTeacherAddress.TabIndex = 11;
        // 
        // lblTeacherNote
        // 
        lblTeacherNote.Anchor = AnchorStyles.Left | AnchorStyles.Top;
        lblTeacherNote.AutoSize = true;
        lblTeacherNote.Location = new Point(3, 237);
        lblTeacherNote.Name = "lblTeacherNote";
        lblTeacherNote.Size = new Size(57, 20);
        lblTeacherNote.TabIndex = 12;
        lblTeacherNote.Text = "Ghi chÃº";
        // 
        // txtTeacherNote
        // 
        txtTeacherNote.Dock = DockStyle.Fill;
        txtTeacherNote.Location = new Point(143, 234);
        txtTeacherNote.Multiline = true;
        txtTeacherNote.Name = "txtTeacherNote";
        txtTeacherNote.ScrollBars = ScrollBars.Vertical;
        txtTeacherNote.Size = new Size(406, 175);
        txtTeacherNote.TabIndex = 13;
        // 
        // errTeacher
        // 
        errTeacher.ContainerControl = this;
        // 
        // btnCreateTeacher
        // 
        btnCreateTeacher.Location = new Point(3, 3);
        btnCreateTeacher.Name = "btnCreateTeacher";
        btnCreateTeacher.Size = new Size(110, 34);
        btnCreateTeacher.TabIndex = 0;
        btnCreateTeacher.Text = "ThÃªm má»›i";
        btnCreateTeacher.UseVisualStyleBackColor = true;
        // 
        // btnSaveTeacher
        // 
        btnSaveTeacher.Location = new Point(119, 3);
        btnSaveTeacher.Name = "btnSaveTeacher";
        btnSaveTeacher.Size = new Size(110, 34);
        btnSaveTeacher.TabIndex = 1;
        btnSaveTeacher.Text = "LÆ°u";
        btnSaveTeacher.UseVisualStyleBackColor = true;
        // 
        // btnUpdateTeacher
        // 
        btnUpdateTeacher.Location = new Point(235, 3);
        btnUpdateTeacher.Name = "btnUpdateTeacher";
        btnUpdateTeacher.Size = new Size(110, 34);
        btnUpdateTeacher.TabIndex = 2;
        btnUpdateTeacher.Text = "Cáº­p nháº­t";
        btnUpdateTeacher.UseVisualStyleBackColor = true;
        // 
        // btnDeleteTeacher
        // 
        btnDeleteTeacher.Location = new Point(351, 3);
        btnDeleteTeacher.Name = "btnDeleteTeacher";
        btnDeleteTeacher.Size = new Size(110, 34);
        btnDeleteTeacher.TabIndex = 3;
        btnDeleteTeacher.Text = "XÃ³a má»m";
        btnDeleteTeacher.UseVisualStyleBackColor = true;
        // 
        // tblTeacherRoot
        // 
        tblTeacherRoot.ColumnCount = 1;
        tblTeacherRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblTeacherRoot.Controls.Add(pnlTeacherFilterCard, 0, 0);
        tblTeacherRoot.Controls.Add(splTeacherContent, 0, 1);
        tblTeacherRoot.Controls.Add(flpTeacherActions, 0, 2);
        tblTeacherRoot.Dock = DockStyle.Fill;
        tblTeacherRoot.Location = new Point(12, 12);
        tblTeacherRoot.Name = "tblTeacherRoot";
        tblTeacherRoot.RowCount = 3;
        tblTeacherRoot.RowStyles.Add(new RowStyle());
        tblTeacherRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblTeacherRoot.RowStyles.Add(new RowStyle());
        tblTeacherRoot.Size = new Size(980, 616);
        tblTeacherRoot.TabIndex = 0;
        // 
        // splTeacherContent
        // 
        splTeacherContent.Dock = DockStyle.Fill;
        splTeacherContent.Location = new Point(3, 91);
        splTeacherContent.Name = "splTeacherContent";
        // 
        // splTeacherContent.Panel1
        // 
        splTeacherContent.Panel1.Controls.Add(dgvTeacherList);
        splTeacherContent.Panel1.Padding = new Padding(0, 0, 6, 0);
        // 
        // splTeacherContent.Panel2
        // 
        splTeacherContent.Panel2.Controls.Add(grpTeacherInfo);
        splTeacherContent.Panel2.Padding = new Padding(6, 0, 0, 0);
        splTeacherContent.Size = new Size(974, 458);
        splTeacherContent.SplitterDistance = 394;
        splTeacherContent.TabIndex = 1;
        // 
        // flpTeacherActions
        // 
        flpTeacherActions.AutoSize = true;
        flpTeacherActions.Controls.Add(btnCreateTeacher);
        flpTeacherActions.Controls.Add(btnSaveTeacher);
        flpTeacherActions.Controls.Add(btnUpdateTeacher);
        flpTeacherActions.Controls.Add(btnDeleteTeacher);
        flpTeacherActions.Dock = DockStyle.Fill;
        flpTeacherActions.Location = new Point(3, 555);
        flpTeacherActions.Name = "flpTeacherActions";
        flpTeacherActions.Size = new Size(974, 58);
        flpTeacherActions.TabIndex = 2;
        flpTeacherActions.WrapContents = false;
        // 
        // FrmTeacherManagement
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(1004, 640);
        Controls.Add(tblTeacherRoot);
        Name = "FrmTeacherManagement";
        Padding = new Padding(12);
        Text = "Quáº£n lÃ½ giÃ¡o viÃªn";
        pnlTeacherFilterCard.ResumeLayout(false);
        pnlTeacherFilterCard.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvTeacherList).EndInit();
        grpTeacherInfo.ResumeLayout(false);
        tblTeacherDetail.ResumeLayout(false);
        tblTeacherDetail.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)errTeacher).EndInit();
        tblTeacherRoot.ResumeLayout(false);
        tblTeacherRoot.PerformLayout();
        splTeacherContent.Panel1.ResumeLayout(false);
        splTeacherContent.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splTeacherContent).EndInit();
        splTeacherContent.ResumeLayout(false);
        flpTeacherActions.ResumeLayout(false);
        ResumeLayout(false);
    }
}

