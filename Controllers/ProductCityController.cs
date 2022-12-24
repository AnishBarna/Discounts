using Discount.Models;
using Microsoft.AspNetCore.Mvc;

using Discount.Services;

namespace Discount.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCityController : ControllerBase
    {
        ProductCityService _productcityservice;
        KeyService _keyservice;

        CityService _cityservice;
        ProductService _productservice;

        public ProductCityController(ProductCityService pcservice, KeyService kservice , ProductService pservice , CityService cservice)
        {
            _productcityservice = pcservice;
            _keyservice = kservice;
            _cityservice = cservice;
            _productservice = pservice;

        }


        [HttpGet]
        public IEnumerable<ProductCity>? Get()
        {
            return _productcityservice.Get();
        }

        [HttpPost]
        public IActionResult Add(ProductCity productCity)
        {
            var city = _cityservice.GetById(productCity.CityId);
            var product = _productservice.GetById(productCity.ProductId);

            if(city is null)
            {
                return BadRequest("City does not exist.");

            }

            if(product is null)
            {
                return BadRequest("Product does not exist");

                
            }

            productCity.Id = _keyservice.GetProductCityId();

            return Ok(_productcityservice.AddProductCity(productCity));

            
        }
        

        [HttpDelete]
        public IActionResult Remove(int productcityid)
        {
            var toBeRemoved = _productcityservice.GetById(productcityid);

            if(toBeRemoved is not null)
            {
                _productcityservice.Remove(productcityid);
                return NoContent();
            }

            return BadRequest("ProductCity not found.");
        }
    }
}