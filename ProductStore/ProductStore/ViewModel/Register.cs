using System.ComponentModel.DataAnnotations;

namespace ProductStore.ViewModel
{
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public string UserName{ get; set; }
        public string UserSurname { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Passwords Must Match!")]
        public string ConfirmPassword { get; set; }
    }
}
