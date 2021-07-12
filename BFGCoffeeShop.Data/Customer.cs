using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Data
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        public Guid CustomerTag { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PaymentType { get; set; }

        public int CoffeeOrderId { get; set; }
        //public virtual CoffeeOrder CoffeeOrder { get; set; }
        //public List<FavoriteOrder> FavoriteOrders { get; set; } stretch goal
    }
}
