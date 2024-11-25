using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pedido_plus_backend.Dtos.Category
{
    public class CreateCategoryDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}