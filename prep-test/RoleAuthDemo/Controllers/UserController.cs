using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using RoleAuthDemo.Models;
using System.Threading.Tasks;

namespace RoleAuthDemo.Controllers
{
    [Authorize(Roles = "User,Admin")] // both user and admin can see profile
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager) => _userManager = userManager;

        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }
    }
}
