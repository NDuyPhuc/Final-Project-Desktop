namespace Trung_tam_quan_ly_ngoai_ngu;

public partial class FrmSidebarPreview : Form
{
    public FrmSidebarPreview()
    {
        InitializeComponent();
        LoadSidebarIcons();
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
