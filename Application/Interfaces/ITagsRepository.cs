using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITagsRepository
    {
        public Task<IEnumerable<Tags>> Get();
        public Task<Tags> Get(int id);
        public Task Add(Tags Tags);
        public Task Add(List<Tags> Tags);
        public Task Put(Tags Tags);
        public Task Put(List<Tags> Tags);
        public Task Delete(Tags Tags);
    }
}
