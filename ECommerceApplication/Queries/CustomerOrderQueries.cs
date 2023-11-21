using ECommerceApplication.Interfaces;
using ECommerceApplication.Model;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Logging;
using ECommerceApplication.Exception;

public class CustomerOrderQueries : ICustomerOrderQueries
{
    private const string ConnectionStringName = "DbConnection";
    private readonly IConfiguration _configuration;
    private readonly ILogger<CustomerOrderQueries> _logger;

    public CustomerOrderQueries(IConfiguration configuration, ILogger<CustomerOrderQueries> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public CustomerOrderDetailsModel GetRecentOrderDetails(RecentOrderModel recentOrderModel)
    {
        List<OrderItemModel> ordersItems = new List<OrderItemModel>();
        CustomerOrderDetailsModel customerOrderDetailsModel = new CustomerOrderDetailsModel();

        try
        {
            string connectionString = _configuration.GetConnectionString(ConnectionStringName);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand sqlComm = new SqlCommand("dbo.spGetRecentOrder", conn))
                {
                    sqlComm.Parameters.AddWithValue("@User", recentOrderModel.User);
                    sqlComm.Parameters.AddWithValue("@CustomerId", recentOrderModel.CustomerId);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(sqlComm))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        DataTable dataTable = ds.Tables[0];
                        DataTable dataTable1 = ds.Tables[1];

                        foreach (DataRow row in dataTable1.Rows)
                        {
                            OrderItemModel orderItemModel = new OrderItemModel()
                            {
                                Price = row.Field<decimal>("PriceEach"),
                                ProductName = row.Field<string>("Product"),
                                Quantity = row.Field<int>("Quantity")
                            };
                            ordersItems.Add(orderItemModel);
                        }

                        customerOrderDetailsModel.Customer = new CustomerDetailsModel()
                        {
                            FirstName = dataTable.Rows[0]["FirstName"].ToString(),
                            LastName = dataTable.Rows[0]["LastName"].ToString()
                        };

                        customerOrderDetailsModel.Order = new CustomerOrderModel()
                        {
                            DeliveryAddress = dataTable.Rows[0]["DeliveryAddress"].ToString(),
                            DeliveryExpected = (DateTime)dataTable.Rows[0]["DeliveryExpected"],
                            OrderDate = (DateTime)dataTable.Rows[0]["OrderDate"],
                            OrderNumber = (int)dataTable.Rows[0]["OrderNumber"],
                            OrderItem = ordersItems
                        };
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message.ToString());
            throw;
        }

        return customerOrderDetailsModel;
    }
}
