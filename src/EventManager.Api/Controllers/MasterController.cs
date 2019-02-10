using AutoMapper;
using EventManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Api.Controllers
{
    public class MasterController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MasterController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Response()
        {
            if (_unitOfWork.Save() > 0)
                return Ok();

            return BadRequest();
        }

        public IActionResult ResponseResult<T>(T result)
        {
            if (result == null)
                return NotFound();

            if (_unitOfWork.Save() > 0)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
