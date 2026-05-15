using TrungTamNgoaiNgu.Application.Contracts;
using TrungTamNgoaiNgu.Application.Infrastructure;
using TrungTamNgoaiNgu.Application.Services;

namespace Trung_tam_quan_ly_ngoai_ngu
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        if (!TryInitializeRuntime())
        {
            return;
        }

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (_, args) => HandleUnhandledException(args.Exception);
            AppDomain.CurrentDomain.UnhandledException += (_, args) =>
            {
                if (args.ExceptionObject is Exception exception)
                {
                    HandleUnhandledException(exception);
                }
            };

        Application.Run(new FrmLogin(AppRuntime.DataService));
    }

    private static bool TryInitializeRuntime()
    {
        try
        {
            AppRuntime.Initialize(new SqlLanguageCenterDataService());
            return true;
        }
        catch (Exception exception)
        {
            ErrorLogger.Log(exception, "InitializeDatabase");
            AppRuntime.Initialize(new OfflineLanguageCenterDataService());

            var message =
                "Không khởi tạo được kết nối SQL Server.\n\n" +
                "Ứng dụng sẽ chuyển sang chế độ offline demo để bạn tiếp tục kiểm tra giao diện.\n\n" +
                "Tài khoản demo:\n" +
                "- admin / 123456\n" +
                "- staff / 123456\n" +
                "- teacher / 123456\n\n" +
                $"Chi tiết lỗi đã được ghi tại:\n{AppPaths.LogFilePath}";

            MessageBox.Show(message, "Khởi tạo database thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return true;
        }
    }

        private static void HandleUnhandledException(Exception exception)
        {
            try
            {
                ErrorLogger.Log(exception, "UnhandledException");

                MessageBox.Show(
                    $"Ứng dụng vừa gặp lỗi và đã ghi log tại:\n{AppPaths.LogFilePath}",
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show(
                    exception.ToString(),
                    "Lỗi hệ thống",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
