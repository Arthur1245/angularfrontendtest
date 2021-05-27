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
    public class DirectorService : IDirectorService
    {
        private readonly StreamingServiceDbContext _context;
        public DirectorService(StreamingServiceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable> GetDirectorAsync()
        {
            return await _context.Director.ToListAsync();
        }

        public async Task<Director> GetDirectorAsync(int id)
        {
            return await _context.Director.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Director> AddDirectorAsync(Director addDirector)
        {
            _context.Director.Add(addDirector);
            await _context.SaveChangesAsync();
            return addDirector;
        }

        public async Task<Director> UpdateDirectorAsync(Director updateDirector)
        {
            _context.Director.Update(updateDirector);
            await _context.SaveChangesAsync();
            return updateDirector;
        }

        public async Task<Director> DeleteDirectorAsync(int id)
        {
            var DirectorToDelete = await _context.Director.FirstOrDefaultAsync(director => director.Id == id);
            _context.Director.Remove(DirectorToDelete);
            await _context.SaveChangesAsync();
            return DirectorToDelete;
        }
    }
}
