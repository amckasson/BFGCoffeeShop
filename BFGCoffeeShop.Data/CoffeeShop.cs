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

       // [ForeignKey("Menu")]
        public int MenuId { get; set; }
        //public virtual Menu MenuName { get; set; }

        //[ForeignKey("CoffeeOrder")]
        public int CoffeeOrderId { get; set; }
        //public virtual CoffeeOrder CoffeeOrder { get; set; }

        public string ShopName { get; set; }

        public string Location { get; set; }

        public string PhoneNumber { get; set; }

        public string Website { get; set; }
    }
}
