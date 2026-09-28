using BankSystem.Services.Helpers;
using BankSystem.Services.Models.Accounts;

namespace BankSystem.Services.Models;

/// <summary>
/// Represents a bank account owner.
/// </summary>
public class AccountOwner
{
    private readonly List<BankAccount> accounts = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="AccountOwner"/> class.
    /// </summary>
    /// <param name="firstName">The first name of the account owner.</param>
    /// <param name="lastName">The last name of the account owner.</param>
    /// <param name="email">The email address of the account owner.</param>
    public AccountOwner(string firstName, string lastName, string email)
    {
        VerifyString(firstName, nameof(firstName));
        VerifyString(lastName, nameof(lastName));

        if (!email.IsEmailValid())
        {
            throw new ArgumentException("The email address is not valid.", nameof(email));
        }

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
    }

    /// <summary>
    /// Gets the account owner's first name.
    /// </summary>
    public string FirstName { get; }

    /// <summary>
    /// Gets the account owner's last name.
    /// </summary>
    public string LastName { get; }

    /// <summary>
    /// Gets the account owner's email address.
    /// </summary>
    public string Email { get; }

    /// <inheritdoc/>
    public override string ToString() => $"{this.FirstName} {this.LastName}, {this.Email}.";

    /// <summary>
    /// Adds a new bank account to the list of accounts owned by the account owner.
    /// </summary>
    /// <param name="account">The bank account to add.</param>
    public void Add(BankAccount account)
    {
        ArgumentNullException.ThrowIfNull(account);
        this.accounts.Add(account);
    }

    /// <summary>
    /// Returns the list of bank accounts associated with the account owner.
    /// </summary>
    /// <returns>A list of <see cref="BankAccount"/> instances.</returns>
    public IReadOnlyList<BankAccount> Accounts() => this.accounts;

    private static void VerifyString(string value, string paramName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null or empty.", paramName);
        }
    }
}
