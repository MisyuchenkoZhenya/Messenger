using Messenger.DAL.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.BLL.Hubs
{
    public class ChatHub : Hub
    {
        // Отправка сообщений
        public void Send(string message)
        {
            Clients.All.AppendMessage(message);
        }

        //// Подключение нового пользователя
        //public void Connect(string userName)
        //{

        //}

        //// Отключение пользователя
        //public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        //{

        //    return base.OnDisconnected(stopCalled);
        //}
    }
}
