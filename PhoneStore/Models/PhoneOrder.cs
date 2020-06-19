using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models
{
    public class PhoneOrder
    {
        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
