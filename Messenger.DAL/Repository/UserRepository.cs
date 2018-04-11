using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DAL.Interfaces;
using Messenger.DAL.Context;
using Messenger.DAL.Models;
using System.Data.Entity;

namespace Messenger.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private MessengerContext db;

        public UserRepository(MessengerContext context)
        {
            db = context;
        }

        public void Create(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsersByChatId(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsersByContactId(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
