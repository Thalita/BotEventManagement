using AutoMapper;
using EventManager.Api.DTOs.Request;
using EventManager.Api.DTOs.Response;
using EventManager.Services.Interfaces;
using EventManager.Services.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage Events
    /// </summary>
    [Route("events")]
    [ApiController]
    public class EventsController : MasterController
    {
        public EventsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Get all events
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var events = _unitOfWork.Event.GetAll();
            var result = _mapper.Map<List<EventResponse>>(events);

            return ResponseResult(result);
        }

        /// <summary>
        /// Get a specific event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var @event = _unitOfWork.Event.Get(id);
            var result = _mapper.Map<EventResponse>(@event);

            return ResponseResult(result);
        }

        /// <summary>
        /// Get all attendants from an event
        /// </summary>
        /// <param name="id">Event's id</param>
        /// <returns></returns>
        [HttpGet("{id}/attendants")]
        public IActionResult GetAttendants([FromRoute] int id)
        {
            var attendants = _unitOfWork.Attendant.Find(a => a.Credential.EventId == id);
            var result = _mapper.Map<List<AttendantResponse>>(attendants);

            return ResponseResult(result);
        }

        /// <summary>
        /// Get all credentials from an event
        /// </summary>
        /// <param name="id">Event's id</param>
        /// <returns></returns>
        [HttpGet("{id}/credentials")]
        public IActionResult GetCredentials([FromRoute] int id)
        {
            var credentials = _unitOfWork.Credential.Find(c => c.EventId == id);
            var result = _mapper.Map<List<CredentialResponse>>(credentials);

            return ResponseResult(result);
        }

        /// <summary>
        /// Get all presentations from an event
        /// </summary>
        /// <param name="id">Event's id</param>
        /// <returns></returns>
        [HttpGet("{id}/presentations")]
        public IActionResult GetPresentations([FromRoute] int id)
        {
            var presentations = _unitOfWork.Presentation.Find(p => p.EventId == id);
            var result = _mapper.Map<List<PresentationResponse>>(presentations);

            return ResponseResult(result);
        }

        /// <summary>
        /// Get all speakers of an event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/speakers")]
        public IActionResult GetSpeakers([FromRoute] int id)
        {
            var speakers = _unitOfWork.Speaker.Find(s => s.EventId == id);
            var result = _mapper.Map<List<SpeakerResponse>>(speakers);

            return ResponseResult(result);
        }

        /// <summary>
        /// Get all sponsors for an specific event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/sponsors")]
        public IActionResult GetSponsors([FromRoute] int id)
        {
            var sponsors = _unitOfWork.Sponsor.Find(s => s.EventId == id);
            var result = _mapper.Map<List<SponsorResponse>>(sponsors);

            return ResponseResult(result);
        }

        /// <summary>
        /// Update a specific event
        /// </summary>
        /// <param name="eventRequest"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] EventRequest eventRequest)
        {
            var @event = _mapper.Map<Event>(eventRequest);     

            _unitOfWork.Event.Update(eventRequest.Id, @event);

            return Result();
        }

        /// <summary>
        /// Create an event
        /// </summary>
        /// <param name="eventRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] EventRequest eventRequest)
        {
            var @event = _mapper.Map<Event>(eventRequest);

            _unitOfWork.Event.Add(@event);

            return Result();
        }

        /// <summary>
        /// Remove an event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var @event = _unitOfWork.Event.Get(id);

            _unitOfWork.Event.Remove(@event);

            return Result();
        }
    }
}
