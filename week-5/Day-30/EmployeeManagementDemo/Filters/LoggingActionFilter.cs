using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace EmployeeManagementDemo.Filters
{


    public class LoggingActionFilter : IActionFilter
    {
        private readonly ILogger<LoggingActionFilter> _logger;

        public LoggingActionFilter(ILogger<LoggingActionFilter> logger) => _logger = logger;

        // Step1: input Validation we are doing
        // Step2: Start measuring Time and Logging
        // Step3: End Measuring Tie and Logging
        // Step4: log Result

        // Implementing required interface method
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // You can add pre-action logic here if needed
        }

        // This method is not part of IActionFilter, but is for async filters.
        public async Task OnActionExecutionAsync(ActionExecutingContext ctx, ActionExecutionDelegate next)
        {
            // Simple input guard
            if (ctx.ActionArguments.TryGetValue("id", out var val) &&
                val is int id && id <= 0)

            {
                ctx.Result = new BadRequestObjectResult("Order id must be > 0");
                return;
            }

            Console.WriteLine($"Before Action Execution : {val}");

            var sw = Stopwatch.StartNew();
            _logger.LogInformation("Action start: {Action}", ctx.ActionDescriptor.DisplayName);
            var executed = await next();
            sw.Stop();
            _logger.LogInformation("Action end: {Action} in {Ms}ms", ctx.ActionDescriptor.DisplayName, sw.ElapsedMilliseconds);

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Action {context.ActionDescriptor.DisplayName} executed with result: {context.Result?.GetType().Name ?? "No Result"} at {DateTime.Now:HH:mm:ss}");
        }


    }
}