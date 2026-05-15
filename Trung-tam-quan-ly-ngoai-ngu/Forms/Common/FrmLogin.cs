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
    private readonly string loginBackgroundPath;
    private Image? loginBackgroundImage;

    public FrmLogin() : this(AppRuntime.DataService)
    {
    }

    public FrmLogin(ILanguageCenterDataService dataService)
    {
        _dataService = dataService;
        InitializeComponent();
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        UpdateStyles();

        AppTheme.ApplyFormStyle(this, "\u0110\u0103ng nh\u1eadp h\u1ec7 th\u1ed1ng");
        ApplyLocalizedText();
        AutoScroll = false;
        lblHeaderTitle.AutoSize = false;
        lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;
        lblHeaderSubtitle.AutoSize = false;
        lblHeaderSubtitle.TextAlign = ContentAlignment.MiddleCenter;
        if (!IsInDesignMode())
        {
            var workingArea = Screen.FromPoint(Cursor.Position).WorkingArea;
            var desiredSize = FormHostHelpers.ScaleSize(this, new Size(1366, 768));
            ClientSize = new Size(
                Math.Min(workingArea.Width, Math.Max(MinimumSize.Width, desiredSize.Width)),
                Math.Min(workingArea.Height, Math.Max(MinimumSize.Height, desiredSize.Height)));
        }
        BackColor = Color.FromArgb(10, 20, 34);

        loginLogoPath = Path.Combine(AppContext.BaseDirectory, "Resources", "Images", "UI", "Login", "login-logo.png");
        loginBackgroundPath = Path.Combine(AppContext.BaseDirectory, "Resources", "Images", "UI", "Login", "login-background.jpg");

        AcceptButton = btnLogin;
        CancelButton = btnExit;

        pnlLoginContainer.Paint += (_, e) =>
        {
            using var surfaceBrush = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(surfaceBrush, new Rectangle(0, 0, pnlLoginContainer.Width - 1, pnlLoginContainer.Height - 1));
            using var borderPen = new Pen(Color.FromArgb(220, 226, 235));
            e.Graphics.DrawRectangle(borderPen, 0, 0, pnlLoginContainer.Width - 1, pnlLoginContainer.Height - 1);
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

        LoadLoginAssetsIfAvailable();
        ApplyResponsiveLayout();

        Resize += (_, _) =>
        {
            ApplyResponsiveLayout();
            Invalidate();
        };
        Shown += (_, _) =>
        {
            ApplyResponsiveLayout();
            txtUsername.Focus();
        };
        Disposed += (_, _) =>
        {
            loginBackgroundImage?.Dispose();
            picHeaderLogo.Image?.Dispose();
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
        pnlLoginFormContent.AutoScroll = false;

        picHeaderLogo.Location = new Point((pnlLoginHeaderOverlay.ClientSize.Width - picHeaderLogo.Width) / 2, FormHostHelpers.ScaleForDpi(this, 28));
        lblHeaderTitle.SetBounds(0, picHeaderLogo.Bottom + FormHostHelpers.ScaleForDpi(this, 10), pnlLoginHeaderOverlay.ClientSize.Width, FormHostHelpers.ScaleForDpi(this, 46));
        lblHeaderSubtitle.SetBounds(0, lblHeaderTitle.Bottom + FormHostHelpers.ScaleForDpi(this, 4), pnlLoginHeaderOverlay.ClientSize.Width, FormHostHelpers.ScaleForDpi(this, 24));

        var contentWidth = pnlLoginFormContent.ClientSize.Width - pnlLoginFormContent.Padding.Horizontal;
        if (contentWidth > 0)
        {
            var left = pnlLoginFormContent.Padding.Left;
            var top = FormHostHelpers.ScaleForDpi(this, 24);

            pnlErrorAlert.SetBounds(left, top, contentWidth, pnlErrorAlert.Height);
            top = pnlErrorAlert.Visible
                ? pnlErrorAlert.Bottom + FormHostHelpers.ScaleForDpi(this, 18)
                : FormHostHelpers.ScaleForDpi(this, 28);

            lblUsername.SetBounds(left, top, contentWidth, lblUsername.Height);
            top = lblUsername.Bottom + FormHostHelpers.ScaleForDpi(this, 6);
            pnlUsernameInput.SetBounds(left, top, contentWidth, pnlUsernameInput.Height);
            txtUsername.SetBounds(FormHostHelpers.ScaleForDpi(this, 14), txtUsername.Top, contentWidth - FormHostHelpers.ScaleForDpi(this, 28), txtUsername.Height);
            pnlUsernameIcon.Visible = false;

            top = pnlUsernameInput.Bottom + FormHostHelpers.ScaleForDpi(this, 14);
            lblPassword.SetBounds(left, top, contentWidth, lblPassword.Height);
            top = lblPassword.Bottom + FormHostHelpers.ScaleForDpi(this, 6);
            pnlPasswordInput.SetBounds(left, top, contentWidth, pnlPasswordInput.Height);
            txtPassword.SetBounds(FormHostHelpers.ScaleForDpi(this, 14), txtPassword.Top, contentWidth - FormHostHelpers.ScaleForDpi(this, 28), txtPassword.Height);
            pnlPasswordIcon.Visible = false;

            top = pnlPasswordInput.Bottom + FormHostHelpers.ScaleForDpi(this, 18);
            pnlSubControls.SetBounds(left, top, contentWidth, pnlSubControls.Height);

            top = pnlSubControls.Bottom + FormHostHelpers.ScaleForDpi(this, 28);
            pnlActionButtons.SetBounds(left, top, contentWidth, pnlActionButtons.Height);

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
            ApplyResponsiveLayout();
            return;
        }
        lblErrorAlertText.Text = message;
        pnlErrorAlert.Visible = true;
        ApplyResponsiveLayout();
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        if (loginBackgroundImage is not null)
        {
            DrawCoverImage(e.Graphics, loginBackgroundImage, ClientRectangle);
        }
        else
        {
            e.Graphics.Clear(Color.FromArgb(10, 20, 34));
        }

        using var overlayBrush = new SolidBrush(Color.FromArgb(116, 12, 24, 40));
        e.Graphics.FillRectangle(overlayBrush, ClientRectangle);
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

    private void LoadLoginAssetsIfAvailable()
    {
        if (File.Exists(loginBackgroundPath))
        {
            loginBackgroundImage?.Dispose();
            loginBackgroundImage = LoadImageCopy(loginBackgroundPath);
        }

        if (File.Exists(loginLogoPath))
        {
            picHeaderLogo.Image?.Dispose();
            picHeaderLogo.Image = LoadImageCopy(loginLogoPath);
        }

        Invalidate();
    }

    private static Image LoadImageCopy(string path)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var sourceImage = Image.FromStream(stream);
        return new Bitmap(sourceImage);
    }

    private static void DrawCoverImage(Graphics graphics, Image image, Rectangle bounds)
    {
        var scale = Math.Max(bounds.Width / (float)image.Width, bounds.Height / (float)image.Height);
        var drawWidth = (int)Math.Ceiling(image.Width * scale);
        var drawHeight = (int)Math.Ceiling(image.Height * scale);
        var drawX = bounds.X + (bounds.Width - drawWidth) / 2;
        var drawY = bounds.Y + (bounds.Height - drawHeight) / 2;
        graphics.DrawImage(image, new Rectangle(drawX, drawY, drawWidth, drawHeight));
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
