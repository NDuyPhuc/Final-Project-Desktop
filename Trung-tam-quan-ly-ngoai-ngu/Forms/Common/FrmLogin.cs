using System.ComponentModel;
using TrungTamNgoaiNgu.Application.Contracts;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Domain.Enums;

namespace Trung_tam_quan_ly_ngoai_ngu;

[DesignerCategory("Form")]
public sealed partial class FrmLogin : Form
{
    private readonly ILanguageCenterDataService _dataService;
    private readonly string loginLogoPath;

    public FrmLogin() : this(AppRuntime.DataService)
    {
    }

    public FrmLogin(ILanguageCenterDataService dataService)
    {
        _dataService = dataService;
        InitializeComponent();

        AppTheme.ApplyFormStyle(this, "\u0110\u0103ng nh\u1eadp h\u1ec7 th\u1ed1ng");
        ApplyLocalizedText();
        AutoScroll = true;
        if (!IsInDesignMode())
        {
            var workingArea = Screen.FromPoint(Cursor.Position).WorkingArea;
            var desiredSize = FormHostHelpers.ScaleSize(this, new Size(1366, 768));
            ClientSize = new Size(
                Math.Min(workingArea.Width, Math.Max(MinimumSize.Width, desiredSize.Width)),
                Math.Min(workingArea.Height, Math.Max(MinimumSize.Height, desiredSize.Height)));
        }
        BackColor = Color.FromArgb(233, 237, 244);

        loginLogoPath = Path.Combine(AppContext.BaseDirectory, "Resources", "Images", "UI", "Login", "login-logo.png");

        AcceptButton = btnLogin;
        CancelButton = btnExit;

        pnlLoginContainer.Paint += (_, e) =>
        {
            using var shadowBrush = new SolidBrush(Color.FromArgb(18, 26, 28, 28));
            e.Graphics.FillRectangle(shadowBrush, new Rectangle(8, 8, pnlLoginContainer.Width - 8, pnlLoginContainer.Height - 8));
            using var surfaceBrush = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(surfaceBrush, new Rectangle(0, 0, pnlLoginContainer.Width - 10, pnlLoginContainer.Height - 10));
        };
        pnlLoginHeader.Paint += DrawLoginHeaderBackground;
        picHeaderLogo.Paint += DrawHeaderLogoFallback;
        pnlErrorIcon.Paint += DrawErrorIcon;

        chkShowPassword.CheckedChanged += (_, _) => txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        btnExit.Click += (_, _) => Close();
        btnLogin.Click += (_, _) => HandleLogin();
        lnkForgotPassword.LinkClicked += (_, _) =>
        {
            using var dialog = new FrmStatusDialog("Hỗ trợ đăng nhập", "Liên hệ quản trị viên để cấp tài khoản hoặc cấp lại mật khẩu. Chuỗi kết nối SQL được cấu hình tập trung trong appsettings.json.");
            dialog.ShowDialog(this);
        };

        ttLogin.SetToolTip(txtUsername, "Nhập tên đăng nhập được cấp trên hệ thống.");
        ttLogin.SetToolTip(txtPassword, "Mật khẩu được đối chiếu với PasswordHash trong bảng Accounts.");

        LoadLoginLogoIfAvailable();
        ApplyResponsiveLayout();

        Resize += (_, _) => ApplyResponsiveLayout();
        Shown += (_, _) =>
        {
            ApplyResponsiveLayout();
            txtUsername.Focus();
        };
    }

    private void ApplyLocalizedText()
    {
        Text = "Đăng nhập hệ thống";
        lblHeaderTitle.Text = "Academic Curator";
        lblHeaderSubtitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
        lblUsername.Text = "TÊN ĐĂNG NHẬP";
        lblPassword.Text = "MẬT KHẨU";
        chkShowPassword.Text = "Hiện mật khẩu";
        lnkForgotPassword.Text = "Quên mật khẩu?";
        btnExit.Text = "Thoát";
        btnLogin.Text = "Đăng nhập";
        lblFooterVersion.Text = "Academic Curator v2.4";
        lblFooterSupport.Text = "Hỗ trợ kỹ thuật";
        lblErrorAlertText.Text = "Sai tên tài khoản hoặc mật khẩu";
        txtUsername.Text = string.Empty;
        txtPassword.Text = string.Empty;
    }

