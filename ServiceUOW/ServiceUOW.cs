using System;
using Messenger.BLL.Interfaces;
using Messenger.BLL.Services;
using Messenger.DAL.Repository;

namespace ServiceUOW
{
    public class ServiceUOW : IDisposable
    {
        private bool disposed = false;

        private UnitOfWork unitOfWork;

        private IChatService chatService;
        private IMessageService messageService;
        private IUserService userService;


        public ServiceUOW()
        {
            unitOfWork = new UnitOfWork();
        }

        public IChatService ChatService {
            get
            {
                if (chatService == null)
                    chatService = new ChatService(unitOfWork);

                return chatService;
            }
        }

        public IMessageService MessageService
        {
            get
            {
                if (messageService == null)
                    messageService = new MessageService(unitOfWork);

                return messageService;
            }
        }

        public IUserService UserService
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
