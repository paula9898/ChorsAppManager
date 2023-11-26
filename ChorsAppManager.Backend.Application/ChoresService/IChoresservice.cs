using ChorsAppManager.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorsAppManager.Backend.Application.ChoresService
{
    public interface IChoresService
    {
        ICollection<Chore> GetAllChores();
        Chore GetChoreById(int choreId);
    }
}
