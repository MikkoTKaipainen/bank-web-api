using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;

namespace BankWepApi.Services
{
    public class TransactionService : ITransactionService
    {
        public Transaction CreateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> ReadTransaction(DateTime startdate, DateTime enddate)
        {
            throw new NotImplementedException();
        }

        public Transaction ReadTransaction(int id)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> ReadTransactions()
        {
            throw new NotImplementedException();
        }
    }
}
