using Microsoft.AspNetCore.Authorization;
using Miccrosoft.AspNetCore.Mvc;

namespace Controllers
{
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("Student/details")]
        [Authorize]
        public IActionResult Details()
        {
            return Ok("Student details can only be sseen by authorised user");
        }
    }
}