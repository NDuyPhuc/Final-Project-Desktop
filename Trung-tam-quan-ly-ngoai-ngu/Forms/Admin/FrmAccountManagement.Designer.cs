namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmAccountManagement
{
    private System.ComponentModel.IContainer components = null;
    private TableLayoutPanel tblAccountRoot;
    private Panel pnlAccountListColumn;
    private Label lblAccountListTitle;
    private Panel pnlAccountFilterCard;
    private TextBox txtAccountKeyword;
    private ComboBox cboAccountRoleFilter;
    private Button btnSearchAccount;
    private Button btnRefreshAccount;
    private FlowLayoutPanel flpAccountCards;
    private Panel pnlAccountDetailColumn;
    private Panel pnlAccountHeader;
    private Label lblAccountTitle;
    private Label lblAccountIdentifier;
    private Button btnCreateAccount;
    private Panel pnlAccountInfoCard;
    private TableLayoutPanel tblAccountInfo;
    private Label lblDisplayName;
    private TextBox txtDisplayName;
    private Label lblUsername;
    private TextBox txtUsername;
    private Label lblEmail;
    private TextBox txtEmail;
    private Label lblPhone;
    private TextBox txtPhone;
    private Label lblRole;
    private ComboBox cboAccountRole;
    private Label lblStatus;
    private FlowLayoutPanel flpAccountStatus;
    private RadioButton rdoAccountActive;
    private RadioButton rdoAccountLocked;
    private FlowLayoutPanel flpAccountActions;
    private Button btnSaveAccount;
    private Button btnResetPassword;
    private Button btnToggleAccountStatus;
    private Panel pnlPermissionRuleCard;
    private Label lblPermissionRuleTitle;
    private TableLayoutPanel tblPermissionCards;
    private Panel pnlPermissionAdmin;
    private Label lblPermissionAdminTitle;
    private Label lblPermissionAdminBody;
    private Panel pnlPermissionStaff;
    private Label lblPermissionStaffTitle;
    private Label lblPermissionStaffBody;
    private Panel pnlPermissionTeacher;
    private Label lblPermissionTeacherTitle;
    private Label lblPermissionTeacherBody;
    private Label lblPermissionFooter;
    private ErrorProvider errAccount;

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
        tblAccountRoot = new TableLayoutPanel();
        pnlAccountListColumn = new Panel();
        flpAccountCards = new FlowLayoutPanel();
        pnlAccountFilterCard = new Panel();
        btnRefreshAccount = new Button();
        btnSearchAccount = new Button();
        cboAccountRoleFilter = new ComboBox();
        txtAccountKeyword = new TextBox();
        lblAccountListTitle = new Label();
        pnlAccountDetailColumn = new Panel();
        pnlPermissionRuleCard = new Panel();
        lblPermissionFooter = new Label();
        tblPermissionCards = new TableLayoutPanel();
        pnlPermissionAdmin = new Panel();
        lblPermissionAdminBody = new Label();
        lblPermissionAdminTitle = new Label();
        pnlPermissionStaff = new Panel();
        lblPermissionStaffBody = new Label();
        lblPermissionStaffTitle = new Label();
        pnlPermissionTeacher = new Panel();
        lblPermissionTeacherBody = new Label();
        lblPermissionTeacherTitle = new Label();
        lblPermissionRuleTitle = new Label();
        pnlAccountInfoCard = new Panel();
        flpAccountActions = new FlowLayoutPanel();
        btnSaveAccount = new Button();
        btnResetPassword = new Button();
        btnToggleAccountStatus = new Button();
        tblAccountInfo = new TableLayoutPanel();
        lblDisplayName = new Label();
        txtDisplayName = new TextBox();
        lblUsername = new Label();
        txtUsername = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblPhone = new Label();
        txtPhone = new TextBox();
        lblRole = new Label();
        cboAccountRole = new ComboBox();
        lblStatus = new Label();
        flpAccountStatus = new FlowLayoutPanel();
        rdoAccountActive = new RadioButton();
        rdoAccountLocked = new RadioButton();
        pnlAccountHeader = new Panel();
        btnCreateAccount = new Button();
        lblAccountIdentifier = new Label();
        lblAccountTitle = new Label();
        errAccount = new ErrorProvider(components);
        tblAccountRoot.SuspendLayout();
        pnlAccountListColumn.SuspendLayout();
        pnlAccountFilterCard.SuspendLayout();
        pnlAccountDetailColumn.SuspendLayout();
        pnlPermissionRuleCard.SuspendLayout();
        tblPermissionCards.SuspendLayout();
        pnlPermissionAdmin.SuspendLayout();
        pnlPermissionStaff.SuspendLayout();
        pnlPermissionTeacher.SuspendLayout();
        pnlAccountInfoCard.SuspendLayout();
        flpAccountActions.SuspendLayout();
        tblAccountInfo.SuspendLayout();
        flpAccountStatus.SuspendLayout();
        pnlAccountHeader.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)errAccount).BeginInit();
        SuspendLayout();
        // 
        // tblAccountRoot
        // 
        tblAccountRoot.ColumnCount = 2;
        tblAccountRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
        tblAccountRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblAccountRoot.Controls.Add(pnlAccountListColumn, 0, 0);
        tblAccountRoot.Controls.Add(pnlAccountDetailColumn, 1, 0);
        tblAccountRoot.Dock = DockStyle.Fill;
        tblAccountRoot.Location = new Point(24, 24);
        tblAccountRoot.Margin = new Padding(4);
        tblAccountRoot.Name = "tblAccountRoot";
        tblAccountRoot.RowCount = 1;
        tblAccountRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblAccountRoot.Size = new Size(1132, 712);
        tblAccountRoot.TabIndex = 0;
        // 
        // pnlAccountListColumn
        // 
        pnlAccountListColumn.AutoScroll = false;
        pnlAccountListColumn.Controls.Add(flpAccountCards);
        pnlAccountListColumn.Controls.Add(pnlAccountFilterCard);
        pnlAccountListColumn.Controls.Add(lblAccountListTitle);
        pnlAccountListColumn.Dock = DockStyle.Fill;
        pnlAccountListColumn.Location = new Point(0, 0);
        pnlAccountListColumn.Margin = new Padding(0);
        pnlAccountListColumn.Name = "pnlAccountListColumn";
        pnlAccountListColumn.Padding = new Padding(0, 0, 30, 0);
        pnlAccountListColumn.Size = new Size(400, 712);
        pnlAccountListColumn.TabIndex = 0;
        // 
        // flpAccountCards
        // 
        flpAccountCards.Dock = DockStyle.Fill;
        flpAccountCards.FlowDirection = FlowDirection.TopDown;
        flpAccountCards.Location = new Point(0, 138);
        flpAccountCards.Margin = new Padding(4);
        flpAccountCards.Name = "flpAccountCards";
        flpAccountCards.Padding = new Padding(0, 6, 0, 0);
        flpAccountCards.Size = new Size(370, 574);
        flpAccountCards.TabIndex = 2;
        flpAccountCards.WrapContents = false;
        // 
        // pnlAccountFilterCard
        // 
        pnlAccountFilterCard.Controls.Add(btnRefreshAccount);
        pnlAccountFilterCard.Controls.Add(btnSearchAccount);
        pnlAccountFilterCard.Controls.Add(cboAccountRoleFilter);
        pnlAccountFilterCard.Controls.Add(txtAccountKeyword);
        pnlAccountFilterCard.Dock = DockStyle.Top;
        pnlAccountFilterCard.Location = new Point(0, 54);
        pnlAccountFilterCard.Margin = new Padding(4);
        pnlAccountFilterCard.Name = "pnlAccountFilterCard";
        pnlAccountFilterCard.Padding = new Padding(0, 15, 0, 15);
        pnlAccountFilterCard.Size = new Size(370, 84);
        pnlAccountFilterCard.TabIndex = 1;
        // 
        // btnRefreshAccount
        // 
        btnRefreshAccount.Location = new Point(525, 15);
        btnRefreshAccount.Margin = new Padding(4);
        btnRefreshAccount.Name = "btnRefreshAccount";
        btnRefreshAccount.Size = new Size(82, 48);
        btnRefreshAccount.TabIndex = 3;
        btnRefreshAccount.Text = "↻";
        btnRefreshAccount.UseVisualStyleBackColor = true;
        // 
        // btnSearchAccount
        // 
        btnSearchAccount.Location = new Point(430, 15);
        btnSearchAccount.Margin = new Padding(4);
        btnSearchAccount.Name = "btnSearchAccount";
        btnSearchAccount.Size = new Size(82, 48);
        btnSearchAccount.TabIndex = 2;
        btnSearchAccount.Text = "⌕";
        btnSearchAccount.UseVisualStyleBackColor = true;
        // 
        // cboAccountRoleFilter
        // 
        cboAccountRoleFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cboAccountRoleFilter.FormattingEnabled = true;
        cboAccountRoleFilter.Items.AddRange(new object[] { "Tất cả", "Admin", "Staff", "Teacher" });
        cboAccountRoleFilter.Location = new Point(0, 18);
        cboAccountRoleFilter.Margin = new Padding(4);
        cboAccountRoleFilter.Name = "cboAccountRoleFilter";
        cboAccountRoleFilter.Size = new Size(124, 36);
        cboAccountRoleFilter.TabIndex = 0;
        // 
        // txtAccountKeyword
        // 
        txtAccountKeyword.Location = new Point(135, 18);
        txtAccountKeyword.Margin = new Padding(4);
        txtAccountKeyword.Name = "txtAccountKeyword";
        txtAccountKeyword.PlaceholderText = "Tìm kiếm tài khoản...";
        txtAccountKeyword.Size = new Size(284, 34);
        txtAccountKeyword.TabIndex = 1;
        // 
        // lblAccountListTitle
        // 
        lblAccountListTitle.Dock = DockStyle.Top;
        lblAccountListTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblAccountListTitle.Location = new Point(0, 0);
        lblAccountListTitle.Margin = new Padding(4, 0, 4, 0);
        lblAccountListTitle.Name = "lblAccountListTitle";
        lblAccountListTitle.Size = new Size(370, 54);
        lblAccountListTitle.TabIndex = 0;
        lblAccountListTitle.Text = "Danh sách Tài khoản";
        // 
        // pnlAccountDetailColumn
        // 
        pnlAccountDetailColumn.AutoScroll = false;
        pnlAccountDetailColumn.Controls.Add(pnlPermissionRuleCard);
        pnlAccountDetailColumn.Controls.Add(pnlAccountInfoCard);
        pnlAccountDetailColumn.Controls.Add(pnlAccountHeader);
        pnlAccountDetailColumn.Dock = DockStyle.Fill;
        pnlAccountDetailColumn.Location = new Point(400, 0);
        pnlAccountDetailColumn.Margin = new Padding(0);
        pnlAccountDetailColumn.Name = "pnlAccountDetailColumn";
        pnlAccountDetailColumn.Padding = new Padding(12, 0, 0, 0);
        pnlAccountDetailColumn.Size = new Size(732, 712);
        pnlAccountDetailColumn.TabIndex = 1;
        // 
        // pnlPermissionRuleCard
        // 
        pnlPermissionRuleCard.Controls.Add(lblPermissionFooter);
        pnlPermissionRuleCard.Controls.Add(tblPermissionCards);
        pnlPermissionRuleCard.Controls.Add(lblPermissionRuleTitle);
        pnlPermissionRuleCard.Dock = DockStyle.Bottom;
        pnlPermissionRuleCard.Location = new Point(12, 1032);
        pnlPermissionRuleCard.Margin = new Padding(4);
        pnlPermissionRuleCard.Name = "pnlPermissionRuleCard";
        pnlPermissionRuleCard.Padding = new Padding(33, 27, 33, 27);
        pnlPermissionRuleCard.Size = new Size(694, 312);
        pnlPermissionRuleCard.TabIndex = 2;
        pnlPermissionRuleCard.Paint += pnlPermissionRuleCard_Paint;
        // 
        // lblPermissionFooter
        // 
        lblPermissionFooter.AutoSize = true;
        lblPermissionFooter.Dock = DockStyle.Bottom;
        lblPermissionFooter.ForeColor = Color.FromArgb(102, 112, 133);
        lblPermissionFooter.Location = new Point(33, 257);
        lblPermissionFooter.Margin = new Padding(4, 0, 4, 0);
        lblPermissionFooter.Name = "lblPermissionFooter";
        lblPermissionFooter.Size = new Size(449, 28);
        lblPermissionFooter.TabIndex = 2;
        lblPermissionFooter.Text = "LINGUISTIC ARCHITECT SECURITY PROTOCOL V2.4";
        lblPermissionFooter.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // tblPermissionCards
        // 
        tblPermissionCards.ColumnCount = 3;
        tblPermissionCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tblPermissionCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tblPermissionCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tblPermissionCards.Controls.Add(pnlPermissionAdmin, 0, 0);
        tblPermissionCards.Controls.Add(pnlPermissionStaff, 1, 0);
        tblPermissionCards.Controls.Add(pnlPermissionTeacher, 2, 0);
        tblPermissionCards.Dock = DockStyle.Top;
        tblPermissionCards.Location = new Point(33, 73);
        tblPermissionCards.Margin = new Padding(4);
        tblPermissionCards.Name = "tblPermissionCards";
        tblPermissionCards.RowCount = 1;
        tblPermissionCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblPermissionCards.Size = new Size(628, 162);
        tblPermissionCards.TabIndex = 1;
        // 
        // pnlPermissionAdmin
        // 
        pnlPermissionAdmin.Controls.Add(lblPermissionAdminBody);
        pnlPermissionAdmin.Controls.Add(lblPermissionAdminTitle);
        pnlPermissionAdmin.Dock = DockStyle.Fill;
        pnlPermissionAdmin.Location = new Point(0, 0);
        pnlPermissionAdmin.Margin = new Padding(0, 0, 18, 0);
        pnlPermissionAdmin.Name = "pnlPermissionAdmin";
        pnlPermissionAdmin.Padding = new Padding(24, 21, 24, 21);
        pnlPermissionAdmin.Size = new Size(191, 162);
        pnlPermissionAdmin.TabIndex = 0;
        // 
        // lblPermissionAdminBody
        // 
        lblPermissionAdminBody.AutoSize = true;
        lblPermissionAdminBody.Dock = DockStyle.Fill;
        lblPermissionAdminBody.ForeColor = Color.FromArgb(42, 51, 64);
        lblPermissionAdminBody.Location = new Point(24, 59);
        lblPermissionAdminBody.Margin = new Padding(4, 0, 4, 0);
        lblPermissionAdminBody.Name = "lblPermissionAdminBody";
        lblPermissionAdminBody.Size = new Size(558, 28);
        lblPermissionAdminBody.TabIndex = 1;
        lblPermissionAdminBody.Text = "Quản trị toàn diện và giám sát các hoạt động hệ thống tối cao.";
        // 
        // lblPermissionAdminTitle
        // 
        lblPermissionAdminTitle.Dock = DockStyle.Top;
        lblPermissionAdminTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblPermissionAdminTitle.Location = new Point(24, 21);
        lblPermissionAdminTitle.Margin = new Padding(4, 0, 4, 0);
        lblPermissionAdminTitle.Name = "lblPermissionAdminTitle";
        lblPermissionAdminTitle.Size = new Size(143, 38);
        lblPermissionAdminTitle.TabIndex = 0;
        lblPermissionAdminTitle.Text = "ADMIN";
        // 
        // pnlPermissionStaff
        // 
        pnlPermissionStaff.Controls.Add(lblPermissionStaffBody);
        pnlPermissionStaff.Controls.Add(lblPermissionStaffTitle);
        pnlPermissionStaff.Dock = DockStyle.Fill;
        pnlPermissionStaff.Location = new Point(209, 0);
        pnlPermissionStaff.Margin = new Padding(0, 0, 18, 0);
        pnlPermissionStaff.Name = "pnlPermissionStaff";
        pnlPermissionStaff.Padding = new Padding(24, 21, 24, 21);
        pnlPermissionStaff.Size = new Size(191, 162);
        pnlPermissionStaff.TabIndex = 1;
        // 
        // lblPermissionStaffBody
        // 
        lblPermissionStaffBody.AutoSize = true;
        lblPermissionStaffBody.Dock = DockStyle.Fill;
        lblPermissionStaffBody.ForeColor = Color.FromArgb(42, 51, 64);
        lblPermissionStaffBody.Location = new Point(24, 59);
        lblPermissionStaffBody.Margin = new Padding(4, 0, 4, 0);
        lblPermissionStaffBody.Name = "lblPermissionStaffBody";
        lblPermissionStaffBody.Size = new Size(563, 28);
        lblPermissionStaffBody.TabIndex = 1;
        lblPermissionStaffBody.Text = "Vận hành các quy trình tác nghiệp: Tuyển sinh, Thu phí, Xếp lớp.";
        // 
        // lblPermissionStaffTitle
        // 
        lblPermissionStaffTitle.Dock = DockStyle.Top;
        lblPermissionStaffTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblPermissionStaffTitle.Location = new Point(24, 21);
        lblPermissionStaffTitle.Margin = new Padding(4, 0, 4, 0);
        lblPermissionStaffTitle.Name = "lblPermissionStaffTitle";
        lblPermissionStaffTitle.Size = new Size(143, 38);
        lblPermissionStaffTitle.TabIndex = 0;
        lblPermissionStaffTitle.Text = "NHÂN VIÊN (STAFF)";
        // 
        // pnlPermissionTeacher
        // 
        pnlPermissionTeacher.Controls.Add(lblPermissionTeacherBody);
        pnlPermissionTeacher.Controls.Add(lblPermissionTeacherTitle);
        pnlPermissionTeacher.Dock = DockStyle.Fill;
        pnlPermissionTeacher.Location = new Point(418, 0);
        pnlPermissionTeacher.Margin = new Padding(0);
        pnlPermissionTeacher.Name = "pnlPermissionTeacher";
        pnlPermissionTeacher.Padding = new Padding(24, 21, 24, 21);
        pnlPermissionTeacher.Size = new Size(210, 162);
        pnlPermissionTeacher.TabIndex = 2;
        // 
        // lblPermissionTeacherBody
        // 
        lblPermissionTeacherBody.AutoSize = true;
        lblPermissionTeacherBody.Dock = DockStyle.Fill;
        lblPermissionTeacherBody.ForeColor = Color.FromArgb(42, 51, 64);
        lblPermissionTeacherBody.Location = new Point(24, 59);
        lblPermissionTeacherBody.Margin = new Padding(4, 0, 4, 0);
        lblPermissionTeacherBody.Name = "lblPermissionTeacherBody";
        lblPermissionTeacherBody.Size = new Size(631, 28);
        lblPermissionTeacherBody.TabIndex = 1;
        lblPermissionTeacherBody.Text = "Truy cập học liệu, quản lý lớp học được giảng dạy và đánh giá học viên.";
        // 
        // lblPermissionTeacherTitle
        // 
        lblPermissionTeacherTitle.Dock = DockStyle.Top;
        lblPermissionTeacherTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblPermissionTeacherTitle.Location = new Point(24, 21);
        lblPermissionTeacherTitle.Margin = new Padding(4, 0, 4, 0);
        lblPermissionTeacherTitle.Name = "lblPermissionTeacherTitle";
        lblPermissionTeacherTitle.Size = new Size(162, 38);
        lblPermissionTeacherTitle.TabIndex = 0;
        lblPermissionTeacherTitle.Text = "GIÁO VIÊN (TEACHER)";
        // 
        // lblPermissionRuleTitle
        // 
        lblPermissionRuleTitle.Dock = DockStyle.Top;
        lblPermissionRuleTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblPermissionRuleTitle.Location = new Point(33, 27);
        lblPermissionRuleTitle.Margin = new Padding(4, 0, 4, 0);
        lblPermissionRuleTitle.Name = "lblPermissionRuleTitle";
        lblPermissionRuleTitle.Size = new Size(628, 46);
        lblPermissionRuleTitle.TabIndex = 0;
        lblPermissionRuleTitle.Text = "QUY TẮC PHÂN QUYỀN HỆ THỐNG";
        // 
        // pnlAccountInfoCard
        // 
        pnlAccountInfoCard.Controls.Add(flpAccountActions);
        pnlAccountInfoCard.Controls.Add(tblAccountInfo);
        pnlAccountInfoCard.Dock = DockStyle.Top;
        pnlAccountInfoCard.Location = new Point(12, 141);
        pnlAccountInfoCard.Margin = new Padding(4);
        pnlAccountInfoCard.Name = "pnlAccountInfoCard";
        pnlAccountInfoCard.Padding = new Padding(33, 27, 33, 27);
        pnlAccountInfoCard.Size = new Size(694, 891);
        pnlAccountInfoCard.TabIndex = 1;
        // 
        // flpAccountActions
        // 
        flpAccountActions.Controls.Add(btnSaveAccount);
        flpAccountActions.Controls.Add(btnResetPassword);
        flpAccountActions.Controls.Add(btnToggleAccountStatus);
        flpAccountActions.Location = new Point(28, 501);
        flpAccountActions.Margin = new Padding(4);
        flpAccountActions.Name = "flpAccountActions";
        flpAccountActions.Size = new Size(909, 69);
        flpAccountActions.TabIndex = 1;
        flpAccountActions.WrapContents = false;
        // 
        // btnSaveAccount
        // 
        btnSaveAccount.Location = new Point(4, 4);
        btnSaveAccount.Margin = new Padding(4);
        btnSaveAccount.Name = "btnSaveAccount";
        btnSaveAccount.Size = new Size(225, 57);
        btnSaveAccount.TabIndex = 0;
        btnSaveAccount.Text = "LƯU THAY ĐỔI";
        btnSaveAccount.UseVisualStyleBackColor = true;
        // 
        // btnResetPassword
        // 
        btnResetPassword.Location = new Point(237, 4);
        btnResetPassword.Margin = new Padding(4);
        btnResetPassword.Name = "btnResetPassword";
        btnResetPassword.Size = new Size(255, 57);
        btnResetPassword.TabIndex = 1;
        btnResetPassword.Text = "ĐẶT LẠI MẬT KHẨU";
        btnResetPassword.UseVisualStyleBackColor = true;
        // 
        // btnToggleAccountStatus
        // 
        btnToggleAccountStatus.Location = new Point(500, 4);
        btnToggleAccountStatus.Margin = new Padding(4);
        btnToggleAccountStatus.Name = "btnToggleAccountStatus";
        btnToggleAccountStatus.Size = new Size(255, 57);
        btnToggleAccountStatus.TabIndex = 2;
        btnToggleAccountStatus.Text = "KHÓA TÀI KHOẢN";
        btnToggleAccountStatus.UseVisualStyleBackColor = true;
        btnToggleAccountStatus.Click += btnToggleAccountStatus_Click;
        // 
        // tblAccountInfo
        // 
        tblAccountInfo.ColumnCount = 2;
        tblAccountInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tblAccountInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tblAccountInfo.Controls.Add(lblDisplayName, 0, 0);
        tblAccountInfo.Controls.Add(txtDisplayName, 0, 1);
        tblAccountInfo.Controls.Add(lblUsername, 1, 0);
        tblAccountInfo.Controls.Add(txtUsername, 1, 1);
        tblAccountInfo.Controls.Add(lblEmail, 0, 2);
        tblAccountInfo.Controls.Add(txtEmail, 0, 3);
        tblAccountInfo.Controls.Add(lblPhone, 1, 2);
        tblAccountInfo.Controls.Add(txtPhone, 1, 3);
        tblAccountInfo.Controls.Add(lblRole, 0, 4);
        tblAccountInfo.Controls.Add(cboAccountRole, 0, 5);
        tblAccountInfo.Controls.Add(lblStatus, 1, 4);
        tblAccountInfo.Controls.Add(flpAccountStatus, 1, 5);
        tblAccountInfo.Dock = DockStyle.Top;
        tblAccountInfo.Location = new Point(33, 27);
        tblAccountInfo.Margin = new Padding(4);
        tblAccountInfo.Name = "tblAccountInfo";
        tblAccountInfo.RowCount = 6;
        tblAccountInfo.RowStyles.Add(new RowStyle());
        tblAccountInfo.RowStyles.Add(new RowStyle());
        tblAccountInfo.RowStyles.Add(new RowStyle());
        tblAccountInfo.RowStyles.Add(new RowStyle());
        tblAccountInfo.RowStyles.Add(new RowStyle());
        tblAccountInfo.RowStyles.Add(new RowStyle());
        tblAccountInfo.Size = new Size(628, 837);
        tblAccountInfo.TabIndex = 0;
        // 
        // lblDisplayName
        // 
        lblDisplayName.AutoSize = true;
        lblDisplayName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblDisplayName.Location = new Point(4, 0);
        lblDisplayName.Margin = new Padding(4, 0, 4, 0);
        lblDisplayName.Name = "lblDisplayName";
        lblDisplayName.Size = new Size(109, 25);
        lblDisplayName.TabIndex = 0;
        lblDisplayName.Text = "HỌ VÀ TÊN";
        // 
        // txtDisplayName
        // 
        txtDisplayName.Dock = DockStyle.Fill;
        txtDisplayName.Location = new Point(4, 29);
        txtDisplayName.Margin = new Padding(4);
        txtDisplayName.Name = "txtDisplayName";
        txtDisplayName.Size = new Size(306, 34);
        txtDisplayName.TabIndex = 1;
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblUsername.Location = new Point(318, 0);
        lblUsername.Margin = new Padding(4, 0, 4, 0);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(162, 25);
        lblUsername.TabIndex = 2;
        lblUsername.Text = "TÊN ĐĂNG NHẬP";
        // 
        // txtUsername
        // 
        txtUsername.Dock = DockStyle.Fill;
        txtUsername.Location = new Point(318, 29);
        txtUsername.Margin = new Padding(4);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(306, 34);
        txtUsername.TabIndex = 3;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblEmail.Location = new Point(4, 67);
        lblEmail.Margin = new Padding(4, 0, 4, 0);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(67, 25);
        lblEmail.TabIndex = 4;
        lblEmail.Text = "EMAIL";
        // 
        // txtEmail
        // 
        txtEmail.Dock = DockStyle.Fill;
        txtEmail.Location = new Point(4, 96);
        txtEmail.Margin = new Padding(4);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(306, 34);
        txtEmail.TabIndex = 5;
        // 
        // lblPhone
        // 
        lblPhone.AutoSize = true;
        lblPhone.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblPhone.Location = new Point(318, 67);
        lblPhone.Margin = new Padding(4, 0, 4, 0);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(147, 25);
        lblPhone.TabIndex = 6;
        lblPhone.Text = "SỐ ĐIỆN THOẠI";
        // 
        // txtPhone
        // 
        txtPhone.Dock = DockStyle.Fill;
        txtPhone.Location = new Point(318, 96);
        txtPhone.Margin = new Padding(4);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(306, 34);
        txtPhone.TabIndex = 7;
        // 
        // lblRole
        // 
        lblRole.AutoSize = true;
        lblRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblRole.Location = new Point(4, 134);
        lblRole.Margin = new Padding(4, 0, 4, 0);
        lblRole.Name = "lblRole";
        lblRole.Size = new Size(84, 25);
        lblRole.TabIndex = 8;
        lblRole.Text = "VAI TRÒ";
        // 
        // cboAccountRole
        // 
        cboAccountRole.Dock = DockStyle.Left;
        cboAccountRole.DropDownStyle = ComboBoxStyle.DropDownList;
        cboAccountRole.FormattingEnabled = true;
        cboAccountRole.Items.AddRange(new object[] { "Admin", "Staff", "Teacher" });
        cboAccountRole.Location = new Point(4, 163);
        cboAccountRole.Margin = new Padding(4);
        cboAccountRole.Name = "cboAccountRole";
        cboAccountRole.Size = new Size(306, 36);
        cboAccountRole.TabIndex = 9;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblStatus.Location = new Point(318, 134);
        lblStatus.Margin = new Padding(4, 0, 4, 0);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(124, 25);
        lblStatus.TabIndex = 10;
        lblStatus.Text = "TRẠNG THÁI";
        // 
        // flpAccountStatus
        // 
        flpAccountStatus.Controls.Add(rdoAccountActive);
        flpAccountStatus.Controls.Add(rdoAccountLocked);
        flpAccountStatus.Location = new Point(318, 163);
        flpAccountStatus.Margin = new Padding(4);
        flpAccountStatus.Name = "flpAccountStatus";
        flpAccountStatus.Size = new Size(306, 50);
        flpAccountStatus.TabIndex = 11;
        flpAccountStatus.WrapContents = false;
        // 
        // rdoAccountActive
        // 
        rdoAccountActive.AutoSize = true;
        rdoAccountActive.Location = new Point(4, 4);
        rdoAccountActive.Margin = new Padding(4);
        rdoAccountActive.Name = "rdoAccountActive";
        rdoAccountActive.Size = new Size(132, 32);
        rdoAccountActive.TabIndex = 0;
        rdoAccountActive.TabStop = true;
        rdoAccountActive.Text = "Hoạt động";
        rdoAccountActive.UseVisualStyleBackColor = true;
        // 
        // rdoAccountLocked
        // 
        rdoAccountLocked.AutoSize = true;
        rdoAccountLocked.Location = new Point(144, 4);
        rdoAccountLocked.Margin = new Padding(4);
        rdoAccountLocked.Name = "rdoAccountLocked";
        rdoAccountLocked.Size = new Size(82, 32);
        rdoAccountLocked.TabIndex = 1;
        rdoAccountLocked.TabStop = true;
        rdoAccountLocked.Text = "Khóa";
        rdoAccountLocked.UseVisualStyleBackColor = true;
        // 
        // pnlAccountHeader
        // 
        pnlAccountHeader.Controls.Add(btnCreateAccount);
        pnlAccountHeader.Controls.Add(lblAccountIdentifier);
        pnlAccountHeader.Controls.Add(lblAccountTitle);
        pnlAccountHeader.Dock = DockStyle.Top;
        pnlAccountHeader.Location = new Point(12, 0);
        pnlAccountHeader.Margin = new Padding(4);
        pnlAccountHeader.Name = "pnlAccountHeader";
        pnlAccountHeader.Size = new Size(694, 141);
        pnlAccountHeader.TabIndex = 0;
        // 
        // btnCreateAccount
        // 
        btnCreateAccount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCreateAccount.Location = new Point(335, 33);
        btnCreateAccount.Margin = new Padding(4);
        btnCreateAccount.Name = "btnCreateAccount";
        btnCreateAccount.Size = new Size(326, 66);
        btnCreateAccount.TabIndex = 2;
        btnCreateAccount.Text = "+ Tạo tài khoản mới";
        btnCreateAccount.UseVisualStyleBackColor = true;
        // 
        // lblAccountIdentifier
        // 
        lblAccountIdentifier.AutoSize = true;
        lblAccountIdentifier.ForeColor = Color.FromArgb(102, 112, 133);
        lblAccountIdentifier.Location = new Point(0, 84);
        lblAccountIdentifier.Margin = new Padding(4, 0, 4, 0);
        lblAccountIdentifier.Name = "lblAccountIdentifier";
        lblAccountIdentifier.Size = new Size(187, 28);
        lblAccountIdentifier.TabIndex = 1;
        lblAccountIdentifier.Text = "ID: USER-8842-ANV";
        // 
        // lblAccountTitle
        // 
        lblAccountTitle.AutoSize = true;
        lblAccountTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblAccountTitle.Location = new Point(0, 21);
        lblAccountTitle.Margin = new Padding(4, 0, 4, 0);
        lblAccountTitle.Name = "lblAccountTitle";
        lblAccountTitle.Size = new Size(369, 48);
        lblAccountTitle.TabIndex = 0;
        lblAccountTitle.Text = "CHI TIẾT TÀI KHOẢN";
        // 
        // errAccount
        // 
        errAccount.ContainerControl = this;
        // 
        // FrmAccountManagement
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        AutoScroll = false;
        BackColor = Color.FromArgb(241, 248, 255);
        ClientSize = new Size(1180, 760);
        Controls.Add(tblAccountRoot);
        Font = new Font("Segoe UI", 10F);
        Margin = new Padding(4);
        MinimumSize = new Size(980, 640);
        Name = "FrmAccountManagement";
        Padding = new Padding(24);
        Text = "Tài khoản và phân quyền";
        tblAccountRoot.ResumeLayout(false);
        pnlAccountListColumn.ResumeLayout(false);
        pnlAccountFilterCard.ResumeLayout(false);
        pnlAccountFilterCard.PerformLayout();
        pnlAccountDetailColumn.ResumeLayout(false);
        pnlPermissionRuleCard.ResumeLayout(false);
        pnlPermissionRuleCard.PerformLayout();
        tblPermissionCards.ResumeLayout(false);
        pnlPermissionAdmin.ResumeLayout(false);
        pnlPermissionAdmin.PerformLayout();
        pnlPermissionStaff.ResumeLayout(false);
        pnlPermissionStaff.PerformLayout();
        pnlPermissionTeacher.ResumeLayout(false);
        pnlPermissionTeacher.PerformLayout();
        pnlAccountInfoCard.ResumeLayout(false);
        flpAccountActions.ResumeLayout(false);
        tblAccountInfo.ResumeLayout(false);
        tblAccountInfo.PerformLayout();
        flpAccountStatus.ResumeLayout(false);
        flpAccountStatus.PerformLayout();
        pnlAccountHeader.ResumeLayout(false);
        pnlAccountHeader.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)errAccount).EndInit();
        ResumeLayout(false);
    }
}

