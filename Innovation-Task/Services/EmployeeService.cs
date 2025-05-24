using Innovation_Task.Entities.DTO;
using Innovation_Task.Entities.Models;
using Innovation_Task.Repositories;

namespace Innovation_Task.Services
{
    public class EmployeeService : CommonServices<Employee>, IEmployeeService
    {
        private readonly ICommonRepository<Employee> _EmployeeRepository;
        public EmployeeService(ICommonRepository<Employee> repository, ExcelExportService excelExportService) 
        : base(repository, excelExportService)
        {
            _EmployeeRepository = repository;
        }
        public async Task<Employee> InsertEmployeeAsync(EmployeeDTO dto)
        {
            
            using (var ms = new MemoryStream()) {
                byte[] fileArray = [];
                if (dto.PhotoFile != null)
                {
                    await dto.PhotoFile.CopyToAsync(ms);
                    fileArray = ms.ToArray();
                }
   
                var employee = new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Email = dto.Email,
                    MobileNumber = dto.MobileNumber,
                    HomeAddress = dto.HomeAddress,
                    Photo = Convert.ToBase64String(fileArray)
                };
                return await InsertAsync(employee);
            }
        
        }

        public async Task<Employee> UpdateEmployeeAsync(EmployeeDTO dto)
        {
            Guid id = dto.Id;
            var EmployeeUpdate = await _EmployeeRepository.GetByIdِAsync(id);
            using (var ms = new MemoryStream())
            {
               
                byte[] fileArray = [] ;
                if (dto.PhotoFile != null)
                {
                    await dto.PhotoFile.CopyToAsync(ms);
                    fileArray = ms.ToArray();
                    EmployeeUpdate.Photo = Convert.ToBase64String(fileArray);
                }

                EmployeeUpdate.Id = dto.Id;
                EmployeeUpdate.Name = dto.Name;
                EmployeeUpdate.Email = dto.Email;
                EmployeeUpdate.MobileNumber = dto.MobileNumber;
                EmployeeUpdate.HomeAddress = dto.HomeAddress;

                
             
                return await UpdateAsync(EmployeeUpdate);
            }

        }



    }

}
