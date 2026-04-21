namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmAccountManagement
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlAccountFilterCard; private TextBox txtAccountKeyword; private ComboBox cboAccountRoleFilter; private Button btnSearchAccount; private Button btnRefreshAccount;
    private DataGridView dgvAccountList; private GroupBox grpAccountInfo; private GroupBox grpPermissionRule; private ErrorProvider errAccount;
    private TextBox txtUsername; private TextBox txtPassword; private TextBox txtDisplayName; private ComboBox cboAccountRole; private ComboBox cboAccountStatus;
    private Button btnCreateAccount; private Button btnSaveAccount; private Button btnToggleAccountStatus; private Button btnResetPassword;
    protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        pnlAccountFilterCard = new Panel(); txtAccountKeyword = new TextBox(); cboAccountRoleFilter = new ComboBox(); btnSearchAccount = new Button(); btnRefreshAccount = new Button();
        dgvAccountList = new DataGridView(); grpAccountInfo = new GroupBox(); grpPermissionRule = new GroupBox(); errAccount = new ErrorProvider(components);
        txtUsername = new TextBox(); txtPassword = new TextBox(); txtDisplayName = new TextBox(); cboAccountRole = new ComboBox(); cboAccountStatus = new ComboBox();
        btnCreateAccount = new Button(); btnSaveAccount = new Button(); btnToggleAccountStatus = new Button(); btnResetPassword = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvAccountList).BeginInit(); ((System.ComponentModel.ISupportInitialize)errAccount).BeginInit(); SuspendLayout();
        pnlAccountFilterCard.BorderStyle = BorderStyle.FixedSingle; pnlAccountFilterCard.Location = new Point(8,8); pnlAccountFilterCard.Size = new Size(1120,80);
        txtAccountKeyword.Location = new Point(16,24); txtAccountKeyword.Size = new Size(260,23); txtAccountKeyword.Name = "txtAccountKeyword";
        cboAccountRoleFilter.Items.AddRange(new object[]{"T?t c?","Admin","Staff","Teacher"}); cboAccountRoleFilter.Location = new Point(292,24); cboAccountRoleFilter.Size = new Size(160,23); cboAccountRoleFilter.Name = "cboAccountRoleFilter";
        btnSearchAccount.Location = new Point(468,22); btnSearchAccount.Size = new Size(100,28); btnSearchAccount.Text = "T́m"; btnSearchAccount.Name = "btnSearchAccount";
        btnRefreshAccount.Location = new Point(580,22); btnRefreshAccount.Size = new Size(100,28); btnRefreshAccount.Text = "Làm m?i"; btnRefreshAccount.Name = "btnRefreshAccount";
        pnlAccountFilterCard.Controls.AddRange(new Control[]{txtAccountKeyword,cboAccountRoleFilter,btnSearchAccount,btnRefreshAccount});
        dgvAccountList.Location = new Point(8,104); dgvAccountList.Size = new Size(560,540); dgvAccountList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; dgvAccountList.RowHeadersVisible = false; dgvAccountList.Name = "dgvAccountList";
        grpAccountInfo.Location = new Point(584,104); grpAccountInfo.Size = new Size(544,280); grpAccountInfo.Text = "Thông tin tài kho?n"; grpAccountInfo.Name = "grpAccountInfo";
        txtUsername.Location = new Point(24,40); txtUsername.Size = new Size(220,23); txtUsername.Name = "txtUsername";
        txtPassword.Location = new Point(280,40); txtPassword.Size = new Size(220,23); txtPassword.Name = "txtPassword";
        txtDisplayName.Location = new Point(24,88); txtDisplayName.Size = new Size(220,23); txtDisplayName.Name = "txtDisplayName";
        cboAccountRole.Location = new Point(280,88); cboAccountRole.Size = new Size(220,23); cboAccountRole.Items.AddRange(new object[]{"Admin","Staff","Teacher"}); cboAccountRole.Name = "cboAccountRole";
        cboAccountStatus.Location = new Point(24,136); cboAccountStatus.Size = new Size(220,23); cboAccountStatus.Items.AddRange(new object[]{"Active","Inactive"}); cboAccountStatus.Name = "cboAccountStatus";
        grpAccountInfo.Controls.AddRange(new Control[]{txtUsername,txtPassword,txtDisplayName,cboAccountRole,cboAccountStatus});
        grpPermissionRule.Location = new Point(584,400); grpPermissionRule.Size = new Size(544,168); grpPermissionRule.Text = "Quy t?c phân quy?n"; grpPermissionRule.Name = "grpPermissionRule";
        btnCreateAccount.Location = new Point(584,592); btnCreateAccount.Size = new Size(110,32); btnCreateAccount.Text = "T?o m?i"; btnCreateAccount.Name = "btnCreateAccount";
        btnSaveAccount.Location = new Point(706,592); btnSaveAccount.Size = new Size(110,32); btnSaveAccount.Text = "Luu"; btnSaveAccount.Name = "btnSaveAccount";
        btnToggleAccountStatus.Location = new Point(828,592); btnToggleAccountStatus.Size = new Size(110,32); btnToggleAccountStatus.Text = "Khóa / M?"; btnToggleAccountStatus.Name = "btnToggleAccountStatus";
        btnResetPassword.Location = new Point(950,592); btnResetPassword.Size = new Size(110,32); btnResetPassword.Text = "Reset MK"; btnResetPassword.Name = "btnResetPassword";
        Controls.AddRange(new Control[]{pnlAccountFilterCard,dgvAccountList,grpAccountInfo,grpPermissionRule,btnCreateAccount,btnSaveAccount,btnToggleAccountStatus,btnResetPassword});
        Name = "FrmAccountManagement"; ClientSize = new Size(1140,650); ((System.ComponentModel.ISupportInitialize)dgvAccountList).EndInit(); ((System.ComponentModel.ISupportInitialize)errAccount).EndInit(); ResumeLayout(false);
    }
}
