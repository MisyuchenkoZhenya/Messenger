﻿using System;
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

        public void RegisterUser(RegisterDTO userDto)
        {            
            var user = Mapper.Map<RegisterDTO, User>(userDto);
            //IdentityResult result = await AppUserManager.Create(new IdentityFactoryOptions<AppUserManager>(), Messenger.)
            //await SignInManager<User, string>.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            user.PasswordHash = new PasswordHasher().HashPassword(userDto.Password);
            Database.Users.Create(user);
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
