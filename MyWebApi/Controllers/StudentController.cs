using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MyWebApi.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<StudentViewModel> students = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57811/api/");
                var responseTask = client.GetAsync("StudentApi");
                responseTask.Wait(); // if without this line,...

                var result = responseTask.Result; // cannot get the result here 

                students = Enumerable.Empty<StudentViewModel>();

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator");
                //if (result.IsSuccessStatusCode)
                //{
                //    var readTask = result.Content.ReadAsAsync<IList<StudentViewModel>>();
                //    readTask.Wait();

                //    students = readTask.Result;
                //}
                //else
                //{
                //    //log response status here

                //    students = Enumerable.Empty<StudentViewModel>();

                //    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator");
                //}

                return View(students);
            }
        }
    }
}