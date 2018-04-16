using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.BLL.DTO;
using Messenger.BLL.Interfaces;
using Messenger.DAL.Interfaces;

namespace Messenger.BLL.Services
{
    class MessageService : IMessageService
    {
        public IUnitOfWork Database { get; set; }

        public MessageService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void DeleteMessage(int messageId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MessageDTO> GetMessages(int chatId)
        {
            throw new NotImplementedException();
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
            Database.Dispose();
        }
    }
}
