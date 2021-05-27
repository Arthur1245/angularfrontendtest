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
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;
        private readonly IMapper _mapper;

        public FilmController(IFilmService filmService, IMapper mapper)
        {
            _filmService = filmService;
            _mapper = mapper;
        }

        [HttpGet("AllFilm")]
        public async Task<ActionResult<IEnumerable<FilmDTO>>> GetFilm()
        {
            var film = await _filmService.GetFilmAsync();
            if (film == null)
            {
                return NotFound();
            }
            var filmDTO = _mapper.Map<List<FilmDTO>>(film);
            return Ok(filmDTO);
        }

        [HttpGet("OneFilm")]
        public async Task<ActionResult<FilmDTO>> GetFilm(int filmId)
        {
            var film = await _filmService.GetFilmAsync(filmId);
            if (film == null)
            {
                return NotFound();
            }
            return Ok(film);
        }

        [HttpPost]
        public async Task<ActionResult<FilmDTO>> CreateFilm(FilmDTO filmDTO)
        {
            var film = _mapper.Map<Film>(filmDTO);
            await _filmService.AddFilmAsync(film);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<FilmDTO>> EditFilm(FilmDTO filmDTO)
        {
            var filmToUpdate = _mapper.Map<Film>(filmDTO);
            var updatedFilm = await _filmService.UpdateFilmAsync(filmToUpdate);
            var filmDTOTOReturn = _mapper.Map<FilmDTO>(updatedFilm);
            return Ok(filmDTOTOReturn);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteFilm(int id)
        {
            await _filmService.DeleteFilmAsync(id);
            return Ok();
        }
    }
}
