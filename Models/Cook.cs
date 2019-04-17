using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesDemo.Models
{
    public class Cook
    {

        /// <summary>
        /// Enum controle de workflow
        /// </summary>
       public enum Status
        {
            ordered, /* foi adicionado status pedido para controle de pedidos nao inicializados*/
            initialized,
            finalized,
            delivered,
        }


        /// <summary>
        /// Constructor inicializa parametros para funcionamento da classe
        /// </summary>
        public Cook()
        {
            Id = new Random().Next(); 
            ItemList = new List<Menu>();
            PreparationStatus = Status.ordered;

        }
        
        //Identificador unico da Lista
        public int Id { get; set; }



        /// <summary>
        /// Lista de items de menu no pedido.
        /// </summary>
        public List<Menu> ItemList { get;  }


        /// <summary>
        /// Acrescenta um item a lista ou aumenta a quantidade do item no pedido.
        /// </summary>
        /// <param name="menu"></param>
        public void AddItem(Menu menu, int quantity = 1)
        {
            // acrescenta 1 item
            menu.Quantity = quantity;

            //se ja houver  acrescenta quantidade
            var item = ItemList.FirstOrDefault(x => x.Id == menu.Id);
            if (item != null)
            {
                item.Quantity += menu.Quantity;
            }
            else // adiciona a lista
            {
                ItemList.Add(menu);
            }


          
        }


        public void GrantDiscount()
        {
            
            //remove os itens adicionados previamente.
            var discountItem = ItemList.FirstOrDefault(x => x.Id == 10);
            if (discountItem != null)
            {
                ItemList.Remove(discountItem);
            }

            //recalcula promoção
            var item = ItemList.FirstOrDefault(x => x.Id == 1 && x.Quantity > 1);
            if (item !=null)
            {
                AddItem(new Menu
                {
                    Id = 10,
                    MenuItem = "Batata Frita Promo",
                    Description = "Leve 2 hamburgueres e ganhe uma batata frita.",
                    Price = 0.0,
                    PreparationTime = 120
                } ,
                    Convert.ToInt32(item.Quantity / 2) // calculo da quantidade de promo a ser acrescentada
                );
            }

        }




        /// <summary>
        /// PreparationTime = maior tempo de preparo na lista de items.
        /// </summary>
        public int PreparationTime
        {
            get
            {
                int result = 0;
                if (ItemList.Count > 0)
                {
                    result = ItemList.Max(x => x.PreparationTime);
                }

                return result;
            }
        }

        /// <summary>
        /// Preparação workFlow status
        /// </summary>
        public Status PreparationStatus { get; set; }
                
    }
}
