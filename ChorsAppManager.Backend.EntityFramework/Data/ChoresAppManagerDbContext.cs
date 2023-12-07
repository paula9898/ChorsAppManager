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
        public DbSet<User> Users { get; set; }//business domain models
        public DbSet<Chore> Chores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Paulina", Email ="otrebskapaulina@gmail.com", Password ="haslo123!", UserName ="poliwoli1976"});

            modelBuilder.Entity<Chore>().HasData(
                new Chore { Id = 1, UserId = 1, Description = "Clean the bathroom" });

        }
    }
}
