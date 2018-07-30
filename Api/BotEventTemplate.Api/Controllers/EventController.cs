﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotEventManagement.Services.Model.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotEventManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet, Route("{eventId}")]
        public IActionResult Get([FromRoute]string eventId)
        {
            return Ok();
        }

        [HttpPut("{eventId}")]
        public IActionResult Put([FromRoute] string eventId, [FromBody] Event @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Event @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        [HttpDelete("{eventId}")]
        public IActionResult Delete([FromRoute] string eventId)
        {
            return Ok();
        }
    }
}