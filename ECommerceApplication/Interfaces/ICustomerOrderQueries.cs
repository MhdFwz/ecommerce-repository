using ECommerceApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Interfaces
{
    public interface ICustomerOrderQueries
    {
        CustomerOrderDetailsModel GetRecentOrderDetails(RecentOrderModel recentOrderModel);
    }
}
