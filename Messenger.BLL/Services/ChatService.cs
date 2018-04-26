﻿using System;
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
            Chat chat = Mapper.Map<ChatDTO, Chat>(chatDto);
            chat.Admin = admin;
            Database.Save();
        }

        public void DeleteChatUser(UserToChatDTO utc)
        {
            User user = Database.Users.GetById(utc.UserId);
            Chat chat = Database.Chats.GetWithInclude(utc.ChatId, 
                                                      c => c.Participants);
            chat.Participants.Remove(user);
            Database.Save();
        }

        public void EditChat(ChatDTO chatDto)
        {
            Chat chat = Database.Chats.GetById(chatDto.Id);
            chat = Mapper.Map<ChatDTO, Chat>(chatDto);
            Database.Save();
        }

        public IEnumerable<ChatDTO> GetChats(int userId)
        {
            var chats = Database.Users.GetWithInclude(userId, 
                                                      u => u.Chats,
                                                      u => u.Chats.Select(c => c.Admin)).Chats;
            var chatsDto = Mapper.Map<IEnumerable<Chat>, List<ChatDTO>>(chats);

            return chatsDto;
        }

        public FullChatDTO GetFullChat(int chatId)
        {
            Chat chat = Database.Chats.GetWithInclude(chatId, 
                                                      c => c.Admin,
                                                      c => c.Messages,
                                                      c => c.Participants);
            FullChatDTO chatDTO = Mapper.Map<Chat, FullChatDTO>(chat);

            return chatDTO;
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
