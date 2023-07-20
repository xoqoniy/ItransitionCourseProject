using Course_Project.Domain.Enums;

namespace Course_Project.Service.DTOs.CustomFields;

public class CustomFieldForResultDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public FieldType Type { get; set; }
    // Other properties or relationships...
}
