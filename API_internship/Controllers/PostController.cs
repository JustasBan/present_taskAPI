using Microsoft.AspNetCore.Cors;
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
                posts = PostsListHelper.Posts();
            }
            catch (FailedGetException)
            {
                return BadRequest("Failed GET request");
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
                post = PostsListHelper.Posts().Find(x => x.Id == id);

                if(post != null)
                    return Ok(post);

                return BadRequest("Failed GET request");
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

                PostsListHelper.Record(result);
            }
            catch (FailedPostException)
            {
                return BadRequest("Failed POST request");
            }
            
            return Ok(PostsListHelper.Posts().Last());            
        }
    }
}
