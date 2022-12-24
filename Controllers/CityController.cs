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
        KeyService _keyservice;

        public CityController(CityService cservice, KeyService kservice)
        {
            _cityservice = cservice;
            _keyservice = kservice;
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
            
            if(city.CityName == "")
            {
                return BadRequest("Invalid city name.");
            }

            
            city.CityId = _keyservice.GetCityId();
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

