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
    class MessageTypeRepository : IMessageTypeRepository
    {
        private MessengerContext db;

        public MessageTypeRepository(MessengerContext context)
        {
            db = context;
        }

        public void Create(MessageType item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MessageType> GetAll()
        {
            throw new NotImplementedException();
        }

        public MessageType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(MessageType item)
        {
            throw new NotImplementedException();
        }
    }
}
