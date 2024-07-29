using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AMS.Domain.Pirmitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Persistance.Configurations.Commons
{
    public class BaseConfigurations<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Id).HasColumnName("Id").UseIdentityColumn();
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDateTime").IsRequired();
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDateTime");
            builder.Property(x => x.CreatedId).HasColumnName("CreatedId");
            builder.Property(x => x.UpdatedId).HasColumnName("UpdatedId");

        }
    }
}
