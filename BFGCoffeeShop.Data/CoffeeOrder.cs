using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Data
{
    public class CoffeeOrder
    {
        [Key]
        public int CoffeeOrderId { get; set; }
        public Guid CoffeeOrderTag { get; set; }
        public string FullName { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Edited { get; set; }
        public string Country { get; set; }
        public decimal TotalPrice { get; set; }
        public string Barista { get; set; }

        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public virtual Customer Customers { get; set; }
    }
}