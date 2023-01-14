using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepository _userRepository;
        public UserBL(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Add(User user) => await _userRepository.Add(user);

        public async Task Delete(User user) => await _userRepository.Delete(user);

        public async Task<IEnumerable<User>> Get() => await _userRepository.Get();

        public async Task<User> Get(int id) => await _userRepository.Get(id);

        public async Task<User> Put(User user)
        {
            var data = await _userRepository.Get(user.UserId);
            data.Email= user.Email;
            data.Name=user.Name; 
            await _userRepository.Put(data);
            
            return data;
        }

    }
}
