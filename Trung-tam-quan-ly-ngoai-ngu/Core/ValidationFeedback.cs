namespace Trung_tam_quan_ly_ngoai_ngu;

internal static class ValidationFeedback
{
    public static void ShowFirstError(IWin32Window owner, ErrorProvider provider, params Control?[] controls)
    {
        foreach (var control in controls)
        {
            if (control is null || control.IsDisposed)
            {
                continue;
            }

            var message = provider.GetError(control);
            if (string.IsNullOrWhiteSpace(message))
            {
                continue;
            }

            MessageBox.Show(owner, message, "Kiểm tra lại thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            TryFocus(control);
            return;
        }
    }

    private static void TryFocus(Control control)
    {
        try
        {
            control.Focus();
        }
        catch
        {
        }
    }
}
