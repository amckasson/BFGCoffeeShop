﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Models.MenuModels
{
    public class MenuDetail
    {
        public int MenuId { get; set; }
        public int CoffeeOrderId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        
    }
}
