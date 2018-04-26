using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Messenger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //IEnumerable<UserDTO> users;
            
            //using (var service = new ChatService(new UnitOfWork()))
            //{
            //    users = service.GetFullChat(1).Participants;
            //}

            return View();
        }
    }
}
