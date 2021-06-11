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
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public Guid CustomerTag { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        [Required]
        public string PaymentType { get; set; }


        //[ForeignKey("CoffeeOrder")]
        //public int CoffeeOrderId { get; set; }

        //      public List<FavoriteOrder> FavoriteOrders { get; set; }

        //      public List<FavoriteOrder> FavoriteOrders { get; set; } stretch goal
    }
}
