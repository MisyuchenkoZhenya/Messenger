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
    public class MessageTypeRepository : IMessageTypeRepository
    {
        private MessengerContext db;

        public MessageTypeRepository(MessengerContext context)
        {
            db = context;
        }

        public void Create(MessageType messageType)
        {
            db.MessageTypes.Add(messageType);
        }

        public void Delete(int id)
        {
            MessageType messageType = db.MessageTypes.Find(id);
            if (messageType != null)
                db.MessageTypes.Remove(messageType);
        }

        public IEnumerable<MessageType> GetAll()
        {
            return db.MessageTypes;
        }

        public MessageType GetById(int id)
        {
            return db.MessageTypes.Find(id);
        }

        public void Update(MessageType messageType)
        {
            db.Entry(messageType).State = EntityState.Modified;
        }
    }
}
