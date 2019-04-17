using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanchesDemo.Models;
using LanchesDemo.Singleton;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LanchesDemo.Controllers
{
    public class CookController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {

            return View();
        }


        /// <summary>
        /// Realiza um pedido para a cozinha
        /// </summary>
        /// <param name="cook"></param>
        /// <returns></returns>
        public JsonResult PlaceOrder(Cook cook)
        {
            CookList cookList = (CookList)HttpContext.RequestServices.GetService(typeof(CookList));

            cookList.AddItem(cook);

            return new JsonResult(cookList);
        }


        /// <summary>
        /// Retorna a lista de pedidos a serem preparados.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCookList() {
            CookList cookList = (CookList)HttpContext.RequestServices.GetService(typeof(CookList));

            return new JsonResult(cookList);
        }



    }
}
