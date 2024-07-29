using AMS.Application.Features.Commands;
using AMS.Application.Features.Queries.AMS;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Student.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public SubjectsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewSubject(AddSubjectCommand addSubjectCommand)
        {
            var result = await _mediatR.Send(addSubjectCommand);
            return Ok(result);
        }
        [HttpGet("subjects")]
        public async Task<IActionResult> GetAllSubject()
        {
            var result = await _mediatR.Send(new GetAllSubjectQuery());
            return Ok(result);
        }
    }
}
