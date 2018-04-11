using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DAL.Models;

namespace Messenger.DAL.Interfaces
{
    interface IMessageRepository : IRepository<Message>
    {
        IEnumerable<Message> GetMessagesByChatId(int Id);
    }
}
