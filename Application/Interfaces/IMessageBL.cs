using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMessageBL
    {
        public Task<IEnumerable<Message>> Get();
        public Task<Message> Get(int id);
        public Task<IEnumerable<Message>> GetUserMessage(int senderId, int receiverId);        
        public Task<Message?> SendMessage(MessageVM message);
        public Task<Message> Put(Message message);
        public Task Delete(Message message);
        Task AddToBlockList(MessageBlock messageBlock);
    }
}
