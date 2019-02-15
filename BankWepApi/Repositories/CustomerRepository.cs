using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankWepApi.Models;
using BankWepApi.Repositories;
using Microsoft.EntityFrameworkCore;



namespace BankWepApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    { 
        private readonly BackendbankdbContext _context;

        public CustomerRepository(BackendbankdbContext context)


         {
        _context = context;
         }
   
    //CREATE
        public Customer CreateCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
            return customer;
        }

    //DELETE
        public void DeleteCustomer(int id)
        {
            var customer = ReadCustomer(id);
            _context.Customer.Remove(customer);
            _context.SaveChanges();
            return;
        }
    //READ BY NAME
        public List<Customer> ReadCustomer(string name)
        {
            return _context.Customer

            .Include(a => a.Account)
            .ToList();
        }
    //READ BY ID
        public Customer ReadCustomer(int id)
        {
            return _context.Customer
               .AsNoTracking()
             .Include(a => a.Account)
             .FirstOrDefault(p => p.Id == id);
        }
    //READ
        public List<Customer> ReadCustomers()
        {
            return _context.Customer.FromSql("Select * From Customer").ToList();
            //return _context.Customer
            //    .Include(c => c.Bank)
            //    .Include(a => a.Account)
            //    .ToList();
        }
    //UPDATE
        public Customer UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();
            return customer;
        }
    }
    
}
