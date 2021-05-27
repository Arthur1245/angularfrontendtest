using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.DTO
{
    public class AddressDTO 
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
