using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DAL.Interfaces;
using Messenger.DAL.Context;
using Messenger.DAL.Models;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Messenger.DAL.Repository
{
    class UserRepository : IRepository<User>
    {
        private MessengerContext db;

        public UserRepository(MessengerContext context)
        {
            db = context;
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User GetById(int id)
        {
            return db.Users.Find(id);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> GetWithInclude(params Expression<Func<User, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<User> GetWithInclude(Func<User, bool> predicate, params Expression<Func<User, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        public User GetWithInclude(int id, params Expression<Func<User, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.FirstOrDefault(q => q.Id == id);
        }

        public IQueryable<User> Include(params Expression<Func<User, object>>[] includeProperties)
        {
            IQueryable<User> query = db.Users;
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
