using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> employees = new List<Employee>() {new Employee(
            name: "Default Employee",
            jobTitle: "Unemployed",
            salary: 0
        )};

        [HttpGet]
        public IEnumerable<Employee> ListEmployees()
        {
            return employees;
        }
    }
}