using AMS.Application.Repositories;
using AMS.Application.Repositories.AMS;
using AMS.Domain.Entities;
using AMS.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Persistance.Repositories.AMS
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AMSContext dbContext) : base(dbContext)
        {
        }
    }
}
