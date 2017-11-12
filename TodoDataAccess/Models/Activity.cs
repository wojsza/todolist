using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoDataAccess.Models
{
    [Table("Activieties")]
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public bool IsCompleted { get; set; } = false;
    }
}
