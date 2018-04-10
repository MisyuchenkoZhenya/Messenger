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
    class ChatRepository : IChatRepository
    {
        private MessengerContext db;

        public ChatRepository(MessengerContext context)
        {
            db = context;
        }

        public void Create(Chat item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Chat> GetAll()
        {
            throw new NotImplementedException();
        }

        public Chat GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Chat> GetChatsByUserId(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Chat item)
        {
            throw new NotImplementedException();
        }
    }
}
