//here we will be creatiung a class ie LogResourceFilter class for implementing custom filter

using Microsoft.AspNetCore.Mvc.Filters; // filter package
using System.Diagnostics; // for diagnostic purposes

namespace StudentApp.Filters
{
    public class LogResourceFilter : IResourceFilter // interface with resource filter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // Log the incoming request
            Debug.WriteLine("Incoming request: " + context.HttpContext.Request.Path);
            //debug.writeline will write the log to the output window
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // Log the outgoing response
            Debug.WriteLine("Outgoing response: " + context.HttpContext.Response.StatusCode);
        }
    }
}




