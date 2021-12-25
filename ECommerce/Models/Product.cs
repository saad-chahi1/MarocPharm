using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required]
        [StringLength(255)]
        [DisplayName("Product")]
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }

        public Category Category { get; set; }
        public long CategoryID { get; set; }

        public Current Current { get; set; }
        public long CurrentID { get; set; }
    }
}
