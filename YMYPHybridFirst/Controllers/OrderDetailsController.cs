using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYPHybridFirst.Models;

namespace YMYPHybridFirst.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderDetailsController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        using (var context = new NorthwindContext())
        {
            var result = context.OrderDetails.FirstOrDefault(o => o.OrderId == id);
            return Ok(result);
        }
    }
}
