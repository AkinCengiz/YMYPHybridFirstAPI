using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYPHybridFirst.Dto;
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

    [HttpGet("getallproductdetails")]
    public IActionResult GetAllProductDetails()
    {
        using (var context = new NorthwindContext())
        {
            var products = (from c in context.Categories
                join p in context.Products on c.CategoryId equals p.CategoryId
                join s in context.Suppliers on p.SupplierId equals s.SupplierId
                select new GetAllProductDetailsResponseDTO()
                {
                    Id = p.ProductId,
                    CategoryName = c.CategoryName,
                    Name = p.ProductName,
                    SupplierName = s.CompanyName,
                    QuantityPerUnit = p.QuantityPerUnit,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock
                }).ToList();
            return Ok(products);
        }
    }
}
