using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.Services
{
    public interface IAddressService
    {
        Task<Address> AddAddressAsync(Address addAddress);
        Task<Address> DeleteAddressAsync(int id);
        Task<Address> GetAddressAsync(int id);
        Task<IEnumerable> GetAddressAsync();
        Task<Address> UpdateAddressAsync(Address updateAddress);
    }
}
