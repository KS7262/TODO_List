using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todoList.Entities
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required, MinLength(3)]
        public string Title { get; set; }

        [Required]
        public string Src { get; set; } 
    }
}
