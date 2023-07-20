using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Course_Project.Service.DTOs.Users;

public class UserForUpdateDto 
{
    public int Id { get; set; }
    [Required(ErrorMessage = "UserName is required")]
    [Display(Name = "Username")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Email is required")]
    public bool IsDeleted { get; set; } = false;
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}
