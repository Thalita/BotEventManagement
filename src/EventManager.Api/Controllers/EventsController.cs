using EventManager.Services.Interfaces;
using EventManager.Api.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using EventManager.Api.DTOs.Response;
using EventManager.Services.Model.Entities;
using System;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage Events
    /// </summary>
    [Route("events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EventsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

            return Ok(result);
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

            if (result == null)
                return NotFound();

            return Ok(result);
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

            return Ok(result);
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

            return Ok(result);
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
            var speakers = _unitOfWork.Speaker.Find(s => s.EventId == id);
            var result = _mapper.Map<List<SpeakerResponse>>(speakers);

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
            var sponsors = _unitOfWork.Sponsor.Find(s => s.EventId == id);
            var result = _mapper.Map<List<SponsorResponse>>(sponsors);

            return Ok(result);
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

            if (@event == null)
                return BadRequest();

            _unitOfWork.Event.Update(eventRequest.Id, @event);

            if (_unitOfWork.Save() == 1)
                return Ok();

            return BadRequest();
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

            if (_unitOfWork.Save() == 1)
                return Ok();

            return BadRequest();
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

            if (_unitOfWork.Save() == 1)
                return Ok();

            return BadRequest();
        }
    }
}
