using BankSystem.Services.Generators;
using BankSystem.Services.Helpers;

namespace BankSystem.Services.Models.Accounts;

/// <summary>
/// Provides a way to work with bank accounts.
/// </summary>
public abstract class BankAccount
{
    private readonly List<AccountCashOperation> operations = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccount"/> class.
    /// </summary>
    /// <param name="owner">The owner of the bank account.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="uniqueNumberGenerator">An object generating unique account numbers.</param>
    protected BankAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator)
        : this(owner, currencyCode, WrapGenerator(uniqueNumberGenerator))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccount"/> class.
    /// </summary>
    /// <param name="owner">The owner of the bank account.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="numberGenerator">A delegate generating unique account numbers.</param>
    protected BankAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator)
    {
        ArgumentNullException.ThrowIfNull(owner);
        ArgumentNullException.ThrowIfNull(numberGenerator);

        if (!currencyCode.IsCurrencyValid())
        {
            throw new ArgumentException("The currency code is not valid.", nameof(currencyCode));
        }

        this.AccountOwner = owner;
        this.CurrencyCode = currencyCode;
        this.Number = numberGenerator();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccount"/> class.
    /// </summary>
    /// <param name="owner">The owner of the bank account.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="uniqueNumberGenerator">An object generating unique account numbers.</param>
    /// <param name="initialBalance">The initial deposit made upon creating the account.</param>
    protected BankAccount(AccountOwner owner, string currencyCode, IUniqueNumberGenerator uniqueNumberGenerator, decimal initialBalance)
        : this(owner, currencyCode, uniqueNumberGenerator)
    {
        this.Deposit(initialBalance, DateTime.Now, "Initial deposit");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BankAccount"/> class.
    /// </summary>
    /// <param name="owner">The owner of the bank account.</param>
    /// <param name="currencyCode">The ISO currency code.</param>
    /// <param name="numberGenerator">A delegate generating unique account numbers.</param>
    /// <param name="initialBalance">The initial deposit made upon creating the account.</param>
    protected BankAccount(AccountOwner owner, string currencyCode, Func<string> numberGenerator, decimal initialBalance)
        : this(owner, currencyCode, numberGenerator)
    {
        this.Deposit(initialBalance, DateTime.Now, "Initial deposit");
    }

    /// <summary>
    /// Gets the bank account number.
    /// </summary>
    public string Number { get; }

    /// <summary>
    /// Gets the balance of the account.
    /// </summary>
    public decimal Balance { get; private set; }

    /// <summary>
    /// Gets the ISO currency code for the account.
    /// </summary>
    public string CurrencyCode { get; }

    /// <summary>
    /// Gets the owner of the bank account.
    /// </summary>
    public AccountOwner AccountOwner { get; }

    /// <summary>
    /// Gets the bonus points associated with the account.
    /// </summary>
    public int BonusPoints { get; private set; }

    /// <summary>
    /// Gets the overdraft limit for the account.
    /// </summary>
    public abstract decimal Overdraft { get; }

    /// <summary>
    /// Returns all operations performed on the account.
    /// </summary>
    /// <returns>A read-only list of the operations performed on the account.</returns>
    /// <remarks>
    /// Kept as a method rather than a property (suppressing CA1024) because it is specified
    /// as a method by the task description and invoked with call syntax throughout the test suite.
    /// </remarks>
#pragma warning disable CA1024
    public IReadOnlyList<AccountCashOperation> GetAllOperations() => this.operations;
#pragma warning restore CA1024

    /// <summary>
    /// Deposits money to the account.
    /// </summary>
    /// <param name="amount">The amount to deposit.</param>
    /// <param name="date">The date and time of the deposit.</param>
    /// <param name="note">Additional details about the deposit.</param>
    public void Deposit(decimal amount, DateTime date, string note)
    {
        this.Balance += amount;
        this.BonusPoints += this.CalculateDepositRewardPoints(amount);
        this.operations.Add(new AccountCashOperation(amount, date, note));
    }

    /// <summary>
    /// Withdraws money from the account.
    /// </summary>
    /// <param name="amount">The amount to withdraw.</param>
    /// <param name="date">The date and time of the withdrawal.</param>
    /// <param name="note">Additional details about the withdrawal.</param>
    public void Withdraw(decimal amount, DateTime date, string note)
    {
        if (amount > this.Balance + this.Overdraft)
        {
            throw new InvalidOperationException("The withdrawal amount exceeds the available balance and overdraft.");
        }

        this.Balance -= amount;
        this.BonusPoints += this.CalculateWithdrawRewardPoints(amount);
        this.operations.Add(new AccountCashOperation(-amount, date, note));
    }

    /// <summary>
    /// Calculates the reward points earned upon a deposit.
    /// </summary>
    /// <param name="amount">The deposited amount.</param>
    /// <returns>The number of reward points earned.</returns>
    protected abstract int CalculateDepositRewardPoints(decimal amount);

    /// <summary>
    /// Calculates the reward points earned upon a withdrawal.
    /// </summary>
    /// <param name="amount">The withdrawn amount.</param>
    /// <returns>The number of reward points earned.</returns>
    protected abstract int CalculateWithdrawRewardPoints(decimal amount);

    private static Func<string> WrapGenerator(IUniqueNumberGenerator uniqueNumberGenerator)
    {
        ArgumentNullException.ThrowIfNull(uniqueNumberGenerator);
        return uniqueNumberGenerator.Generate;
    }
}
