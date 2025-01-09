using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>();
        private List<Employee> employees2 = new List<Employee>() {new Employee(
            name: "Default Employee",
            jobTitle: "Unemployed",
            salary: 0
        )};

        [HttpGet]
        public IEnumerable<Employee> ListEmployees()
        {
            return employees;
        }

        [HttpPost]
        public Employee AddEmployees([FromBody] Employee employee)
        {
            employees.Add(employee);
            return employee;
        }
    }
}