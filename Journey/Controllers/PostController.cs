using Journy.Model;
using Journy.Model.features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using BCrypt.Net;
using Journey.Model.Requests;
using Journey.Model.Responses;

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

            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(),
                                        "uploads", user.Id.ToString()
                                        ));
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
        [HttpGet("randomposts/{countryId?}")]
        public IActionResult GetRandomPosts(int? countryId = null)
        {
            var username = User.FindFirst(TokenClaimsConstant.Username).Value;
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            IQueryable<Post> postsQuery = _context.Posts.Where(p => p.UserId != user.Id);

            if (countryId.HasValue)
            {
                postsQuery = postsQuery.Where(p => p.CountryId == countryId.Value);
            }

            var posts = postsQuery.Select(p => new PostResponse
            {
                Id = p.Id,
                Text = p.Texts,
                Title = p.Title,
                ImagePath = p.ImgPath,
                AverageRatings = p.AverageRating

            })
            .ToList();

            var rnd = new Random();
            posts = posts.OrderBy(x => rnd.Next()).ToList();

            return Ok(posts);
        }
        [HttpPost("pin/{postId}")]
        public IActionResult PinPost(int postId)
        {
            var username = User.FindFirst(TokenClaimsConstant.Username).Value;
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var postToPin = _context.Posts.FirstOrDefault(p => p.Id == postId);
            if (postToPin == null)
            {
                return NotFound("Post not found");
            }

            var existingPin = _context.Pins.FirstOrDefault(p => p.UserId == user.Id && p.Posts.Any(post => post.Id == postId));

            if (existingPin != null)
            {
                existingPin.Posts.Remove(postToPin);
            }
            else
            {
                var pin = new Pin
                {
                    UserId = user.Id,
                    Users = user,
                    Posts = new List<Post> { postToPin }
                };
                _context.Pins.Add(pin);
            }

            _context.SaveChanges();

            return Ok(new { Message = "Operation completed successfully" });
        }

        [HttpGet("pinnedposts")]
        public IActionResult GetPinnedPosts()
        {
            var username = User.FindFirst(TokenClaimsConstant.Username).Value;
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var pinnedPosts = _context.Pins
                                     .Where(p => p.UserId == user.Id)
                                     .SelectMany(p => p.Posts)
                                     .Select(p => new PostResponse
                                     {
                                         Id = p.Id,
                                         Text = p.Texts,
                                         Title = p.Title,
                                         ImagePath = p.ImgPath
                                     })
                                     .ToList();

            return Ok(pinnedPosts);
        }
        [HttpPost("edit/{postId}")]
        public IActionResult EditPost(int postId, EditPostRequest request)
        {
            var username = User.FindFirst(TokenClaimsConstant.Username).Value;
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var post = _context.Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null)
            {
                return NotFound("Post not found");
            }

            if (post.UserId != user.Id)
            {
                return Unauthorized("You are not authorized to edit this post");
            }

            post.Texts = request.Texts;

            _context.SaveChanges();

            return Ok(new { Message = "Post updated successfully" });
        }

        [HttpPost("{postId}/rate")]
        public IActionResult RatePost(int postId, [FromBody] RatingRequest ratingValue)
        {
            if (ratingValue.Ratings < 1 || ratingValue.Ratings > 5)
            {
                return BadRequest("Rating value must be between 1 and 5.");
            }

            var post = _context.Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null)
            {
                return NotFound("Post not found.");
            }

            var userId = int.Parse(User.FindFirst(TokenClaimsConstant.UserId).Value);

            var existingRating = _context.Ratings.FirstOrDefault(r => r.UserId == userId && r.PostId == postId);
            if (existingRating != null)
            {
                return BadRequest("You have already rated this post.");
            }

            var newRating = new Rating { UserId = userId, PostId = postId, Value = ratingValue.Ratings };
            _context.Ratings.Add(newRating);
            _context.SaveChanges();

            var ratings = _context.Ratings.Where(r => r.PostId == postId).ToList();
            post.AverageRating = ratings.Any() ? ratings.Average(r => r.Value) : 0;
            _context.SaveChanges();

            return Ok(new { Message = "Post rated successfully." });
        }


        [HttpGet("{postId}/rating")]
        public IActionResult GetPostRating(int postId)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == postId);
            if (post == null)
            {
                return NotFound("Post not found.");
            }

            return Ok(new { AverageRating = post.AverageRating });
        }

        [HttpGet("countries")]
        public IActionResult GetCountryIds()
        {
            var countryIds = _context.Countries.ToList();
            return Ok(countryIds);
        }

    }


}

