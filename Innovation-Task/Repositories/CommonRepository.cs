using Innovation_Task.Entities;
using Innovation_Task.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Innovation_Task.Repositories
{
    public class CommonRepository<T> : ICommonRepository<T> where T : BaseEntitie_SoftDelete
    {
        private readonly AppDbContext _dbcontext;
        private readonly DbSet<T> _dbSet;
        public CommonRepository(AppDbContext dbcontext) 
        {
            _dbcontext = dbcontext;
            _dbSet=_dbcontext.Set<T>();
        }
        public async Task BulkDeleteAsync(List<Guid> ids)
        {
            var items=await _dbSet.Where(x=>ids.Contains(x.Id)).ToListAsync();
            foreach(var item in items)
            {
                item.IsDeleted = true;
            }
            _dbSet.RemoveRange(items);
            await SaveAsync();
        }

        public async  Task BulkInsertAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.Id == Guid.Empty || await GetByIdِAsync(entity.Id) != null)
                {
                    entity.Id = Guid.NewGuid();
                }
            }
            await _dbSet.AddRangeAsync(entities);
            await SaveAsync();
           
        }

        public async Task BulkUpdateAsync(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            await SaveAsync();
         
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await GetByIdِAsync(id);
            if ( item.IsDeleted == false) 

            item.IsDeleted = true;
            _dbSet.Update(item);
            await SaveAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _dbSet.Where(e => !e.IsDeleted).ToListAsync();
        }

        public async Task<T> GetByIdِAsync(Guid id)
        {
            var item = await _dbSet.Where(e => e.Id == id).FirstOrDefaultAsync();
            
            return item;

        }

        public async Task<T> InsertAsync(T entity)
        {
            if (entity.Id == Guid.Empty || await GetByIdِAsync(entity.Id) != null)
            {
                entity.Id = Guid.NewGuid();
            }
            var item= await _dbSet.AddAsync(entity);
         await SaveAsync();
            return item.Entity;
        }

        public async Task SaveAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var item = _dbSet.Update(entity);
            await SaveAsync();
            return item.Entity;
        }
    }
}
