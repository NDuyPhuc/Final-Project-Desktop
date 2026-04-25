using System.Security.Cryptography;
using System.Text;

namespace TrungTamNgoaiNgu.Application.Security;

public static class PasswordHasher
{
    public static string Hash(string plainTextPassword)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(plainTextPassword);

        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(plainTextPassword));
        return Convert.ToHexString(hash);
    }

    public static bool Verify(string plainTextPassword, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(plainTextPassword) || string.IsNullOrWhiteSpace(passwordHash))
        {
            return false;
        }

        return string.Equals(
            Hash(plainTextPassword),
            passwordHash.Trim(),
            StringComparison.OrdinalIgnoreCase);
    }
}
