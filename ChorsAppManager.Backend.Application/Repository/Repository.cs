using ChorsAppManager.Backend.EntityFramework.Data;
using ChorsAppManager.Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorsAppManager.Backend.Application.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ChoresAppManagerDbContext _choresAppManagerDbContext;

        public Repository(ChoresAppManagerDbContext choresAppManagerDbContext)
        {
            _choresAppManagerDbContext = choresAppManagerDbContext;
        }

        public async Task<ICollection<T>> GetAllChores()
        {
            return await _choresAppManagerDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetChoreById(int id)
        {
            return await _choresAppManagerDbContext.Set<T>().FindAsync(id);
        }
    }
}
