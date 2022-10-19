using Discount.Models;
using Microsoft.EntityFrameworkCore;
using Discount.Data;

namespace Discount.Services
{
    public class DiscountedProductService
{
    private readonly DiscountContext _context;

    public DiscountedProductService(DiscountContext context)
    {
        _context = context;
    }
    public IEnumerable<Product>? GetAll()
    {
        return _context.Products;
    }
    public Product? GetById(int productid)
    {
        return _context.Products.FirstOrDefault(p => p.ProductId == productid);
    }
    public Product? GetByName(string query)
    {
        return _context.Products.FirstOrDefault(p => p.ProductName.ToLower() == query.ToLower());
    }
    public Product Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return product;

    }

    public bool isDiscountedByCity(int cityid, int productid)
    {

        var product = _context.Products.FirstOrDefault( p => p.ProductId == productid);

        var productcity = _context.ProductCities.FirstOrDefault(p => p.CityCityId == cityid && p.ProductDiscountedProductId == product.DiscountedProductId);

        if(productcity is not null)
        {
            return true;
        }

        return false;
    }


    public void Remove(int id)
    {
        var toBeRemoved = _context.Products.Find(id);

        if(toBeRemoved is null)
            return;
        
        _context.Products.Remove(toBeRemoved);
        _context.SaveChanges();
    }

}
}

