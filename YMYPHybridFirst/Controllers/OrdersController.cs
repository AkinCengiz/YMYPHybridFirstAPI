using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYPHybridFirst.Models;

namespace YMYPHybridFirst.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        using (var context = new NorthwindContext())
        {
            var result = context.Orders.FirstOrDefault(o => o.OrderId == id);
            if (result is null)
            {
                return NotFound("Order not found...");
            }

            return Ok(result);
        }
    }

    [HttpGet("getorderdetails")]
    public IActionResult GetOrderDetails()
    {
        using (var context = new NorthwindContext())
        {
            var result = (from o in context.Orders
                join od in context.OrderDetails on o.OrderId equals od.OrderId
                join c in context.Customers on o.CustomerId equals c.CustomerId
                join p in context.Products on od.ProductId equals p.ProductId
                join ct in context.Categories on p.CategoryId equals ct.CategoryId
                join e in context.Employees on o.EmployeeId equals e.EmployeeId select new
                {
                    OrderId = o.OrderId,
                    CustumerName = c.CompanyName,
                    EmployeeName = e.FirstName + " " + e.LastName,
                    Date = o.OrderDate,
                    Category = ct.CategoryName,
                    Product = p.ProductName,
                    Price = od.UnitPrice,
                    Quantity = od.Quantity
                }).ToList();
                 

            //var result = context.OrderDetails.Where(o => o.OrderId == id).ToList();
            if (result is null)
            {
                return NotFound("Not found");
            }

            return Ok(result);
        }
    }

    [HttpGet("getbyidorderdetails/{id}")]
    public IActionResult GetOrderDetails(int id)
    {
        using (var context = new NorthwindContext())
        {
            var result = (from o in context.Orders
                join od in context.OrderDetails on o.OrderId equals od.OrderId
                join c in context.Customers on o.CustomerId equals c.CustomerId
                join p in context.Products on od.ProductId equals p.ProductId
                join ct in context.Categories on p.CategoryId equals ct.CategoryId
                join e in context.Employees on o.EmployeeId equals e.EmployeeId
                          where o.OrderId == id
                select new
                {
                    OrderId = o.OrderId,
                    CustumerName = c.CompanyName,
                    EmployeeName = e.FirstName + " " + e.LastName,
                    Date = o.OrderDate,
                    Category = ct.CategoryName,
                    Product = p.ProductName,
                    Price = od.UnitPrice,
                    Quantity = od.Quantity
                }).ToList();


            //var result = context.OrderDetails.Where(o => o.OrderId == id).ToList();
            if (result is null)
            {
                return NotFound("Not found");
            }

            return Ok(result);
        }
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        using (var context = new NorthwindContext())
        {
            var result = context.Orders.ToList();
            if (result is null)
            {
                return NotFound("Not found");
            }

            return Ok(result);
        }
    }


}
