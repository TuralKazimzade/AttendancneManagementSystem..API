using AMS.Domain.Pirmitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(bool tracking = true);
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        Task<List<T>> GetWhere(Expression<Func<T, bool>> expression);


    }
}
