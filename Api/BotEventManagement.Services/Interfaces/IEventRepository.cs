﻿using EventManager.Services.Model.Entities;
using EventManager.Services.Model.DTO;

namespace EventManager.Services.Interfaces
{
    public interface IEventRepository : IRepository<EventDTO, EventDTO, Event>
    {
    }
}
