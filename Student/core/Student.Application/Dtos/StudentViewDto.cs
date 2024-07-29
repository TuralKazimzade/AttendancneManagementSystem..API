using AMS.Application.Mapper.Interfaces;
using AMS.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Dtos
{
    public class StudentViewDto:IMapTo<Student>
    {
        
        public string Name { get; set; }
        public string Course { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
