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
        Task<IEnumerable<ChatDTO>> GetChats(string userId, bool privateOnly = false);
        ChatDTO GetFullChat(int chatId);
        IEnumerable<UserDTO> GetChatParticipants(int chatId);
        Task<bool> EditChat(ChatDTO chatDto);
        void AddChatUser(UserToChatDTO utc);
        void DeleteChatUser(UserToChatDTO utc);
        Task<int> CreateChat(ChatDTO chatDto);
    }
}
