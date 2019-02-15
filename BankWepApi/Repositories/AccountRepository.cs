using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;

using Microsoft.EntityFrameworkCore;

namespace BankWepApi.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BackendbankdbContext _context;

        public AccountRepository(BackendbankdbContext _context)
        {
            this._context = _context;
        }

        public Account CreateAccount(Account account)
        {
            _context.Add(account);
            _context.SaveChanges();
            return account;
        }

        public List<Account> ReadAccounts()
        {
            return _context.Account.FromSql("Select * From Account").ToList();
        }

        public Account ReadAccount(long id)
        {
            //return _context.Account
            //    .AsNoTracking()
            //    .Include(p => p.Transaction)
            //    .FirstOrDefault(p => p.Id == id);
            return _context.Account
                .Where(a => a.Id == id)
                .Include(a => a.Transaction)
                .FirstOrDefault(a => a.Id == id);
        }

        public Account UpdateAccount(Account account)
        {
            _context.Update(account);
            _context.SaveChanges();
            return account;
        }

        public Account DeleteAccount(long id, Account account)
        {
            var deletedAccount = ReadAccount(id);
            _context.Account.Remove(deletedAccount);
            _context.SaveChanges();
            return account;
        }

        public Account UpdateBalance(Account account)
        {
            _context.Account.Update(account);
            _context.SaveChanges();
            return account;
        }
    }
}
