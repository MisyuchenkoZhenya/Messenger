using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.BLL.DTO;

namespace Messenger.BLL.Interfaces
{
    public interface IUserService : IService
    {
        void RegisterUser(UserAccountDTO userDto);
        void LoginUser(UserAccountDTO userDto);
        IEnumerable<UserDTO> GetUsers();
        UserDTO GetFullUser(int id);
        void UpdateUser(UserDTO userDto);
        IEnumerable<UserDTO> GetContacts(int id);
        void AddContact(UserToUserDTO userDto);
        void DeleteContact(UserToUserDTO userDto);
    }
}
