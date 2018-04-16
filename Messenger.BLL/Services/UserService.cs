using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.BLL.DTO;
using Messenger.BLL.Interfaces;
using Messenger.DAL.Interfaces;
using Messenger.DAL.Models;

namespace Messenger.BLL.Services
{
    class UserService : IUserService
    {
        public IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void AddContact(UserToUserDTO user)
        {
            User firstUser = Database.Users.GetById(user.FirstUserId);
            User secondUser = Database.Users.GetById(user.SecondUserId);
            firstUser.Contacts.Add(secondUser);
            secondUser.Contacts.Add(firstUser);

            Database.Save();
        }

        public void DeleteContact(UserToUserDTO user)
        {
            User firstUser = Database.Users.GetWithInclude(user.FirstUserId, u => u.Contacts);
            User secondUser = Database.Users.GetWithInclude(user.SecondUserId, u => u.Contacts);
            firstUser.Contacts.Remove(secondUser);
            secondUser.Contacts.Remove(firstUser);

            Database.Save();
        }

        public IEnumerable<UserDTO> GetContacts(int id)
        {
            //IEnumerable<User> users = Database.Users.GetWithInclude(id, u => u.Contacts).Contacts;
            throw new NotImplementedException();
        }

        public UserDTO GetFullUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void LoginUser(UserAccountDTO user)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(UserAccountDTO user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
