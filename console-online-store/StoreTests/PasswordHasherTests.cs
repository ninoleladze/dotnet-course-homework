namespace StoreTests;

using StoreDAL.Security;

/// <summary>
/// Verifies <see cref="PasswordHasher"/> correctly hashes and verifies passwords without ever
/// storing them as plain text.
/// </summary>
public class PasswordHasherTests
{
    [Fact]
    public void Hash_NeverReturnsThePlainTextPassword()
    {
        var hash = PasswordHasher.Hash("secret123");

        Assert.NotEqual("secret123", hash);
    }

    [Fact]
    public void Hash_IsDeterministic()
    {
        var first = PasswordHasher.Hash("secret123");
        var second = PasswordHasher.Hash("secret123");

        Assert.Equal(first, second);
    }

    [Fact]
    public void Hash_DifferentPasswordsProduceDifferentHashes()
    {
        var first = PasswordHasher.Hash("secret123");
        var second = PasswordHasher.Hash("secret124");

        Assert.NotEqual(first, second);
    }

    [Fact]
    public void Verify_ReturnsTrueForTheCorrectPassword()
    {
        var hash = PasswordHasher.Hash("secret123");

        Assert.True(PasswordHasher.Verify("secret123", hash));
    }

    [Fact]
    public void Verify_ReturnsFalseForTheWrongPassword()
    {
        var hash = PasswordHasher.Hash("secret123");

        Assert.False(PasswordHasher.Verify("not-the-password", hash));
    }

    [Fact]
    public void Verify_WorksForABlankPassword()
    {
        var hash = PasswordHasher.Hash(string.Empty);

        Assert.True(PasswordHasher.Verify(string.Empty, hash));
    }
}
