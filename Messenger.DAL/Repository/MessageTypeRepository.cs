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

        public MessageTypeRepository()
        {
            db = new MessengerContext();
        }

        public void CreateMessageType(MessageType messageType)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessageType(int Id)
        {
            throw new NotImplementedException();
        }

        public MessageType GetMessageTypeById(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<MessageType> GetMessageTypes()
        {
            throw new NotImplementedException();
        }
    }
}
