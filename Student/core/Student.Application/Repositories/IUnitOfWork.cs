using AMS.Application.Repositories.AMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Repositories
{
    public interface IUnitOfWork:IDisposable
    {
        Task Commit();
        void Roolback();
        TRepository SetRepository<TRepository>();
        TRepository GetRepository<TRepository>() where TRepository : class;
        public IStudentRepository StudentRepository { get; }
        public ISubjectRepository SubjectRepository { get; }
        public IStudentSubjectRepository StudentSubjectRepository { get; }
        public ITeacherRepository TeacherRepository { get; }
    }
}
