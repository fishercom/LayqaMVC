using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Layqa.Web.Areas.Admin.Models;
using Layqa.Service;
using Layqa.Service.Dto;
using Layqa.Service.Util;
using AutoMapper;
using System.Diagnostics;
using System.Net;

namespace Layqa.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class TemplateController : Controller
    {
        private ServiceTemplate serviceTemplate;

        public TemplateController()
        {
            serviceTemplate = new ServiceTemplate();
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            /*
            var request = requestContext.HttpContext.Request;

            if (request["TemplateId"] != null) TemplateId = Convert.ToInt32(request["TemplateId"]);
            if (request["TemplateParentId"] != null) TemplateParentId = Convert.ToInt32(request["TemplateParentId"]);

            ViewBag.TemplateId = TemplateId;
            ViewBag.TemplateParentId = TemplateParentId;
            */

            base.Initialize(requestContext);
        }

        // GET: Admin/Template
        public ActionResult Index()
        {
            IEnumerable<TemplateDto> list = serviceTemplate.GetList();

            return View(Mapper.Map<IEnumerable<TemplateDto>, IList<TemplateListViewModel>>(list));
        }

        public ActionResult Create()
        {
            var model = new TemplateFormViewModel() { Active = true };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TemplateFormViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    serviceTemplate.Add(new TemplateDto()
                    {
                        TemplateId = model.TemplateId,

                        Name = model.Name,
                        AdminView = model.AdminView,
                        FrontView = model.FrontView,
                        IsSection = model.IsSection,
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
                ModelState.AddModelError("Error", "Se ha producido un error: "+ex.Message);
                return View(model);
            }

            return RedirectToAction("Index", new { TemplateId = ViewBag.TemplateId, TemplateParentId = ViewBag.TemplateParentId });
        }

        public ActionResult Edit(int Id)
        {
            TemplateDto Template = serviceTemplate.GetItem(Id);

            return View(Mapper.Map<TemplateDto, TemplateFormViewModel>(Template));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TemplateFormViewModel model)
        {
            TemplateDto Template = serviceTemplate.GetItem(model.TemplateId);

            try
            {
                if (ModelState.IsValid)
                {
                    Template.TemplateId = model.TemplateId;

                    Template.Name = model.Name;
                    Template.AdminView = model.AdminView;
                    Template.FrontView = model.FrontView;
                    Template.IsSection = model.IsSection;
                    Template.Active = model.Active;

                    serviceTemplate.Edit(Template);
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
            TemplateDto Template = serviceTemplate.GetItem(Id);
            ViewBag.Id = Template.TemplateId;
            ViewBag.Title = "Esquema " + Template.TemplateId;
            ViewBag.Controller = "Template";
            return PartialView("_Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAction(int Id)
        {
            var Template = serviceTemplate.GetItem(Id);

            try
            {
                if (Template!=null && ModelState.IsValid)
                {
                    serviceTemplate.Delete(Id);
                }
                else
                {
                    ModelState.AddModelError("Error", "Algunos datos ingresados no son válidos");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "Se ha producido un error: " + ex.Message);
            }

            return RedirectToAction("Index");
        }

    }
}