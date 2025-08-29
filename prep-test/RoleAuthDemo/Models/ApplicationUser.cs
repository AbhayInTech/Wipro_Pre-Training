using Microsoft.AspNetCore.Identity;

namespace RoleAuthDemo.Models
{
    public class ApplicationUser : IdentityUser
    {
        // add extra profile fields if needed
        public string DisplayName { get; set; }
    }
}
