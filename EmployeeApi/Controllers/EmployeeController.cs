using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>();

        [HttpGet]
        public IEnumerable<Employee> ListEmployees()
        {
            return employees;
        }

        [HttpPost]

        public Employee Post([FromBody] Employee employee)
        {
            employees.Add(employee);
            return employee;
        }
    }
}