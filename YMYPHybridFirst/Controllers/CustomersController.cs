using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYPHybridFirst.Models;

namespace YMYPHybridFirst.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        using (var context = new NorthwindContext())
        {
            var result = context.Customers.FirstOrDefault(c => c.CustomerId == id);
            return Ok(result);
        }
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        using (var context = new NorthwindContext())
        {
            var categories = context.Customers.ToList();
            return Ok(categories);
        }
    }
}
