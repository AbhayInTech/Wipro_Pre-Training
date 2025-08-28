// Here i want to show content of the database table
using DatabaseFirstDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDirectoryDbContext _context;

        public EmployeeController(EmployeeDirectoryDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();
            return View(employees);
        }
    }
}