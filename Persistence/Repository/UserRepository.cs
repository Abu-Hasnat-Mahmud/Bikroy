using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _dBContext;
        public UserRepository(DBContext dbContext)
        {
            _dBContext= dbContext;
        }

        public async Task Add(User user)
        {
            _dBContext.User.Add(user);
            await _dBContext.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _dBContext.Remove(user);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> Get() => await _dBContext.User.ToListAsync();

        public async Task<User> Get(int id) => await _dBContext.User.FindAsync(id);

        public async Task Put(User user)
        {
            _dBContext.User.Update(user);
            await _dBContext.SaveChangesAsync();
        }
    }
}
