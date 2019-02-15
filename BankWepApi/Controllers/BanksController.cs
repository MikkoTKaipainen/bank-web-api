using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankWepApi.Models;
using BankWepApi.Repositories;
using BankWepApi.Services;

namespace BankWepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BanksController(IBankService bankRepository)
        {
            _bankService = bankRepository;
        }

      
        // GET: api/Banks
        [HttpGet]
        public ActionResult<List<Bank>> GetBanks()
        {
            return new JsonResult(_bankService.ReadBanks());
        }

        // GET: api/Banks/5
        [HttpGet("{id}")]
        public ActionResult<Bank> Get(int id)
        {
            var bank = _bankService.ReadBank(id);
            return new JsonResult(bank);
        }

        [HttpGet("{name}")]
        public ActionResult<Bank> Get(string name)
        {
            var bank = _bankService.ReadBank(name);
            return new JsonResult(bank);
        }

        // PUT: api/Banks/5
        [HttpPut]
        public ActionResult<Bank> Put(Bank bank, int id)
        {
            return new JsonResult(_bankService.UpdateBank(bank, id));
        }

        // POST: api/Banks
        [HttpPost]
        public ActionResult<Bank> Post(Bank bank)
        {
            return new JsonResult(_bankService.CreateBank(bank));
        }

        // DELETE: api/Banks/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return new JsonResult(_bankService.DeleteBank(id));
        }
              
    }
}
