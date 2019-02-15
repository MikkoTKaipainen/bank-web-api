using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;

namespace BankWepApi.Services
{
    public interface ITransactionService
    {
        Transaction CreateTransaction(Transaction transaction);
        List<Transaction> ReadTransactions();
        List<Transaction> ReadTransactions(DateTime startdate, DateTime enddate);
        Transaction ReadTransaction(int id);
    }
}
