using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Repositories;
using BankWepApi.Services;
using BankWepApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankWepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController
    {

        private readonly IAccountRepository _accountRepository;
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult<List<Account>> ListAllAccounts()
        {
            var accounts = _accountService.ReadAccounts();
            return new JsonResult(accounts);
        }

        [HttpGet("{Id}")]
        public ActionResult<Account> Get(long id)
        {
            var accounts = _accountService.ReadAccount(id);
            return new JsonResult(accounts);
        }

        [HttpPost]
        public ActionResult<Account> Post(Account account)
        {
            var newAccount = _accountService.CreateAccount(account);
            return new JsonResult(newAccount);
        }

        [HttpPut("{Id}")]
        public ActionResult<Account> Put(long id, Account account)
        {
            var updatedAccount = _accountService.UpdateAccount(id, account);
            return updatedAccount;
        }
    }
}
