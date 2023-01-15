using Application.Interfaces;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DBContext _dBContext;
        public MessageRepository(DBContext dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task Add(Message Message)
        {
            _dBContext.Message.Add(Message);
            await _dBContext.SaveChangesAsync();
        }

        public async Task Delete(Message Message)
        {
            _dBContext.Remove(Message);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Message>> Get() => await _dBContext.Message.ToListAsync();

        public async Task<Message> Get(int id) => await _dBContext.Message.FirstOrDefaultAsync(a => a.MessageId == id);

        public async Task<IEnumerable<Message>> GetUserConversation(int senderId, int receiverId)
            => await _dBContext.Message.AsNoTracking().Where(a => (a.SenderId == senderId && a.ReceiverId == receiverId) || (a.SenderId == receiverId && a.ReceiverId == senderId)).ToListAsync();
               
        public async Task Put(Message Message)
        {
            _dBContext.Message.Update(Message);
            await _dBContext.SaveChangesAsync();
        }


        public async Task AddToBlockList(MessageBlock messageBlock)
        {
            await _dBContext.MessageBlock.AddAsync(messageBlock);
            await _dBContext.SaveChangesAsync();
        }

        public async Task UnBlockUser(MessageBlock messageBlock)
        {
            _dBContext.MessageBlock.Update(messageBlock);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<bool> CheckBlockList(int senderId, int receiverId)
        {
            return await _dBContext.MessageBlock
                .AnyAsync(a => (a.UserId == senderId && a.BlockUserId == receiverId) 
                    || (a.UserId == receiverId && a.BlockUserId == senderId));

        }




    }
}
