using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage = "Name cannot be long than 50 characters")]
        public string Name { get; set; }
    }
}
