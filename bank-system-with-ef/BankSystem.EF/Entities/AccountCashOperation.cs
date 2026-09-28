using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.EF.Entities;

[Table("account_cash_operation")]
public class AccountCashOperation
{
    [Key]
    [Column("account_cash_operation_id")]
    public int Id { get; set; }

    [Column("bank_account_id")]
    [ForeignKey("BankAccount")]
    public int BankAccountId { get; set; }

    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("operation_date_time")]
    public string OperationDateTime { get; set; }

    [Column("note")]
    public string Note { get; set; }

    public BankAccount BankAccount { get; set; }
}

