using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Model
{
    public class RecentOrderModel
    {
        [Required]
        public string User { get; set; }
        [Required]
        public string CustomerId { get; set; }
    }
}
