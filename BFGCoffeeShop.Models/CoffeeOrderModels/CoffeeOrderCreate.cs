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
        public string Country { get; set; }
        public Guid CoffeeOrderTag { get; set; }
        public string Barista { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public int MenuId{ get; set; }
        public int AdditionId { get; set; }
    }
}
