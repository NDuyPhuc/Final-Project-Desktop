namespace Trung_tam_quan_ly_ngoai_ngu;

using System.ComponentModel;
using System.Reflection;

public static class FormHostHelpers
{
    private static readonly PropertyInfo? DoubleBufferedProperty =
        typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);

    public static void ConfigureModuleSurface(Form form, string title)
    {
        form.Text = title;
        form.BackColor = AppTheme.Background;
        form.Font = AppTheme.FontBody;
        form.AutoScroll = true;
        EnableOptimizedRendering(form);
    }

    public static void ConfigureShellSurface(Form form, string title)
    {
        form.Text = title;
        form.BackColor = AppTheme.Background;
        form.Font = AppTheme.FontBody;
        form.StartPosition = FormStartPosition.CenterScreen;
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        {
            form.WindowState = FormWindowState.Normal;
            form.AutoScaleMode = AutoScaleMode.None;
        }
        else
        {
            form.WindowState = FormWindowState.Maximized;
            form.MinimumSize = new Size(1280, 760);
        }

        EnableOptimizedRendering(form);
    }

    public static void OpenChildForm(Panel hostPanel, Form childForm)
    {
        for (var index = hostPanel.Controls.Count - 1; index >= 0; index--)
        {
            var control = hostPanel.Controls[index];
            if (control is Form oldForm)
            {
                oldForm.Close();
                oldForm.Dispose();
            }
            else
            {
                hostPanel.Controls.RemoveAt(index);
            }
        }

        hostPanel.Controls.Clear();
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;
        hostPanel.Controls.Add(childForm);
        EnableOptimizedRendering(childForm);
        childForm.Show();
    }

    public static void OpenLoginAndClose(Form currentForm)
    {
        currentForm.Hide();
        using var login = new FrmLogin();
        login.ShowDialog();
        currentForm.Close();
    }

    public static void SetActiveMenu(Button activeButton, params Button[] menuButtons)
    {
        foreach (var button in menuButtons)
        {
            if (button == activeButton)
            {
                button.BackColor = AppTheme.SidebarActive;
                button.ForeColor = AppTheme.Accent;
                button.Font = AppTheme.FontSidebarItemBold;
                button.FlatAppearance.BorderSize = 0;
            }
            else
            {
                button.BackColor = Color.Transparent;
                button.ForeColor = AppTheme.SidebarText;
                button.Font = AppTheme.FontSidebarItem;
                button.FlatAppearance.BorderSize = 0;
            }
        }
    }

    public static void EnableOptimizedRendering(Control control)
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        {
            return;
        }

        SetDoubleBuffered(control);

        foreach (Control child in control.Controls)
        {
            EnableOptimizedRendering(child);
        }

        if (control is SplitContainer splitContainer)
        {
            SetDoubleBuffered(splitContainer.Panel1);
            SetDoubleBuffered(splitContainer.Panel2);
        }
    }

    private static void SetDoubleBuffered(Control control)
    {
        try
        {
            DoubleBufferedProperty?.SetValue(control, true);
        }
        catch
        {
        }
    }
}
