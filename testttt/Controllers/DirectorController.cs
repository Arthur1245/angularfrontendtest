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
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _directorService;
        private readonly IMapper _mapper;

        public DirectorController(IDirectorService directorService, IMapper mapper)
        {
            _directorService = directorService;
            _mapper = mapper;
        }

        [HttpGet("GetAllDirectors")]
        public async Task<ActionResult<IEnumerable<DirectorDTO>>> GetDirectors()
        {
            var director = await _directorService.GetDirectorAsync();
            if (director == null)
            {
                return NotFound();
            }
            var directorDTO = _mapper.Map<List<DirectorDTO>>(director);
            return Ok(directorDTO);
        }

        [HttpGet("OneDirector")]
        public async Task<ActionResult<DirectorDTO>> GetDirector(int directorId)
        {
            var director = await _directorService.GetDirectorAsync(directorId);
            if (director == null)
            {
                return NotFound();
            }
            return Ok(director);
        }

        [HttpPost]
        public async Task<ActionResult<DirectorDTO>> CreateDirector(DirectorDTO directorDTO)
        {
            var director = _mapper.Map<Director>(directorDTO);
            await _directorService.AddDirectorAsync(director);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<DirectorDTO>> EditDirecto(DirectorDTO directorDTO)
        {
            var directorToUpdate = _mapper.Map<Director>(directorDTO);
            var updatedDirector = await _directorService.UpdateDirectorAsync(directorToUpdate);
            var directorDTOTOReturn = _mapper.Map<DirectorDTO>(updatedDirector);
            return Ok(directorDTOTOReturn);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDirector(int id)
        {
            await _directorService.DeleteDirectorAsync(id);
            return Ok();
        }
    }
}
