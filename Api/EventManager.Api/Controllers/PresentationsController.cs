//using EventManager.Services.Interfaces;
//using EventManager.Api.DTOs.Request;
//using EventManager.Api.DTOs.Request.Filters;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;

//namespace EventManager.Api.Controllers
//{
//    /// <summary>
//    /// Manage presentations of an specific event
//    /// </summary>
//    [Route("presentations")]
//    [ApiController]
//    public class PresentationsController : ControllerBase
//    {
//        private readonly IAttendantRepository _attendantRepository;
//        private readonly IPresentationRepository _presentationRepository;

//        public PresentationsController(IAttendantRepository attendantRepository,
//                                       IPresentationRepository presentationRepository)
//        {
//            _attendantRepository = attendantRepository;
//            _presentationRepository = presentationRepository;
//        }

//        #region Presentation

//        /// <summary>
//        /// Get a specific Presentation of an event
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        [HttpGet("{id}")]
//        public IActionResult GetById([FromRoute]int id)
//        {
//            var result = _presentationRepository.Select(p => p.PresentationId == id);

//            return Ok(result);
//        }

//        /// <summary>
//        /// Get all attendants by filters
//        /// </summary>
//        /// <param name="id">Presentation's id</param>
//        /// <returns></returns>
//        [HttpPost]
//        public IActionResult GetPresentations([FromBody] PresentationRequestFilters filters)
//        {

//            var result = _presentationRepository.Select(e => e.EventId == filters.EventId);

//            var teste = new Dictionary<string, object>();

          

//            teste.Add(nameof(filters.Category), filters.Category);

            

//            if (!string.IsNullOrEmpty(filters.Category))
//            {
//                result = result.Where(c => c.Category == filters.Category);
//            }
//            if(!string.IsNullOrEmpty(filters.Local))
//            {
//                result = result.Where(l => l.Local == filters.Local);
//            }
//            if (!string.IsNullOrEmpty(filters.Name))
//            {
//                result = result.Where(t => t.Theme == filters.Theme);
//            }


//            _presentationRepository.Select(p => p.Category == filters.Category);


//            //return Ok(_attendantRepository.Select(x => x.PresentationAttendants.All(p => p.PresentationId == id)));

//            return Ok();
//        }

//        /// <summary>
//        /// Get all attendants from a specific presentation
//        /// </summary>
//        /// <param name="id">Presentation's id</param>
//        /// <returns></returns>
//        [HttpGet("{id}/attendants")]
//        public IActionResult GetPresentations([FromRoute] int id)
//        {
//            return Ok(_attendantRepository.Select(x => x.PresentationAttendants.All(p => p.PresentationId == id)));
//        }

//        /// <summary>
//        /// Update a specific Presentation of an event
//        /// </summary>
//        /// <param name="presentation"></param>
//        /// <returns></returns>
//        [HttpPut]
//        public IActionResult Put([FromBody] PresentationRequest presentation)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            _presentationRepository.Update(presentation);

//            return NoContent();
//        }

//        /// <summary>
//        /// Create a specific Presentation of an event
//        /// </summary>
//        /// <param name="presentation"></param>
//        /// <returns></returns>
//        [HttpPost]
//        public IActionResult Post([FromBody] PresentationRequest presentation)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            _presentationRepository.Create(presentation);

//            return Ok();
//        }

//        /// <summary>
//        /// Remove a specific Presentation of an event
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        [HttpDelete("{id}")]
//        public IActionResult Delete([FromRoute] int id)
//        {
//            var presentation = new PresentationRequest
//            {
//                PresentationId = id
//            };

//            _presentationRepository.Delete(presentation);
//            return NoContent();
//        }

//        #endregion
//    }
//}
