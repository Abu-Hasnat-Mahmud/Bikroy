using Application.Interfaces;
using Domain.Models;
using Domain.ViewModels;
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

        public async Task<Post> Add(PostVM post)
        {
            Post newPost = MappingPost(post);

            await _postRepository.Add(newPost);
            return newPost;
        }


        public async Task Delete(Post post) => await _postRepository.Delete(post);

        public async Task<IEnumerable<Post>> Get() => await _postRepository.Get();

        public async Task<Post> Get(int id) => await _postRepository.Get(id);

        public async Task<IEnumerable<Post>> GetUserPost(int userId) => await _postRepository.GetUserPost(userId);
        public async Task<IEnumerable<Post>> Search(string searchText) => await _postRepository.Search(searchText);

        public async Task<Post> Put(PostVM newPost)
        {           
            var data = await _postRepository.Get(newPost.PostId);

            var post = MappingPost(newPost);

            data.ProductName = post?.ProductName;
            data.Price = post?.Price ?? 0;
            data.Description = post?.Description;

            await _postRepository.Put(data);

            if (post?.Tags != null)
            {
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
            }

            return data;
        }


        // Not used Auto Mapping package for simple API
        private Post MappingPost(PostVM post)
        {
            if (post !=null)
            {
                Post newPost = new()
                {
                    PostId = post.PostId,
                    ProductName = post.ProductName,
                    Price = post.Price,
                    Description = post.Description,
                    PostDate = post.PostDate,
                    UserId = post.UserId,
                    Tags = new List<Tags>(),
                   
                };

                foreach (var item in post.Tags)
                {
                    Tags tags = new() { Id= item.Id, Name= item.Name, PostId=item.PostId,  };
                    newPost.Tags.Add(tags);                
                }


                return newPost;
            }

            return null;
        }


    }
}
