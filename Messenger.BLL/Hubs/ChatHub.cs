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

            Clients.Group(roomName).addChatMessage(content.message);
        }
        
        public async Task Connect(string roomName)
        {
            await Groups.Add(Context.ConnectionId, roomName);
            Clients.Group(roomName).addChatMessage(Context.User.Identity.Name + " joined.");
        }

        public async Task Disconnect(string roomName)
        {
            await Groups.Remove(Context.ConnectionId, roomName);
            Clients.Group(roomName).addChatMessage(Context.User.Identity.Name + " disconnected.");
        }

        //// Отключение пользователя
        //public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        //{

        //    return base.OnDisconnected(stopCalled);
        //}
    }
}
