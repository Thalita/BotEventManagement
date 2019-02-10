using AutoMapper;
using EventManager.Api.DTOs.Request;
using EventManager.Api.DTOs.Response;
using EventManager.Services.Interfaces;
using EventManager.Services.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage Event's attendants
    /// </summary>
    [Route("attendants")]
    [ApiController]
    public class AttendantsController : MasterController
    {
        public AttendantsController(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork, mapper)
        {        
        }

        /// <summary>
        /// Get a specific attendant
        /// </summary>      
        /// <param name="id">Attendant's id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            var attendant = _unitOfWork.Attendant.Find(x => x.AttendantId == id).FirstOrDefault();

            var result = _mapper.Map<AttendantResponse>(attendant);

            return ResponseResult(result);
        }
        
        /// <summary>
        /// Get all presentations from a specific attendant
        /// </summary>
        /// <param name="id">Attendant's id</param>
        /// <returns></returns>
        [HttpGet("{id}/presentations")]
        public IActionResult GetPresentations([FromRoute] int id)
        {
            var presentation = _unitOfWork.PresentationAttendant.Find(x => x.AttendantId == id).Select(x => x.Presentation);

            var result = _mapper.Map<List<PresentationResponse>>(presentation);

            return ResponseResult(result);
        }

        /// <summary>
        /// Get all presentations of a specific attendant in PDF format
        /// </summary>
        /// <param name="id">Attendant's id</param>
        /// <returns></returns>
        [HttpGet("{id}/presentations/pdf")]
        public IActionResult GetPresentationsPDF([FromRoute] int id)
        {
            // TODO: converter para pdf
            var presentation = _unitOfWork.PresentationAttendant.Find(x => x.AttendantId == id).Select(x => x.Presentation);

            var result = _mapper.Map<List<PresentationResponse>>(presentation);

            return ResponseResult(result);
        }

        /// <summary>
        /// Adds an attendant to an event
        /// </summary>
        /// <param name="attendantRequest">Attendant's data</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] AttendantRequest attendantRequest)
        {
            var attendant = _mapper.Map<Attendant>(attendantRequest);

            _unitOfWork.Attendant.Add(attendant);

            return Result();
        }

        /// <summary>
        /// Add a presentation to attendant's list
        /// </summary>
        /// <param name="attendantPresentationRequest"></param>
        /// <returns></returns>
        [HttpPost("presentation")]
        public IActionResult Create([FromBody] AttendantPresentationRequest attendantPresentationRequest)
        {
            var attendantPresentation = _mapper.Map<PresentationAttendant>(attendantPresentationRequest);

            _unitOfWork.PresentationAttendant.Add(attendantPresentation);

            return Result();
        }

        /// <summary>
        /// Update a specific attendant from an event
        /// </summary>
        /// <param name="attendantRequest">Attendant's data</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] AttendantRequest attendantRequest)
        {            
            var attendant = _mapper.Map<Attendant>(attendantRequest);

            _unitOfWork.Attendant.Update(attendantRequest.AttendantId, attendant);

            return Result();
        }

        /// <summary>
        /// Remove an attendant of an event
        /// </summary>
        /// <param name="id">Attendant's id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var attendant = _unitOfWork.Attendant.Find(x => x.AttendantId == id).First();

            _unitOfWork.Attendant.Remove(attendant);

            return Result();
        }

        /// <summary>
        /// Remove a presentation from attendant's list
        /// </summary>
        /// <param name="attendantPresentationRequest"></param>
        /// <returns></returns>
        [HttpDelete("presentation")]
        public IActionResult Delete([FromBody] AttendantPresentationRequest attendantPresentationRequest)
        {
            var atendantPresentation = _mapper.Map<PresentationAttendant>(attendantPresentationRequest);

            _unitOfWork.PresentationAttendant.Remove(atendantPresentation);

            return Result();
        }
    }
}
