using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Payment
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
