using AutoMapper;
using EventManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Api.Controllers
{
    public class MasterController: ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public MasterController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        protected IActionResult Result()
        {
            if (_unitOfWork.Save() > 0)
                return Ok();

            return BadRequest();
        }

        protected IActionResult ResponseResult<T>(T result)
        {
            if (result == null)
                return NotFound();
            
            return Ok(result);
        }
    }
}
