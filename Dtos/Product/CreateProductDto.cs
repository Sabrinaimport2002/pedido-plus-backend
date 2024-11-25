using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pedido_plus_backend.Dtos.Product
{
    public class CreateProductDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public int Stock { get; set; }
        [Required]
        public List<int> CategoryIds { get; set; }
    }
}