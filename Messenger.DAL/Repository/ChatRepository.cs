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

        public ChatRepository()
        {
            db = new MessengerContext();
        }

        public void CreateChat(Chat chat)
        {
            throw new NotImplementedException();
        }

        public void DeleteChat(int Id)
        {
            throw new NotImplementedException();
        }

        public Chat GetChatById(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Chat> GetChats()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Chat> GetChatsByUserId(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateChat(Chat chat)
        {
            throw new NotImplementedException();
        }
    }
}
