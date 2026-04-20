namespace Trung_tam_quan_ly_ngoai_ngu;

public sealed record ShellChromeNames(
    string SidebarName,
    string TopbarName,
    string ContentHostName,
    string CurrentRoleLabelName,
    string CurrentUserLabelName,
    string LogoutButtonName);

public sealed record MenuDefinition(string Key, string Text, string ButtonName);

public abstract class ModuleFormBase : Form
{
    protected readonly Panel pnlModuleHeader;
    protected readonly Panel pnlModuleBody;

    protected ModuleFormBase(string title)
    {
        AppTheme.ApplyFormStyle(this, title);
        TopLevel = false;
        FormBorderStyle = FormBorderStyle.None;
        Dock = DockStyle.Fill;

        pnlModuleHeader = UiHelpers.CreatePanel("pnlModuleHeader", DockStyle.Top);
        pnlModuleHeader.Height = 56;
        pnlModuleHeader.Padding = new Padding(8, 12, 0, 8);
        pnlModuleHeader.BackColor = AppTheme.Background;
        pnlModuleHeader.Controls.Add(UiHelpers.CreateLabel("lblModuleTitle", title, AppTheme.FontTitle, AppTheme.TextPrimary));

        pnlModuleBody = UiHelpers.CreatePanel("pnlModuleBody", DockStyle.Fill);
        pnlModuleBody.BackColor = AppTheme.Background;
        pnlModuleBody.Padding = new Padding(8);

        Controls.Add(pnlModuleBody);
        Controls.Add(pnlModuleHeader);
    }
}

public abstract class ShellFormBase : Form
{
    private readonly Dictionary<string, Panel> _menuItems = [];
    protected readonly Panel pnlSidebar;
    protected readonly Panel pnlTopbar;
    protected readonly Panel pnlContentHost;
    protected readonly Label lblCurrentRole;
    protected readonly Label lblCurrentUser;
    protected readonly Button btnLogout;
    protected readonly string CurrentUserName;

    protected ShellFormBase(string title, string roleText, string currentUserName, ShellChromeNames chromeNames)
    {
        CurrentUserName = currentUserName;
        AppTheme.ApplyFormStyle(this, title);
        WindowState = FormWindowState.Maximized;

        pnlSidebar = UiHelpers.CreatePanel(chromeNames.SidebarName, DockStyle.Left);
        pnlSidebar.Width = 256;
        pnlSidebar.BackColor = AppTheme.Sidebar;
        pnlSidebar.Padding = new Padding(0);

        pnlTopbar = UiHelpers.CreatePanel(chromeNames.TopbarName, DockStyle.Top);
        pnlTopbar.Height = 68;
        pnlTopbar.Padding = new Padding(24, 18, 24, 18);
        pnlTopbar.BackColor = Color.White;
        pnlTopbar.Paint += (_, e) =>
        {
            using var pen = new Pen(AppTheme.Border);
            e.Graphics.DrawLine(pen, 0, pnlTopbar.Height - 1, pnlTopbar.Width, pnlTopbar.Height - 1);
        };

        pnlContentHost = UiHelpers.CreatePanel(chromeNames.ContentHostName, DockStyle.Fill);
        pnlContentHost.BackColor = AppTheme.Background;
        pnlContentHost.Padding = new Padding(18);

        lblCurrentRole = UiHelpers.CreateLabel(chromeNames.CurrentRoleLabelName, roleText, AppTheme.FontBodyBold, AppTheme.Accent);
        lblCurrentUser = UiHelpers.CreateLabel(chromeNames.CurrentUserLabelName, currentUserName, AppTheme.FontBodyBold, AppTheme.TextPrimary);
        btnLogout = UiHelpers.CreateButton(chromeNames.LogoutButtonName, "\u0110\u0103ng xu\u1ea5t", "secondary");
        btnLogout.Width = 110;
        btnLogout.Click += (_, _) =>
        {
            Hide();
            using var login = new FrmLogin();
            login.ShowDialog();
            Close();
        };

        var topbarLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 1
        };
        topbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        topbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        topbarLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        topbarLayout.Controls.Add(lblCurrentRole, 0, 0);
        topbarLayout.Controls.Add(lblCurrentUser, 1, 0);
        topbarLayout.Controls.Add(btnLogout, 2, 0);
        pnlTopbar.Controls.Add(topbarLayout);

