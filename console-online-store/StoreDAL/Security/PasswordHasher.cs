namespace StoreDAL.Security;
using System;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Provides one-way password hashing so plain-text passwords are never persisted in the database.
/// </summary>
public static class PasswordHasher
{
    /// <summary>
    /// Computes a SHA-256 hash of the given password and returns it as a lowercase hex string.
    /// </summary>
    /// <param name="password">The plain-text password to hash.</param>
    /// <returns>The hex-encoded SHA-256 hash of <paramref name="password"/>.</returns>
    public static string Hash(string password)
    {
        ArgumentNullException.ThrowIfNull(password);
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = SHA256.HashData(bytes);
        return Convert.ToHexString(hash).ToUpperInvariant();
    }

    /// <summary>
    /// Checks whether the given plain-text password matches a previously computed hash.
    /// </summary>
    /// <param name="password">The plain-text password to verify.</param>
    /// <param name="passwordHash">The stored hash to compare against.</param>
    /// <returns><see langword="true"/> if the password matches the hash; otherwise <see langword="false"/>.</returns>
    public static bool Verify(string password, string passwordHash)
    {
        ArgumentNullException.ThrowIfNull(password);
        ArgumentNullException.ThrowIfNull(passwordHash);
        return string.Equals(Hash(password), passwordHash, StringComparison.OrdinalIgnoreCase);
    }
}
