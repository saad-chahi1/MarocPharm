using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class CategoryViewModel
    {
        public IEnumerable<ECommerce.Models.Category> Categories { get; set; }
        public ECommerce.Models.Category Category { get; set; }
    }
}
