using System;
using System.Collections.Generic;

namespace Discount.Models
{
    public partial class ProductCity
    {
        public long ProductDiscountedProductId { get; set; }
        public int CityCityId { get; set; }

        public virtual City CityCity { get; set; } = null!;
        public virtual Product ProductDiscountedProduct { get; set; } = null!;
    }
}
