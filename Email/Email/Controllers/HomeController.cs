using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Email.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Email.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailForm model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("gflynn@volusia.org"));
                message.From = new MailAddress("gregnnylf94@gmail.com");
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credentials = new NetworkCredential
                    {
                        UserName = "gregnnylf94@gmail.com",
                        Password = "Enjoilif3!"
                    };

                    smtp.Credentials = credentials;
                    smtp.Host = "smtp-relay.gmail.com";
                    smtp.Port = 25;
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }

            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}