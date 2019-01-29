using Microsoft.AspNetCore.Mvc;
using System;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Controller to validate api health
    /// </summary>
    [Route("/health")]
    public class HealthController : Controller
    {

        /// <summary>
        /// Method to validate api health
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            Console.WriteLine("Health Controller - Before Health return");
            return Ok("success");
        }
    }
}