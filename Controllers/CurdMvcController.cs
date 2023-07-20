using EngineerTestApiApps.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace EngineerTestApiApps.Controllers
{
    public class CurdMvcController : Controller
    {
        // GET: CurdMvc
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<User> list = new List<User>();
            client.BaseAddress =new Uri("http://errahulkc-001-site1.dtempurl.com/api/CustomApi");

            var response = client.GetAsync("CustomApi");
            response.Wait();

            var test = response.Result;

            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<User>>();
                display.Wait();
                list = display.Result;
            }
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            client.BaseAddress = new Uri("http://errahulkc-001-site1.dtempurl.com/api/CustomApi");

            var response = client.PostAsJsonAsync<User>("CustomApi", user);
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }
        public ActionResult Details(int ID)
        {
            User user = null;
            client.BaseAddress = new Uri("http://errahulkc-001-site1.dtempurl.com/api/CustomApi");

            var response = client.GetAsync("CustomApi?id="+ID.ToString());
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<User>();
                display.Wait();
                user = display.Result;
            }
            return View(user);
        }
        public ActionResult Edit(int ID)
        {

            User user = null;
            client.BaseAddress = new Uri("http://errahulkc-001-site1.dtempurl.com/api/CustomApi");

            var response = client.GetAsync("CustomApi?id=" + ID.ToString());
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<User>();
                display.Wait();
                user = display.Result;
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User u)
        {
            client.BaseAddress = new Uri("http://errahulkc-001-site1.dtempurl.com/api/CustomApi");

            var response = client.PutAsJsonAsync<User>("CustomApi", u);
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }
        public ActionResult Delete(int ID)
        {

            User user = null;
            client.BaseAddress = new Uri("http://errahulkc-001-site1.dtempurl.com/api/CustomApi");

            var response = client.GetAsync("CustomApi?id=" + ID.ToString());
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<User>();
                display.Wait();
                user = display.Result;
            }
            return View(user);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int ID)
        {
            client.BaseAddress = new Uri("http://errahulkc-001-site1.dtempurl.com/api/CustomApi");

            var response = client.DeleteAsync("CustomApi/"+ID);
            response.Wait();

            var test = response.Result;

            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }
    }
}