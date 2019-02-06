//using EventManager.Services.Interfaces;
//using EventManager.Api.DTOs.Request;
//using Microsoft.AspNetCore.Mvc;
//using System.Linq;

//namespace EventManager.Api.Controllers
//{
//    /// <summary>
//    /// Manage Speakers of an event
//    /// </summary>
//    [Route("speakers")]
//    [ApiController]
//    public class SpeakersController : ControllerBase
//    {
//        private readonly ISpeakerRepository _speakerRepository;
//        private readonly ISpeakerPresentationRepository _speakerPresentationRepository;

//        public SpeakersController(ISpeakerRepository speakerRepository, ISpeakerPresentationRepository speakerPresentationRepository)
//        {
//            _speakerRepository = speakerRepository;
//            _speakerPresentationRepository = speakerPresentationRepository;
//        }

//        #region Speaker

//        /// <summary>
//        /// Get specific speaker of an event
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        [HttpGet("{id}")]
//        public IActionResult GetById([FromRoute]int id)
//        {
//            return Ok(_speakerRepository.Select(s => s.SpeakerId == id));
//        }

//        /// <summary>
//        /// Create a specific speaker of an event
//        /// </summary>
//        /// <param name="speaker"></param>
//        /// <returns></returns>
//        [HttpPost]
//        public IActionResult Post([FromBody] SpeakerRequest speaker)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            _speakerRepository.Create(speaker);

//            return Ok();
//        }

//        /// <summary>
//        /// Update a specific speaker of an event
//        /// </summary>
//        /// <param name="speaker"></param>
//        /// <returns></returns>
//        [HttpPut]
//        public IActionResult Put([FromBody] SpeakerRequest speaker)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            _speakerRepository.Update(speaker);

//            return NoContent();
//        }

//        /// <summary>
//        /// Remove a specific speaker of an event
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        [HttpDelete("{id}")]
//        public IActionResult Delete([FromRoute] int id)
//        {
//            var speaker = new SpeakerRequest
//            {
//                SpeakerId = id
//            };

//            _speakerRepository.Delete(speaker);
//            return Ok();
//        }

//        #endregion

//        #region Speaker's presentations

//        /// <summary>
//        /// Bind a presentation for this speaker
//        /// </summary>
//        /// <param name="speakerPresentation"></param>
//        /// <returns></returns>
//        [HttpPost("presentations")]
//        public IActionResult PostSpeakerPresentation([FromBody] SpeakerPresentationRequest speakerPresentation)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            _speakerPresentationRepository.Create(speakerPresentation);

//            return Ok();
//        }

//        /// <summary>
//        /// Unbind a presentation for this speaker
//        /// </summary>
//        /// <param name="speakerPresentation"></param>
//        /// <returns></returns>
//        [HttpDelete("presentations")]
//        public IActionResult Delete([FromBody] SpeakerPresentationRequest speakerPresentation)
//        {
//            _speakerPresentationRepository.Delete(speakerPresentation);
//            return Ok();
//        }

//        #endregion
//    }
//}
