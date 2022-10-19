using Discount.Models;
using Discount.Data;
using Microsoft.EntityFrameworkCore;

namespace Discount.Services
{
    public class CityService
{  
    private readonly DiscountContext _context;
    public CityService(DiscountContext context)
    {
        _context = context;
    }
    public IEnumerable<City>? GetAll()
    {
        return _context.Cities;
    }
    public City? GetById(int id)
    {
        return _context.Cities.FirstOrDefault( p => p.CityId == id);
    }
    public City? GetByName(string query)
    {
        return _context.Cities.FirstOrDefault( p => p.CityName.ToLower() == query.ToLower());
    }
    public City Add(City city)
    {
        _context.Cities.Add(city);
        _context.SaveChanges();
        return city;
    }
    public void Remove(int id)
    {
        var toBeRemoved = _context.Cities.Find(id);

        if(toBeRemoved is null)
        return;

        _context.Cities.Remove(toBeRemoved);
        _context.SaveChanges();
    }

}
}