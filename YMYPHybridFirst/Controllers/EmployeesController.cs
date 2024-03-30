using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYPHybridFirst.Models;

namespace YMYPHybridFirst.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        using (var context = new NorthwindContext())
        {
            var result = context.Employees.FirstOrDefault(e => e.EmployeeId == id);
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
            var result = context.Employees.ToList();
            if (result == null)
            {
                return NotFound("Page not found");
            }

            return Ok(result);
        }
    }
}
