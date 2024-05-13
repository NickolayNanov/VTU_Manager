using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VTU_Manager.Domain.Interfaces.Models;
using VTU_Manager.Domain.Interfaces.Repositories;
using VTU_Manager.Persistance.Data;

namespace VTU_Manager.Persistance.Read
{
    public class ReadOnlyRepository<T, TKey> : IReadOnlyRepository<T, TKey>
        where T : class, IEntityBase
    {
        private readonly ApplicationDbContext context;

        public ReadOnlyRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await this.context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> ListWithExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await this.context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await this.context.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            return await this.context.Set<T>().FindAsync(id);
        }
    }
}
