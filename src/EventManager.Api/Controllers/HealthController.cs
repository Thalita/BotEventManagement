﻿using Microsoft.AspNetCore.Mvc;
using System;

namespace EventManager.Api.Controllers
{
    /// <summary>
    /// Controller to validate api health
    /// </summary>
    [Route("/health")]
    public class HealthController : Microsoft.AspNetCore.Mvc.Controller
    {

        /// <summary>
        /// Method to validate api health
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("success");
        }
    }
}
