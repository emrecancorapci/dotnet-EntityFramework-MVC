using System.ComponentModel.DataAnnotations;

namespace Bookshop.Web.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "User name cannot be empty.")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password cannot be empty.")]
        public string Password { get; set; }
    }
}
