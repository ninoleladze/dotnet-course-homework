using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.EF.Entities;

[Table("currency_code")]
public class CurrencyCode
{
    [Key]
    [Column("currency_code_id")]
    public int Id { get; set; }

    [Column("currency_code")]
    public string CurrenciesCode { get; set; }

    public Collection<BankAccount> BankAccounts { get; set; }
}
