using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.BLL.DTO;
using Messenger.BLL.Interfaces;
using Messenger.DAL.Interfaces;
using Messenger.DAL.Models;
using AutoMapper;

namespace Messenger.BLL.Services
{
    public class UserService : IUserService
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
            var users = Database.Users.GetWithInclude(id, u => u.Contacts).Contacts;
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
            var usersDTO = Mapper.Map<IEnumerable<User>, List<UserDTO>>(users);

            return usersDTO;
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
