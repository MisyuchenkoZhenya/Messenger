using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.DAL.Models;

namespace Messenger.DAL.Interfaces
{
    interface IChatRepository
    {
        IQueryable<Chat> GetChats();
        Chat GetChatById(int Id);
        IQueryable<Chat> GetChatsByUserId(int Id);
        void CreateChat(Chat chat);
        void UpdateChat(Chat chat);
        void DeleteChat(int Id);
    }
}
