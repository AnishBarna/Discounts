using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Discount.Models
{
    public partial class City
    {
        [Key]
        public int CityId { get; set; }
        public string? CityName { get; set; }

        [JsonIgnore]
        public IEnumerable<ProductCity>? ProductCities { get; set; }


    }
}
