using Business.Abstract;
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
    public class UserFavsController : ControllerBase
    {
        IUserFavService _userFavService;

        public UserFavsController(IUserFavService userFavService)
        {
            _userFavService = userFavService;
        }


        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _userFavService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getuserfavdetails")]
        public IActionResult GetUserFavDetails()
        {
            var result = _userFavService.GetUserFavDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
