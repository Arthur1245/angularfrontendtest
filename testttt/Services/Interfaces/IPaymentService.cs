using Models;
using System.Collections;
using System.Threading.Tasks;

namespace StreamingService.Services
{
    public interface IPaymentService
    {
        Task<Payment> AddPaymentAsync(Payment addPayment);
        Task<Payment> DeletePaymentAsync(int id);
        Task<Payment> GetPaymentAsync(int id);
        Task<IEnumerable> GetPaymentsAsync();
        Task<Payment> UpdatePaymentAsync(Payment updatePayment);
    }
}