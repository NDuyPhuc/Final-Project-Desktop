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
            ApplicationConfiguration.Initialize();

            ILanguageCenterDataService dataService = new SqlLanguageCenterDataService();
            if (!TryInitializeRuntime(dataService))
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

            Application.Run(new FrmLogin(dataService));
        }

        private static bool TryInitializeRuntime(ILanguageCenterDataService dataService)
        {
            try
            {
                AppRuntime.Initialize(dataService);
                return true;
            }
            catch (Exception exception)
            {
                ErrorLogger.Log(exception, "InitializeDatabase");

                var scriptPath = Path.Combine(AppPaths.GetWorkspaceRoot(), "docs", "database-script.sql");
                var settingsPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
                var message =
                    "Khong the khoi tao ket noi SQL Server.\n\n" +
                    $"1. Kiem tra chuoi ket noi trong: {settingsPath}\n" +
                    $"2. Chay script: {scriptPath}\n" +
                    "3. Neu can ghi de cau hinh, dat bien moi truong TTNN_SQL_CONNECTION_STRING va TTNN_SQL_PASSWORD roi mo lai app.\n\n" +
                    $"Chi tiet loi da duoc ghi tai:\n{AppPaths.LogFilePath}";

                MessageBox.Show(message, "Khoi tao database that bai", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static void HandleUnhandledException(Exception exception)
        {
            try
            {
                ErrorLogger.Log(exception, "UnhandledException");

                MessageBox.Show(
                    $"Ung dung vua gap loi va da ghi log tai:\n{AppPaths.LogFilePath}",
                    "Loi he thong",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show(
                    exception.ToString(),
                    "Loi he thong",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
