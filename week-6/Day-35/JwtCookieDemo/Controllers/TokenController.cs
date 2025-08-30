// TokenController.cs : This controller will helps us manage JWT tokens, so UI is not required 

//                      and it will be stateless



// Here is the todo for implementing this controller

// 1. Create a new controller named TokenController

// 2. Implement a method for generating JWT tokens

// 3. Implement a method for validating JWT tokens

// 4. Implement a method for refreshing JWT tokens

using Microsoft.AspNetCore.Mvc;

using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;

using System.Text;


namespace JwtCookieDemo.Controllers

{

    [ApiController]

    [Route("[controller]/[action]")]

    public class TokenController : ControllerBase

    {

        private readonly IConfiguration _configuration; // Inject IConfiguration in constructor so that we can access appsettings.json



        public TokenController(IConfiguration configuration) //Here we are injecting IConfiguration for accessing appsettings.json

        {

            _configuration = configuration;

        }



        //Here i want to implement the methods for managing JWT tokens ie GetTokens() with hard coded user , roles and dept values

        [HttpGet]

        public IActionResult GetTokens()

        {

            var token = GenerateJwtToken("JohnDoe", "Admin", "IT");

            return Ok(new { token });

        }

        //to call GenerateJwtToken() we can use below method as eg 

        //token/GenerateJwtToken

        private string GenerateJwtToken(string username, string role, string department)

        {

            var claims = new[]

            {

                new Claim(ClaimTypes.Name, username),

                new Claim(ClaimTypes.Role, role),

                new Claim("department", department)

            };




            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Your_Secret_Key_Here"));

            //Here we are creating a symmetric security key

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // use HMAC SHA256 algorithm HMACSHA256 is a symmetric encryption algorithm




            //Here we are creating a JWT token string that can be used for authentication

            //Here we can use cookie authentication as well by following steps

            //Step 1: Create a cookie with the JWT token

            // var cookieOptions = new CookieOptions

            // {

            //     HttpOnly = true,

            //     Expires = DateTimeOffset.UtcNow.AddMinutes(30)

            // };

            // Response.Cookies.Append("jwt", token, cookieOptions);




            // Step 2: Return the JWT token as a response

            // return Ok(new { token });

            // Step 3: Use the JWT token for authentication in subsequent requests



            var token = new JwtSecurityToken(

                issuer: _configuration["Jwt:Issuer"], // this is referenced from appsettings.json using _configuration

                audience: _configuration["Jwt:Audience"],

                claims: claims,

                expires: DateTime.Now.AddMinutes(30), // duration of token validity

                signingCredentials: creds

            );

            //finally we can use it 

            return new JwtSecurityTokenHandler().WriteToken(token);

            // returning the token as string so that it can be used in the authorization header of http requests

        }

    }

}





