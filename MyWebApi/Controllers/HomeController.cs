using MyWebApi.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApi.Controllers
{
    [Log1] //This is an attribute, sử dụng được khi class dẫn xuất từ class Attribute
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
