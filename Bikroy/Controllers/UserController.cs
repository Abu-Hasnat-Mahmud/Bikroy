using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bikroy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;
        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var users= await _userBL.Get();
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _userBL.Get(id);
            if (user == null)
                return BadRequest("User not found!");

            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            try
            {
                await _userBL.Add(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] User request)
        {
            try
            {
                if (id != request.UserId)
                    return BadRequest();

                var user = await _userBL.Put(request);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var user = await _userBL.Get(id);
                if (user == null)
                    return BadRequest("User not found!");

                await _userBL.Delete(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }
            
        }
    }
}
