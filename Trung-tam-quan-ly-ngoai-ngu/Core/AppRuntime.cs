using TrungTamNgoaiNgu.Application.Contracts;
using TrungTamNgoaiNgu.Application.Services;
using TrungTamNgoaiNgu.Domain.Entities;

namespace Trung_tam_quan_ly_ngoai_ngu;

internal static class AppRuntime
{
    private static ILanguageCenterDataService? _dataService;

    public static ILanguageCenterDataService DataService =>
        _dataService ?? throw new InvalidOperationException("Application services have not been initialized.");

    public static AccountEntity? CurrentUser { get; private set; }

    public static void Initialize(ILanguageCenterDataService? dataService = null)
    {
        _dataService = dataService ?? new SqlLanguageCenterDataService();
        _dataService.EnsureDatabaseReady();
    }

    public static void SetCurrentUser(AccountEntity? account)
    {
        CurrentUser = account;
    }
}
