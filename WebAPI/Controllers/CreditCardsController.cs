using Business.Abstract;
using Core.Utitlities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController: ControllerBase
    {
        private readonly ICreditCardService creditCardService;
        public CreditCardsController(ICreditCardService creditCardService)
        {
            this.creditCardService = creditCardService;
        }
        
        [HttpPost("add")]
        public IActionResult Add(CreditCardCreateDto creditCardCreateDto) 
        {
            var result = creditCardService.Add(creditCardCreateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CreditCardUpdateDto creditCardUpdateDto)
        {
            var result = creditCardService.Update(creditCardUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycreditcardid")]
        public IActionResult GetByCreditCardId(int id)
        {
            var result = creditCardService.GetByCreditCardId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycreditcardnumber")]
        public IActionResult GetByCreditCardNumber(string cardNumber)
        {
            var result = creditCardService.GetByCreditCardNumber(cardNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int id)
        {
            var result = creditCardService.GetByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
