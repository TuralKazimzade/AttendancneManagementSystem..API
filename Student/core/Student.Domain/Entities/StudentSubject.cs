using AMS.Domain.Pirmitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Domain.Entities
{
    public class StudentSubject:BaseEntity
    {
        public int StudentId { get; set; }
        public Student Students { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
