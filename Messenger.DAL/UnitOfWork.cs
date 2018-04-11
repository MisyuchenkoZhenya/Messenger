using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DAL.Context;
using Messenger.DAL.Repository;

namespace Messenger.DAL
{
    public class UnitOfWork : IDisposable
    {
        private MessengerContext db;
        private ChatRepository chatRepository;
        private MessageRepository messageRepository;
        private MessageTypeRepository messageTypeRepository;
        private UserRepository userRepository;

        public UnitOfWork()
        {
            db = new MessengerContext();
        }

        public ChatRepository Chats
        {
            get
            {
                if (chatRepository == null)
                    chatRepository = new ChatRepository(db);

                return chatRepository;
            }
        }

        public MessageRepository Messages
        {
            get
            {
                if (messageRepository == null)
                    messageRepository = new MessageRepository(db);

                return messageRepository;
            }
        }

        public MessageTypeRepository MessageTypes
        {
            get
            {
                if (messageTypeRepository == null)
                    messageTypeRepository = new MessageTypeRepository(db);

                return messageTypeRepository;
            }
        }

        public UserRepository Users
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

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
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
