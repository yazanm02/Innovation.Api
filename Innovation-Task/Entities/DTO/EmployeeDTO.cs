
namespace Innovation_Task.Entities.DTO
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; } 
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? HomeAddress { get; set; }
        public IFormFile? PhotoFile { get; set; }
    }
}