    private void CenterLoginPanel()
    {
        var outerMargin = FormHostHelpers.ScaleForDpi(this, 24);
        pnlLoginContainer.Left = Math.Max(outerMargin, (ClientSize.Width - pnlLoginContainer.Width) / 2);
        pnlLoginContainer.Top = Math.Max(outerMargin, (ClientSize.Height - pnlLoginContainer.Height) / 2);
    }

    private void ApplyResponsiveLayout()
    {
        if (IsInDesignMode())
        {
            return;
        }

        var outerMargin = FormHostHelpers.ScaleForDpi(this, 24);
        var compact = ClientSize.Width < FormHostHelpers.ScaleForDpi(this, 980);
        var containerWidth = Math.Min(
            Math.Max(pnlLoginContainer.MinimumSize.Width, ClientSize.Width - outerMargin * 2),
            FormHostHelpers.ScaleForDpi(this, compact ? 520 : 560));
        var containerHeight = Math.Max(
            pnlLoginContainer.MinimumSize.Height,
            Math.Min(ClientSize.Height - outerMargin * 2, FormHostHelpers.ScaleForDpi(this, 760)));

        pnlLoginContainer.Size = new Size(containerWidth, containerHeight);
        pnlLoginHeader.Height = FormHostHelpers.ScaleForDpi(this, compact ? 176 : 200);
        pnlLoginFooter.Height = FormHostHelpers.ScaleForDpi(this, 56);
        tblFooter.Padding = FormHostHelpers.ScalePadding(this, new Padding(compact ? 20 : 32, 12, compact ? 20 : 32, 12));
        pnlLoginFormContent.Padding = FormHostHelpers.ScalePadding(this, new Padding(compact ? 24 : 32, 0, compact ? 24 : 32, 0));

        var contentWidth = pnlLoginFormContent.ClientSize.Width - pnlLoginFormContent.Padding.Horizontal;
        if (contentWidth > 0)
        {
            pnlErrorAlert.Width = contentWidth;
            lblUsername.Width = contentWidth;
            pnlUsernameInput.Width = contentWidth;
            lblPassword.Width = contentWidth;
            pnlPasswordInput.Width = contentWidth;
            pnlSubControls.Width = contentWidth;
            pnlActionButtons.Width = contentWidth;

            var gap = FormHostHelpers.ScaleForDpi(this, 16);
            var buttonWidth = Math.Max(FormHostHelpers.ScaleForDpi(this, 140), (contentWidth - gap) / 2);
            btnExit.SetBounds(0, 0, buttonWidth, btnExit.Height);
            btnLogin.SetBounds(contentWidth - buttonWidth, 0, buttonWidth, btnLogin.Height);
        }

        CenterLoginPanel();
    }

    private static bool IsInDesignMode()
    {
        return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
    }

    private void HandleLogin()
    {
        try
        {
            errLogin.Clear();
            SetErrorState(null);

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errLogin.SetError(txtUsername, "Tên đăng nhập không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errLogin.SetError(txtPassword, "Mật khẩu không được để trống.");
            }

            if (!string.IsNullOrWhiteSpace(errLogin.GetError(txtUsername)) || !string.IsNullOrWhiteSpace(errLogin.GetError(txtPassword)))
            {
                SetErrorState("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.");
                return;
            }

            var account = _dataService.Authenticate(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if (account is null)
            {
                SetErrorState("Sai tên tài khoản hoặc mật khẩu.");
                return;
            }

            AppRuntime.SetCurrentUser(account);
            Form dashboard = account.Role switch
            {
                AccountRole.Admin => new FrmAdminDashboard(account.DisplayName, _dataService),
                AccountRole.Staff => new FrmStaffDashboard(account.DisplayName),
                AccountRole.Teacher => new FrmTeacherDashboard(account.DisplayName),
                _ => throw new InvalidOperationException("Vai trò không hợp lệ.")
            };

            pnlErrorAlert.Visible = false;
            Hide();
            using (dashboard)
            {
                dashboard.ShowDialog();
            }

            AppRuntime.SetCurrentUser(null);
            Show();
            txtPassword.Clear();
            txtUsername.Focus();
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "FrmLogin.HandleLogin");
            SetErrorState("Không thể đăng nhập. Vui lòng kiểm tra log.txt.");
        }
    }

