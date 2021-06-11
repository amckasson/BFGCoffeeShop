﻿using BFGCoffeeShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Models.AdditionModels
{
    public class AdditionCreate
    {
        //public Guid CustomerOrder { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
