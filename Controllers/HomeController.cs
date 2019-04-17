using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanchesDemo.Models;
using Microsoft.Extensions.Configuration;


namespace LanchesDemo.Controllers
{
    public class HomeController : Controller
    {


        public HomeController(IConfiguration configuration)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "O numero maximo de itens suportados é:" + Util.AppSettings.CookListMax;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
