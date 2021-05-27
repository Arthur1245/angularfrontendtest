using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Address
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
