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
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService , IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpGet("AllPayments")]
        public async Task<ActionResult<IEnumerable<PaymentDTO>>> GetPayments()
        {
            var payment = await _paymentService.GetPaymentsAsync();
            if (payment == null)
            {
                return NotFound();
            }
            var paymentDTO = _mapper.Map<List<PaymentDTO>>(payment);
            return Ok(paymentDTO);
        }

        [HttpGet("OnePayment")]
        public async Task<ActionResult<PaymentDTO>> GetPayment(int paymentId)
        {
            var payment = await _paymentService.GetPaymentAsync(paymentId);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDTO>> CreatePayment(PaymentDTO paymentDTO)
        {
            var payment = _mapper.Map<Payment>(paymentDTO);
            await _paymentService.AddPaymentAsync(payment);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<PaymentDTO>> EditPayment(PaymentDTO paymentDTO)
        {
            var paymentToUpdate = _mapper.Map<Payment>(paymentDTO);
            var updatedPayment = await _paymentService.UpdatePaymentAsync(paymentToUpdate);
            var paymentDTOTOReturn = _mapper.Map<PaymentDTO>(updatedPayment);
            return Ok(paymentDTOTOReturn);
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePayment(int id)
        {
            await _paymentService.DeletePaymentAsync(id);
            return Ok();
        }
    }
}
