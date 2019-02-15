using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;

namespace BankWepApi.Repositories
{
    public interface IAccountRepository
    {
        Account CreateAccount(Account account);
        List<Account> ReadAccounts();
        Account ReadAccount(long id);
        Account UpdateAccount(Account account);
        Account DeleteAccount(long id, Account account);
        Account UpdateBalance(Account account);
    }
}
