using Discount.Models;
using Discount.Data;

namespace Discount.Services
{
    public partial class ProductCityService
    {
        private readonly DiscountContext _context;

        public ProductCityService(DiscountContext context)
        {
            _context = context;
        }


        public IEnumerable<ProductCity>? Get()
        {
            return _context.ProductCities.ToList();
        }


        public ProductCity? GetById(int id)
        {
            return _context.ProductCities.Where( p => p.Id == id).FirstOrDefault();
        }
        public ProductCity AddProductCity(ProductCity productcity)
        {
            _context.ProductCities.Add(productcity);
            _context.SaveChanges();

            return productcity;            
        }

        public void Remove(int productcityid)
        {
            var toBeRemoved = _context.ProductCities.Find(productcityid);
            

            if(toBeRemoved is not null)
            {
                _context.ProductCities.Remove(toBeRemoved);
                _context.SaveChanges();
            }
        }



    }
}