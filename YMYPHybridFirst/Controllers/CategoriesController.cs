using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYPHybridFirst.Models;

namespace YMYPHybridFirst.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    [HttpGet("getbyid/{id}")]
    public IActionResult GetById(int id)
    {
        using (var context = new NorthwindContext())
        {
            var result = context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (result == null)
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
            var result = context.Categories.ToList();
            if (result is null)
            {
                return NotFound("Page not found");
            }

            return Ok(result);
        }
    }
}
