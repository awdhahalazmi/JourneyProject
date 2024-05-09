using Journy.Model;
using Journy.Model.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using BCrypt.Net;
using Journey.Model;
using Microsoft.EntityFrameworkCore;
using Journey.Model.Requests;
using Journey.Model.Responses;

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
                return Ok(new UserLoginResponse { Token = response.Token });
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
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            var username = User.FindFirst(TokenClaimsConstant.Username).Value;
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var userProfile = new ProfileResponse
            {
                Id= user.Id,
               Name= user.Name,
                Username= user.Username,
               Email= user.Email,
               ImagePath= user.ImagePath
            };

            return Ok(userProfile);
        }


        [HttpPost("profile")]
        public async Task<IActionResult> EditProfile(EditProfileRequest request)
        {

            var username = User.FindFirst(TokenClaimsConstant.Username).Value;
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            
            user.Name = request.Name;
          //  user.Email = request.Email;

            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(),
                                        "uploads", user.Id.ToString()));

            var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                                        "uploads",user.Id.ToString(),
                                        request.Image.FileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                await request.Image.CopyToAsync(stream);
            }



            user.ImagePath = $"uploads/{user.Id}/{request.Image.FileName}";
            _context.SaveChanges();

            return Ok(new { Message = "Profile updated successfully" });
        }
        [HttpPost("follow/{userId}")]
        public IActionResult FollowUser(int userId)
        {
            var username = User.FindFirst(TokenClaimsConstant.Username).Value;
            var currentUser = _context.Users.Include(r=> r.Following).FirstOrDefault(u => u.Username == username);
            if (currentUser == null)
            {
                return NotFound("User not found");
            }

            var userToFollow = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (userToFollow == null)
            {
                return NotFound("User to follow not found");
            }

            if (currentUser.Following.Contains(userToFollow))
            {
                currentUser.Following.Remove(userToFollow);
            }
            else
            {
                currentUser.Following.Add(userToFollow);
            }

            _context.SaveChanges();

            return Ok(new { Message = "Operation completed successfully" });
        }
        [HttpGet("followers")]
        public IActionResult GetFollowers()
        {
            var username = User.FindFirst(TokenClaimsConstant.Username).Value;
            var user = _context.Users.Include(u => u.Followers).FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var followers = user.Followers.Select(f => new ProfileResponse
            {
                Id = f.Id,
                Name = f.Name,
                Username = f.Username,
                Email = f.Email,
                ImagePath = f.ImagePath
            }).ToList();

            return Ok(followers);
        }

        [HttpGet("following")]
        public IActionResult GetFollowing()
        {
            var username = User.FindFirst(TokenClaimsConstant.Username).Value;
            var user = _context.Users.Include(u => u.Following).FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var following = user.Following.Select(f => new ProfileResponse
            {
                Id = f.Id,
                Name = f.Name,
                Username = f.Username,
                Email = f.Email,
                ImagePath = f.ImagePath
            }).ToList();

            return Ok(following);
        }




    }
}
