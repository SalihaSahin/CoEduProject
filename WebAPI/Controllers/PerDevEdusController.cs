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
    public class PerDevEdusController : ControllerBase
    {
        IPerDevEduService _perDevEduService;

        public PerDevEdusController(IPerDevEduService perDevEduService)
        {
            _perDevEduService = perDevEduService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _perDevEduService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _perDevEduService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(PerDevEdu perDevEdu)
        {
            var result = _perDevEduService.Add(perDevEdu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(PerDevEdu perDevEdu)
        {
            var result = _perDevEduService.Delete(perDevEdu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(PerDevEdu perDevEdu)
        {
            var result = _perDevEduService.Update(perDevEdu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
