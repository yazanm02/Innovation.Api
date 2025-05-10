using System.ComponentModel.DataAnnotations;

namespace Innovation_Task.Entities.Models
{
    public class Employee:BaseEntitie_SoftDelete
    {
       
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string? HomeAddress { get; set; }
        public string? Photo { get; set; }
    }
}
