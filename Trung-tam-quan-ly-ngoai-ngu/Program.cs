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

            Application.Run(new FrmLogin(AppRuntime.DataService));
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
                AppRuntime.Initialize(new OfflineLanguageCenterDataService());

                var message =
                    "Khong the khoi tao ket noi SQL Server.\n\n" +
                    "Ung dung se chuyen sang che do offline demo de ban tiep tuc kiem tra giao dien.\n\n" +
                    "Tai khoan demo:\n" +
                    "- admin / 123456\n" +
                    "- staff / 123456\n" +
                    "- teacher / 123456\n\n" +
                    $"Chi tiet loi da duoc ghi tai:\n{AppPaths.LogFilePath}";

                MessageBox.Show(message, "Khoi tao database that bai", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
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
