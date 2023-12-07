using ChorsAppManager.Backend.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorsAppManager.Backend.Application.RegistrationUserService
{
    public interface IRegisterService
    {
        Task<bool> RegisterUser(UserDto userDto);
    }
}
