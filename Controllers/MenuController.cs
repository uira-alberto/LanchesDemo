using System.Net;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using LanchesDemo.Models;
using System.Runtime.Remoting.Contexts;
using LanchesDemo.Util;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LanchesDemo.Controllers
{
    public class MenuController : Controller
    {

        public IActionResult Index()
        {
            return View(GetMenuList());
        }

        /// <summary>
        /// Adiciona um no pedido
        /// </summary>
        /// <param name="idMenu"></param>
        /// <returns></returns>
        public JsonResult Add(int idMenu)
        {

            Cook newOrder = this.Order;
            
            ///valida
            if (newOrder == null)
            {
                newOrder = new Cook();
            }

            newOrder.AddItem(GetMenu(idMenu));
            newOrder.GrantDiscount();

            //salva session
            Order = newOrder;
            
            return new JsonResult(newOrder);
        }


        public JsonResult OrderCart()
        {
            return new JsonResult(Order);
        }


        /// <summary>
        /// Realiza um pedido para a cozinha
        /// </summary>
        /// <returns></returns>
        public JsonResult PlaceOrder()
        {
            var cookController = new CookController();
            cookController.ControllerContext = ControllerContext;

            cookController.PlaceOrder(Order);

            return OrderCart();
        }



        /// <summary>
        /// Retorna a lista de itens do arquivo json.
        /// </summary>
        /// <returns></returns>
        private List<Menu> GetMenuList() {

            var webClient = new WebClient();
            var json = webClient.DownloadString("wwwroot/data/menu.json");
            var result = JsonConvert.DeserializeObject<List<Menu>>(json);

            return result;
        }


        /// <summary>
        /// Retorna um item menu a partir do ID
        /// </summary>
        /// <param name="idMenu"></param>
        /// <returns></returns>
        public Menu GetMenu(int idMenu)
        {
            var menus = GetMenuList();
            return menus.Where( i => i.Id == idMenu).FirstOrDefault() ;
        }

        /// <summary>
        /// Order Session Object
        /// </summary>
        private const string OrderString = "Order";
        public Cook Order
        {
            get => HttpContext.Session.GetObject<Cook>(OrderString);
            set => HttpContext.Session.SetObject(OrderString, value);
        }




    }
}
