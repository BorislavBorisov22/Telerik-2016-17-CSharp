using FirstMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVCApp.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new TestViewModel()
            {
                FirstName = "Ivan",
                LastName = "Petkov",
                Age = 33,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(TestViewModel model)
        {
            return new EmptyResult();
        }
    }
}