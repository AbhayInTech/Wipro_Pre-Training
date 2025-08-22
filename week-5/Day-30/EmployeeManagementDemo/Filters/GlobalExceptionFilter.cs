using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagementDemo.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var problem = new ProblemDetails // It helps to format the error response in a standard way
            {
                Title = "An error occurred while processing your request.",
                Detail = context.Exception.Message,
                Status = 500,
                Instance = context.HttpContext.Request.Path
            };
            context.Result = new ObjectResult(problem)
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}