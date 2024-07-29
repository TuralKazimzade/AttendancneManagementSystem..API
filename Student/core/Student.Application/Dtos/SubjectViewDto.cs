using AMS.Application.Mapper.Interfaces;
using AMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Dtos
{
    public class SubjectViewDto:IMapTo<Subject>
    {       
        public string SubjectName { get; set; }
        public string Course { get; set; }
        public string Semester { get; set; }
        public string AssignedTeacher { get; set; }
    }
}
