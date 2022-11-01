using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        ITrainerService _trainerService;
        IAuthService _authService;

        public TrainersController(ITrainerService trainerService, IAuthService authService)
        {
           _trainerService = trainerService;
            _authService = authService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(1000);
            var result = _trainerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("gettrainerdetails")]
        public IActionResult GetTrainerDetails(int trainerId)
        {
            var result = _trainerService.GetTrainerDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int trainerId)
        {
            var result = _trainerService.GetById(trainerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("gettrainerdetailbyid")]
        public IActionResult GetTrainerDetailById(int trainerId)
        {
            var result = _trainerService.GetTrainerDetailById(trainerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("gettrainerbyfilter")]
        public IActionResult GetTrainerDetailsByFilter(int educationId, int formOfEduId, int addressId)
        {
            var result = _trainerService.GetAllByFilter(educationId, formOfEduId, addressId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyaddress")]
        public IActionResult GetByAddress(int addressId)
        {
            var result = _trainerService.GetAllByAddressId(addressId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyformofedu")]
        public IActionResult GetByFormOfEdus(int formOfEduId)
        {
            var result = _trainerService.GetAllByFormOfEduId(formOfEduId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyeducation")]
        public IActionResult GetByEductaions(int educationId)
        {
            var result = _trainerService.GetAllByEducationId(educationId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(TrainerCreateDto trainer)
        {
            var result = _trainerService.Add(trainer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpDelete("delete")]
        public IActionResult Delete(Trainer trainer)
        {
            var result = _trainerService.Delete(trainer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Trainer trainer)
        {
            var result = _trainerService.Update(trainer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("changetrainerpassword")]
        public IActionResult ChangeTrainerPassword(ChangeUserPassword changeUserPassword)
        {
            var result = _trainerService.ChangeTrainerPassword(changeUserPassword);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
