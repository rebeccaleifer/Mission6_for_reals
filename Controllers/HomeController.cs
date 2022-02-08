//Rebecca Leifer
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext daContext { get; set; }

        public HomeController(TaskContext someName)
        {
            daContext = someName;
        }

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
            ViewBag.Categories = daContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult EnterTasks (TaskResponse tr)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(tr);
                daContext.SaveChanges();

                return View("Confirmation", tr);
            }
            else //If Invalid
            {
                ViewBag.Categories = daContext.Categories.ToList();

                return View();
            }
        }

        public IActionResult ListTasks()
        {
            var tasks = daContext.Responses
                .Include(x => x.Category)
                .ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = daContext.Categories.ToList();
            var task = daContext.Responses.Single(x => x.TaskId == taskid);
            return View("EnterTasks", task);
        }

        [HttpPost]
        public IActionResult Edit(TaskResponse t)
        {
            daContext.Update(t);
            daContext.SaveChanges();

            return RedirectToAction("ListTasks");
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var task = daContext.Responses.Single(x => x.TaskId == taskid);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(TaskResponse tr)
        {
            daContext.Responses.Remove(tr);
            daContext.SaveChanges();

            return RedirectToAction("ListTasks");
        }
    }
}
