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
    public class AdmUserController : Controller
    {
        private ServiceAdmUser ServiceAdmUser;
        private ServiceAdmProfile ServiceAdmProfile;

        public AdmUserController()
        {
            ServiceAdmUser = new ServiceAdmUser();
            ServiceAdmProfile = new ServiceAdmProfile();
        }

        public AdmUserController(ApplicationUserManager userManager,
            ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;

            ServiceAdmUser = new ServiceAdmUser();
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

        // GET: Admin/AdmUser
        public ActionResult Index()
        {
            IEnumerable<AdmUserDto> list = ServiceAdmUser.GetList();

            return View("Index", Mapper.Map<IEnumerable<AdmUserDto>, IList<AdmUserListViewModel>>(list));
        }

        public ActionResult Create()
        {
            var model = new AdmUserFormViewModel();
            //ViewBag.RolesList = RoleManager.Roles;
            ViewBag.AdmProfileesList = ServiceAdmProfile.GetList();
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdmUserFormViewModel model)
        {
            try
            {
                ViewBag.AdmProfileesList = ServiceAdmProfile.GetList();

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
                            // Add user admin to Role Admin if not already added
                            UserManager.AddToRole(user.Id, "Administrator");
                        }
                    }
                    else
                    {
                        model.AccountId = user.Id;
                    }

                    ServiceAdmUser.Add(new AdmUserDto()
                    {
                        Name = model.Name,
                        LastName = model.LastName,
                        Email = model.Email,
                        AccountId = model.AccountId, //Update from Identity
                        RegisterDate = DateTime.Now,
                        Active = model.Active,
                        AdmProfileId = model.AdmProfileId
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
            AdmUserDto AdmUser = ServiceAdmUser.GetItem(Id);
            //ViewBag.RolesList = RoleManager.Roles;
            ViewBag.AdmProfileesList = ServiceAdmProfile.GetList();

            return View(Mapper.Map<AdmUserDto, AdmUserFormViewModel>(AdmUser));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdmUserFormViewModel model)
        {
            try
            {
                ViewBag.AdmProfileesList = ServiceAdmProfile.GetList();

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
                                // Add user admin to Role Admin if not already added
                                UserManager.AddToRole(user.Id, "Administrator");
                            }
                        }
                        else
                        {
                            model.AccountId = user.Id;
                        }
                    }

                    var AdmUser = ServiceAdmUser.GetItem(model.UserId);
                    AdmUser.Name = model.Name;
                    AdmUser.LastName = model.LastName;
                    AdmUser.Email = model.Email;
                    AdmUser.AccountId = model.AccountId; //Update from Identity
                    AdmUser.Active = model.Active;
                    AdmUser.AdmProfileId = model.AdmProfileId;

                    ServiceAdmUser.Edit(AdmUser);
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
            AdmUserDto AdmUser = ServiceAdmUser.GetItem(Id);
            ViewBag.Id = AdmUser.UserId;
            ViewBag.Title = AdmUser.Name+AdmUser.LastName;
            ViewBag.Controller = "AdmUser";

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
                    ServiceAdmUser.Delete(Id);
                }
                else
                {
                    ModelState.AddModelError("Error", "Algunos datos ingresados no son válidos");
                    return Index();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "Se ha producido un error: " + ex.Message);
                return Index();
            }

            return RedirectToAction("Index");
        }

    }
}