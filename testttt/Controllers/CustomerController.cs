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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet("AllCustomers")]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            var customer = await _customerService.GetCustomersAsync();
            if (customer == null)
            {
                return NotFound();
            }
            var customerDTO = _mapper.Map<List<CustomerDTO>>(customer);
            return Ok(customerDTO);
        }

        [HttpGet("OneCustomer")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(int customerId)
        {
            var customer = await _customerService.GetCustomerAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerService.AddCustomerAsync(customer);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<CustomerDTO>> EditCustomer(CustomerDTO customerDTO)
        {
            var customerToUpdate = _mapper.Map<Customer>(customerDTO);
            var updatedcustomer = await _customerService.UpdateCustomerAsync(customerToUpdate);
            var customerDTOTOReturn = _mapper.Map<CustomerDTO>(updatedcustomer);
            return Ok(customerDTOTOReturn);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return Ok();
        }
    }
}
