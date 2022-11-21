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
    public class TrainerImagesController : ControllerBase
    {
        ITrainerImageService _trainerImageService;

        public TrainerImagesController(ITrainerImageService trainerImageService)
        {
            _trainerImageService = trainerImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _trainerImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _trainerImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesbytrainerid")]
        public IActionResult GetImagesByTrainerId(int trainerId)
        {
            var result = _trainerImageService.GetImagesByTrainerId(trainerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] TrainerImage trainerImage)
        {
            var result = _trainerImageService.Add(file,trainerImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm] IFormFile file, [FromForm] TrainerImage trainerImage)
        {
            var result = _trainerImageService.Delete(file,trainerImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] TrainerImage trainerImage)
        {
            var result = _trainerImageService.Update(file, trainerImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
