using Application.Interfaces;
using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MessageBL : IMessageBL
    {
        private readonly IMessageRepository _messageRepository;

        public MessageBL(IMessageRepository MessageRepository)
        {
            _messageRepository = MessageRepository;

        }

        public async Task<Message?> SendMessage(MessageVM message)
        {
            var isBlock = await _messageRepository.CheckBlockList(message.SenderId, message.ReceiverId);
            if (!isBlock)
            {
                Message newMessage = new()
                {
                    SenderId = message.SenderId,
                    ReceiverId = message.ReceiverId,
                    PostId=message.PostId,
                    MessageBody = message.MessageBody,
                    MessageDate= message.MessageDate,
                };

                await _messageRepository.Add(newMessage);
                return newMessage;
            }

            return null;
        }


        public async Task Delete(Message Message) => await _messageRepository.Delete(Message);

        public async Task<IEnumerable<Message>> Get() => await _messageRepository.Get();

        public async Task<Message> Get(int id) => await _messageRepository.Get(id);

        public async Task<IEnumerable<Message>> GetUserMessage(int senderId, int receiverId) => await _messageRepository.GetUserConversation(senderId, receiverId);

        public async Task<Message> Put(Message message)
        {
            var data = await _messageRepository.Get(message.MessageId);
            data.MessageBody = message.MessageBody;
            //data.MessageDate = message.MessageDate;
            await _messageRepository.Put(data);

            return data;
        }


        public async Task AddToBlockList(MessageBlock messageBlock)
        {
            await _messageRepository.AddToBlockList(messageBlock);
        }

    }
}
