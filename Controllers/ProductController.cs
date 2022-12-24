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
    ProductService _productservice;
    CityService _cityservice;
    KeyService _keyservice;

    public ProductController(ProductService pservice, CityService cservice, KeyService kservice)
    {
        _productservice = pservice;
        _cityservice = cservice;

        _keyservice = kservice;
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
        var tobeadded = _productservice.GetById(product.ProductId);
        
        if(tobeadded is not null)
        {
            return BadRequest("Product already exists.");
        }

        product.Id = _keyservice.GetProductId();

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

