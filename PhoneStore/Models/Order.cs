﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Phone Phone { get; set; }
        public ICollection<PhoneOrder> PhoneOrders { get; set; }
    }
}
