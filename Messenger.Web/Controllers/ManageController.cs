﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Messenger.Web.Models;
using Messenger.BLL.Identity.Managers;
using Messenger.BLL.DTO;
using Newtonsoft.Json;

namespace Messenger.Web.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        ServiceUOW.ServiceUOW serviceUOW; 

        public ManageController()
        {
            serviceUOW = new ServiceUOW.ServiceUOW();
        }

        //public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        //{
        //    UserManager = userManager;
        //    SignInManager = signInManager;
        //}

        [HttpGet]
        public ActionResult Details()
        {
            return PartialView("DetailsPartial");
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            var model = await serviceUOW.UserService.GetFullUser(userId);

            return View(model);
        }

        //
        // GET: /Manage/GetUsersByEmail
        public async Task<string> GetUsersByEmail(string email)
        {
            var contacts = await serviceUOW.UserService.GetContacts(User.Identity.GetUserId());
            var users = await serviceUOW.UserService.GetUsersWithEmail(email, User.Identity.GetUserId());

            return JsonConvert.SerializeObject(users.Except(contacts), Formatting.Indented);
        }

        //#region Helpers
        //        // Used for XSRF protection when adding external logins
        //        private const string XsrfKey = "XsrfId";

        //        private IAuthenticationManager AuthenticationManager
        //        {
        //            get
        //            {
        //                return HttpContext.GetOwinContext().Authentication;
        //            }
        //        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        //private bool HasPassword()
        //{
        //    var user = UserManager.FindById(User.Identity.GetUserId());
        //    if (user != null)
        //    {
        //        return user.PasswordHash != null;
        //    }
        //    return false;
        //}

        //private bool HasPhoneNumber()
        //{
        //    var user = UserManager.FindById(User.Identity.GetUserId());
        //    if (user != null)
        //    {
        //        return user.PhoneNumber != null;
        //    }
        //    return false;
        //}

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        //#endregion
    }
}