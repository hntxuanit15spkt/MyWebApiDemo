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

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<StudentViewModel>>();
                    readTask.Wait();

                    students = readTask.Result;
                }
                else
                {
                    //log response status here

                    students = Enumerable.Empty<StudentViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator");
                }

                return View(students);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentViewModel student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57811/api/");

                //PostAsJsonAsync method serializes an object to JSON and sends the JSON payload in a POST request
                var postTask = client.PostAsJsonAsync<StudentViewModel>("StudentApi", student);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return View(student);
            }
        }
    }
}