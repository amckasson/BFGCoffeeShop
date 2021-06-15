using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Data
{
    public class CoffeeShop
    {
        [Key]
        public int CoffeeShopId { get; set; }
             
        public string ShopName { get; set; }

        public string Location { get; set; }

        public string PhoneNumber { get; set; }

        public string Website { get; set; }

        public int CoffeeOrderId { get; set; }
        public virtual List<CoffeeOrder> CoffeeOrder { get; set; }

        public int MenuId { get; set; }
        public virtual List<Menu> Menu { get; set; } = new List<Menu>();
    }
}
