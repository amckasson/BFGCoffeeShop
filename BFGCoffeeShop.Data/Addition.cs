using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Data
{
    public class Addition
    {
        [Key]
        public int? AdditionId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        public int CustomerId { get; set; }
        //public virtual Customer Customer { get; set; }
    }
}