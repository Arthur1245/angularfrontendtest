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
    public class ActorService : IActorService
    {
        private readonly StreamingServiceDbContext _context;
        public ActorService(StreamingServiceDbContext context)
        {
            _context = context;
        }

        public async Task<Actor> GetActorAsync(int id)
        {
            return await _context.Actor.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable> GetAllActorsAsync()
        {
            return await _context.Actor.ToListAsync();
        }
        public async Task<Actor> CreateActorAsync(Actor createActor)
        {
            _context.Actor.Add(createActor);
            await _context.SaveChangesAsync();
            return createActor;
        }
        public async Task<Actor> UpdateActorAsync(Actor updateActor)
        {
            _context.Actor.Update(updateActor);
            await _context.SaveChangesAsync();
            return updateActor;
        }
        public async Task<Actor> DeleteActorAsync(int id)
        {
            var ActorToDelete = await _context.Actor.FirstOrDefaultAsync(actor => actor.Id == id);
            _context.Actor.Remove(ActorToDelete);
            await _context.SaveChangesAsync();
            return ActorToDelete;
        }
    }
}
