using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace EmployeeManagementDemo.Filters
{
    public class ManagerAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var role = context.HttpContext.Request.Headers["X-Role"].ToString();

            if (!string.Equals(role, "Manager", StringComparison.OrdinalIgnoreCase))

            {

                context.Result = new ContentResult { StatusCode = 403, Content = "Forbidden: Manager role required." };

            }
        }
    }
}