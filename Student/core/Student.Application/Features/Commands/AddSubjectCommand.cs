using AMS.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Features.Commands
{
    public class AddSubjectCommand :IRequest<SubjectViewDto>
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string Course { get; set; }
        public string Semester { get; set; }
        public string AssignedTeacher { get; set; }
        public int TeacherId { get; set; }
    }
}
