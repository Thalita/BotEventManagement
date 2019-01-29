using EventManager.Services.Interfaces;
using EventManager.Services.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage User Presentations of an event
    /// </summary>
    [Route("[controller]")]
    public class PresentantionsAttendantsController : Controller
    {
        private readonly IUserPresentationsRepository _attendantPresentationRepository;

        public PresentantionsAttendantsController(IUserPresentationsRepository userPresentationsRepository)
        {
            _attendantPresentationRepository = userPresentationsRepository;
        }

        /// <summary>
        /// Create an attendant Presentation
        /// </summary>
        /// <param name="attendantPresentation"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] AttendantPresentationDTO attendantPresentation)
        {
            _attendantPresentationRepository.Create(attendantPresentation);
            return NoContent();
        }

        /// <summary>
        /// Delete an attend presentation entry
        /// </summary>
        /// <param name="attendantPresentation"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete([FromRoute] AttendantPresentationDTO attendantPresentation)
        {
            _attendantPresentationRepository.Delete(attendantPresentation);
            return NoContent();
        }

        /// <summary>
        /// Get all attendant Presentations of specific event
        /// </summary>
        /// <param name="attendantPresentation"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll([FromRoute] AttendantPresentationDTO attendantPresentation)
        {
            var result = _attendantPresentationRepository.Select(a => a.AttendantId == attendantPresentation.UserId
                                                               && a.PresentationId == attendantPresentation.PresentationId);
            return Ok(result);
        }

    }
}