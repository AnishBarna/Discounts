using Discount.Models;
using Discount.Data;
using Microsoft.EntityFrameworkCore;

namespace Discount.Services
{
    public class KeyService
{  
    private readonly DiscountContext _context;
    
    public KeyService(DiscountContext context)
    {
        _context = context;
    }



    public IEnumerable<Key> GetAll()
    {
        return _context.Keys.ToList();
    }

    public int GetProductId()
    {
        var key = _context.Keys.Where( k => k.Id == 1).SingleOrDefault();

        int current = key!.ProductId++;

        _context.SaveChanges();

        return current;

    }

    public int GetCityId()
    {
        var key = _context.Keys.Where( k => k.Id == 1).SingleOrDefault();

        int current = key!.CityId++;

        _context.SaveChanges();

        return current;

    }

    public int GetProductCityId()
    {
        var key = _context.Keys.Where( k => k.Id == 1).SingleOrDefault();

        int current = key!.ProductCityId++;

        _context.SaveChanges();

        return current;

    }

    


}
}
