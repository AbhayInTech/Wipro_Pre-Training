using Microsoft.AspNetCore.Mvc;
using Assignment2MvcApp.Models;

namespace Assignment2MvcApp.Controllers
{
    /// <summary>
    /// UserController demonstrates MVC pattern and model binding
    /// This controller handles user input through forms and displays submitted data
    /// </summary>
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// GET: /User/Create
        /// Displays the form for creating a new user (simple model binding)
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            // Return empty User model to the view for form binding
            return View(new User());
        }

        /// <summary>
        /// POST: /User/Create
        /// Handles form submission with model binding for simple types
        /// Demonstrates basic model binding with validation
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            // Check if model state is valid (model binding successful)
            if (ModelState.IsValid)
            {
                // Log successful model binding
                _logger.LogInformation($"User created: {user.FullName}, Age: {user.Age}");

                // Store user data in TempData for display on success page
                TempData["UserData"] = $"Name: {user.FullName}, Age: {user.Age}";

                // Redirect to success page
                return RedirectToAction("Success");
            }

            // If model binding failed, return to form with validation errors
            return View(user);
        }

        /// <summary>
        /// GET: /User/CreateWithAddress
        /// Displays the form for creating a user with address (complex model binding)
        /// </summary>
        [HttpGet]
        public IActionResult CreateWithAddress()
        {
            // Return empty User model with initialized Address for form binding
            return View(new User());
        }

        /// <summary>
        /// POST: /User/CreateWithAddress
        /// Handles form submission with model binding for complex types
        /// Demonstrates nested model binding with validation
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateWithAddress(User user)
        {
            // Check if model state is valid (model binding successful for both simple and complex types)
            if (ModelState.IsValid)
            {
                // Log successful complex model binding
                _logger.LogInformation($"User with address created: {user.FullName}, Address: {user.Address.FullAddress}");

                // Store user data in TempData for display on success page
                TempData["UserData"] = $"Name: {user.FullName}, Age: {user.Age}";
                TempData["AddressData"] = $"Address: {user.Address.FullAddress}";

                // Redirect to success page
                return RedirectToAction("Success");
            }

            // If model binding failed, return to form with validation errors
            return View(user);
        }

        /// <summary>
        /// GET: /User/Success
        /// Displays success page with submitted data
        /// </summary>
        [HttpGet]
        public IActionResult Success()
        {
            // Retrieve data from TempData
            ViewBag.UserData = TempData["UserData"];
            ViewBag.AddressData = TempData["AddressData"];

            return View();
        }

        /// <summary>
        /// GET: /User/Index
        /// Index page explaining the MVC pattern and model binding concepts
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
