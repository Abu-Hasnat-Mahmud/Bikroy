using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMessageRepository
    {
        public Task<IEnumerable<Message>> Get();
        public Task<Message> Get(int id);
        public Task<IEnumerable<Message>> GetUserConversation(int senderId, int receiverId);       
        public Task Add(Message Message);
        public Task Put(Message Message);
        public Task Delete(Message Message);
        Task AddToBlockList(MessageBlock messageBlock);
        Task UnBlockUser(MessageBlock messageBlock);
        Task<bool> CheckBlockList(int senderId, int receiverId);
    }
}
