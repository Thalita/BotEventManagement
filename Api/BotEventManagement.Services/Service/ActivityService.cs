﻿using BotEventManagement.Services.Interfaces;
using BotEventManagement.Services.Model.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotEventManagement.Services.Service
{
    public class ActivityService : ICrudElementsWIthEventFilter<Activity>
    {
        private BotEventManagementContext _botEventManagementContext;

        public ActivityService(BotEventManagementContext botEventManagementContext)
        {
            _botEventManagementContext = botEventManagementContext;
        }

        public void Create(Activity element)
        {
            _botEventManagementContext.Activity.Add(element);
            _botEventManagementContext.SaveChanges();

        }

        public void Delete(string elementId)
        {
            int activityId = int.Parse(elementId);

            Activity element = _botEventManagementContext.Activity.Where(x => x.Id == activityId).First();
            _botEventManagementContext.Activity.Remove(element);

            _botEventManagementContext.SaveChanges();

        }

        public List<Activity> GetAll(string eventId)
        {
            List<Activity> elements = _botEventManagementContext.Activity.Where(x => x.EventId == eventId).ToList();
            return elements;

        }

        public Activity GetById(string elementId, string eventId)
        {
            int activityId = int.Parse(elementId);

            Activity element = _botEventManagementContext.Activity.Where(x => x.Id == activityId && x.EventId == eventId).First();
            return element;
        }

        public void Update(Activity element)
        {
            _botEventManagementContext.Entry(element).State = EntityState.Modified;
            _botEventManagementContext.SaveChanges();
        }
    }
}