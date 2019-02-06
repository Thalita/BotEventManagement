﻿using AutoMapper;
using EventManager.Services.Interfaces;
using EventManager.Api.DTOs.Request;
using EventManager.Api.DTOs.Response;
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

            var attendant = _unitOfWork.Attendant.Find(x => x.AttendantId == id).FirstOrDefault();

            var result = _mapper.Map<AttendantResponse>(attendant);

            return Ok(result);

        }


        /// <summary>
        /// Get all presentations from a specific attendant
        /// </summary>
        /// <param name="id">Attendant's id</param>
        /// <returns></returns>
        [HttpGet("{id}/presentations")]
        public IActionResult GetPresentations([FromRoute] int id)
        {
            var presentation = _unitOfWork.PresentationAttendant.Find(x => x.AttendantId == id).Select(x => x.Attendant);

            var result = _mapper.Map<List<AttendantResponse>>(presentation);

            return Ok(result);
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
            var presentation = _unitOfWork.PresentationAttendant.Find(x => x.AttendantId == id).Select(x => x.Attendant);

            var result = _mapper.Map<List<AttendantResponse>>(presentation);

            return Ok(result);
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

            if(_unitOfWork.Save() == 1)
                return Ok();

            return BadRequest();

        }

        /// <summary>
        /// Add a presentation to attendant's list
        /// </summary>
        /// <param name="attendantPresentation"></param>
        /// <returns></returns>
        [HttpPost("presentation")]
        public IActionResult Create([FromBody] AttendantPresentationRequest attendantPresentation)
        {

            var result = _mapper.Map<PresentationAttendant>(attendantPresentation);

            _unitOfWork.PresentationAttendant.Add(result);

            if (_unitOfWork.Save() == 1)
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Update a specific attendant from an event
        /// </summary>
        /// <param name="attendantRequest">Attendant's data</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] AttendantRequest attendantRequest)
        {
            var  attendant = _unitOfWork.Attendant.Get(attendantRequest.AttendantId);

            if (attendantRequest.CredentialId > 0)
                attendant.CredentialId = attendantRequest.CredentialId;

            if(!string.IsNullOrWhiteSpace(attendantRequest.Name))
                attendant.Name = attendantRequest.Name;

            if(!string.IsNullOrWhiteSpace(attendant.Email))
                attendant.Email = attendantRequest.Email;

            if (_unitOfWork.Save() == 1)
                return Ok();
   
            return BadRequest();
        }

        /// <summary>
        /// Remove a presentation to attendant's list
        /// </summary>
        /// <param name="attendantPresentation"></param>
        /// <returns></returns>
        [HttpDelete("presentation")]
        public IActionResult Delete([FromBody] AttendantPresentationRequest attendantPresentation)
        {  
            var result = _mapper.Map<PresentationAttendant>(attendantPresentation);

            _unitOfWork.PresentationAttendant.Remove(result);

            if (_unitOfWork.Save() == 1)
                return Ok();

            return BadRequest();
        }
    }
}
