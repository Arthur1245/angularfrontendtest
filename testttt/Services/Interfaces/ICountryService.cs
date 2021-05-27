using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.Services
{
    public interface ICountryService
    {
        Task<Country> AddCountryAsync(Country addCountry);
        Task<Country> DeleteCountryAsync(int id);
        Task<Country> GetCountryAsync(int id);
        Task<IEnumerable> GetCountryAsync();
        Task<Country> UpdateCountryAsync(Country updateCountry);
    }
}
