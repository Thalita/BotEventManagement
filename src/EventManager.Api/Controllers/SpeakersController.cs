using AutoMapper;
using EventManager.Api.DTOs.Request;
using EventManager.Api.DTOs.Response;
using EventManager.Services.Interfaces;
using EventManager.Services.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage Speakers of an event
    /// </summary>
    [Route("speakers")]
    [ApiController]
    public class SpeakersController : MasterController
    {
        public SpeakersController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
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

            return ResponseResult(result);
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

            return Result();
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

            _unitOfWork.Speaker.Update(speakerRequest.SpeakerId, speaker);

            return Result();
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

            return Result();
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

            return Result();
        }

        /// <summary>
        /// Unbind a presentation for this speaker
        /// </summary>
        /// <param name="speakerPresentationRequest"></param>
        /// <returns></returns>
        [HttpDelete("presentations")]
        public IActionResult Delete([FromBody] SpeakerPresentationRequest speakerPresentationRequest)
        {
            var speakerPresentation = _unitOfWork.SpeakerPresentation
                                                                    .Find(s => s.PresentationId == speakerPresentationRequest.PresentationId
                                                                               && s.SpeakerId == speakerPresentationRequest.SpeakerId)
                                                                    .FirstOrDefault();

            _unitOfWork.SpeakerPresentation.Remove(speakerPresentation);

            return Result();
        }
    }
}
