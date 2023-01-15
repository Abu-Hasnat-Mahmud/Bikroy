using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bikroy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageBL _messageBL;
        public MessageController(IMessageBL MessageBL)
        {
            _messageBL = MessageBL;
        }

        //// GET: api/<MessageController>
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Message>>> Get()
        //{
        //    var Messages= await _messageBL.Get();
        //    return Ok(Messages);
        //}

        //// GET api/<MessageController>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Message>> Get(int id)
        //{
        //    var Message = await _messageBL.Get(id);
        //    if (Message == null)
        //        return BadRequest("Message not found!");

        //    return Ok(Message);
        //}


        [HttpGet("GetUserMessage")]
        public async Task<ActionResult<Message>> GetUserMessage(int senderId, int receiverId)
        {
            if (senderId < 1 || receiverId < 1)
            {
                return BadRequest();
            }

            var messages = await _messageBL.GetUserMessage(senderId, receiverId);

            return Ok(messages);
        }




        // Message api/<MessageController>
        [HttpPost("SendMessage")]
        public async Task<ActionResult> SendMessage(Message message)
        {
            try
            {
                await _messageBL.SendMessage(message);

                if (message.MessageId < 1)
                    return BadRequest("The message not sent!!");

                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // Message api/<MessageController>
        [HttpPost("BlockUser")]
        public async Task<ActionResult> BlockUser(MessageBlock request)
        {
            try
            {
                await _messageBL.AddToBlockList(request);
                
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        //// PUT api/<MessageController>/5
        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(int id, [FromBody] Message request)
        //{
        //    try
        //    {
        //        if (id != request.MessageId)
        //            return BadRequest();

        //        var message = await _messageBL.Put(request);
        //        return Ok(message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var message = await _messageBL.Get(id);
                if (message == null)
                    return BadRequest("Message not found!");

                await _messageBL.Delete(message);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); ;
            }

        }
    }
}
