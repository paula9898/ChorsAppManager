using ChorsAppManager.Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorsAppManager.Backend.EntityFramework.Data
{
    public class ChoresAppManagerDbContext : DbContext
    {
        public ChoresAppManagerDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Chore> Chores { get; set; }
    }
}
