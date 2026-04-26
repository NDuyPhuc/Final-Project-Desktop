namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmSidebarPreview : Form
{
    public FrmSidebarPreview()
    {
        InitializeComponent();
        FormHostHelpers.ConfigureModuleSurface(this, "Sidebar Preview");
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = FormHostHelpers.ScaleSize(this, new Size(1200, 760));
        ScalePreviewChrome();
        LoadSidebarIcons();
    }

    private void ScalePreviewChrome()
    {
        pnlSidebar.Width = FormHostHelpers.ScaleForDpi(this, 256);
        pnlSidebarBottom.Height = FormHostHelpers.ScaleForDpi(this, 125);
        pnlSidebarBottom.Padding = FormHostHelpers.ScalePadding(this, new Padding(24));
        pnlSidebarTop.Height = FormHostHelpers.ScaleForDpi(this, 384);
        flpSidebarMenu.Location = new Point(
            FormHostHelpers.ScaleForDpi(this, 24),
            FormHostHelpers.ScaleForDpi(this, 116));
        flpSidebarMenu.Size = FormHostHelpers.ScaleSize(this, new Size(208, 236));
        pnlBrandRow.Location = new Point(
            FormHostHelpers.ScaleForDpi(this, 24),
            FormHostHelpers.ScaleForDpi(this, 32));
        pnlBrandRow.Size = FormHostHelpers.ScaleSize(this, new Size(208, 44));
        pnlCanvas.Location = new Point(
            FormHostHelpers.ScaleForDpi(this, 32),
            FormHostHelpers.ScaleForDpi(this, 88));
        lblPreviewHint.Location = new Point(
            FormHostHelpers.ScaleForDpi(this, 32),
            FormHostHelpers.ScaleForDpi(this, 32));
    }

    private void pnlSidebarBottom_Paint(object? sender, PaintEventArgs e)
    {
        using var pen = new Pen(Color.FromArgb(50, 194, 199, 209));
        e.Graphics.DrawLine(pen, 0, 0, pnlSidebarBottom.Width, 0);
    }

    private void pnlNavDashboardContent_Paint(object? sender, PaintEventArgs e)
    {
        using var brush = new SolidBrush(Color.FromArgb(0, 110, 110));
        e.Graphics.FillRectangle(brush, pnlNavDashboardContent.Width - 4, 0, 4, pnlNavDashboardContent.Height);
    }

    private void LoadSidebarIcons()
    {
        ApplySidebarIcon(pnlBrandMark, "logo-mark", lblBrandGlyph);
        ApplySidebarIcon(pnlNavDashboardIcon, "access-control");
        ApplySidebarIcon(pnlNavTeacherIcon, "staff-directory");
        ApplySidebarIcon(pnlNavStudentIcon, "student-matrix");
        ApplySidebarIcon(pnlNavScheduleIcon, "schedule");
        ApplySidebarIcon(pnlNavFinanceIcon, "finance");
        ApplySidebarIcon(pnlSidebarDocumentsIcon, "documents");
        ApplySidebarIcon(pnlSidebarSupportIcon, "support");
    }

    private static void ApplySidebarIcon(Panel panel, string iconKey, Control? fallback = null)
    {
        var iconPath = ResolveSidebarIconPath(iconKey);
        if (iconPath is null)
        {
            return;
        }

        try
        {
            using var source = Image.FromFile(iconPath);
            panel.BackgroundImage = new Bitmap(source);
            panel.BackgroundImageLayout = ImageLayout.Zoom;
            panel.BackColor = Color.Transparent;
            if (fallback is not null)
            {
                fallback.Visible = false;
            }
        }
        catch
        {
        }
    }

    private static string? ResolveSidebarIconPath(string iconKey)
    {
        var fileName = $"{iconKey}.png";
        var roots = new[]
        {
            AppContext.BaseDirectory,
            Environment.CurrentDirectory
        }
        .Where(path => !string.IsNullOrWhiteSpace(path))
        .Distinct(StringComparer.OrdinalIgnoreCase);

        foreach (var root in roots)
        {
            var directory = new DirectoryInfo(root);
            while (directory is not null)
            {
                var candidate = Path.Combine(directory.FullName, "Resources", "Images", "UI", "Icons", "Sidebar", fileName);
                if (File.Exists(candidate))
                {
                    return candidate;
                }

                candidate = Path.Combine(directory.FullName, "Trung-tam-quan-ly-ngoai-ngu", "Resources", "Images", "UI", "Icons", "Sidebar", fileName);
                if (File.Exists(candidate))
                {
                    return candidate;
                }

                directory = directory.Parent;
            }
        }

        return null;
    }
}
