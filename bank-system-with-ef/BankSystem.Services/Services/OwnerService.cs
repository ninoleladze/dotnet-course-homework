using BankSystem.EF.Entities;
using BankSystem.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Services.Services;

public class OwnerService : BaseService
{
    public OwnerService(BankContext context)
        : base(context)
    {
    }

    public IReadOnlyList<AccountOwnerTotalBalanceModel> GetAccountOwnersTotalBalance()
    {
        return this.Context.BankAccounts
            .GroupBy(ba => new
            {
                ba.AccountOwnerId,
                ba.AccountOwner.FirstName,
                ba.AccountOwner.LastName,
                CurrencyCode = ba.CurrencyCode.CurrenciesCode,
            })
            .Select(g => new AccountOwnerTotalBalanceModel
            {
                AccountOwnerId = g.Key.AccountOwnerId,
                FirstName = g.Key.FirstName,
                LastName = g.Key.LastName,
                CurrencyCode = g.Key.CurrencyCode,
                Total = (decimal)g.Sum(ba => (double)ba.Balance),
            })
            .AsEnumerable()
            .OrderByDescending(m => m.Total)
            .ToList();
    }
}
