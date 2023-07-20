using Course_Project.Domain.Commons;
using Course_Project.Domain.Enums;

namespace Course_Project.Domain.Entities;
public class Collection : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Topics Topic { get; set; } = Topics.Other;
    public byte[] ImageData { get; set; } // Store image as byte array
    public string ImageFilename { get; set; } // Store image filename
    public List<Item> Items { get; set; }
    public User Owner { get; set; }
    public List<CustomField> CustomFields { get; set; }
}
