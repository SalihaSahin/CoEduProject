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
    public class HSchoolEdusController : ControllerBase
    {
        IHSchoolEduService _hSchoolEduService;

        public HSchoolEdusController(IHSchoolEduService hSchoolEduService)
        {
            _hSchoolEduService = hSchoolEduService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _hSchoolEduService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _hSchoolEduService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(HSchoolEdu hSchoolEdu)
        {
            var result = _hSchoolEduService.Add(hSchoolEdu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(HSchoolEdu hSchoolEdu)
        {
            var result = _hSchoolEduService.Delete(hSchoolEdu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(HSchoolEdu hSchoolEdu)
        {
            var result = _hSchoolEduService.Update(hSchoolEdu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
