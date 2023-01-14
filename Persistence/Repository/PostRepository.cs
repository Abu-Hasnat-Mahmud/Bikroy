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

        public async Task<IEnumerable<Post>> Get() => await _dBContext.Post.Include(a => a.Tags).ToListAsync();

        public async Task<Post> Get(int id) => await _dBContext.Post.Include(a => a.Tags).FirstOrDefaultAsync(a => a.PostId == id);

        public async Task<IEnumerable<Post>> GetUserPost(int userId)
            => await _dBContext.Post.Include(a => a.Tags).AsNoTracking().Where(a => a.UserId == userId).ToListAsync();

        public async Task<IEnumerable<Post>> Search(string search)
        {
            var param = new SqlParameter("@search", search);

            var posts = await _dBContext.Post.FromSqlRaw("EXEC [ProductSearch] @search", param).ToListAsync();
            return posts;
        }



        public async Task Put(Post Post)
        {
            _dBContext.Post.Update(Post);
            await _dBContext.SaveChangesAsync();
        }
    }
}
