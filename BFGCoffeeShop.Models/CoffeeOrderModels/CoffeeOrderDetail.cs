using BFGCoffeeShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Models.CoffeeOrderModels
{
    public class CoffeeOrderDetail
    {
        public int CoffeeOrderId { get; set; }
        public string FullName { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Edited { get; set; }
        public string Country { get; set; }
        public string Barista { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual IEnumerable<Addition> Additions { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int MenuId { get; set; }
        public virtual Menu MenuItem { get; set; }
    }
}
