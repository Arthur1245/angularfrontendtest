using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StreamingService.DTO;
using StreamingService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _ActorService;
        private readonly IMapper _mapper;
        public ActorController(IMapper mapper, IActorService actorService)
        {
            _ActorService = actorService;
            _mapper = mapper;
        }
        [HttpGet("GetActor")]
        public async Task<ActionResult<ActorDTO>> GetActor(int actorId)
        {
            var actor = await _ActorService.GetActorAsync(actorId);
            if (actor == null)
            {
                return NotFound();
            }
            return Ok(actor);
        }
        [HttpGet("GetAllActors")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetActors()
        {
            var actor = await _ActorService.GetAllActorsAsync();
            if (actor == null)
            {
                return NotFound();
            }
            var actorDTO = _mapper.Map<List<ActorDTO>>(actor);
            return Ok(actorDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ActorDTO>> CreateAdmin(ActorDTO actorDTO)
        {
            var actor = _mapper.Map<Actor>(actorDTO);
            await _ActorService.CreateActorAsync(actor);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<ActorDTO>> EditAdmin(ActorDTO actorDTO)
        {
            var actorToUpdate = _mapper.Map<Actor>(actorDTO);
            var updatedActor = await _ActorService.UpdateActorAsync(actorToUpdate);
            var actorDTOToReturn = _mapper.Map<ActorDTO>(updatedActor);
            return Ok(actorDTOToReturn);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteActor(int id)
        {
            await _ActorService.DeleteActorAsync(id);
            return Ok();
        }
    }
}
