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
    public class ArticleController : Controller
    {
        private ServiceArticle serviceArticle;
        private ServiceSchema serviceSchema;
        private ServiceAdmUser serviceAdmUser;
        private ServiceTemplate serviceTemplate;
        Nullable<int> ArticleParentId, SchemaId;
        const string prefix = "XmlParams_";

        public ArticleController()
        {
            serviceTemplate = new ServiceTemplate();
            serviceArticle = new ServiceArticle();
            serviceSchema = new ServiceSchema();
            serviceAdmUser = new ServiceAdmUser();
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            var request = requestContext.HttpContext.Request;

            SchemaId = Convert.ToInt32("0" + request["SchemaId"]);
            ArticleParentId = Convert.ToInt32("0" + request["ArticleParentId"]);

            ViewBag.SchemaId = SchemaId == 0 ? null : SchemaId;
            ViewBag.ArticleParentId = ArticleParentId == 0 ? null : ArticleParentId;

            base.Initialize(requestContext);
        }

        // GET: Admin/Article
        public ActionResult Index()
        {
            ViewBag.TemplateList = serviceSchema.GetList_Template(ViewBag.SchemaId);
            IEnumerable<ArticleDto> list = serviceArticle.GetList(ViewBag.ArticleParentId);

            return View(Mapper.Map<IEnumerable<ArticleDto>, IList<ArticleListViewModel>>(list));
        }

        public ActionResult Create()
        {
            var model = new ArticleFormViewModel() { XmlParams="", RegisterDate = DateTime.Now };

            //if (ArticleParentId != null && SchemaId != null) model.Title = serviceSchema.GetItem(model.SchemaId).Alias;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleFormViewModel model)
        {
            var admuser = serviceAdmUser.GetItem_Email(User.Identity.GetUserName());

            try
            {
                if (ModelState.IsValid)
                {
                    string XmlParams = string.Empty;
                    foreach (string key in Request.Form.AllKeys)
                    {
                        if (key.StartsWith(prefix))
                        {
                            XmlParams = XMLReader.SetValue(XmlParams, key.Replace(prefix, ""), Request.Form[key]);
                        }
                    }

                    serviceArticle.Add(new ArticleDto()
                    {
                        SchemaId = model.SchemaId,
                        ArticleParentId = model.ArticleParentId,
                        Title = model.Title,
                        SubTitle = model.SubTitle,
                        Resumen = WebUtility.HtmlDecode(model.Resumen),
                        Description = WebUtility.HtmlDecode(model.Description),
                        Description2 = WebUtility.HtmlDecode(model.Description2),
                        XmlParams = XmlParams,
                        PublishDate = model.PublishDate,
                        ShowInHome = model.ShowInHome,
                        StaticUrl = model.StaticUrl,
                        Position = model.Position,
                        AuthorId = admuser.UserId,
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
                ModelState.AddModelError("Error", "Se ha producido un error: "+ex.Message);
                return View(model);
            }

            return RedirectToAction("Index", new { SchemaId = ViewBag.SchemaId, ArticleParentId = ViewBag.ArticleParentId });
        }

        public ActionResult Edit(int Id)
        {
            ArticleDto article = serviceArticle.GetItem(Id);
            ViewBag.ArticleParentId = article.ArticleParentId;
            ViewBag.SchemaId = article.Schema.SchemaParentId;
            
            return View(Mapper.Map<ArticleDto, ArticleFormViewModel>(article));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticleFormViewModel model)
        {
            var article = serviceArticle.GetItem(model.ArticleId);
            var admuser = serviceAdmUser.GetItem_Email(User.Identity.GetUserName());
            ViewBag.ArticleParentId = article.ArticleParentId;
            ViewBag.SchemaId = article.Schema.SchemaParentId;

            try
            {
                if (ModelState.IsValid)
                {
                    string XmlParams = article.XmlParams;
                    foreach (string key in Request.Form.AllKeys)
                    {
                        if (key.StartsWith(prefix))
                        {
                            XmlParams = XMLReader.SetValue(XmlParams, key.Replace(prefix, ""), Request.Form[key]);
                        }
                    }

                    article.Title = model.Title;
                    article.SubTitle = model.SubTitle;
                    article.Resumen = System.Net.WebUtility.HtmlDecode(model.Resumen);
                    article.Description = System.Net.WebUtility.HtmlDecode(model.Description);
                    article.Description2 = System.Net.WebUtility.HtmlDecode(model.Description2);
                    article.XmlParams = XmlParams;
                    article.PublishDate = model.PublishDate;
                    article.ShowInHome =  model.ShowInHome;
                    article.StaticUrl = model.StaticUrl;
                    article.Position = model.Position;
                    article.AuthorId = admuser.UserId;
                    article.Active = model.Active;

                    serviceArticle.Edit(article);
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


            return RedirectToAction("Index", new { SchemaId = ViewBag.SchemaId, ArticleParentId = ViewBag.ArticleParentId });
        }

        public PartialViewResult Delete(int Id)
        {
            ArticleDto article = serviceArticle.GetItem(Id);
            ViewBag.Id = article.ArticleId;
            ViewBag.Title = article.Title;
            ViewBag.Controller = "Article";
            return PartialView("_Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAction(int Id)
        {
            var article = serviceArticle.GetItem(Id);
            ViewBag.ArticleParentId = article.ArticleParentId;
            ViewBag.SchemaId = article.Schema.SchemaParentId;

            try
            {
                if (article!=null && ModelState.IsValid)
                {
                    serviceArticle.Delete(Id);
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

            return RedirectToAction("Index", new { SchemaId = ViewBag.SchemaId, ArticleParentId = ViewBag.ArticleParentId });
        }

    }
}