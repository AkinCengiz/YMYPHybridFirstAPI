using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYPHybridFirst.Models;

namespace YMYPHybridFirst.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    [HttpGet("{id}")]
    public Product Get(int id)
    {
        using (var context = new NorthwindContext())
        {
            return context.Products.FirstOrDefault(p => p.ProductId == id);
        }

    }

    [HttpGet("getallproduct")]
    public List<Product> GetProduct()
    {
        using (var context = new NorthwindContext())
        {
            var result = context.Products.ToList();
            return result;
        }
    }
}
