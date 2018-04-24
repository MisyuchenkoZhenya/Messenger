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
    public class ChatService : IChatService
    {
        private bool disposed = false;

        public IUnitOfWork Database { get; set; }


        public ChatService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void AddChatUser(UserToChatDTO utc)
        {
            var user = Database.Users.GetById(utc.UserId);
            Database.Chats.GetById(utc.ChatId).Participants.Add(user);
            Database.Save();
        }

        public void CreateChat(ChatDTO chatDto)
        {
            User admin = Database.Users.GetById(chatDto.AdminId);
            Mapper.Initialize(cfg => cfg.CreateMap<ChatDTO, Chat>()
                                        .ForMember("Admin", opt => opt.MapFrom(c => admin)));
            User user = Mapper.Map<ChatDTO, User>(chatDto);
            Database.Save();
        }

        public void DeleteChatUser(UserToChatDTO utc)
        {
            User user = Database.Users.GetById(utc.UserId);
            Chat chat = Database.Chats.GetWithInclude(utc.ChatId, c => c.Participants);
            chat.Participants.Remove(user);
            Database.Save();
        }

        public void EditChatPhoto(ChatDTO chatDto)
        {
            throw new NotImplementedException();
        }

        public void EditChatTitle(ChatDTO chatDto)
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
        
        ~ChatService()
        {
            Dispose(false);
        }
    }
}
