using Assignment2.Models;
using Assignment2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Why Cruises of Antarctica?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Talk to a Polar Travel Adviser.";

            return View();
        }
        public ActionResult SendEmail()
        {
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        public ActionResult SendEmail(SendEmailViewModel model, HttpPostedFileBase postedFile)
        {
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String toAddRecipients = model.ToAddRecipients;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, toAddRecipients, subject, contents, postedFile);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

    }
}