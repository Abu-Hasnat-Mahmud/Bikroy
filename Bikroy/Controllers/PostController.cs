using Application.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bikroy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostBL _postBL;
        public PostController(IPostBL PostBL)
        {
            _postBL = PostBL;
        }

        /// <summary>
        /// Get all post
        /// </summary>
        /// <returns>Return all created post.</returns>
        // GET: api/<PostController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> Get()
        {
            var posts = await _postBL.Get();
            return Ok(posts);
        }


        /// <summary>
        /// Get specific post by PostId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            var post = await _postBL.Get(id);
            if (post == null)
                return BadRequest("Post not found!");

            return Ok(post);
        }

        /// <summary>
        /// Get selling post specific user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Return all the post of specific seller</returns>
        [HttpGet("GetUserPost")]
        public async Task<ActionResult<Post>> GetUserPost(int userId)
        {
            var post = await _postBL.GetUserPost(userId);
            return Ok(post);
        }


        /// <summary>
        /// Search post by product name and tags
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns>Return all post by matching search keyword</returns>
        [HttpGet("Search")]
        public async Task<ActionResult<Post>> Search(string searchText)
        {
            var post = await _postBL.Search(searchText);
            return Ok(post);
        }


        /// <summary>
        /// Created new selling post
        /// </summary>
        /// <param name="post"></param>
        /// <returns>Return newly created post.</returns>
        // POST api/<PostController>
        [HttpPost]
        public async Task<ActionResult> AddPost(PostVM post)
        {
            try
            {
                var newPost = await _postBL.Add(post);
                return Ok(newPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Update post info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns>Return updated post</returns>

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PostVM request)
        {
            try
            {
                if (id != request.PostId)
                    return BadRequest();

                var post = await _postBL.Put(request);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        /// <summary>
        /// Delete post by postId.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var Post = await _postBL.Get(id);
                if (Post == null)
                    return BadRequest("Post not found!");

                await _postBL.Delete(Post);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }

        }
    }
}
