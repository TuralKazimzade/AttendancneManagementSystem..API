using AMS.Application.Repositories;
using AMS.Application.Repositories.AMS;
using AMS.Persistance.Contexts;
using AMS.Persistance.Repositories.AMS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Persistance.Repositories
{
    public partial class UnitOfWork : IUnitOfWork
    {        
        private readonly AMSContext _context;
        private readonly Dictionary<Type, Object> _repositories;

        public UnitOfWork( AMSContext context)
        {
            _repositories = new Dictionary<Type, object>(); 
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            return SetRepository<TRepository>();
        }

        public void Roolback()
        {
           foreach(var entry in _context.ChangeTracker.Entries())
            {
                switch(entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added: 
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;

                }
            }
        }

        public IStudentRepository StudentRepository => new StudentRepository( _context );
        public ISubjectRepository SubjectRepository => new SubjectRepository( _context );
        public ITeacherRepository TeacherRepository => new TeacherRepository( _context );
        public IStudentSubjectRepository StudentSubjectRepository => new StudentSubjectRepository( _context );
        public TRepository SetRepository<TRepository>()
        {
            if (_repositories.ContainsKey(typeof(TRepository)))
            {
                return (TRepository)_repositories[typeof(TRepository)];
            }
            var repositoryType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x=>!x.IsInterface && x.IsClass && x.IsAssignableFrom(typeof(TRepository)));
            var repositoryInstance = (TRepository)Activator.CreateInstance(repositoryType,_context);
            _repositories.Add(typeof(TRepository), repositoryInstance);

            return repositoryInstance;
                
        }

       
        
    }
    partial class UnitOfWork
    {
        public IStudentRepository studentRepository=> SetRepository<IStudentRepository>();
        public ISubjectRepository subjectRepository=> SetRepository<SubjectRepository>();
        public ITeacherRepository teacherRepository=> SetRepository<TeacherRepository>();
    }
}
