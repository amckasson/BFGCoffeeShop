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
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Edited { get; set; }
        public string Country { get; set; }
        public string Barista { get; set; }

        decimal Total = 0;
        public decimal TotalPrice
        {
            get
            {
                foreach (Addition add in Additions)
                {
                    Total += add.Price;
                }
                foreach(Menu menu in Menus)
                {
                    Total += menu.ItemPrice;
                }
                return Total;
            }
        }
       
        public virtual List<Menu> Menus { get; set; }
       
        public virtual List<Addition> Additions { get; set; }

        public virtual List<Customer> Customer { get; set; }
    }
}