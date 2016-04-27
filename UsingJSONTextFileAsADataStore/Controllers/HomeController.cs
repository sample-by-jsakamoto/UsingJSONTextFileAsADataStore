using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsingJSONTextFileAsADataStore.Models;

namespace UsingJSONTextFileAsADataStore.Controllers
{
    public class HomeController : System.Web.Mvc.Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string name, int age)
        {
            var store = Global.PeopleStore;
            lock (store)
            {
                store.Add(new Person
                {
                    Name = name,
                    Age = age
                });
                store.SaveChanges();
            }

            return View("Index");
        }
    }
}