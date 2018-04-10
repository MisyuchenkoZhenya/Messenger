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
    class MessageRepository : IMessageRepository
    {
        private MessengerContext db;

        public MessageRepository(MessengerContext context)
        {
            db = context;
        }

        public void Create(Message item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Message> GetAll()
        {
            throw new NotImplementedException();
        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Message> GetMessagesByChatId(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Message item)
        {
            throw new NotImplementedException();
        }
    }
}
