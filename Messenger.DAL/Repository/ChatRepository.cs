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
    public class ChatRepository : IChatRepository
    {
        private MessengerContext db;

        public ChatRepository(MessengerContext context)
        {
            db = context;
        }

        public void Create(Chat chat)
        {
            db.Chats.Add(chat);
        }

        public void Delete(int id)
        {
            Chat chat = db.Chats.Find(id);
            if (chat != null)
                db.Chats.Remove(chat);
        }

        public IEnumerable<Chat> GetAll()
        {
            return db.Chats
                    .Include(c => c.Admin)
                    .Include(c => c.Participants)
                    .Include(c => c.Messages);
        }

        public Chat GetById(int id)
        {
            return db.Chats
                    .Include(c => c.Admin)
                    .Include(c => c.Participants)
                    .Include(c => c.Messages)
                    .FirstOrDefault(c => c.Id == id);
        }

        public void Update(Chat chat)
        {
            db.Entry(chat).State = EntityState.Modified;
        }

        public IEnumerable<Chat> GetChatsByUserId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
