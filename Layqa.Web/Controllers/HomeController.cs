using System;
using System.Web.Mvc;
using Layqa.Service.Util;
using Layqa.Web.Areas.Admin.Models;
using Layqa.Web.Models;
using log4net;

namespace Layqa.Web.Controllers
{
    public class HomeController : Controller
    {
        private Email serviceEmail;
        private ILog logger;

        public HomeController()
        {
            logger = LogManager.GetLogger("HomeController");
            serviceEmail = new Email();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult ContactForm(ContactFormViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var ToEmail = model.Email; // "fishdev@gmail.com";
                    var Subject = "Nuevo Contacto";
                    var Body = "<h2>Nuevo Contacto</h2>";
                    Body += "<p>Se ha registrado una nueva solicitud de contacto, a continuación los datos del usuario:</p>";
                    Body += "<p><strong>Nombres:</strong> " + model.Name + "</p>";
                    Body += "<p><strong>E-mail:</strong> " + model.Email + "</p>";
                    Body += "<p><strong>Teléfono:</strong> " + model.Phone + "</p>";
                    Body += "<p><strong>Mensaje:</strong><br />" + model.Message + "</p>";

                    if (!serviceEmail.Send(ToEmail, Subject, Body))
                    {
                        logger.Warn(serviceEmail.ErrorMsg);
                        ModelState.AddModelError("Error", serviceEmail.ErrorMsg);
                    }
                    else
                    {
                        logger.Info("Se ha enviado un email: " + ToEmail);
                    }
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

            return PartialView("Templates/_form_contact", model);
        }


        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
