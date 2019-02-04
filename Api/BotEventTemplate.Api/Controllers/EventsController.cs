using EventManager.Services.Interfaces;
using EventManager.Services.Model.DTO.Request;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage Events
    /// </summary>
    [Route("events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly ISponsorRepository _sponsorRepository;
        private readonly IAttendantRepository _attendantRepository;
        private readonly ICredentialRepository _credentialRepository;
        private readonly IPresentationRepository _presentationRepository;

        public EventsController(IEventRepository eventRepository,
                                ISpeakerRepository speakerRepository,
                                ISponsorRepository sponsorRepository,
                                IAttendantRepository attendantRepository,
                                ICredentialRepository credentialRepository,
                                IPresentationRepository presentationRepository)
        {
            _eventRepository = eventRepository;
            _speakerRepository = speakerRepository;
            _sponsorRepository = sponsorRepository;
            _attendantRepository = attendantRepository;
            _credentialRepository = credentialRepository;
            _presentationRepository = presentationRepository;
        }

        /// <summary>
        /// Get all events
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_eventRepository.Select(e => true));
        }

        /// <summary>
        /// Get a specific event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            return Ok(_eventRepository.Select(e => e.EventId == id));
        }

        /// <summary>
        /// Get all attendants from an event
        /// </summary>
        /// <param name="id">Event's id</param>
        /// <returns></returns>
        [HttpGet("{id}/attendants")]
        public IActionResult GetAttendants([FromRoute] int id)
        {
            return Ok(_attendantRepository.Select(x => x.PresentationAttendants
                                                      .All(p => p.Presentation.EventId == id)));
        }

        /// <summary>
        /// Get all credentials from an event
        /// </summary>
        /// <param name="id">Event's id</param>
        /// <returns></returns>
        [HttpGet("{id}/credentials")]
        public IActionResult GetCredentials([FromRoute] int id)
        {
            return Ok(_credentialRepository.Select(x => x.EventId == id));
        }

        /// <summary>
        /// Get all presentations from an event
        /// </summary>
        /// <param name="id">Event's id</param>
        /// <returns></returns>
        [HttpGet("{id}/presentations")]
        public IActionResult GetPresentations([FromRoute] int id)
        {
            var result = _presentationRepository.Select(p => p.EventId == id);

            return Ok(result);
        }

        /// <summary>
        /// Get all speakers of an event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/speakers")]
        public IActionResult GetSpeakers([FromRoute] int id)
        {
            var result = _speakerRepository.Select(s => s.SpeakerPresentations
                                                        .All(sp => sp.Presentation.EventId == id));

            return Ok(result);
        }

        /// <summary>
        /// Get all sponsors for an specific event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/sponsors")]
        public ActionResult GetSponsors([FromRoute] int id)
        {
            var result = _sponsorRepository.Select(s => s.EventId == id);

            return Ok(result);
        }

        /// <summary>
        /// Update a specific event
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] EventRequest @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _eventRepository.Update(@event);

            return NoContent();
        }

        /// <summary>
        /// Create an event
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] EventRequest @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _eventRepository.Create(@event);

            return Ok();
        }

        /// <summary>
        /// Remove an event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var @event = new EventRequest
            {
                Id = id
            };

            _eventRepository.Delete(@event);
            return Ok();
        }
    }
}
