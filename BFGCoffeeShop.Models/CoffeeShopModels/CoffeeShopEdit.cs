using BFGCoffeeShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Models.CoffeeShopModels
{
    public class CoffeeShopEdit
    {
        public int CoffeeShopId { get; set; }

        public string ShopName { get; set; }

        public string Location { get; set; }

        public string PhoneNumber { get; set; }

        public string Website { get; set; }

       
    }
}
