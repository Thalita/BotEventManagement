//using EventManager.Services.Interfaces;
//using EventManager.Api.DTOs.Request;
//using Microsoft.AspNetCore.Mvc;
//using System.Linq;

//namespace EventManager.Api.Controllers
//{
//    /// <summary>
//    /// Manage sponsors for an event
//    /// </summary>
//    [Route("sponsors")]
//    [ApiController]
//    public class SponsorsController : Controller
//    {

//        private readonly ISponsorRepository _sponsorRepository;

//        public SponsorsController(ISponsorRepository sponsorRepository)
//        {
//            _sponsorRepository = sponsorRepository;
//        }


//        #region Sponsor

//        /// <summary>
//        /// Get a specific sponsor
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        [HttpGet("{id}")]
//        public ActionResult GetById([FromRoute]int id)
//        {
//            var result = _sponsorRepository.Select(s => s.SponsorId == id);

//            return Ok(result);
//        }

//        /// <summary>
//        /// Create an sponsor
//        /// </summary>
//        /// <param name="sponsor"></param>
//        /// <returns></returns>
//        [HttpPost]
//        public ActionResult Create([FromBody] SponsorRequest sponsor)
//        {
//            _sponsorRepository.Create(sponsor);

//            return NoContent();
//        }

//        /// <summary>
//        /// Update a sponsor's information
//        /// </summary>
//        /// <param name="sponsor"></param>
//        /// <returns></returns>
//        [HttpPut]
//        public ActionResult Update([FromBody] SponsorRequest sponsor)
//        {
//            _sponsorRepository.Update(sponsor);

//            return NoContent();
//        }


//        /// <summary>
//        /// Delete a sponsor
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        [HttpDelete("{id}")]
//        public ActionResult Delete([FromRoute]int id)
//        {
//            var sponsor = new SponsorRequest
//            {
//                SponsorId = id
//            };

//            _sponsorRepository.Delete(sponsor);

//            return NoContent();
//        }

//        #endregion
//    }
//}
