using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;

namespace BankWepApi.Services
{
    public interface ICustomerService
    {
        Customer CreateCustomer(Customer customer);
        List<Customer> ReadCustomers();
        List<Customer> ReadCustomer(string name);
        Customer ReadCustomer(int id);
        Customer UpdateCustomer(Customer customer, int id);
        Customer DeleteCustomer(Customer customer, int id);
    }
}
