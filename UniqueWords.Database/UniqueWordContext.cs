using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqueWords.Database.Models;

namespace UniqueWords.Database
{
    public class UniqueWordContext : DbContext
    {
        public UniqueWordContext(DbContextOptions<UniqueWordContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<UniqueWordList> UniqueWordList { get; set; }
        public DbSet<WatchList> WatchList { get; set; }
    }
}
