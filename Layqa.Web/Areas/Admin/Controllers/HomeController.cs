using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Layqa.Web.Areas.Admin.Models;
using Layqa.Service;
using Layqa.Service.Dto;
using AutoMapper;
using Microsoft.Owin.Security;

namespace Layqa.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {

            return View();
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // POST: /Admin/Home/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}