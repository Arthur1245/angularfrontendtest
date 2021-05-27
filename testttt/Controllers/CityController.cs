using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StreamingService.DTO;
using StreamingService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CityController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;

        }

        [HttpGet("GetCity")]
        public async Task<ActionResult<IEnumerable<CityDTO>>> GetCity()
        {
            var city = await _cityService.GetCityAsync();
            if (city == null)
            {
                return NotFound();
            }
            var cityDTO = _mapper.Map<List<CityDTO>>(city);
            return Ok(cityDTO);
        }

        [HttpGet("GetOneCity")]
        public async Task<ActionResult<CityDTO>> GetCity(int cityId)
        {
            var city = await _cityService.GetCityAsync(cityId);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult<CityDTO>> CreateCity(CityDTO cityDTO)
        {
            var city = _mapper.Map<City>(cityDTO);
            await _cityService.AddCityAsync(city);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<CityDTO>> EditCity(CityDTO cityDTO)
        {
            var cityToUpdate = _mapper.Map<City>(cityDTO);
            var updatedCity = await _cityService.UpdateCityAsync(cityToUpdate);
            var cityDTOTOReturn = _mapper.Map<CityDTO>(updatedCity);
            return Ok(cityDTOTOReturn);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCity(int id)
        {
            await _cityService.DeleteCityAsync(id);
            return Ok();
        }
    }
}
