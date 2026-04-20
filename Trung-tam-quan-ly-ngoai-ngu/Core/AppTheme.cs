using System.Drawing.Drawing2D;

namespace Trung_tam_quan_ly_ngoai_ngu;

internal static class AppTheme
{
    public static readonly Color Sidebar = Color.FromArgb(230, 246, 255);
    public static readonly Color SidebarHover = Color.FromArgb(224, 241, 250);
    public static readonly Color Accent = Color.FromArgb(0, 110, 110);
    public static readonly Color SidebarBrand = Color.FromArgb(0, 66, 118);
    public static readonly Color SidebarActive = Color.FromArgb(144, 239, 239);
    public static readonly Color SidebarText = Color.FromArgb(66, 71, 80);
    public static readonly Color SidebarTitle = Color.FromArgb(7, 30, 39);
    public static readonly Color Success = Color.FromArgb(41, 166, 124);
    public static readonly Color Warning = Color.FromArgb(235, 179, 61);
    public static readonly Color Danger = Color.FromArgb(224, 91, 97);
    public static readonly Color Background = Color.FromArgb(245, 247, 251);
    public static readonly Color Surface = Color.White;
    public static readonly Color Border = Color.FromArgb(225, 230, 239);
    public static readonly Color TextPrimary = Color.FromArgb(42, 51, 64);
    public static readonly Color TextMuted = Color.FromArgb(102, 112, 133);

    public static readonly Font FontBody = new("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
    public static readonly Font FontBodyBold = new("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
    public static readonly Font FontTitle = new("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
    public static readonly Font FontSection = new("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
    public static readonly Font FontKpi = new("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
    public static readonly Font FontSidebarTitle = new("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
    public static readonly Font FontSidebarMeta = new("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point);
    public static readonly Font FontSidebarItem = new("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
    public static readonly Font FontSidebarItemBold = new("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);

    public static void ApplyFormStyle(Form form, string title)
    {
        form.Text = title;
        form.StartPosition = FormStartPosition.CenterScreen;
        form.BackColor = Background;
        form.Font = FontBody;
        form.MinimumSize = new Size(1280, 760);
    }

    public static void StylePrimaryButton(Button button)
    {
        button.BackColor = Accent;
        button.ForeColor = Color.White;
        button.FlatAppearance.BorderSize = 0;
        button.FlatStyle = FlatStyle.Flat;
        button.Cursor = Cursors.Hand;
        button.Font = FontBodyBold;
        button.Height = 36;
    }

    public static void StyleSecondaryButton(Button button)
    {
        button.BackColor = Color.White;
        button.ForeColor = Accent;
        button.FlatAppearance.BorderColor = Accent;
        button.FlatAppearance.BorderSize = 1;
        button.FlatStyle = FlatStyle.Flat;
        button.Cursor = Cursors.Hand;
        button.Font = FontBodyBold;
        button.Height = 36;
    }

    public static void StyleDangerButton(Button button)
    {
        button.BackColor = Danger;
        button.ForeColor = Color.White;
        button.FlatAppearance.BorderSize = 0;
        button.FlatStyle = FlatStyle.Flat;
        button.Cursor = Cursors.Hand;
        button.Font = FontBodyBold;
        button.Height = 36;
    }

    public static void StyleGroupBox(GroupBox groupBox)
    {
        groupBox.BackColor = Surface;
        groupBox.ForeColor = TextPrimary;
        groupBox.Font = FontSection;
        groupBox.Padding = new Padding(14, 12, 14, 14);
    }

    public static void StyleCard(Panel panel)
    {
        panel.BackColor = Surface;
        panel.Padding = new Padding(14);
        panel.Margin = new Padding(0, 0, 12, 12);
        panel.Paint += (_, e) =>
        {
            using var pen = new Pen(Border);
            var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            e.Graphics.DrawRectangle(pen, rect);
        };
    }

    public static void StyleGrid(DataGridView grid)
    {
        grid.BackgroundColor = Color.White;
        grid.BorderStyle = BorderStyle.None;
        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 251);
        grid.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimary;
        grid.ColumnHeadersDefaultCellStyle.Font = FontBodyBold;
        grid.ColumnHeadersHeight = 40;
        grid.RowTemplate.Height = 34;
        grid.RowHeadersVisible = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.MultiSelect = false;
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.GridColor = Border;
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(228, 237, 255);
        grid.DefaultCellStyle.SelectionForeColor = TextPrimary;
    }

    public static void RoundPanelCorners(Panel panel, int radius = 10)
    {
        panel.Resize += (_, _) =>
        {
            using var path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            panel.Region = new Region(path);
        };
    }
}
