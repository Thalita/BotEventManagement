using AutoMapper;
using EventManager.Api.DTOs.Request;
using EventManager.Api.DTOs.Response;
using EventManager.Services.Interfaces;
using EventManager.Services.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage presentations of an specific event
    /// </summary>
    [Route("presentations")]
    [ApiController]
    public class PresentationsController : MasterController
    {
        public PresentationsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
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

            return ResponseResult(result);
        }

        //ToDo
        /// <summary>
        /// Get all pesentation according to filters
        /// </summary>
        /// <param name="filters">Presentations filters</param>
        /// <returns></returns>
        [HttpPost("/filters")]
        public IActionResult GetPresentations([FromBody] PresentationRequest filters)
        {
            var list = _unitOfWork.Presentation.Find(e => e.EventId == filters.EventId);    

            //Filter values by reflection
            var properties = typeof(PresentationRequest).GetProperties();

            foreach (var prop in properties)
            {
                var value = prop.GetValue(filters, null);

                if (!IsEmpty(value))
                {
                    list = FilterList(list, prop.Name, value.ToString());
                }
            }

            var result = _mapper.Map<List<PresentationResponse>>(list);

            return ResponseResult(result);
        }

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

            return ResponseResult(result);
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

            _unitOfWork.Presentation.Update(presentationRequest.PresentationId, presentation);

            return Result();
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

            return Result();
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

            return Result();
        }

        #endregion


        private bool IsEmpty<T>(T field)
        {
            if (field == null || string.IsNullOrEmpty(field.ToString()))
                return true;
            if (field.Equals(default(DateTime)) || field.Equals(default(int)))
                return true;        

            return false;
        }

        private IEnumerable<T> FilterList<T>(IEnumerable<T> list, string propName, string filter)
        {
            var result = new List<T>();
            foreach (var item in list)
            {
                var value = item.GetType().GetProperty(propName).GetValue(item);

                if (value.ToString().Equals(filter))
                {
                    result.Add(item);
                }
            }
            return result;
        }

    }
}
