using BFGCoffeeShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        //[ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public virtual List<Menu> Menus { get; set; }

        //public int AdditionId { get; set; }
        public virtual List<Addition> Additions { get; set; }

        //public int CoffeeShopId { get; set; }
        public virtual List<Customer> Customer { get; set; }
    }
}