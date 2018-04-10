using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DAL.Models;

namespace Messenger.DAL.Interfaces
{
    interface IUserRepository
    {
        IQueryable<User> GetUsers();
        User GetUserById(int Id);
        IQueryable<User> GetUsersByChatId(int Id);
        IQueryable<User> GetUsersByContactId(int Id);
        void CreateUser(User chat);
        void UpdateUser(User chat);
        void DeleteUser(int Id);
    }
}
