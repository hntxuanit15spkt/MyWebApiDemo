using MyWebApi.Common;
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
                client.BaseAddress = new Uri(Defines.URI_BASE);
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
                client.BaseAddress = new Uri(Defines.URI_BASE);
                var postTask = client.PostAsJsonAsync<StudentViewModel>("StudentApi", student);
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Server error. Please contact administrator.");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            StudentViewModel student = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Defines.URI_BASE);
                var responseTask = client.GetAsync("StudentApi?id=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<StudentViewModel>();
                    readTask.Wait();
                    student = readTask.Result;
                }
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Defines.URI_BASE);
                var putTask = client.PutAsJsonAsync<StudentViewModel>("StudentApi", student);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(student);
        }

        public ActionResult Delete (int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Defines.URI_BASE);
                var deleteTask = client.DeleteAsync("StudentApi?id=" + id);
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}