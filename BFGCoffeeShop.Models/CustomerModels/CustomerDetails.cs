using BFGCoffeeShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Models.CustomerModels
{
    public class CustomerDetails
    {
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //public string FullName { get; set; }

        [Required]
        public string PaymentType { get; set; }

        public int CoffeeOrder { get; set; }
        //public int MenuId { get; set; }
        //public virtual List<Menu> Menus { get; set; }

        //public int AdditionId { get; set; }
        //public virtual List<Addition> Additions { get; set; }
        //public List<FavoriteOrder> FavoriteOrders { get; set; }
    }
}
