using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;
using BankWepApi.Repositories;
using BankWepApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankWepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase

    {

        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerRepository customerRepository, ICustomerService customerService)
        {
            _customerRepository = customerRepository;
            _customerService = customerService;
        }

        // POST api/customer
        [HttpPost]
        public ActionResult<Customer> Post(Customer customer)
        {
            return _customerService.CreateCustomer(customer);
        }


        // GET api/customers
        [HttpGet]
        public ActionResult<List<Customer>> GetCustomers()
        {
            return new JsonResult(_customerService.ReadCustomers());
        }
        // GET api/customer by id
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            return new JsonResult(_customerService.ReadCustomer(id));
        }
        //// GET api/customer by name
        //[HttpGet("{firstname?}/{lastname?}")]
        //public ActionResult<List<Customer>> GetCustomer(string firstName, string lastName)
        //{
        //    return new JsonResult(_customerService.ReadCustomers(firstName, lastName));
        //}

        // PUT api/customers/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(Customer customer, int id)
        {
            return _customerService.UpdateCustomer(customer, id);
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _customerService.DeleteCustomer(id);
            return new NoContentResult();
        }

    }
}
