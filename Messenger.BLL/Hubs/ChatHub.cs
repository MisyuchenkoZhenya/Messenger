using Messenger.DAL.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.BLL.Services;
using Messenger.DAL.Repository;
using Messenger.BLL.DTO;

namespace Messenger.BLL.Hubs
{
    public class ChatHub : Hub
    {
        private MessageService messageService;

        public ChatHub()
        {
            messageService = new MessageService(new UnitOfWork());
        }
        
        public async Task Send(dynamic content, string roomName)
        {
            MessageDTO messageDTO = new MessageDTO
            {
                Author = content.authorId,
                Content = content.message,
                CreatedAt = DateTime.Now,
                Type = content.message_type,
                ChatId = int.Parse(roomName)
            };
            messageService.SendMessage(messageDTO);
            content.createdAt = messageDTO.CreatedAt;
            content.author = Context.User.Identity.Name;

            Clients.Group(roomName).addChatMessage(content);
        }
        
        public async Task Connect(string roomName)
        {
            await Groups.Add(Context.ConnectionId, roomName);
            Clients.Group(roomName).addChatMessage(new { message = Context.User.Identity.Name + " joined.", message_type = "Info" });
        }

        public async Task Disconnect(string roomName)
        {
            await Groups.Remove(Context.ConnectionId, roomName);
            Clients.Group(roomName).addChatMessage(new { message = Context.User.Identity.Name + " disconnected.", message_type = "Info" });
        }
    }
}
