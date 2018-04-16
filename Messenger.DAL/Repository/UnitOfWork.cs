using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DAL.Context;
using Messenger.DAL.Interfaces;
using Messenger.DAL.Models;

namespace Messenger.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        private MessengerContext db;
        private ChatRepository chatRepository;
        private MessageRepository messageRepository;
        private MessageTypeRepository messageTypeRepository;
        private UserRepository userRepository;

        public UnitOfWork()
        {
            db = new MessengerContext();
        }

        public IRepository<Chat> Chats
        {
            get
            {
                if (chatRepository == null)
                    chatRepository = new ChatRepository(db);

                return chatRepository;
            }
        }

        public IRepository<Message> Messages
        {
            get
            {
                if (messageRepository == null)
                    messageRepository = new MessageRepository(db);

                return messageRepository;
            }
        }

        public IRepository<MessageType> MessageTypes
        {
            get
            {
                if (messageTypeRepository == null)
                    messageTypeRepository = new MessageTypeRepository(db);

                return messageTypeRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);

                return userRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
