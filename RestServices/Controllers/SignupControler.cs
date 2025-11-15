using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SignupControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private static List<UserModel> Users = new List<UserModel>();

        // Register user
        [HttpPost("register")]
        public IActionResult Register(UserModel student)
        {
            // Check if username exists
            if (Users.Any(u => u.Username == student.Username))
            {
                return BadRequest("Username already exists");
            }

            Users.Add(student); // Save user into list

            return Ok(new
            {
                message = "Registered Successfully",
                student
            });
        }

        // Login user
        [HttpPost("login")]
        public IActionResult Login(LoginModel login)
        {
            var user = Users
                .FirstOrDefault(x => x.Username == login.Username && x.Password == login.Password);

            if (user == null)
                return BadRequest("Invalid Credentials");

            // Record login time
            user.LoginTime = DateTime.Now;

            return Ok(new
            {
                message = "Login Successful",
                user
            });
        }

        // Get all users
        [HttpGet("all")]
        public IActionResult GetAllAccounts()
        {
            var result = Users.Select(u => new
            {
                u.FullName,
                u.Username,
                u.Email,
                u.Address,
                u.District,
                LoginTime = u.LoginTime.HasValue ? u.LoginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : null
            }).ToList();

            return Ok(result);
        }
    }

    // User model
    public class UserModel
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public DateTime? LoginTime { get; set; }
    }

    // Login model
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
