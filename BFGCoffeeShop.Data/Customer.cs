﻿using System;
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
        public int MenuId { get; set; }
        public virtual List<Menu> Menu { get; set; }

        public int AdditionId { get; set; }
        public virtual List<Addition> Addition { get; set; }

        //public List<FavoriteOrder> FavoriteOrders { get; set; } stretch goal
    }
}
