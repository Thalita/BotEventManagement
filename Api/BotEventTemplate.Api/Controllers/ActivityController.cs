﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotEventManagement.Api.Controllers
{
    /// <summary>
    /// Manage activities of an event
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private ICrudElementsWIthEventFilter<Activity> _activityService;
        public ActivityController(ICrudElementsWIthEventFilter<Activity> activityService)
        {
            _activityService = activityService;
        }

        /// <summary>
        /// Get activities of an event
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromHeader] string eventId)
        {
            return Ok(_activityService.GetAll(eventId));
        }

        /// <summary>
        /// Get a specific activity of an event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="activityId"></param>
        /// <returns></returns>
        [HttpGet, Route("{activityId}")]
        public IActionResult Get([FromHeader] string eventId, [FromRoute]string activityId)
        {
            return Ok(_activityService.GetById(activityId, eventId));
        }

        /// <summary>
        /// Update a specific activity of an event
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="activity"></param>
        /// <returns></returns>
        [HttpPut("{activityId}")]
        public IActionResult Put([FromRoute] string activityId, [FromBody] Activity activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _activityService.Update(activity);

            return Ok();
        }

        /// <summary>
        /// Create a specific activity of an event
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Activity activity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _activityService.Create(activity);


            return Ok();
        }

        /// <summary>
        /// Remove a specific activity of an event
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        [HttpDelete("{activityId}")]
        public IActionResult Delete([FromRoute] string activityId)
        {
            _activityService.Delete(activityId);
            return Ok();
        }
    }
}