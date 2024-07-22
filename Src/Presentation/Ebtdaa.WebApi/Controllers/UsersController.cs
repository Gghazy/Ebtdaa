using Ebtdaa.Application.Users.Dtos;
using Ebtdaa.Application.Users.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebtdaa.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) 
        { 
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetOne(string ownerIdentity)
        {
            return Ok(await _userService.GetOne(ownerIdentity));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UserRequestDto request)
        {
            return Ok(await _userService.AddAsync(request));
        }
    }
}
