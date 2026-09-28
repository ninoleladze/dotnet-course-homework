using _08._24._26_DI1.Models;
using Microsoft.AspNetCore.Mvc;

namespace _08._24._26_DI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        List<Employee> Employees = new List<Employee>
        {
            new Employee() { Name = "John", Position = "Manager" },
            new Employee() { Name = "Sarah", Position = "Developer" },
            new Employee() { Name = "Mike", Position = "Designer" }
        };

        [HttpGet]
        public List<Employee> GetAllEmployees()
        {
            return Employees;
        }

        [HttpGet("byIndex/{index}")]
        public Employee GetEmployeeByIndex(int index)
        {
            return Employees[index];
        }

        [HttpGet("byPosition/{position}")]
        public List<Employee> GetEmployeesByPosition(string position)
        {
            return Employees.Where(e => e.Position == position).ToList();
        }

        [HttpGet("first")]
        public Employee GetFirstEmployee()
        {
            return Employees.First();
        }

        [HttpGet("count")]
        public int GetEmployeeCount()
        {
            return Employees.Count;
        }
    }
}
