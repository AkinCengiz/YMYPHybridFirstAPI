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

    [HttpPost]
    public IActionResult Create(Supplier supplier)
    {
        using (var context = new NorthwindContext())
        {
            context.Suppliers.Add(supplier);
            context.SaveChanges();
            return Ok("Created supplier success");
        }
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        using (var context = new NorthwindContext())
        {
            Supplier supplier = context.Suppliers.FirstOrDefault(s => s.SupplierId == id);
            if (supplier == null)
            {
                return NotFound("Supplier not found");
            }
            context.Suppliers.Remove(supplier);
            context.SaveChanges();
            return Ok("Supplier deleted success");
        }
    }

    [HttpPut]
    public IActionResult Update(Supplier supplier)
    {
        using (var context = new NorthwindContext())
        {
            Supplier updatedSupplier = context.Suppliers.FirstOrDefault(s => s.SupplierId == supplier.SupplierId);
            if (updatedSupplier == null)
            {
                return NotFound("Supplier not found");
            }

            updatedSupplier.CompanyName = supplier.CompanyName;
            updatedSupplier.ContactName = supplier.ContactName;
            updatedSupplier.ContactTitle = supplier.ContactTitle;
            context.SaveChanges();
            return Ok("Supplier updated success");
        }
    }
}
