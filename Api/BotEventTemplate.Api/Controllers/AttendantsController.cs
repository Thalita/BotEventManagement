using AutoMapper;
using EventManager.Services.Interfaces;
using EventManager.Services.Model.DTO.Request;
using EventManager.Services.Model.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage Event's attendants
    /// </summary>
    [Route("attendants")]
    [ApiController]
    public class AttendantsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public AttendantsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a specific attendant
        /// </summary>      
        /// <param name="id">Attendant's id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            var attendant = _unitOfWork.Attendant.Find(x => x.AttendantId == id);

            var result = _mapper.Map<AttendantResponse>(attendant);
        
            return Ok(result);          

        }


        ///// <summary>
        ///// Get all presentations from a specific attendant
        ///// </summary>
        ///// <param name="id">Attendant's id</param>
        ///// <returns></returns>
        //[HttpGet("{id}/presentations")]
        //public IActionResult GetPresentations([FromRoute] int id)
        //{
        //    return Ok(_presentationRepository.Select(x => x.PresentationAttendants.All(p => p.AttendantId == id)));
        //}

        //// TODO: RETORNAR COMO PDF
        ///// <summary>
        ///// Get all presentations of a specific attendant in PDF format
        ///// </summary>
        ///// <param name="id">Attendant's id</param>
        ///// <returns></returns>
        //[HttpGet("{id}/presentations/pdf")]
        //public IActionResult GetPresentationsPDF([FromRoute] int id)
        //{
        //    // TODO: converter para pdf
        //    return Ok(_presentationRepository.Select(x => x.PresentationAttendants.All(p => p.AttendantId == id)));
        //}

        ///// <summary>
        ///// Adds an attendant to an event
        ///// </summary>
        ///// <param name="attendant">Attendant's data</param>
        ///// <returns></returns>
        //[HttpPost]
        //public IActionResult Post([FromBody] AttendantRequest attendant)
        //{
        
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    _attendantRepository.Create(attendant);

        //    return Ok();
        //}

        ///// <summary>
        ///// Add a presentation to attendant's list
        ///// </summary>
        ///// <param name="attendantPresentation"></param>
        ///// <returns></returns>
        //[HttpPost("presentation")]
        //public IActionResult Create([FromBody] AttendantPresentationRequest attendantPresentation)
        //{
        //    _attendantPresentationRepository.Create(attendantPresentation);
        //    return NoContent();
        //}

        ///// <summary>
        ///// Update a specific attendant from an event
        ///// </summary>
        ///// <param name="attendant">Attendant's data</param>
        ///// <returns></returns>
        //[HttpPut]
        //public IActionResult Put([FromBody] AttendantRequest attendant)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    _attendantRepository.Update(attendant);

        //    return NoContent();
        //}

        ///// <summary>
        ///// Remove a presentation to attendant's list
        ///// </summary>
        ///// <param name="attendantPresentation"></param>
        ///// <returns></returns>
        //[HttpDelete("presentation")]
        //public IActionResult Delete([FromBody] AttendantPresentationRequest attendantPresentation)
        //{
        //    _attendantPresentationRepository.Delete(attendantPresentation);
        //    return NoContent();
        //}
    }
}
