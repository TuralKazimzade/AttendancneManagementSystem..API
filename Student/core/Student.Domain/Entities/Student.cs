using AMS.Domain.Pirmitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Domain.Entities
{
    public  class Student:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public string  Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
