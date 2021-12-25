using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class CurrencyViewModel
    {
        public IEnumerable<ECommerce.Models.Current> Currencies { get; set; }
        public ECommerce.Models.Current Currency { get; set; }
    }
}
