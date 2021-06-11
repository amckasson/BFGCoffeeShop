﻿using BFGCoffeeShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Models.MenuModels
{
    public class MenuCreate
    {
 
        public string ItemName { get; set; }

        public decimal ItemPrice { get; set; }

       public int CustomerId { get; set; }
       public virtual Customer Customer { get; set; }
       
    }
}
