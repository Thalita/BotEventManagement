﻿using EventManager.Services.Model.Entities;
using EventManager.Services.Model.DTO.Request;
using EventManager.Services.Model.DTO.Response;

namespace EventManager.Services.Interfaces
{
    public interface IAttendantRepository : IRepository<AttendantRequest, AttendantResponse, Attendant>
    {

    }
}
