using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorsAppManager.Backend.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Chore> Chores { get; set;}//ICollection

    }
}
