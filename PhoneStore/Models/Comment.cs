using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneStore.Models
{
    public class Comment
    {
        public int id { get; set; }

        [RegularExpression(@"^[A-Za-z0-9\s]*$")]
        [StringLength(50)]
        public string Title { get; set; }

        [RegularExpression(@"^[A-Za-z0-9\s]*$")]
        [StringLength(200)]
        public string Body { get; set; }

        [RegularExpression(@"^[A-Za-z0-9\s]*$")]
        [StringLength(30)]
        public string SentBy { get; set; }
        public DateTime Posted { get; set; }
        public string IP { get; set; }

        public Phone Phone { get; set; }

    }
}
