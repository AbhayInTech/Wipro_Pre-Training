using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleAuthDemo.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RoleAuthDemo.Controllers
{
    [Authorize(Roles = "Admin")] // only admins
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db) => _db = db;

        public async Task<IActionResult> Dashboard()
        {
            // show list of users (example)
            var users = await _db.Users.ToListAsync();
            return View(users);
        }
    }
}
