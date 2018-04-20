﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.BLL.DTO;

namespace Messenger.BLL.Interfaces
{
    interface IMessageService : IService
    {
        void SendMessage(MessageDTO message);
        void SendMedia(MessageDTO message);
        IEnumerable<MessageDTO> GetMessages(int chatId);
        void DeleteMessage(int messageId);
    }
}