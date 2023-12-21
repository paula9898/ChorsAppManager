
using ChorsAppManager.Backend.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorsAppManager.Backend.Application.RegistrationUserService
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<User> _userManager;

        public RegisterService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> RegisterUser(UserDto model)
        {
            if(string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                throw new ArgumentException("Incorrect Login or password");
            }
            if(model.Password !=model.ConfirmedPassword )
            {
                throw new ArgumentException("Password and confirm password does not match");
            }
                
            var user = new User
            {
                UserName = model.UserName,

                //Password = model.Password,

                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            return result.Succeeded;
        }
    }

}
