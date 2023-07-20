using Course_Project.Domain.Enums;

namespace Course_Project.Service.DTOs.Collections; 
public class CollectionForResultDto 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Topics Topic { get; set; }
    public string ImageUrl { get; set; }
}
