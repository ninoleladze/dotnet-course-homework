using BankSystem.Services.Generators;

namespace BankSystem.Services.Models.Accounts;

/// <summary>
/// Represents a silver bank account.
/// </summary>
public class SilverAccount : BankAccount
{
    private const int SilverDepositCostPerPoint = 5;
    private const int SilverWithdrawCostPerPoint = 2;
    private const int SilverBalanceCostPerPoint = 100;

    /// <summary>
    /// Initializes a new instance of the <see cref="SilverAccount"/> class.
    /// </summary>
    /// <param name="owner">The owner of the account.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="uniqueNumberGenerator">An object generating unique account numbers.</param>
    public SilverAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator)
        : base(owner, currencyCode, uniqueNumberGenerator)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SilverAccount"/> class.
    /// </summary>
    /// <param name="owner">The owner of the account.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="numberGenerator">A delegate generating unique account numbers.</param>
    public SilverAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator)
        : base(owner, currencyCode, numberGenerator)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SilverAccount"/> class.
    /// </summary>
    /// <param name="owner">The owner of the account.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="uniqueNumberGenerator">An object generating unique account numbers.</param>
    /// <param name="initialBalance">The initial deposit made upon creating the account.</param>
    public SilverAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator, decimal initialBalance)
        : base(owner, currencyCode, uniqueNumberGenerator, initialBalance)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SilverAccount"/> class.
    /// </summary>
    /// <param name="owner">The owner of the account.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="numberGenerator">A delegate generating unique account numbers.</param>
    /// <param name="initialBalance">The initial deposit made upon creating the account.</param>
    public SilverAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator, decimal initialBalance)
        : base(owner, currencyCode, numberGenerator, initialBalance)
    {
    }

    /// <inheritdoc/>
    public override decimal Overdraft => 2 * this.BonusPoints;

    /// <inheritdoc/>
    protected override int CalculateDepositRewardPoints(decimal amount) =>
        Math.Max((int)Math.Floor((this.Balance / SilverBalanceCostPerPoint) + (amount / SilverDepositCostPerPoint)), 0);

    /// <inheritdoc/>
    protected override int CalculateWithdrawRewardPoints(decimal amount) =>
        Math.Max((int)Math.Floor((this.Balance / SilverBalanceCostPerPoint) + (amount / SilverWithdrawCostPerPoint)), 0);
}
