using AMS.Domain.Pirmitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Domain.Entities
{
    public class Subject:BaseEntity
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string Course { get; set; }
        public string Semester { get; set; }
        public string AssignedTeacher { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
