using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;
using BankWepApi.Repositories;
//using BankWepApi.Utilities;


namespace BankWepApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;


        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //CREATE
        public Customer CreateCustomer(Customer customer)
        {
            //customer.Psw = PswHash.HashPassword(customer.Psw, "salt");
            return _customerRepository.CreateCustomer(customer);
        }
        //DELETE
        public void DeleteCustomer(int id)
        {
            
             _customerRepository.DeleteCustomer(id);    
        }
        //READ BY NAME //PITÄSKÖ LISÄTÄ FIRSTNAME LASTNAME?
        public List<Customer> ReadCustomer(string name)
        {
            return _customerRepository.ReadCustomer(name);
        }
        //READ BY ID
        public Customer ReadCustomer(int id)
        {
            return _customerRepository.ReadCustomer(id);
        }
        //READ
        public List<Customer> ReadCustomers()
        {
            return _customerRepository.ReadCustomers();
        }
        //UPDATE
        public Customer UpdateCustomer(Customer customer, int id)
        {
            var updateCustomer = _customerRepository.ReadCustomer(id);
            if (updateCustomer == null)
                throw new Exception("Customer not found");
            //customer.Psw = PswHash.HashPassword(customer.Psw, "salt");
            return _customerRepository.UpdateCustomer(customer);
        }
    }
}
