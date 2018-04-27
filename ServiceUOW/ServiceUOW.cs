using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.BLL.Services;
using Messenger.BLL.Interfaces;
using Messenger.DAL.Repository;
using Messenger.DAL.Interfaces;

namespace ServiceUOW
{
    public class ServiceUOW : IDisposable
    {
        private bool disposed = false;

        private UnitOfWork unitOfWork;

        private ChatService chatService;
        private MessageService messageService;
        private UserService userService;


        public ServiceUOW()
        {
            unitOfWork = new UnitOfWork();
        }

        public ChatService ChatService {
            get
            {
                if (chatService == null)
                    chatService = new ChatService(unitOfWork);

                return chatService;
            }
        }

        public MessageService MessageService
        {
            get
            {
                if (messageService == null)
                    messageService = new MessageService(unitOfWork);

                return messageService;
            }
        }

        public UserService UserService
        {
            get
            {
                if (userService == null)
                    userService = new UserService(unitOfWork);

                return userService;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    unitOfWork.Dispose();
                    if(chatService != null)
                        chatService.Dispose();
                    if (messageService != null)
                        messageService.Dispose();
                    if (userService != null)
                        userService.Dispose();
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
