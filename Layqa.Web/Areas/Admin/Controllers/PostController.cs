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
    public class PostController : Controller
    {
        private ServicePost ServicePost;
        private ServiceAdmUser ServiceAdmUser;

        public PostController()
        {
            ServicePost = new ServicePost();
            ServiceAdmUser = new ServiceAdmUser();
        }

        // GET: Admin/Post
        public ActionResult Index()
        {
            IEnumerable<PostDto> list = ServicePost.GetList();

            return View(Mapper.Map<IEnumerable<PostDto>, IList<PostListViewModel>>(list));
        }

        public ActionResult Create()
        {
            var model = new PostFormViewModel() { PublishDate = DateTime.Now };
            ViewBag.AutorList = Mapper.Map<IEnumerable<AdmUserDto>, IList<AdmUserListViewModel>>(ServiceAdmUser.GetList());
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostFormViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ServicePost.Add(new PostDto()
                    {
                        Title = model.Title,
                        Resumen = System.Net.WebUtility.HtmlDecode(model.Resumen),
                        Description = System.Net.WebUtility.HtmlDecode(model.Description),
                        PublishDate = model.PublishDate,
                        AuthorId = model.AuthorId,
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

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            PostDto post = ServicePost.GetItem(Id);
            ViewBag.AutorList = Mapper.Map<IEnumerable<AdmUserDto>, IList<AdmUserListViewModel>>(ServiceAdmUser.GetList());
            return View(Mapper.Map<PostDto, PostFormViewModel>(post));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostFormViewModel model)
        {
            ViewBag.AutorList = Mapper.Map<IEnumerable<AdmUserDto>, IList<AdmUserListViewModel>>(ServiceAdmUser.GetList());

            try
            {
                if (ModelState.IsValid)
                {
                    var post = ServicePost.GetItem(model.PostId);

                    post.Title = model.Title;
                    post.Resumen = System.Net.WebUtility.HtmlDecode(model.Resumen);
                    post.Description = System.Net.WebUtility.HtmlDecode(model.Description);
                    post.PublishDate = model.PublishDate;
                    post.AuthorId = model.AuthorId;
                    post.Active = model.Active;

                    ServicePost.Edit(post);
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
            PostDto post = ServicePost.GetItem(Id);
            ViewBag.Id = post.PostId;
            ViewBag.Title = post.Title;
            ViewBag.Controller = "Post";

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
                    ServicePost.Delete(Id);
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