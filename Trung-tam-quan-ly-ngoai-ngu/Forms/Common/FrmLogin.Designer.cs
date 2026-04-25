namespace Trung_tam_quan_ly_ngoai_ngu;

partial class FrmLogin
{
    private System.ComponentModel.IContainer components = null;

    private Panel pnlLoginContainer;
    private Panel pnlLoginHeader;
    private Panel pnlLoginHeaderOverlay;
    private PictureBox picHeaderLogo;
    private Label lblHeaderTitle;
    private Label lblHeaderSubtitle;
    private Panel pnlLoginFormContent;
    private Panel pnlErrorAlert;
    private Panel pnlErrorAccent;
    private Panel pnlErrorIcon;
    private Label lblErrorAlertText;
    private Label lblUsername;
    private Panel pnlUsernameInput;
    private Panel pnlUsernameIcon;
    private TextBox txtUsername;
    private Label lblPassword;
    private Panel pnlPasswordInput;
    private Panel pnlPasswordIcon;
    private TextBox txtPassword;
    private Panel pnlSubControls;
    private TableLayoutPanel tblSubControls;
    private CheckBox chkShowPassword;
    private LinkLabel lnkForgotPassword;
    private Panel pnlActionButtons;
    private Button btnExit;
    private Button btnLogin;
    private Panel pnlLoginFooter;
    private TableLayoutPanel tblFooter;
    private Label lblFooterVersion;
    private Label lblFooterSupport;
    private ErrorProvider errLogin;
    private ToolTip ttLogin;

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
        pnlLoginContainer = new Panel();
        pnlLoginFooter = new Panel();
        tblFooter = new TableLayoutPanel();
        lblFooterVersion = new Label();
        lblFooterSupport = new Label();
        pnlLoginFormContent = new Panel();
        pnlActionButtons = new Panel();
        btnExit = new Button();
        btnLogin = new Button();
        pnlSubControls = new Panel();
        tblSubControls = new TableLayoutPanel();
        chkShowPassword = new CheckBox();
        lnkForgotPassword = new LinkLabel();
        pnlPasswordInput = new Panel();
        txtPassword = new TextBox();
        pnlPasswordIcon = new Panel();
        lblPassword = new Label();
        pnlUsernameInput = new Panel();
        txtUsername = new TextBox();
        pnlUsernameIcon = new Panel();
        lblUsername = new Label();
        pnlErrorAlert = new Panel();
        lblErrorAlertText = new Label();
        pnlErrorIcon = new Panel();
        pnlErrorAccent = new Panel();
        pnlLoginHeader = new Panel();
        pnlLoginHeaderOverlay = new Panel();
        lblHeaderSubtitle = new Label();
        lblHeaderTitle = new Label();
        picHeaderLogo = new PictureBox();
        errLogin = new ErrorProvider(components);
        ttLogin = new ToolTip(components);
        pnlLoginContainer.SuspendLayout();
        pnlLoginFooter.SuspendLayout();
        tblFooter.SuspendLayout();
        pnlLoginFormContent.SuspendLayout();
        pnlActionButtons.SuspendLayout();
        pnlSubControls.SuspendLayout();
        tblSubControls.SuspendLayout();
        pnlPasswordInput.SuspendLayout();
        pnlUsernameInput.SuspendLayout();
        pnlErrorAlert.SuspendLayout();
        pnlLoginHeader.SuspendLayout();
        pnlLoginHeaderOverlay.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picHeaderLogo).BeginInit();
        ((System.ComponentModel.ISupportInitialize)errLogin).BeginInit();
        SuspendLayout();
        // 
        // pnlLoginContainer
        // 
        pnlLoginContainer.BackColor = Color.White;
        pnlLoginContainer.Controls.Add(pnlLoginFooter);
        pnlLoginContainer.Controls.Add(pnlLoginFormContent);
        pnlLoginContainer.Controls.Add(pnlLoginHeader);
        pnlLoginContainer.MinimumSize = new Size(448, 678);
        pnlLoginContainer.Location = new Point(266, 21);
        pnlLoginContainer.Name = "pnlLoginContainer";
        pnlLoginContainer.Size = new Size(448, 678);
        pnlLoginContainer.AutoScroll = false;
        pnlLoginContainer.TabIndex = 0;
        // 
        // pnlLoginFooter
        // 
        pnlLoginFooter.BackColor = Color.FromArgb(243, 243, 243);
        pnlLoginFooter.Controls.Add(tblFooter);
        pnlLoginFooter.Dock = DockStyle.Bottom;
        pnlLoginFooter.Name = "pnlLoginFooter";
        pnlLoginFooter.Size = new Size(448, 56);
        pnlLoginFooter.AutoScroll = false;
        pnlLoginFooter.TabIndex = 2;
        // 
        // tblFooter
        // 
        tblFooter.ColumnCount = 2;
        tblFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tblFooter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tblFooter.Controls.Add(lblFooterVersion, 0, 0);
        tblFooter.Controls.Add(lblFooterSupport, 1, 0);
        tblFooter.Dock = DockStyle.Fill;
        tblFooter.Location = new Point(0, 0);
        tblFooter.Margin = new Padding(0);
        tblFooter.Name = "tblFooter";
        tblFooter.Padding = new Padding(32, 12, 32, 12);
        tblFooter.RowCount = 1;
        tblFooter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblFooter.Size = new Size(448, 56);
        tblFooter.AutoScroll = false;
        tblFooter.TabIndex = 0;
        // 
        // lblFooterVersion
        // 
        lblFooterVersion.Dock = DockStyle.Fill;
        lblFooterVersion.ForeColor = Color.FromArgb(110, 114, 121);
        lblFooterVersion.Location = new Point(32, 12);
        lblFooterVersion.Margin = new Padding(0);
        lblFooterVersion.Name = "lblFooterVersion";
        lblFooterVersion.Size = new Size(192, 32);
        lblFooterVersion.AutoSize = true;
        lblFooterVersion.TabIndex = 0;
        lblFooterVersion.Text = "Academic Curator v2.4";
        lblFooterVersion.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblFooterSupport
        // 
        lblFooterSupport.Dock = DockStyle.Fill;
        lblFooterSupport.ForeColor = Color.FromArgb(110, 114, 121);
        lblFooterSupport.Location = new Point(224, 12);
        lblFooterSupport.Margin = new Padding(0);
        lblFooterSupport.Name = "lblFooterSupport";
        lblFooterSupport.Size = new Size(192, 32);
        lblFooterSupport.AutoSize = true;
        lblFooterSupport.TabIndex = 1;
        lblFooterSupport.Text = "Hỗ trợ kỹ thuật";
        lblFooterSupport.TextAlign = ContentAlignment.MiddleRight;
        // 
        // pnlLoginFormContent
        // 
        pnlLoginFormContent.BackColor = Color.FromArgb(243, 243, 243);
        pnlLoginFormContent.Controls.Add(pnlActionButtons);
        pnlLoginFormContent.Controls.Add(pnlSubControls);
        pnlLoginFormContent.Controls.Add(pnlPasswordInput);
        pnlLoginFormContent.Controls.Add(lblPassword);
        pnlLoginFormContent.Controls.Add(pnlUsernameInput);
        pnlLoginFormContent.Controls.Add(lblUsername);
        pnlLoginFormContent.Controls.Add(pnlErrorAlert);
        pnlLoginFormContent.Dock = DockStyle.Fill;
        pnlLoginFormContent.Name = "pnlLoginFormContent";
        pnlLoginFormContent.Size = new Size(448, 430);
        pnlLoginFormContent.AutoScroll = true;
        pnlLoginFormContent.TabIndex = 1;
        // 
        // pnlActionButtons
        // 
        pnlActionButtons.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        pnlActionButtons.BackColor = Color.Transparent;
        pnlActionButtons.Controls.Add(btnExit);
        pnlActionButtons.Controls.Add(btnLogin);
        pnlActionButtons.Location = new Point(32, 318);
        pnlActionButtons.Name = "pnlActionButtons";
        pnlActionButtons.Size = new Size(384, 44);
        pnlActionButtons.AutoScroll = false;
        pnlActionButtons.TabIndex = 6;
        // 
        // btnExit
        // 
        btnExit.BackColor = Color.FromArgb(232, 232, 232);
        btnExit.FlatAppearance.BorderSize = 0;
        btnExit.FlatStyle = FlatStyle.Flat;
        btnExit.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        btnExit.ForeColor = Color.FromArgb(26, 28, 28);
        btnExit.Location = new Point(0, 0);
        btnExit.Name = "btnExit";
        btnExit.Size = new Size(184, 44);
        btnExit.TabIndex = 0;
        btnExit.Text = "Thoát";
        btnExit.UseVisualStyleBackColor = false;
        // 
        // btnLogin
        // 
        btnLogin.BackColor = Color.FromArgb(0, 30, 64);
        btnLogin.FlatAppearance.BorderSize = 0;
        btnLogin.FlatStyle = FlatStyle.Flat;
        btnLogin.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        btnLogin.ForeColor = Color.White;
        btnLogin.Location = new Point(200, 0);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(184, 44);
        btnLogin.TabIndex = 1;
        btnLogin.Text = "Đăng nhập";
        btnLogin.UseVisualStyleBackColor = false;
        // 
        // pnlSubControls
        // 
        pnlSubControls.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        pnlSubControls.BackColor = Color.Transparent;
        pnlSubControls.Controls.Add(tblSubControls);
        pnlSubControls.Location = new Point(32, 258);
        pnlSubControls.Name = "pnlSubControls";
        pnlSubControls.Size = new Size(384, 28);
        pnlSubControls.AutoScroll = false;
        pnlSubControls.TabIndex = 5;
        // 
        // tblSubControls
        // 
        tblSubControls.ColumnCount = 2;
        tblSubControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
        tblSubControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
        tblSubControls.Controls.Add(chkShowPassword, 0, 0);
        tblSubControls.Controls.Add(lnkForgotPassword, 1, 0);
        tblSubControls.Dock = DockStyle.Fill;
        tblSubControls.Location = new Point(0, 0);
        tblSubControls.Margin = new Padding(0);
        tblSubControls.Name = "tblSubControls";
        tblSubControls.RowCount = 1;
        tblSubControls.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblSubControls.Size = new Size(384, 28);
        tblSubControls.AutoScroll = false;
        tblSubControls.TabIndex = 0;
        // 
        // chkShowPassword
        // 
        chkShowPassword.Anchor = AnchorStyles.Left;
        chkShowPassword.AutoSize = true;
        chkShowPassword.BackColor = Color.Transparent;
        chkShowPassword.Font = new Font("Segoe UI", 11F);
        chkShowPassword.ForeColor = Color.FromArgb(67, 71, 79);
        chkShowPassword.Location = new Point(0, 0);
        chkShowPassword.Margin = new Padding(0);
        chkShowPassword.Name = "chkShowPassword";
        chkShowPassword.Size = new Size(156, 28);
        chkShowPassword.TabIndex = 0;
        chkShowPassword.Text = "Hiện mật khẩu";
        chkShowPassword.UseVisualStyleBackColor = false;
        // 
        // lnkForgotPassword
        // 
        lnkForgotPassword.Anchor = AnchorStyles.Right;
        lnkForgotPassword.AutoSize = true;
        lnkForgotPassword.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lnkForgotPassword.LinkColor = Color.FromArgb(0, 106, 106);
        lnkForgotPassword.Location = new Point(228, 1);
        lnkForgotPassword.Margin = new Padding(0);
        lnkForgotPassword.Name = "lnkForgotPassword";
        lnkForgotPassword.Size = new Size(156, 25);
        lnkForgotPassword.AutoSize = true;
        lnkForgotPassword.TabIndex = 1;
        lnkForgotPassword.TabStop = true;
        lnkForgotPassword.Text = "Quên mật khẩu?";
        lnkForgotPassword.TextAlign = ContentAlignment.MiddleRight;
        lnkForgotPassword.VisitedLinkColor = Color.FromArgb(0, 106, 106);
        // 
        // pnlPasswordInput
        // 
        pnlPasswordInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        pnlPasswordInput.BackColor = Color.FromArgb(226, 226, 226);
        pnlPasswordInput.Controls.Add(txtPassword);
        pnlPasswordInput.Controls.Add(pnlPasswordIcon);
        pnlPasswordInput.Location = new Point(32, 208);
        pnlPasswordInput.Name = "pnlPasswordInput";
        pnlPasswordInput.Size = new Size(384, 40);
        pnlPasswordInput.AutoScroll = false;
        pnlPasswordInput.TabIndex = 4;
        // 
        // txtPassword
        // 
        txtPassword.BackColor = Color.FromArgb(226, 226, 226);
        txtPassword.BorderStyle = BorderStyle.None;
        txtPassword.Font = new Font("Segoe UI", 12F);
        txtPassword.ForeColor = Color.FromArgb(26, 28, 28);
        txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtPassword.Location = new Point(40, 4);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(332, 27);
        txtPassword.TabIndex = 1;
        txtPassword.Text = "••••••••";
        txtPassword.UseSystemPasswordChar = true;
        // 
        // pnlPasswordIcon
        // 
        pnlPasswordIcon.BackColor = Color.Transparent;
        pnlPasswordIcon.Location = new Point(12, 12);
        pnlPasswordIcon.Name = "pnlPasswordIcon";
        pnlPasswordIcon.Size = new Size(16, 16);
        pnlPasswordIcon.AutoScroll = true;
        pnlPasswordIcon.TabIndex = 0;
        // 
        // lblPassword
        // 
        lblPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblPassword.ForeColor = Color.FromArgb(26, 28, 28);
        lblPassword.Location = new Point(32, 180);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(384, 25);
        lblPassword.AutoSize = true;
        lblPassword.TabIndex = 3;
        lblPassword.Text = "MẬT KHẨU";
        lblPassword.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlUsernameInput
        // 
        pnlUsernameInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        pnlUsernameInput.BackColor = Color.FromArgb(226, 226, 226);
        pnlUsernameInput.Controls.Add(txtUsername);
        pnlUsernameInput.Controls.Add(pnlUsernameIcon);
        pnlUsernameInput.Location = new Point(32, 124);
        pnlUsernameInput.Name = "pnlUsernameInput";
        pnlUsernameInput.Size = new Size(384, 40);
        pnlUsernameInput.AutoScroll = false;
        pnlUsernameInput.TabIndex = 2;
        // 
        // txtUsername
        // 
        txtUsername.BackColor = Color.FromArgb(226, 226, 226);
        txtUsername.BorderStyle = BorderStyle.None;
        txtUsername.Font = new Font("Segoe UI", 12F);
        txtUsername.ForeColor = Color.FromArgb(26, 28, 28);
        txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtUsername.Location = new Point(40, 4);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(332, 27);
        txtUsername.TabIndex = 1;
        txtUsername.Text = "admin";
        // 
        // pnlUsernameIcon
        // 
        pnlUsernameIcon.BackColor = Color.Transparent;
        pnlUsernameIcon.Location = new Point(12, 12);
        pnlUsernameIcon.Name = "pnlUsernameIcon";
        pnlUsernameIcon.Size = new Size(16, 16);
        pnlUsernameIcon.AutoScroll = true;
        pnlUsernameIcon.TabIndex = 0;
        // 
        // lblUsername
        // 
        lblUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblUsername.ForeColor = Color.FromArgb(26, 28, 28);
        lblUsername.Location = new Point(32, 96);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(384, 25);
        lblUsername.AutoSize = true;
        lblUsername.TabIndex = 1;
        lblUsername.Text = "TÊN ĐĂNG NHẬP";
        lblUsername.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlErrorAlert
        // 
        pnlErrorAlert.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        pnlErrorAlert.BackColor = Color.FromArgb(255, 218, 214);
        pnlErrorAlert.Controls.Add(lblErrorAlertText);
        pnlErrorAlert.Controls.Add(pnlErrorIcon);
        pnlErrorAlert.Controls.Add(pnlErrorAccent);
        pnlErrorAlert.Location = new Point(32, 24);
        pnlErrorAlert.Name = "pnlErrorAlert";
        pnlErrorAlert.Size = new Size(384, 54);
        pnlErrorAlert.AutoScroll = false;
        pnlErrorAlert.TabIndex = 0;
        pnlErrorAlert.Visible = false;
        // 
        // lblErrorAlertText
        // 
        lblErrorAlertText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblErrorAlertText.ForeColor = Color.FromArgb(147, 0, 10);
        lblErrorAlertText.Location = new Point(48, 17);
        lblErrorAlertText.Name = "lblErrorAlertText";
        lblErrorAlertText.Size = new Size(300, 20);
        lblErrorAlertText.AutoSize = true;
        lblErrorAlertText.TabIndex = 2;
        lblErrorAlertText.Text = "Sai tên tài khoản hoặc mật khẩu";
        lblErrorAlertText.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlErrorIcon
        // 
        pnlErrorIcon.BackColor = Color.Transparent;
        pnlErrorIcon.Location = new Point(16, 17);
        pnlErrorIcon.Name = "pnlErrorIcon";
        pnlErrorIcon.Size = new Size(20, 20);
        pnlErrorIcon.AutoScroll = false;
        pnlErrorIcon.TabIndex = 1;
        // 
        // pnlErrorAccent
        // 
        pnlErrorAccent.BackColor = Color.FromArgb(186, 26, 26);
        pnlErrorAccent.Location = new Point(0, 0);
        pnlErrorAccent.Name = "pnlErrorAccent";
        pnlErrorAccent.Size = new Size(4, 54);
        pnlErrorAccent.AutoScroll = false;
        pnlErrorAccent.TabIndex = 0;
        // 
        // pnlLoginHeader
        // 
        pnlLoginHeader.BackColor = Color.FromArgb(0, 51, 102);
        pnlLoginHeader.Controls.Add(pnlLoginHeaderOverlay);
        pnlLoginHeader.Dock = DockStyle.Top;
        pnlLoginHeader.Name = "pnlLoginHeader";
        pnlLoginHeader.Size = new Size(448, 200);
        pnlLoginHeader.AutoScroll = false;
        pnlLoginHeader.TabIndex = 0;
        // 
        // pnlLoginHeaderOverlay
        // 
        pnlLoginHeaderOverlay.BackColor = Color.Transparent;
        pnlLoginHeaderOverlay.Controls.Add(lblHeaderSubtitle);
        pnlLoginHeaderOverlay.Controls.Add(lblHeaderTitle);
        pnlLoginHeaderOverlay.Controls.Add(picHeaderLogo);
        pnlLoginHeaderOverlay.Dock = DockStyle.Fill;
        pnlLoginHeaderOverlay.Name = "pnlLoginHeaderOverlay";
        pnlLoginHeaderOverlay.Size = new Size(448, 200);
        pnlLoginHeaderOverlay.AutoScroll = false;
        pnlLoginHeaderOverlay.TabIndex = 0;
        // 
        // lblHeaderSubtitle
        // 
        lblHeaderSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblHeaderSubtitle.ForeColor = Color.FromArgb(204, 255, 255, 255);
        lblHeaderSubtitle.Location = new Point(44, 155);
        lblHeaderSubtitle.Name = "lblHeaderSubtitle";
        lblHeaderSubtitle.Size = new Size(360, 24);
        lblHeaderSubtitle.AutoSize = true;
        lblHeaderSubtitle.TabIndex = 2;
        lblHeaderSubtitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
        lblHeaderSubtitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblHeaderTitle
        // 
        lblHeaderTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        lblHeaderTitle.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
        lblHeaderTitle.ForeColor = Color.White;
        lblHeaderTitle.Location = new Point(44, 95);
        lblHeaderTitle.Name = "lblHeaderTitle";
        lblHeaderTitle.Size = new Size(360, 54);
        lblHeaderTitle.AutoSize = true;
        lblHeaderTitle.TabIndex = 1;
        lblHeaderTitle.Text = "Academic Curator";
        lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // picHeaderLogo
        // 
        picHeaderLogo.BackColor = Color.FromArgb(0, 30, 64);
        picHeaderLogo.BorderStyle = BorderStyle.FixedSingle;
        picHeaderLogo.Location = new Point(192, 27);
        picHeaderLogo.Name = "picHeaderLogo";
        picHeaderLogo.Size = new Size(64, 64);
        picHeaderLogo.SizeMode = PictureBoxSizeMode.Zoom;
        picHeaderLogo.TabIndex = 0;
        picHeaderLogo.TabStop = false;
        // 
        // errLogin
        // 
        errLogin.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errLogin.ContainerControl = this;
        // 
        // FrmLogin
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(233, 237, 244);
        ClientSize = new Size(980, 720);
        Font = new Font("Segoe UI", 10F);
        Controls.Add(pnlLoginContainer);
        MinimumSize = new Size(760, 620);
        Name = "FrmLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Đăng nhập hệ thống";
        pnlLoginContainer.ResumeLayout(false);
        pnlLoginFooter.ResumeLayout(false);
        tblFooter.ResumeLayout(false);
        pnlLoginFormContent.ResumeLayout(false);
        pnlActionButtons.ResumeLayout(false);
        pnlSubControls.ResumeLayout(false);
        tblSubControls.ResumeLayout(false);
        tblSubControls.PerformLayout();
        pnlPasswordInput.ResumeLayout(false);
        pnlPasswordInput.PerformLayout();
        pnlUsernameInput.ResumeLayout(false);
        pnlUsernameInput.PerformLayout();
        pnlErrorAlert.ResumeLayout(false);
        pnlLoginHeader.ResumeLayout(false);
        pnlLoginHeaderOverlay.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)picHeaderLogo).EndInit();
        ((System.ComponentModel.ISupportInitialize)errLogin).EndInit();
        AutoScroll = true;
        ResumeLayout(false);
    }
}

