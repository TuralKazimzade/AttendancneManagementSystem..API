using AMS.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Features.Commands
{
    public class UpdateStudentCommand: IRequest<StudentViewDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
