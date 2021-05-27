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
    public class PaymentService : IPaymentService
    {
        private readonly StreamingServiceDbContext _context;
        public PaymentService(StreamingServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable> GetPaymentsAsync()
        {
            return await _context.Payment.ToListAsync();
        }

        public async Task<Payment> GetPaymentAsync(int id)
        {
            return await _context.Payment.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Payment> AddPaymentAsync(Payment addPayment)
        {
            _context.Payment.Add(addPayment);
            await _context.SaveChangesAsync();
            return addPayment;
        }

        public async Task<Payment> UpdatePaymentAsync(Payment updatePayment)
        {
            _context.Payment.Update(updatePayment);
            await _context.SaveChangesAsync();
            return updatePayment;
        }

        public async Task<Payment> DeletePaymentAsync(int id)
        {
            var PaymentToDelete = await _context.Payment.FirstOrDefaultAsync(payment => payment.Id == id);
            _context.Payment.Remove(PaymentToDelete);
            await _context.SaveChangesAsync();
            return PaymentToDelete;
        }
    }
}
