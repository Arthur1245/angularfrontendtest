using Models;
using System.Collections;
using System.Threading.Tasks;

namespace StreamingService.Services
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomerAsync(Customer addCustomer);
        Task<Customer> DeleteCustomerAsync(int id);
        Task<Customer> GetCustomerAsync(int id);
        Task<IEnumerable> GetCustomersAsync();
        Task<Customer> UpdateCustomerAsync(Customer updateCustomer);
    }
}