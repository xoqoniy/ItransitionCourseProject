namespace Course_Project.Service.DTOs.Items;

public class ItemForCreationDto
{
    public string Name { get; set; }
    public List<string> Tags { get; set; }
    public Dictionary<string, object> CustomFieldValues { get; set; }
    public int CollectionId { get; set; }
    public int AuthorId { get; set; }
    // Other properties or validation attributes...
}
