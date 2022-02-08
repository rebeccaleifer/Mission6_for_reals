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
        private TaskContext tContext { get; set; }

        public HomeController(TaskContext someName)
        {
            tContext = someName;
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
            ViewBag.Categories = tContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult EnterTasks (TaskResponse tr)
        {
            if (ModelState.IsValid)
            {
                tContext.Add(tr);
                tContext.SaveChanges();

                return View("Confirmation", tr);
            }
            else //If Invalid
            {
                ViewBag.Categories = tContext.Categories.ToList();

                return View();
            }
        }

        public IActionResult ListTasks()
        {
            var tasks = tContext.Responses
                .Include(x => x.Category)
                .ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = tContext.Categories.ToList();
            var task = tContext.Responses.Single(x => x.TaskId == taskid);
            return View("EnterTasks", task);
        }

        [HttpPost]
        public IActionResult Edit(TaskResponse t)
        {
            tContext.Update(t);
            tContext.SaveChanges();

            return RedirectToAction("ListTasks");
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var task = tContext.Responses.Single(x => x.TaskId == taskid);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(TaskResponse tr)
        {
            tContext.Responses.Remove(tr);
            tContext.SaveChanges();

            return RedirectToAction("ListTasks");
        }
    }
}
