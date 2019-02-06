//using EventManager.Services.Interfaces;
//using EventManager.Services.Model.DTO.Request;
//using Microsoft.AspNetCore.Mvc;
//using System.Linq;

//namespace EventManager.Api.Controllers
//{
//    /// <summary>
//    /// Manage Event's credentials
//    /// </summary>
//    [Route("credentials")]
//    [ApiController]
//    public class CredentialsController : ControllerBase
//    {
//        private readonly ICredentialRepository _credentialRepository;
//        private readonly IPresentationRepository _presentationRepository;
//        private readonly IPresentationCredentialRepository _presentationCredentialRepository;

//        public CredentialsController(ICredentialRepository credentialRepository,
//                                     IPresentationRepository presentationRepository,
//                                     IPresentationCredentialRepository presentationCredentialRepository)
//        {
//            _credentialRepository = credentialRepository;
//            _presentationRepository = presentationRepository;
//            _presentationCredentialRepository = presentationCredentialRepository;
//        }

//        /// <summary>
//        /// Get a specific credential
//        /// </summary>      
//        /// <param name="id">Credential's id</param>
//        /// <returns></returns>
//        [HttpGet("{id}")]
//        public IActionResult GetById([FromRoute] int id)
//        {
//            return Ok(_credentialRepository.Select(x => x.CredentialId == id));
//        }

//         /// <summary>
//        /// Create an credential for an event
//        /// </summary>
//        /// <param name="credential"></param>
//        /// <returns></returns>
//        [HttpPost]
//        public IActionResult Create([FromBody] CredentiaRequest credential)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            _credentialRepository.Create(credential);

//            return Ok();
//        }

//        /// <summary>
//        /// Update a specific credential of an event
//        /// </summary>
//        /// <param name="credential"></param>
//        /// <returns></returns>
//        [HttpPut]
//        public IActionResult Update([FromBody] CredentiaRequest credential)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            _credentialRepository.Update(credential);

//            return NoContent();
//        }

//        /// <summary>
//        /// Remove an credential of an event
//        /// </summary>
//        /// <param name="id">Event's id</param>
//        /// <returns></returns>
//        [HttpDelete("{id}")]
//        public IActionResult Delete([FromRoute] int id)
//        {
//            var credential = new CredentiaRequest
//            {
//                CredentialId = id
//            };

//            _credentialRepository.Delete(credential);

//            return NoContent();
//        }

//        /// <summary>
//        /// Get all presentations from an credential
//        /// </summary>
//        /// <param name="id">Credential's id</param>
//        /// <returns></returns>
//        [HttpGet("{id}/presentations")]
//        public IActionResult Create([FromRoute] int id)
//        {
//            return Ok(_presentationRepository.Select(x => x.PresentationCredentials
//                                                      .All(p => p.CredentialId == id)));
//        }

//        /// <summary>
//        /// Bind a credential to a presentation
//        /// </summary>
//        /// <param name="presentationCredential"></param>
//        /// <returns></returns>
//        [HttpPost("presentations")]
//        public IActionResult Create([FromBody] PresentationCredentialRequest presentationCredential)
//        {
//            _presentationCredentialRepository.Create(presentationCredential);
//            return NoContent();
//        }

//        /// <summary>
//        /// Unbind a credential from a presentation
//        /// </summary>
//        /// <param name="presentationCredential"></param>
//        /// <returns></returns>
//        [HttpDelete("presentations")]
//        public IActionResult Delete([FromBody] PresentationCredentialRequest presentationCredential)
//        {
//            _presentationCredentialRepository.Delete(presentationCredential);
//            return NoContent();
//        }
//    }
//}
