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
    public class PostRepository : IPostRepository
    {
        private readonly DBContext _dBContext;
        public PostRepository(DBContext dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task Add(Post Post)
        {
            _dBContext.Post.Add(Post);
            await _dBContext.SaveChangesAsync();
        }

        public async Task Delete(Post Post)
        {
            _dBContext.Remove(Post);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> Get() => await _dBContext.Post.ToListAsync();

        public async Task<Post> Get(int id) => await _dBContext.Post.FindAsync(id);

        public async Task<IEnumerable<Post>> GetUserPost(int userId)
            => await _dBContext.Post.AsNoTracking().Where(a => a.UserId == userId).ToListAsync();

        public async Task<IEnumerable<Post>> Get(string search)
        {
            string filter = $"%{search}%";
            var data = await _dBContext.Post.AsNoTracking()
                //.Include(a=>a.Tags)
                .Where(a => EF.Functions.Like(a.ProductName, filter)
                    //a.Tags.Select(c=> EF.Functions.Like(c.Name, filter))
                    )

                .ToListAsync();
            return data;
        }



        public async Task Put(Post Post)
        {
            _dBContext.Post.Update(Post);
            await _dBContext.SaveChangesAsync();
        }
    }
}
