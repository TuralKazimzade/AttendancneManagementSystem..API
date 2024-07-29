using AMS.Domain.Entities;
using AMS.Domain.Entities.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Persistance.Contexts
{
    public class AMSContext : DbContext
    {
        public AMSContext(DbContextOptions<AMSContext> options) : base(options) { }

        public DbSet<Student> Students => this.Set<Student>();
        public DbSet<Subject>  Subjects => this.Set<Subject>();
        public DbSet<StudentSubject> StudentSubjects => this.Set<StudentSubject>();
        public DbSet<Teacher> Teachers => this.Set<Teacher>();
        public DbSet<User> Users => this.Set<User>();
        public DbSet<Role> Roles => this.Set<Role>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
