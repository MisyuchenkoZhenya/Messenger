using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Messenger.BLL.Services;
using Messenger.BLL.DTO;
using Messenger.DAL.Repository;

namespace Messenger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            IEnumerable<MessageDTO> messages;
            
            using (var service = new MessageService(new UnitOfWork()))
            {
                messages = service.GetMessages(1);
            }

            return View(messages);
        }
    }
}
