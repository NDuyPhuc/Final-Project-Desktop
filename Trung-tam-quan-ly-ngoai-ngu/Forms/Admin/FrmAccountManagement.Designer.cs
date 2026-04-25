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
        tblAccountRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 430F));
        tblAccountRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tblAccountRoot.Controls.Add(pnlAccountListColumn, 0, 0);
        tblAccountRoot.Controls.Add(pnlAccountDetailColumn, 1, 0);
        tblAccountRoot.Dock = DockStyle.Fill;
        tblAccountRoot.Location = new Point(16, 16);
        tblAccountRoot.Name = "tblAccountRoot";
        tblAccountRoot.RowCount = 1;
        tblAccountRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblAccountRoot.Size = new Size(1088, 688);
        tblAccountRoot.TabIndex = 0;
        // 
        // pnlAccountListColumn
        // 
        pnlAccountListColumn.Controls.Add(flpAccountCards);
        pnlAccountListColumn.Controls.Add(pnlAccountFilterCard);
        pnlAccountListColumn.Controls.Add(lblAccountListTitle);
        pnlAccountListColumn.Dock = DockStyle.Fill;
        pnlAccountListColumn.Location = new Point(0, 0);
        pnlAccountListColumn.Margin = new Padding(0);
        pnlAccountListColumn.Name = "pnlAccountListColumn";
        pnlAccountListColumn.Padding = new Padding(0, 0, 20, 0);
        pnlAccountListColumn.Size = new Size(430, 688);
        pnlAccountListColumn.TabIndex = 0;
        // 
        // flpAccountCards
        // 
        flpAccountCards.AutoScroll = true;
        flpAccountCards.Dock = DockStyle.Fill;
        flpAccountCards.FlowDirection = FlowDirection.TopDown;
        flpAccountCards.Location = new Point(0, 92);
        flpAccountCards.Name = "flpAccountCards";
        flpAccountCards.Padding = new Padding(0, 4, 0, 0);
        flpAccountCards.Size = new Size(410, 596);
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
        pnlAccountFilterCard.Location = new Point(0, 36);
        pnlAccountFilterCard.Name = "pnlAccountFilterCard";
        pnlAccountFilterCard.Padding = new Padding(0, 10, 0, 10);
        pnlAccountFilterCard.Size = new Size(410, 56);
        pnlAccountFilterCard.TabIndex = 1;
        // 
        // btnRefreshAccount
        // 
        btnRefreshAccount.Location = new Point(350, 10);
        btnRefreshAccount.Name = "btnRefreshAccount";
        btnRefreshAccount.Size = new Size(55, 32);
        btnRefreshAccount.TabIndex = 3;
        btnRefreshAccount.Text = "↻";
        btnRefreshAccount.UseVisualStyleBackColor = true;
        // 
        // btnSearchAccount
        // 
        btnSearchAccount.Location = new Point(287, 10);
        btnSearchAccount.Name = "btnSearchAccount";
        btnSearchAccount.Size = new Size(55, 32);
        btnSearchAccount.TabIndex = 2;
        btnSearchAccount.Text = "⌕";
        btnSearchAccount.UseVisualStyleBackColor = true;
        // 
        // cboAccountRoleFilter
        // 
        cboAccountRoleFilter.DropDownStyle = ComboBoxStyle.DropDownList;
        cboAccountRoleFilter.FormattingEnabled = true;
        cboAccountRoleFilter.Items.AddRange(new object[] { "Tất cả", "Admin", "Staff", "Teacher" });
        cboAccountRoleFilter.Location = new Point(0, 12);
        cboAccountRoleFilter.Name = "cboAccountRoleFilter";
        cboAccountRoleFilter.Size = new Size(84, 28);
        cboAccountRoleFilter.TabIndex = 0;
        // 
        // txtAccountKeyword
        // 
        txtAccountKeyword.Location = new Point(90, 12);
        txtAccountKeyword.Name = "txtAccountKeyword";
        txtAccountKeyword.PlaceholderText = "Tìm kiếm tài khoản...";
        txtAccountKeyword.Size = new Size(191, 27);
        txtAccountKeyword.TabIndex = 1;
        // 
        // lblAccountListTitle
        // 
        lblAccountListTitle.Dock = DockStyle.Top;
        lblAccountListTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblAccountListTitle.Location = new Point(0, 0);
        lblAccountListTitle.Name = "lblAccountListTitle";
        lblAccountListTitle.Size = new Size(410, 36);
        lblAccountListTitle.TabIndex = 0;
        lblAccountListTitle.Text = "Danh sách Tài khoản";
        // 
        // pnlAccountDetailColumn
        // 
        pnlAccountDetailColumn.Controls.Add(pnlPermissionRuleCard);
        pnlAccountDetailColumn.Controls.Add(pnlAccountInfoCard);
        pnlAccountDetailColumn.Controls.Add(pnlAccountHeader);
        pnlAccountDetailColumn.Dock = DockStyle.Fill;
        pnlAccountDetailColumn.Location = new Point(430, 0);
        pnlAccountDetailColumn.Margin = new Padding(0);
        pnlAccountDetailColumn.Name = "pnlAccountDetailColumn";
        pnlAccountDetailColumn.Padding = new Padding(8, 0, 0, 0);
        pnlAccountDetailColumn.Size = new Size(658, 688);
        pnlAccountDetailColumn.TabIndex = 1;
        // 
        // pnlPermissionRuleCard
        // 
        pnlPermissionRuleCard.Controls.Add(lblPermissionFooter);
        pnlPermissionRuleCard.Controls.Add(tblPermissionCards);
        pnlPermissionRuleCard.Controls.Add(lblPermissionRuleTitle);
        pnlPermissionRuleCard.Dock = DockStyle.Top;
        pnlPermissionRuleCard.Location = new Point(8, 386);
        pnlPermissionRuleCard.Name = "pnlPermissionRuleCard";
        pnlPermissionRuleCard.Padding = new Padding(22, 18, 22, 18);
        pnlPermissionRuleCard.Size = new Size(650, 208);
        pnlPermissionRuleCard.TabIndex = 2;
        pnlPermissionRuleCard.Paint += pnlPermissionRuleCard_Paint;
        // 
        // lblPermissionFooter
        // 
        lblPermissionFooter.Dock = DockStyle.Bottom;
        lblPermissionFooter.ForeColor = Color.FromArgb(102, 112, 133);
        lblPermissionFooter.Location = new Point(22, 170);
        lblPermissionFooter.Name = "lblPermissionFooter";
        lblPermissionFooter.Size = new Size(606, 20);
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
        tblPermissionCards.Location = new Point(22, 49);
        tblPermissionCards.Name = "tblPermissionCards";
        tblPermissionCards.RowCount = 1;
        tblPermissionCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblPermissionCards.Size = new Size(606, 108);
        tblPermissionCards.TabIndex = 1;
        // 
        // pnlPermissionAdmin
        // 
        pnlPermissionAdmin.Controls.Add(lblPermissionAdminBody);
        pnlPermissionAdmin.Controls.Add(lblPermissionAdminTitle);
        pnlPermissionAdmin.Dock = DockStyle.Fill;
        pnlPermissionAdmin.Location = new Point(0, 0);
        pnlPermissionAdmin.Margin = new Padding(0, 0, 12, 0);
        pnlPermissionAdmin.Name = "pnlPermissionAdmin";
        pnlPermissionAdmin.Padding = new Padding(16, 14, 16, 14);
        pnlPermissionAdmin.Size = new Size(189, 108);
        pnlPermissionAdmin.TabIndex = 0;
        // 
        // lblPermissionAdminBody
        // 
        lblPermissionAdminBody.Dock = DockStyle.Fill;
        lblPermissionAdminBody.ForeColor = Color.FromArgb(42, 51, 64);
        lblPermissionAdminBody.Location = new Point(16, 39);
        lblPermissionAdminBody.Name = "lblPermissionAdminBody";
        lblPermissionAdminBody.Size = new Size(157, 55);
        lblPermissionAdminBody.TabIndex = 1;
        lblPermissionAdminBody.Text = "Quản trị toàn diện và giám sát các hoạt động hệ thống tối cao.";
        // 
        // lblPermissionAdminTitle
        // 
        lblPermissionAdminTitle.Dock = DockStyle.Top;
        lblPermissionAdminTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblPermissionAdminTitle.Location = new Point(16, 14);
        lblPermissionAdminTitle.Name = "lblPermissionAdminTitle";
        lblPermissionAdminTitle.Size = new Size(157, 25);
        lblPermissionAdminTitle.TabIndex = 0;
        lblPermissionAdminTitle.Text = "ADMIN";
        // 
        // pnlPermissionStaff
        // 
        pnlPermissionStaff.Controls.Add(lblPermissionStaffBody);
        pnlPermissionStaff.Controls.Add(lblPermissionStaffTitle);
        pnlPermissionStaff.Dock = DockStyle.Fill;
        pnlPermissionStaff.Location = new Point(201, 0);
        pnlPermissionStaff.Margin = new Padding(0, 0, 12, 0);
        pnlPermissionStaff.Name = "pnlPermissionStaff";
        pnlPermissionStaff.Padding = new Padding(16, 14, 16, 14);
        pnlPermissionStaff.Size = new Size(189, 108);
        pnlPermissionStaff.TabIndex = 1;
        // 
        // lblPermissionStaffBody
        // 
        lblPermissionStaffBody.Dock = DockStyle.Fill;
        lblPermissionStaffBody.ForeColor = Color.FromArgb(42, 51, 64);
        lblPermissionStaffBody.Location = new Point(16, 39);
        lblPermissionStaffBody.Name = "lblPermissionStaffBody";
        lblPermissionStaffBody.Size = new Size(157, 55);
        lblPermissionStaffBody.TabIndex = 1;
        lblPermissionStaffBody.Text = "Vận hành các quy trình tác nghiệp: Tuyển sinh, Thu phí, Xếp lớp.";
        // 
        // lblPermissionStaffTitle
        // 
        lblPermissionStaffTitle.Dock = DockStyle.Top;
        lblPermissionStaffTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblPermissionStaffTitle.Location = new Point(16, 14);
        lblPermissionStaffTitle.Name = "lblPermissionStaffTitle";
        lblPermissionStaffTitle.Size = new Size(157, 25);
        lblPermissionStaffTitle.TabIndex = 0;
        lblPermissionStaffTitle.Text = "NHÂN VIÊN (STAFF)";
        // 
        // pnlPermissionTeacher
        // 
        pnlPermissionTeacher.Controls.Add(lblPermissionTeacherBody);
        pnlPermissionTeacher.Controls.Add(lblPermissionTeacherTitle);
        pnlPermissionTeacher.Dock = DockStyle.Fill;
        pnlPermissionTeacher.Location = new Point(402, 0);
        pnlPermissionTeacher.Margin = new Padding(0);
        pnlPermissionTeacher.Name = "pnlPermissionTeacher";
        pnlPermissionTeacher.Padding = new Padding(16, 14, 16, 14);
        pnlPermissionTeacher.Size = new Size(204, 108);
        pnlPermissionTeacher.TabIndex = 2;
        // 
        // lblPermissionTeacherBody
        // 
        lblPermissionTeacherBody.Dock = DockStyle.Fill;
        lblPermissionTeacherBody.ForeColor = Color.FromArgb(42, 51, 64);
        lblPermissionTeacherBody.Location = new Point(16, 39);
        lblPermissionTeacherBody.Name = "lblPermissionTeacherBody";
        lblPermissionTeacherBody.Size = new Size(172, 55);
        lblPermissionTeacherBody.TabIndex = 1;
        lblPermissionTeacherBody.Text = "Truy cập học liệu, quản lý lớp học được giảng dạy và đánh giá học viên.";
        // 
        // lblPermissionTeacherTitle
        // 
        lblPermissionTeacherTitle.Dock = DockStyle.Top;
        lblPermissionTeacherTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblPermissionTeacherTitle.Location = new Point(16, 14);
        lblPermissionTeacherTitle.Name = "lblPermissionTeacherTitle";
        lblPermissionTeacherTitle.Size = new Size(172, 25);
        lblPermissionTeacherTitle.TabIndex = 0;
        lblPermissionTeacherTitle.Text = "GIÁO VIÊN (TEACHER)";
        // 
        // lblPermissionRuleTitle
        // 
        lblPermissionRuleTitle.Dock = DockStyle.Top;
        lblPermissionRuleTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblPermissionRuleTitle.Location = new Point(22, 18);
        lblPermissionRuleTitle.Name = "lblPermissionRuleTitle";
        lblPermissionRuleTitle.Size = new Size(606, 31);
        lblPermissionRuleTitle.TabIndex = 0;
        lblPermissionRuleTitle.Text = "QUY TẮC PHÂN QUYỀN HỆ THỐNG";
        // 
        // pnlAccountInfoCard
        // 
        pnlAccountInfoCard.Controls.Add(flpAccountActions);
        pnlAccountInfoCard.Controls.Add(tblAccountInfo);
        pnlAccountInfoCard.Dock = DockStyle.Top;
        pnlAccountInfoCard.Location = new Point(8, 94);
        pnlAccountInfoCard.Name = "pnlAccountInfoCard";
        pnlAccountInfoCard.Padding = new Padding(22, 18, 22, 18);
        pnlAccountInfoCard.Size = new Size(650, 292);
        pnlAccountInfoCard.TabIndex = 1;
        // 
        // flpAccountActions
        // 
        flpAccountActions.Controls.Add(btnSaveAccount);
        flpAccountActions.Controls.Add(btnResetPassword);
        flpAccountActions.Controls.Add(btnToggleAccountStatus);
        flpAccountActions.Dock = DockStyle.Top;
        flpAccountActions.Location = new Point(22, 210);
        flpAccountActions.Name = "flpAccountActions";
        flpAccountActions.Size = new Size(606, 46);
        flpAccountActions.TabIndex = 1;
        flpAccountActions.WrapContents = false;
        // 
        // btnSaveAccount
        // 
        btnSaveAccount.Location = new Point(3, 3);
        btnSaveAccount.Name = "btnSaveAccount";
        btnSaveAccount.Size = new Size(150, 38);
        btnSaveAccount.TabIndex = 0;
        btnSaveAccount.Text = "LƯU THAY ĐỔI";
        btnSaveAccount.UseVisualStyleBackColor = true;
        // 
        // btnResetPassword
        // 
        btnResetPassword.Location = new Point(159, 3);
        btnResetPassword.Name = "btnResetPassword";
        btnResetPassword.Size = new Size(170, 38);
        btnResetPassword.TabIndex = 1;
        btnResetPassword.Text = "ĐẶT LẠI MẬT KHẨU";
        btnResetPassword.UseVisualStyleBackColor = true;
        // 
        // btnToggleAccountStatus
        // 
        btnToggleAccountStatus.Location = new Point(335, 3);
        btnToggleAccountStatus.Name = "btnToggleAccountStatus";
        btnToggleAccountStatus.Size = new Size(170, 38);
        btnToggleAccountStatus.TabIndex = 2;
        btnToggleAccountStatus.Text = "KHÓA TÀI KHOẢN";
        btnToggleAccountStatus.UseVisualStyleBackColor = true;
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
        tblAccountInfo.Location = new Point(22, 18);
        tblAccountInfo.Name = "tblAccountInfo";
        tblAccountInfo.RowCount = 6;
        tblAccountInfo.RowStyles.Add(new RowStyle());
        tblAccountInfo.RowStyles.Add(new RowStyle());
        tblAccountInfo.RowStyles.Add(new RowStyle());
        tblAccountInfo.RowStyles.Add(new RowStyle());
        tblAccountInfo.RowStyles.Add(new RowStyle());
        tblAccountInfo.RowStyles.Add(new RowStyle());
        tblAccountInfo.Size = new Size(606, 192);
        tblAccountInfo.TabIndex = 0;
        // 
        // lblDisplayName
        // 
        lblDisplayName.AutoSize = true;
        lblDisplayName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblDisplayName.Location = new Point(3, 0);
        lblDisplayName.Name = "lblDisplayName";
        lblDisplayName.Size = new Size(88, 20);
        lblDisplayName.TabIndex = 0;
        lblDisplayName.Text = "HỌ VÀ TÊN";
        // 
        // txtDisplayName
        // 
        txtDisplayName.Dock = DockStyle.Fill;
        txtDisplayName.Location = new Point(3, 23);
        txtDisplayName.Name = "txtDisplayName";
        txtDisplayName.Size = new Size(297, 27);
        txtDisplayName.TabIndex = 1;
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblUsername.Location = new Point(306, 0);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(134, 20);
        lblUsername.TabIndex = 2;
        lblUsername.Text = "TÊN ĐĂNG NHẬP";
        // 
        // txtUsername
        // 
        txtUsername.Dock = DockStyle.Fill;
        txtUsername.Location = new Point(306, 23);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(297, 27);
        txtUsername.TabIndex = 3;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblEmail.Location = new Point(3, 53);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(55, 20);
        lblEmail.TabIndex = 4;
        lblEmail.Text = "EMAIL";
        // 
        // txtEmail
        // 
        txtEmail.Dock = DockStyle.Fill;
        txtEmail.Location = new Point(3, 76);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(297, 27);
        txtEmail.TabIndex = 5;
        // 
        // lblPhone
        // 
        lblPhone.AutoSize = true;
        lblPhone.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblPhone.Location = new Point(306, 53);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new Size(119, 20);
        lblPhone.TabIndex = 6;
        lblPhone.Text = "SỐ ĐIỆN THOẠI";
        // 
        // txtPhone
        // 
        txtPhone.Dock = DockStyle.Fill;
        txtPhone.Location = new Point(306, 76);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new Size(297, 27);
        txtPhone.TabIndex = 7;
        // 
        // lblRole
        // 
        lblRole.AutoSize = true;
        lblRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblRole.Location = new Point(3, 106);
        lblRole.Name = "lblRole";
        lblRole.Size = new Size(68, 20);
        lblRole.TabIndex = 8;
        lblRole.Text = "VAI TRÒ";
        // 
        // cboAccountRole
        // 
        cboAccountRole.Dock = DockStyle.Left;
        cboAccountRole.DropDownStyle = ComboBoxStyle.DropDownList;
        cboAccountRole.FormattingEnabled = true;
        cboAccountRole.Items.AddRange(new object[] { "Admin", "Staff", "Teacher" });
        cboAccountRole.Location = new Point(3, 129);
        cboAccountRole.Name = "cboAccountRole";
        cboAccountRole.Size = new Size(205, 28);
        cboAccountRole.TabIndex = 9;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblStatus.Location = new Point(306, 106);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(102, 20);
        lblStatus.TabIndex = 10;
        lblStatus.Text = "TRẠNG THÁI";
        // 
        // flpAccountStatus
        // 
        flpAccountStatus.Controls.Add(rdoAccountActive);
        flpAccountStatus.Controls.Add(rdoAccountLocked);
        flpAccountStatus.Dock = DockStyle.Fill;
        flpAccountStatus.Location = new Point(306, 129);
        flpAccountStatus.Name = "flpAccountStatus";
        flpAccountStatus.Size = new Size(297, 60);
        flpAccountStatus.TabIndex = 11;
        flpAccountStatus.WrapContents = false;
        // 
        // rdoAccountActive
        // 
        rdoAccountActive.AutoSize = true;
        rdoAccountActive.Location = new Point(3, 3);
        rdoAccountActive.Name = "rdoAccountActive";
        rdoAccountActive.Size = new Size(102, 24);
        rdoAccountActive.TabIndex = 0;
        rdoAccountActive.TabStop = true;
        rdoAccountActive.Text = "Hoạt động";
        rdoAccountActive.UseVisualStyleBackColor = true;
        // 
        // rdoAccountLocked
        // 
        rdoAccountLocked.AutoSize = true;
        rdoAccountLocked.Location = new Point(111, 3);
        rdoAccountLocked.Name = "rdoAccountLocked";
        rdoAccountLocked.Size = new Size(64, 24);
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
        pnlAccountHeader.Location = new Point(8, 0);
        pnlAccountHeader.Name = "pnlAccountHeader";
        pnlAccountHeader.Size = new Size(650, 94);
        pnlAccountHeader.TabIndex = 0;
        // 
        // btnCreateAccount
        // 
        btnCreateAccount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCreateAccount.Location = new Point(411, 22);
        btnCreateAccount.Name = "btnCreateAccount";
        btnCreateAccount.Size = new Size(217, 44);
        btnCreateAccount.TabIndex = 2;
        btnCreateAccount.Text = "+ Tạo tài khoản mới";
        btnCreateAccount.UseVisualStyleBackColor = true;
        // 
        // lblAccountIdentifier
        // 
        lblAccountIdentifier.AutoSize = true;
        lblAccountIdentifier.ForeColor = Color.FromArgb(102, 112, 133);
        lblAccountIdentifier.Location = new Point(0, 56);
        lblAccountIdentifier.Name = "lblAccountIdentifier";
        lblAccountIdentifier.Size = new Size(140, 20);
        lblAccountIdentifier.TabIndex = 1;
        lblAccountIdentifier.Text = "ID: USER-8842-ANV";
        // 
        // lblAccountTitle
        // 
        lblAccountTitle.AutoSize = true;
        lblAccountTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblAccountTitle.Location = new Point(0, 14);
        lblAccountTitle.Name = "lblAccountTitle";
        lblAccountTitle.Size = new Size(313, 41);
        lblAccountTitle.TabIndex = 0;
        lblAccountTitle.Text = "CHI TIẾT TÀI KHOẢN";
        // 
        // errAccount
        // 
        errAccount.ContainerControl = this;
        // 
        // FrmAccountManagement
        // 
        AutoScaleMode = AutoScaleMode.None;
        BackColor = Color.FromArgb(241, 248, 255);
        ClientSize = new Size(1120, 720);
        Controls.Add(tblAccountRoot);
        Name = "FrmAccountManagement";
        Padding = new Padding(16);
        Text = "Tài khoản và phân quyền";
        tblAccountRoot.ResumeLayout(false);
        pnlAccountListColumn.ResumeLayout(false);
        pnlAccountFilterCard.ResumeLayout(false);
        pnlAccountFilterCard.PerformLayout();
        pnlAccountDetailColumn.ResumeLayout(false);
        pnlPermissionRuleCard.ResumeLayout(false);
        tblPermissionCards.ResumeLayout(false);
        pnlPermissionAdmin.ResumeLayout(false);
        pnlPermissionStaff.ResumeLayout(false);
        pnlPermissionTeacher.ResumeLayout(false);
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
