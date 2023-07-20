namespace Course_Project.Service.DTOs.Items;


public class ItemForUpdateDto
{
    public string Name { get; set; }
    public List<string> Tags { get; set; }
    public Dictionary<string, object> CustomFieldValues { get; set; }
    // Other properties or validation attributes...
}
