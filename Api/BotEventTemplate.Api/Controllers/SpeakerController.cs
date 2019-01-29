using EventManager.Services.Interfaces;
using EventManager.Services.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage Speakers of an event
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private ISpeakerRepository _speakerService;
        public SpeakerController(ISpeakerRepository speakerService)
        {
            _speakerService = speakerService;
        }

        /// <summary>
        /// Get speakers of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromHeader] string eventId)
        {
            // return Ok(_speakerService.GetAll(eventId));

            return Ok();
        }

        /// <summary>
        /// Get specific speaker of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="speakerId"></param>
        /// <returns></returns>
        [HttpGet, Route("{speakerId}")]
        public IActionResult Get([FromHeader] string eventId, [FromRoute]string speakerId)
        {
            //return Ok(_speakerService.GetById(speakerId, eventId));

            return Ok();
        }

        /// <summary>
        /// Update a specific speaker of an event
        /// </summary>
        /// <param name="speakerId"></param>
        /// <param name="speaker"></param>
        /// <returns></returns>
        [HttpPut("{speakerId}")]
        public IActionResult Put([FromRoute] int speakerId, [FromBody] SpeakerDTO speaker)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (speakerId != speaker.SpeakerId)
                return BadRequest("This id doesn't correspond with object");

            _speakerService.Update(speaker);

            return NoContent();
        }

        /// <summary>
        /// Create a specific speaker of an event
        /// </summary>
        /// <param name="speaker"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] SpeakerDTO speaker)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _speakerService.Create(speaker);

            return Ok();
        }

        /// <summary>
        /// Remove a specific speaker of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="speakerId"></param>
        /// <returns></returns>
        [HttpDelete("{speakerId}")]
        public IActionResult Delete([FromHeader] string eventId, [FromRoute] string speakerId)
        {
            //_speakerService.Delete(eventId, speakerId);
            return Ok();
        }
    }
}