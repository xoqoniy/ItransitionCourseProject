using System.ComponentModel.DataAnnotations;

namespace Course_Project.Service.DTOs.Users;

public class UserForCreationDto
{
    [Required(ErrorMessage = "UserName is required")]
    [Display(Name = "Username")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
    
}
