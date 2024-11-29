using Hangfire;
using Hangfire_Example.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hangfire_Example.Controllers
{
    public class HomeController : Controller
    {
        private static int counter = 0;

        public IActionResult Index()
        {
            // Her 5 saniyede bir çalışacak şekilde bir arka plan işi başlatıyoruz
            RecurringJob.AddOrUpdate("increment-counter", () => IncrementCounter(), "*/5 * * * * *"); // 5 saniyede bir çalışır

            // Counter değerini View'a gönder
            ViewBag.CounterValue = counter;
            return View();
        }

        public void IncrementCounter()
        {
            counter++;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
