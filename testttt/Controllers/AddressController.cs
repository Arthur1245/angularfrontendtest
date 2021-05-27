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
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AddressController(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;

        }

        [HttpGet("GetAddress")]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> GetAddress()
        {
            var address = await _addressService.GetAddressAsync();
            if (address == null)
            {
                return NotFound();
            }
            var addressDTO = _mapper.Map<List<AddressDTO>>(address);
            return Ok(addressDTO);
        }

        [HttpGet("GetOneAddress")]
        public async Task<ActionResult<AddressDTO>> GetAddress(int addressId)
        {
            var address = await _addressService.GetAddressAsync(addressId);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address);
        }

        [HttpPost]
        public async Task<ActionResult<AddressDTO>> CreateAddress(AddressDTO addressDTO)
        {
            var address = _mapper.Map<Address>(addressDTO);
            await _addressService.AddAddressAsync(address);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<AddressDTO>> EditAddress(AddressDTO addressDTO)
        {
            var addressToUpdate = _mapper.Map<Address>(addressDTO);
            var updatedAddress = await _addressService.UpdateAddressAsync(addressToUpdate);
            var addressDTOTOReturn = _mapper.Map<AddressDTO>(updatedAddress);
            return Ok(addressDTOTOReturn);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAddress(int id)
        {
            await _addressService.DeleteAddressAsync(id);
            return Ok();
        }
    }
}
