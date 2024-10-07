using Microsoft.AspNetCore.Mvc;
using WebApplication1.model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private static List<Employee> employ = new List<Employee>
            {
            new Employee {Id=1,Name="Arun",Salary=80000},
            new Employee {Id=2,Name="Arjun",Salary=100000},
            new Employee {Id=1,Name="Arunima",Salary=80000}
            };
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Getemploy()
        {
            return Ok(employ);
        }

        [HttpGet("{id}")]
        public IActionResult Getemploy(int id)
        {
            var item = employ.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee newEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            newEmployee.Id = employ.Count + 1;
            employ.Add(newEmployee);
            return Ok($"your new employe:{newEmployee.Name}");
        }
    }
}
