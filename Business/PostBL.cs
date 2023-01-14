using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PostBL : IPostBL
    {
        private readonly IPostRepository _postRepository;
        private readonly ITagsRepository _tagRepository;
        public PostBL(IPostRepository postRepository, ITagsRepository tagsRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagsRepository;
        }

        public async Task Add(Post post) => await _postRepository.Add(post);

        public async Task Delete(Post post) => await _postRepository.Delete(post);

        public async Task<IEnumerable<Post>> Get() => await _postRepository.Get();

        public async Task<Post> Get(int id) => await _postRepository.Get(id);

        public async Task<IEnumerable<Post>> GetUserPost(int userId) => await _postRepository.GetUserPost(userId);

        public async Task<Post> Put(Post post)
        {
            var data = await _postRepository.Get(post.PostId);
            data.ProductName = post.ProductName;
            data.Description = post.Description;

            await _postRepository.Put(data);

            foreach (var item in post.Tags)
            {
                if (item.Id > 0)
                {
                    await _tagRepository.Put(item);
                }
                else
                {
                    await _tagRepository.Add(item);
                }
            }

            return data;
        }

    }
}
