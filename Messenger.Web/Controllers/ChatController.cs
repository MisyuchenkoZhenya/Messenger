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
        public async Task<ActionResult> AddChat(ChatDTO chatDTO)
        {
            if (ModelState.IsValid)
            {
                chatDTO.AdminId = User.Identity.GetUserId();

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

        //
        // GET: /Chat/AddContact
        [HttpPost]
        public async Task<string> AddContact(string contactId)
        {
            bool result = true;
                //await serviceUOW.UserService.AddContact(new UserToUserDTO
                //{
                //    FirstUserId = User.Identity.GetUserId(),
                //    SecondUserId = contactId
                //});

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
    }
}