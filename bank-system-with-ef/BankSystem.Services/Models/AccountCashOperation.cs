using System.Globalization;

namespace BankSystem.Services.Models;

/// <summary>
/// Represents a bank account cash operation.
/// </summary>
public class AccountCashOperation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountCashOperation"/> class.
    /// </summary>
    /// <param name="amount">The amount the operation manipulates.</param>
    /// <param name="date">The date and time when the operation is done.</param>
    /// <param name="note">Additional details about the operation.</param>
    public AccountCashOperation(decimal amount, DateTime date, string note)
    {
        this.Amount = amount;
        this.Date = date;
        this.Note = note;
    }

    /// <summary>
    /// Gets the amount of the bank operation.
    /// </summary>
    public decimal Amount { get; }

    /// <summary>
    /// Gets the date and time of the bank operation.
    /// </summary>
    public DateTime Date { get; }

    /// <summary>
    /// Gets any notes associated with the bank operation.
    /// </summary>
    public string Note { get; }

    /// <inheritdoc/>
    public override string ToString()
    {
        var operationType = this.Amount >= 0 ? "Credited to account" : "Debited from account";
        return $"{this.Date.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture)} {this.Note} : {operationType} {this.Amount.ToString(CultureInfo.InvariantCulture)}.";
    }
}
