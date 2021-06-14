using BFGCoffeeShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Models.CoffeeOrderModels
{
    public class CoffeeOrderCreate
    {
        public int CoffeeShopId { get; set; }
        public string Country { get; set; }
        public string Barista { get; set; }
        public int CustomerId { get; set; }
        //public virtual Customer Customer { get; set; }
    }
}
