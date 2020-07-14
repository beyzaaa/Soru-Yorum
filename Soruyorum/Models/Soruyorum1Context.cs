using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soruyorum.Models
{
    public class Soruyorum1Context: DbContext
    {
        public Soruyorum1Context(DbContextOptions<Soruyorum1Context> options) : base(options) { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
