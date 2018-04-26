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
        IEnumerable<ChatDTO> GetChats(int userId);
        FullChatDTO GetFullChat(int chatId);
        void EditChat(ChatDTO chatDto);
        void AddChatUser(UserToChatDTO utc);
        void DeleteChatUser(UserToChatDTO utc);
        void CreateChat(ChatDTO chatDto);
    }
}
