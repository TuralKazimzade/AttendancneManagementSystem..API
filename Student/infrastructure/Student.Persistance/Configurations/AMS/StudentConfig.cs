using AMS.Persistance.Configurations.Commons;
using AMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AMS.Persistance.Configurations.AMS
{
    public class StudentConfig:BaseConfigurations<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Name).HasColumnName("Student name").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Course).HasMaxLength(100).IsRequired();
            builder.Property(x=>x.Email).HasColumnName("email").HasMaxLength(100).IsRequired();
            builder.Property(x=>x.UserName).HasColumnName("username").HasMaxLength(100).IsRequired();
            builder.Property(x=>x.Password).HasColumnName("password").IsRequired().HasMaxLength(100);

            builder.HasMany(x=>x.StudentSubjects).WithOne(x=>x.Students).HasForeignKey(x=>x.StudentId);
        }
    }
}
