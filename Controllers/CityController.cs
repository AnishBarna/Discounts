using Discount.Models;
using Microsoft.AspNetCore.Mvc;

using Discount.Services;

namespace Discount.Controllers
{
    [ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    CityService _cityservice;

    public CityController(CityService service)
    {
        _cityservice = service;
    }

    [HttpGet]
    public ActionResult _Get()
    {
        var cities = _cityservice.GetAll();
        
        if(cities is null)
        {
            return NotFound();
        }
        
        return Ok(cities);
    }

    [HttpGet("byid/{id}")]
    public ActionResult _GetById(int id)
    {
        var city = _cityservice.GetById(id);

        if(city is null)
        {
            return NotFound();
        }

        return Ok(city);

    }

    [HttpGet("byname/{query}")]
    public ActionResult _GetByName(string query)
    {
        var city = _cityservice.GetByName(query);

        if(city is null)
        {
            return NotFound();
        }

        return Ok(city);
    }

    [HttpPost]
    public ActionResult _AddCity(City city)
    {
        _cityservice.Add(city);
        return CreatedAtAction(nameof(_AddCity),city);

    }

    [HttpDelete("{id}")]
    public ActionResult _RemoveCity(int id)
    {
        var city = _cityservice.GetById(id);

        if(city is null)
        {
            return NotFound();

        }

        _cityservice.Remove(id);

        return NoContent();
    }



}
}

