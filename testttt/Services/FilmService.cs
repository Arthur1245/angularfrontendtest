using Microsoft.EntityFrameworkCore;
using Models;
using StreamingService.Db;
using StreamingService.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.Services
{
    public class FilmService : IFilmService
    {
        private readonly StreamingServiceDbContext _context;
        public FilmService(StreamingServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable> GetFilmAsync()
        {
            return await _context.Film.ToListAsync();
        }

        public async Task<Film> GetFilmAsync(int id)
        {
            return await _context.Film.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Film> AddFilmAsync(Film addFilm)
        {
            _context.Film.Add(addFilm);
            await _context.SaveChangesAsync();
            return addFilm;
        }

        public async Task<Film> UpdateFilmAsync(Film updateFilm)
        {
            _context.Film.Update(updateFilm);
            await _context.SaveChangesAsync();
            return updateFilm;
        }

        public async Task<Film> DeleteFilmAsync(int id)
        {
            var FilmToDelete = await _context.Film.FirstOrDefaultAsync(admin => admin.Id == id);
            _context.Film.Remove(FilmToDelete);
            await _context.SaveChangesAsync();
            return FilmToDelete;
        }
    }
}
