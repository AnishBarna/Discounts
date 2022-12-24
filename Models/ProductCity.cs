using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace Discount.Models
{
    public partial class ProductCity
    {
        [Key]
        public int Id { get; set; }
        public int CityId { get; set; }

        public int ProductId { get; set; }

        [JsonIgnore]
        public virtual City? City { get; set; }

        [JsonIgnore]  
        public virtual Product? Product { get; set; }
    }
}
