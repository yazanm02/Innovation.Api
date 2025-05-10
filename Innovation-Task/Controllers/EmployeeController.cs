using Innovation_Task.Entities.DTO;
using Innovation_Task.Entities.Models;
using Innovation_Task.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Innovation_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : CommonController<Employee>
    {
        private readonly IEmployeeService _EmployeeService;

        public EmployeeController(IEmployeeService EmployeeService) : base(EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }
        [HttpPost("InsertEmployee")]
        public async Task<IActionResult> InsertEmployee([FromForm]EmployeeDTO employeeDTO)
        {
            return Ok(await _EmployeeService.InsertEmployeeAsync(employeeDTO));
        }
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> updateEmploye([FromForm] EmployeeDTO employeeDTO)
        {
            return Ok(await _EmployeeService.UpdateEmployeeAsync(employeeDTO));
        }
    }
}
