using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Layqa.Web.Areas.Admin.Models;
using Layqa.Service;
using Layqa.Service.Dto;
using AutoMapper;

namespace Layqa.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdmProfileController : Controller
    {
        private ServiceAdmProfile serviceAdmProfile;

        public AdmProfileController()
        {
            serviceAdmProfile = new ServiceAdmProfile();
        }

        // GET: Admin/AdmProfile
        public ActionResult Index()
        {
            IEnumerable<AdmProfileDto> list = serviceAdmProfile.GetList();

            return View(Mapper.Map<IEnumerable<AdmProfileDto>, IList<AdmProfileListViewModel>>(list));
        }

        public ActionResult Create()
        {
            var model = new AdmProfileFormViewModel() { };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdmProfileFormViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    serviceAdmProfile.Add(new AdmProfileDto()
                    {
                        Name = model.Name,
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
                ModelState.AddModelError("Error", "Se ha producido un error: "+ex.Message);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            AdmProfileDto profile = serviceAdmProfile.GetItem(Id);

            return View(Mapper.Map<AdmProfileDto, AdmProfileFormViewModel>(profile));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdmProfileFormViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var profile = serviceAdmProfile.GetItem(model.AdmProfileId);

                    profile.Name = model.Name;
                    serviceAdmProfile.Edit(profile);
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
            AdmProfileDto profile = serviceAdmProfile.GetItem(Id);
            ViewBag.Id = profile.AdmProfileId;
            ViewBag.Title = profile.Name;
            ViewBag.Controller = "AdmProfile";

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
                    serviceAdmProfile.Delete(Id);
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