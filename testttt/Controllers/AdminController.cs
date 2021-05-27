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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        [HttpGet("AllAdmins")]
        public async Task<ActionResult<IEnumerable<AdminDTO>>> GetAdmins()
        {
            var admin = await _adminService.GetAdminsAsync();
            if (admin == null)
            {
                return NotFound();
            }
            var adminDTO = _mapper.Map<List<AdminDTO>>(admin);
            return Ok(adminDTO);
        }

        [HttpGet("OneAdmin")]
        public async Task<ActionResult<AdminDTO>> GetAdmin(int adminId)
        {
            var admin = await _adminService.GetAdminAsync(adminId);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        [HttpPost]
        public async Task<ActionResult<AdminDTO>> CreateAdmin(AdminDTO adminDTO)
        {
            var admin = _mapper.Map<Admin>(adminDTO);
            await _adminService.AddAdminAsync(admin);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<AdminDTO>> EditAdmin(AdminDTO adminDTO)
        {
            var adminToUpdate = _mapper.Map<Admin>(adminDTO);
            var updatedAdmin = await _adminService.UpdateAdminAsync(adminToUpdate);
            var adminDTOTOReturn = _mapper.Map<AdminDTO>(updatedAdmin);
            return Ok(adminDTOTOReturn);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAdmin(int id)
        {
            await _adminService.DeleteAdminAsync(id);
            return Ok();
        }
    }
}
