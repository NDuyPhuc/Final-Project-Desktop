using Microsoft.EntityFrameworkCore;
using TrungTamNgoaiNgu.Application.Data;
using TrungTamNgoaiNgu.Domain.Entities;
using TrungTamNgoaiNgu.Domain.Enums;

namespace TrungTamNgoaiNgu.Application.Repositories;

public sealed class SqlAccountRepository(DbContextOptions<LanguageCenterDbContext> options) : IAccountRepository
{
    public bool CanConnect()
    {
        using var context = CreateContext();
        return context.Database.CanConnect();
    }

    public AccountEntity? FindActiveByUsername(string username)
    {
        using var context = CreateContext();
        var normalizedUsername = username.Trim().ToLowerInvariant();
        return context.Accounts
            .AsNoTracking()
            .FirstOrDefault(account =>
                !account.IsDeleted &&
                account.Status == AccountStatus.Active &&
                account.Username.ToLower() == normalizedUsername);
    }

    public string GetNextId()
    {
        using var context = CreateContext();
        return GetNextCode(context.Accounts.Select(x => x.Id).ToList(), "ACC");
    }

    public IReadOnlyList<AccountEntity> GetAccounts()
    {
        using var context = CreateContext();
        return context.Accounts
            .AsNoTracking()
            .Where(account => !account.IsDeleted)
            .OrderBy(account => account.Role)
            .ThenBy(account => account.DisplayName)
            .ToList();
    }

    public AccountEntity Save(AccountEntity account)
    {
        using var context = CreateContext();
        var entity = context.Accounts.FirstOrDefault(x => x.Id == account.Id);
        if (entity is null)
        {
            entity = new AccountEntity
            {
                Id = string.IsNullOrWhiteSpace(account.Id) ? GetNextCode(context.Accounts.Select(x => x.Id).ToList(), "ACC") : account.Id,
                Username = account.Username.Trim(),
                PasswordHash = string.IsNullOrWhiteSpace(account.PasswordHash) ? account.PasswordHash : account.PasswordHash.Trim(),
                DisplayName = account.DisplayName.Trim(),
                Email = account.Email.Trim(),
                Phone = account.Phone.Trim(),
                Role = account.Role,
                Status = account.Status,
                IsDeleted = account.IsDeleted
            };

            context.Accounts.Add(entity);
        }
        else
        {
            entity.Username = account.Username.Trim();
            entity.DisplayName = account.DisplayName.Trim();
            entity.Email = account.Email.Trim();
            entity.Phone = account.Phone.Trim();
            entity.Role = account.Role;
            entity.Status = account.Status;
            entity.IsDeleted = account.IsDeleted;
            if (!string.IsNullOrWhiteSpace(account.PasswordHash))
            {
                entity.PasswordHash = account.PasswordHash.Trim();
            }
        }

        context.SaveChanges();
        return entity;
    }

    public void ToggleStatus(string accountId)
    {
        using var context = CreateContext();
        var entity = context.Accounts.FirstOrDefault(x => x.Id == accountId && !x.IsDeleted)
                     ?? throw new InvalidOperationException("Tai khoan khong ton tai.");

        entity.Status = entity.Status == AccountStatus.Active ? AccountStatus.Locked : AccountStatus.Active;
        context.SaveChanges();
    }

    public void ResetPassword(string accountId, string passwordHash)
    {
        using var context = CreateContext();
        var entity = context.Accounts.FirstOrDefault(x => x.Id == accountId && !x.IsDeleted)
                     ?? throw new InvalidOperationException("Tai khoan khong ton tai.");

        entity.PasswordHash = passwordHash;
        context.SaveChanges();
    }

    private LanguageCenterDbContext CreateContext()
    {
        return new LanguageCenterDbContext(options);
    }

    private static string GetNextCode(IEnumerable<string> existingIds, string prefix)
    {
        var nextNumber = existingIds
            .Where(id => id.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            .Select(id => new string(id.Skip(prefix.Length).Where(char.IsDigit).ToArray()))
            .Where(value => int.TryParse(value, out _))
            .Select(int.Parse)
            .DefaultIfEmpty(0)
            .Max() + 1;

        return $"{prefix}{nextNumber:000}";
    }
}
