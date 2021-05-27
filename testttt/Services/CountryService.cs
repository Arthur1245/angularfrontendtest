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
    public class CountryService : ICountryService
    {
        private readonly StreamingServiceDbContext _context;
        public CountryService(StreamingServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable> GetCountryAsync()
        {
            return await _context.Country.ToListAsync();
        }

        public async Task<Country> GetCountryAsync(int id)
        {
            return await _context.Country.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Country> AddCountryAsync(Country addCountry)
        {
            _context.Country.Add(addCountry);
            await _context.SaveChangesAsync();
            return addCountry;
        }

        public async Task<Country> UpdateCountryAsync(Country updateCountry)
        {
            _context.Country.Update(updateCountry);
            await _context.SaveChangesAsync();
            return updateCountry;
        }

        public async Task<Country> DeleteCountryAsync(int id)
        {
            var CountryToDelete = await _context.Country.FirstOrDefaultAsync(country => country.Id == id);
            _context.Country.Remove(CountryToDelete);
            await _context.SaveChangesAsync();
            return CountryToDelete;
        }
    }
}
