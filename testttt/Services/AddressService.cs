using Microsoft.EntityFrameworkCore;
using Models;
using StreamingService.Db;
using StreamingService.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.Services
{
    public class AddressService : IAddressService
    {
        private readonly StreamingServiceDbContext _context;
        public AddressService(StreamingServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable> GetAddressAsync()
        {
            return await _context.Address.ToListAsync();
        }

        public async Task<Address> GetAddressAsync(int id)
        {
            return await _context.Address.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Address> AddAddressAsync(Address addAddress)
        {
            _context.Address.Add(addAddress);
            await _context.SaveChangesAsync();
            return addAddress;
        }

        public async Task<Address> UpdateAddressAsync(Address updateAddress)
        {
            _context.Address.Update(updateAddress);
            await _context.SaveChangesAsync();
            return updateAddress;
        }

        public async Task<Address> DeleteAddressAsync(int id)
        {
            var AddressToDelete = await _context.Address.FirstOrDefaultAsync(address => address.Id == id);
            _context.Address.Remove(AddressToDelete);
            await _context.SaveChangesAsync();
            return AddressToDelete;
        }
    }
}
