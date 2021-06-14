using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Data
{
    public class CoffeeOrder
    {
        [Key]
        public int CoffeeOrderId { get; set; }
        public string FullName { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Edited { get; set; }
        public string Country { get; set; }
        public decimal TotalPrice { get; set; }
        public string Barista { get; set; }
        public int CoffeeShopId { get; set; }

        //[ForeignKey("Customer")]
       // public int CustomerId { get; set; }
        public virtual List<Customer> Customer { get; set; }

        public virtual List<Addition> Additions { get; set; }

        public virtual List<Menu> Menus { get; set; }
    }
}
