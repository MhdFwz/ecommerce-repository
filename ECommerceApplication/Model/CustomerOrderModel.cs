using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Model
{
    public class CustomerOrderModel
    {
        public CustomerOrderModel()
        {
            OrderItem = new List<OrderItemModel>();
        }

        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public List<OrderItemModel> OrderItem { get; set; }
        public DateTime DeliveryExpected { get; set; }
    }
}
