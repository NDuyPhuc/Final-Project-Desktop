using System.ComponentModel;

namespace Trung_tam_quan_ly_ngoai_ngu;

[DesignerCategory("Form")]
public sealed partial class FrmLogin : Form
{
    private readonly string loginLogoPath;

    public FrmLogin()
    {
        InitializeComponent();

        AppTheme.ApplyFormStyle(this, "\u0110\u0103ng nh\u1eadp h\u1ec7 th\u1ed1ng");
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
            using var dialog = new FrmStatusDialog("H\u1ed7 tr\u1ee3 \u0111\u0103ng nh\u1eadp", "M\u00e0n n\u00e0y m\u1edbi l\u00e0 UI demo. Backend c\u00f3 th\u1ec3 n\u1ed1i sang quy tr\u00ecnh reset m\u1eadt kh\u1ea9u sau.");
            dialog.ShowDialog(this);
        };

        ttLogin.SetToolTip(txtUsername, "Nh\u1eadp admin, staff ho\u1eb7c teacher \u0111\u1ec3 m\u1edf shell t\u01b0\u01a1ng \u1ee9ng.");
        ttLogin.SetToolTip(txtPassword, "M\u1eadt kh\u1ea9u \u0111ang l\u00e0 d\u1eef li\u1ec7u demo, backend s\u1ebd n\u1ed1i x\u00e1c th\u1ef1c sau.");

        LoadLoginLogoIfAvailable();
        CenterLoginPanel();

        Resize += (_, _) => CenterLoginPanel();
        Shown += (_, _) =>
        {
            CenterLoginPanel();
            txtUsername.Focus();
        };
    }

    private void CenterLoginPanel()
    {
        pnlLoginContainer.Left = (ClientSize.Width - pnlLoginContainer.Width) / 2;
        pnlLoginContainer.Top = (ClientSize.Height - pnlLoginContainer.Height) / 2;
    }

    private static bool IsInDesignMode()
    {
        return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
    }

    private void HandleLogin()
    {
        errLogin.Clear();
        SetErrorState(null);

        if (string.IsNullOrWhiteSpace(txtUsername.Text))
        {
            errLogin.SetError(txtUsername, "T\u00ean \u0111\u0103ng nh\u1eadp kh\u00f4ng \u0111\u01b0\u1ee3c \u0111\u1ec3 tr\u1ed1ng.");
        }

        if (string.IsNullOrWhiteSpace(txtPassword.Text))
        {
            errLogin.SetError(txtPassword, "M\u1eadt kh\u1ea9u kh\u00f4ng \u0111\u01b0\u1ee3c \u0111\u1ec3 tr\u1ed1ng.");
        }

        if (!string.IsNullOrWhiteSpace(errLogin.GetError(txtUsername)) || !string.IsNullOrWhiteSpace(errLogin.GetError(txtPassword)))
        {
            SetErrorState("Vui l\u00f2ng nh\u1eadp \u0111\u1ea7y \u0111\u1ee7 t\u00ean \u0111\u0103ng nh\u1eadp v\u00e0 m\u1eadt kh\u1ea9u.");
            return;
        }

        Form? dashboard = txtUsername.Text.Trim().ToLowerInvariant() switch
        {
            "admin" => new FrmAdminDashboard("admin"),
            "staff" => new FrmStaffDashboard("staff"),
            "teacher" => new FrmTeacherDashboard("teacher"),
            _ => null
        };

        if (dashboard is null)
        {
            SetErrorState("Sai t\u00ean t\u00e0i kho\u1ea3n ho\u1eb7c m\u1eadt kh\u1ea9u");
            return;
        }

        pnlErrorAlert.Visible = false;
        Hide();
        using (dashboard)
        {
            dashboard.ShowDialog();
        }
        Show();
        txtPassword.Clear();
        txtUsername.Focus();
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
