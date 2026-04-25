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
        if (form.MinimumSize == Size.Empty)
        {
            form.MinimumSize = new Size(900, 620);
        }

        EnableAdaptiveScrolling(form);
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

        EnableAdaptiveScrolling(form);
        EnableOptimizedRendering(form);
    }

    public static void OpenChildForm(Panel hostPanel, Form childForm)
    {
        LogUi($"OpenChildForm:start:{childForm.GetType().Name}");
        hostPanel.AutoScroll = true;
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
            EnableAdaptiveScrolling(childForm);
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

    public static void EnableAdaptiveScrolling(Form form)
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || form.IsDisposed)
        {
            return;
        }

        form.AutoScroll = true;
        form.Layout -= HandleAdaptiveScrollLayout;
        form.Layout += HandleAdaptiveScrollLayout;
        form.Resize -= HandleAdaptiveScrollResize;
        form.Resize += HandleAdaptiveScrollResize;

        UpdateAdaptiveScrollRange(form);
    }

    private static void HandleAdaptiveScrollLayout(object? sender, LayoutEventArgs _) 
    {
        if (sender is Form form)
        {
            UpdateAdaptiveScrollRange(form);
        }
    }

    private static void HandleAdaptiveScrollResize(object? sender, EventArgs _)
    {
        if (sender is Form form)
        {
            UpdateAdaptiveScrollRange(form);
        }
    }

    private static void UpdateAdaptiveScrollRange(Form form)
    {
        if (form.IsDisposed || !form.IsHandleCreated)
        {
            return;
        }

        var contentBounds = GetContentBounds(form.Controls);
        var minWidth = Math.Max(form.ClientSize.Width, contentBounds.Right + form.Padding.Right + 12);
        var minHeight = Math.Max(form.ClientSize.Height, contentBounds.Bottom + form.Padding.Bottom + 12);

        form.AutoScrollMinSize = new Size(minWidth, minHeight);
    }

    private static Rectangle GetContentBounds(Control.ControlCollection controls)
    {
        var right = 0;
        var bottom = 0;

        foreach (Control control in controls)
        {
            if (!control.Visible)
            {
                continue;
            }

            right = Math.Max(right, control.Right + control.Margin.Right);
            bottom = Math.Max(bottom, control.Bottom + control.Margin.Bottom);
        }

        return new Rectangle(0, 0, right, bottom);
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
