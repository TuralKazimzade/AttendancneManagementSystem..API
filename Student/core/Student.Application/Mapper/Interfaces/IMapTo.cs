using AMS.Domain.Pirmitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Mapper.Interfaces
{
    internal interface IMapTo<TEntity> where TEntity : BaseEntity { }
    
}
