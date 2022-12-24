using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Discount.Models
{
    public partial class Product
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<ProductCity>? ProductCities { get; set; }

    }
}
