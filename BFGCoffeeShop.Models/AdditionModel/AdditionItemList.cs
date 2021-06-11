using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Models.AdditionModels
{
    public class AdditionItemList
    {
        public int AdditionId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CustomerId { get; set; }
    }
}
