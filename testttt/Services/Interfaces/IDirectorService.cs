using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.Services.Interfaces
{
    public interface IDirectorService
    {
        Task<Director> AddDirectorAsync(Director addDirector);
        Task<Director> DeleteDirectorAsync(int id);
        Task<Director> GetDirectorAsync(int id);
        Task<IEnumerable> GetDirectorAsync();
        Task<Director> UpdateDirectorAsync(Director updateDirector);
    }
}
