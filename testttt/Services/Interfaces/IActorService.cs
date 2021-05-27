using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.Services.Interfaces
{
    public interface IActorService
    {
        Task<Actor> GetActorAsync(int id);
        Task<IEnumerable> GetAllActorsAsync();
        Task<Actor> CreateActorAsync(Actor createActor);
        Task<Actor> UpdateActorAsync(Actor updateActor);
        Task<Actor> DeleteActorAsync(int id);
    }
}
