﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPostBL
    {
        public Task<IEnumerable<Post>> Get();
        public Task<Post> Get(int id);
        public Task<IEnumerable<Post>> GetUserPost(int userId);
        public Task<IEnumerable<Post>> Search(string searchText);
        public Task Add(Post Post);
        public Task<Post> Put(Post Post);
        public Task Delete(Post Post);
    }
}
