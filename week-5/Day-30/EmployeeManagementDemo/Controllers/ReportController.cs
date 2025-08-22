using Microsoft.AspNetCore.Mvc;
using EmployeeManagementDemo.Filters;

namespace EmployeeManagementDemo.Controllers
{
    public class ReportController : Controller
    {
        [HttpGet("reports/salary")]
        [ServiceFilter(typeof(ManagerAuthorizationFilter))]
        public IActionResult Salary() => Content("Salary report: [confidential]");
    }
}