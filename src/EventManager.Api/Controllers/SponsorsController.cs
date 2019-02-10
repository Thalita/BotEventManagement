using EventManager.Services.Interfaces;
using EventManager.Api.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using EventManager.Api.DTOs.Response;
using EventManager.Services.Model.Entities;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage sponsors for an event
    /// </summary>
    [Route("sponsors")]
    [ApiController]
    public class SponsorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public SponsorsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a specific sponsor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute]int id)
        {
            var sponsor = _unitOfWork.Sponsor.Get(id);
            var result = _mapper.Map<SponsorResponse>(sponsor);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>
        /// Create an sponsor
        /// </summary>
        /// <param name="sponsorRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create([FromBody] SponsorRequest sponsorRequest)
        {
            var sponsor = _mapper.Map<Sponsor>(sponsorRequest);

            _unitOfWork.Sponsor.Add(sponsor);

            if (_unitOfWork.Save() == 1)
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Update a sponsor's information
        /// </summary>
        /// <param name="sponsorRequest"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult Update([FromBody] SponsorRequest sponsorRequest)
        {
            var sponsor = _mapper.Map<Sponsor>(sponsorRequest);
            
            if(sponsor != null)
            {
                _unitOfWork.Sponsor.Update(sponsorRequest.SponsorId, sponsor);
                if (_unitOfWork.Save() == 1)
                    return Ok();

            }

            return BadRequest();
        }

        /// <summary>
        /// Delete a sponsor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]int id)
        {
            var entity = _unitOfWork.Sponsor.Get(id);

            _unitOfWork.Sponsor.Remove(entity);

            if (_unitOfWork.Save() == 1)
                return Ok();

            return BadRequest();
        }
    }
}
