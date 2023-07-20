using Course_Project.Domain.Enums;
using Course_Project.Service.DTOs.CustomFields;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Course_Project.Service.DTOs.Collections;

public class CollectionForCreationDto
{
    [Required(ErrorMessage = "Collection name is required")]
    public string Name { get; set; }
    public string Description { get; set; }
    public Topics Topic { get; set; }
    public IFormFile ImageFile { get; set; }
    public List<CustomFieldForCreationDto> CustomFields { get; set; }
}
