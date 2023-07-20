namespace Course_Project.Service.DTOs.Comments;


public class CommentForResultDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int ItemId { get; set; }
    public int AuthorId { get; set; }
    // Other properties or relationships...
}