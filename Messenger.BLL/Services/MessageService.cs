using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.BLL.DTO;
using Messenger.BLL.Interfaces;
using Messenger.DAL.Interfaces;
using Messenger.DAL.Models;
using AutoMapper;

namespace Messenger.BLL.Services
{
    public class MessageService : IMessageService
    {
        private bool disposed = false;

        public IUnitOfWork Database { get; set; }


        public MessageService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void DeleteMessage(int messageId)
        {
            Database.Messages.Delete(messageId);
            Database.Save();
        }

        public IEnumerable<MessageDTO> GetMessages(int chatId)
        {
            var messages = Database.Chats.GetWithInclude(chatId, c => c.Messages, 
                                                                 c => c.Messages.Select(m => m.Type),
                                                                 c => c.Messages.Select(m => m.Author)).Messages;
            var messagesDto = Mapper.Map<IEnumerable<Message>, List<MessageDTO>>(messages);

            return messagesDto;
        }

        public void SendMedia(MessageDTO message)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(MessageDTO message)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Database.Dispose();
                }
                disposed = true;
            }
        }

        ~MessageService()
        {
            Dispose(false);
        }
    }
}
