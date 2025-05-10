using System.ComponentModel.DataAnnotations;

namespace Innovation_Task.Entities.Models
{
    public class BaseEntitie_SoftDelete
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; } = false;
        public DateTime CreationDate { get; set; }= DateTime.Now;
    
        public DateTime ModifynDate { get; set; } = DateTime.Now;


    }
}
