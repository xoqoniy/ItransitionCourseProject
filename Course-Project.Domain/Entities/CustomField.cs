
using Course_Project.Domain.Enums;

namespace Course_Project.Domain.Entities;
public class CustomField
{
    public int Id { get; set; }
    public string Name { get; set; }
    public FieldType Type { get; set; }
    public Collection Collection { get; set; }

}
