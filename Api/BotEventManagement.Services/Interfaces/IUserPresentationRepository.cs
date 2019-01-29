﻿using EventManager.Services.Model.Entities;
using EventManager.Services.Model.DTO;

namespace EventManager.Services.Interfaces
{
    public interface IUserPresentationsRepository : IRepository<AttendantPresentationDTO, PresentationDTO, PresentationAttendant>
    {
    }
}