using EventManager.Services.Interfaces;
using EventManager.Services.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage Events
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private IEventRepository _eventService;
        public EventsController(IEventRepository eventService)
        {
            _eventService = eventService;
        }
        /// <summary>
        /// Get all events
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_eventService.Select(e => true));
        }

        /// <summary>
        /// Get a specific event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet, Route("{eventId}")]
        public IActionResult GetById([FromRoute]int eventId)
        {
            return Ok(_eventService.Select(e => e.EventId == eventId));
        }

        /// <summary>
        /// Update a specific event
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        [HttpPut("{eventId}")]
        public IActionResult Put([FromBody] EventDTO @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _eventService.Update(@event);

            return NoContent();
        }

        /// <summary>
        /// Create an event
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] EventDTO @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _eventService.Create(@event);

            return Ok();
        }

        /// <summary>
        /// Remove an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpDelete("{eventId}")]
        public IActionResult Delete([FromRoute] int eventId)
        {
            var @event = new EventDTO
            {
                Id = eventId
            };

            _eventService.Delete(@event);
            return Ok();
        }
    }
}