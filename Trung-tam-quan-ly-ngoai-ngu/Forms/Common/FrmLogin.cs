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
            ClientSize = new Size(1366, 768);
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
            using var dialog = new FrmStatusDialog("Ho tro dang nhap", "Lien he quan tri vien de cap tai khoan hoac cap lai mat khau. Chuoi ket noi SQL duoc cau hinh tap trung trong appsettings.json.");
            dialog.ShowDialog(this);
        };

        ttLogin.SetToolTip(txtUsername, "Nhap ten dang nhap duoc cap tren he thong.");
        ttLogin.SetToolTip(txtPassword, "Mat khau duoc doi chieu voi PasswordHash trong bang Accounts.");

        LoadLoginLogoIfAvailable();
        CenterLoginPanel();

        Resize += (_, _) => CenterLoginPanel();
        Shown += (_, _) =>
        {
            CenterLoginPanel();
            txtUsername.Focus();
        };
    }

    private void ApplyLocalizedText()
    {
        Text = "Dang nhap he thong";
        lblHeaderTitle.Text = "Academic Curator";
        lblHeaderSubtitle.Text = "DANG NHAP HE THONG";
        lblUsername.Text = "TEN DANG NHAP";
        lblPassword.Text = "MAT KHAU";
        chkShowPassword.Text = "Hien mat khau";
        lnkForgotPassword.Text = "Quen mat khau?";
        btnExit.Text = "Thoat";
        btnLogin.Text = "Dang nhap";
        lblFooterVersion.Text = "Academic Curator v2.4";
        lblFooterSupport.Text = "Ho tro ky thuat";
        lblErrorAlertText.Text = "Sai ten tai khoan hoac mat khau";
        txtUsername.Text = string.Empty;
        txtPassword.Text = string.Empty;
    }

    private void CenterLoginPanel()
    {
        pnlLoginContainer.Left = Math.Max(24, (ClientSize.Width - pnlLoginContainer.Width) / 2);
        pnlLoginContainer.Top = Math.Max(24, (ClientSize.Height - pnlLoginContainer.Height) / 2);
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
                errLogin.SetError(txtUsername, "Ten dang nhap khong duoc de trong.");
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errLogin.SetError(txtPassword, "Mat khau khong duoc de trong.");
            }

            if (!string.IsNullOrWhiteSpace(errLogin.GetError(txtUsername)) || !string.IsNullOrWhiteSpace(errLogin.GetError(txtPassword)))
            {
                SetErrorState("Vui long nhap day du ten dang nhap va mat khau.");
                return;
            }

            var account = _dataService.Authenticate(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if (account is null)
            {
                SetErrorState("Sai ten tai khoan hoac mat khau.");
                return;
            }

            AppRuntime.SetCurrentUser(account);
            Form dashboard = account.Role switch
            {
                AccountRole.Admin => new FrmAdminDashboard(account.DisplayName, _dataService),
                AccountRole.Staff => new FrmStaffDashboard(account.DisplayName),
                AccountRole.Teacher => new FrmTeacherDashboard(account.DisplayName),
                _ => throw new InvalidOperationException("Vai tro khong hop le.")
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
            SetErrorState("Khong the dang nhap. Vui long kiem tra log.txt.");
        }
    }

    private void SetErrorState(string? message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            pnlErrorAlert.Visible = false;
            return;
        }

        lblErrorAlertText.Text = message;
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
