using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic; 
using System.Configuration;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          //  return RedirectToAction("Contact", "Home");
            return File("index.html", "text/html");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ActionResult Home()
        {
            ViewBag.Message = "Modify me.";

            return View();
        }

        public ActionResult ThankYou()
        {
            ViewBag.Message = "Modify me.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View(new ContactViewModel() );
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                //dynamic table = new Prospect();
                //dynamic o = new ExpandoObject();
                //{
                //    o.Email = viewModel.Email;
                //    o.Address1 = viewModel.Address1;
                //    o.Address2 = viewModel.Address2;
                //    o.City = viewModel.City;
                //    o.State = viewModel.State;
                //    o.Zip = viewModel.Zip;
                //    o.Phone = viewModel.Phone;
                //    o.Name = viewModel.Name;
                //    o.Company = viewModel.Company;
                //    o.Comment = viewModel.Comment;
                //    o.IpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"]; 
                //}
                //table.Insert(o);
                try
                {
                    SendEmail(viewModel);
                }
                catch
                {
                }
             //   return RedirectToAction("Contact", "Home");

            }
            ModelState.AddModelError(string.Empty, "Oops,  " + string.Join(" ; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)));
            return View(viewModel);
        }

        protected void SendEmail(ContactViewModel viewModel)
        {
            var to = ConfigurationManager.AppSettings["EmailSendTo"];
            var smtpEmailAddres = ConfigurationManager.AppSettings["SmtpEmailAddres"];
            var smtpEmailPassword = ConfigurationManager.AppSettings["SmtpEmailPassword"];

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("name:{0}          <br/>email:{1}        <br/>phone:{2}         <br/>Comments:{3}   ",
                viewModel.Name, viewModel.Email, viewModel.Phone, viewModel.Comment);


            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(smtpEmailAddres, smtpEmailPassword),
                EnableSsl = true
            };
            client.Send(smtpEmailAddres, to, "Vista Woodworking Website contact lead", sb.ToString());
            //Response.Redirect("../Public/Thankyou.aspx");
        }
    }

    public class ContactViewModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
    }


}
