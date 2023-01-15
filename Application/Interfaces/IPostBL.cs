using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPostBL
    {
        Task<IEnumerable<Post>> Get();
        Task<Post> Get(int id);
        Task<IEnumerable<Post>> GetUserPost(int userId);
        Task<IEnumerable<Post>> Search(string searchText);
        Task<Post> Add(PostVM Post);
        Task<Post> Put(PostVM Post);
        Task Delete(Post Post);
    }
}
