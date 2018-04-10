using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DAL.Models;

namespace Messenger.DAL.Interfaces
{
    interface IMessageTypeRepository
    {
        IQueryable<MessageType> GetMessageTypes();
        MessageType GetMessageTypeById(int Id);
        void CreateMessageType(MessageType messageType);
        void DeleteMessageType(int Id);
    }
}
