using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;
using BankWepApi.Repositories;

namespace BankWepApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountrepository;

        public AccountService(IAccountRepository accountrepository)
        {
            _accountrepository = accountrepository;
        }

        public Account CreateAccount(Account account)
        {
            return _accountrepository.CreateAccount(account);
        }

        public Account DeleteAccount(long id, Account account)
        {
            throw new NotImplementedException();
        }

        public Account ReadAccount(long id)
        {
            return _accountrepository.ReadAccount(id);
        }

        public List<Account> ReadAccounts()
        {
            return _accountrepository.ReadAccounts();
        }

        public Account UpdateAccount(long id, Account account)
        {
            var updatedAccount = _accountrepository.ReadAccount(id);
            if (updatedAccount == null)
                throw new Exception("Account not found");
            return _accountrepository.UpdateAccount(account);
        }
    }
}
