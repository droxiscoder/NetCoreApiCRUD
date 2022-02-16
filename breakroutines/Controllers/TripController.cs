using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using breakroutines.Data.Interfaces;
using breakroutines.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace breakroutines.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TripController : ControllerBase
    {

        private readonly ITripService _tripRepository;
        private readonly ILogger<UserController> _logger;

        public TripController(ITripService tripRepository,
                                ILogger<UserController> logger)
            : base()
        {
            this._tripRepository = tripRepository;
            this._logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Trip>), 200)]
        public async Task<IActionResult> GetByNearToMe(decimal latitude, decimal longitude)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _tripRepository.GetByNearToMe(latitude, longitude);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Trip), 200)]
        public async Task<IActionResult> GetSingleById(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _tripRepository.GetSingleById(id);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }

    }
}


