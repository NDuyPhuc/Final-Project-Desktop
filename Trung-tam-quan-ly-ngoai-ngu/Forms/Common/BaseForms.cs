namespace Trung_tam_quan_ly_ngoai_ngu;

using System.ComponentModel;
using System.Reflection;

public static class FormHostHelpers
{
    private static readonly PropertyInfo? DoubleBufferedProperty =
        typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
    private static readonly object UiLogLock = new();

    public static void ConfigureModuleSurface(Form form, string title)
    {
        form.Text = title;
        form.BackColor = AppTheme.Background;
        form.Font = AppTheme.FontBody;
        form.AutoScroll = true;
        form.AutoScaleMode = AutoScaleMode.Dpi;
        EnableOptimizedRendering(form);
    }

    public static void ConfigureShellSurface(Form form, string title)
    {
        form.Text = title;
        form.BackColor = AppTheme.Background;
        form.Font = AppTheme.FontBody;
        form.StartPosition = FormStartPosition.CenterScreen;
        form.AutoScaleMode = AutoScaleMode.Dpi;
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
        {
            form.WindowState = FormWindowState.Normal;
        }
        else
        {
            form.WindowState = FormWindowState.Maximized;
            form.MinimumSize = new Size(1024, 700);
        }

        EnableOptimizedRendering(form);
    }

    public static void OpenChildForm(Panel hostPanel, Form childForm)
    {
        LogUi($"OpenChildForm:start:{childForm.GetType().Name}");
        hostPanel.SuspendLayout();
        try
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
            LogUi($"OpenChildForm:shown:{childForm.GetType().Name}");
        }
        catch (Exception exception)
        {
            LogUi($"OpenChildForm:error:{childForm.GetType().Name}:{exception}");
            throw;
        }
        finally
        {
            hostPanel.ResumeLayout(true);
        }
    }

    public static void OpenLoginAndClose(Form currentForm)
    {
        currentForm.Hide();
        AppRuntime.SetCurrentUser(null);
        using var login = new FrmLogin(AppRuntime.DataService);
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

    public static void ApplyResponsiveSplit(SplitContainer splitContainer, Orientation targetOrientation, int desiredDistance)
    {
        EnsureSafeSplitOrientation(splitContainer, targetOrientation);
        ApplySafeSplitterDistance(splitContainer, desiredDistance);
    }

    public static void EnsureSafeSplitOrientation(SplitContainer splitContainer, Orientation targetOrientation)
    {
        if (splitContainer.IsDisposed || splitContainer.Orientation == targetOrientation)
        {
            return;
        }

        var panel1MinSize = splitContainer.Panel1MinSize;
        var panel2MinSize = splitContainer.Panel2MinSize;

        splitContainer.SuspendLayout();
        try
        {
            splitContainer.Panel1MinSize = 0;
            splitContainer.Panel2MinSize = 0;

            if (GetSplitAxisLength(splitContainer, splitContainer.Orientation) > splitContainer.SplitterWidth)
            {
                splitContainer.SplitterDistance = 0;
            }

            splitContainer.Orientation = targetOrientation;
        }
        finally
        {
            splitContainer.Panel1MinSize = panel1MinSize;
            splitContainer.Panel2MinSize = panel2MinSize;
            splitContainer.ResumeLayout(true);
        }
    }

    public static void ApplySafeSplitterDistance(SplitContainer splitContainer, int desiredDistance)
    {
        if (splitContainer.IsDisposed)
        {
            return;
        }

        var axisLength = GetSplitAxisLength(splitContainer, splitContainer.Orientation);
        if (axisLength <= 0)
        {
            return;
        }

        var minimum = splitContainer.Panel1MinSize;
        var maximum = axisLength - splitContainer.Panel2MinSize - splitContainer.SplitterWidth;

        if (maximum < minimum)
        {
            return;
        }

        splitContainer.SplitterDistance = Math.Clamp(desiredDistance, minimum, maximum);
    }

    public static void LogUi(string message)
    {
        try
        {
            var logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            Directory.CreateDirectory(logDirectory);
            var logPath = Path.Combine(logDirectory, "ui-trace.log");
            var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} | {message}{Environment.NewLine}";

            lock (UiLogLock)
            {
                File.AppendAllText(logPath, line);
            }
        }
        catch
        {
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

    private static int GetSplitAxisLength(SplitContainer splitContainer, Orientation orientation)
    {
        return orientation == Orientation.Horizontal
            ? splitContainer.ClientSize.Height
            : splitContainer.ClientSize.Width;
    }
}
