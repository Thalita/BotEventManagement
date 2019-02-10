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
    /// Manage presentations of an specific event
    /// </summary>
    [Route("presentations")]
    [ApiController]
    public class PresentationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PresentationsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Presentation

        /// <summary>
        /// Get a specific Presentation of an event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var presentation = _unitOfWork.Presentation.Find(p => p.PresentationId == id).First();
            var result = _mapper.Map<PresentationResponse>(presentation);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        ////ToDo
        ///// <summary>
        ///// Get all attendants by filters
        ///// </summary>
        ///// <param name="id">Presentation's id</param>
        ///// <returns></returns>
        //[HttpPost]
        //public IActionResult GetPresentations([FromBody] PresentationRequestFilters filters)
        //{

        //    var result = _presentationRepository.Select(e => e.EventId == filters.EventId);

        //    var teste = new Dictionary<string, object>();

        //    teste.Add(nameof(filters.Category), filters.Category);



        //    if (!string.IsNullOrEmpty(filters.Category))
        //    {
        //        result = result.Where(c => c.Category == filters.Category);
        //    }
        //    if (!string.IsNullOrEmpty(filters.Local))
        //    {
        //        result = result.Where(l => l.Local == filters.Local);
        //    }
        //    if (!string.IsNullOrEmpty(filters.Name))
        //    {
        //        result = result.Where(t => t.Theme == filters.Theme);
        //    }


        //    _presentationRepository.Select(p => p.Category == filters.Category);


        //    //return Ok(_attendantRepository.Select(x => x.PresentationAttendants.All(p => p.PresentationId == id)));

        //    return Ok();
        //}

        /// <summary>
        /// Get all attendants from a specific presentation
        /// </summary>
        /// <param name="id">Presentation's id</param>
        /// <returns></returns>
        [HttpGet("{id}/attendants")]
        public IActionResult GetPresentations([FromRoute] int id)
        {
            var attendants = _unitOfWork.PresentationAttendant.Find(x => x.PresentationId == id).Select(x => x.Attendant);

            var result = _mapper.Map<List<AttendantResponse>>(attendants);

            return Ok(result);
        }

        /// <summary>
        /// Update a specific Presentation of an event
        /// </summary>
        /// <param name="presentationRequest"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] PresentationRequest presentationRequest)
        {
            var presentation = _mapper.Map<Presentation>(presentationRequest);

            if(presentation != null)
            {
                _unitOfWork.Presentation.Update(presentationRequest.PresentationId, presentation);

                if (_unitOfWork.Save() == 1)
                    return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Create a specific Presentation of an event
        /// </summary>
        /// <param name="presentationRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] PresentationRequest presentationRequest)
        {
            var presentatoin = _mapper.Map<Presentation>(presentationRequest);

            _unitOfWork.Presentation.Add(presentatoin);

            if (_unitOfWork.Save() == 1)
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Remove a specific Presentation of an event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var presentation = _unitOfWork.Presentation.Get(id);

            _unitOfWork.Presentation.Remove(presentation);

            if (_unitOfWork.Save() == 1)
                return Ok();

            return BadRequest();
        }

        #endregion
    }
}
