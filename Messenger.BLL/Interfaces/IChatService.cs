using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.BLL.DTO;

namespace Messenger.BLL.Interfaces
{
    public interface IChatService : IService
    {
        IEnumerable<ChatDTO> GetChats(string userId);
        ChatDTO GetFullChat(int chatId);
        void EditChat(ChatDTO chatDto);
        void AddChatUser(UserToChatDTO utc);
        void DeleteChatUser(UserToChatDTO utc);
        Task<bool> CreateChat(ChatDTO chatDto);
    }
}
