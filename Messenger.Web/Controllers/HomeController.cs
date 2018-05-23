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
        public async Task<JsonResult> UploadFile()
        {
            //TODO: clear this later
            string fileName = string.Empty;
            string type = string.Empty;
            foreach (string file in Request.Files)
            {
                var fileContent = Request.Files[file];
                if (fileContent != null && fileContent.ContentLength > 0)
                {
                    var stream = fileContent.InputStream;
                    string extension = fileContent.FileName.Split('.').Last();
                    fileName = $"{Guid.NewGuid().ToString()}.{extension}";
                    type = fileContent.ContentType.Split('/')[0].Equals("image") ? "Image" : "File";
                    var path = Path.Combine(Server.MapPath(type.Equals("Image") ? "~/data/images" : "~/data/files"), fileName);
                    using (var fileStream = System.IO.File.Create(path))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
            }

            return Json(new { file_name = fileName, file_type = type });
        }

        public async Task<string> GetChatContent(int chatId)
        {
            var messages = await serviceUOW.MessageService.GetMessages(chatId);

            return JsonConvert.SerializeObject(messages, Formatting.Indented);
        }
    }
}