        Controls.Add(pnlContentHost);
        Controls.Add(pnlTopbar);
        Controls.Add(pnlSidebar);

        BuildSidebar(roleText);
        ShowDashboard();
    }

    private void BuildSidebar(string roleText)
    {
        var pnlSidebarTop = UiHelpers.CreatePanel("pnlSidebarTop", DockStyle.Top);
        pnlSidebarTop.Height = 384;
        pnlSidebarTop.BackColor = Color.Transparent;

        var brandRow = new Panel
        {
            Name = "pnlBrandRow",
            Location = new Point(24, 32),
            Size = new Size(208, 44),
            BackColor = Color.Transparent
        };

        var pnlBrandMark = new Panel
        {
            Name = "pnlBrandMark",
            Location = new Point(0, 2),
            Size = new Size(40, 40),
            BackColor = AppTheme.SidebarBrand,
            BackgroundImageLayout = ImageLayout.Zoom
        };

        var lblBrandGlyph = new Label
        {
            Name = "lblBrandGlyph",
            Dock = DockStyle.Fill,
            Text = "A",
            Font = new Font("Segoe UI", 12F, FontStyle.Bold),
            ForeColor = Color.White,
            TextAlign = ContentAlignment.MiddleCenter,
            BackColor = Color.Transparent
        };
        pnlBrandMark.Controls.Add(lblBrandGlyph);
        TryApplySidebarIcon(pnlBrandMark, "logo-mark");
        lblBrandGlyph.Visible = pnlBrandMark.BackgroundImage is null;

        var lblBrandTitle = new Label
        {
            Name = "lblBrandTitle",
            Location = new Point(52, 0),
            Size = new Size(156, 24),
            Text = ResolveSidebarTitle(roleText),
            Font = AppTheme.FontSidebarTitle,
            ForeColor = AppTheme.SidebarTitle,
            TextAlign = ContentAlignment.MiddleLeft
        };

        var lblBrandSubtitle = new Label
        {
            Name = "lblBrandSubtitle",
            Location = new Point(52, 24),
            Size = new Size(156, 16),
            Text = roleText,
            Font = AppTheme.FontSidebarMeta,
            ForeColor = AppTheme.SidebarText,
            TextAlign = ContentAlignment.MiddleLeft
        };

        brandRow.Controls.Add(pnlBrandMark);
        brandRow.Controls.Add(lblBrandTitle);
        brandRow.Controls.Add(lblBrandSubtitle);

        var navPanel = new FlowLayoutPanel
        {
            Name = "pnlSidebarMenu",
            Location = new Point(24, 116),
            Size = new Size(208, 236),
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            BackColor = Color.Transparent,
            Margin = new Padding(0),
            Padding = new Padding(0)
        };

        foreach (var menu in GetMenuDefinitions())
        {
            var item = CreateSidebarNavItem(menu);
            _menuItems[menu.Key] = item;
            navPanel.Controls.Add(item);
        }

        pnlSidebarTop.Controls.Add(brandRow);
        pnlSidebarTop.Controls.Add(navPanel);

        var pnlSidebarBottom = UiHelpers.CreatePanel("pnlSidebarBottom", DockStyle.Bottom);
        pnlSidebarBottom.Height = 125;
        pnlSidebarBottom.BackColor = Color.Transparent;
        pnlSidebarBottom.Padding = new Padding(24);
        pnlSidebarBottom.Paint += (_, e) =>
        {
            using var pen = new Pen(Color.FromArgb(50, 194, 199, 209));
            e.Graphics.DrawLine(pen, 0, 0, pnlSidebarBottom.Width, 0);
        };

        var footerNav = new FlowLayoutPanel
        {
            Name = "pnlSidebarFooterNav",
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            BackColor = Color.Transparent,
            Margin = new Padding(0),
            Padding = new Padding(0)
        };
        footerNav.Controls.Add(CreateSidebarFooterItem("btnSidebarDocuments", "T\u00e0i li\u1ec7u"));
        footerNav.Controls.Add(CreateSidebarFooterItem("btnSidebarSupport", "H\u1ed7 tr\u1ee3"));

        pnlSidebarBottom.Controls.Add(footerNav);
        pnlSidebar.Controls.Add(pnlSidebarBottom);
        pnlSidebar.Controls.Add(pnlSidebarTop);
    }

    protected void HighlightMenu(string key)
    {
        foreach (var item in _menuItems)
        {
            ApplySidebarItemState(item.Value, item.Key == key);
        }
    }

    private void OnMenuClicked(string key)
    {
        if (key == "dashboard")
        {
            ShowDashboard();
            return;
        }

        var form = CreateModuleForm(key);
        if (form is null)
        {
            return;
        }

        HighlightMenu(key);
        UiHelpers.ShowChildForm(pnlContentHost, form);
    }

    protected void ShowDashboard()
    {
        HighlightMenu("dashboard");
        foreach (Control control in pnlContentHost.Controls)
        {
            control.Dispose();
        }

        pnlContentHost.Controls.Clear();
        var home = BuildDashboardHome();
        home.Dock = DockStyle.Fill;
        pnlContentHost.Controls.Add(home);
    }

    protected abstract IReadOnlyList<MenuDefinition> GetMenuDefinitions();
    protected abstract Control BuildDashboardHome();
    protected abstract Form? CreateModuleForm(string key);

    private Panel CreateSidebarNavItem(MenuDefinition menu)
    {
        var item = new Panel
        {
            Name = menu.ButtonName,
            Size = new Size(208, 44),
            Margin = new Padding(0, 0, 0, 4),
            BackColor = Color.Transparent,
            Cursor = Cursors.Hand,
            Tag = menu.Key
        };

        var content = new Panel
        {
            Name = $"pnl{menu.ButtonName}Content",
            Location = new Point(0, 0),
            Size = new Size(208, 44),
            BackColor = Color.Transparent,
            Cursor = Cursors.Hand
        };

        var icon = new Panel
        {
            Name = $"pnl{menu.ButtonName}Icon",
            Location = new Point(16, 12),
            Size = new Size(16, 20),
            BackColor = AppTheme.SidebarText,
            Cursor = Cursors.Hand,
            BackgroundImageLayout = ImageLayout.Zoom
        };
        TryApplySidebarIcon(icon, ResolveMenuIconKey(menu));

        var label = new Label
        {
            Name = $"lbl{menu.ButtonName}Text",
            Location = new Point(44, 12),
            Size = new Size(144, 20),
            Text = menu.Text,
            Font = AppTheme.FontSidebarItem,
            ForeColor = AppTheme.SidebarText,
            TextAlign = ContentAlignment.MiddleLeft,
            Cursor = Cursors.Hand
        };

        content.Controls.Add(icon);
        content.Controls.Add(label);
        item.Controls.Add(content);

        WireSidebarItemClick(item, menu.Key);
        ApplySidebarItemState(item, false);
        return item;
    }

    private Panel CreateSidebarFooterItem(string name, string text)
    {
        var item = new Panel
        {
            Name = name,
            Size = new Size(208, 40),
            Margin = new Padding(0, 0, 0, 4),
            BackColor = Color.Transparent,
            Cursor = Cursors.Hand
        };

        var icon = new Panel
        {
            Name = $"pnl{name}Icon",
            Location = new Point(16, 10),
            Size = new Size(16, 20),
            BackColor = AppTheme.SidebarText,
            BackgroundImageLayout = ImageLayout.Zoom
        };

        var label = new Label
        {
            Name = $"lbl{name}Text",
            Location = new Point(44, 10),
            Size = new Size(120, 20),
            Text = text,
            Font = AppTheme.FontSidebarItem,
            ForeColor = AppTheme.SidebarText,
            TextAlign = ContentAlignment.MiddleLeft
        };

        item.Controls.Add(icon);
        item.Controls.Add(label);
        TryApplySidebarIcon(icon, name == "btnSidebarDocuments" ? "documents" : "support");
        item.Click += (_, _) => ShowSidebarInfo(text);
        icon.Click += (_, _) => ShowSidebarInfo(text);
        label.Click += (_, _) => ShowSidebarInfo(text);
        return item;
    }

    private void WireSidebarItemClick(Control control, string key)
    {
        control.Click += (_, _) => OnMenuClicked(key);
        foreach (Control child in control.Controls)
        {
            WireSidebarItemClick(child, key);
        }
    }

    private static void ApplySidebarItemState(Panel item, bool isActive)
    {
        var content = item.Controls.OfType<Panel>().FirstOrDefault();
        var icon = content?.Controls.OfType<Panel>().FirstOrDefault();
        var label = content?.Controls.OfType<Label>().FirstOrDefault();

        if (content is not null)
        {
            content.BackColor = isActive ? AppTheme.SidebarActive : Color.Transparent;
            content.Paint -= PaintSidebarActiveBorder;
            if (isActive)
            {
                content.Paint += PaintSidebarActiveBorder;
            }
            else
            {
                content.Invalidate();
            }
        }

        if (icon is not null)
        {
            if (icon.BackgroundImage is null)
            {
                icon.BackColor = isActive ? AppTheme.Accent : AppTheme.SidebarText;
            }
        }

        if (label is not null)
        {
            label.ForeColor = isActive ? AppTheme.Accent : AppTheme.SidebarText;
            label.Font = isActive ? AppTheme.FontSidebarItemBold : AppTheme.FontSidebarItem;
        }
    }

    private static void PaintSidebarActiveBorder(object? sender, PaintEventArgs e)
    {
        if (sender is not Panel panel)
        {
            return;
        }

        using var brush = new SolidBrush(AppTheme.Accent);
        e.Graphics.FillRectangle(brush, panel.Width - 4, 0, 4, panel.Height);
    }

    private static string ResolveSidebarTitle(string roleText)
    {
        if (roleText.Contains("Admin", StringComparison.OrdinalIgnoreCase))
        {
            return "System Admin";
        }

        if (roleText.Contains("Teacher", StringComparison.OrdinalIgnoreCase) ||
            roleText.Contains("Gi\u00e1o", StringComparison.OrdinalIgnoreCase))
        {
            return "Teacher Space";
        }

        return "Operations Hub";
    }

    private void ShowSidebarInfo(string text)
    {
        MessageBox.Show($"{text} s\u1ebd \u0111\u01b0\u1ee3c c\u1eadp nh\u1eadt \u1edf b\u01b0\u1edbc sau.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private static string ResolveMenuIconKey(MenuDefinition menu)
    {
        return menu.Key switch
        {
            "dashboard" => "access-control",
            "systemMonitor" => "student-matrix",
            "accountManagement" => "staff-directory",
            "adminReports" => "documents",

            "studentManagement" => "student-matrix",
            "teacherManagement" => "staff-directory",
            "courseManagement" => "documents",
            "classManagement" => "schedule",
            "enrollment" => "documents",
            "tuitionReceipt" => "finance",
            "debtTracking" => "finance",

            "teachingClasses" => "schedule",
            "classStudentList" => "student-matrix",
            "attendance" => "schedule",
            "scoreEntry" => "documents",
            _ => "access-control"
        };
    }

    private static void TryApplySidebarIcon(Panel target, string iconKey)
    {
        var iconPath = ResolveSidebarIconPath(iconKey);
        if (iconPath is null)
        {
            return;
        }

        try
        {
            using var source = Image.FromFile(iconPath);
            target.BackgroundImage = new Bitmap(source);
            target.BackColor = Color.Transparent;
        }
        catch
        {
            target.BackgroundImage = null;
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
