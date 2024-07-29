using AMS.Application.Features.Commands;
using AMS.Application.Features.Queries.AMS;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public TeachersController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewTeacher(AddTeacherCommand addTeacherCommand)
        {
            var result = await _mediatR.Send(addTeacherCommand);
            return Ok(result);
        }
        [HttpGet("teachers")]
        public async Task<IActionResult> GetAllTeacher()
        {
            var result = await _mediatR.Send(new GetAllTeacherQuery());
            return Ok(result);
        }
    }
}
