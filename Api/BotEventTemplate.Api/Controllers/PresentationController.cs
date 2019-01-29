using EventManager.Services.Interfaces;
using EventManager.Services.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage presentations of an specific event
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class PresentationsController : ControllerBase
    {
        private IPresentationRepository _presentationRepository;
        public PresentationsController(IPresentationRepository presentationRepository)
        {
            _presentationRepository = presentationRepository;
        }

        /// <summary>
        /// Get presentations of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromHeader] int eventId)
        {
            var result = _presentationRepository.Select(p => p.EventId == eventId);

            return Ok(result);
        }

        /// <summary>
        /// Get a specific Presentation of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="PresentationId"></param>
        /// <returns></returns>
        [HttpGet, Route("{PresentationId}")]
        public IActionResult GetById([FromHeader] int eventId, [FromRoute]int presentationId)
        {

            var result = _presentationRepository.Select(p => p.EventId == eventId
                                                        && p.PresentationId == presentationId); s

            return Ok(result);
        }

        /// <summary>
        /// Update a specific Presentation of an event
        /// </summary>
        /// <param name="Presentation"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] PresentationDTO Presentation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _presentationRepository.Update(Presentation);

            return NoContent();
        }

        /// <summary>
        /// Create a specific Presentation of an event
        /// </summary>
        /// <param name="presentation"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] PresentationDTO presentation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _presentationRepository.Create(presentation);

            return Ok();
        }

        /// <summary>
        /// Remove a specific Presentation of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="presentationId"></param>
        /// <returns></returns>
        [HttpDelete("{PresentationId}")]
        public IActionResult Delete([FromHeader] int eventId, [FromRoute] int presentationId)
        {
            var presentation = new PresentationDTO
            {
                PresentationId = presentationId,
                EventId = eventId
            };

            _presentationRepository.Delete(presentation);
            return NoContent();
        }
    }
}