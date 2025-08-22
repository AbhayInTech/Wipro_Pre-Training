using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using EmployeeManagementDemo.Filters;
using System;



namespace EmployeeManagementDemo.Controllers
{

    [Route("orders")]
    [ServiceFilter(typeof(GlobalExceptionFilter))]
    public class OrdersController : Controller
    {
        private readonly ILogger<LoggingActionFilter> _logger;
        public OrdersController(ILogger<LoggingActionFilter> logger)
        {
            _logger = logger;
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            throw new Exception("Simulated exception for testing GlobalExceptionFilter on create function");
            //the above string that is present inside the Exception function is shown in the browser when this method is called

            return Content("All orders at Time : {DateTime.Now:HH:mm:ss}");
        }

        [HttpGet("")]
        public IActionResult Index() => throw new Exception("Simulated exception for testing GlobalExceptionFilter on index Function");


        [HttpGet("{id:int}")]
        [ServiceFilter(typeof(LoggingActionFilter))]
        public IActionResult Get(int id) => Content($"Order details for order id: {id} at Time : {DateTime.Now:HH:mm:ss}");

        //error
        [HttpGet("error")]
        public IActionResult Error() => throw new Exception("Simulated exception for testing GlobalExceptionFilter");
    }
}