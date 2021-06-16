using BFGCoffeeShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Models.CoffeeOrderModels
{
    public class CoffeeOrderListItem
    {
        public int CoffeeOrderId { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
