using ChorsAppManager.Backend.Application.Repositories;
using ChorsAppManager.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorsAppManager.Backend.Application.ChoresServices
{
    public class ChoresService : IChoresService
    {
        private readonly IRepository<Chore> _choreRepository;

        public ChoresService(IRepository<Chore> choreRepository)
        {
            _choreRepository = choreRepository;
        }

        public async Task<ICollection<Chore>> GetAllChores()
        {
            return await _choreRepository.GetAllChores();
        }

        public async Task<Chore> GetChoreById(int choreId)
        {
            return await _choreRepository.GetChoreById(choreId);
        }
    }

}
