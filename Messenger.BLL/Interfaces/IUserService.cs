using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.BLL.DTO;
using Messenger.BLL.Identity.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Messenger.BLL.Interfaces
{
    public interface IUserService : IService
    {
        Task<IdentityResult> RegisterUser(RegisterDTO userDto, ApplicationUserManager userManager, ApplicationSignInManager signInManager);
        Task<SignInStatus> LoginUser(LoginDTO userDto, ApplicationSignInManager signInManager);
        IEnumerable<UserDTO> GetUsers();
        UserDTO GetFullUser(string id);
        void UpdateUser(UserDTO userDto);
        IEnumerable<UserDTO> GetContacts(string id);
        void AddContact(UserToUserDTO userDto);
        void DeleteContact(UserToUserDTO userDto);
    }
}
