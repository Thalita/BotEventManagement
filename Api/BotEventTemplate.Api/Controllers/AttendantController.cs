using EventManager.Services.Interfaces;
using EventManager.Services.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage Event's attendants
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AttendantsController : ControllerBase
    {
        private IAttendantRepository _attendantRepository;
        public AttendantsController(IAttendantRepository attendantRepository)
        {
            _attendantRepository = attendantRepository;
        }

        /// <summary>
        /// Get all Event's attendants of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet, Route("events/{attendantId}")]
        public IActionResult GetAllByEvent([FromHeader] int eventId)
        {
            return Ok(_attendantRepository.Select(x => x.PresentationAttendants
                                                      .All(p => p.Presentation.EventId == eventId)));
        }

        /// <summary>
        /// Get a specific attendant
        /// </summary>      
        /// <param name="attendantId"></param>
        /// <returns></returns>
        [HttpGet, Route("{attendantId}")]
        public IActionResult Get([FromRoute]int attendantId)
        {
            return Ok(_attendantRepository.Select(x => x.AttendantId == attendantId));
        }

        /// <summary>
        /// Update a specific attendant of an event
        /// </summary>
        /// <param name="attendant"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] AttendantDTO attendant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _attendantRepository.Update(attendant);

            return NoContent();
        }

        /// <summary>
        /// Create an attendant for an event
        /// </summary>
        /// <param name="attendant"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] AttendantDTO attendant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _attendantRepository.Create(attendant);

            return Ok();
        }

        /// <summary>
        /// Remove an Event Participant of an event
        /// </summary>
        /// <param name="attendantId"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int attendantId)
        {
            var attendantDTO = new AttendantDTO
            {
                AttendantId = attendantId
            };

            _attendantRepository.Delete(attendantDTO);

            return NoContent();
        }

    }
}