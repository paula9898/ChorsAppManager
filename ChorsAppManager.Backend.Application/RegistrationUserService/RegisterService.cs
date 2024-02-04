
using ChorsAppManager.Backend.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            if(model.Password !=model.ConfirmPassword )
            {
                throw new ArgumentException("Password and confirm password does not match");
            }
            if (string.IsNullOrWhiteSpace(model.UserName)) // <-- There is no way around this.
            {
                throw new ArgumentException("Username incorrect or null");
            }

            var identityErrors = new List<IdentityError>();
            await ValidateUserName(_userManager, new User { UserName = model.UserName }, identityErrors, new IdentityErrorDescriber());

            // Check if there are any errors and throw an exception if validation fails
            if (identityErrors.Any())
            {
                var errorMessages = identityErrors.Select(error => error.Description);
                throw new ArgumentException($"Username validation failed: {string.Join(", ", errorMessages)}");
            }


            var user = new User
            {
                UserName = model.UserName,

                FirstName = model.FirstName,

                //Password = model.Password,

                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            return result.Succeeded;
        }

        private async Task ValidateUserName(UserManager<User> manager, User model, ICollection<IdentityError> errors, IdentityErrorDescriber identityErrorDescriber)
        {
            var userName = await manager.GetUserNameAsync(model);
            if (string.IsNullOrWhiteSpace(userName)) // <-- There is no way around this.
            {

                errors.Add(identityErrorDescriber.InvalidUserName(userName));
            }
            else if (!string.IsNullOrEmpty(manager.Options.User.AllowedUserNameCharacters) &&
                userName.Any(c => !manager.Options.User.AllowedUserNameCharacters.Contains(c)))
            {
                errors.Add(identityErrorDescriber.InvalidUserName(userName));
            }
            else
            {
                var owner = await manager.FindByNameAsync(userName);
                if (owner != null &&
                    !string.Equals(await manager.GetUserIdAsync(owner), await manager.GetUserIdAsync(model)))
                {
                    errors.Add(identityErrorDescriber.DuplicateUserName(userName));
                }
            }
        }
    }

}
