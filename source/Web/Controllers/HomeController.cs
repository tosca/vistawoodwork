using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public FileResult Index()
        {
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
                //SendEmail(o.Name, o.Address1, o.City, o.State, o.Zip, o.Phone, o.Email, o.Company, o.Comment);
                return RedirectToAction("ThankYou", "Home");
            }
            ModelState.AddModelError(string.Empty, "Oops,  " + string.Join(" ; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)));
            return View(viewModel);
        }

    }

    public class ContactViewModel
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
    }


}
