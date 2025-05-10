using Innovation_Task.Entities.Models;

namespace Innovation_Task.Repositories
{
    public interface ICommonRepository<T> where T : BaseEntitie_SoftDelete
    {
        Task<T> GetByIdِAsync(Guid id);
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
         Task BulkInsertAsync(IEnumerable<T> entities);
        Task BulkUpdateAsync(IEnumerable<T> entities);

        Task BulkDeleteAsync(List<Guid> ids);
        Task SaveAsync();

    }
}
