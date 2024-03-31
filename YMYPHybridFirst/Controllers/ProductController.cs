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

    [HttpPost("add")]
    public IActionResult Add(Product product)
    {
        using (var context = new NorthwindContext())
        {
            context.Products.Add(product);
            context.SaveChanges();
            return Ok();
        }
    }

    [HttpPost("update")]
    public IActionResult Update(Product product)
    {
        using (var context = new NorthwindContext())
        {
            context.Products.Update(product);
            context.SaveChanges();
            return Ok();
        }
    }
}
