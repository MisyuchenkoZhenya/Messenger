using Messenger.BLL.DTO;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Messenger.Web.Controllers
{
    public class ChatController : Controller
    {
        ServiceUOW.ServiceUOW serviceUOW;

        public ChatController()
        {
            serviceUOW = new ServiceUOW.ServiceUOW();
        }

        // GET: Chat
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Chat/AddChat
        public ActionResult AddChat()
        {
            return View();
        }

        //
        // POST: /Chat/AddChat
        [HttpPost]
        public async Task<ActionResult> AddChat(ChatDTO chatDTO, string[] users)
        {
            if (ModelState.IsValid)
            {
                chatDTO.AdminId = User.Identity.GetUserId();
                int chatId = await serviceUOW.ChatService.CreateChat(chatDTO);
                foreach(var userId in users)
                {
                    serviceUOW.ChatService.AddChatUser(new UserToChatDTO { ChatId = chatId, UserId = userId });
                }                

                return RedirectToAction("Index", "Manage");
            }

            return View(chatDTO);
        }

        //
        // GET: /Chat/GetUsersByEmail
        public async Task<string> GetUsersByEmail(string email)
        {
            var contacts = await serviceUOW.UserService.GetContacts(User.Identity.GetUserId());

            return JsonConvert.SerializeObject(contacts, Formatting.Indented);
        }
    }
}