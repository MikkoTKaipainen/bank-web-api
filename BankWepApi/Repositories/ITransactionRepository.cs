﻿using System;
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
        List<Transaction> ReadTransaction(DateTime startdate, DateTime enddate);
        Transaction ReadTransaction(int id);
    }
}
