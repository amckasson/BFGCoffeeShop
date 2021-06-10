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
        public Guid CustomerOrder { get; set; }
        public string FullName
        {
            get
            {
                return Customer.FullName;
            }
        }
        public string Country { get; set; }
        public string Barista { get; set; }
        public decimal TotalPrice { get; set; }
        public int? AdditionId { get; set; }
        public virtual List<Addition> Additions { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int MenuId { get; set; }
        public virtual List<Menu> MenuItem { get; set; }

        public decimal getTotalPrice()
        {
            foreach (Menu Item in MenuItem)
            {
                TotalPrice += Item.ItemPrice;
            }
            foreach (Addition Item in Additions)
            {
                if (Item != null)
                    TotalPrice += Item.Price;
            }
            return TotalPrice;
        }

        public Guid getGUID()
        {
            return CustomerOrder = Customer.CustomerTag;
        }

    }
}
