//here we will be creatiung a class ie LogResourceFilter class for implementing custom filter

using Microsoft.AspNetCore.Mvc.Filters; // filter package
using System.Diagnostics; // for diagnostic purposes

namespace StudentApp.Filters
{
    public class ValidateStudentFilter : IActionFilter // interface with resource filter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Log the incoming request
            Debug.WriteLine("Validating request for action : " + context.ActionDescriptor.DisplayName);
            //debug.writeline will write the log to the output window




        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Log the outgoing response
            Debug.WriteLine("Action executd : " + context.ActionDescriptor.DisplayName);
        }
    }
}




