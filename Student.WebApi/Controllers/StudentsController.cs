using AMS.Application.Features.Commands;
using AMS.Application.Features.Queries.AMS;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public StudentsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStudent(AddStudentCommand addstudentCommand)
        {
            var result = await _mediatR.Send(addstudentCommand);
            return Ok(result);
        }

        [HttpGet("students")]

        public async Task<IActionResult> GetAllStudent()
        {
            var result = await _mediatR.Send(new GetAllStudentQuery());
            return Ok(result);
        }
        [HttpPut("{id}")]
        
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentCommand updateStudentCommand)
        {
            if (id != updateStudentCommand.Id)
            {
                return BadRequest("ID in the URL and command do not match");
            }

            var result = await _mediatR.Send(updateStudentCommand);
            return Ok(result);
        }
    }
}
