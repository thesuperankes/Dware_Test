using Dapper;
using DataAccess.DW.DataAccess.Interfaces;
using Entities.Order;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DW.DataAccess
{
    public class OrderDA : IOrderDA
    {

        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public CreateOrderOut CreateOrder(CreateOrderIn input)
        {
            CreateOrderOut response = new CreateOrderOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error,
                Message = ""
            };
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var sql = @"INSERT INTO tbl_Order(ClientId,PurchaseDate,Total) VALUES (@ClientId,GETDATE(),@Total); SELECT CAST(SCOPE_IDENTITY() as int);";

                    var orderId = connection.ExecuteScalar<int>(sql, input.order);
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;
                    response.OrderId = orderId;

                }

                return response;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    response.Message = "No se encontro un ClientId valido";
                else
                    response.Message = "Ocurrio un problema al agregar el registro";

                return response;
            }

        }

        public DeleteOrderOut DeleteOrder(int orderId)
        {
            DeleteOrderOut response = new DeleteOrderOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error,
                Message = ""
            };
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "DELETE FROM tbl_Order WHERE OrderId = @OrderId";

                    connection.Execute(sql, new { OrderId = orderId });

                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;

                }

                return response;
            }
            catch (SqlException ex)
            {
                return response;
            }

        }

        public UpdateOrderOut UpdateOrder(UpdateOrderIn input)
        {
            UpdateOrderOut response = new UpdateOrderOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error,
                Message = ""
            };
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var sql = @"UPDATE tbl_Order SET ClientId = @ClientId, Total = @Total WHERE OrderId = @OrderId;";

                    var orderId = connection.ExecuteScalar<int>(sql, input.order);
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;
                }

                return response;
            }
            catch (SqlException ex)
            {
                return response;
            }

        }

        public CreateProductOrderOut CreateProductOrder(CreateProductOrderIn input)
        {
            CreateProductOrderOut response = new CreateProductOrderOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error,
                Message = ""
            };
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var sql = @"INSERT INTO tbl_ProductOrder(ProductId,OrderId,Quantity,UnitPrice) VALUES(@ProductId,@OrderId,@Quantity, @UnitPrice); SELECT CAST(SCOPE_IDENTITY() as int);";

                    var productOrderId = connection.ExecuteScalar<int>(sql, input);

                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;
                    response.productOrderId = productOrderId;
                }

                return response;

            }
            catch (SqlException ex)
            {
                return response;
            }

        }

        public GetAllOrdersOut GetAllOrders()
        {
            GetAllOrdersOut response = new GetAllOrdersOut()
            {
                ResponseCode = Entities.Client.General.ResponseCode.Error,
                Message = "Ocurrio un error al obtener los registros"

            };
            try
            {
                using (IDbConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DynamicParameters param = new DynamicParameters();


                    var data = connection.Query<Order>("SELECT [OrderId] , c.FirstName + ' ' + c.LastName [ClientName], c.ClientId ,[PurchaseDate] ,[Total] FROM tbl_Order o INNER JOIN tbl_Client c ON o.ClientId = c.ClientId ORDER BY PurchaseDate DESC");

                    var orderList = new List<Order>();

                    foreach (var i in data)
                    {
                        var order = new Order()
                        {
                            OrderId = i.OrderId,
                            ClientId = i.ClientId,
                            Total = i.Total,
                            PurchaseDate = i.PurchaseDate,


                        };

                        orderList.Add(order);
                    }

                    response.order = orderList;
                    response.ResponseCode = Entities.Client.General.ResponseCode.Success;



                    if (response.order.Count == 0)
                        response.Message = "No se encontraron registros";

                }

                return response;
            }
            catch (SqlException ex)
            {
                return response;
            }

        }
    }
}
