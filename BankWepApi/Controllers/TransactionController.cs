using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankWepApi.Models;
using BankWepApi.Services;

namespace BankWepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;

        public TransactionController(ITransactionService transactionService, IAccountService accountService)
        {
            _transactionService = transactionService;
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult<List<Transaction>> ReadTransactions()
        {
            return new JsonResult(_transactionService.ReadTransactions());
        }

        [HttpGet("{id}")]
        public ActionResult<Transaction> ReadTransaction(int id)
        {
            return new JsonResult(_transactionService.ReadTransaction(id));
        }

        [HttpGet("transactions/{startDate}/{endDate?}")]
        public ActionResult<List<Transaction>> ReadTransactionByDate(DateTime startDate, DateTime endDate)
        {
            return new JsonResult(_transactionService.ReadTransactions(startDate, endDate));
        }

        [HttpPost]
        public ActionResult<Transaction> CreateTransaction(Transaction transaction)
        {
            _transactionService.CreateTransaction(transaction);
            return new JsonResult(_accountService.UpdateBalance(transaction.AccountId, transaction.Amount));
        }
    }
}