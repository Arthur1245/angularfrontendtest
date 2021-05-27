using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.Services.Interfaces
{
    public interface IFilmService
    {
        Task<Film> AddFilmAsync(Film addFilm);
        Task<Film> DeleteFilmAsync(int id);
        Task<Film> GetFilmAsync(int id);
        Task<IEnumerable> GetFilmAsync();
        Task<Film> UpdateFilmAsync(Film updateFilm);
    }
}
