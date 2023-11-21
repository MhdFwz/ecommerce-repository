using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Model
{
    public class CustomerOrderDetailsModel
    {
        public CustomerDetailsModel Customer { get; set; }

        public CustomerOrderModel Order { get; set; }
    }
}
