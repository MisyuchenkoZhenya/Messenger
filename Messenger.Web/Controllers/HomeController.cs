using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Messenger.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;

namespace Messenger.Web.Controllers
{
    public class HomeController : Controller
    {
        ServiceUOW.ServiceUOW serviceUOW;

        public HomeController()
        {
            serviceUOW = ServiceUOW.ServiceUOW.GetInstance();
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            var model = await serviceUOW.UserService.GetFullUser(userId);
            var contacts = await serviceUOW.UserService.GetContacts(userId);
            var chats = await serviceUOW.UserService.GetChats(userId);

            return View(new ManageIndexViewModel { CurrentUser = model, Contacts = contacts, Chats = chats });
        }

        [HttpPost]
        public async Task<JsonResult> UploadFile(string id)
        {
            string fileName = string.Empty;
            foreach (string file in Request.Files)
            {
                var fileContent = Request.Files[file];
                if (fileContent != null && fileContent.ContentLength > 0)
                {
                    var stream = fileContent.InputStream;
                    string extension = fileContent.ContentType.Split('/')[1];
                    fileName = $"{Guid.NewGuid().ToString()}.{extension}";
                    var path = Path.Combine(Server.MapPath("~/App_Data/Images"), fileName);
                    using (var fileStream = System.IO.File.Create(path))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
            }

            return Json(fileName);
        }

        public async Task<string> GetChatContent(int chatId)
        {
            var messages = await serviceUOW.MessageService.GetMessages(chatId);

            return JsonConvert.SerializeObject(messages, Formatting.Indented);
        }
    }
}