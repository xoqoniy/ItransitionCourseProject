
namespace Course_Project.Service.DTOs.Comments;

public class CommentForCreationDto
{
    public string Content { get; set; }
    public int ItemId { get; set; }
    public int AuthorId { get; set; }
    // Other properties or validation attributes...
}

