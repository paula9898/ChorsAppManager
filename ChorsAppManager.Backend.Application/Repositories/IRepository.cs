using ChorsAppManager.Backend.EntityFramework.Data;
using ChorsAppManager.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorsAppManager.Backend.Application.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task <ICollection<T>> GetAllChores();
        Task <T> GetChoreById(int id);
    }
}
