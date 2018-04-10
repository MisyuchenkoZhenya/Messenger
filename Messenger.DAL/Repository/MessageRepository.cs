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

        public MessageRepository()
        {
            db = new MessengerContext();
        }

        public void CreateMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Message> GetMessages()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Message> GetMessagesByChatId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
