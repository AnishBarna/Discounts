using Discount.Services;
using Discount.Models;
using Discount.Data;
using Microsoft.AspNetCore.Mvc;

namespace Discount.Controllers
{
    [ApiController]
    [Route("[controller]")]
public class ProductController : ControllerBase
{
    DiscountedProductService _productservice;
    CityService _cityservice;

    public ProductController(DiscountedProductService pservice, CityService cservice)
    {
        _productservice = pservice;
        _cityservice = cservice;
    }

    [HttpGet]
    public ActionResult _Get()
    {
        var products = _productservice.GetAll();
        
        if(products is null)
        {
            return NotFound();
        }
        
        return Ok(products);
    }

    [HttpGet("byid/{id:int}")]
    public ActionResult _GetById(int productid)
    {
        var product = _productservice.GetById(productid);

        if(product is null)
        {
            return NotFound();
        }

        return Ok(product);

    }

    [HttpGet("byname/{query}")]
    public ActionResult _GetByName(string query)
    {
        var product = _productservice.GetByName(query);

        if(product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }


    [HttpGet("checkdiscount/{productid}/{cityid}")]
    public ActionResult CheckDiscount(int productid, int cityid)
    {
        var city = _cityservice.GetById(cityid);
        var product = _productservice.GetById(productid);

        if(city is null || product is null)
        {
            return NotFound();
        }
        
        bool isDiscountedByCity = _productservice.isDiscountedByCity(cityid,productid);

        if(isDiscountedByCity == true)
        {
            return Ok(1);
        }
        else
        {
            return Ok(0);
        }
    }

    [HttpPost]
    public ActionResult _AddProduct(Product product)
    {
        _productservice.Add(product);
        return CreatedAtAction(nameof(_AddProduct),product);

    }




    [HttpDelete("{id}")]
    public ActionResult _RemoveProduct(int id)
    {
        var product = _productservice.GetById(id);

        if(product is null)
        {
            return NotFound();

        }

        _productservice.Remove(id);

        return NoContent();
    }

}
}

