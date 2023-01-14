using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> Get();
        public Task<User> Get(int id);
        public Task Add(User user);
        public Task Put(User user);
        public Task Delete(User user);
    }
}
