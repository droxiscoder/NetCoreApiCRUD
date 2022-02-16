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
    public class ReviewController : ControllerBase
    {

        private readonly IReviewService _reviewRepository;
        private readonly ILogger<UserController> _logger;

        public ReviewController(IReviewService reviewRepository,
                                ILogger<UserController> logger)
            : base()
        {
            this._reviewRepository = reviewRepository;
            this._logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Review review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _reviewRepository.Add(review);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Review>), 200)]
        public async Task<IActionResult> GetSingle(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _reviewRepository.GetSingle(id);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Review>), 200)]
        public async Task<IActionResult> GetAllByTripId(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _reviewRepository.GetAllByTripId(id);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> Delete([FromBody] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _reviewRepository.Delete(id);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }
    }
}


