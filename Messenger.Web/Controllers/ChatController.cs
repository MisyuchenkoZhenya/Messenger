using Messenger.BLL.DTO;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Messenger.Web.Models;

namespace Messenger.Web.Controllers
{
    public class ChatController : Controller
    {
        ServiceUOW.ServiceUOW serviceUOW;

        public ChatController()
        {
            serviceUOW = ServiceUOW.ServiceUOW.GetInstance();
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
        public async Task<ActionResult> AddChat(ChatDTO chatDTO, HttpPostedFileBase upload, string[] users)
        {
            //TODO: correct upload

            Regex rgx = new Regex(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$");
            if (!rgx.IsMatch(upload.FileName))
                ModelState.AddModelError("PhotoUrl", "Only Image files allowed.");
            
            if (ModelState.IsValid)
            {
                chatDTO.AdminId = User.Identity.GetUserId();
                chatDTO.PhotoUrl = SaveChatIcon(upload);
                chatDTO.CreatedAt = DateTime.Now;
                int chatId = await serviceUOW.ChatService.CreateChat(chatDTO);
                
                foreach (var userId in users ?? Array.Empty<string>())
                {
                    serviceUOW.ChatService.AddChatUser(new UserToChatDTO { ChatId = chatId, UserId = userId });
                }
                serviceUOW.ChatService.AddChatUser(new UserToChatDTO { ChatId = chatId, UserId = User.Identity.GetUserId() });

                return RedirectToAction("Index", "Manage");
            }

            return View(chatDTO);
        }

        //
        // GET: /Chat/UpdateChat
        public ActionResult UpdateChat(int chatId)
        {
            var chat = serviceUOW.ChatService.GetFullChat(chatId);
            var participants = serviceUOW.ChatService.GetChatParticipants(chatId);

            ChatToUpdateViewModel vm = new ChatToUpdateViewModel
            {
                Chat = chat,
                Participants = participants.ToList()
            };

            return View(vm);
        }

        //
        // POST: /Chat/UpdateChat
        [HttpPost]
        public async Task<ActionResult> UpdateChat(ChatDTO chatDTO, HttpPostedFileBase upload, string[] users)
        {
            if (ModelState.IsValid)
            {


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


        private string SaveChatIcon(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0 && file.FileName != "-noImage-.png")
            {
                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/images/chatIcons"), _FileName);
                file.SaveAs(_path);

                return file.FileName;
            }

            return "-noImage-.png";
        }
    }
}