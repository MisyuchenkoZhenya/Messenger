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
        public bool disposed = false;

        public IUnitOfWork Database { get; set; }


        public UserService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void AddContact(UserToUserDTO userDto)
        {
            User firstUser = Database.Users.GetById(userDto.FirstUserId);
            User secondUser = Database.Users.GetById(userDto.SecondUserId);
            firstUser.Contacts.Add(secondUser);
            secondUser.Contacts.Add(firstUser);
            Database.Save();
        }

        public void DeleteContact(UserToUserDTO userDto)
        {
            User firstUser = Database.Users.GetWithInclude(userDto.FirstUserId, u => u.Contacts);
            User secondUser = Database.Users.GetWithInclude(userDto.SecondUserId, u => u.Contacts);
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
            var user = Database.Users.GetById(id);
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
            var userDTO = Mapper.Map<User, UserDTO>(user);

            return userDTO;
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void LoginUser(UserAccountDTO userDto)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(UserAccountDTO userDto)
        {            
            Mapper.Initialize(cfg => cfg.CreateMap<UserAccountDTO, User>());
            var user = Mapper.Map<UserAccountDTO, User>(userDto);
            Database.Users.Create(user);
            Database.Save();
        }

        public void UpdateUser(UserDTO userDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserDTO, User>());
            var user = Mapper.Map<UserDTO, User>(userDto);
            Database.Users.Update(user);
            Database.Save();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Database.Dispose();
                }
                disposed = true;
            }
        }

        ~UserService()
        {
            Dispose(false);
        }
    }
}