    private void SetErrorState(string? message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            pnlErrorAlert.Visible = false;
            return;
        }
        lblErrorAlertText.Text = "Sai tên tài khoản hoặc mật khẩu";
        pnlErrorAlert.Visible = true;
    }

    private void DrawLoginHeaderBackground(object? sender, PaintEventArgs e)
    {
        using var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            new Rectangle(0, 0, pnlLoginHeader.Width, pnlLoginHeader.Height),
            Color.FromArgb(0, 30, 64),
            Color.FromArgb(0, 51, 102),
            90F);
        e.Graphics.FillRectangle(brush, new Rectangle(0, 0, pnlLoginHeader.Width, pnlLoginHeader.Height));
    }

    private void DrawHeaderLogoFallback(object? sender, PaintEventArgs e)
    {
        if (picHeaderLogo.Image is not null)
        {
            return;
        }

        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        using var borderPen = new Pen(Color.FromArgb(68, 255, 255, 255));
        using var fillBrush = new SolidBrush(Color.FromArgb(0, 30, 64));
        e.Graphics.FillRoundedRectangle(fillBrush, new Rectangle(0, 0, picHeaderLogo.Width - 1, picHeaderLogo.Height - 1), 12);
        e.Graphics.DrawRoundedRectangle(borderPen, new Rectangle(0, 0, picHeaderLogo.Width - 1, picHeaderLogo.Height - 1), 12);

        using var cubePen = new Pen(Color.White, 1.8F);
        var centerX = picHeaderLogo.Width / 2F;
        var top = 18F;
        var size = 22F;
        var pointsTop = new[]
        {
            new PointF(centerX, top),
            new PointF(centerX + size / 2F, top + size / 4F),
            new PointF(centerX, top + size / 2F),
            new PointF(centerX - size / 2F, top + size / 4F)
        };
        e.Graphics.DrawPolygon(cubePen, pointsTop);
        e.Graphics.DrawLine(cubePen, centerX, top + size / 2F, centerX, top + size);
        e.Graphics.DrawLine(cubePen, centerX - size / 2F, top + size / 4F, centerX - size / 2F, top + size * 0.75F);
        e.Graphics.DrawLine(cubePen, centerX + size / 2F, top + size / 4F, centerX + size / 2F, top + size * 0.75F);
        e.Graphics.DrawLine(cubePen, centerX - size / 2F, top + size * 0.75F, centerX, top + size);
        e.Graphics.DrawLine(cubePen, centerX + size / 2F, top + size * 0.75F, centerX, top + size);
    }

    private void DrawErrorIcon(object? sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        using var brush = new SolidBrush(Color.FromArgb(186, 26, 26));
        e.Graphics.FillEllipse(brush, 0, 0, 18, 18);
        using var pen = new Pen(Color.White, 2F);
        e.Graphics.DrawLine(pen, 9, 4, 9, 10);
        e.Graphics.DrawLine(pen, 9, 13, 9, 13);
    }

    private void LoadLoginLogoIfAvailable()
    {
        if (!File.Exists(loginLogoPath))
        {
            return;
        }

        using var stream = new FileStream(loginLogoPath, FileMode.Open, FileAccess.Read);
        picHeaderLogo.Image = Image.FromStream(stream);
    }
}

internal static class LoginDrawingExtensions
{
    public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle bounds, int radius)
    {
        using var path = BuildRoundedPath(bounds, radius);
        graphics.DrawPath(pen, path);
    }

    public static void FillRoundedRectangle(this Graphics graphics, Brush brush, Rectangle bounds, int radius)
    {
        using var path = BuildRoundedPath(bounds, radius);
        graphics.FillPath(brush, path);
    }

    private static System.Drawing.Drawing2D.GraphicsPath BuildRoundedPath(Rectangle bounds, int radius)
    {
        var diameter = radius * 2;
        var path = new System.Drawing.Drawing2D.GraphicsPath();
        path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
        path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
        path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();
        return path;
    }
}
