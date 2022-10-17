using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportEdusController : ControllerBase
    {
        ISportEduService _sportEduService;

        public SportEdusController(ISportEduService sportEduService)
        {
            _sportEduService = sportEduService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _sportEduService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _sportEduService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(SportEdu sportEdu)
        {
            var result = _sportEduService.Add(sportEdu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(SportEdu sportEdu)
        {
            var result = _sportEduService.Delete(sportEdu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(SportEdu sportEdu)
        {
            var result = _sportEduService.Update(sportEdu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
