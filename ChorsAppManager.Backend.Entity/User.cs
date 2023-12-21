using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorsAppManager.Backend.Model
{
    public class User : IdentityUser<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        public string UserName { get; set; }
        public ICollection<Chore> Chores { get; set;}//ICollection
    }
}
