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
    class ChatService : IChatService
    {
        public IUnitOfWork Database { get; set; }

        public ChatService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void AddChatUser(UserToChatDTO utc)
        {
            throw new NotImplementedException();
        }

        public void CreateChat(ChatDTO chat)
        {
            throw new NotImplementedException();
        }

        public void DeleteChatUser(UserToChatDTO utc)
        {
            throw new NotImplementedException();
        }

        public void EditChatPhoto(ChatDTO chat)
        {
            throw new NotImplementedException();
        }

        public void EditChatTitle(ChatDTO chat)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChatDTO> GetChats(int userId)
        {
            throw new NotImplementedException();
        }

        public ChatDTO GetFullChat(int chatId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
