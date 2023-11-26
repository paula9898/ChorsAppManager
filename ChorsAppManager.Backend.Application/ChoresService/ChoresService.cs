using ChorsAppManager.Backend.Application.Repository;
using ChorsAppManager.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorsAppManager.Backend.Application.ChoresService
{
    public class ChoresService : IChoresService
    {
        private readonly IRepository<Chore> _choreRepository;

        public ChoresService(IRepository<Chore> choreRepository)
        {
            _choreRepository = choreRepository;
        }

        Task<ICollection<Chore>> IChoresService.GetAllChores()
        {
            throw new NotImplementedException();
        }

        Task<Chore> IChoresService.GetChoreById(int choreId)
        {
            throw new NotImplementedException();
        }
    }
}
