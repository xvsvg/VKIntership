using System.Security.Cryptography;

namespace VKIntership.Domain.Core.Tools;

public static class PasswordHasher
{
    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;
    private const int SaltSize = 16;
    private const int KeySize = 32;
    private const int Iterations = 10000;
    private const char SaltDelimeter = ';';

    public static string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            Algorithm,
            KeySize);

        return string.Join(SaltDelimeter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }

    public static bool CheckPassword(string passwordHash, string password)
    {
        var pw = passwordHash.Split(SaltDelimeter);
        var salt = Convert.FromBase64String(pw[0]);
        var hash = Convert.FromBase64String(pw[1]);

        var inputHash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            Algorithm,
            KeySize);

        return CryptographicOperations.FixedTimeEquals(hash, inputHash);
    }
}