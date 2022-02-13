using System;
using System.Threading.Tasks;
using breakroutines.Data.Interfaces;
using breakroutines.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace breakroutines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository,
                                ILogger<UserController> logger)
            : base()
        {
            this._userRepository = userRepository;
            this._logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userRepository.Add(user);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }
    }
}
