using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ServisInjection.Models
{
    public class Product<T>
    {
        public T Id { get; set; }
        [Required]
        [MaxLength(6)]
        [Column(TypeName = "varchar(255)")]
        public string Maker { get; set; }
        [JsonPropertyName("img")]
        [Required]
        [MaxLength(6)]
        [Column(TypeName = "varchar(255)")]
        public string Image { get; set; }
        [Required]
        [MaxLength(6)]
        [Column(TypeName = "varchar(255)")]
        public string Url { get; set; }
        [Required]
        [MaxLength(6)]
        [Column(TypeName = "varchar(255)")]
        public string Title { get; set; }
        [Required]
        [MaxLength(6)]
        [Column(TypeName = "varchar(1024)")]
        public string Description { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Product<T>>(this);
    }
}
