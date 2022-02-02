//Rebecca Leifer
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        // private TaskContext tContext { get; set; }

        //public HomeController(TaskContext someName)
        //{
        //    //tContext = someName;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterTasks()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult EnterTasks()
        //{
        //    return View();
        //}

        public IActionResult ListTasks()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult Edit()
        //{
        //    return View("ListTasks");
        //}

        //[HttpPost]
        //public IActionResult Edit()
        //{
        //    tContext.Update(blah);
        //    tContext.SaveChanges();

        //    return RedirectToAction("ListTasks");
        //}

        //[HttpGet]
        //public IActionResult Delete()
        //{

        //    return View("EnterTasks");
        //}

        //[HttpPost]
        //public IActionResult Delete()
        //{
        //    tContext.Responses.Remove();
        //    tContext.SaveChanges();

        //    return RedirectToAction("ListTasks");
        //}
    }
}
