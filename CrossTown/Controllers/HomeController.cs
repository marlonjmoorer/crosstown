using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace CrossTown.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
		    var model = new EmailViewModel();
			return View(model);
		}
		[HttpPost]
		public ActionResult SendMail(EmailViewModel model) {


			if (ModelState.IsValid)
			{
			    var Username = ConfigurationManager.AppSettings["mailAccount"];

				//Password to use for SMTP authentication
				var Password = ConfigurationManager.AppSettings["mailPassword"];

			    using (MailMessage mm = new MailMessage(model.email_address, Username))
				{
					mm.Subject = "Need Quote";
					mm.Body = model.comments;
				    mm.CC.Add(model.email_address);

					mm.IsBodyHtml = false;
					SmtpClient smtp = new SmtpClient();
					smtp.Host = "smtp.gmail.com";
					smtp.EnableSsl = true;
					NetworkCredential NetworkCred = new NetworkCredential(Username, Password);
					//smtp.UseDefaultCredentials = true;
					smtp.Credentials = NetworkCred;
					smtp.Port = 587;
					smtp.Send(mm);

				}


			    TempData["SuccessMessage"] = "You quote has been sent sucessfully!";
			    return RedirectToAction("index");
			}
			else {
				model.section = "quote";
				return View("Index", model);
			}



		
		}
	}
}
