using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Messenger.BLL.Services;
using Messenger.DAL.Repository;

namespace Messenger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            
            using(var service = new UserService(new UnitOfWork()))
            {
                var result = service.GetContacts(1);
                foreach(var i in result)
                {
                    System.Diagnostics.Debug.WriteLine(i.PhoneNumber);
                }
            }

            return View();
        }
    }
}
