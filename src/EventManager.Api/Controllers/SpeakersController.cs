using EventManager.Services.Interfaces;
using EventManager.Api.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using EventManager.Services.Model.Entities;
using EventManager.Api.DTOs.Response;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage Speakers of an event
    /// </summary>
    [Route("speakers")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SpeakersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        /// <summary>
        /// Get specific speaker of an event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var speaker = _unitOfWork.Speaker.Find(s => s.SpeakerId == id).First();
            var result = _mapper.Map<SpeakerResponse>(speaker);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Create a specific speaker of an event
        /// </summary>
        /// <param name="speakerRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] SpeakerRequest speakerRequest)
        {
            var speaker = _mapper.Map<Speaker>(speakerRequest);

            _unitOfWork.Speaker.Add(speaker);

            if (_unitOfWork.Save() == 1)
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Update a specific speaker of an event
        /// </summary>
        /// <param name="speakerRequest"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] SpeakerRequest speakerRequest)
        {
            var speaker = _mapper.Map<Speaker>(speakerRequest);

            if(speaker != null)
            {
                _unitOfWork.Speaker.Update(speakerRequest.SpeakerId, speaker);

                if (_unitOfWork.Save() == 1)
                    return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Remove a specific speaker of an event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var entity = _unitOfWork.Speaker.Get(id);

            _unitOfWork.Speaker.Remove(entity);

            if (_unitOfWork.Save() == 1)
                return Ok();

            return BadRequest();
        }


        /// <summary>
        /// Bind a presentation for this speaker
        /// </summary>
        /// <param name="speakerPresentationRequest"></param>
        /// <returns></returns>
        [HttpPost("presentations")]
        public IActionResult PostSpeakerPresentation([FromBody] SpeakerPresentationRequest speakerPresentationRequest)
        {
            var speakerPresentation = _mapper.Map<SpeakerPresentation>(speakerPresentationRequest);

            _unitOfWork.SpeakerPresentation.Add(speakerPresentation);

            if (_unitOfWork.Save() == 1)
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Unbind a presentation for this speaker
        /// </summary>
        /// <param name="speakerPresentationRequest"></param>
        /// <returns></returns>
        [HttpDelete("presentations")]
        public IActionResult Delete([FromBody] SpeakerPresentationRequest speakerPresentationRequest)
        {
            var speakerPresentation = _unitOfWork.SpeakerPresentation.Find(s => s.PresentationId == speakerPresentationRequest.PresentationId
                                                                && s.SpeakerId == speakerPresentationRequest.SpeakerId)
                                                        .FirstOrDefault();

            _unitOfWork.SpeakerPresentation.Remove(speakerPresentation);

            if (_unitOfWork.Save() == 1)
                return Ok();

            return BadRequest();
        }
    }
}
