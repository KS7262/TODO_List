using System.ComponentModel.DataAnnotations;

namespace todoList.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string NickName { get; set;}

        [Required, RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")]
        public string Email { get; set;}

        [Required, MinLength(8), RegularExpression(@"^\S+$")] 
        public string Password { get; set;}

    }
}
