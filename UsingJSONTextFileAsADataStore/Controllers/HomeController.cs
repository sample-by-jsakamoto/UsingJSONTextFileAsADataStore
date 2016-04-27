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
            var store = Global.PeopleStore;
            lock (store)
            {
                return View("Index", store.People.ToArray());
            }
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

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var store = Global.PeopleStore;
            lock (store)
            {
                store.Delete(id);
                store.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var store = Global.PeopleStore;
            lock (store)
            {
                var personToEdit = store.People.First(person => person.Id == id);
                return View(personToEdit);
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, string name, int age)
        {
            var store = Global.PeopleStore;
            lock (store)
            {
                var personToEdit = store.People.First(person => person.Id == id);
                if (ModelState.IsValid == false)
                    return View(personToEdit);

                personToEdit.Name = name;
                personToEdit.Age = age;
                store.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}