using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
			var mvcName = typeof(Controller).Assembly.GetName();
			var isMono = Type.GetType("Mono.Runtime") != null;

			ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			ViewData["Runtime"] = isMono ? "Mono" : ".NET";


		 	var Username = "marlonjmoorer@gmail.com";
            //Password to use for SMTP authentication
            var Password = "zero1318";

			using (MailMessage mm = new MailMessage(Username, Username))
			{
				mm.Subject = "Subject";
				mm.Body = "I think i was about 17";

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


			return View();
		}
	}
}
