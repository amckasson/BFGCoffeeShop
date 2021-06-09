using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Data
{
    public class CoffeeOrder
    {
        [Key]
        public int CoffeeOrderId { get; set; }
        public string FullName { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Edited { get; set; }
        public string Country { get; set; }
        public decimal TotalPrice { get; set; }
        public string Barista { get; set; }
        public int? AdditionId { get; set; }
        public virtual List<Addition> Additions { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customers { get; set; }
        public int MenuId { get; set; }
        public virtual List<Menu> Menus { get; set; }  
    }
}
