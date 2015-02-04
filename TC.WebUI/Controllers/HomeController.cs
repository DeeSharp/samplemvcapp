using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TC.Business.Entities;
using TC.Business.Repository.Abstract;
using TC.Business.Repository.Concrete;

namespace TC.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IPersonRepository repository;

        public HomeController()
        {
            this.repository = new PersonRepository(); // To be IoCed
        }

        public ActionResult Index()
        {
            return View(this.repository.Get());
        }

        
        public ActionResult Edit(int id)
        {
            var person = this.repository.GetById(id);
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            this.repository.Update(person);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            this.repository.Add(person);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            this.repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}