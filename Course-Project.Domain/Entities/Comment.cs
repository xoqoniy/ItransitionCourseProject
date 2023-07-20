using Course_Project.Domain.Commons;
namespace Course_Project.Domain.Entities;

public class Comment : Auditable
{
    public string Content { get; set; }
    public Item Item { get; set; }
    public User Author { get; set; }
}
