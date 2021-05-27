using Microsoft.EntityFrameworkCore;
using Models;
using StreamingService.Db;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly StreamingServiceDbContext _context;
        public CustomerService(StreamingServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable> GetCustomersAsync()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _context.Customer.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Customer> AddCustomerAsync(Customer addCustomer)
        {
            _context.Customer.Add(addCustomer);
            await _context.SaveChangesAsync();
            return addCustomer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer updateCustomer)
        {
            _context.Customer.Update(updateCustomer);
            await _context.SaveChangesAsync();
            return updateCustomer;
        }

        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            var CustomerToDelete = await _context.Customer.FirstOrDefaultAsync(customer => customer.Id == id);
            _context.Customer.Remove(CustomerToDelete);
            await _context.SaveChangesAsync();
            return CustomerToDelete;
        }
    }
}
