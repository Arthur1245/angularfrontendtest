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
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountryController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;

        }

        [HttpGet("GetCountry")]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetCountry()
        {
            var country = await _countryService.GetCountryAsync();
            if (country == null)
            {
                return NotFound();
            }
            var countryDTO = _mapper.Map<List<CountryDTO>>(country);
            return Ok(countryDTO);
        }

        [HttpGet("GetOneCountry")]
        public async Task<ActionResult<CountryDTO>> GetCountry(int countryId)
        {
            var country = await _countryService.GetCountryAsync(countryId);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        public async Task<ActionResult<CountryDTO>> CreateCountry(CountryDTO countryDTO)
        {
            var country = _mapper.Map<Country>(countryDTO);
            await _countryService.AddCountryAsync(country);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<CountryDTO>> EditCountry(CountryDTO countryDTO)
        {
            var countryToUpdate = _mapper.Map<Country>(countryDTO);
            var updatedCountry = await _countryService.UpdateCountryAsync(countryToUpdate);
            var countryDTOTOReturn = _mapper.Map<CountryDTO>(updatedCountry);
            return Ok(countryDTOTOReturn);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            await _countryService.DeleteCountryAsync(id);
            return Ok();
        }
    }
}
