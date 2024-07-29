using AMS.Domain.Pirmitives;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Persistance.Interceptors
{
    public sealed class UpdateBaseEntityInterceptor:SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
                                                           DbContextEventData eventData, 
                                                           InterceptionResult<int> result, 
                                                           CancellationToken cancellationToken = default)
        {
            var dbContext = eventData.Context;
            if (dbContext is null) return base.SavingChangesAsync(eventData, result, cancellationToken);

            IEnumerable<EntityEntry<BaseEntity>> entities = 
                dbContext.ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entities)
            {
                switch (entry.State)
                {
                    case Microsoft.EntityFrameworkCore.EntityState.Modified:
                        entry.Property(x=>x.UpdatedDate).CurrentValue = DateTime.UtcNow;
                        break;

                    case Microsoft.EntityFrameworkCore.EntityState.Added:
                        entry.Property(x => x.CreatedDate).CurrentValue = DateTime.UtcNow;
                        break;

                    


                }
            }
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        }
    }
}
