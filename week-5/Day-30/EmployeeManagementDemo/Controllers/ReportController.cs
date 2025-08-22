using Microsoft.AspNetCore.Mvc;
using EmployeeManagementDemo.Filters;

namespace EmployeeManagementDemo.Controllers
{
    [ApiController]
    [Route("reports")]
    public class ReportController : ControllerBase
    {
        [HttpGet("salary")]
        [ServiceFilter(typeof(ManagerAuthorizationFilter))]
        public IActionResult Salary() => Content("Salary report: [confidential]");
    }
}