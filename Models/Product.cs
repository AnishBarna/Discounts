using System;
using System.Collections.Generic;

namespace Discount.Models
{
    public partial class Product
    {
        public long DiscountedProductId { get; set; }
        public long ProductId { get; set; }
        public string? ProductName { get; set; }
    }
}
