using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.Services
{
    public interface ICityService
    {
        Task<City> AddCityAsync(City addCity);
        Task<City> DeleteCityAsync(int id);
        Task<City> GetCityAsync(int id);
        Task<IEnumerable> GetCityAsync();
        Task<City> UpdateCityAsync(City updateCity);
    }
}
