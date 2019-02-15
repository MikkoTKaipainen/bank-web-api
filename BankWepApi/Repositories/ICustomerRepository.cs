using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;

namespace BankWepApi.Repositories
{
    public interface ICustomerRepository
    {
        Customer CreateCustomer(Customer customer);
        List<Customer> ReadCustomers();
        List<Customer> ReadCustomer(string name);
        Customer ReadCustomer(int id);
        Customer UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
