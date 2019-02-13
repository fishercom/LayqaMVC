using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using Layqa.Web.Areas.Admin.Models;
using Layqa.Web.Models;
using Layqa.Service;
using Layqa.Service.Dto;
using AutoMapper;
using System;

namespace Layqa.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class WebUserController : Controller
    {
        private ServiceUser ServiceUser;

        public WebUserController()
        {
            ServiceUser = new ServiceUser();
        }

        public WebUserController(ApplicationUserManager userManager,
            ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;

            ServiceUser = new ServiceUser();
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        // GET: Admin/User
        public ActionResult Index()
        {
            IEnumerable<WebUserDto> list = ServiceUser.GetList();

            return View(Mapper.Map<IEnumerable<WebUserDto>, IList<WebUserListViewModel>>(list));
        }

        public ActionResult Create()
        {
            var model = new WebUserFormViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WebUserFormViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = UserManager.FindByEmail(model.Email);
                    if (user == null)
                    {
                        user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                        var result = UserManager.Create(user, model.Password);
                        result = UserManager.SetLockoutEnabled(user.Id, false);

                        if (result.Succeeded)
                        {
                            model.AccountId = user.Id;
                            // User cannot to have admin role
                        }
                    }
                    else
                    {
                        model.AccountId = user.Id;
                    }

                    ServiceUser.Add(new WebUserDto()
                    {
                        Name = model.Name,
                        LastName = model.LastName,
                        Email = model.Email,
                        AccountId = model.AccountId, //Update from Identity
                        RegisterDate = DateTime.Now,
                        Active = model.Active
                    });
                }
                else
                {
                    ModelState.AddModelError("Error", "Algunos datos ingresados no son válidos");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "Se ha producido un error: " + ex.Message);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            WebUserDto User = ServiceUser.GetItem(Id);

            return View(Mapper.Map<WebUserDto, WebUserFormViewModel>(User));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WebUserFormViewModel model)
        {
            ViewBag.AutorList = Mapper.Map<IEnumerable<WebUserDto>, IList<WebUserListViewModel>>(ServiceUser.GetList());

            try
            {
                if (ModelState.IsValid)
                {

                    if (string.IsNullOrEmpty(model.AccountId))
                    {

                        var user = UserManager.FindByEmail(model.Email);
                        if (user == null)
                        {
                            user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                            var result = UserManager.Create(user);
                            result = UserManager.SetLockoutEnabled(user.Id, false);

                            if (result.Succeeded)
                            {
                                model.AccountId = user.Id;
                                // User cannot to have admin role
                            }
                        }
                        else
                        {
                            model.AccountId = user.Id;
                        }
                    }

                    var User = ServiceUser.GetItem(model.UserId);

                    User.Name = model.Name;
                    User.LastName = model.LastName;
                    User.Email = model.Email;
                    User.AccountId = model.AccountId; //Update from Identity
                    User.Active = model.Active;

                    ServiceUser.Edit(User);
                }
                else
                {
                    ModelState.AddModelError("Error", "Algunos datos ingresados no son válidos");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "Se ha producido un error: " + ex.Message);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public PartialViewResult Delete(int Id)
        {
            WebUserDto User = ServiceUser.GetItem(Id);
            ViewBag.Id = User.UserId;
            ViewBag.Title = User.Name+User.LastName;
            ViewBag.Controller = "User";

            return PartialView("_Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAction(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ServiceUser.Delete(Id);
                }
                else
                {
                    ModelState.AddModelError("Error", "Algunos datos ingresados no son válidos");
                    return View("Delete");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "Se ha producido un error: " + ex.Message);
                return View("Delete");
            }

            return RedirectToAction("Index");
        }

    }
}