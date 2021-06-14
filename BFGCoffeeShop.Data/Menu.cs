using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public decimal TotalPrice { get; set; }


        [Required]
        public decimal ItemPrice { get; set; }

        //public int CustomerId { get; set; }
        //public virtual Customer Customer { get; set; }

        public int CoffeeOrderId { get; set; }
    }
}
