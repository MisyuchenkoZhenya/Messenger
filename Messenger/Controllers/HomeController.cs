using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Messenger.DAL.Models;
using Messenger.DAL.Repository;


namespace Messenger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            using (var db = new UnitOfWork())
            {
                db.Users.Create(new User
                {
                    Id = "jadnjakndjkasndkjdnkajsdnkjsdnsadn",
                    FirstName = "q",
                    LastName = "q",
                    PhoneNumber = "123321123",
                    PasswordHash = "addemcewocmweocm"
                });
            }

            return View();
        }
    }
}
