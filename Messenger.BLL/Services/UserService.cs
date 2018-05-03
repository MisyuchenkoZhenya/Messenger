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
using Messenger.BLL.Identity.Managers;

namespace Messenger.BLL.Services
{
    public class UserService : IUserService
    {
        private bool disposed = false;
        
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

        public IEnumerable<UserDTO> GetContacts(string id)
        {
            var users = Database.Users.GetWithInclude(id, u => u.Contacts).Contacts;
            var usersDTO = Mapper.Map<IEnumerable<User>, List<UserDTO>>(users);

            return usersDTO;
        }

        public IEnumerable<ChatDTO> GetChats(string id)
        {
            var chats = Database.Users.GetWithInclude(id, u => u.Chats).Chats;
            var chatsDTO = Mapper.Map<IEnumerable<Chat>, List<ChatDTO>>(chats);

            return chatsDTO;
        }

        public Task<UserDTO> GetFullUser(string id)
        {
            return Task.Run(() => {
                var user = Database.Users.GetById(id);
                var userDTO = Mapper.Map<User, UserDTO>(user);

                return userDTO;
            });
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> RegisterUser(RegisterDTO userDto, ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            var user = Mapper.Map<RegisterDTO, User>(userDto);
            user.UserName = userDto.Email;

            var result = await userManager.CreateAsync(user, userDto.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }

            return result;
        }

        public async Task<SignInStatus> LoginUser(LoginDTO userDto, ApplicationSignInManager signInManager)
        {
            var result = await signInManager.PasswordSignInAsync(userDto.Email, userDto.Password, userDto.RememberMe, shouldLockout: false);           

            return result;
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
