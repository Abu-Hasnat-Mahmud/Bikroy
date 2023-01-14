using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DAL
{
    public class DBContext : DbContext
    {       
        public DBContext(DbContextOptions<DBContext> options) : base(options){ }

        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Tags> Tags { get; set; }

    }
}
