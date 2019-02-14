using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;
using BankWepApi.Repositories;

namespace BankWepApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Transaction CreateTransaction(Transaction transaction)
        {
            transaction.TimeStamp = DateTime.UtcNow;
            return _transactionRepository.CreateTransaction(transaction);
        }

        public Transaction ReadTransaction(int id)
        {
            return _transactionRepository.ReadTransaction(id);
        }

        public List<Transaction> ReadTransactions()
        {
            return _transactionRepository.ReadTransactions();
        }

        public List<Transaction> ReadTransactions(DateTime startDate, DateTime endDate)
        {
            // Check if endDate is set to something other than empty
            if (endDate == DateTime.MinValue)
            {
                endDate = DateTime.UtcNow;
            }
            return _transactionRepository.ReadTransactions(startDate, endDate);
        }
    }
}