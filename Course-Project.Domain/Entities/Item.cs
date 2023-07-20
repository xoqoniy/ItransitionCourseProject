
using Course_Project.Domain.Commons;
using System.Xml.Linq;

namespace Course_Project.Domain.Entities;

public class Item : Auditable
{
    public string Name { get; set; }
    public List<string> Tags { get; set; }
    public Dictionary<string, object> CustomFieldValues { get; set; }
    public List<Comment> Comments { get; set; }
    public int Likes { get; set; }
    public Collection Collection { get; set; }
    public User Author { get; set; }
}
