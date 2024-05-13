using System.Linq.Expressions;
using VTU_Manager.Domain.Interfaces.Models;
using VTU_Manager.Domain.Interfaces.Repositories;
using VTU_Manager.Persistance.Data;

namespace VTU_Manager.Persistance.Write
{
    public class MutatableRepository<T, TKey> : IMutatableRepository<T, TKey>
        where T : class, IEntityBase
    {
        private readonly ApplicationDbContext context;

        public MutatableRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(T entity)
        {
            await this.context.Set<T>().AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this.context.Set<T>().Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TKey id)
        {
            var entity = await this.context.Set<T>().FindAsync(id);

            this.context.Set<T>().Remove(entity);

            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> expression)
        {
            var entities = this.context.Set<T>().Where(expression);

            this.context.RemoveRange(entities);

            await this.context.SaveChangesAsync();
        }
    }
}
