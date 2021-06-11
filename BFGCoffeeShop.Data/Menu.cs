using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Data
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        [Required]
        public string ItemName { get; set; }

        [ForeignKey(nameof(CoffeeOrder))]
        public int CoffeeOrderId { get; set; }
        public virtual CoffeeOrder CoffeeOrder { get; set; }

        [Required]
        public decimal ItemPrice { get; set; }
    }
}
