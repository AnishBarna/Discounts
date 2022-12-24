using Discount.Models;
using Discount.Services;
using Microsoft.AspNetCore.Mvc;

namespace Rex_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeyController : ControllerBase
    {
    KeyService keyservice;

    public KeyController(KeyService service)
    {
        keyservice = service;
        
    }

    [HttpGet]
    public ActionResult _GetAll()
    {
        return Ok(keyservice.GetAll());
    }
    
    }

    
}