using Innovation_Task.Entities.Models;
using Innovation_Task.Repositories;

namespace Innovation_Task.Services
{
    public class CommonServices<T> : ICommonServices<T> where T : BaseEntitie_SoftDelete
    {
        
        private readonly ICommonRepository<T> _repository;
        private readonly ExcelExportService _excelExportService;
        public CommonServices( ICommonRepository<T> repository,ExcelExportService excelExportService) {
        _repository = repository;
            _excelExportService = excelExportService;
        }
        public async Task<byte[]> ExportToExcelAsync(string sheetName, string? title = null, List<string>? selectedColumns = null)
        {
        
            var allData = await _repository.GetAllAsync();

            var filteredData = allData.Where(x => !x.IsDeleted).ToList();

            return _excelExportService.ExportToExcel(filteredData, sheetName, title, selectedColumns);
        }


        public async Task BulkDeleteAsync(List<Guid> ids)
        {
            await _repository.BulkDeleteAsync(ids);
        }

        public async Task BulkInsertAsync(IEnumerable<T> entities)
        {
             await _repository.BulkInsertAsync(entities);   
        }

        public async Task BulkUpdateAsync(IEnumerable<T> entities)
        {
            await _repository.BulkUpdateAsync(entities);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           var items= await _repository.GetAllAsync();
            return items;
        }

        public async Task<T> GetByIdِAsync(Guid id)
        {
            var item= await _repository.GetByIdِAsync(id);
            return item;
        }

        public async Task<T> InsertAsync(T entity)
        {

           var item= await _repository.InsertAsync(entity);
            return item;
        }

        public async Task SaveAsync()
        {
           await _repository.SaveAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
           var item= await _repository.UpdateAsync(entity);  
            return item;  
        }

       
    }
}
