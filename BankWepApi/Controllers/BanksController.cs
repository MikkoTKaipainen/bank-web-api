using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankWepApi.Models;
using BankWepApi.Repositories;

namespace BankWepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly IBankRepository _bankRepository;

        public BanksController(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

      
        // GET: api/Banks
        [HttpGet]
        public ActionResult<List<Bank>> GetBanks()
        {
            return new JsonResult(_bankRepository.Read());
        }

        // GET: api/Banks/5
        [HttpGet("{id}")]
        public ActionResult<Bank> Get(int id)
        {
            var bank = _bankRepository.Read(id);
            return new JsonResult();
        }

        // PUT: api/Banks/5
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // POST: api/Banks
        [HttpPost]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Banks/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
              
    }
}
