using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYPHybridFirst.Models;

namespace YMYPHybridFirst.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SuppliersController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        using (var context = new NorthwindContext())
        {
            var result = context.Suppliers.FirstOrDefault(s => s.SupplierId == id);
            if (result is null)
            {
                return NotFound("Page not found");
            }

            return Ok(result);
        }
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        using (var context = new NorthwindContext())
        {
            var result = context.Suppliers.ToList();
            if (result == null)
            {
                NotFound("Page not found");
            }

            return Ok(result);
        }
    }
}
