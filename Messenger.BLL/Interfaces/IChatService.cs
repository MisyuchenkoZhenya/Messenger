﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.BLL.DTO;

namespace Messenger.BLL.Interfaces
{
    interface IChatService : IService
    {
        IEnumerable<ChatDTO> GetChats(int userId);
        ChatDTO GetFullChat(int chatId);
        void EditChatTitle(ChatDTO chatDto);
        void EditChatPhoto(ChatDTO chatDto);
        void AddChatUser(UserToChatDTO utc);
        void DeleteChatUser(UserToChatDTO utc);
        void CreateChat(ChatDTO chatDto);
    }
}