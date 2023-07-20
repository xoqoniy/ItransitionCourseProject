using Course_Project.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Service.DTOs.Collections
{
    public class CollectionForUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Topics Topic { get; set; }
        public IFormFile ImageFile { get; set; }
        // Other properties or validation attributes...
    }

}
