using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.DTO
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int TotalPrice { get; set; }
        public DateTime PaymentDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int RentalId { get; set; }
        public Rental Rental { get; set; }
        public string PaymentOption { get; set; }
    }
}
