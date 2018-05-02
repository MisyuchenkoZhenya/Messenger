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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Messenger.BLL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Messenger.DAL.Context;
using Microsoft.Owin;
using System.Net;
using Microsoft.Owin.Security;

namespace Messenger.BLL.Services
{
    public class UserService : IUserService
    {
        private bool disposed = false;

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public IUnitOfWork Database { get; set; }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager;// ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager;// ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


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

        public IEnumerable<UserDTO> GetContacts(string id)
        {
            var users = Database.Users.GetWithInclude(id, u => u.Contacts).Contacts;
            var usersDTO = Mapper.Map<IEnumerable<User>, List<UserDTO>>(users);

            return usersDTO;
        }

        public UserDTO GetFullUser(string id)
        {
            var user = Database.Users.GetById(id);
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

        public async void RegisterUser(RegisterDTO userDto)
        {

            var user = Mapper.Map<RegisterDTO, User>(userDto);
            user.PasswordHash = new PasswordHasher().HashPassword(userDto.Password);

            var result = await UserManager.CreateAsync(user, userDto.Password);

            //var appDbContext = new IOwinContext().Get<ApplicationDbContext>();
            //Database.Users.Create(user);

            Database.Save();
        }

        public void UpdateUser(UserDTO userDto)
        {
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
