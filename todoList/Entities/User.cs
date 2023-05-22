using System.ComponentModel.DataAnnotations;

namespace todoList.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter your nickname!")]
        [RegularExpression(@"^(?!.*\s\s)\S.*$", ErrorMessage = "Enter correct NickName")]
        public string NickName { get; set;}

        [Required(ErrorMessage = "")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Enter the correct email")]
        public string Email { get; set;}

        [Required(ErrorMessage = "Enter password")]
        [MinLength(8, ErrorMessage = "Min length must be 8 symbols")] 
        [RegularExpression(@"^\S+$", ErrorMessage = "Enter correct password")] 
        public string Password { get; set;}

    }
}
