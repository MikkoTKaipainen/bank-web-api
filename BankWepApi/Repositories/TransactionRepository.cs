using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;

namespace BankWepApi.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BackendbankdbContext _context;

        public TransactionRepository(BackendbankdbContext context)
        {
            _context = context;
        }

        public Transaction CreateTransaction(Transaction transaction)
        {
            _context.Add(transaction);
            _context.SaveChanges();
            return transaction;
        }

        public List<Transaction> ReadTransactions()
        {
            return _context.Transaction
                .ToList();
        }

        public Transaction ReadTransaction(int id)
        {
            return _context.Transaction
                .Where(t => t.Id == id)
                .FirstOrDefault(t => t.Id == id);
        }

        public List<Transaction> ReadTransactions(DateTime startDate, DateTime endDate)
        {
            return _context.Transaction
                .Where(t => t.TimeStamp >= startDate && t.TimeStamp <= endDate)
                .ToList();
        }
    }
}