using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LanchesDemo.Models
{
    public class Menu
    {
        public int Id { get; set; }


        [Display(Name = "Prato")]
        public string MenuItem { get; set; }

        [Display(Name = "Preço")]
        public double Price { get; set; }

        [Display(Name = "Tempo de Preparo")]
        public int PreparationTime { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Quantidade")]
        public int Quantity { get; set; } //quantity deveria ser propriedade da lista mas para manter a simplicidade foi adicionado como Menuitem

    }
}
