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
    public class CityService : ICityService
    {
        private readonly StreamingServiceDbContext _context;
        public CityService(StreamingServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable> GetCityAsync()
        {
            return await _context.City.ToListAsync();
        }

        public async Task<City> GetCityAsync(int id)
        {
            return await _context.City.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<City> AddCityAsync(City addCity)
        {
            _context.City.Add(addCity);
            await _context.SaveChangesAsync();
            return addCity;
        }

        public async Task<City> UpdateCityAsync(City updateCity)
        {
            _context.City.Update(updateCity);
            await _context.SaveChangesAsync();
            return updateCity;
        }

        public async Task<City> DeleteCityAsync(int id)
        {
            var CityToDelete = await _context.City.FirstOrDefaultAsync(city => city.Id == id);
            _context.City.Remove(CityToDelete);
            await _context.SaveChangesAsync();
            return CityToDelete;
        }
    }
}
