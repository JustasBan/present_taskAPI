using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API_internship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            List<Post> posts;

            try
            {
                posts = await ApiHelper<Post>.GetAll("https://jsonplaceholder.typicode.com/posts");
            }
            catch (FailedGetException)
            {
                return BadRequest("Failed request");
            }

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            Post post;

            try
            {
                post = await ApiHelper<Post>.GetOne
                        (string.Concat("https://jsonplaceholder.typicode.com/posts/", id.ToString()));

            }
            catch (FailedGetException)
            {
                return BadRequest("Failed request");
            }

            return Ok(post);
        }

        [HttpPost()]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            Post result;

            try
            { 
                 result = await ApiHelper<Post>.PostOne
                    (post, "https://jsonplaceholder.typicode.com/posts/");
            }
            catch (FailedPostException)
            {
                return BadRequest("Failed request");
            }
            catch (EmptyFieldsException)
            {
                return BadRequest("Fill in all fields");
            }
            
            return Ok(result);            
        }
    }
}
