using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Models.CustomerModels
{
    public class CustomerEdit
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PaymentType { get; set; }

        //      public List<FavoriteOrder> FavoriteOrders { get; set; }
    }
}
