using Course_Project.Domain.Commons;
using Course_Project.Domain.Entities;

namespace Course_Project.Service.DTOs.Users;

public class UserForResultDto: Auditable
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; } = false;
    public bool IsBlocked { get; set; } = false;
    public List<Collection> Collections { get; set; }
}
