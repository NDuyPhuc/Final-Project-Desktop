using TrungTamNgoaiNgu.Domain.Entities;

namespace TrungTamNgoaiNgu.Application.Repositories;

public interface IAccountRepository
{
    bool CanConnect();
    AccountEntity? FindActiveByUsername(string username);
    string GetNextId();
    IReadOnlyList<AccountEntity> GetAccounts();
    AccountEntity Save(AccountEntity account);
    void ToggleStatus(string accountId);
    void ResetPassword(string accountId, string passwordHash);
}
