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

    [HttpPost]
    public IActionResult Add(Customer customer)
    {
        using (var context = new NorthwindContext())
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return Ok("Customer added");
        }
    }

    [HttpDelete]
    public IActionResult Delete(string id)
    {
        using (var context = new NorthwindContext())
        {
            Customer customer = context.Customers.FirstOrDefault(q => q.CustomerId == id);
            if (customer == null)
            {
                return NotFound("Customer found");
            }

            context.Customers.Remove(customer);
            context.SaveChanges();
            return Ok("Customer deleted success");
        }
    }

    [HttpPut]
    public IActionResult Update(Customer customer)
    {
        using (var context = new NorthwindContext())
        {
            Customer updatedCustomer = context.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if (updatedCustomer == null)
            {
                return NotFound("Customer not found");
            }
            updatedCustomer.CompanyName = customer.CompanyName;
            updatedCustomer.ContactName = customer.ContactName;
            context.SaveChanges();
            return Ok("Customer updated success");
        }
    }
}
