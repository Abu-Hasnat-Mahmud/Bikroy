using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bikroy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostBL _PostBL;
        public PostController(IPostBL PostBL)
        {
            _PostBL = PostBL;
        }

        // GET: api/<PostController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> Get()
        {
            var posts= await _PostBL.Get();
            return Ok(posts);
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            var post = await _PostBL.Get(id);
            if (post == null)
                return BadRequest("Post not found!");

            return Ok(post);
        }

       
        [HttpGet]
        public async Task<ActionResult<Post>> GetUserPost(int userId)
        {
            var post = await _PostBL.GetUserPost(userId);
            return Ok(post);
        }



        // POST api/<PostController>
        [HttpPost]
        public async Task<ActionResult> AddPost(Post post)
        {
            try
            {
                await _PostBL.Add(post);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Post request)
        {
            try
            {
                if (id != request.PostId)
                    return BadRequest();

                var Post = await _PostBL.Put(request);
                return Ok(Post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var Post = await _PostBL.Get(id);
                if (Post == null)
                    return BadRequest("Post not found!");

                await _PostBL.Delete(Post);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }
            
        }
    }
}
