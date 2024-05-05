using Journy.Model;
using Journy.Model.features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using BCrypt.Net;
using Journey.Model;

namespace Journey_it.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly JourneyContext _context;
        private readonly IConfiguration _configuration;

        public PostController(JourneyContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePost(CreatePostRequest request)
        {
            var username = User.FindFirst(TokenClaimsConstant.Username).Value;
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var post = new Post
            {
                Texts = request.Texts,
                Title = request.Title,
                CountryId = request.CountryId,
                UserId = user.Id
            };

            
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                                        "uploads", user.Id.ToString(),
                                        $"{post.Id}_{request.ImagePath.FileName}");

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await request.ImagePath.CopyToAsync(stream);
            }

            post.ImgPath = $"uploads/{user.Id}/{post.Id}_{request.ImagePath.FileName}";
            _context.Posts.Add(post);
            

            _context.SaveChanges();

            return Ok(new PostCreatedResponse { Id = post.Id});
        }
        [HttpGet("myposts")]
        public IActionResult GetMyPosts()
        {
            var username = User.FindFirst(TokenClaimsConstant.Username).Value;
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var posts = _context.Posts.Where(p => p.UserId == user.Id)
                                      .Select(p => new PostResponse
                                      {
                                         Id =  p.Id,
                                          Text = p.Texts,
                                         Title =  p.Title,
                                         ImagePath = p.ImgPath
                                      })
                                      .ToList();

            return Ok(posts);
        }

    }
}
