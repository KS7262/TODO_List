﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace todoList.Entities
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required(ErrorMessage = "Enter the title")]
        [MinLength(3, ErrorMessage = "Min length must be 3 symbols")]
        public string Title { get; set; }

        [Required]
        public string Src { get; set; } 
    }
}
