﻿using EventManager.Services.Interfaces;
using EventManager.Api.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using EventManager.Api.DTOs.Response;
using EventManager.Services.Model.Entities;
using System.Collections.Generic;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage Event's credentials
    /// </summary>
    [Route("credentials")]
    [ApiController]
    public class CredentialsController : MasterController
    {
        public CredentialsController(IUnitOfWork unitOfWork, IMapper mapper):base (unitOfWork, mapper)
        {       
        }

        /// <summary>
        /// Get a specific credential
        /// </summary>      
        /// <param name="id">Credential's id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var credential = _unitOfWork.Credential.Get(id);

            var result = _mapper.Map<CredentialResponse>(credential);

            return ResponseResult(result);
        }

        /// <summary>
        /// Create an credential for an event
        /// </summary>
        /// <param name="credentialRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] CredentiaRequest credentialRequest)
        {
            var credential = _mapper.Map<Credential>(credentialRequest);

            _unitOfWork.Credential.Add(credential);

            return Result();
        }

        /// <summary>
        /// Update a specific credential of an event
        /// </summary>
        /// <param name="credentialRequest"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] CredentiaRequest credentialRequest)
        {
            var credential = _mapper.Map<Credential>(credentialRequest);

            _unitOfWork.Credential.Update(credentialRequest.CredentialId, credential);

            return Result();
        }

        /// <summary>
        /// Remove an credential of an event
        /// </summary>
        /// <param name="id">Event's id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var credential = _unitOfWork.Credential.Find(x => x.CredentialId == id).First();

            _unitOfWork.Credential.Remove(credential);

            return Result();
        }

        /// <summary>
        /// Get all presentations from an credential
        /// </summary>
        /// <param name="id">Credential's id</param>
        /// <returns></returns>
        [HttpGet("{id}/presentations")]
        public IActionResult GetCredentialsPresentation([FromRoute] int id)
        {
            var presentations = _unitOfWork.Credential.Find(C => C.CredentialId == id).First().PresentationCredentials.Select(s => s.Presentation);

            var result = _mapper.Map<List<PresentationResponse>>(presentations);

            return Ok(result);
        }

        /// <summary>
        /// Bind a credential to a presentation
        /// </summary>
        /// <param name="presentationCredentialRequest"></param>
        /// <returns></returns>
        [HttpPost("presentations")]
        public IActionResult Create([FromBody] PresentationCredentialRequest presentationCredentialRequest)
        {
            var presentationCredential = _mapper.Map<PresentationCredential>(presentationCredentialRequest);

            _unitOfWork.PresentationCredential.Add(presentationCredential);

            return Result();
        }

        /// <summary>
        /// Unbind a credential from a presentation
        /// </summary>
        /// <param name="presentationCredentialRequest"></param>
        /// <returns></returns>
        [HttpDelete("presentations")]
        public IActionResult Delete([FromBody] PresentationCredentialRequest presentationCredentialRequest)
        {
            var presentationCredential = _mapper.Map<PresentationCredential>(presentationCredentialRequest);

            _unitOfWork.PresentationCredential.Remove(presentationCredential);

            return Result();
        }
    }
}
