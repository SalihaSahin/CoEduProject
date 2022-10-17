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
    public class FormOfEdusController : ControllerBase
    {
        IFormOfEduService _formOfEduService;

        public FormOfEdusController(IFormOfEduService formOfEduService)
        {
            _formOfEduService = formOfEduService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _formOfEduService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _formOfEduService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(FormOfEdu formOfEdu)
        {
            var result = _formOfEduService.Add(formOfEdu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(FormOfEdu formOfEdu)
        {
            var result = _formOfEduService.Delete(formOfEdu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(FormOfEdu formOfEdu)
        {
            var result = _formOfEduService.Update(formOfEdu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
