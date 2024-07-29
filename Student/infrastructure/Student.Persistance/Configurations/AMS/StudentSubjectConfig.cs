using AMS.Domain.Entities;
using AMS.Persistance.Configurations.Commons;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Persistance.Configurations.AMS
{
    public class StudentSubjectConfig:BaseConfigurations<StudentSubject>
    {
        public override void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            base.Configure(builder);

            builder.HasKey(x=> new {x.StudentId,x.SubjectId});
        }
    }
}
