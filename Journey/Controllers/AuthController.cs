using Journy.Model;
using Journy.Model.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using BCrypt.Net;

namespace Journey_it.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _service;
        private readonly JourneyContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(TokenService service, JourneyContext context, IConfiguration configuration)
        {
            _service = service;
            _context = context;
            _configuration = configuration;
        }


        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginDetails)
        {
            var response = _service.GenerateToken(loginDetails.Username, loginDetails.Password);
            if (response.IsValid)
            {
                return Ok(new { Token = response.Token });
            }
            return BadRequest("Username and/or Password is wrong");
        }

        [HttpPost("signup")]
        public IActionResult Signup(SignUpRequest request)
        {
            if (_context.Users.Any(u => u.Username == request.Username))
            {
                return Conflict("Username already exists");
            }

            var newUser = UserAccount.Create(request.Username,
                                      request.Password,
                                      request.IsAdmin);
            newUser.Email = request.Email;

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return Ok(new { Message = "User Created" });
        }
    }
}
