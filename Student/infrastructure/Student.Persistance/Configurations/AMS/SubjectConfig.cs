using AMS.Domain.Entities;
using AMS.Persistance.Configurations.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Persistance.Configurations.AMS
{
    public class SubjectConfig:BaseConfigurations<Subject>
    {
        public override void Configure(EntityTypeBuilder<Subject> builder)
        {
            base.Configure(builder);
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.SubjectName).HasColumnName("Subject name").HasMaxLength(100).IsRequired();
            builder.Property(x=>x.Course).HasMaxLength(100).IsRequired();
            builder.Property(x=>x.Semester).HasMaxLength(100).IsRequired();
            builder.Property(x=>x.AssignedTeacher).HasColumnName("Assigned Teacher").HasMaxLength(100).IsRequired();

            builder.HasOne(x=>x.Teacher).WithMany(x=>x.Subjects).HasForeignKey(x=>x.TeacherId);
            
            builder.HasMany(x=>x.StudentSubjects).WithOne(x=>x.Subject).HasForeignKey(x=>x.SubjectId);
        }
    }
}
