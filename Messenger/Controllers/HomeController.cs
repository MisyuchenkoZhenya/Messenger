﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Messenger.DAL;
using Messenger.DAL.Context;

namespace Messenger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            using (MessengerContext db = new MessengerContext())
            {
                db.Database.Initialize(true);
                db.SaveChanges();
            }

            return View();
        }
    }
}
