using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models
{
    public class Phone
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PhoneOrder> PhoneOrders { get; set; }

    }
}
