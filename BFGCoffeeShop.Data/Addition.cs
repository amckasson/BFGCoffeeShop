using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("CoffeeOrder")]
        public int CoffeeOrderId { get; set; }
        public virtual CoffeeOrder CoffeeOrder { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
