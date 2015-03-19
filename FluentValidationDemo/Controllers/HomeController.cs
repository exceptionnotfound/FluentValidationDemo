using FluentValidationDemo.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FluentValidationDemo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            AddMovieVM model = new AddMovieVM();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AddMovieVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Fluent()
        {
            AddFluentMovieVM model = new AddFluentMovieVM();
            return View(model);
        }

        [HttpPost]
        public ActionResult Fluent(AddFluentMovieVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction("Fluent");
        }
    }
}