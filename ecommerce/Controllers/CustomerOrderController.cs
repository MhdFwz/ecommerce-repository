using ECommerceApplication.Interfaces;
using ECommerceApplication.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerOrderController : ControllerBase
    {
        private ICustomerOrderQueries _customerOrderQueries;
        private readonly ILogger<CustomerOrderController> _logger;
        public CustomerOrderController(ICustomerOrderQueries customerOrderQueries, ILogger<CustomerOrderController> logger)
        {
            _customerOrderQueries = customerOrderQueries ?? throw new ArgumentNullException(nameof(customerOrderQueries));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [HttpPost("GetCustomerRecentOrder")]
        public IActionResult GetCustomerRecentOrder(RecentOrderModel recentOrderModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }

                var result = _customerOrderQueries.GetRecentOrderDetails(recentOrderModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetCustomerRecentOrder");
                return BadRequest("An error occurred while processing the request.");
            }
        }
    }

}
