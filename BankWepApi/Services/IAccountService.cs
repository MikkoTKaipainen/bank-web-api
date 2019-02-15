using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;

namespace BankWepApi.Services
{
    public interface IAccountService
    {
        Account CreateAccount(Account account);
        List<Account> ReadAccounts();
        Account ReadAccount(long id);
        Account UpdateAccount(long id, Account account);
        Account UpdateBalance(long id, decimal amount);
        Account DeleteAccount(long id, Account account);
    }
}
