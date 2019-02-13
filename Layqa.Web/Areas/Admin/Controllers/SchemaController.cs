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
    public class SchemaController : Controller
    {
        private ServiceSchema serviceSchema;
        private ServiceTemplate serviceTemplate;
        Nullable<int> SchemaParentId, SchemaId;
        const string prefix = "XmlParams_";

        public SchemaController()
        {
            serviceTemplate = new ServiceTemplate();
            serviceSchema = new ServiceSchema();
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            var request = requestContext.HttpContext.Request;

            if (request["SchemaId"] != null) SchemaId = Convert.ToInt32(request["SchemaId"]);
            if (request["SchemaParentId"] != null) SchemaParentId = Convert.ToInt32(request["SchemaParentId"]);

            ViewBag.SchemaId = SchemaId;
            ViewBag.SchemaParentId = SchemaParentId;

            base.Initialize(requestContext);
        }

        // GET: Admin/Schema
        public ActionResult Index()
        {
            IEnumerable<SchemaDto> list = serviceSchema.GetList(SchemaParentId);

            return View(Mapper.Map<IEnumerable<SchemaDto>, IList<SchemaListViewModel>>(list));
        }

        public ActionResult Create()
        {
            var model = new SchemaFormViewModel() { Active = true};
            ViewBag.TemplateList = serviceTemplate.GetList(SchemaParentId);
            //ViewBag.SchemaParentId = SchemaParentId;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchemaFormViewModel model)
        {
            ViewBag.SchemaParentId = model.SchemaParentId;
            ViewBag.TemplateList = serviceTemplate.GetList(model.SchemaParentId);

            try
            {
                if (ModelState.IsValid)
                {
                    serviceSchema.Add(new SchemaDto()
                    {
                        SchemaId = model.SchemaId,
                        SchemaParentId = model.SchemaParentId,

                        //SectionId = model.SectionId,
                        TemplateId = model.TemplateId,
                        Iterations = model.Iterations,
                        Position = model.Position,
                        IsPage = model.IsPage,
                        Alias = model.Alias,
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

            return RedirectToAction("Index", new { SchemaId = ViewBag.SchemaId, SchemaParentId = ViewBag.SchemaParentId });
        }

        public ActionResult Edit(int Id)
        {
            SchemaDto schema = serviceSchema.GetItem(Id);

            ViewBag.SchemaParentId = schema.SchemaParentId;
            ViewBag.TemplateList = serviceTemplate.GetList(schema.SchemaParentId);

            return View(Mapper.Map<SchemaDto, SchemaFormViewModel>(schema));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SchemaFormViewModel model)
        {
            SchemaDto schema = serviceSchema.GetItem(model.SchemaId);

            ViewBag.SchemaParentId = schema.SchemaParentId;
            ViewBag.TemplateList = serviceTemplate.GetList(schema.SchemaParentId);

            try
            {
                if (ModelState.IsValid)
                {
                    //schema.SectionId = model.SectionId;
                    schema.TemplateId = model.TemplateId;
                    schema.Iterations = model.Iterations;
                    schema.Position = model.Position;
                    schema.IsPage = model.IsPage;
                    schema.Alias = model.Alias;
                    schema.Active = model.Active;

                    serviceSchema.Edit(schema);
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


            return RedirectToAction("Index", new { SchemaId = ViewBag.SchemaId, SchemaParentId = ViewBag.SchemaParentId });
        }

        public PartialViewResult Delete(int Id)
        {
            SchemaDto Schema = serviceSchema.GetItem(Id);
            ViewBag.Id = Schema.SchemaId;
            ViewBag.Title = "Esquema " + Schema.SchemaId;
            ViewBag.Controller = "Schema";
            return PartialView("_Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAction(int Id)
        {
            var Schema = serviceSchema.GetItem(Id);
            ViewBag.SchemaParentId = Schema.SchemaParentId;
            ViewBag.SchemaId = Schema.SchemaId;

            try
            {
                if (Schema!=null && ModelState.IsValid)
                {
                    serviceSchema.Delete(Id);
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

            return RedirectToAction("Index", new { SchemaId = ViewBag.SchemaId, SchemaParentId = ViewBag.SchemaParentId });
        }

    }
}