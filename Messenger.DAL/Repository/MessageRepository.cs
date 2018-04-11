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
    public class MessageRepository : IMessageRepository
    {
        private MessengerContext db;

        public MessageRepository(MessengerContext context)
        {
            db = context;
        }

        public void Create(Message message)
        {
            db.Messages.Add(message);
        }

        public void Delete(int id)
        {
            Message message = db.Messages.Find(id);
            if (message != null)
                db.Messages.Remove(message);
        }

        public IEnumerable<Message> GetAll()
        {
            return db.Messages
                    .Include(m => m.Author)
                    .Include(m => m.Chat)
                    .Include(m => m.Type)
                    .ToList();
        }

        public Message GetById(int id)
        {
            return db.Messages.Find(id);
                    //.Include(m => m.Author)
                    //.Include(m => m.Chat)
                    //.Include(m => m.Type)
                    //.FirstOrDefault(m => m.Id == id);
        }

        public void Update(Message message)
        {
            db.Entry(message).State = EntityState.Modified;
        }

        public IEnumerable<Message> GetMessagesByChatId(int id)
        {
            return db.Messages
                    .Include(m => m.Author)
                    .Include(m => m.Chat)
                    .Include(m => m.Type)
                    .Where(m => m.Chat.Id == id);
        }
    }
}
