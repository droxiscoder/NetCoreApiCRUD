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
    public class TripPhotoController : ControllerBase
    {

        private readonly ITripPhotoService _tripPhotoRepository;
        private readonly ILogger<UserController> _logger;

        public TripPhotoController(ITripPhotoService tripPhotoRepository,
                                ILogger<UserController> logger)
            : base()
        {
            this._tripPhotoRepository = tripPhotoRepository;
            this._logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TripPhoto tripPhoto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _tripPhotoRepository.Add(tripPhoto);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(TripPhoto), 200)]
        public async Task<IActionResult> GetSingle(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _tripPhotoRepository.GetSingle(id);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TripPhoto>), 200)]
        public async Task<IActionResult> GetAllByTripId(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _tripPhotoRepository.GetAllByTripId(id);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> Delete([FromBody] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _tripPhotoRepository.Delete(id);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }
    }
}

