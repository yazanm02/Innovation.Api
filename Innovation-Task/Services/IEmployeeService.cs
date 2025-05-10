
using Innovation_Task.Entities.DTO;
using Innovation_Task.Entities.Models;

namespace Innovation_Task.Services
{
    public interface IEmployeeService : ICommonServices<Employee>
    {
        Task<Employee> InsertEmployeeAsync(EmployeeDTO dto);
        Task<Employee> UpdateEmployeeAsync(EmployeeDTO dto);
    }
}
