using System.ComponentModel.DataAnnotations;

namespace BeeHive.L20.Services.SL20.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Username is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
