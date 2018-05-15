using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Messenger.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Messenger.Web.Controllers
{
    public class HomeController : Controller
    {
        ServiceUOW.ServiceUOW serviceUOW;

        public HomeController()
        {
            serviceUOW = new ServiceUOW.ServiceUOW();
        }

        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            var model = await serviceUOW.UserService.GetFullUser(userId);
            var contacts = await serviceUOW.UserService.GetContacts(userId);
            var chats = await serviceUOW.ChatService.GetChats(userId);

            return View(new ManageIndexViewModel { CurrentUser = model, Contacts = contacts, Chats = chats });
        }
    }
}