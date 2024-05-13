using System.Linq.Expressions;

namespace VTU_Manager.Domain.Interfaces.Repositories
{
    public interface IReadOnlyRepository<T, TKey>
    {
        Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression);

        Task<T> GetByIdAsync(TKey id);

        Task<IEnumerable<T>> ListAsync();

        Task<IEnumerable<T>> ListWithExpressionAsync(Expression<Func<T, bool>> expression);
    }
}
