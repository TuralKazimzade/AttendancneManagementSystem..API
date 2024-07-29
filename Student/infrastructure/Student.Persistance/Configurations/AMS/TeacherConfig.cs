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
    public class TeacherConfig:BaseConfigurations<Teacher>
    {
        public override void Configure(EntityTypeBuilder<Teacher> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Name).HasColumnName("Teacher name").HasMaxLength(100).IsRequired();
            builder.Property(x=>x.Address).HasMaxLength(100).IsRequired();
            builder.Property(x=>x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x=>x.UserName).HasColumnName("Username").HasMaxLength(100).IsRequired();
            builder.Property(x=>x.Password).HasMaxLength(100).IsRequired();

            builder.HasMany(x=>x.Subjects).WithOne(x=>x.Teacher).HasForeignKey(x=>x.TeacherId);
        }
    }
}
