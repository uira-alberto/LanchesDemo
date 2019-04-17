using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchesDemo.Models;
using LanchesDemo.Util;

namespace LanchesDemo.Singleton
{
    public class CookList
    {


        public CookList()
        {
            items = new List<Cook>();
            ItemsWaiting = new Queue<Cook>();
        }

        /// <summary>
        /// Lista de Itens / ReadOnly
        /// </summary>
        private List<Cook> items;
        public List<Cook> Items {
            get {
                return items;
            }
        }

        /// <summary>
        /// Adiciona itens na lista. Se lista esta cheia {AppSettings.CookListMax} Adiciona na fila.
        /// </summary>
        /// <param name="cook"></param>
        public void AddItem(Cook cook) {
            if (Items.Count >= AppSettings.CookListMax)
            {
                ItemsWaiting.Enqueue(cook);
            }
            else
            {
                Items.Add(cook);
            }
        }

        //Alterar o status de preparação de um item da lista.
        public Cook ChangePreparationStatus(int idCook, Cook.Status status)
        {
            var selitem = Items.Where(x => x.Id == idCook).FirstOrDefault();

            selitem.PreparationStatus = status;

            //se for o final da preparação retira o 
            //elemento da lista e adiciona novo da fila.
            if (selitem.PreparationStatus == Cook.Status.delivered)
            {
                Items.Remove(selitem);
                if (ItemsWaiting.Count() > 0)
                {
                    Items.Add(ItemsWaiting.Dequeue());
                }
            }

            return selitem;
        }

        public Queue<Cook> ItemsWaiting {get; set;}

    }
}
