using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Innovation_Task.Entities.Models;
using Innovation_Task.Services;
namespace Innovation_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController<T> : ControllerBase where T : BaseEntitie_SoftDelete { 
        private readonly  ICommonServices<T> _service;
        public CommonController(ICommonServices<T> service) { 
           _service = service;
   
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(Guid id) {
        
            var item = await _service.GetByIdِAsync(id);
            if (item.IsDeleted == true || item == null) 
                return NotFound($"ID={id} Not found");
            return Ok(item);
        }
        [HttpPost]

        public async Task<IActionResult> Insert([FromBody] T entity)
        {
           
            var item = await _service.InsertAsync(entity);
            return Ok(item);

        }

        [HttpPost("BulkInsert")]
        public void BulkInsert([FromBody] IEnumerable<T> entities)
        {
             _service.BulkInsertAsync(entities);
          
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] T entity)
        {
            var item =await _service.UpdateAsync(entity);   
            return Ok(item);
        }

        [HttpPut("BulkUpdate")]
        public async Task<IActionResult> BulkUpdate(IEnumerable<T> entities)
        {
            await _service.BulkUpdateAsync(entities);
            return Ok();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        [HttpDelete("BulkDelete")]
        public async Task<IActionResult> BulkDelete(List<Guid> ids)
        {
            await _service.BulkDeleteAsync(ids);
            return Ok();

        }


    }
}
