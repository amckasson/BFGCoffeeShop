using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Models.CoffeeShopModels
{
    public class CoffeeShopCreate
    {
        public int MenuId { get; set; }

        public string ShopName { get; set; }

        public string Location { get; set; }

        public string PhoneNumber { get; set; }

        public string Website { get; set; }
    }
}
