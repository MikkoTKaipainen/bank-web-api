using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;

namespace BankWepApi.Repositories
{
    public interface ITransactionRepository
    {
        Transaction CreateTransaction(Transaction transaction);
        List<Transaction> ReadTransactions();
        Transaction ReadTransaction(int id);
        List<Transaction> ReadTransactions(DateTime startDate, DateTime endDate);
    }
}
