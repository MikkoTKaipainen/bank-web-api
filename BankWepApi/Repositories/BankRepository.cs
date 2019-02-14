using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;

namespace BankWepApi.Repositories
{
    public class BankRepository : IBankRepository
    {

        private readonly BackendbankdbContext _context;

        public BankRepository(BackendbankdbContext context)
        {
            _context = context;
        }
        public Bank CreateBank(Bank bank)
        {
            _context.Add(bank);
            _context.SaveChanges();
            return bank;
        }

        public Bank DeleteBank(Bank bank)
        {
            var deletedBank = ReadBank(id);
            _context.Bank.Remove(deletedBank);
            _context.SaveChanges();
            return bank;
        }

        public Bank ReadBank(int id)
        {
            return _context.Bank
                .Where(b => b.Id == id)
                .FirstOrDefault(b => b.Id == id);
        }

        public List<Bank> ReadBank(string name)
        {
            throw new NotImplementedException();
        }

        public List<Bank> ReadBanks()
        {
            return _context.Bank
                .ToList();
        }

        public Bank UpdateBank(Bank bank)
        {
            _context.Update(bank);
            _context.SaveChanges();
            return bank;
        }
    }
}
