using Application.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;


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



        /// <summary>
        /// Get Conversation
        /// </summary>
        /// <param name="senderId"></param>
        /// <param name="receiverId"></param>
        /// <returns>Conversation between Buyer and Seller</returns>

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




        /// <summary>
        /// Send message between Seller and Buyer
        /// </summary>
        /// <param name="message"></param>
        /// <returns>Newly create message</returns>
        /// <response code="200">Returns the newly created message</response>
        /// <response code="400">If the message not send.</response>
        [HttpPost("SendMessage")]
        public async Task<ActionResult> SendMessage(MessageVM message)
        {
            try
            {
                var msg = await _messageBL.SendMessage(message);

                if (msg == null)
                    return BadRequest("The message not send!!");

                return Ok(msg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Block buyer
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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



        /// <summary>
        /// Delete message
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
