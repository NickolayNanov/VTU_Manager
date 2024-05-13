using System.Linq.Expressions;
using VTU_Manager.Domain.Interfaces.Models;

namespace VTU_Manager.Domain.Interfaces.Repositories
{
    public interface IMutatableRepository<T, TKey>
        where T : class, IEntityBase
    {
        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(TKey id);

        Task DeleteAsync(Expression<Func<T, bool>> expression);
    }
}
