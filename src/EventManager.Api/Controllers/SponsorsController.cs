using AutoMapper;
using EventManager.Api.DTOs.Request;
using EventManager.Api.DTOs.Response;
using EventManager.Services.Interfaces;
using EventManager.Services.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Manage sponsors for an event
    /// </summary>
    [Route("sponsors")]
    [ApiController]
    public class SponsorsController : MasterController
    {      
        public SponsorsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Get a specific sponsor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var sponsor = _unitOfWork.Sponsor.Get(id);

            var result = _mapper.Map<SponsorResponse>(sponsor);

            return ResponseResult(result);
        }

        /// <summary>
        /// Create an sponsor
        /// </summary>
        /// <param name="sponsorRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] SponsorRequest sponsorRequest)
        {
            var sponsor = _mapper.Map<Sponsor>(sponsorRequest);

            _unitOfWork.Sponsor.Add(sponsor);

            return Result();
        }

        /// <summary>
        /// Update a sponsor's information
        /// </summary>
        /// <param name="sponsorRequest"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] SponsorRequest sponsorRequest)
        {
            var sponsor = _mapper.Map<Sponsor>(sponsorRequest);

            _unitOfWork.Sponsor.Update(sponsorRequest.SponsorId, sponsor);

            return Result();
        }

        /// <summary>
        /// Delete a sponsor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            var entity = _unitOfWork.Sponsor.Get(id);

            _unitOfWork.Sponsor.Remove(entity);

            return Result();
        }
    }
}
