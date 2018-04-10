using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DAL.Interfaces;
using Messenger.DAL.Context;
using Messenger.DAL.Models;

namespace Messenger.DAL.Repository
{
    class UserRepository : IUserRepository
    {
        private MessengerContext db;

        public UserRepository()
        {
            db = new MessengerContext();
        }

        public void CreateUser(User chat)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetUsersByChatId(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetUsersByContactId(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User chat)
        {
            throw new NotImplementedException();
        }
    }
}
