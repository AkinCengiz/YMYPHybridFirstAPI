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

    [HttpPost("add")]
    public IActionResult Add(Employee employee)
    {
        using (var context = new NorthwindContext())
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return Ok();
        }
    }

    //[HttpPost("update")]
    //public IActionResult Update(Employee employee)
    //{
    //    using (var context = new NorthwindContext())
    //    {
    //        context.Employees.Update(employee);
    //        context.SaveChanges();
    //        return Ok();
    //    }
    //}

    [HttpDelete("{Id}")]
    public IActionResult Delete(int id)
    {
        using (var context = new NorthwindContext())
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }
            context.Employees.Remove(employee);
            context.SaveChanges();
            return Ok("Employee deleted success");
        }
    }

    [HttpPut]
    public IActionResult Update(Employee employee)
    {
        using (var context = new NorthwindContext())
        {
            Employee updatedEmployee = context.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
            updatedEmployee.FirstName = employee.FirstName;
            updatedEmployee.LastName = employee.LastName;
            updatedEmployee.Title = employee.Title;
            context.SaveChanges();
            return Ok("Updated success");
        }
    }
}
