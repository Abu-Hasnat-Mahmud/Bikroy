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
    public class TagsRepository : ITagsRepository
    {
        private readonly DBContext _dBContext;
        public TagsRepository(DBContext dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task Add(Tags Tags)
        {
            _dBContext.Tags.Add(Tags);
            await _dBContext.SaveChangesAsync();
        }

        public async Task Add(List<Tags> Tags)
        {
            await _dBContext.Tags.AddRangeAsync(Tags);
            await _dBContext.SaveChangesAsync();
        }



        public async Task Delete(Tags Tags)
        {
            _dBContext.Remove(Tags);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tags>> Get() => await _dBContext.Tags.ToListAsync();

        public async Task<Tags> Get(int id) => await _dBContext.Tags.FindAsync(id);

        public async Task Put(Tags Tags)
        {
            _dBContext.Tags.Update(Tags);
            await _dBContext.SaveChangesAsync();
        }

        public async Task Put(List<Tags> Tags)
        {
            _dBContext.Tags.UpdateRange(Tags);
            await _dBContext.SaveChangesAsync();
        }


    }
}
